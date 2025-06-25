using Models;
using System.Diagnostics;
using System.Text;

namespace NightreignSaveManager.Helpers
{
    //Credit to EonaCat for use decryption and file handling  
    internal class Data
    {
        private const int HeaderLength = 12;
        private const int DataBlock = 32;
        private const int DataBlockSize = 64;

        private static readonly List<BND4Entry> entries = new();
        private static byte[]? RawData;

        private static readonly string _outputFolder = Dir.dataPath;
        public static string OutputFolder => _outputFolder;

        private static byte[] divider = [0x40, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF];

        private static ulong steamID64;

        public static string? Decrypt(string inputFile)
        {
            RawData = File.ReadAllBytes(inputFile);

            if (!IsValidHeader(BND4Entry.FILEIDENTIFIER, RawData))
            {
                return null;
            }

            entries.Clear();
            int numberEntries = BitConverter.ToInt32(RawData, HeaderLength);

            for (int i = 0; i < numberEntries; i++)
            {
                int pos = DataBlockSize + (i * DataBlock);
                if (pos + DataBlock > RawData.Length)
                {
                    break;
                }

                if (!IsValidDivider(RawData, pos))
                {
                    continue;
                }

                int size = BitConverter.ToInt32(RawData, pos + 8);
                int dataOffset = BitConverter.ToInt32(RawData, pos + 16);
                int footerLength = BitConverter.ToInt32(RawData, pos + 24);

                var entry = new BND4Entry(RawData, i, _outputFolder, size, dataOffset, footerLength);
                entry.Decrypt();//creates decrypted file
                entries.Add(entry);

                Debug.WriteLine($"Decrypted Entry #{i}: {entry.Name}");
                if (i == 10)
                {
                    byte[] oldSteamId;
                    byte[] newSteamId;
                    string ERData10Path = Path.Combine(Dir.dataPath, "ER_NR_DATA_10");
                    try
                    {
                        using var fs = new FileStream(ERData10Path, FileMode.Open, FileAccess.Read);//reads file; 'using var' auto closes stream after use
                        fs.Seek(0x8, SeekOrigin.Begin);//Moves the read position 8 bytes from the beginning of the file; 0x8 hex for 8
                        oldSteamId = new byte[8];//Initializes a new 8-byte array
                        fs.Read(oldSteamId, 0, 8);//Reads 8 bytes from the current file position (offset 8) into oldSteamId
                        Debug.WriteLine("Old Steam ID (bytes): " + BitConverter.ToString(oldSteamId));
                        ulong oldSteamId64 = BitConverter.ToUInt64(oldSteamId, 0);//ulong is a 64bit unsigned int; after convert is just an int
                        Debug.WriteLine("Old Steam ID (unsigned 64 int): " + oldSteamId64);
                        newSteamId = BitConverter.GetBytes(oldSteamId64);//convert back to 8
                        Debug.WriteLine("New Steam ID (bytes): " + BitConverter.ToString(newSteamId));
                    }
                    catch (Exception ex) { Debug.WriteLine(ex.ToString()); }
                }
            }
            Debug.WriteLine(entries.ToString());
            //FileHelper.TryCreateDirectory(_outputFolder, logger);
            return _outputFolder;
        }
        public static string GetSteamID(string inputFile)
        {
            RawData = File.ReadAllBytes(inputFile);
            int pos = DataBlockSize + (10 * DataBlock);//64 + 10 x 64

            if ((!IsValidHeader(BND4Entry.FILEIDENTIFIER, RawData))||(pos + DataBlock > RawData.Length) || (!IsValidDivider(RawData, pos)))
            {
                return "unknown";
            }

            int size = BitConverter.ToInt32(RawData, pos + 8);
            int dataOffset = BitConverter.ToInt32(RawData, pos + 16);
            int footerLength = BitConverter.ToInt32(RawData, pos + 24);

            var entry = new BND4Entry(RawData, 10, "", size, dataOffset, footerLength);

            byte[] steamID = new byte[8];

            try
            {
                using var ms = new MemoryStream(entry.DecryptMS());
                ms.Seek(0x8, SeekOrigin.Begin);
                ms.Read(steamID, 0, 8);
                steamID64 = BitConverter.ToUInt64(steamID, 0);
                //Debug.WriteLine("Steam ID (bytes): " + BitConverter.ToString(steamID));
                //Debug.WriteLine("Steam ID (unsigned 64 int): " + steamID64);
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.ToString());
            }

            //Debug.Write("SteamID decrypted");
            return steamID64.ToString();
        }
        public static string? Encrypt(string inputFile)
        {
            return "";
        }

        internal static bool IsValidHeader(string fileIdentifier, byte[] data)
        {
            //Debug.WriteLine("Checking data for valid header " + fileIdentifier);
            byte[] byteIdentifier = Encoding.ASCII.GetBytes(fileIdentifier);
            if (data != null && data.Length >= fileIdentifier.Length && data.Take(fileIdentifier.Length).SequenceEqual(byteIdentifier))
            {
                //Debug.WriteLine("Header is valid");
                return true;
            }
            else { return false; }
        }
        internal static bool IsValidDivider(byte[] data, int position)
        {
            return data.Skip(position).Take(divider.Length).SequenceEqual(divider);
        }
    }
}
//Credit to EonaCat for file structure and data info
using NightreignSaveManager.Models;
using System.Diagnostics;
using System.Text;

namespace NightreignSaveManager.Helpers
{
    public class Data
    {
        public const string fileIdentifier = "BND4";

        private static byte[] DS2_KEY = { 0x18, 0xF6, 0x32, 0x66, 0x05, 0xBD, 0x17, 0x8A, 0x55, 0x24, 0x52, 0x3A, 0xC0, 0xA0, 0xC6, 0x09 };
        private static byte[] divider = [0x40, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF];

        public const int DataBlock = 32;
        public const int DataBlockSize = 64;
        public const int IV_SIZE = 16;
        private const int steamIDHex = 16;

        private static ulong steamID64;

        public static string? GetSteamID(string inputFile)
        {
            byte[] rawData = File.ReadAllBytes(inputFile);
            byte[]? steamID = new byte[8];

            int pos = DataBlockSize + (10 * DataBlock);//10 is steamid location

            if ((!IsValidHeader(fileIdentifier, rawData))||(pos + DataBlock > rawData.Length) || (!IsValidDivider(rawData, pos)))
            {
                return null;
            }

            int size = BitConverter.ToInt32(rawData, pos + 8);
            int dataOffset = BitConverter.ToInt32(rawData, pos + 16);
            int footerLength = BitConverter.ToInt32(rawData, pos + 24);

            byte[] encryptedData = rawData.Skip(dataOffset).Take(size).ToArray();
            byte[] iv = encryptedData.Take(IV_SIZE).ToArray();
            byte[] encryptedPayload = encryptedData.Skip(IV_SIZE).ToArray();

            byte[] decryptedData = Transform.DecryptEngine(rawData, DS2_KEY, iv, encryptedPayload);

            try
            {
                //decriptor using decrypted entry
                using var ms = new MemoryStream(decryptedData);
                ms.Seek(0x8, SeekOrigin.Begin);
                ms.Read(steamID, 0, 8);
                steamID64 = BitConverter.ToUInt64(steamID, 0);
                Debug.WriteLine("Steam ID (bytes): " + BitConverter.ToString(steamID));
                Debug.WriteLine("Steam ID (unsigned 64 int): " + steamID64);
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.ToString());
            }
            if(steamID == null)
            {
                return null;
            } 
            else
            {
                return steamID64.ToString();
            }
        }
        internal static byte[]? ConvertToSteamIdBytes(string steamId)
        {
            if (string.IsNullOrEmpty(steamId) || steamId.Length != 17 || !steamId.All(char.IsDigit))
            {
                return null;
            }

            var hex = Convert.ToUInt64(steamId).ToString("x").PadLeft(steamIDHex, '0');
            var steamIdBytes = Enumerable.Range(0, hex.Length)
                                         .Where(i => i % 2 == 0)
                                         .Select(i => Convert.ToByte(hex.Substring(i, 2), 16))
                                         .Reverse().ToArray();
            return steamIdBytes;
        }
        internal static bool IsValidHeader(string fileIdentifier, byte[] data)
        {
            byte[] byteIdentifier = Encoding.ASCII.GetBytes(fileIdentifier);
            if (data != null && data.Length >= fileIdentifier.Length && data.Take(fileIdentifier.Length).SequenceEqual(byteIdentifier))
            {
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

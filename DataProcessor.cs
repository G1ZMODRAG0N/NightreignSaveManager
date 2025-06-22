using Models;
using System.Diagnostics;


namespace NightreignSaveManager.Helpers
{
    internal static class DataProcessor
    {
        private const int HeaderLength = 12;
        private const int DataBlock = 32;
        private const int DataBlockSize = 64;

        private static readonly List<BND4Entry> entries = new();
        private static byte[]? RawData;

        //private static readonly string _outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EonaCat", "NightReign", "Temp");

        public static string? Decrypt(string inputFile)
        {
            RawData = File.ReadAllBytes(inputFile);

            if(!DataHelpers.IsValidHeader(BND4Entry.FILEIDENTIFIER, RawData))
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

                if (!DataHelpers.IsValidDivider(RawData, pos))
                {
                    continue;
                }

                int size = BitConverter.ToInt32(RawData, pos + 8);
                int dataOffset = BitConverter.ToInt32(RawData, pos + 16);
                int footerLength = BitConverter.ToInt32(RawData, pos + 24);

                var entry = new BND4Entry(RawData, i, "_outputFolder", size, dataOffset, footerLength);
                entry.Decrypt();
                entries.Add(entry);

                Debug.WriteLine($"Decrypted Entry #{i}: {entry.Name}");
                if (i == 10)
                {/*
                    byte[] oldSteamId;
                    try
                    {
                        using var fs = new FileStream(entry, FileMode.Open, FileAccess.Read);
                        fs.Seek(0x8, SeekOrigin.Begin);
                        oldSteamId = new byte[STEAM_ID_BYTE_LENGTH];
                        fs.Read(oldSteamId, 0, STEAM_ID_BYTE_LENGTH);
                    }*/
                }
            }
            Debug.WriteLine(entries.ToString());
            //FileHelper.TryCreateDirectory(_outputFolder, logger);
            return "";// _outputFolder;
        }
    }
}


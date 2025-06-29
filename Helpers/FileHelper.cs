﻿//Credit to https://github.com/EonaCat/NightReign
namespace NightreignSaveManager.Helpers
{
    internal class FileHelper
    {
        public static void TryCreateDirectory(string path, Action<string> logCallback)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                logCallback?.Invoke($"Failed to create output directory: {ex.Message}");
            }
        }
    }
}
using System.Diagnostics;

namespace NightreignSaveManager.Helpers
{
    internal class Dir
    {
        internal static string rootPath = AppDomain.CurrentDomain.BaseDirectory;

        internal static string BaseArchivePath = Path.Combine(rootPath, "archive");
        internal static string archivePath = @"";

        internal static string BaseBackupPath = Path.Combine(rootPath, "backup");
        internal static string backupPath = @"";

        internal static string baseDir = Environment.ExpandEnvironmentVariables("%APPDATA%") + @"\Nightreign";

        internal static List<string> steamFolders = Directory.GetDirectories(baseDir)
            .Where(dir => Path.GetFileName(dir).All(char.IsDigit) && Path.GetFileName(dir).Length == 17).ToList();
        internal static string savefilePath = @"";
        public static void CheckStructure()
        {
            Debug.WriteLine("Checking for archive directory...");
            if (!Directory.Exists(archivePath))
            {
                Debug.WriteLine("No archive directory detected. Creating: " + archivePath);
                Directory.CreateDirectory(archivePath);
            }
            if (!Directory.Exists(backupPath))
            {
                Debug.WriteLine("No backup directory detected. Creating: " + backupPath);
                Directory.CreateDirectory(backupPath);
            }
            if (!Directory.Exists(archivePath))
            {
                Debug.WriteLine("No data directory detected. Creating: ");
            }
        }
    }
}

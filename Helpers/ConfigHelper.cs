using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace NightreignSaveManager.Helpers
{
    internal static class Config
    {
        internal static string steamID = string.Empty;
        public static void Write(string root, List<string> folders, string version, string lastUpdate, Form form, bool change)
        {
            Debug.WriteLine("Checking if config exists...");

            if (!File.Exists(Path.Combine(root, "config.json")) || change)
            {
                Debug.WriteLine("Creating/Updating config. Setting SteamID...");

                string? selectedID = new DirectoryInfo(folders[0]).Name;

                if (folders == null)
                {
                    MessageBox.Show("Unable to locate steamID in the save directory. Please ensure Nightreign is properly installed...Exiting.");
                    form.Close();
                    return;
                }
                else if (folders.Count > 0)
                {
                    selectedID = SteamSelect.ShowDialog("Select or type in a SteamID:", "Select SteamID");
                }
                if (string.IsNullOrEmpty(selectedID) && !change)
                {
                    MessageBox.Show("No SteamID was selected. Exiting...");
                    form.Close();
                    return;
                }
                else if (string.IsNullOrEmpty(selectedID) && change)
                {
                    return;
                }
                var config = new
                {
                    App = "NighreignSaveManager",
                    Version = version,
                    SteamID = selectedID,
                    LastUpdated = lastUpdate
                };
                string jsontoString = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                try
                {
                    using (FileStream fs = File.Create(Path.Combine(root, "config.json")))
                    {
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            writer.WriteLine(jsontoString);
                            if (change)
                            {
                                MessageBox.Show("Your default SteamID has been updated to: " + selectedID);

                                Dir.savefilePath = Path.Combine(Dir.baseDir, selectedID);

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

            string jsonPath = Path.Combine(root, "config.json");

            string jsonFile = File.ReadAllText(jsonPath);

            steamID = Regex.Match(jsonFile, @"\b\d{17}\b").ToString();//find alternative that does not use regex

            Debug.WriteLine("Default SteamID set to: " + steamID);

            Dir.savefilePath = Path.Combine(Dir.baseDir, steamID);

            Dir.archivePath = Path.Combine(Dir.BaseArchivePath, steamID);

            Dir.backupPath = Path.Combine(Dir.BaseBackupPath, steamID);

            Dir.CheckStructure();
        }
    }
}
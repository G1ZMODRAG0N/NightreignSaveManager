using NightreignSaveManager;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using SteamID.Select;

namespace Helper.Utils
{
    public static class Helpers
    {
        public static string steamID = "";
        public static void WriteConfig(string root, List<string> folders, string version, string lastUpdate, Form form, bool change)
        {
            //create config file on first run
            if (!File.Exists(Path.Combine(root, "config.json")) || change)
            {
                //set steamid
                string selectedID = new DirectoryInfo(folders[0]).Name;
                Debug.WriteLine(selectedID);
                if (folders == null)
                {
                    MessageBox.Show("Unable to locate steamID in the save directory. Please ensure Nightreign is properly installed...Exiting.");
                    form.Close();
                    return;
                }
                else if (folders.Count > 0)
                {
                    selectedID = SteamSelect.ShowDialog("Select default SteamID:", "Select SteamID", folders);
                }
                if (selectedID == null && !change)
                {
                    MessageBox.Show("No SteamID was selected. Exiting...");
                    form.Close();
                    return;
                } else if (selectedID == null && change)
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
                //write json to stream
                using (FileStream fs = File.Create(Path.Combine(root, "config.json")))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        //write
                        writer.WriteLine(jsontoString);
                        //feedback if changed
                        if (change) 
                        {
                            MessageBox.Show("Your default SteamID has been updated."); 
                            Form1.savefilePath = Path.Combine(Form1.baseDir, selectedID); 
                        }
                    }
                }
            }
            //set up config
            string jsonPath = Path.Combine(root, "config.json");
            string jsonFile = File.ReadAllText(jsonPath);
            Debug.WriteLine("Checking if config exists...");
            // Get the SteamID value
            steamID = Regex.Match(jsonFile, @"\b\d{17}\b").ToString();//find alternative that does not use regex
            Debug.Write(steamID + "\n");
            //set save location path
            Form1.savefilePath = Path.Combine(Form1.baseDir, steamID);
        }
        //open URL
        public static void OpenURL(string url)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }
        //open directory
        public static void OpenDir(string path)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    Arguments = path,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link: " + ex.Message);
            }
        }
        //open note
        public static void OpenNote(string path)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "notepad.exe",
                    Arguments = path,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to launch: " + ex.Message);
            }
        }
        //open seemless
        public static void OpenSeemless(string path)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "nrsc_launcher.exe",
                    WorkingDirectory = path,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to launch: " + ex.Message);
            }
        }
        //open vanilla
        public static void OpenVanilla(string path)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "start_protected_game.exe",
                    WorkingDirectory = path,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to launch: " + ex.Message);
            }
        }
        
    }
}
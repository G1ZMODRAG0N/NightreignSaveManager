using System.Diagnostics;

namespace NightreignSaveManager.Helpers
{
    internal static class Link
    {
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
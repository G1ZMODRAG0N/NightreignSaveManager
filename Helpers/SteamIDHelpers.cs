using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace NightreignSaveManager.Helpers
{
    public static class SteamSelect
    {
        public static List<string> personaList = new List<string>();
        public static List<string> steamIDList = new List<string>();
        public static void FindSteamIDs()
        {
            string registryKey;
            if(Environment.Is64BitOperatingSystem)
            {
                registryKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam";
            }
            else
            {
                registryKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam";
            }

            if(registryKey == null || steamIDList.Count > 0)
            {
                return;
            }

            var steamAccounts = new List<string>();
            string steamPath = Registry.GetValue(registryKey, "InstallPath", null) as string;
            string loginPath = Path.Combine(steamPath, "config");
            string vdfFile = Path.Combine(loginPath, "loginusers.vdf");

            if (!File.Exists(vdfFile))
            {
                Debug.WriteLine("no path found" + vdfFile);
                return;
            }

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            string logins = File.ReadAllText(vdfFile).Remove(0,7);
            MatchCollection personaNames = Regex.Matches(logins, "\"PersonaName\"\\s+\"([^\"]+)\"");
            Debug.WriteLine(logins);
            MatchCollection ids = Regex.Matches(logins, @"\b\d{17}\b");
            foreach (Match id in ids)
            {
                steamIDList.Add(id.Value);
                
            }
            foreach (Match name in personaNames)
            {
                personaList.Add(name.Value.Remove(0,14).Trim());

            }
            Debug.WriteLine("SteamIDs found: " + string.Join(", ", steamIDList));
            Debug.WriteLine(string.Join(", ", personaList));
            //return steamIDList;

        }

        public static string Confirmation(ListView listView, TextBox textBox, string result, Form steamselect)
        {
            if (listView.SelectedItems.Count <= 0 && textBox.Text.Length <= 0)
            {
                MessageBox.Show("Please select at least one steamID");

            }
            else if ((textBox.Text.Length > 17 || textBox.Text.Length < 17 || Regex.IsMatch(textBox.Text, "[a-zA-Z]")) && listView.SelectedItems.Count <= 0)
            {
                MessageBox.Show("SteamID input must be 17 digits with no letters");
            }
            else if (textBox.Text.Length > 0)
            {
                if (Path.Exists(Path.Combine(Dir.baseDir, textBox.Text)))
                {
                    result = textBox.Text;
                    steamselect.DialogResult = DialogResult.OK;
                    steamselect.Close();
                }
                else
                {
                    MessageBox.Show("There is no save file directory for that SteamID");
                }

            }
            else
            {
                if (Path.Exists(Path.Combine(Dir.baseDir, textBox.Text)))
                {
                    result = listView.SelectedItems[0].Text;
                    steamselect.DialogResult = DialogResult.OK;
                    steamselect.Close();
                }
                else
                {
                    MessageBox.Show("There is no save file directory for that SteamID");
                }

            }
            return result;
        }

        public static string ShowDialog(string text, string caption, List<string> path)
        {
            string result = "";

            Form steamselect = new Form();
            steamselect.Width = 300;
            steamselect.Height = 260;
            steamselect.FormBorderStyle = FormBorderStyle.FixedDialog;
            steamselect.Text = caption;
            steamselect.StartPosition = FormStartPosition.CenterScreen;

            Label textLabel = new Label();
            textLabel.Left = 25;
            textLabel.Top = 20;
            textLabel.Text = text;
            textLabel.AutoSize = true;

            ListView listView = new ListView();
            listView.Left = 25;
            listView.Top = 40;
            listView.Width = 235;
            listView.Height = 100;
            listView.FullRowSelect = true;
            listView.View = View.Details;
            listView.Columns.Add("SteamID(s)", 113);//listView.Width - 4);
            listView.Columns.Add("Username",120);
            listView.AllowColumnReorder = false;
            listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            

            TextBox textBox = new TextBox();
            textBox.Left = 25;
            textBox.Top = 150;
            textBox.Width = 235;


            //populate listview with steamids from folders listed
            FindSteamIDs();
            for (int i = 0; i < steamIDList.Count; i++)
            {
                ListViewItem item = new ListViewItem(steamIDList[i]);
                listView.Items.Add(item);
                item.SubItems.Add(personaList[i]);
            }

            listView.Items[0].Selected = true;
            listView.Select(); // Gives focus to the ListView, so selection is visible

            //confirm button
            Button confirmation = new Button();
            confirmation.Text = "Select";
            confirmation.Left = 60;
            confirmation.Width = 80;
            confirmation.Top = 180;
            //confirmation.DialogResult = DialogResult.OK;
            confirmation.Click += (sender, e) =>
            {
                result = Confirmation( listView, textBox, result, steamselect);
            };
            listView.DoubleClick += (sender, e) =>
            {
                result = Confirmation(listView, textBox, result, steamselect);
            };

            //cancel button
            Button cancel = new Button();
            cancel.Text = "Cancel";
            cancel.Left = 150;
            cancel.Width = 80;
            cancel.Top = 180;
            //cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancel.Click += (sender, e) =>
            {
                steamselect.DialogResult = DialogResult.Cancel;
                steamselect.Close();
            };

            //check id button
            Button checkID = new Button();
            checkID.Text = "CheckID";
            checkID.Left = 180;
            checkID.Width = 80;
            checkID.Top = 10;
            checkID.Click += (sender, e) =>
            {
                if (listView.SelectedItems.Count > 0)
                {
                    string selectedID = new DirectoryInfo(listView.SelectedItems[0].Text).Name;
                    string steamURL = "https://steamcommunity.com/profiles/" + selectedID;
                    Link.OpenURL(steamURL);
                    Debug.WriteLine(selectedID);
                }
                else
                {
                    MessageBox.Show("Please select an ID in the list to check.");
                }
            }; 

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(checkID, "Click to check your Steam ID. (Opens your steam profile)");

            //controls add
            steamselect.Controls.Add(textLabel);
            steamselect.Controls.Add(textBox);
            steamselect.Controls.Add(listView);
            steamselect.Controls.Add(confirmation);
            steamselect.Controls.Add(cancel);
            steamselect.Controls.Add(checkID);
            steamselect.AcceptButton = confirmation;
            steamselect.MinimizeBox = false;
            steamselect.MaximizeBox = false;
            steamselect.HelpButton = true;
            steamselect.HelpButtonClicked += (sender, e) => { Link.OpenURL("https://help.steampowered.com/en/faqs/view/2816-BE67-5B69-0FEC"); };

            var dialogResult = steamselect.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}

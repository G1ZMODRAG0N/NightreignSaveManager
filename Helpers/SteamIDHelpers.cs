using System.Diagnostics;

namespace NightreignSaveManager.Helpers
{
    public static class SteamSelect
    {

        public static string ShowDialog(string text, string caption, List<string> path)
        {
            string result = null;

            Form steamselect = new Form();
            steamselect.Width = 300;
            steamselect.Height = 200;
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
            listView.Height = 70;
            listView.FullRowSelect = true;
            listView.View = View.Details;
            listView.Columns.Add("SteamID(s)", listView.Width - 4);
            listView.AllowColumnReorder = false;
            listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            //populate listview with steamids from folders listed
            foreach (var folder in path)
            {
                string steamID = new DirectoryInfo(folder).Name;
                ListViewItem item = new ListViewItem(steamID);
                listView.Items.Add(item);
                listView.Items[0].Selected = true;
                listView.Select(); // Gives focus to the ListView, so selection is visible
            }


            //confirm button
            Button confirmation = new Button();
            confirmation.Text = "Select";
            confirmation.Left = 60;
            confirmation.Width = 80;
            confirmation.Top = 120;
            //confirmation.DialogResult = DialogResult.OK;
            confirmation.Click += (sender, e) =>
            {
                if (listView.SelectedItems.Count > 0 && listView.SelectedItems[0].Text == Config.steamID)
                {
                    MessageBox.Show("You cannot select the same steamID.");
                    
                }
                else if (listView.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Please select at least one steamID");
                } else
                {
                    result = listView.SelectedItems[0].Text;
                    steamselect.DialogResult = DialogResult.OK;
                    steamselect.Close();
                }
            };

            //cancel button
            Button cancel = new Button();
            cancel.Text = "Cancel";
            cancel.Left = 150;
            cancel.Width = 80;
            cancel.Top = 120;
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
                string selectedID = new DirectoryInfo(listView.SelectedItems[0].Text).Name;
                string steamURL = "https://steamcommunity.com/profiles/" + selectedID;
                Link.OpenURL(steamURL);
                Debug.WriteLine(selectedID);
            }; 

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(checkID, "Click to check your Steam ID. (Opens your steam profile)");

            //controls add
            steamselect.Controls.Add(textLabel);
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
            } else
            {
                return null;
            }
        }
    }
}

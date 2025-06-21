using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace SteamID.Select
{
    public static class SteamSelect
    {
        public static string ShowDialog(string text, string caption, List<string> path)
        {
            System.Windows.Forms.Form steamselect = new System.Windows.Forms.Form();
            steamselect.Width = 300;
            steamselect.Height = 200;
            steamselect.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            steamselect.Text = caption;
            steamselect.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            System.Windows.Forms.Label textLabel = new System.Windows.Forms.Label();
            textLabel.Left = 25;
            textLabel.Top = 20;
            textLabel.Text = text;
            textLabel.AutoSize = true;

            System.Windows.Forms.ListView listView = new System.Windows.Forms.ListView();
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
            System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button();
            confirmation.Text = "Select";
            confirmation.Left = 60;
            confirmation.Width = 80;
            confirmation.Top = 120;
            confirmation.DialogResult = System.Windows.Forms.DialogResult.OK;
            confirmation.Click += (sender, e) => { steamselect.Close(); };

            //cancel button
            System.Windows.Forms.Button cancel = new System.Windows.Forms.Button();
            cancel.Text = "Cancel";
            cancel.Left = 150;
            cancel.Width = 80;
            cancel.Top = 120;
            cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            //check id button
            System.Windows.Forms.Button checkID = new System.Windows.Forms.Button();
            checkID.Text = "CheckID";
            checkID.Left = 180;
            checkID.Width = 80;
            checkID.Top = 10;
            checkID.Click += (sender, e) =>
            {
                string selectedID = new DirectoryInfo(listView.SelectedItems[0].Text).Name;
                string steamURL = "https://steamcommunity.com/profiles/" + selectedID;
                Helper.Utils.Helpers.OpenURL(steamURL);
                Debug.WriteLine(selectedID);
            };
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
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
            steamselect.HelpButtonClicked += (sender, e) => { Helper.Utils.Helpers.OpenURL("https://help.steampowered.com/en/faqs/view/2816-BE67-5B69-0FEC"); };


            System.Windows.Forms.DialogResult result = steamselect.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                return listView.SelectedItems[0].Text;
            }
            else
            {
                return null;
            }
        }
    }
}

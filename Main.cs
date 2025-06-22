using NightreignSaveManager.Helpers;
using NightreignSaveManager.Custom.ColorTable;
using System.Diagnostics;

namespace NightreignSaveManager
{
    //main form class
    public partial class Main : Form
    {

        //set versioning
        private static string currentVersion = "1.1.5";
        private static string lastUpdated = "06.22.25";

        //set mouse pos for click-drag move form
        private Point initialMousePosition;
        //Initialize Form
        public Main()
        {
            InitializeComponent();
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MyColorTable());
            Debug.WriteLine("Initializing...");
            Debug.WriteLine("Current version:" + currentVersion);
            Debug.WriteLine("Root set to: " + Dir.rootPath);
        }
        //refresh listview1
        private async void RefreshListView1()
        {
            listView1.Items.Clear();
            listView1.Cursor = Cursors.WaitCursor;
            await Task.Delay(500);
            listView1.Cursor = Cursors.Default;
            string[] archiveFiles = Directory.GetFiles(Dir.archivePath);
            foreach (var file in archiveFiles)
            {
                string filename = Path.GetFileName(file);
                string type = Path.GetExtension(file).TrimStart('.');  // Replace this with actual logic if needed
                //skip if not a er save
                if (type != "co2" ^ type != "sl2" ^ type != "bak")
                {
                    continue;
                }
                if (type == "co2")
                {
                    type = "Seemless";
                }
                else if (type == "sl2")
                {
                    type = "Vanilla";
                }
                else if (type == "bak")
                {
                    type = "Backup";
                }
                string date = File.GetLastWriteTime(file).ToString("yyyy-MM-dd HH:mm");

                ListViewItem item = new ListViewItem(filename);
                item.SubItems.Add(type);
                item.SubItems.Add(date);

                listView1.Items.Add(item);

                listView1.Items[0].Selected = true;
                listView1.Select(); // Gives focus to the ListView, so selection is visible
            }
            if (listView1.Items.Count <= 0)
            {
                setupText.Visible = true;
            }
            else { setupText.Visible = false; }
        }
        //refresh listview2
        private async void RefreshListView2()
        {
            Debug.WriteLine("Refreshing ListView2: " + Dir.savefilePath);
            listView2.Items.Clear();
            listView2.Cursor = Cursors.WaitCursor;
            button6.Cursor = Cursors.WaitCursor;
            viewBackups.Cursor = Cursors.WaitCursor;
            await Task.Delay(500);
            listView2.Cursor = Cursors.Default;
            button6.Cursor = Cursors.Default;
            viewBackups.Cursor = Cursors.Default;
            string[] files = Directory.GetFiles(Dir.savefilePath);
            foreach (var file in files)
            {
                string filename = Path.GetFileName(file);
                string type = Path.GetExtension(file).TrimStart('.');  // Replace this with actual logic if needed
                bool active = false;
                if (type == "sl2" || type == "co2")
                {
                    active = true;
                }
                //skip if not a er save
                if (type != "co2" ^ type != "sl2" ^ type != "bak")
                {
                    continue;
                }
                if (type == "co2")
                {
                    type = "Seemless";
                }
                else if (type == "sl2")
                {
                    type = "Vanilla";
                }
                else if (type == "bak")
                {
                    type = "Backup";
                }
                string date = File.GetLastWriteTime(file).ToString("yyyy-MM-dd HH:mm");

                ListViewItem item = new ListViewItem(filename);
                item.SubItems.Add(type);
                item.SubItems.Add(date);
                item.SubItems.Add(active.ToString());

                listView2.Items.Add(item);
            }
        }
        //refresh backuplistview
        private async void RefreshBackupListview()
        {
            backupListView.Items.Clear();
            backupListView.Cursor = Cursors.WaitCursor;
            await Task.Delay(500);
            backupListView.Cursor = Cursors.Default;
            string[] files = Directory.GetFiles(Dir.backupPath);
            foreach (var file in files)
            {
                string filename = Path.GetFileName(file);
                string type = Path.GetExtension(file).TrimStart('.');  // Replace this with actual logic if needed
                bool active = false;
                if (type == "sl2" || type == "co2")
                {
                    active = true;
                }
                //skip if not a er save
                if (type != "co2" ^ type != "sl2" ^ type != "bak")
                {
                    continue;
                }
                if (type == "co2")
                {
                    type = "Seemless";
                }
                else if (type == "sl2")
                {
                    type = "Vanilla";
                }
                else if (type == "bak")
                {
                    type = "Backup";
                }
                string date = File.GetLastWriteTime(file).ToString("yyyy-MM-dd HH:mm");

                ListViewItem item = new ListViewItem(filename);
                item.SubItems.Add(type);
                item.SubItems.Add(date);
                item.SubItems.Add(active.ToString());

                backupListView.Items.Add(item);
            }
        }
        //close backup view window
        private void CloseBackupWindow()
        {
            backupListView.Enabled = false;
            backupListView.Visible = false;
            if (listView1.Items.Count <= 0) { setupText.Visible = true; }
            viewBackups.Text = "View Backups";
            EnableAll();
        }
        //disable all
        public void DisableAll()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name == "viewBackups" || ctrl.Name == "closeButton" || ctrl.Name == "miniButton" || ctrl.Name == "listView1" || ctrl.Name == "listView2")
                {
                    continue;
                }
                ctrl.Enabled = false;
            }
        }
        //enable all
        public void EnableAll()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name == "viewBackups" || ctrl.Name == "closeButton" || ctrl.Name == "miniButton" || ctrl.Name == "listView1" || ctrl.Name == "listView2")
                {
                    continue;
                }
                ctrl.Enabled = true;
            }
        }
        //Load
        private void Form1_Load(object sender, EventArgs e)
        {
            //apply version to label text
            versionLabel.Text = "v" + currentVersion.ToString();
            //check/update config
            Config.Write(Dir.rootPath, Dir.steamFolders, currentVersion, lastUpdated, this, false);

            //setup listview1
            listView1.View = View.Details;
            listView1.Columns.Add("Filename", 150);
            listView1.Columns.Add("Type", 60);
            listView1.Columns.Add("Last Modified", 100);
            RefreshListView1();

            //setup listview2
            listView2.View = View.Details;
            listView2.Columns.Add("Filename", 100);
            listView2.Columns.Add("Type", 60);
            listView2.Columns.Add("Date", 100);
            listView2.Columns.Add("Active", 30);
            listView2.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
            RefreshListView2();

            //setup backup listview
            backupListView.View = View.Details;
            backupListView.Columns.Add("Filename", 100);
            backupListView.Columns.Add("Type", 60);
            backupListView.Columns.Add("Last Modified", 130);
            RefreshBackupListview();

            //override contextstrip for listview
            listView1.ContextMenuStrip = null;
            //apply to mousedown event
            if (listView1_MouseDown != null)
            {
                listView1.MouseDown += listView1_MouseDown; //fix later
            }

        }
        //mouse down event on panel for click drag form
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                initialMousePosition = e.Location;
            }
        }
        //mouse movement position
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point currentMousePosition = e.Location;
                int deltaX = currentMousePosition.X - initialMousePosition.X;
                int deltaY = currentMousePosition.Y - initialMousePosition.Y;
                Location = new Point(Location.X + deltaX, Location.Y + deltaY);
            }
        }
        //mouse release for click drag form
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            // Reset the initial mouse position when dragging is released
            // Optional, but good practice
            initialMousePosition = Point.Empty;
        }
        //close click
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Closes the current form
        }
        //close mouse over color change
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.FromArgb(100, 220, 220, 220); // Change to your desired highlight color
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.Transparent; // Change to your desired highlight color
        }
        //minimize click
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Before Minimizing
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Minimized;
        }
        //minimize fix
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
        }
        //minimize mouse over color change
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            miniButton.BackColor = Color.FromArgb(100, 250, 250, 250); // Change to your desired highlight color
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            miniButton.BackColor = Color.Transparent; // Change to your desired highlight color
        }
        //open save dir
        private void openSaveDir_Click(object sender, EventArgs e)
        {
            string baseDir = Environment.ExpandEnvironmentVariables("%APPDATA%") + @"\Nightreign";

            if (Directory.Exists(Dir.savefilePath))
            {
                Link.OpenDir(Dir.savefilePath);
            }
            else
            {
                MessageBox.Show("Folder does not exist.");
            }
        }
        //open archive dir
        private void openArchiveDir_Click(Object sender, EventArgs e)
        {
            if (Directory.Exists(Dir.archivePath))
            {
                Link.OpenDir(Dir.archivePath);
            }
            else
            {
                MessageBox.Show("Folder does not exist.");
            }
        }
        //open backup dir
        private void openBackupDir_Click(Object sender, EventArgs e)
        {
            if (Directory.Exists(Dir.backupPath))
            {
                Link.OpenDir(Dir.backupPath);
            }
            else
            {
                MessageBox.Show("Folder does not exist.");
            }
        }
        //vanilla import
        private void vanillaSaveFileToolStripMenuItem_Click(object obj, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file(s)";
                openFileDialog.Multiselect = true;
                openFileDialog.InitialDirectory = Dir.savefilePath;
                openFileDialog.Filter = "Save Files (*.sl2)|*.sl2";
                //if ok selected
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string newFileName = Prompt.ShowDialog("Name the save file:", "Rename File"); //fix this
                    //if null
                    if (newFileName != null)
                    {
                        string selectedFile = openFileDialog.SafeFileName;
                        File.Copy(openFileDialog.FileName, Dir.archivePath + @"\" + newFileName + ".sl2");
                        RefreshListView1();
                        // Now `selectedFile` contains the full file path
                        MessageBox.Show(selectedFile + " has been imported as: " + newFileName);
                    }

                }
            }
        }
        //seemeless import
        private void seemlessSaveFileToolStripMenuItem_Click(object obj, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string baseDir = Environment.ExpandEnvironmentVariables("%APPDATA%") + @"\Nightreign";
                var matchingFolders = Directory.GetDirectories(baseDir)
                .Where(dir => Path.GetFileName(dir).All(char.IsDigit) && Path.GetFileName(dir).Length == 17)
                .ToList();
                string path = matchingFolders[0];
                openFileDialog.Title = "Select a file(s)";
                openFileDialog.Multiselect = true;
                openFileDialog.InitialDirectory = path;
                openFileDialog.Filter = "Save Files (*.co2)|*.co2";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string newFileName = Prompt.ShowDialog("Name the save file:", "Rename File"); //fix this
                    //if null
                    if (newFileName != null)
                    {
                        string selectedFile = openFileDialog.SafeFileName;
                        File.Copy(openFileDialog.FileName, Dir.archivePath + @"\" + newFileName + ".co2");
                        RefreshListView1();
                        // Now `selectedFile` contains the full file path
                        MessageBox.Show(selectedFile + " has been imported as: " + newFileName);
                    }
                }
            }
        }
        //refresh listview1
        private void refreshList1_Click(object obj, EventArgs e)
        {
            RefreshListView1();
        }
        //refresh listview2
        private void button6_Click(object obj, EventArgs e)
        {
            RefreshListView2();
        }
        //listview disable selections
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item != null)
            {
                e.Item.Selected = false; // Immediately deselect
            }
        }
        //make active click
        private void makeActiveButton_Click(object obj, EventArgs e)
        {
            if (listView1.Items.Count <= 0)
            {
                MessageBox.Show("There are no files in the archive to make active...");
                return;
            }
            var selectedFile = listView1.SelectedItems[0].Text;
            if (backupListView.Visible == true)
            {
                CloseBackupWindow();
                return;
            }
            if (listView1.SelectedItems.Count > 0)
            {
                string typeOfSave;
                string outPutFileType;
                if (selectedFile.Contains(".sl2"))
                {
                    typeOfSave = "Vanilla";
                    outPutFileType = ".sl2";
                }
                else if (selectedFile.Contains(".co2"))
                {
                    typeOfSave = "Seemeless";
                    outPutFileType = ".co2";
                }
                else
                {
                    return;
                }
                var userInput = MessageBox.Show
                    (
                    "The currently selected item " + selectedFile + " will become your active " + typeOfSave + " save file. Proceed?",
                    "Make Active",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );
                if (userInput == DialogResult.Yes)
                {
                    File.Copy(Path.Combine(Dir.archivePath, selectedFile), Path.Combine(Dir.savefilePath, "NR0000" + outPutFileType), true);
                    RefreshListView1();
                    RefreshListView2();
                    MessageBox.Show(
                        selectedFile + " has been set as your 'active' " + typeOfSave + " save file",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                }
            }
        }
        //backup all active click
        private void backupAllButton_Click(object obj, EventArgs e)
        {
            if (backupListView.Visible == true)
            {
                CloseBackupWindow();
                return;
            }
            //confirm
            var confirmation = MessageBox.Show(
                "Backup all active save files? (this will overwrite existing 'active' save files in the backup)",
                "Backup All",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (confirmation == DialogResult.Yes)
            {
                foreach (System.Windows.Forms.ListViewItem item in listView2.Items)
                {
                    if (item.Text.Contains(".bak"))
                    {
                        continue;
                    }
                    var filePath = Path.Combine(Dir.savefilePath, item.Text);
                    var backupFilePath = Path.Combine(Dir.backupPath, item.Text + ".bak");
                    File.Copy(filePath, backupFilePath, true);
                    // Now `selectedFile` contains the full file path
                }
                MessageBox.Show(
                    "All active save files have successfully backed up!",
                    "Success",
                    MessageBoxButtons.OK
                    );
            }
        }
        //readme button
        private void readmeButton_Click(object sender, EventArgs e)
        {
            var readmePath = Path.Combine(Dir.rootPath, "README.md");
            if (File.Exists(readmePath))
            {
                Link.OpenNote(readmePath);
            }
            else
            {
                MessageBox.Show("Folder: " + readmePath + " does not exist.");
            }
        }
        //about button
        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                " > NR_SaveManager \n > " + currentVersion + "\n > G1ZMO_DRAG0N\n > " + lastUpdated,
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }
        //rename click
        private void renameContextButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count <= 0)
            {
                return;
            }
            string selectedFilename = listView1.SelectedItems[0].Text;
            string selectedFile = Path.Combine(Dir.archivePath, selectedFilename);
            string selectednoExt = Path.GetFileNameWithoutExtension(selectedFilename);
            string selectedExt = Path.GetExtension(selectedFilename);
            string newFileName = Prompt.ShowDialog("Rename save file: '" + selectednoExt + "'", "Rename File"); //fix this
            if (newFileName != null)
            {
                File.Copy(Path.Combine(Dir.archivePath, selectedFilename), Path.Combine(Dir.archivePath, newFileName + selectedExt), true);
                if (File.Exists(selectedFile))
                {
                    File.Delete(selectedFile);
                }
                RefreshListView1();
            }
        }
        //backup context click
        private void bakcupContextButton_Click(object sender, EventArgs e)
        {
            string selectedFilename = listView1.SelectedItems[0].Text;
            string backupSourceFile = Path.Combine(Dir.archivePath, selectedFilename);
            string backupOutputFile = Path.Combine(Dir.backupPath, selectedFilename + ".bak");
            if (File.Exists(backupOutputFile))
            {
                var userInput = MessageBox.Show("Overwrite existing backup file?", "File Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (userInput == DialogResult.Yes)
                {
                    return;
                }
            }
            else
            {
                File.Copy(backupSourceFile, backupOutputFile, true);
                MessageBox.Show("Backup successful.");
            }
        }
        //disallow context menu on click for non-focused items
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = listView1.HitTest(e.Location);
                if (hitTest.Item != null)
                {
                    listView1.FocusedItem = hitTest.Item;
                    contextMenu.Show(listView1, e.Location);
                }
            }
        }
        //view backups click
        private void viewBackups_Click(object sender, EventArgs e)
        {
            if (backupListView.Visible == true)
            {
                CloseBackupWindow();
            }
            else
            {
                DisableAll();
                backupListView.Enabled = true;
                backupListView.Visible = true;
                setupText.Visible = false;
                viewBackups.Text = "Close Window";
                RefreshBackupListview();
            }
        }
        //view backups close
        private void viewBackupsClose_Click(object sender, EventArgs e)
        {
            CloseBackupWindow();
        }
        //restore saves click
        private void restoreSaves_Click(Object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (backupListView.Visible == true)
                {
                    CloseBackupWindow();
                    return;
                }
                openFileDialog.Title = "Select a file(s)";
                openFileDialog.Multiselect = true;
                openFileDialog.InitialDirectory = Dir.backupPath;
                openFileDialog.Filter = "Backup Save Files (*.bak)|*.bak";
                //if ok selected
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = Path.GetFileNameWithoutExtension(openFileDialog.SafeFileName);
                    string typeOfSave;
                    string outputFile;
                    if (Path.GetExtension(selectedFile) == ".sl2")
                    {
                        typeOfSave = "Vanilla";
                        outputFile = "NR0000.sl2";
                    }
                    else if (Path.GetExtension(selectedFile) == ".co2")
                    {
                        typeOfSave = "Seemless";
                        outputFile = "NR0000.co2";
                    }
                    else
                    {
                        MessageBox.Show("Incorrect file type selected.");
                        return;
                    }
                    var userInput = MessageBox.Show(
                        "Restore " + selectedFile + " and make this your 'active' " + typeOfSave + " save file?",
                        "Restore Save File",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                        );
                    if (userInput == DialogResult.Yes)
                    {
                        File.Copy(openFileDialog.FileName, Dir.savefilePath + @"\" + outputFile, true);
                        RefreshListView2();
                        MessageBox.Show(
                            selectedFile + " has been restored and set as your 'active'" + typeOfSave + " save file",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
                    }
                }
            }
        }
        //convert save click
        private void convertSave_Click(object sender, EventArgs e)
        {
            if (backupListView.Visible == true)
            {
                CloseBackupWindow();
                return;
            }
            if (listView1.Items.Count <= 0)
            {
                MessageBox.Show("There are no files in the archive to covnert...");
                return;
            }
            string selectedFile = listView1.SelectedItems[0].Text;
            var inputFilePath = Path.Combine(Dir.archivePath, selectedFile);
            string fileExt;
            string fileType;

            if (Path.GetExtension(selectedFile) == ".sl2")
            {
                fileExt = ".co2";
                fileType = "Seemless";
            }
            else if (Path.GetExtension(selectedFile) == ".co2")
            {
                fileExt = ".sl2";
                fileType = "Vanilla";
            }
            else
            {
                MessageBox.Show("Incorrect filetype selected.");
                return;
            }

            if (File.Exists(Path.ChangeExtension(inputFilePath, fileExt)))
            {
                MessageBox.Show(
                    "A file with that name already exists. Please rename or remove the file before converting.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            File.Copy(inputFilePath, Path.ChangeExtension(inputFilePath, fileExt));
            File.Delete(inputFilePath);
            MessageBox.Show("Save file has been converted to a " + fileType + " save.");
            RefreshListView1();
        }
        //refresh listview1 click
        private void refreshToolTip_Click(object sender, EventArgs e)
        {
            RefreshListView1();
        }
        //title link click
        private void titleLink_Click(object sender, EventArgs e)
        {
            CloseBackupWindow();
            Link.OpenURL("https://github.com/G1ZMODRAG0N/NightreignSaveManager/releases");

        }
        //ko-fi click
        private void kofi_Click(object sender, EventArgs e)
        {
            Link.OpenURL("https://ko-fi.com/g1zmo_drag0n");
        }
        //remove click
        private void remove_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count <= 0)
            {
                return;
            }
            var selectedFile = listView1.SelectedItems[0].Text;
            var filePath = Path.Combine(Dir.archivePath, selectedFile);
            var userInput = MessageBox.Show(
                "Delete selected save file: " + selectedFile + "?",
                "Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (userInput == DialogResult.Yes)
            {
                File.Delete(filePath);
                RefreshListView1();
            }
        }
        //check updates click
        private void checkUpdates_Click(object sender, EventArgs e)
        {
            Link.OpenURL("https://github.com/G1ZMODRAG0N/NightreignSaveManager/releases");
        }
        //seemless coop click
        private void launchseemless_Click(object sender, EventArgs e)
        {
            //search for nightreign installation
            for (char c = 'A'; c <= 'Z'; c++)
            {
                var rootPath = c.ToString() + ":";
                var path = Path.Join(rootPath, @"\Program Files (x86)\Steam\steamapps\common\ELDEN RING NIGHTREIGN\Game");
                var file = Path.Combine(path, "nrsc_launcher.exe");
                if (Path.Exists(path))
                {
                    if (!File.Exists(file))
                    {
                        MessageBox.Show("Unable to locate Seemless Co-op Mod for Nightreign");
                        return;
                    }
                    Link.OpenSeemless(path);
                }
            }

        }
        //launch nightreign
        private void launchVanilla_Click(object sender, EventArgs e)
        {
            //search for nightreign installation
            for (char c = 'A'; c <= 'Z'; c++)
            {
                var rootPath = c.ToString() + ":";
                var path = Path.Join(rootPath, @"\Program Files (x86)\Steam\steamapps\common\ELDEN RING NIGHTREIGN\Game");
                var file = Path.Combine(path, "start_protected_game.exe");
                if (Path.Exists(path))
                {
                    if (!File.Exists(file))
                    {
                        MessageBox.Show("Unable to locate Nightreign executable.");
                        return;
                    }
                    Link.OpenVanilla(path);
                }
            }

        }
        //change default steamID click
        private void changeSteamID_Click(object sender, EventArgs e)
        {
            if (Dir.steamFolders.Count == 1)
            {
                MessageBox.Show("Sorry, there appears to be only 1 SteamID to use.");
                return;
            }
            Config.Write(Dir.rootPath, Dir.steamFolders, currentVersion, lastUpdated, this, true);
            RefreshListView2();
        }
        //faq click
        private void faxItem_Click(object sender, EventArgs e)
        {
            Link.OpenURL("https://github.com/G1ZMODRAG0N/NightreignSaveManager?tab=readme-ov-file#faq");
        }
        //decrypt test button click
        private void DecryptButton_Click(object sender, EventArgs e)
        {
            DataProcessor.Decrypt(Path.Combine(Dir.archivePath, listView1.SelectedItems[0].Text));
        }
    }
}
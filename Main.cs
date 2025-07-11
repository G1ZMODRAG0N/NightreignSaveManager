// Credit for the decryption and encryption of save files aswell as the idea to use loginusers.vdf for steam usernames goes to EonaCat's Save Transfer tool: https://github.com/EonaCat/NightReign
//And my understanding of SL2 file structure goes to: https://github.com/alfizari/Elden-Ring-Nightreign-Save-Editor-PS4

using NightreignSaveManager.Helpers;
using NightreignSaveManager.Custom.ColorTable;
using System.Diagnostics;

namespace NightreignSaveManager
{
    public partial class Main : Form
    {
        private static readonly string currentVersion = "1.2.0";

        private static readonly string lastUpdated = "06.29.25";

        private Point initialMousePosition;

        public Main()
        {
            InitializeComponent();
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MyColorTable());
            Debug.WriteLine($"Initializing...\nCurrent version: {currentVersion}");
        }
        //refresh listview1
        private async void RefreshListView1()
        {
            listView1.Items.Clear();
            listView1.Cursor = Cursors.WaitCursor;
            await Task.Delay(500);
            try 
            {
                string[] archiveFiles = Directory.GetFiles(Dir.archivePath); 
                foreach (var file in archiveFiles)
                {
                    string filename = Path.GetFileName(file);
                    string type = Path.GetExtension(file).TrimStart('.');  // Replace this with actual logic if needed
                    string steamID = Data.GetSteamID(file);
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
                    item.SubItems.Add(steamID);

                    listView1.Items.Add(item);

                    listView1.Items[0].Selected = true;
                    listView1.Select(); // Gives focus to the ListView, so selection is visible
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally 
            {
                listView1.Cursor = Cursors.Default;
            }
            
           
            if (listView1.Items.Count <= 0)
            {
                setupText.Visible = true;
                renameToolStrip.Enabled = false;
                removeToolStrip.Enabled = false;
                duplicateToolStrip.Enabled = false;
                convertToolStrip.Enabled = false;
                modifyToolStripMenuItem.Enabled = false;
                backupFileToolStrip.Enabled = false;
            }
            else
            {
                setupText.Visible = false;
                renameToolStrip.Enabled = true;
                removeToolStrip.Enabled = true;
                duplicateToolStrip.Enabled = true;
                convertToolStrip.Enabled = true;
                modifyToolStripMenuItem.Enabled = true;
                backupFileToolStrip.Enabled = true;
            }
        }
        //refresh listview2
        private async void RefreshListView2()
        {
            Debug.WriteLine($"Refreshing ListView2: { Dir.savefilePath}");
            listView2.Items.Clear();
            listView2.Cursor = Cursors.WaitCursor;
            refreshBttn2.Cursor = Cursors.WaitCursor;
            viewBackups.Cursor = Cursors.WaitCursor;
            await Task.Delay(500);
            listView2.Cursor = Cursors.Default;
            refreshBttn2.Cursor = Cursors.Default;
            viewBackups.Cursor = Cursors.Default;
            if (!Path.Exists(Dir.savefilePath))
            {
                saveSetup.Visible = true;
                return;
            }
            else
            {
                saveSetup.Visible = false;
            }
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
            //viewBackups.Text = "View Backups";
            EnableAll();
        }
        //disable all
        private void DisableAll()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name != "viewBackups")
                {
                    ctrl.Enabled = false;
                }
            }
        }
        //enable all
        private void EnableAll()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name != "viewBackups")
                {
                    ctrl.Enabled = true;
                }
            }
        }
        //Load
        private void MainForm_Load(object sender, EventArgs e)
        {
            versionLabel.Text = $"v{currentVersion.ToString()}";

            Config.Write(Dir.rootPath, Dir.steamFolders, currentVersion, lastUpdated, this, false);

            saveSetup.Text = $"NO SAVE FILES\r\nNo directory or save file(s) were found for the default SteamID: {Config.steamID}. Please select a SteamID that has launched and created a Nightreign save.\r\n";

            listView1.View = View.Details;
            listView1.Columns.Add("Filename", 80);
            listView1.Columns.Add("Type", 60);
            listView1.Columns.Add("Last Modified", 100);
            listView1.Columns.Add("SteamID", 130);
            listView1.ContextMenuStrip = null;//override contextstrip for listview
            RefreshListView1();
            if (ListView1_MouseDown != null)
            {
                listView1.MouseDown += ListView1_MouseDown; //fix later
            }

            listView2.View = View.Details;
            listView2.Columns.Add("Filename", 100);
            listView2.Columns.Add("Type", 60);
            listView2.Columns.Add("Date", 100);
            listView2.Columns.Add("Active", 30);
            listView2.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
            RefreshListView2();

            backupListView.View = View.Details;
            backupListView.Columns.Add("Filename", 100);
            backupListView.Columns.Add("Type", 60);
            backupListView.Columns.Add("Last Modified", 130);
            RefreshBackupListview();

        }
        //mouse down event on panel for click drag form
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                initialMousePosition = e.Location;
            }
        }
        //mouse movement position
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
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
        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            initialMousePosition = Point.Empty;
        }
        //close click
        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //close mouse over color change
        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.BackColor = Color.FromArgb(100, 220, 220, 220);
        }
        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.BackColor = Color.Transparent;
        }
        //minimize click
        private void MiniButton_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Minimized;
        }
        //minimize fix
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
        }
        //minimize mouse over color change
        private void MiniButton_MouseEnter(object sender, EventArgs e)
        {
            MiniButton.BackColor = Color.FromArgb(100, 250, 250, 250);
        }
        private void MiniButton_MouseLeave(object sender, EventArgs e)
        {
            MiniButton.BackColor = Color.Transparent;
        }
        //open save dir
        private void OpenSaveDir_Click(object sender, EventArgs e)
        {
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
        private void OpenArchiveDir_Click(Object sender, EventArgs e)
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
        private void OpenBackupDir_Click(Object sender, EventArgs e)
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
        private void VanillaImport_Click(object obj, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file(s)";
                openFileDialog.Multiselect = true;
                openFileDialog.InitialDirectory = Dir.savefilePath;
                openFileDialog.Filter = "Save Files (*.sl2)|*.sl2";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string newFileName = Prompt.ShowDialog("Name the save file:", "Rename File"); //fix this
                    if (newFileName != null)
                    {
                        string selectedFile = openFileDialog.SafeFileName;
                        File.Copy(openFileDialog.FileName, @$"{Dir.archivePath}\{newFileName}.sl2");
                        RefreshListView1();
                        MessageBox.Show($"{selectedFile} has been imported as: {newFileName}");
                    }

                }
            }
        }
        //seemeless import
        private void SeemlessImport_Click(object obj, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string baseDir = @$"{Environment.ExpandEnvironmentVariables("%APPDATA%")}\Nightreign";
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
                    string newFileName = Prompt.ShowDialog("Name the save file:", "Rename File");
                    if (newFileName != null)
                    {
                        string selectedFile = openFileDialog.SafeFileName;
                        File.Copy(openFileDialog.FileName, @$"{Dir.archivePath}\{newFileName}.co2");
                        RefreshListView1();
                        MessageBox.Show($"{selectedFile} has been imported as: {newFileName}");
                    }
                }
            }
        }
        //refresh listview1
        private void RefreshList1_Click(object obj, EventArgs e)
        {
            RefreshListView1();
        }
        //refresh listview2
        private void RefreshList2_Click(object obj, EventArgs e)
        {
            RefreshListView2();
        }
        //listview1 disable when no items selected
        private void ListView1SelectionChange(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bool isEnabled = listView1.SelectedItems.Count > 0;
            var menuItems = new ToolStripItem[]
            {
                renameToolStrip,
                removeToolStrip,
                duplicateToolStrip,
                convertToolStrip,
                modifyToolStripMenuItem,
                backupFileToolStrip
            };

            foreach (var item in menuItems)
            {
                item.Enabled = isEnabled;
            }
        }
        //listview2 disable selections
        private void ListView2SelectionChange(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item != null)
            {
                e.Item.Selected = false; // Immediately deselect
            }
        }
        //make active click
        private void MakeActive_Click(object obj, EventArgs e)
        {
            if (!Path.Exists(Dir.savefilePath))
            {
                MessageBox.Show($"The Nightreign save folder does not exist for the default \nSteam ID: {Config.steamID}\nPlease create a folder or select a different Steam ID in File > Select Default SteamID");
                return;
            }
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a save file to perform this action.");
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
                    $"The currently selected item {selectedFile} will become your active {typeOfSave} save file. Proceed?",
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
                        $"{selectedFile} has been set as your 'active' {typeOfSave} save file",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                }
            }
        }
        //backup all active click
        private void BackupAll_Click(object obj, EventArgs e)
        {
            if (backupListView.Visible == true)
            {
                CloseBackupWindow();
                return;
            }
            if (!Path.Exists(Dir.savefilePath))
            {
                MessageBox.Show($"The Nightreign save folder does not exist for the default \nSteam ID: {Config.steamID}\nPlease create a folder or select a different Steam ID in File > Select Default SteamID");
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
                foreach (ListViewItem item in listView2.Items)
                {
                    if (item.Text.Contains(".bak"))
                    {
                        continue;
                    }
                    var filePath = Path.Combine(Dir.savefilePath, item.Text);
                    var backupFilePath = Path.Combine(Dir.backupPath, $"{item.Text}.bak");
                    File.Copy(filePath, backupFilePath, true);
                }
                MessageBox.Show(
                    "All active save files have successfully backed up!",
                    "Success",
                    MessageBoxButtons.OK
                    );
            }
        }
        //readme button
        private void Readme_Click(object sender, EventArgs e)
        {
            var readmePath = Path.Combine(Dir.rootPath, "README.md");
            if (File.Exists(readmePath))
            {
                Link.OpenNote(readmePath);
            }
            else
            {
                MessageBox.Show("Cannot locate the README.ms file.");
            }
        }
        //about button
        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                $" > NR_SaveManager \n > {currentVersion} will become your active {lastUpdated}",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }
        //rename click
        private void Rename_Click(object sender, EventArgs e)
        {
            string selectedFilename = listView1.SelectedItems[0].Text;
            string selectedFile = Path.Combine(Dir.archivePath, selectedFilename);
            string selectednoExt = Path.GetFileNameWithoutExtension(selectedFilename);
            string selectedExt = Path.GetExtension(selectedFilename);
            string newFileName = Prompt.ShowDialog($"Rename save file: {selectednoExt}", "Rename File"); //fix this
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
        private void Backup_Click(object sender, EventArgs e)
        {
            string selectedFilename = listView1.SelectedItems[0].Text;
            string backupSourceFile = Path.Combine(Dir.archivePath, selectedFilename);
            string backupOutputFile = Path.Combine(Dir.backupPath, $"{ selectedFilename}.bak");
            if (File.Exists(backupOutputFile))
            {
                var userInput = MessageBox.Show("Overwrite existing backup file?", "File Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (userInput == DialogResult.No)
                {
                    return;
                }
            }
            File.Copy(backupSourceFile, backupOutputFile, true);
            MessageBox.Show($"Backup of file {selectedFilename} successful!");
        }
        //disallow context menu on click for non-focused items
        private void ListView1_MouseDown(object sender, MouseEventArgs e)
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
        private void ViewBackups_Click(object sender, EventArgs e)
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
                //viewBackups.Text = "Close Window";
                RefreshBackupListview();
            }
        }
        //view backups close
        private void ViewBackupsClose_Click(object sender, EventArgs e)
        {
            CloseBackupWindow();
        }
        //restore saves click
        private void RestoreSaves_Click(Object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (backupListView.Visible == true)
                {
                    CloseBackupWindow();
                    return;
                }
                if (!Path.Exists(Dir.savefilePath))
                {
                    MessageBox.Show($"The Nightreign save folder does not exist for the default \nSteam ID: {Config.steamID}\nPlease create a folder or select a different Steam ID in File > Select Default SteamID");
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
                        $"Restore {selectedFile} and make this your 'active' {typeOfSave} save file?",
                        "Restore Save File",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                        );
                    if (userInput == DialogResult.Yes)
                    {
                        File.Copy(openFileDialog.FileName, @$"{Dir.savefilePath}\{outputFile}", true);
                        RefreshListView2();
                        MessageBox.Show(
                            $"{selectedFile} has been restored and set as your 'active' {typeOfSave} save file",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
                    }
                }
            }
        }
        //convert save click
        private void ConvertSave_Click(object sender, EventArgs e)
        {
            if (!Path.Exists(Dir.savefilePath))
            {
                MessageBox.Show($"The Nightreign save folder does not exist for the default \nSteam ID: {Config.steamID}\nPlease create a folder or select a different Steam ID in File > Select Default SteamID");
                return;
            }
            if(listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a save file to perform this action.");
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
            MessageBox.Show($"Save file has been converted to a {fileType} successful!");
            RefreshListView1();
        }
        //refresh listview1 click
        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshListView1();
        }
        //title link click
        private void TitleLink_Click(object sender, EventArgs e)
        {
            CloseBackupWindow();
            Link.OpenURL("https://github.com/G1ZMODRAG0N/NightreignSaveManager/releases");

        }
        //ko-fi click
        private void Kofi_Click(object sender, EventArgs e)
        {
            Link.OpenURL("https://ko-fi.com/g1zmo_drag0n");
        }
        //remove click
        private void Remove_Click(object sender, EventArgs e)
        {
            DialogResult warning = new DialogResult();
            warning = MessageBox.Show(
                "Are you sure you want to delete the selected file?",
                "Delete File",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
                );
            if (warning != DialogResult.Yes)
            {
                return;
            }
            var selectedFile = listView1.SelectedItems[0].Text;
            var filePath = Path.Combine(Dir.archivePath, selectedFile);
            File.Delete(filePath);
            RefreshListView1();
        }
        //check updates click
        private void CheckUpdates_Click(object sender, EventArgs e)
        {
            Link.OpenURL("https://github.com/G1ZMODRAG0N/NightreignSaveManager/releases");
        }
        //seemless coop click
        private void Launchseemless_Click(object sender, EventArgs e)
        {
            //search for nightreign installation
            for (char c = 'A'; c <= 'Z'; c++)
            {
                var rootPath = @$"{c.ToString()}:";
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
        private void LaunchVanilla_Click(object sender, EventArgs e)
        {
            //search for nightreign installation
            for (char c = 'A'; c <= 'Z'; c++)
            {
                var rootPath = @$"{c.ToString()}:";
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
        //default steamID click
        private void DefaultSteamID_Click(object sender, EventArgs e)
        {
            Config.Write(Dir.rootPath, Dir.steamFolders, currentVersion, lastUpdated, this, true);
            RefreshListView1();
            RefreshListView2();
        }
        //faq click
        private void FAQItem_Click(object sender, EventArgs e)
        {
            Link.OpenURL("https://github.com/G1ZMODRAG0N/NightreignSaveManager?tab=readme-ov-file#faq");
        }
        //duplicate click
        private void Duplicate_Click(object sender, EventArgs e)
        {
            string sourceItem = listView1.SelectedItems[0].Text;
            string sourceExt = Path.GetExtension(sourceItem);
            string destinationItem = $"{Path.GetFileNameWithoutExtension(sourceItem)} - Copy{sourceExt}";
            string sourcePath = Path.Combine(Dir.archivePath, sourceItem);
            string destinationPath = Path.Combine(Dir.archivePath, destinationItem);
            File.Copy(sourcePath, destinationPath);
            MessageBox.Show("File successfully copied.");
            RefreshListView1();
        }
        //edit steamID
        //Credit to https://github.com/EonaCat/NightReign for this block. Im terrible with class structures between helpers
        private void EditSteamID_Click(object sender, EventArgs e)
        {
            DialogResult warning = new DialogResult();
            warning = MessageBox.Show(
                "Editing the SteamID within a save file has a chance of corrupting your file. Please make sure to backup the save before proceeding with this process. Continue?",
                "Continue",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
                );
            if( warning != DialogResult.Yes) 
            {
                return;
            }
            //get file
            var selectedFile = listView1.SelectedItems[0];
            string inputFile = Path.Combine(Dir.archivePath, selectedFile.Text);
            string outputFile = Path.Combine(Dir.archivePath, $"NewID_{listView1.SelectedItems[0].Text}");
            string fileExt = Path.GetExtension(outputFile);

            if (!File.Exists(inputFile) || string.IsNullOrEmpty(inputFile)) 
            {
                MessageBox.Show("Unable locate save file or file is corrupted.");
                return; 
            }

            //decrypt index 10, get steam id in bytes
            string? oldSteamId = Data.GetSteamID(inputFile);

            if (string.IsNullOrEmpty(oldSteamId))
            {
                MessageBox.Show("Unable locate steamID from the save file or file is corrupted.");
                return;
            }
            //old
            byte[] oldSteamIDbytes = Data.ConvertToSteamIdBytes(oldSteamId);
            Debug.WriteLine($"Old steamID {oldSteamId}");
            Debug.WriteLine($"Old steamID {BitConverter.ToString(oldSteamIDbytes)}");

            //new
            string newSteamID = SteamSelect.ShowDialog("text","caption");
            if (string.IsNullOrEmpty(newSteamID))
            {
                return;
            }
            else if (newSteamID == selectedFile.SubItems[3].Text)
            {
                MessageBox.Show("The selected steamID is already applied to this save file.");
                return;

            }
                byte[] newSteamIdBytes = Data.ConvertToSteamIdBytes(newSteamID);

            Debug.WriteLine($"New steamID {newSteamID}");
            Debug.WriteLine($"New steamIDbytes {BitConverter.ToString(newSteamIdBytes)}");

            string folderPath;
            try
            {
                folderPath = FileEngine.Decrypt(inputFile,Console.WriteLine);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to decrypt SL2 file", ex.Message);
                return;
            }

            var ERDataFiles = Directory.GetFiles(folderPath, "ELDENRING_DATA*").OrderBy(f => f).ToArray();
            string ERData10Path = Path.Combine(folderPath, "ELDENRING_DATA_10");

            if (!File.Exists(ERData10Path))
            {
                Debug.WriteLine("Missing File", $"ELDENRING_DATA_10 not found in {folderPath}");
                return;
            }

            if (newSteamIdBytes == null)
            {
                MessageBox.Show("Invalid Steam ID format. Please enter a valid 17-digit Steam ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (oldSteamIDbytes.SequenceEqual(newSteamIdBytes))
            {
                MessageBox.Show("The new Steam ID is the same as the old one.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           Debug.WriteLine($"New Steam ID (bytes): {BitConverter.ToString(newSteamIdBytes)}");
            int filesModified = 0;

            foreach (var file in ERDataFiles)
            {
                byte[] data = File.ReadAllBytes(file);
                if (!data.ContainsSubsequence(oldSteamIDbytes))
                {
                    continue;
                }

                var newData = BytesHelper.ReplaceBytes(data, oldSteamIDbytes, newSteamIdBytes);
                if (!data.SequenceEqual(newData))
                {
                    File.WriteAllBytes(file, newData);
                    filesModified++;
                }
            }

            if (filesModified == 0)
            {
                MessageBox.Show("No files were modified. The old Steam ID might not be present in any slots.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           Debug.WriteLine($"Steam ID replaced in {filesModified} file(s)");

            if (string.IsNullOrEmpty(outputFile))
            {
                return;
            }

            if (File.Exists(outputFile))
            {
                outputFile = Path.Combine(Dir.archivePath,Prompt.ShowDialog("File name already exists. Please rename.","Name the save file") + fileExt);
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                FileEngine.Encrypt(outputFile);
                MessageBox.Show($"ID edit successful {new DirectoryInfo(outputFile).Name}");
                FileEngine.RemoveEncryptedFolder();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to re-encrypt and save", ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        RefreshListView1();
        }
    }
}
using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;
using System.Windows.Forms;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Text;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NightreignSaveManager
{
    //main form class
    public partial class Form1 : Form
    {
        //set mouse pos for click-drag move form
        private Point initialMousePosition;

        //setup paths
        static string rootPath = AppDomain.CurrentDomain.BaseDirectory;
        static string archivePath = Path.Combine(rootPath, "archive");
        static string backupPath = Path.Combine(rootPath, "backup");

        static string baseDir = Environment.ExpandEnvironmentVariables("%APPDATA%") + @"\Nightreign";
        static string savefilePath = Directory.GetDirectories(baseDir)
            .Where(dir => Path.GetFileName(dir).All(char.IsDigit) && Path.GetFileName(dir).Length == 17).ToList()[0];

        //setup check for updates
        private async Task CheckForUpdatesAsync()
        {
            string currentVersion = "1.0.0";
            string repoOwner = "G1ZMODRAG0N";
            string repoName = "NightreignSaveManager";
            string apiUrl = $"https://api.github.com/repos/{repoOwner}/{repoName}/releases/latest";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("UpdateChecker/1.0"); // GitHub requires a User-Agent

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(json))
                    {
                        string latestVersion = doc.RootElement.GetProperty("tag_name").GetString().TrimStart('v');

                        if (Version.TryParse(currentVersion, out var current) &&
                            Version.TryParse(latestVersion, out var latest))
                        {
                            if (latest > current)
                            {
                                MessageBox.Show($"New version available: {latest}\nVisit GitHub to download it.", "Update");
                            }
                            else
                            {
                                MessageBox.Show("You're using the latest version.", "Update");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error checking for updates:\n{ex.Message}", "Error");
                }
            }
        }
        //refresh listview1
        private async void RefreshListView1()
        {
            listView1.Items.Clear();
            listView1.Cursor = Cursors.WaitCursor;
            await Task.Delay(500);
            listView1.Cursor = Cursors.Default;
            string[] archiveFiles = Directory.GetFiles(archivePath);
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
        }
        //refresh listview2
        private async void RefreshListView2()
        {
            listView2.Items.Clear();
            listView2.Cursor = Cursors.WaitCursor;
            button6.Cursor = Cursors.WaitCursor;
            viewBackups.Cursor = Cursors.WaitCursor;
            await Task.Delay(500);
            listView2.Cursor = Cursors.Default;
            button6.Cursor = Cursors.Default;
            viewBackups.Cursor = Cursors.Default;
            string[] files = Directory.GetFiles(savefilePath);
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
            string[] files = Directory.GetFiles(backupPath);
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
            viewBackups.Text = "View Backups";
            EnableAll();
        }
        //open URL
        public void OpenUrl(string url)
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
        //Initialize Form
        public Form1()
        {
            InitializeComponent();
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MyColorTable());
        }

        //Load
        private void Form1_Load(object sender, EventArgs e)
        {
            //create archive directory
            if (!Directory.Exists(archivePath))
            {
                Directory.CreateDirectory(archivePath);
            }
            //create backup directory
            if (!Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }

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

        //custom colortable
        public class MyColorTable : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground
            {
                get
                {
                    return Color.FromArgb(100, 220, 220, 220);
                }
            }
            public override Color ImageMarginGradientBegin
            {
                get
                {
                    return Color.FromArgb(100, 220, 220, 220);
                }
            }
            public override Color ImageMarginGradientMiddle
            {
                get
                {
                    return Color.FromArgb(100, 220, 220, 220);
                }
            }
            public override Color ImageMarginGradientEnd
            {
                get
                {
                    return Color.FromArgb(100, 220, 220, 220);
                }
            }
            public override Color MenuBorder
            {
                get
                {
                    return Color.WhiteSmoke;
                }
            }
            public override Color MenuItemBorder
            {
                get
                {
                    return Color.WhiteSmoke;
                }
            }
            public override Color MenuItemSelected
            {
                get
                {
                    return Color.FromArgb(100, 220, 220, 220);
                }
            }
            public override Color MenuStripGradientBegin
            {
                get
                {
                    return Color.FromArgb(100, 220, 220, 220);
                }
            }
            public override Color MenuStripGradientEnd
            {
                get
                {
                    return Color.FromArgb(100, 220, 220, 220);
                }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get
                {
                    return Color.FromArgb(100, 80, 80, 80);
                }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get
                {
                    return Color.FromArgb(100, 80, 80, 80);
                }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get
                {
                    return Color.FromArgb(100, 220, 220, 220);
                }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get
                {
                    return Color.FromArgb(100, 220, 220, 220);
                }
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
            var matchingFolders = Directory.GetDirectories(baseDir)
            .Where(dir => Path.GetFileName(dir).All(char.IsDigit) && Path.GetFileName(dir).Length == 17)
            .ToList();
            string path = matchingFolders[0];

            if (Directory.Exists(path))
            {
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("Folder does not exist.");
            }
        }
        //open archive dir
        private void openArchiveDir_Click(Object sender, EventArgs e)
        {
            if (Directory.Exists(archivePath))
            {
                System.Diagnostics.Process.Start("explorer.exe", archivePath);
            }
            else
            {
                MessageBox.Show("Folder does not exist.");
            }
        }
        //open backup dir
        private void openBackupDir_Click(Object sender, EventArgs e)
        {
            if (Directory.Exists(backupPath))
            {
                System.Diagnostics.Process.Start("explorer.exe", backupPath);
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
                openFileDialog.InitialDirectory = savefilePath;
                openFileDialog.Filter = "Save Files (*.sl2)|*.sl2";
                //if ok selected
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string newFileName = Prompt.ShowDialog("Name the save file:", "Rename File"); //fix this
                    //if null
                    if (newFileName != null)
                    {
                        string selectedFile = openFileDialog.SafeFileName;
                        File.Copy(openFileDialog.FileName, archivePath + @"\" + newFileName + ".sl2");
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
                        File.Copy(openFileDialog.FileName, archivePath + @"\" + newFileName + ".co2");
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
                    File.Copy(Path.Combine(archivePath, selectedFile), Path.Combine(savefilePath, "NR0000" + outPutFileType), true);
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
        //bakcup all active click
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
                    var filePath = Path.Combine(savefilePath, item.Text);
                    var backupFilePath = Path.Combine(backupPath, item.Text + ".bak");
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
            var readmePath = Path.Combine(rootPath, "README.md");
            if (File.Exists(readmePath))
            {
                System.Diagnostics.Process.Start("notepad.exe", readmePath);
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
                "NR SaveManager \nVersion: '1.0.0'",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }
        //rename context click
        private void renameContextButton_Click(object sender, EventArgs e)
        {
            string selectedFilename = listView1.SelectedItems[0].Text;
            string selectednoExt = Path.GetFileNameWithoutExtension(selectedFilename);
            string selectedExt = Path.GetExtension(selectedFilename);
            string newFileName = Prompt.ShowDialog("Rename save file: '" + selectednoExt + "'", "Rename File"); //fix this
            if (newFileName != null)
            {
                File.Copy(archivePath + @"\" + selectedFilename, archivePath + @"\" + newFileName + selectedExt, true);
                RefreshListView1();
            }
        }
        //backup context click
        private void bakcupContextButton_Click(object sender, EventArgs e)
        {
            string selectedFilename = listView1.SelectedItems[0].Text;
            string backupSourceFile = Path.Combine(archivePath, selectedFilename);
            string backupOutputFile = Path.Combine(backupPath, selectedFilename + ".bak");
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
                openFileDialog.InitialDirectory = backupPath;
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
                        File.Copy(openFileDialog.FileName, savefilePath + @"\" + outputFile, true);
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
            string selectedFile = listView1.SelectedItems[0].Text;
            var inputFilePath = Path.Combine(archivePath, selectedFile);
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
            OpenUrl("https://github.com/G1ZMODRAG0N/NightreignSaveManager/releases");

        }
        //ko-fi click
        private void kofi_Click(object sender, EventArgs e)
        {
            OpenUrl("https://ko-fi.com/g1zmo_drag0n");
        }
        //remove click
        private void remove_Click(object sender, EventArgs e)
        {
            var selectedFile = listView1.SelectedItems[0].Text;
            var filePath = Path.Combine(archivePath, selectedFile);
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
        private async void checkUpdates_Click(object sender, EventArgs e)
        {
            await CheckForUpdatesAsync();
        }
    }
    //rename dialog prompt
    public static class Prompt
    {
        public static string? ShowDialog(string text, string caption)
        {
            System.Windows.Forms.Form prompt = new System.Windows.Forms.Form();
            prompt.Width = 200;
            prompt.Height = 150;
            prompt.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            System.Windows.Forms.Label textLabel = new System.Windows.Forms.Label();
            textLabel.Left = 20;
            textLabel.Top = 20;
            textLabel.Text = text;
            textLabel.AutoSize = true;

            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Left = 20;
            textBox.Top = 40;
            textBox.Width = 140;

            System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button();
            confirmation.Text = "Confirm";
            confirmation.Left = 10;
            confirmation.Width = 80;
            confirmation.Top = 80;
            confirmation.DialogResult = System.Windows.Forms.DialogResult.OK;

            System.Windows.Forms.Button cancel = new System.Windows.Forms.Button();
            cancel.Text = "Cancel";
            cancel.Left = 95;
            cancel.Width = 80;
            cancel.Top = 80;
            cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;

            System.Windows.Forms.DialogResult result = prompt.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                return textBox.Text;
            }
            else
            {
                return null;
            }
        }
    }
}

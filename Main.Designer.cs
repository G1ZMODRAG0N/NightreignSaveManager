namespace NightreignSaveManager
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            toolStripSeparator1 = new ToolStripSeparator();
            fileToolStripMenuItem = new ToolStripMenuItem();
            TitleBar = new Panel();
            CloseButton = new PictureBox();
            MiniButton = new PictureBox();
            IconImage = new PictureBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem1 = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            vanillaSaveFileToolStripMenuItem = new ToolStripMenuItem();
            seemlessSaveFileToolStripMenuItem = new ToolStripMenuItem();
            openDirectoryToolStripMenuItem = new ToolStripMenuItem();
            openSaveDir = new ToolStripMenuItem();
            openBackupDir = new ToolStripMenuItem();
            openArchiveDir = new ToolStripMenuItem();
            changeSteamProfileIDToolStripMenuItem = new ToolStripMenuItem();
            launchNightreignToolStripMenuItem = new ToolStripMenuItem();
            launchSeemlessToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            renameToolStrip = new ToolStripMenuItem();
            duplicateToolStrip = new ToolStripMenuItem();
            removeToolStrip = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            modifyToolStripMenuItem = new ToolStripMenuItem();
            convertToolStrip = new ToolStripMenuItem();
            relicsToolStripMenuItem = new ToolStripMenuItem();
            steamIDToolStrip = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            backupFileToolStrip = new ToolStripMenuItem();
            backupAllActiveToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            readmeButton = new ToolStripMenuItem();
            checkForUpdateToolStripMenuItem = new ToolStripMenuItem();
            fAQToolStripMenuItem = new ToolStripMenuItem();
            aboutButton = new ToolStripMenuItem();
            TitleImage = new PictureBox();
            listView1 = new ListView();
            contextMenu = new ContextMenuStrip(components);
            makeActiveToolStripMenuItem = new ToolStripMenuItem();
            modifyToolStripMenuItem1 = new ToolStripMenuItem();
            convertToolStripMenuItem = new ToolStripMenuItem();
            relicsToolStripMenuItem1 = new ToolStripMenuItem();
            DefaultSteamIDToolStripMenuItem = new ToolStripMenuItem();
            backupToolStripMenuItem = new ToolStripMenuItem();
            duplicateToolStripMenuItem = new ToolStripMenuItem();
            renameToolStripMenuItem = new ToolStripMenuItem();
            removeToolStripMenuItem = new ToolStripMenuItem();
            refreshToolTip = new ToolStripMenuItem();
            label1 = new Label();
            listView2 = new ListView();
            label2 = new Label();
            refreshBttn2 = new Button();
            versionLabel = new Label();
            toolTip1 = new ToolTip(components);
            viewBackups = new Button();
            refreshBttn1 = new Button();
            convertButton = new Button();
            importButton = new Button();
            makeActiveButton = new Button();
            restoreButton = new Button();
            backupAllButton = new Button();
            backupListView = new ListView();
            KofiImage = new PictureBox();
            setupText = new Label();
            saveSetup = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CloseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MiniButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconImage).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TitleImage).BeginInit();
            contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)KofiImage).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.BackColor = Color.FromArgb(50, 50, 50);
            toolStripSeparator1.ForeColor = Color.WhiteSmoke;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 23);
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 19);
            fileToolStripMenuItem.Text = "File";
            // 
            // TitleBar
            // 
            TitleBar.BackColor = Color.FromArgb(50, 50, 50);
            TitleBar.Controls.Add(CloseButton);
            TitleBar.Controls.Add(MiniButton);
            TitleBar.Controls.Add(IconImage);
            TitleBar.Controls.Add(menuStrip1);
            TitleBar.Dock = DockStyle.Top;
            TitleBar.Location = new Point(0, 0);
            TitleBar.Name = "TitleBar";
            TitleBar.Size = new Size(350, 35);
            TitleBar.TabIndex = 15;
            TitleBar.MouseDown += TitleBar_MouseDown;
            TitleBar.MouseMove += TitleBar_MouseMove;
            TitleBar.MouseUp += TitleBar_MouseUp;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.Transparent;
            CloseButton.BackgroundImageLayout = ImageLayout.None;
            CloseButton.Image = (Image)resources.GetObject("CloseButton.Image");
            CloseButton.Location = new Point(316, 0);
            CloseButton.Margin = new Padding(0);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(34, 35);
            CloseButton.SizeMode = PictureBoxSizeMode.CenterImage;
            CloseButton.TabIndex = 16;
            CloseButton.TabStop = false;
            CloseButton.Click += CloseButton_Click_1;
            CloseButton.MouseEnter += CloseButton_MouseEnter;
            CloseButton.MouseLeave += CloseButton_MouseLeave;
            // 
            // MiniButton
            // 
            MiniButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MiniButton.BackColor = Color.Transparent;
            MiniButton.BackgroundImageLayout = ImageLayout.None;
            MiniButton.Image = (Image)resources.GetObject("MiniButton.Image");
            MiniButton.Location = new Point(279, 0);
            MiniButton.Name = "MiniButton";
            MiniButton.Size = new Size(34, 35);
            MiniButton.SizeMode = PictureBoxSizeMode.CenterImage;
            MiniButton.TabIndex = 16;
            MiniButton.TabStop = false;
            MiniButton.Click += MiniButton_Click;
            MiniButton.MouseEnter += MiniButton_MouseEnter;
            MiniButton.MouseLeave += MiniButton_MouseLeave;
            // 
            // IconImage
            // 
            IconImage.BackColor = Color.Transparent;
            IconImage.Image = Properties.Resources.icon;
            IconImage.Location = new Point(11, 10);
            IconImage.Name = "IconImage";
            IconImage.Size = new Size(16, 16);
            IconImage.SizeMode = PictureBoxSizeMode.CenterImage;
            IconImage.TabIndex = 16;
            IconImage.TabStop = false;
            IconImage.MouseDown += TitleBar_MouseDown;
            IconImage.MouseMove += TitleBar_MouseMove;
            IconImage.MouseUp += TitleBar_MouseUp;
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.Top;
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = Color.FromArgb(50, 50, 50);
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem1, toolStripMenuItem1, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(40, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(0);
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(254, 35);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.MouseDown += TitleBar_MouseDown;
            menuStrip1.MouseMove += TitleBar_MouseMove;
            menuStrip1.MouseUp += TitleBar_MouseUp;
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.BackColor = Color.FromArgb(50, 50, 50);
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, openDirectoryToolStripMenuItem, changeSteamProfileIDToolStripMenuItem, launchNightreignToolStripMenuItem, launchSeemlessToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem1.ForeColor = SystemColors.Control;
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Padding = new Padding(0);
            fileToolStripMenuItem1.Size = new Size(29, 35);
            fileToolStripMenuItem1.Text = "File";
            fileToolStripMenuItem1.Click += ViewBackupsClose_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            openToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { vanillaSaveFileToolStripMenuItem, seemlessSaveFileToolStripMenuItem });
            openToolStripMenuItem.ForeColor = SystemColors.Control;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.ShowShortcutKeys = false;
            openToolStripMenuItem.Size = new Size(201, 22);
            openToolStripMenuItem.Text = "Import";
            // 
            // vanillaSaveFileToolStripMenuItem
            // 
            vanillaSaveFileToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            vanillaSaveFileToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            vanillaSaveFileToolStripMenuItem.ForeColor = SystemColors.Control;
            vanillaSaveFileToolStripMenuItem.Name = "vanillaSaveFileToolStripMenuItem";
            vanillaSaveFileToolStripMenuItem.ShowShortcutKeys = false;
            vanillaSaveFileToolStripMenuItem.Size = new Size(183, 22);
            vanillaSaveFileToolStripMenuItem.Text = "Vanilla Save File(s)";
            vanillaSaveFileToolStripMenuItem.Click += VanillaImport_Click;
            // 
            // seemlessSaveFileToolStripMenuItem
            // 
            seemlessSaveFileToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            seemlessSaveFileToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            seemlessSaveFileToolStripMenuItem.ForeColor = SystemColors.Control;
            seemlessSaveFileToolStripMenuItem.Name = "seemlessSaveFileToolStripMenuItem";
            seemlessSaveFileToolStripMenuItem.Size = new Size(183, 22);
            seemlessSaveFileToolStripMenuItem.Text = "Seemless Save File(s)";
            seemlessSaveFileToolStripMenuItem.Click += SeemlessImport_Click;
            // 
            // openDirectoryToolStripMenuItem
            // 
            openDirectoryToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            openDirectoryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openSaveDir, openBackupDir, openArchiveDir });
            openDirectoryToolStripMenuItem.ForeColor = SystemColors.Control;
            openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            openDirectoryToolStripMenuItem.Size = new Size(201, 22);
            openDirectoryToolStripMenuItem.Text = "Open Directory";
            // 
            // openSaveDir
            // 
            openSaveDir.BackColor = Color.FromArgb(50, 50, 50);
            openSaveDir.ForeColor = SystemColors.Control;
            openSaveDir.Name = "openSaveDir";
            openSaveDir.Size = new Size(139, 22);
            openSaveDir.Text = "Game Saves";
            openSaveDir.Click += OpenSaveDir_Click;
            // 
            // openBackupDir
            // 
            openBackupDir.BackColor = Color.FromArgb(50, 50, 50);
            openBackupDir.ForeColor = SystemColors.Control;
            openBackupDir.Name = "openBackupDir";
            openBackupDir.Size = new Size(139, 22);
            openBackupDir.Text = "Backup Files";
            openBackupDir.Click += OpenBackupDir_Click;
            // 
            // openArchiveDir
            // 
            openArchiveDir.BackColor = Color.FromArgb(50, 50, 50);
            openArchiveDir.ForeColor = SystemColors.Control;
            openArchiveDir.Name = "openArchiveDir";
            openArchiveDir.Size = new Size(139, 22);
            openArchiveDir.Text = "Archive";
            openArchiveDir.Click += OpenArchiveDir_Click;
            // 
            // changeSteamProfileIDToolStripMenuItem
            // 
            changeSteamProfileIDToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            changeSteamProfileIDToolStripMenuItem.ForeColor = SystemColors.Control;
            changeSteamProfileIDToolStripMenuItem.Name = "changeSteamProfileIDToolStripMenuItem";
            changeSteamProfileIDToolStripMenuItem.Size = new Size(201, 22);
            changeSteamProfileIDToolStripMenuItem.Text = "Select Default SteamID";
            changeSteamProfileIDToolStripMenuItem.ToolTipText = "Select the default steamid to use. (Lists from available save dir)";
            changeSteamProfileIDToolStripMenuItem.Click += DefaultSteamID_Click;
            // 
            // launchNightreignToolStripMenuItem
            // 
            launchNightreignToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            launchNightreignToolStripMenuItem.ForeColor = SystemColors.Control;
            launchNightreignToolStripMenuItem.Name = "launchNightreignToolStripMenuItem";
            launchNightreignToolStripMenuItem.Size = new Size(201, 22);
            launchNightreignToolStripMenuItem.Text = "Launch Nightreign";
            launchNightreignToolStripMenuItem.ToolTipText = "Start start_protected_game.exe";
            launchNightreignToolStripMenuItem.Click += LaunchVanilla_Click;
            // 
            // launchSeemlessToolStripMenuItem
            // 
            launchSeemlessToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            launchSeemlessToolStripMenuItem.ForeColor = SystemColors.Control;
            launchSeemlessToolStripMenuItem.Name = "launchSeemlessToolStripMenuItem";
            launchSeemlessToolStripMenuItem.Size = new Size(201, 22);
            launchSeemlessToolStripMenuItem.Text = "Launch Seemless Co-op";
            launchSeemlessToolStripMenuItem.ToolTipText = "Start Seemless Coop nrsc_launcher.exe";
            launchSeemlessToolStripMenuItem.Click += Launchseemless_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            exitToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            exitToolStripMenuItem.ForeColor = SystemColors.Control;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(201, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += CloseButton_Click_1;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { renameToolStrip, duplicateToolStrip, removeToolStrip });
            toolStripMenuItem1.ForeColor = Color.WhiteSmoke;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(39, 35);
            toolStripMenuItem1.Text = "Edit";
            // 
            // renameToolStrip
            // 
            renameToolStrip.BackColor = Color.FromArgb(50, 50, 50);
            renameToolStrip.ForeColor = SystemColors.Control;
            renameToolStrip.Name = "renameToolStrip";
            renameToolStrip.Size = new Size(124, 22);
            renameToolStrip.Text = "Rename";
            renameToolStrip.Click += Rename_Click;
            // 
            // duplicateToolStrip
            // 
            duplicateToolStrip.BackColor = Color.FromArgb(50, 50, 50);
            duplicateToolStrip.ForeColor = SystemColors.Control;
            duplicateToolStrip.Name = "duplicateToolStrip";
            duplicateToolStrip.Size = new Size(124, 22);
            duplicateToolStrip.Text = "Duplicate";
            duplicateToolStrip.Click += Duplicate_Click;
            // 
            // removeToolStrip
            // 
            removeToolStrip.BackColor = Color.FromArgb(50, 50, 50);
            removeToolStrip.ForeColor = SystemColors.Control;
            removeToolStrip.Name = "removeToolStrip";
            removeToolStrip.Size = new Size(124, 22);
            removeToolStrip.Text = "Remove";
            removeToolStrip.Click += Remove_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { modifyToolStripMenuItem, optionsToolStripMenuItem, backupFileToolStrip, backupAllActiveToolStripMenuItem });
            toolsToolStripMenuItem.ForeColor = Color.WhiteSmoke;
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(61, 35);
            toolsToolStripMenuItem.Text = "Options";
            toolsToolStripMenuItem.Click += ViewBackupsClose_Click;
            // 
            // modifyToolStripMenuItem
            // 
            modifyToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            modifyToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { convertToolStrip, relicsToolStripMenuItem, steamIDToolStrip });
            modifyToolStripMenuItem.ForeColor = SystemColors.Control;
            modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            modifyToolStripMenuItem.Size = new Size(166, 22);
            modifyToolStripMenuItem.Text = "Modify";
            // 
            // convertToolStrip
            // 
            convertToolStrip.BackColor = Color.FromArgb(50, 50, 50);
            convertToolStrip.ForeColor = SystemColors.Control;
            convertToolStrip.Name = "convertToolStrip";
            convertToolStrip.Size = new Size(141, 22);
            convertToolStrip.Text = "Convert";
            convertToolStrip.ToolTipText = "Convert a selected save file .sl2<>.co2";
            convertToolStrip.Click += ConvertSave_Click;
            // 
            // relicsToolStripMenuItem
            // 
            relicsToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            relicsToolStripMenuItem.Enabled = false;
            relicsToolStripMenuItem.ForeColor = SystemColors.Control;
            relicsToolStripMenuItem.Name = "relicsToolStripMenuItem";
            relicsToolStripMenuItem.Size = new Size(141, 22);
            relicsToolStripMenuItem.Text = "Edit Relics";
            relicsToolStripMenuItem.ToolTipText = "Modify existing relics on a selected game ";
            relicsToolStripMenuItem.Visible = false;
            // 
            // steamIDToolStrip
            // 
            steamIDToolStrip.BackColor = Color.FromArgb(50, 50, 50);
            steamIDToolStrip.ForeColor = SystemColors.Control;
            steamIDToolStrip.Name = "steamIDToolStrip";
            steamIDToolStrip.Size = new Size(141, 22);
            steamIDToolStrip.Text = "Edit SteamID";
            steamIDToolStrip.ToolTipText = "Modify the SteamID attached to the save file";
            steamIDToolStrip.Click += EditSteamID_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            optionsToolStripMenuItem.ForeColor = SystemColors.Control;
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(166, 22);
            optionsToolStripMenuItem.Text = "Restore a Save";
            optionsToolStripMenuItem.ToolTipText = "Restore a backed up save file";
            optionsToolStripMenuItem.Click += RestoreSaves_Click;
            // 
            // backupFileToolStrip
            // 
            backupFileToolStrip.BackColor = Color.FromArgb(50, 50, 50);
            backupFileToolStrip.ForeColor = SystemColors.Control;
            backupFileToolStrip.Name = "backupFileToolStrip";
            backupFileToolStrip.Size = new Size(166, 22);
            backupFileToolStrip.Text = "Backup a Save";
            backupFileToolStrip.Click += Backup_Click;
            // 
            // backupAllActiveToolStripMenuItem
            // 
            backupAllActiveToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            backupAllActiveToolStripMenuItem.ForeColor = SystemColors.Control;
            backupAllActiveToolStripMenuItem.Name = "backupAllActiveToolStripMenuItem";
            backupAllActiveToolStripMenuItem.Size = new Size(166, 22);
            backupAllActiveToolStripMenuItem.Text = "Backup All Active";
            backupAllActiveToolStripMenuItem.Click += BackupAll_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { readmeButton, checkForUpdateToolStripMenuItem, fAQToolStripMenuItem, aboutButton });
            helpToolStripMenuItem.ForeColor = Color.WhiteSmoke;
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 35);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += ViewBackupsClose_Click;
            // 
            // readmeButton
            // 
            readmeButton.BackColor = Color.FromArgb(50, 50, 50);
            readmeButton.ForeColor = SystemColors.Control;
            readmeButton.Name = "readmeButton";
            readmeButton.Size = new Size(171, 22);
            readmeButton.Text = "Readme";
            readmeButton.Click += Readme_Click;
            // 
            // checkForUpdateToolStripMenuItem
            // 
            checkForUpdateToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            checkForUpdateToolStripMenuItem.ForeColor = SystemColors.Control;
            checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            checkForUpdateToolStripMenuItem.Size = new Size(171, 22);
            checkForUpdateToolStripMenuItem.Text = "Check for Updates";
            checkForUpdateToolStripMenuItem.Click += CheckUpdates_Click;
            // 
            // fAQToolStripMenuItem
            // 
            fAQToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            fAQToolStripMenuItem.ForeColor = SystemColors.Control;
            fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            fAQToolStripMenuItem.Size = new Size(171, 22);
            fAQToolStripMenuItem.Text = "FAQ";
            fAQToolStripMenuItem.Click += FAQItem_Click;
            // 
            // aboutButton
            // 
            aboutButton.BackColor = Color.FromArgb(50, 50, 50);
            aboutButton.ForeColor = SystemColors.Control;
            aboutButton.Name = "aboutButton";
            aboutButton.Size = new Size(171, 22);
            aboutButton.Text = "About";
            aboutButton.Click += About_Click;
            // 
            // TitleImage
            // 
            TitleImage.BackColor = Color.Transparent;
            TitleImage.Image = (Image)resources.GetObject("TitleImage.Image");
            TitleImage.Location = new Point(54, 32);
            TitleImage.Name = "TitleImage";
            TitleImage.Size = new Size(240, 58);
            TitleImage.SizeMode = PictureBoxSizeMode.AutoSize;
            TitleImage.TabIndex = 16;
            TitleImage.TabStop = false;
            toolTip1.SetToolTip(TitleImage, "Go to releases");
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(80, 80, 80);
            listView1.BorderStyle = BorderStyle.FixedSingle;
            listView1.ContextMenuStrip = contextMenu;
            listView1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listView1.ForeColor = SystemColors.Control;
            listView1.FullRowSelect = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Location = new Point(11, 184);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(327, 179);
            listView1.Sorting = SortOrder.Ascending;
            listView1.TabIndex = 18;
            toolTip1.SetToolTip(listView1, "Select an archived item to modify or convert");
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.ItemSelectionChanged += ListView1SelectionChange;
            // 
            // contextMenu
            // 
            contextMenu.BackColor = SystemColors.ButtonFace;
            contextMenu.ImageScalingSize = new Size(24, 24);
            contextMenu.Items.AddRange(new ToolStripItem[] { makeActiveToolStripMenuItem, modifyToolStripMenuItem1, backupToolStripMenuItem, duplicateToolStripMenuItem, renameToolStripMenuItem, removeToolStripMenuItem, refreshToolTip });
            contextMenu.Name = "contextMenuStrip1";
            contextMenu.RenderMode = ToolStripRenderMode.Professional;
            contextMenu.ShowImageMargin = false;
            contextMenu.Size = new Size(115, 158);
            // 
            // makeActiveToolStripMenuItem
            // 
            makeActiveToolStripMenuItem.Name = "makeActiveToolStripMenuItem";
            makeActiveToolStripMenuItem.Size = new Size(114, 22);
            makeActiveToolStripMenuItem.Text = "Make Active";
            makeActiveToolStripMenuItem.Click += MakeActive_Click;
            // 
            // modifyToolStripMenuItem1
            // 
            modifyToolStripMenuItem1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            modifyToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { convertToolStripMenuItem, relicsToolStripMenuItem1, DefaultSteamIDToolStripMenuItem });
            modifyToolStripMenuItem1.Name = "modifyToolStripMenuItem1";
            modifyToolStripMenuItem1.Size = new Size(114, 22);
            modifyToolStripMenuItem1.Text = "Modify";
            // 
            // convertToolStripMenuItem
            // 
            convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            convertToolStripMenuItem.Size = new Size(141, 22);
            convertToolStripMenuItem.Text = "Convert";
            convertToolStripMenuItem.Click += ConvertSave_Click;
            // 
            // relicsToolStripMenuItem1
            // 
            relicsToolStripMenuItem1.Enabled = false;
            relicsToolStripMenuItem1.Name = "relicsToolStripMenuItem1";
            relicsToolStripMenuItem1.Size = new Size(141, 22);
            relicsToolStripMenuItem1.Text = "Edit Relics";
            relicsToolStripMenuItem1.Visible = false;
            // 
            // DefaultSteamIDToolStripMenuItem
            // 
            DefaultSteamIDToolStripMenuItem.Name = "DefaultSteamIDToolStripMenuItem";
            DefaultSteamIDToolStripMenuItem.Size = new Size(141, 22);
            DefaultSteamIDToolStripMenuItem.Text = "Edit SteamID";
            DefaultSteamIDToolStripMenuItem.Click += EditSteamID_Click;
            // 
            // backupToolStripMenuItem
            // 
            backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            backupToolStripMenuItem.Size = new Size(114, 22);
            backupToolStripMenuItem.Text = "Backup";
            backupToolStripMenuItem.Click += Backup_Click;
            // 
            // duplicateToolStripMenuItem
            // 
            duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            duplicateToolStripMenuItem.Size = new Size(114, 22);
            duplicateToolStripMenuItem.Text = "Duplicate";
            duplicateToolStripMenuItem.Click += Duplicate_Click;
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(114, 22);
            renameToolStripMenuItem.Text = "Rename";
            renameToolStripMenuItem.Click += Rename_Click;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(114, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += Remove_Click;
            // 
            // refreshToolTip
            // 
            refreshToolTip.Name = "refreshToolTip";
            refreshToolTip.Size = new Size(114, 22);
            refreshToolTip.Text = "Refresh";
            refreshToolTip.Click += Refresh_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(50, 50, 50);
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 367);
            label1.Name = "label1";
            label1.Size = new Size(327, 19);
            label1.TabIndex = 22;
            label1.Text = "Game Save Files (read-only)";
            label1.TextAlign = ContentAlignment.TopCenter;
            toolTip1.SetToolTip(label1, "Game save files are only to provide you an overview of active files. (this section is read-only)");
            // 
            // listView2
            // 
            listView2.BackColor = Color.FromArgb(80, 80, 80);
            listView2.BorderStyle = BorderStyle.FixedSingle;
            listView2.Cursor = Cursors.No;
            listView2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listView2.ForeColor = SystemColors.Control;
            listView2.FullRowSelect = true;
            listView2.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView2.Location = new Point(11, 386);
            listView2.MultiSelect = false;
            listView2.Name = "listView2";
            listView2.Size = new Size(327, 166);
            listView2.Sorting = SortOrder.Ascending;
            listView2.TabIndex = 23;
            toolTip1.SetToolTip(listView2, "Game save files are only to provide you an overview of active files. (this section is read-only)");
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.ItemSelectionChanged += ListView2SelectionChange;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(50, 50, 50);
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 165);
            label2.Name = "label2";
            label2.Size = new Size(327, 19);
            label2.TabIndex = 24;
            label2.Text = "Archived Save Files";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // refreshBttn2
            // 
            refreshBttn2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            refreshBttn2.BackColor = SystemColors.ButtonFace;
            refreshBttn2.BackgroundImageLayout = ImageLayout.Center;
            refreshBttn2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            refreshBttn2.ForeColor = Color.Black;
            refreshBttn2.Image = (Image)resources.GetObject("refreshBttn2.Image");
            refreshBttn2.Location = new Point(297, 500);
            refreshBttn2.Name = "refreshBttn2";
            refreshBttn2.Size = new Size(32, 32);
            refreshBttn2.TabIndex = 26;
            toolTip1.SetToolTip(refreshBttn2, "Refresh list");
            refreshBttn2.UseVisualStyleBackColor = false;
            refreshBttn2.Click += RefreshList2_Click;
            // 
            // versionLabel
            // 
            versionLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            versionLabel.AutoSize = true;
            versionLabel.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            versionLabel.Location = new Point(311, 555);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(0, 16);
            versionLabel.TabIndex = 29;
            versionLabel.TextAlign = ContentAlignment.BottomRight;
            // 
            // viewBackups
            // 
            viewBackups.Anchor = AnchorStyles.Top;
            viewBackups.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            viewBackups.BackColor = SystemColors.ButtonFace;
            viewBackups.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewBackups.ForeColor = Color.Black;
            viewBackups.Location = new Point(221, 3);
            viewBackups.Name = "viewBackups";
            viewBackups.Size = new Size(100, 30);
            viewBackups.TabIndex = 30;
            viewBackups.Text = "View Backups";
            toolTip1.SetToolTip(viewBackups, "View list of backup files");
            viewBackups.UseVisualStyleBackColor = false;
            viewBackups.Click += ViewBackups_Click;
            // 
            // refreshBttn1
            // 
            refreshBttn1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            refreshBttn1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            refreshBttn1.BackColor = SystemColors.ButtonFace;
            refreshBttn1.BackgroundImageLayout = ImageLayout.Center;
            refreshBttn1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            refreshBttn1.ForeColor = Color.Black;
            refreshBttn1.Image = (Image)resources.GetObject("refreshBttn1.Image");
            refreshBttn1.Location = new Point(297, 307);
            refreshBttn1.Name = "refreshBttn1";
            refreshBttn1.Size = new Size(32, 32);
            refreshBttn1.TabIndex = 33;
            toolTip1.SetToolTip(refreshBttn1, "Refresh list");
            refreshBttn1.UseVisualStyleBackColor = false;
            refreshBttn1.Click += RefreshList1_Click;
            // 
            // convertButton
            // 
            convertButton.Anchor = AnchorStyles.Top;
            convertButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            convertButton.BackColor = SystemColors.ButtonFace;
            convertButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            convertButton.ForeColor = Color.Black;
            convertButton.Location = new Point(111, 3);
            convertButton.Name = "convertButton";
            convertButton.Size = new Size(100, 30);
            convertButton.TabIndex = 0;
            convertButton.Text = "Convert Save";
            toolTip1.SetToolTip(convertButton, "Change the extension of a save file .sl2/.co2 for either Seemless or Vanilla");
            convertButton.UseVisualStyleBackColor = false;
            convertButton.Click += ConvertSave_Click;
            // 
            // importButton
            // 
            importButton.Anchor = AnchorStyles.Top;
            importButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            importButton.BackColor = SystemColors.ButtonFace;
            importButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            importButton.ForeColor = Color.Black;
            importButton.Location = new Point(3, 3);
            importButton.Name = "importButton";
            importButton.Size = new Size(100, 30);
            importButton.TabIndex = 37;
            importButton.Text = "Import File";
            toolTip1.SetToolTip(importButton, "Change the extension of a save file .sl2/.co2 for either Seemless or Vanilla");
            importButton.UseVisualStyleBackColor = false;
            importButton.Click += VanillaImport_Click;
            // 
            // makeActiveButton
            // 
            makeActiveButton.Anchor = AnchorStyles.Top;
            makeActiveButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            makeActiveButton.BackColor = SystemColors.ButtonFace;
            makeActiveButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            makeActiveButton.ForeColor = Color.Black;
            makeActiveButton.Location = new Point(3, 39);
            makeActiveButton.Name = "makeActiveButton";
            makeActiveButton.Size = new Size(100, 30);
            makeActiveButton.TabIndex = 1;
            makeActiveButton.Text = "Make Active";
            toolTip1.SetToolTip(makeActiveButton, "Set a file to be the current save to load into");
            makeActiveButton.UseVisualStyleBackColor = false;
            makeActiveButton.Click += MakeActive_Click;
            // 
            // restoreButton
            // 
            restoreButton.Anchor = AnchorStyles.Top;
            restoreButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            restoreButton.BackColor = SystemColors.ButtonFace;
            restoreButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            restoreButton.ForeColor = Color.Black;
            restoreButton.Location = new Point(109, 39);
            restoreButton.Name = "restoreButton";
            restoreButton.Size = new Size(104, 30);
            restoreButton.TabIndex = 28;
            restoreButton.Text = "Restore a Save";
            toolTip1.SetToolTip(restoreButton, "Restore a save from backup and make your active save file");
            restoreButton.UseVisualStyleBackColor = false;
            restoreButton.Click += RestoreSaves_Click;
            // 
            // backupAllButton
            // 
            backupAllButton.Anchor = AnchorStyles.Top;
            backupAllButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            backupAllButton.BackColor = SystemColors.ButtonFace;
            backupAllButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backupAllButton.ForeColor = Color.Black;
            backupAllButton.Location = new Point(221, 39);
            backupAllButton.Name = "backupAllButton";
            backupAllButton.Size = new Size(100, 30);
            backupAllButton.TabIndex = 27;
            backupAllButton.Text = "Backup Saves";
            toolTip1.SetToolTip(backupAllButton, "Backup all current save files (overwrites existing)");
            backupAllButton.UseVisualStyleBackColor = false;
            backupAllButton.Click += BackupAll_Click;
            // 
            // backupListView
            // 
            backupListView.BackColor = SystemColors.Menu;
            backupListView.Enabled = false;
            backupListView.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backupListView.ForeColor = SystemColors.ControlText;
            backupListView.FullRowSelect = true;
            backupListView.Location = new Point(11, 165);
            backupListView.MultiSelect = false;
            backupListView.Name = "backupListView";
            backupListView.Size = new Size(327, 387);
            backupListView.Sorting = SortOrder.Ascending;
            backupListView.TabIndex = 31;
            backupListView.UseCompatibleStateImageBehavior = false;
            backupListView.Visible = false;
            backupListView.SelectedIndexChanged += ViewBackupsClose_Click;
            backupListView.Click += ViewBackupsClose_Click;
            // 
            // KofiImage
            // 
            KofiImage.Cursor = Cursors.Hand;
            KofiImage.Image = (Image)resources.GetObject("KofiImage.Image");
            KofiImage.Location = new Point(226, 35);
            KofiImage.Name = "KofiImage";
            KofiImage.Size = new Size(119, 16);
            KofiImage.SizeMode = PictureBoxSizeMode.AutoSize;
            KofiImage.TabIndex = 32;
            KofiImage.TabStop = false;
            KofiImage.Click += Kofi_Click;
            // 
            // setupText
            // 
            setupText.BackColor = Color.FromArgb(80, 80, 80);
            setupText.FlatStyle = FlatStyle.Flat;
            setupText.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            setupText.ForeColor = SystemColors.Control;
            setupText.Location = new Point(54, 217);
            setupText.Name = "setupText";
            setupText.Size = new Size(240, 101);
            setupText.TabIndex = 34;
            setupText.Text = "ARCHIVE EMPTY\r\nGet started by going to File > Import > Vanilla Save File(s)\r\nIt is also recommened to select 'Backup Saves' as your first action.";
            setupText.TextAlign = ContentAlignment.MiddleCenter;
            setupText.Visible = false;
            // 
            // saveSetup
            // 
            saveSetup.BackColor = Color.FromArgb(80, 80, 80);
            saveSetup.FlatStyle = FlatStyle.Flat;
            saveSetup.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveSetup.ForeColor = SystemColors.Control;
            saveSetup.Location = new Point(54, 430);
            saveSetup.Name = "saveSetup";
            saveSetup.Size = new Size(240, 101);
            saveSetup.TabIndex = 35;
            saveSetup.TextAlign = ContentAlignment.MiddleCenter;
            saveSetup.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(importButton, 0, 0);
            tableLayoutPanel1.Controls.Add(backupAllButton, 2, 1);
            tableLayoutPanel1.Controls.Add(restoreButton, 1, 1);
            tableLayoutPanel1.Controls.Add(makeActiveButton, 0, 1);
            tableLayoutPanel1.Controls.Add(convertButton, 1, 0);
            tableLayoutPanel1.Controls.Add(viewBackups, 2, 0);
            tableLayoutPanel1.Location = new Point(12, 90);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(326, 72);
            tableLayoutPanel1.TabIndex = 36;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.FromArgb(30, 30, 30);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(350, 570);
            Controls.Add(backupListView);
            Controls.Add(KofiImage);
            Controls.Add(saveSetup);
            Controls.Add(setupText);
            Controls.Add(refreshBttn1);
            Controls.Add(versionLabel);
            Controls.Add(refreshBttn2);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(TitleBar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TitleImage);
            Controls.Add(tableLayoutPanel1);
            DoubleBuffered = true;
            Font = new Font("Century Gothic", 10F);
            ForeColor = Color.WhiteSmoke;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(350, 570);
            MinimumSize = new Size(350, 570);
            Name = "Main";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NR Save Manager";
            Load += MainForm_Load;
            SizeChanged += MainForm_Resize;
            Click += ViewBackupsClose_Click;
            MouseDown += TitleBar_MouseDown;
            MouseMove += TitleBar_MouseMove;
            MouseUp += TitleBar_MouseUp;
            TitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CloseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)MiniButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconImage).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TitleImage).EndInit();
            contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)KofiImage).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private Panel TitleBar;
        private PictureBox CloseButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem vanillaSaveFileToolStripMenuItem;
        private ToolStripMenuItem seemlessSaveFileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutButton;
        private PictureBox IconImage;
        private PictureBox MiniButton;
        private PictureBox TitleImage;
        private ListView listView1;
        private ToolStripMenuItem readmeButton;
        private Label label1;
        private ListView listView2;
        private Label label2;
        private Button refreshBttn2;
        private Label versionLabel;
        private ToolStripMenuItem openDirectoryToolStripMenuItem;
        private ToolStripMenuItem openSaveDir;
        private ToolStripMenuItem openBackupDir;
        private ToolStripMenuItem openArchiveDir;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem makeActiveToolStripMenuItem;
        private ToolStripMenuItem backupToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private ToolTip toolTip1;
        private Button viewBackups;
        private ListView backupListView;
        private PictureBox KofiImage;
        private ToolStripMenuItem refreshToolTip;
        private Button refreshBttn1;
        private ToolStripMenuItem launchSeemlessToolStripMenuItem;
        private ToolStripMenuItem launchNightreignToolStripMenuItem;
        private ToolStripMenuItem modifyToolStripMenuItem;
        private ToolStripMenuItem relicsToolStripMenuItem;
        private ToolStripMenuItem modifyToolStripMenuItem1;
        private ToolStripMenuItem relicsToolStripMenuItem1;
        private ToolStripMenuItem changeSteamProfileIDToolStripMenuItem;
        private ToolStripMenuItem steamIDToolStrip;
        private ToolStripMenuItem DefaultSteamIDToolStripMenuItem;
        private ToolStripMenuItem convertToolStripMenuItem;
        private ToolStripMenuItem convertToolStrip;
        private Label setupText;
        private ToolStripMenuItem fAQToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem renameToolStrip;
        private ToolStripMenuItem duplicateToolStrip;
        private ToolStripMenuItem removeToolStrip;
        private ToolStripMenuItem backupFileToolStrip;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStripMenuItem duplicateToolStripMenuItem;
        private ToolStripMenuItem backupAllActiveToolStripMenuItem;
        private Label saveSetup;
        private TableLayoutPanel tableLayoutPanel1;
        private Button convertButton;
        private Button importButton;
        private Button backupAllButton;
        private Button restoreButton;
        private Button makeActiveButton;
    }
}

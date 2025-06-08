namespace NightreignSaveManager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStripSeparator1 = new ToolStripSeparator();
            fileToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            closeButton = new PictureBox();
            miniButton = new PictureBox();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem1 = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            vanillaSaveFileToolStripMenuItem = new ToolStripMenuItem();
            seemlessSaveFileToolStripMenuItem = new ToolStripMenuItem();
            openDirectoryToolStripMenuItem = new ToolStripMenuItem();
            openSaveDir = new ToolStripMenuItem();
            openBackupDir = new ToolStripMenuItem();
            openArchiveDir = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            customizeToolStripMenuItem = new ToolStripMenuItem();
            toSeemlessToolStripMenuItem = new ToolStripMenuItem();
            toVanillaToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            restoreSeemlessBackupToolStripMenuItem = new ToolStripMenuItem();
            restoreVanillaBackupToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            rEADMEToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            pictureBox2 = new PictureBox();
            button2 = new Button();
            button1 = new Button();
            listView1 = new ListView();
            label1 = new Label();
            listView2 = new ListView();
            label2 = new Label();
            button3 = new Button();
            button6 = new Button();
            button7 = new Button();
            button4 = new Button();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)closeButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)miniButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(50, 50, 50);
            panel1.Controls.Add(closeButton);
            panel1.Controls.Add(miniButton);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 35);
            panel1.TabIndex = 15;
            panel1.Paint += panel1_Paint;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.Transparent;
            closeButton.BackgroundImageLayout = ImageLayout.None;
            closeButton.Image = (Image)resources.GetObject("closeButton.Image");
            closeButton.Location = new Point(316, 0);
            closeButton.Margin = new Padding(0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(34, 35);
            closeButton.SizeMode = PictureBoxSizeMode.CenterImage;
            closeButton.TabIndex = 16;
            closeButton.TabStop = false;
            closeButton.Click += pictureBox1_Click_1;
            closeButton.MouseEnter += pictureBox1_MouseEnter;
            closeButton.MouseLeave += pictureBox1_MouseLeave;
            // 
            // miniButton
            // 
            miniButton.BackColor = Color.Transparent;
            miniButton.BackgroundImageLayout = ImageLayout.None;
            miniButton.Image = (Image)resources.GetObject("miniButton.Image");
            miniButton.Location = new Point(279, 0);
            miniButton.Name = "miniButton";
            miniButton.Size = new Size(34, 35);
            miniButton.SizeMode = PictureBoxSizeMode.CenterImage;
            miniButton.TabIndex = 16;
            miniButton.TabStop = false;
            miniButton.Click += pictureBox2_Click;
            miniButton.MouseEnter += pictureBox2_MouseEnter;
            miniButton.MouseLeave += pictureBox2_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.icon;
            pictureBox1.Location = new Point(11, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 16);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += panel1_MouseDown;
            pictureBox1.MouseMove += panel1_MouseMove;
            pictureBox1.MouseUp += panel1_MouseUp;
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = Color.FromArgb(50, 50, 50);
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem1, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(40, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(0);
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(254, 35);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            menuStrip1.MouseDown += panel1_MouseDown;
            menuStrip1.MouseMove += panel1_MouseMove;
            menuStrip1.MouseUp += panel1_MouseUp;
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.BackColor = Color.FromArgb(50, 50, 50);
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, openDirectoryToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem1.ForeColor = SystemColors.Control;
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Padding = new Padding(0);
            fileToolStripMenuItem1.Size = new Size(29, 35);
            fileToolStripMenuItem1.Text = "File";
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
            openToolStripMenuItem.Size = new Size(154, 22);
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
            vanillaSaveFileToolStripMenuItem.Click += vanillaSaveFileToolStripMenuItem_Click;
            // 
            // seemlessSaveFileToolStripMenuItem
            // 
            seemlessSaveFileToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            seemlessSaveFileToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            seemlessSaveFileToolStripMenuItem.ForeColor = SystemColors.Control;
            seemlessSaveFileToolStripMenuItem.Name = "seemlessSaveFileToolStripMenuItem";
            seemlessSaveFileToolStripMenuItem.Size = new Size(183, 22);
            seemlessSaveFileToolStripMenuItem.Text = "Seemless Save File(s)";
            seemlessSaveFileToolStripMenuItem.Click += seemlessSaveFileToolStripMenuItem_Click;
            // 
            // openDirectoryToolStripMenuItem
            // 
            openDirectoryToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            openDirectoryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openSaveDir, openBackupDir, openArchiveDir });
            openDirectoryToolStripMenuItem.ForeColor = SystemColors.Control;
            openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            openDirectoryToolStripMenuItem.Size = new Size(154, 22);
            openDirectoryToolStripMenuItem.Text = "Open Directory";
            // 
            // openSaveDir
            // 
            openSaveDir.BackColor = Color.FromArgb(50, 50, 50);
            openSaveDir.ForeColor = SystemColors.Control;
            openSaveDir.Name = "openSaveDir";
            openSaveDir.Size = new Size(139, 22);
            openSaveDir.Text = "Game Saves";
            openSaveDir.Click += openSaveDir_Click;
            // 
            // openBackupDir
            // 
            openBackupDir.BackColor = Color.FromArgb(50, 50, 50);
            openBackupDir.ForeColor = SystemColors.Control;
            openBackupDir.Name = "openBackupDir";
            openBackupDir.Size = new Size(139, 22);
            openBackupDir.Text = "Backup Files";
            openBackupDir.Click += openBackupDir_Click;
            // 
            // openArchiveDir
            // 
            openArchiveDir.BackColor = Color.FromArgb(50, 50, 50);
            openArchiveDir.ForeColor = SystemColors.Control;
            openArchiveDir.Name = "openArchiveDir";
            openArchiveDir.Size = new Size(139, 22);
            openArchiveDir.Text = "Archive";
            openArchiveDir.Click += openArchiveDir_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            exitToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            exitToolStripMenuItem.ForeColor = SystemColors.Control;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(154, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += pictureBox1_Click_1;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customizeToolStripMenuItem, optionsToolStripMenuItem });
            toolsToolStripMenuItem.ForeColor = Color.WhiteSmoke;
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(61, 35);
            toolsToolStripMenuItem.Text = "Options";
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            customizeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toSeemlessToolStripMenuItem, toVanillaToolStripMenuItem });
            customizeToolStripMenuItem.ForeColor = SystemColors.Control;
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new Size(143, 22);
            customizeToolStripMenuItem.Text = "Convert Save";
            // 
            // toSeemlessToolStripMenuItem
            // 
            toSeemlessToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            toSeemlessToolStripMenuItem.ForeColor = SystemColors.Control;
            toSeemlessToolStripMenuItem.Name = "toSeemlessToolStripMenuItem";
            toSeemlessToolStripMenuItem.Size = new Size(137, 22);
            toSeemlessToolStripMenuItem.Text = "To Seemless";
            // 
            // toVanillaToolStripMenuItem
            // 
            toVanillaToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            toVanillaToolStripMenuItem.ForeColor = SystemColors.Control;
            toVanillaToolStripMenuItem.Name = "toVanillaToolStripMenuItem";
            toVanillaToolStripMenuItem.Size = new Size(137, 22);
            toVanillaToolStripMenuItem.Text = "To Vanilla";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { restoreSeemlessBackupToolStripMenuItem, restoreVanillaBackupToolStripMenuItem });
            optionsToolStripMenuItem.ForeColor = SystemColors.Control;
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(143, 22);
            optionsToolStripMenuItem.Text = "Restore";
            // 
            // restoreSeemlessBackupToolStripMenuItem
            // 
            restoreSeemlessBackupToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            restoreSeemlessBackupToolStripMenuItem.ForeColor = SystemColors.Control;
            restoreSeemlessBackupToolStripMenuItem.Name = "restoreSeemlessBackupToolStripMenuItem";
            restoreSeemlessBackupToolStripMenuItem.Size = new Size(206, 22);
            restoreSeemlessBackupToolStripMenuItem.Text = "Restore Seemless Backup";
            // 
            // restoreVanillaBackupToolStripMenuItem
            // 
            restoreVanillaBackupToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            restoreVanillaBackupToolStripMenuItem.ForeColor = SystemColors.Control;
            restoreVanillaBackupToolStripMenuItem.Name = "restoreVanillaBackupToolStripMenuItem";
            restoreVanillaBackupToolStripMenuItem.Size = new Size(206, 22);
            restoreVanillaBackupToolStripMenuItem.Text = "Restore Vanilla Backup";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rEADMEToolStripMenuItem, aboutToolStripMenuItem });
            helpToolStripMenuItem.ForeColor = Color.WhiteSmoke;
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 35);
            helpToolStripMenuItem.Text = "Help";
            // 
            // rEADMEToolStripMenuItem
            // 
            rEADMEToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            rEADMEToolStripMenuItem.ForeColor = SystemColors.Control;
            rEADMEToolStripMenuItem.Name = "rEADMEToolStripMenuItem";
            rEADMEToolStripMenuItem.Size = new Size(117, 22);
            rEADMEToolStripMenuItem.Text = "Readme";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.BackColor = Color.FromArgb(50, 50, 50);
            aboutToolStripMenuItem.ForeColor = SystemColors.Control;
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(117, 22);
            aboutToolStripMenuItem.Text = "About";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-3, 32);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(353, 64);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.BackColor = SystemColors.ButtonFace;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(11, 135);
            button2.Name = "button2";
            button2.Size = new Size(88, 27);
            button2.TabIndex = 1;
            button2.Text = "Make Active";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackColor = Color.FromArgb(80, 80, 80);
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(86, 102);
            button1.Name = "button1";
            button1.Size = new Size(179, 27);
            button1.TabIndex = 0;
            button1.Text = "Convert to Vanilla/Seemless";
            button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(80, 80, 80);
            listView1.BorderStyle = BorderStyle.FixedSingle;
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
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(50, 50, 50);
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 367);
            label1.Name = "label1";
            label1.Size = new Size(327, 19);
            label1.TabIndex = 22;
            label1.Text = "Game Save Files";
            label1.TextAlign = ContentAlignment.TopCenter;
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
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.ItemSelectionChanged += listView1_ItemSelectionChanged;
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
            // button3
            // 
            button3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button3.BackColor = SystemColors.ButtonFace;
            button3.BackgroundImageLayout = ImageLayout.Center;
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Black;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(297, 323);
            button3.Name = "button3";
            button3.Size = new Size(32, 32);
            button3.TabIndex = 25;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button6
            // 
            button6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button6.BackColor = SystemColors.ButtonFace;
            button6.BackgroundImageLayout = ImageLayout.Center;
            button6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.Black;
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.Location = new Point(297, 514);
            button6.Name = "button6";
            button6.Size = new Size(32, 32);
            button6.TabIndex = 26;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.AutoSize = true;
            button7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button7.BackColor = Color.FromArgb(80, 80, 80);
            button7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.Black;
            button7.Location = new Point(112, 135);
            button7.Name = "button7";
            button7.Size = new Size(134, 27);
            button7.TabIndex = 27;
            button7.Text = "Backup Game Saves";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button4
            // 
            button4.AutoSize = true;
            button4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button4.BackColor = Color.FromArgb(80, 80, 80);
            button4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(257, 135);
            button4.Name = "button4";
            button4.Size = new Size(81, 27);
            button4.TabIndex = 28;
            button4.Text = "Restore All";
            button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(311, 555);
            label3.Name = "label3";
            label3.Size = new Size(39, 16);
            label3.TabIndex = 29;
            label3.Text = "v1.0.1";
            label3.TextAlign = ContentAlignment.BottomRight;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(30, 30, 30);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(350, 570);
            Controls.Add(label3);
            Controls.Add(button4);
            Controls.Add(button7);
            Controls.Add(button3);
            Controls.Add(button6);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            Font = new Font("Century Gothic", 10F);
            ForeColor = Color.WhiteSmoke;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(350, 570);
            MinimumSize = new Size(350, 570);
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NR Save Manager";
            Load += Form1_Load;
            SizeChanged += Form1_Resize;
            MouseDown += panel1_MouseDown;
            MouseMove += panel1_MouseMove;
            MouseUp += panel1_MouseUp;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)closeButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)miniButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private Panel panel1;
        private PictureBox closeButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem vanillaSaveFileToolStripMenuItem;
        private ToolStripMenuItem seemlessSaveFileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem toSeemlessToolStripMenuItem;
        private ToolStripMenuItem toVanillaToolStripMenuItem;
        private PictureBox miniButton;
        private PictureBox pictureBox2;
        private ListView listView1;
        private ToolStripMenuItem restoreVanillaBackupToolStripMenuItem;
        private ToolStripMenuItem restoreSeemlessBackupToolStripMenuItem;
        private ToolStripMenuItem rEADMEToolStripMenuItem;
        private Button button1;
        private Button button2;
        private Label label1;
        private ListView listView2;
        private Label label2;
        private Button button3;
        private Button button6;
        private Button button7;
        private Button button4;
        private Label label3;
        private ToolStripMenuItem openDirectoryToolStripMenuItem;
        private ToolStripMenuItem openSaveDir;
        private ToolStripMenuItem openBackupDir;
        private ToolStripMenuItem openArchiveDir;
    }
}

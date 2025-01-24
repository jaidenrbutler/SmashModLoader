namespace SmashModLoader
{
    partial class SmashModManager
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
            DownloadMods = new Button();
            OpenModFolder = new Button();
            Settings = new Button();
            Launch = new Button();
            groupBox1 = new GroupBox();
            ListViewPlugins = new ListView();
            Plugins = new ColumnHeader();
            contextMenuStrip2 = new ContextMenuStrip(components);
            enableToolStripMenuItem1 = new ToolStripMenuItem();
            disableToolStripMenuItem1 = new ToolStripMenuItem();
            ListViewMods = new ListView();
            columnHeader1 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            enableToolStripMenuItem = new ToolStripMenuItem();
            disableToolStripMenuItem = new ToolStripMenuItem();
            ImportMod = new Button();
            Enable = new ToolStripMenuItem();
            Disable = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DownloadMods
            // 
            DownloadMods.Location = new Point(12, 12);
            DownloadMods.Name = "DownloadMods";
            DownloadMods.Size = new Size(100, 61);
            DownloadMods.TabIndex = 0;
            DownloadMods.Text = "Download Mods";
            DownloadMods.UseVisualStyleBackColor = true;
            DownloadMods.Click += DownloadMods_Click;
            // 
            // OpenModFolder
            // 
            OpenModFolder.Location = new Point(118, 13);
            OpenModFolder.Name = "OpenModFolder";
            OpenModFolder.Size = new Size(100, 60);
            OpenModFolder.TabIndex = 1;
            OpenModFolder.Text = "Open Mod Folder";
            OpenModFolder.UseVisualStyleBackColor = true;
            OpenModFolder.Click += OpenModFolder_Click;
            // 
            // Settings
            // 
            Settings.Location = new Point(224, 13);
            Settings.Name = "Settings";
            Settings.Size = new Size(100, 60);
            Settings.TabIndex = 2;
            Settings.Text = "Settings";
            Settings.UseVisualStyleBackColor = true;
            Settings.Click += Settings_Click;
            // 
            // Launch
            // 
            Launch.Location = new Point(688, 13);
            Launch.Name = "Launch";
            Launch.Size = new Size(100, 60);
            Launch.TabIndex = 3;
            Launch.Text = "Launch";
            Launch.UseVisualStyleBackColor = true;
            Launch.Click += Launch_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ListViewPlugins);
            groupBox1.Controls.Add(ListViewMods);
            groupBox1.Location = new Point(12, 79);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 365);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // ListViewPlugins
            // 
            ListViewPlugins.Columns.AddRange(new ColumnHeader[] { Plugins });
            ListViewPlugins.ContextMenuStrip = contextMenuStrip2;
            ListViewPlugins.Location = new Point(410, 17);
            ListViewPlugins.Name = "ListViewPlugins";
            ListViewPlugins.Size = new Size(366, 342);
            ListViewPlugins.TabIndex = 1;
            ListViewPlugins.UseCompatibleStateImageBehavior = false;
            ListViewPlugins.View = View.Details;
            // 
            // Plugins
            // 
            Plugins.Text = "Plugins";
            Plugins.Width = 300;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { enableToolStripMenuItem1, disableToolStripMenuItem1 });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(113, 48);
            // 
            // enableToolStripMenuItem1
            // 
            enableToolStripMenuItem1.Name = "enableToolStripMenuItem1";
            enableToolStripMenuItem1.Size = new Size(112, 22);
            enableToolStripMenuItem1.Text = "Enable";
            enableToolStripMenuItem1.Click += enableToolStripMenuItem1_Click;
            // 
            // disableToolStripMenuItem1
            // 
            disableToolStripMenuItem1.Name = "disableToolStripMenuItem1";
            disableToolStripMenuItem1.Size = new Size(112, 22);
            disableToolStripMenuItem1.Text = "Disable";
            disableToolStripMenuItem1.Click += disableToolStripMenuItem1_Click;
            // 
            // ListViewMods
            // 
            ListViewMods.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            ListViewMods.ContextMenuStrip = contextMenuStrip1;
            ListViewMods.Location = new Point(0, 17);
            ListViewMods.Name = "ListViewMods";
            ListViewMods.Size = new Size(352, 342);
            ListViewMods.TabIndex = 0;
            ListViewMods.UseCompatibleStateImageBehavior = false;
            ListViewMods.View = View.Details;
            ListViewMods.SelectedIndexChanged += ListViewMods_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Mods";
            columnHeader1.Width = 400;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { enableToolStripMenuItem, disableToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 92);
            // 
            // enableToolStripMenuItem
            // 
            enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            enableToolStripMenuItem.Size = new Size(180, 22);
            enableToolStripMenuItem.Text = "Enable";
            enableToolStripMenuItem.Click += enableToolStripMenuItem_Click;
            // 
            // disableToolStripMenuItem
            // 
            disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            disableToolStripMenuItem.Size = new Size(180, 22);
            disableToolStripMenuItem.Text = "Disable";
            disableToolStripMenuItem.Click += disableToolStripMenuItem_Click_1;
            // 
            // ImportMod
            // 
            ImportMod.Location = new Point(330, 13);
            ImportMod.Name = "ImportMod";
            ImportMod.Size = new Size(100, 60);
            ImportMod.TabIndex = 5;
            ImportMod.Text = "Import Mod Zip";
            ImportMod.UseVisualStyleBackColor = true;
            ImportMod.Click += ImportMod_Click;
            // 
            // Enable
            // 
            Enable.Name = "Enable";
            Enable.Size = new Size(180, 22);
            Enable.Text = "Enable";
            // 
            // Disable
            // 
            Disable.Name = "Disable";
            Disable.Size = new Size(180, 22);
            Disable.Text = "Disable";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(180, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // SmashModManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ImportMod);
            Controls.Add(groupBox1);
            Controls.Add(Launch);
            Controls.Add(Settings);
            Controls.Add(OpenModFolder);
            Controls.Add(DownloadMods);
            Name = "SmashModManager";
            Text = "SSBU Mod Manager";
            groupBox1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button DownloadMods;
        private Button OpenModFolder;
        private Button Settings;
        private Button Launch;
        private GroupBox groupBox1;
        private ListView ListViewMods;
        private ColumnHeader columnHeader1;
        private Button ImportMod;
        private ToolStripMenuItem Enable;
        private ToolStripMenuItem Disable;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem enableToolStripMenuItem;
        private ToolStripMenuItem disableToolStripMenuItem;
        private ListView ListViewPlugins;
        private ColumnHeader Plugins;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem enableToolStripMenuItem1;
        private ToolStripMenuItem disableToolStripMenuItem1;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}

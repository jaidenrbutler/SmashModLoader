using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmashModLoader
{
    public partial class SettingsForm : Form
    {
        public string YuzuFolderPath { get; private set; }
        public string YuzuExePath { get; private set; }
        public string SmashIsoPath { get; private set; }

        public SettingsForm(string currentYuzuFolder, string currentYuzuExePath, string currentSmashIsoPath)
        {
            InitializeComponent();
            YuzuFolderPath = currentYuzuFolder;
            YuzuExePath = currentYuzuExePath;
            SmashIsoPath = currentSmashIsoPath;

            // Set the initinal text box values
            textBox1.Text = YuzuFolderPath;
            textBox2.Text = YuzuExePath;
            SmashIsoTextBox.Text = SmashIsoPath;
        }

        private void SelectYuzuFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                folderBrowser.Description = "Select Your Mod Folder";
                folderBrowser.ShowNewFolderButton = false;
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    YuzuFolderPath = folderBrowser.SelectedPath;
                    textBox1.Text = YuzuFolderPath;
                }
            }
        }

        private void SelectYuzuExe_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Yuzu Executable|yuzu.exe";
                fileDialog.Title = "Select the yuzu executable";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    YuzuExePath = fileDialog.FileName;
                    textBox2.Text = YuzuExePath;
                }
            }
        }

        private void SmashISOBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Smash Bros ISO|*.nsp";
                fileDialog.Title = "Select the Smash Bros ISO";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    SmashIsoPath = fileDialog.FileName;
                    SmashIsoTextBox.Text = SmashIsoPath;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Save setting
            Properties.Settings.Default.YuzuFolderPath = YuzuFolderPath;
            Properties.Settings.Default.YuzuPath = YuzuExePath;
            Properties.Settings.Default.SmashISO = SmashIsoPath;
            Properties.Settings.Default.Save();

            MessageBox.Show("Settings saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the form
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


    }
}

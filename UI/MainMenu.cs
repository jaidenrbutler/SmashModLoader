// TODO: in order
// Search and filter
// Better error logging
// Drag and drop mod import
// Dark Mode
// Better notifications and loading symbols

using System.Runtime.CompilerServices;
using System;
using System.IO.Compression;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace SmashModLoader
{
    public partial class SmashModManager : Form
    {
        // Paths to mod folders
        private string? modFolder;
        private string? disabledFolderPath;
        private string? pluginFolder;
        private string? disabledPluginPath;
        private string? smashIsoPath;

        public SmashModManager()
        {
            InitializeComponent();
            SetModFolderPaths();
            EnsureDisabledFolderExists();
            LoadMods();
            LoadPlugins();
            TotalModCount();
        }

        private void SetModFolderPaths()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            modFolder = Path.Combine(appDataPath, @"yuzu\sdmc\ultimate\mods\");
            disabledFolderPath = Path.Combine(modFolder, "disabled");
            pluginFolder = Path.Combine(appDataPath, @"yuzu\sdmc\atmosphere\contents\01006A800016E000\romfs\skyline\plugins\");
            disabledPluginPath = Path.Combine(appDataPath, @"yuzu\sdmc\atmosphere\contents\01006A800016E000\romfs\skyline\disabled\");

            Console.WriteLine("Plugin Folder: " + pluginFolder);
            Console.WriteLine("Disabled Plugin Path: " + disabledPluginPath);
        }

        private void EnsureDisabledFolderExists()
        {
            if (!Directory.Exists(disabledFolderPath))
            {
                Directory.CreateDirectory(disabledFolderPath);
            }

            if (!Directory.Exists(disabledPluginPath))
            {
                Directory.CreateDirectory(disabledPluginPath);
            }
        }


        private void OpenModFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(modFolder))
            {
                System.Diagnostics.Process.Start("explorer.exe", modFolder);
            }
            else
            {
                MessageBox.Show($"The mods folder does not exist: {modFolder}");
            }
        }

        private async void ImportMod_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileBrowser = new OpenFileDialog())
            {
                // filter for only zip files
                fileBrowser.Filter = "Zip files (*.zip)|*.zip";


                if (fileBrowser.ShowDialog() == DialogResult.OK)
                {
                    ImportProgressBar.Visible = true;
                    ImportProgressBar.Style = ProgressBarStyle.Marquee;


                    // Path of the file
                    var filePath = fileBrowser.FileName;

                    try
                    {
                        await Task.Run(() => extractModToModFolder(filePath));

                        MessageBox.Show("Mod imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to import mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Hide the progress bar after the operation
                        ImportProgressBar.Visible = false;
                    }

                }
            }
        }

        private void extractModToModFolder(string filePath)
        {
            string tempExtractPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempExtractPath);

            try
            {
                // Extract the zip file to the temp folder
                ZipFile.ExtractToDirectory(filePath, tempExtractPath);

                foreach (var file in Directory.GetFiles(tempExtractPath, "*", SearchOption.AllDirectories))
                {
                    string fileName = Path.GetFileName(file);

                    if (fileName.EndsWith(".nro", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!File.Exists(Path.Combine(pluginFolder, fileName)))
                        {
                            // Move .nro files to plugins folder
                            string destinationPath = Path.Combine(pluginFolder, fileName);
                            Directory.CreateDirectory(pluginFolder);
                            File.Move(file, destinationPath);
                        }
                    }
                    else
                    {
                        if (!File.Exists(Path.Combine(modFolder, fileName)))
                        {
                            // Move other files to mods folder
                            string relativePath = Path.GetRelativePath(tempExtractPath, file);
                            string destinationPath = Path.Combine(modFolder, relativePath);
                            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath)!);
                            File.Move(file, destinationPath);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to extract mod: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Clean up temp folder
                if (Directory.Exists(tempExtractPath))
                {
                    Directory.Delete(tempExtractPath, true);
                }

                LoadMods();
                LoadPlugins();
            }
        }

        private void ExportModsAndPlugins(string exportPath)
        {
            try
            {
                // Temp folder to org mods and plugins
                string tempFolder = Path.Combine(Path.GetTempPath(), "ModsAndPluginsExport");

                // Ensure the temp folder is empty
                if (Directory.Exists(tempFolder))
                    Directory.Delete(tempFolder, true);
                Directory.CreateDirectory(tempFolder);

                // Copy mods to the temp folder
                if (Directory.Exists(modFolder))
                {
                    CopyDirectory(modFolder, tempFolder);
                }

                // Copy plugins to the temp folder
                if (Directory.Exists(pluginFolder))
                {
                    CopyDirectory(pluginFolder, tempFolder);
                }

                // Create the ZIP file
                if (File.Exists(exportPath))
                    File.Delete(exportPath);
                ZipFile.CreateFromDirectory(tempFolder, exportPath);

                // Clean up the temp folder
                Directory.Delete(tempFolder, true);

                MessageBox.Show($"Mods and plugins have been successfully exported to: {exportPath} ");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured while exporting mods and plugins: {ex.Message} ");
            }
        }

        private void CopyDirectory(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);

            // copy all files
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string targetFile = Path.Combine(targetDir, Path.GetFileName(file));
                File.Copy(file, targetFile, true);
            }

            // Recursively copy subdirectories
            foreach (string directory in Directory.GetDirectories(sourceDir))
            {
                string targetSubDir = Path.Combine(targetDir, Path.GetFileName(directory));
                CopyDirectory(directory, targetSubDir);
            }
        }




        /// <summary>
        /// Gets the names of the directories in the mod folder and adds them to a list view
        /// </summary>
        /// <param name="folderPath"></param>
        private void LoadMods()
        {
            if (ListViewMods.InvokeRequired)
            {
                // Invoke the method on the UI thread
                ListViewMods.Invoke(new MethodInvoker(LoadMods));
                return;
            }

            // Clear the ListViewMods before reloading
            ListViewMods.Items.Clear();

            // Check if the mod folder exists before trying to list directories
            if (Directory.Exists(modFolder))
            {
                // Load enabled mods
                foreach (var folder in Directory.GetDirectories(modFolder))
                {
                    // Exclude the "disabled" folder
                    if (!folder.Equals(disabledFolderPath, StringComparison.OrdinalIgnoreCase))
                    {
                        ListViewMods.Items.Add(Path.GetFileName(folder) + " (Enabled)");
                    }
                }
            }
            else
            {
                MessageBox.Show($"The mods folder does not exist: {modFolder}");
            }

            // Check if the disabled folder exists before trying to list directories
            if (Directory.Exists(disabledFolderPath))
            {
                // Load disabled mods
                foreach (var folder in Directory.GetDirectories(disabledFolderPath))
                {
                    ListViewMods.Items.Add(Path.GetFileName(folder) + " (Disabled)");
                }
            }
            TotalModCount();
        }


        private void LoadPlugins()
        {
            if (ListViewPlugins.InvokeRequired)
            {
                // Switch to the UI thread if necessary
                ListViewPlugins.Invoke(new MethodInvoker(LoadPlugins));
                return;
            }

            // Clear the ListViewPlugins before reloading
            ListViewPlugins.Items.Clear();

            // Check if the plugin folder exists before trying to list files
            if (Directory.Exists(pluginFolder))
            {
                foreach (var file in Directory.GetFiles(pluginFolder))
                {
                    ListViewPlugins.Items.Add(Path.GetFileName(file) + " (Enabled)");
                }
            }

            // Check if the disabled plugin folder exists before trying to list files
            if (Directory.Exists(disabledPluginPath))
            {
                foreach (var file in Directory.GetFiles(disabledPluginPath))
                {
                    ListViewPlugins.Items.Add(Path.GetFileName(file) + " (Disabled)");
                }
            }
            TotalModCount();
        }

        #region Enable and disabling mods

        private void DisableMod(string modName)
        {
            string sourcePath = Path.Combine(modFolder, modName);
            string targetPath = Path.Combine(disabledFolderPath, modName);

            if (Directory.Exists(sourcePath))
            {
                Directory.Move(sourcePath, targetPath);
                LoadMods(); // Refresh the list
            }
            else
            {
                MessageBox.Show("Mod not found!");
            }
        }

        private void EnableMod(string modName)
        {
            string sourcePath = Path.Combine(disabledFolderPath, modName);
            string targetPath = Path.Combine(modFolder, modName);

            if (Directory.Exists(sourcePath))
            {
                Directory.Move(sourcePath, targetPath);
                LoadMods(); // Refresh the list
            }
            else
            {
                MessageBox.Show("Mod not found!");
            }
        }

        private void EnablePlugin(string pluginName)
        {
            string sourcePath = Path.Combine(disabledPluginPath, pluginName);
            string targetPath = Path.Combine(pluginFolder, pluginName);

            if (File.Exists(sourcePath))
            {
                if (File.Exists(targetPath))
                {
                    File.Delete(targetPath); // Or rename the existing file
                }
                File.Move(sourcePath, targetPath);
                LoadPlugins(); // Refresh the list
            }
            else
            {
                MessageBox.Show("Plugin not found!");
            }
        }

        private void DisablePlugin(string pluginName)
        {
            string sourcePath = Path.Combine(pluginFolder, pluginName);
            string targetPath = Path.Combine(disabledPluginPath, pluginName);

            if (File.Exists(sourcePath))
            {
                if (File.Exists(targetPath))
                {
                    File.Delete(targetPath); // Or rename the existing file
                }
                File.Move(sourcePath, targetPath);
                LoadPlugins(); // Refresh the list
            }
            else
            {
                MessageBox.Show("Plugin not found!");
            }
        }

        #endregion



        private void DownloadMods_Click(object sender, EventArgs e)
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://gamebanana.com/games/6498",
                UseShellExecute = true
            };


            System.Diagnostics.Process.Start(psi);
        }


        private void ListViewMods_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Enable_Click(object sender, EventArgs e)
        {
            if (ListViewMods.SelectedItems.Count > 0)
            {
                string modName = ListViewMods.SelectedItems[0].Text;
                EnableMod(modName);
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            string currentYuzuFolder = Properties.Settings.Default.YuzuFolderPath;
            string currentYuzuExePath = Properties.Settings.Default.YuzuPath;
            string currentSmashIsoPath = Properties.Settings.Default.SmashISO;

            using (SettingsForm settingsForm = new SettingsForm(currentYuzuFolder, currentYuzuExePath, currentSmashIsoPath))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    // Update paths in the main form
                    modFolder = settingsForm.YuzuFolderPath;
                    pluginFolder = Path.Combine(modFolder, @"..\..\atmosphere\contents\01006A800016E000\romfs\skyline\plugins");
                    disabledFolderPath = Path.Combine(modFolder, "disabled");
                    disabledPluginPath = Path.Combine(pluginFolder, "disabled");
                    smashIsoPath = settingsForm.SmashIsoPath;

                    // Reload mods and plugins with the updated paths
                    LoadMods();
                    LoadPlugins();
                }
            }
        }

        private void disableToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Ensure an item is selected
            if (ListViewMods.SelectedItems.Count > 0)
            {
                // Get the selected item's text
                string selectedItem = ListViewMods.SelectedItems[0].Text;
                string modName = selectedItem.Replace(" (Enabled)", "").Replace(" (Disabled)", "");

                // Check if the mod is enabled
                if (selectedItem.Contains("(Enabled)"))
                {
                    DisableMod(modName);
                }
                else
                {
                    MessageBox.Show("This mod is already disabled!");
                }
            }
            else
            {
                MessageBox.Show("No mod selected!");
            }
        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListViewMods.SelectedItems.Count > 0)
            {
                string selectedItem = ListViewMods.SelectedItems[0].Text;
                string modName = selectedItem.Replace(" (Disabled)", "").Replace(" (Enabled)", "");

                if (selectedItem.Contains("(Disabled)"))
                {
                    EnableMod(modName);
                }
                else
                {
                    MessageBox.Show("This mod is already enabled!");
                }
            }
            else
            {
                MessageBox.Show("No mod selected!");
            }
        }

        private void enableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ListViewPlugins.SelectedItems.Count > 0)
            {
                string selectedItem = ListViewPlugins.SelectedItems[0].Text;
                string pluginName = selectedItem.Replace(" (Disabled)", "").Replace(" (Enabled)", "");

                if (selectedItem.Contains("(Disabled)"))
                {
                    EnablePlugin(pluginName);
                }
                else
                {
                    MessageBox.Show("This plugin is already enabled!");
                }
            }
            else
            {
                MessageBox.Show("No plugin selected!");
            }
        }

        private void disableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ListViewPlugins.SelectedItems.Count > 0)
            {
                string selectedItem = ListViewPlugins.SelectedItems[0].Text;
                string pluginName = selectedItem.Replace(" (Enabled)", "").Replace(" (Disabled)", "");

                if (selectedItem.Contains("(Enabled)"))
                {
                    DisablePlugin(pluginName);
                }
                else
                {
                    MessageBox.Show("This plugin is already disabled!");
                }
            }
            else
            {
                MessageBox.Show("No plugin selected!");
            }

        }

        private void SetYuzuPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable Files (*.exe)|*.exe";
                openFileDialog.Title = "Select Yuzu Executable";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string yuzuPath = openFileDialog.FileName;

                    // Save the path for future use (e.g., in a settings file or user preferences)
                    Properties.Settings.Default.YuzuPath = yuzuPath;
                    Properties.Settings.Default.Save();

                    MessageBox.Show($"Yuzu path set to: {yuzuPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Launch_Click(object sender, EventArgs e)
        {
            string yuzuPath = Properties.Settings.Default.YuzuPath;
            string smashPath = Properties.Settings.Default.SmashISO;

            if (string.IsNullOrEmpty(yuzuPath) || !File.Exists(yuzuPath))
            {
                MessageBox.Show("Yuzu path is not set or invalid. Please set the path first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(smashPath) || !File.Exists(smashPath))
            {
                MessageBox.Show("Smash ISO path is not set or invalid. Please set the path first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var processInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = yuzuPath, // Yuzu executable path
                    Arguments = $"-f -g \"{smashPath}\"", // Fullscreen and game path
                    UseShellExecute = true // Ensure the shell is used for execution
                };

                System.Diagnostics.Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to launch Yuzu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListViewMods.SelectedItems.Count > 0)
            {
                string selectedItem = ListViewMods.SelectedItems[0].Text;
                string modName = selectedItem.Replace(" (Enabled)", "").Replace(" (Disabled)", "");

                string modPath = Path.Combine(modFolder, modName);

                if (Directory.Exists(modPath))
                {
                    // want to ask user to confirm delete
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this mod?", "Delete Mod", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Directory.Delete(modPath, true);
                        LoadMods();
                    }
                    else
                    {
                        MessageBox.Show("Mod was not deleted");
                    }
                }
                else
                {
                    MessageBox.Show("Mod not found!");
                }
            }
            else
            {
                MessageBox.Show("No mod selected!");
            }
        }

        private void deleteToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (ListViewPlugins.Items.Count > 0)
            {
                string selectedItem = ListViewPlugins.SelectedItems[0].Text;
                string pluginName = selectedItem.Replace(" (Enabled)", "").Replace(" (Disabled)", "");

                string pluginPath = Path.Combine(pluginFolder, pluginName);

                if (File.Exists(pluginPath))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this plugin?", "Delete Mod", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Delete(pluginPath);
                        LoadPlugins();
                    }
                    else
                    {
                        MessageBox.Show("Plugin was not deleted");
                    }
                }
                else
                {
                    MessageBox.Show("Plugin was not found");
                }
            }
            else
            {
                MessageBox.Show("No plugin was selected");
            }
        }

        private void TotalModCount()
        {
            TotalModsLabel.Text = "Total Mods: " + ListViewMods.Items.Count.ToString();
            TotalPluginsLabel.Text = "Total Plugins: " + ListViewPlugins.Items.Count.ToString();
        }

        private async void exportModsButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                ImportProgressBar.Visible = true;
                ImportProgressBar.Style = ProgressBarStyle.Marquee;
                
                saveFileDialog.Filter = "ZIP files (*zip)|*.zip";
                saveFileDialog.Title = "Export Mods and Plugins";
                saveFileDialog.FileName = "ModsAndPlugins.zip";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        await Task.Run(() => ExportModsAndPlugins(saveFileDialog.FileName));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                ImportProgressBar.Visible = false;




            }
        }
    }
}

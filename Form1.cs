namespace SmashModLoader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SmashModLoader", "config.json");

            // Load the game path from the config file
            if (File.Exists(filePath))
            {
                txtGamePath.Text = File.ReadAllText(filePath);
            }
        }


        // Clicking on this button will open a dialog to select the game folder
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the folder where the game is installed";
                folderDialog.ShowNewFolderButton = false;
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtGamePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        // This will save the game path to a config file and move on to the next form
        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGamePath.Text))
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SmashModLoader", "config.json");

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.WriteAllText(filePath, txtGamePath.Text);

                MessageBox.Show("Game path saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select the game folder first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // This will close the application
        private void cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

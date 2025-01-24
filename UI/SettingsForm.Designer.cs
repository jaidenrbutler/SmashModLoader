namespace SmashModLoader
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Back = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SelectYuzuFolder = new Button();
            SelectYuzuExe = new Button();
            YuzuFolderLabel = new Label();
            YuzuExeLabel = new Label();
            SaveButton = new Button();
            SmashIsoTextBox = new TextBox();
            SmashISOBrowse = new Button();
            SmashISOLabel = new Label();
            SuspendLayout();
            // 
            // Back
            // 
            Back.Location = new Point(12, 12);
            Back.Name = "Back";
            Back.Size = new Size(100, 61);
            Back.TabIndex = 1;
            Back.Text = "Back";
            Back.UseVisualStyleBackColor = true;
            Back.Click += Back_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(98, 105);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(315, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(98, 155);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(315, 23);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // SelectYuzuFolder
            // 
            SelectYuzuFolder.Location = new Point(12, 105);
            SelectYuzuFolder.Name = "SelectYuzuFolder";
            SelectYuzuFolder.Size = new Size(75, 23);
            SelectYuzuFolder.TabIndex = 4;
            SelectYuzuFolder.Text = "Browse";
            SelectYuzuFolder.UseVisualStyleBackColor = true;
            SelectYuzuFolder.Click += SelectYuzuFolder_Click;
            // 
            // SelectYuzuExe
            // 
            SelectYuzuExe.Location = new Point(12, 155);
            SelectYuzuExe.Name = "SelectYuzuExe";
            SelectYuzuExe.Size = new Size(75, 23);
            SelectYuzuExe.TabIndex = 5;
            SelectYuzuExe.Text = "Browse";
            SelectYuzuExe.UseVisualStyleBackColor = true;
            SelectYuzuExe.Click += SelectYuzuExe_Click;
            // 
            // YuzuFolderLabel
            // 
            YuzuFolderLabel.AutoSize = true;
            YuzuFolderLabel.Location = new Point(98, 87);
            YuzuFolderLabel.Name = "YuzuFolderLabel";
            YuzuFolderLabel.Size = new Size(68, 15);
            YuzuFolderLabel.TabIndex = 6;
            YuzuFolderLabel.Text = "Mod Folder";
            // 
            // YuzuExeLabel
            // 
            YuzuExeLabel.AutoSize = true;
            YuzuExeLabel.Location = new Point(98, 137);
            YuzuExeLabel.Name = "YuzuExeLabel";
            YuzuExeLabel.Size = new Size(58, 15);
            YuzuExeLabel.TabIndex = 7;
            YuzuExeLabel.Text = "Yuzu .EXE";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(118, 12);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(100, 61);
            SaveButton.TabIndex = 8;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // SmashIsoTextBox
            // 
            SmashIsoTextBox.Location = new Point(98, 204);
            SmashIsoTextBox.Name = "SmashIsoTextBox";
            SmashIsoTextBox.Size = new Size(315, 23);
            SmashIsoTextBox.TabIndex = 9;
            // 
            // SmashISOBrowse
            // 
            SmashISOBrowse.Location = new Point(12, 204);
            SmashISOBrowse.Name = "SmashISOBrowse";
            SmashISOBrowse.Size = new Size(75, 23);
            SmashISOBrowse.TabIndex = 10;
            SmashISOBrowse.Text = "Browse";
            SmashISOBrowse.UseVisualStyleBackColor = true;
            SmashISOBrowse.Click += SmashISOBrowse_Click;
            // 
            // SmashISOLabel
            // 
            SmashISOLabel.AutoSize = true;
            SmashISOLabel.Location = new Point(98, 186);
            SmashISOLabel.Name = "SmashISOLabel";
            SmashISOLabel.Size = new Size(66, 15);
            SmashISOLabel.TabIndex = 11;
            SmashISOLabel.Text = "Smash .ISO";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 285);
            Controls.Add(SmashISOLabel);
            Controls.Add(SmashISOBrowse);
            Controls.Add(SmashIsoTextBox);
            Controls.Add(SaveButton);
            Controls.Add(YuzuExeLabel);
            Controls.Add(YuzuFolderLabel);
            Controls.Add(SelectYuzuExe);
            Controls.Add(SelectYuzuFolder);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(Back);
            Name = "SettingsForm";
            Text = "SettingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Back;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button SelectYuzuFolder;
        private Button SelectYuzuExe;
        private Label YuzuFolderLabel;
        private Label YuzuExeLabel;
        private Button SaveButton;
        private TextBox SmashIsoTextBox;
        private Button SmashISOBrowse;
        private Label SmashISOLabel;
    }
}
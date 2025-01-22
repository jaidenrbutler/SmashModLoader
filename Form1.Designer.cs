namespace SmashModLoader
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
            folderBrowserDialog1 = new FolderBrowserDialog();
            txtGamePath = new TextBox();
            btnBrowse = new Button();
            nextBtn = new Button();
            cancel = new Button();
            SuspendLayout();
            // 
            // txtGamePath
            // 
            txtGamePath.Location = new Point(36, 50);
            txtGamePath.Name = "txtGamePath";
            txtGamePath.ReadOnly = true;
            txtGamePath.Size = new Size(322, 23);
            txtGamePath.TabIndex = 2;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(364, 50);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(83, 23);
            btnBrowse.TabIndex = 3;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // nextBtn
            // 
            nextBtn.Location = new Point(36, 99);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(75, 23);
            nextBtn.TabIndex = 5;
            nextBtn.Text = "Next";
            nextBtn.UseVisualStyleBackColor = true;
            nextBtn.Click += nextBtn_Click;
            // 
            // cancel
            // 
            cancel.Location = new Point(117, 99);
            cancel.Name = "cancel";
            cancel.Size = new Size(75, 23);
            cancel.TabIndex = 6;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 159);
            Controls.Add(cancel);
            Controls.Add(nextBtn);
            Controls.Add(btnBrowse);
            Controls.Add(txtGamePath);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox txtGamePath;
        private Button btnBrowse;
        private Button nextBtn;
        private Button cancel;
    }
}

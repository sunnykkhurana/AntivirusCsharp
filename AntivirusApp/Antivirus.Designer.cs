namespace AntivirusApp
{
    partial class Antivirus
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
            this.btn_Folder = new System.Windows.Forms.Button();
            this.btn_Scan = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_FolderPath = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_Done = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbl_cntViruses = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_searching = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Folder
            // 
            this.btn_Folder.Location = new System.Drawing.Point(21, 117);
            this.btn_Folder.Name = "btn_Folder";
            this.btn_Folder.Size = new System.Drawing.Size(191, 45);
            this.btn_Folder.TabIndex = 0;
            this.btn_Folder.Text = "Folder";
            this.btn_Folder.UseVisualStyleBackColor = true;
            this.btn_Folder.Click += new System.EventHandler(this.btn_Folder_Click);
            // 
            // btn_Scan
            // 
            this.btn_Scan.Location = new System.Drawing.Point(21, 188);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.Size = new System.Drawing.Size(191, 45);
            this.btn_Scan.TabIndex = 1;
            this.btn_Scan.Text = "Scan";
            this.btn_Scan.UseVisualStyleBackColor = true;
            this.btn_Scan.Click += new System.EventHandler(this.btn_Scan_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(255, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(620, 25);
            this.progressBar1.TabIndex = 2;
            // 
            // lbl_FolderPath
            // 
            this.lbl_FolderPath.AutoSize = true;
            this.lbl_FolderPath.Location = new System.Drawing.Point(18, 49);
            this.lbl_FolderPath.Name = "lbl_FolderPath";
            this.lbl_FolderPath.Size = new System.Drawing.Size(89, 17);
            this.lbl_FolderPath.TabIndex = 3;
            this.lbl_FolderPath.Text = "[Folder Path]";
            // 
            // btn_Done
            // 
            this.btn_Done.Location = new System.Drawing.Point(21, 394);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(191, 47);
            this.btn_Done.TabIndex = 4;
            this.btn_Done.Text = "Exit";
            this.btn_Done.UseVisualStyleBackColor = true;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(255, 69);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(620, 372);
            this.listBox1.TabIndex = 5;
            // 
            // lbl_cntViruses
            // 
            this.lbl_cntViruses.AutoSize = true;
            this.lbl_cntViruses.ForeColor = System.Drawing.Color.Red;
            this.lbl_cntViruses.Location = new System.Drawing.Point(18, 266);
            this.lbl_cntViruses.Name = "lbl_cntViruses";
            this.lbl_cntViruses.Size = new System.Drawing.Size(55, 17);
            this.lbl_cntViruses.TabIndex = 6;
            this.lbl_cntViruses.Text = "Viruses";
            this.lbl_cntViruses.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 482);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Searching:";
            this.label1.Visible = false;
            // 
            // lbl_searching
            // 
            this.lbl_searching.AutoSize = true;
            this.lbl_searching.Location = new System.Drawing.Point(100, 482);
            this.lbl_searching.Name = "lbl_searching";
            this.lbl_searching.Size = new System.Drawing.Size(80, 17);
            this.lbl_searching.TabIndex = 8;
            this.lbl_searching.Text = "[Searching]";
            this.lbl_searching.Visible = false;
            // 
            // Antivirus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 519);
            this.Controls.Add(this.lbl_searching);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_cntViruses);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_Done);
            this.Controls.Add(this.lbl_FolderPath);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_Scan);
            this.Controls.Add(this.btn_Folder);
            this.Name = "Antivirus";
            this.Text = "Antivirus";
            this.Load += new System.EventHandler(this.Antivirus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Folder;
        private System.Windows.Forms.Button btn_Scan;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_FolderPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lbl_cntViruses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_searching;
    }
}
namespace ComparePPTX
{
    partial class FormCompare
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
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Button buttonBrowseOldFile;
            System.Windows.Forms.Button buttonBrowseNewFile;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Button buttonBrowseOutputFolder;
            System.Windows.Forms.Label label3;
            this.textOldFile = new System.Windows.Forms.TextBox();
            this.textNewFile = new System.Windows.Forms.TextBox();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.backgroundComparator = new System.ComponentModel.BackgroundWorker();
            this.textOutputFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.labelProgress = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            buttonBrowseOldFile = new System.Windows.Forms.Button();
            buttonBrowseNewFile = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            buttonBrowseOutputFolder = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox1.Controls.Add(buttonBrowseOutputFolder);
            groupBox1.Controls.Add(this.textOutputFolder);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(buttonBrowseOldFile);
            groupBox1.Controls.Add(buttonBrowseNewFile);
            groupBox1.Controls.Add(this.textOldFile);
            groupBox1.Controls.Add(this.textNewFile);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(527, 129);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "비교 대상 선택";
            // 
            // buttonBrowseOldFile
            // 
            buttonBrowseOldFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonBrowseOldFile.Location = new System.Drawing.Point(439, 57);
            buttonBrowseOldFile.Name = "buttonBrowseOldFile";
            buttonBrowseOldFile.Size = new System.Drawing.Size(70, 23);
            buttonBrowseOldFile.TabIndex = 5;
            buttonBrowseOldFile.Text = "...";
            buttonBrowseOldFile.UseVisualStyleBackColor = true;
            buttonBrowseOldFile.Click += new System.EventHandler(this.buttonBrowseOldFile_Click);
            // 
            // buttonBrowseNewFile
            // 
            buttonBrowseNewFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonBrowseNewFile.Location = new System.Drawing.Point(439, 25);
            buttonBrowseNewFile.Name = "buttonBrowseNewFile";
            buttonBrowseNewFile.Size = new System.Drawing.Size(70, 23);
            buttonBrowseNewFile.TabIndex = 2;
            buttonBrowseNewFile.Text = "...";
            buttonBrowseNewFile.UseVisualStyleBackColor = true;
            buttonBrowseNewFile.Click += new System.EventHandler(this.buttonBrowseNewFile_Click);
            // 
            // textOldFile
            // 
            this.textOldFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textOldFile.Location = new System.Drawing.Point(76, 58);
            this.textOldFile.Name = "textOldFile";
            this.textOldFile.Size = new System.Drawing.Size(357, 21);
            this.textOldFile.TabIndex = 4;
            // 
            // textNewFile
            // 
            this.textNewFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textNewFile.Location = new System.Drawing.Point(76, 26);
            this.textNewFile.Name = "textNewFile";
            this.textNewFile.Size = new System.Drawing.Size(357, 21);
            this.textNewFile.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(23, 62);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(45, 12);
            label2.TabIndex = 3;
            label2.Text = "옛 파일";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 30);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(45, 12);
            label1.TabIndex = 0;
            label1.Text = "새 파일";
            // 
            // buttonCompare
            // 
            this.buttonCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCompare.Location = new System.Drawing.Point(464, 147);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(75, 23);
            this.buttonCompare.TabIndex = 1;
            this.buttonCompare.Text = "비교(&C)";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // backgroundComparator
            // 
            this.backgroundComparator.WorkerReportsProgress = true;
            this.backgroundComparator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundComparator_DoWork);
            this.backgroundComparator.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundComparator_ProgressChanged);
            this.backgroundComparator.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundComparator_RunWorkerCompleted);
            // 
            // buttonBrowseOutputFolder
            // 
            buttonBrowseOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonBrowseOutputFolder.Location = new System.Drawing.Point(439, 88);
            buttonBrowseOutputFolder.Name = "buttonBrowseOutputFolder";
            buttonBrowseOutputFolder.Size = new System.Drawing.Size(70, 23);
            buttonBrowseOutputFolder.TabIndex = 8;
            buttonBrowseOutputFolder.Text = "...";
            buttonBrowseOutputFolder.UseVisualStyleBackColor = true;
            buttonBrowseOutputFolder.Click += new System.EventHandler(this.buttonBrowseOutputFolder_Click);
            // 
            // textOutputFolder
            // 
            this.textOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textOutputFolder.Location = new System.Drawing.Point(76, 89);
            this.textOutputFolder.Name = "textOutputFolder";
            this.textOutputFolder.Size = new System.Drawing.Size(357, 21);
            this.textOutputFolder.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(11, 93);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(57, 12);
            label3.TabIndex = 6;
            label3.Text = "결과 폴더";
            // 
            // labelProgress
            // 
            this.labelProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProgress.Location = new System.Drawing.Point(415, 152);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(43, 13);
            this.labelProgress.TabIndex = 2;
            this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 181);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.buttonCompare);
            this.Controls.Add(groupBox1);
            this.Name = "FormCompare";
            this.Text = "PPTX 비교";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textOldFile;
        private System.Windows.Forms.TextBox textNewFile;
        private System.ComponentModel.BackgroundWorker backgroundComparator;
        private System.Windows.Forms.TextBox textOutputFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.Label labelProgress;
    }
}


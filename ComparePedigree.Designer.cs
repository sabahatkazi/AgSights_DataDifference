namespace AgSights
{
    partial class ComparePedigree
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
            this.lblOtherSource = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdOtherSourceFile = new System.Windows.Forms.OpenFileDialog();
            this.btnSourceFile = new System.Windows.Forms.Button();
            this.btnUploadBioTrack = new System.Windows.Forms.Button();
            this.ofdBioTrackFile = new System.Windows.Forms.OpenFileDialog();
            this.btnCompare = new System.Windows.Forms.Button();
            this.lblMessageSource = new System.Windows.Forms.Label();
            this.lblMessageBioTrack = new System.Windows.Forms.Label();
            this.dgvCompare = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.sfdOutput = new System.Windows.Forms.SaveFileDialog();
            this.btnNewExport = new System.Windows.Forms.Button();
            this.dgvNewCompare = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewCompare)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOtherSource
            // 
            this.lblOtherSource.AutoSize = true;
            this.lblOtherSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherSource.Location = new System.Drawing.Point(56, 59);
            this.lblOtherSource.Name = "lblOtherSource";
            this.lblOtherSource.Size = new System.Drawing.Size(288, 29);
            this.lblOtherSource.TabIndex = 0;
            this.lblOtherSource.Text = "Select Other Source File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select BioTrack File";
            // 
            // ofdOtherSourceFile
            // 
            this.ofdOtherSourceFile.FileName = "ofdOtherSourceFile";
            // 
            // btnSourceFile
            // 
            this.btnSourceFile.Location = new System.Drawing.Point(455, 64);
            this.btnSourceFile.Name = "btnSourceFile";
            this.btnSourceFile.Size = new System.Drawing.Size(91, 35);
            this.btnSourceFile.TabIndex = 2;
            this.btnSourceFile.Text = "Upload";
            this.btnSourceFile.UseVisualStyleBackColor = true;
            this.btnSourceFile.Click += new System.EventHandler(this.btnSourceFile_Click);
            // 
            // btnUploadBioTrack
            // 
            this.btnUploadBioTrack.Location = new System.Drawing.Point(455, 145);
            this.btnUploadBioTrack.Name = "btnUploadBioTrack";
            this.btnUploadBioTrack.Size = new System.Drawing.Size(91, 35);
            this.btnUploadBioTrack.TabIndex = 3;
            this.btnUploadBioTrack.Text = "Upload";
            this.btnUploadBioTrack.UseVisualStyleBackColor = true;
            this.btnUploadBioTrack.Click += new System.EventHandler(this.btnUploadBioTrack_Click);
            // 
            // ofdBioTrackFile
            // 
            this.ofdBioTrackFile.FileName = "ofdBioTrackFile";
            // 
            // btnCompare
            // 
            this.btnCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompare.Location = new System.Drawing.Point(61, 227);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(97, 37);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // lblMessageSource
            // 
            this.lblMessageSource.AutoSize = true;
            this.lblMessageSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageSource.Location = new System.Drawing.Point(574, 82);
            this.lblMessageSource.Name = "lblMessageSource";
            this.lblMessageSource.Size = new System.Drawing.Size(0, 20);
            this.lblMessageSource.TabIndex = 5;
            this.lblMessageSource.Visible = false;
            // 
            // lblMessageBioTrack
            // 
            this.lblMessageBioTrack.AutoSize = true;
            this.lblMessageBioTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageBioTrack.Location = new System.Drawing.Point(574, 164);
            this.lblMessageBioTrack.Name = "lblMessageBioTrack";
            this.lblMessageBioTrack.Size = new System.Drawing.Size(0, 20);
            this.lblMessageBioTrack.TabIndex = 6;
            this.lblMessageBioTrack.Visible = false;
            // 
            // dgvCompare
            // 
            this.dgvCompare.AllowUserToAddRows = false;
            this.dgvCompare.AllowUserToDeleteRows = false;
            this.dgvCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompare.Location = new System.Drawing.Point(61, 289);
            this.dgvCompare.Name = "dgvCompare";
            this.dgvCompare.ReadOnly = true;
            this.dgvCompare.RowHeadersWidth = 51;
            this.dgvCompare.RowTemplate.Height = 24;
            this.dgvCompare.Size = new System.Drawing.Size(685, 150);
            this.dgvCompare.TabIndex = 7;
            this.dgvCompare.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(204, 227);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(97, 37);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnNewExport
            // 
            this.btnNewExport.Enabled = false;
            this.btnNewExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewExport.Location = new System.Drawing.Point(61, 453);
            this.btnNewExport.Name = "btnNewExport";
            this.btnNewExport.Size = new System.Drawing.Size(172, 37);
            this.btnNewExport.TabIndex = 10;
            this.btnNewExport.Text = "New Data Export";
            this.btnNewExport.UseVisualStyleBackColor = true;
            this.btnNewExport.Click += new System.EventHandler(this.btnNewExport_Click);
            // 
            // dgvNewCompare
            // 
            this.dgvNewCompare.AllowUserToAddRows = false;
            this.dgvNewCompare.AllowUserToDeleteRows = false;
            this.dgvNewCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewCompare.Location = new System.Drawing.Point(61, 507);
            this.dgvNewCompare.Name = "dgvNewCompare";
            this.dgvNewCompare.ReadOnly = true;
            this.dgvNewCompare.RowHeadersWidth = 51;
            this.dgvNewCompare.RowTemplate.Height = 24;
            this.dgvNewCompare.Size = new System.Drawing.Size(685, 150);
            this.dgvNewCompare.TabIndex = 9;
            this.dgvNewCompare.Visible = false;
            // 
            // ComparePedigree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1352, 682);
            this.Controls.Add(this.btnNewExport);
            this.Controls.Add(this.dgvNewCompare);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvCompare);
            this.Controls.Add(this.lblMessageBioTrack);
            this.Controls.Add(this.lblMessageSource);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnUploadBioTrack);
            this.Controls.Add(this.btnSourceFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOtherSource);
            this.MinimizeBox = false;
            this.Name = "ComparePedigree";
            this.Text = "ComparePedigree";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.ComparePedigree_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewCompare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOtherSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdOtherSourceFile;
        private System.Windows.Forms.Button btnSourceFile;
        private System.Windows.Forms.Button btnUploadBioTrack;
        private System.Windows.Forms.OpenFileDialog ofdBioTrackFile;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label lblMessageSource;
        private System.Windows.Forms.Label lblMessageBioTrack;
        private System.Windows.Forms.DataGridView dgvCompare;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog sfdOutput;
        private System.Windows.Forms.Button btnNewExport;
        private System.Windows.Forms.DataGridView dgvNewCompare;
    }
}
namespace DevelopmentSimplyPut.ImagesCombiner
{
    partial class frmImagesCombiner
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
            this.btnAddCategoryImages = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnGenerateImages = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddCategoryImages
            // 
            this.btnAddCategoryImages.Location = new System.Drawing.Point(12, 9);
            this.btnAddCategoryImages.Name = "btnAddCategoryImages";
            this.btnAddCategoryImages.Size = new System.Drawing.Size(121, 23);
            this.btnAddCategoryImages.TabIndex = 0;
            this.btnAddCategoryImages.Text = "Add Category Images";
            this.btnAddCategoryImages.UseVisualStyleBackColor = true;
            this.btnAddCategoryImages.Click += new System.EventHandler(this.btnAddCategoryImages_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // btnGenerateImages
            // 
            this.btnGenerateImages.Location = new System.Drawing.Point(429, 337);
            this.btnGenerateImages.Name = "btnGenerateImages";
            this.btnGenerateImages.Size = new System.Drawing.Size(112, 23);
            this.btnGenerateImages.TabIndex = 2;
            this.btnGenerateImages.Text = "Generate Images";
            this.btnGenerateImages.UseVisualStyleBackColor = true;
            this.btnGenerateImages.Click += new System.EventHandler(this.btnGenerateImages_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 41);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(529, 280);
            this.treeView1.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(480, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(61, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmImagesCombiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 372);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnGenerateImages);
            this.Controls.Add(this.btnAddCategoryImages);
            this.Name = "frmImagesCombiner";
            this.Text = "Images Combiner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddCategoryImages;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnGenerateImages;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnClear;
    }
}


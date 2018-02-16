namespace Emage
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.BLoad = new System.Windows.Forms.Button();
            this.BConvert = new System.Windows.Forms.Button();
            this.BSave = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(456, 456);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // BLoad
            // 
            this.BLoad.Location = new System.Drawing.Point(12, 474);
            this.BLoad.Name = "BLoad";
            this.BLoad.Size = new System.Drawing.Size(225, 54);
            this.BLoad.TabIndex = 1;
            this.BLoad.Text = "Load Image";
            this.BLoad.UseVisualStyleBackColor = true;
            this.BLoad.Click += new System.EventHandler(this.BLoad_Click);
            // 
            // BConvert
            // 
            this.BConvert.Location = new System.Drawing.Point(243, 474);
            this.BConvert.Name = "BConvert";
            this.BConvert.Size = new System.Drawing.Size(225, 54);
            this.BConvert.TabIndex = 2;
            this.BConvert.Text = "Convert Image";
            this.BConvert.UseVisualStyleBackColor = true;
            this.BConvert.Click += new System.EventHandler(this.BConvert_Click);
            // 
            // BSave
            // 
            this.BSave.Location = new System.Drawing.Point(12, 534);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(456, 54);
            this.BSave.TabIndex = 3;
            this.BSave.Text = "Save";
            this.BSave.UseVisualStyleBackColor = true;
            this.BSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // openDialog
            // 
            this.openDialog.InitialDirectory = "%CD%";
            this.openDialog.RestoreDirectory = true;
            // 
            // saveDialog
            // 
            this.saveDialog.CheckFileExists = true;
            this.saveDialog.InitialDirectory = ".";
            this.saveDialog.RestoreDirectory = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 597);
            this.Controls.Add(this.BSave);
            this.Controls.Add(this.BConvert);
            this.Controls.Add(this.BLoad);
            this.Controls.Add(this.pictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Emage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button BLoad;
        private System.Windows.Forms.Button BConvert;
        private System.Windows.Forms.Button BSave;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
    }
}


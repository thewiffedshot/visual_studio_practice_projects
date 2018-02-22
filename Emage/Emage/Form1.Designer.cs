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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.BLoad = new System.Windows.Forms.Button();
            this.BConvert = new System.Windows.Forms.Button();
            this.BSave = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.smallOption = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.threadOption = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(456, 456);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // BLoad
            // 
            this.BLoad.Location = new System.Drawing.Point(12, 496);
            this.BLoad.Name = "BLoad";
            this.BLoad.Size = new System.Drawing.Size(225, 54);
            this.BLoad.TabIndex = 1;
            this.BLoad.Text = "Load Image";
            this.BLoad.UseVisualStyleBackColor = true;
            this.BLoad.Click += new System.EventHandler(this.BLoad_Click);
            // 
            // BConvert
            // 
            this.BConvert.Enabled = false;
            this.BConvert.Location = new System.Drawing.Point(243, 496);
            this.BConvert.Name = "BConvert";
            this.BConvert.Size = new System.Drawing.Size(225, 54);
            this.BConvert.TabIndex = 2;
            this.BConvert.Text = "Convert Image";
            this.BConvert.UseVisualStyleBackColor = true;
            this.BConvert.Click += new System.EventHandler(this.BConvert_Click);
            // 
            // BSave
            // 
            this.BSave.Enabled = false;
            this.BSave.Location = new System.Drawing.Point(12, 556);
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
            this.saveDialog.InitialDirectory = ".";
            this.saveDialog.RestoreDirectory = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Unispace", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 479);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Small Emojis: ";
            // 
            // smallOption
            // 
            this.smallOption.AutoSize = true;
            this.smallOption.Location = new System.Drawing.Point(109, 479);
            this.smallOption.Name = "smallOption";
            this.smallOption.Size = new System.Drawing.Size(15, 14);
            this.smallOption.TabIndex = 5;
            this.smallOption.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Unispace", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 479);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Multi-Thread:";
            // 
            // threadOption
            // 
            this.threadOption.AutoSize = true;
            this.threadOption.Location = new System.Drawing.Point(339, 479);
            this.threadOption.Name = "threadOption";
            this.threadOption.Size = new System.Drawing.Size(15, 14);
            this.threadOption.TabIndex = 7;
            this.threadOption.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(480, 617);
            this.Controls.Add(this.threadOption);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.smallOption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BSave);
            this.Controls.Add(this.BConvert);
            this.Controls.Add(this.BLoad);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Emage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button BLoad;
        private System.Windows.Forms.Button BConvert;
        private System.Windows.Forms.Button BSave;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox smallOption;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox threadOption;
    }
}


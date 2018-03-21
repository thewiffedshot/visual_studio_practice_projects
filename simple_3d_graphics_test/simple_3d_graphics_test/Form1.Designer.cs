namespace simple_3d_graphics_test
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.trackX = new System.Windows.Forms.TrackBar();
            this.trackY = new System.Windows.Forms.TrackBar();
            this.trackZ = new System.Windows.Forms.TrackBar();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackDistance = new System.Windows.Forms.TrackBar();
            this.labelDistance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelRotZ = new System.Windows.Forms.Label();
            this.labelRotY = new System.Windows.Forms.Label();
            this.labelRotX = new System.Windows.Forms.Label();
            this.trackRotZ = new System.Windows.Forms.TrackBar();
            this.trackRotY = new System.Windows.Forms.TrackBar();
            this.trackRotX = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRotZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRotX)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(41, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 618);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(600, 81);
            this.button1.TabIndex = 1;
            this.button1.Text = "Translate and Render";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackX
            // 
            this.trackX.Location = new System.Drawing.Point(647, 48);
            this.trackX.Maximum = 50;
            this.trackX.Minimum = -50;
            this.trackX.Name = "trackX";
            this.trackX.Size = new System.Drawing.Size(257, 45);
            this.trackX.TabIndex = 2;
            this.trackX.Scroll += new System.EventHandler(this.trackX_Scroll);
            // 
            // trackY
            // 
            this.trackY.Location = new System.Drawing.Point(647, 99);
            this.trackY.Maximum = 50;
            this.trackY.Minimum = -50;
            this.trackY.Name = "trackY";
            this.trackY.Size = new System.Drawing.Size(257, 45);
            this.trackY.TabIndex = 3;
            this.trackY.Scroll += new System.EventHandler(this.trackY_Scroll);
            // 
            // trackZ
            // 
            this.trackZ.Location = new System.Drawing.Point(647, 150);
            this.trackZ.Maximum = 50;
            this.trackZ.Minimum = -50;
            this.trackZ.Name = "trackZ";
            this.trackZ.Size = new System.Drawing.Size(257, 45);
            this.trackZ.TabIndex = 4;
            this.trackZ.Scroll += new System.EventHandler(this.trackZ_Scroll);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX.Location = new System.Drawing.Point(901, 48);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(21, 24);
            this.labelX.TabIndex = 5;
            this.labelX.Text = "0";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelY.Location = new System.Drawing.Point(901, 99);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(21, 24);
            this.labelY.TabIndex = 6;
            this.labelY.Text = "0";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZ.Location = new System.Drawing.Point(901, 150);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(21, 24);
            this.labelZ.TabIndex = 7;
            this.labelZ.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(902, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(902, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(902, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Z";
            // 
            // trackDistance
            // 
            this.trackDistance.Location = new System.Drawing.Point(647, 643);
            this.trackDistance.Maximum = 1000;
            this.trackDistance.Name = "trackDistance";
            this.trackDistance.Size = new System.Drawing.Size(257, 45);
            this.trackDistance.TabIndex = 11;
            this.trackDistance.Scroll += new System.EventHandler(this.trackDistance_Scroll);
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDistance.Location = new System.Drawing.Point(901, 643);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(21, 24);
            this.labelDistance.TabIndex = 12;
            this.labelDistance.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(676, 620);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Distance from view plane";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(651, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(253, 31);
            this.label5.TabIndex = 14;
            this.label5.Text = "Translation Vector";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(651, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(293, 31);
            this.label6.TabIndex = 15;
            this.label6.Text = "Rotation Vector (deg)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(902, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Z";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(902, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(902, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "X";
            // 
            // labelRotZ
            // 
            this.labelRotZ.AutoSize = true;
            this.labelRotZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRotZ.Location = new System.Drawing.Point(901, 347);
            this.labelRotZ.Name = "labelRotZ";
            this.labelRotZ.Size = new System.Drawing.Size(21, 24);
            this.labelRotZ.TabIndex = 21;
            this.labelRotZ.Text = "0";
            // 
            // labelRotY
            // 
            this.labelRotY.AutoSize = true;
            this.labelRotY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRotY.Location = new System.Drawing.Point(901, 296);
            this.labelRotY.Name = "labelRotY";
            this.labelRotY.Size = new System.Drawing.Size(21, 24);
            this.labelRotY.TabIndex = 20;
            this.labelRotY.Text = "0";
            // 
            // labelRotX
            // 
            this.labelRotX.AutoSize = true;
            this.labelRotX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRotX.Location = new System.Drawing.Point(901, 245);
            this.labelRotX.Name = "labelRotX";
            this.labelRotX.Size = new System.Drawing.Size(21, 24);
            this.labelRotX.TabIndex = 19;
            this.labelRotX.Text = "0";
            // 
            // trackRotZ
            // 
            this.trackRotZ.Location = new System.Drawing.Point(647, 347);
            this.trackRotZ.Maximum = 90;
            this.trackRotZ.Minimum = -90;
            this.trackRotZ.Name = "trackRotZ";
            this.trackRotZ.Size = new System.Drawing.Size(257, 45);
            this.trackRotZ.TabIndex = 18;
            this.trackRotZ.Scroll += new System.EventHandler(this.trackRotZ_Scroll);
            // 
            // trackRotY
            // 
            this.trackRotY.Location = new System.Drawing.Point(647, 296);
            this.trackRotY.Maximum = 90;
            this.trackRotY.Minimum = -90;
            this.trackRotY.Name = "trackRotY";
            this.trackRotY.Size = new System.Drawing.Size(257, 45);
            this.trackRotY.TabIndex = 17;
            this.trackRotY.Scroll += new System.EventHandler(this.trackRotY_Scroll);
            // 
            // trackRotX
            // 
            this.trackRotX.Location = new System.Drawing.Point(647, 245);
            this.trackRotX.Maximum = 90;
            this.trackRotX.Minimum = -90;
            this.trackRotX.Name = "trackRotX";
            this.trackRotX.Size = new System.Drawing.Size(257, 45);
            this.trackRotX.TabIndex = 16;
            this.trackRotX.Scroll += new System.EventHandler(this.trackRotX_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 700);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelRotZ);
            this.Controls.Add(this.labelRotY);
            this.Controls.Add(this.labelRotX);
            this.Controls.Add(this.trackRotZ);
            this.Controls.Add(this.trackRotY);
            this.Controls.Add(this.trackRotX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.trackDistance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.trackZ);
            this.Controls.Add(this.trackY);
            this.Controls.Add(this.trackX);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "3D Render";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRotZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRotX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackX;
        private System.Windows.Forms.TrackBar trackY;
        private System.Windows.Forms.TrackBar trackZ;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackDistance;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelRotZ;
        private System.Windows.Forms.Label labelRotY;
        private System.Windows.Forms.Label labelRotX;
        private System.Windows.Forms.TrackBar trackRotZ;
        private System.Windows.Forms.TrackBar trackRotY;
        private System.Windows.Forms.TrackBar trackRotX;
    }
}


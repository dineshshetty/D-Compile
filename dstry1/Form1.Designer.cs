namespace dstry1
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
            this.decompile_button = new System.Windows.Forms.Button();
            this.browse_button = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loading_pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loading_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // decompile_button
            // 
            this.decompile_button.Location = new System.Drawing.Point(99, 86);
            this.decompile_button.Name = "decompile_button";
            this.decompile_button.Size = new System.Drawing.Size(75, 23);
            this.decompile_button.TabIndex = 0;
            this.decompile_button.Text = "Decompile";
            this.decompile_button.UseVisualStyleBackColor = true;
            this.decompile_button.Click += new System.EventHandler(this.decompile_button_Click);
            // 
            // browse_button
            // 
            this.browse_button.Location = new System.Drawing.Point(205, 47);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(75, 23);
            this.browse_button.TabIndex = 1;
            this.browse_button.Text = "Browse";
            this.browse_button.UseVisualStyleBackColor = true;
            this.browse_button.Click += new System.EventHandler(this.browse_button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 20);
            this.textBox1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // loading_pic
            // 
            this.loading_pic.Image = global::dstry1.Properties.Resources.f1f1f1;
            this.loading_pic.Location = new System.Drawing.Point(117, 183);
            this.loading_pic.Name = "loading_pic";
            this.loading_pic.Size = new System.Drawing.Size(35, 33);
            this.loading_pic.TabIndex = 5;
            this.loading_pic.TabStop = false;
            this.loading_pic.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.loading_pic);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.browse_button);
            this.Controls.Add(this.decompile_button);
            this.Name = "Form1";
            this.Text = "D-Compile v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loading_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button decompile_button;
        private System.Windows.Forms.Button browse_button;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox loading_pic;
    }
}


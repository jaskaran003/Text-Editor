namespace SmartPadPlusPlus
{
    partial class HelpModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpModal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.help_close = new System.Windows.Forms.Button();
            this.help_text = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.help_close);
            this.panel1.Controls.Add(this.help_text);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 277);
            this.panel1.TabIndex = 0;
            // 
            // help_close
            // 
            this.help_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.help_close.Location = new System.Drawing.Point(22, 236);
            this.help_close.Name = "help_close";
            this.help_close.Size = new System.Drawing.Size(275, 23);
            this.help_close.TabIndex = 2;
            this.help_close.Text = "OK";
            this.help_close.UseVisualStyleBackColor = true;
            this.help_close.Click += new System.EventHandler(this.help_close_Click);
            // 
            // help_text
            // 
            this.help_text.AutoSize = true;
            this.help_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help_text.Location = new System.Drawing.Point(19, 51);
            this.help_text.MaximumSize = new System.Drawing.Size(300, 200);
            this.help_text.Name = "help_text";
            this.help_text.Size = new System.Drawing.Size(12, 18);
            this.help_text.TabIndex = 1;
            this.help_text.Text = ".";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(132, 14);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(54, 24);
            this.Title.TabIndex = 0;
            this.Title.Text = "Hello";
            // 
            // HelpModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 302);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HelpModal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label help_text;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button help_close;
    }
}
namespace SmartPadPlusPlus
{
    partial class UserTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserTypeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.usertype_novice = new System.Windows.Forms.RadioButton();
            this.usertype_typical = new System.Windows.Forms.RadioButton();
            this.usertype_expert = new System.Windows.Forms.RadioButton();
            this.save_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the user mode";
            // 
            // usertype_novice
            // 
            this.usertype_novice.AutoSize = true;
            this.usertype_novice.Checked = true;
            this.usertype_novice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usertype_novice.Location = new System.Drawing.Point(55, 59);
            this.usertype_novice.Name = "usertype_novice";
            this.usertype_novice.Size = new System.Drawing.Size(74, 24);
            this.usertype_novice.TabIndex = 1;
            this.usertype_novice.TabStop = true;
            this.usertype_novice.Text = "Novice";
            this.usertype_novice.UseVisualStyleBackColor = true;
            this.usertype_novice.CheckedChanged += new System.EventHandler(this.usertype_novice_CheckedChanged);
            // 
            // usertype_typical
            // 
            this.usertype_typical.AutoSize = true;
            this.usertype_typical.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usertype_typical.Location = new System.Drawing.Point(154, 59);
            this.usertype_typical.Name = "usertype_typical";
            this.usertype_typical.Size = new System.Drawing.Size(86, 24);
            this.usertype_typical.TabIndex = 2;
            this.usertype_typical.Text = "Average";
            this.usertype_typical.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.usertype_typical.UseVisualStyleBackColor = true;
            this.usertype_typical.CheckedChanged += new System.EventHandler(this.usertype_typical_CheckedChanged);
            // 
            // usertype_expert
            // 
            this.usertype_expert.AutoSize = true;
            this.usertype_expert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usertype_expert.Location = new System.Drawing.Point(263, 59);
            this.usertype_expert.Name = "usertype_expert";
            this.usertype_expert.Size = new System.Drawing.Size(73, 24);
            this.usertype_expert.TabIndex = 3;
            this.usertype_expert.Text = "Expert";
            this.usertype_expert.UseVisualStyleBackColor = true;
            this.usertype_expert.CheckedChanged += new System.EventHandler(this.usertype_expert_CheckedChanged);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(55, 106);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(281, 23);
            this.save_btn.TabIndex = 4;
            this.save_btn.Text = "OK";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // UserTypeForm
            // 
            this.AcceptButton = this.save_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 151);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.usertype_expert);
            this.Controls.Add(this.usertype_typical);
            this.Controls.Add(this.usertype_novice);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Mode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton usertype_novice;
        private System.Windows.Forms.RadioButton usertype_typical;
        private System.Windows.Forms.RadioButton usertype_expert;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
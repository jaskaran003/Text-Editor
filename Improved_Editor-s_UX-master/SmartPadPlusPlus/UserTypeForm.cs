using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartPadPlusPlus
{
    public partial class UserTypeForm : Form
    {
   
        MainForm mainForm;

        public UserTypeForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }
      
        private void save_btn_Click(object sender, EventArgs e)
        {
           this.Close();
            if(this.mainForm.userType == UserType.NOVICE)
            {
                this.mainForm.InitHelpForm();
            }
        }
       
        private void usertype_typical_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            this.mainForm.userType = UserType.AVERAGE;
        }

        private void usertype_novice_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            this.mainForm.userType = UserType.NOVICE;
        }

        private void usertype_expert_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            this.mainForm.userType = UserType.EXPERT;
        }
    }
}

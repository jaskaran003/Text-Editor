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
    public partial class HelpModal : Form
    {
        public HelpModal()
        {
            InitializeComponent();
            this.help_text.Text = "Welcome to SmartPad++ - the friendly text editor. \n\nYour recent commands will appear in the recent command drop down. Click the command again to user it. \n\nTo see all the available commands click on the keyboard icon.";
        }

        private void help_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}

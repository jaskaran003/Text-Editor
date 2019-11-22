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
    public partial class AllCommandsForm : Form
    {
        private MainForm mainForm;
        public AllCommandsForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            searchTxt.TextChanged += new EventHandler(searchBox_TextChanged);
            this.ActiveControl = searchTxt;
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            IEnumerable<String> keyMatches = mainForm.commandDict.Keys.Where(o => o.ToLower().Contains(searchTxt.Text.ToLower()));
            List<Command> matches = new List<Command>();
            foreach(String match in keyMatches)
            {
                matches.Add(mainForm.commandDict[match]);
            }
            loadCommandList(matches);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            commandList.View = View.Tile;
            commandList.TileSize = new Size(250, 80);
            commandList.LabelWrap = true;

            commandList.Columns.AddRange(new ColumnHeader[]
            {new ColumnHeader(), new ColumnHeader(), new ColumnHeader()});

            loadCommandList(mainForm.commandDict.Values);
       
        }

        private void loadCommandList(IEnumerable<Command> commands)
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(40, 40);
            imageList.Images.Clear();
            commandList.Items.Clear();
            int index = 0;
            foreach (Command command in commands) { 
                imageList.Images.Add(command.getImage());
                commandList.Items.Add(new ListViewItem(command.getListViewText(), index));
                index++;
            }
            commandList.LargeImageList = imageList;
        }

        private void commandList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (commandList.SelectedItems.Count > 0)
            {
                String command = commandList.SelectedItems[0].Text;
                if (mainForm.commandDict.ContainsKey(command))
                {
                    mainForm.commandDict[command].performAction();
                }
                this.Close();
            }
        }
    }
}

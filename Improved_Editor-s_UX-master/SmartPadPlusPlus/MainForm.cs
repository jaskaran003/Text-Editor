using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ScintillaNET;
using SmartPadPlusPlus.Utils;
using SmartPadPlusPlus.Controls;


namespace SmartPadPlusPlus
{

    public partial class MainForm : Form
    {

        // Command keys
        public readonly string OPEN = "Open"; //change

        public readonly string COPY = "Copy";
        public readonly string ZOOM_IN = "Zoom In";
        public readonly string ZOOM_OUT = "Zoom out";
        public readonly string ZOOM_100 = "Zoom 100%";
        public readonly string INDENT = "Indent";
        public readonly string OUTDENT = "Outdent";
        public readonly string SAVE = "Save";
        public readonly string REDO = "Redo";
        public readonly string UNDO = "Undo";
        public readonly string LOWERCASE = "Lowercase";
        public readonly string UPPERCASE = "Uppercase";
        public readonly string CUT = "Cut";
        public readonly string PASTE = "Paste";
        public readonly string NEW_FILE = "New File";

        // Save user type when changed
        // We will modify interface
        private UserType _userType;
        public UserType userType
        {
            get
            {
                return _userType;
            }
            set
            {
                _userType = value;
                UserTypeChanged(value);
            }
        }

        // Used throughout application
        // to match command key with icons, command,
        // and description
        public Dictionary<String, Command> commandDict = new Dictionary<string, Command>();

        private UserTypeForm userTypeForm;

        private void UserTypeChanged(UserType _userType)
        {
            Console.WriteLine(_userType);
            if (_userType == UserType.NOVICE)
            {
                averageToolStrip.Visible = false;
                expertToolStrip.Visible = false;
            }
            if (_userType == UserType.AVERAGE)
            {
                averageToolStrip.Visible = true;
                expertToolStrip.Visible = false;
            }
            else if (_userType == UserType.EXPERT)
            {
                averageToolStrip.Visible = true;
                expertToolStrip.Visible = true;
            }
        }

        private void changeFileTitle()
        {
            String baseName = "SmartPad++";
            if (currentFileName == null)
            {
                this.Text = baseName + " - untitled";
            }
            else
            {
                this.Text = baseName + " - " + currentFileName;
                if (TextArea.Modified)
                {
                    this.Text += "*";
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        // Our Scintilla component
        ScintillaNET.Scintilla TextArea;

        private String currentFileName;

        private void MainForm_Load(object sender, EventArgs e)
        {

            InitToolStrips();

            InitUserTypeForm();

            // Setup command dictionary - used for All Commands and Recent Commands
            InitCommands();

            // CREATE CONTROL
            TextArea = new ScintillaNET.Scintilla();
            TextPanel.Controls.Add(TextArea);

            // BASIC CONFIG
            TextArea.Dock = System.Windows.Forms.DockStyle.Fill;
            TextArea.TextChanged += (this.OnTextChanged);

            TextArea.ScrollWidth = 1;
            TextArea.ScrollWidthTracking = true; // the default

            // INITIAL VIEW CONFIG
            TextArea.WrapMode = WrapMode.None;
            TextArea.IndentationGuides = IndentView.LookBoth;
            TextArea.Document = Document.Empty;


            // STYLING
            InitColors();

            // INIT HOTKEYS
            InitHotkeys();

            changeFileTitle();

            this.ActiveControl = TextArea;

        }

        private void InitUserTypeForm()
        {
            userTypeForm = new UserTypeForm(this);
            userTypeForm.ShowDialog();
        }

        public void InitHelpForm()
        {
            userTypeForm.Hide();
            HelpModal hm = new HelpModal();

            hm.ShowDialog();
        }
        private void InitAllCommandsForm()
        {
            AllCommandsForm acf = new AllCommandsForm(this);
            acf.ShowDialog();
        }

        // Setup novice, average and expert tool strips
        private void InitToolStrips()
        {
            averageToolStrip.Visible = false;
            expertToolStrip.Visible = false;
        }

        public void userTypeSelected()
        {

        }

        private void InitCommands()
        {
            commandDict.Add(COPY, new Command(
                COPY,
                "Copy selected text to the clipboard",
                "Ctrl + c",
                new Bitmap(Image.FromFile("../../Images/copy.png")),
                () => this.copyCommand()
             ));
            commandDict.Add(CUT, new Command(
                CUT,
                "Move the selected text to the clipboard",
                "Ctrl + x",
                new Bitmap(Image.FromFile("../../Images/cut.png")),
                () => this.cutCommand()
            ));
            commandDict.Add(PASTE, new Command(
                PASTE,
                "Place text from the clipboard into the editor",
                "Ctrl + v",
                new Bitmap(Image.FromFile("../../Images/paste.png")),
                () => this.pasteCommand()
            ));
            commandDict.Add(INDENT, new Command(
                INDENT,
                "Move text toward right side",
                "Tab",
                new Bitmap(Image.FromFile("../../Images/Indent.png")),
                () => this.Indent()
            ));
            commandDict.Add(OUTDENT, new Command(
               OUTDENT,
               "Move text toward left side",
               "Shift + Tab",
               new Bitmap(Image.FromFile("../../Images/Outdent.png")),
               () => this.Outdent()
           ));
            commandDict.Add(ZOOM_IN, new Command(
               ZOOM_IN,
               "Magnify the text",
               "Ctrl+Plus",
               new Bitmap(Image.FromFile("../../Images/Zoomin.png")),
               () => this.ZoomIn()
           ));
            commandDict.Add(ZOOM_OUT, new Command(
             ZOOM_OUT,
             "Reduse the size of text",
             "Ctrl+Minus",
             new Bitmap(Image.FromFile("../../Images/Zoomout.png")),
             () => this.ZoomOut()
         ));
            commandDict.Add(REDO, new Command(
             REDO,
             "Repeat your last action",
             "Ctrl+Y",
             new Bitmap(Image.FromFile("../../Images/Redo.png")),
             () => this.Redo1()
         ));
            commandDict.Add(UNDO, new Command(
             UNDO,
             "To reverse your last action",
             "Ctrl+Z",
             new Bitmap(Image.FromFile("../../Images/Undo.png")),
             () => this.Undo1()
         ));
            commandDict.Add(SAVE, new Command(
               SAVE,
               "Save the file",
               "Ctrl+S",
               new Bitmap(Image.FromFile("../../Images/save.png")),
               () => this.saveCommand()
           ));
            commandDict.Add(NEW_FILE, new Command(
             NEW_FILE,
             "Create new file",
             "Ctrl+N",
             new Bitmap(Image.FromFile("../../Images/Newfile.png")),
             () => this.newFileCommand()
         ));
            commandDict.Add(LOWERCASE, new Command(
            LOWERCASE,
            "Convert text to lowercase",
            "Ctrl+L",
            new Bitmap(Image.FromFile("../../Images/low.png")),
            () => this.Lowercase()
        ));
            commandDict.Add(UPPERCASE, new Command(
            UPPERCASE,
            "Convert text to Uppercase",
            "Ctrl+U",
            new Bitmap(Image.FromFile("../../Images/up.png")),
            () => this.Uppercase()
        ));
            commandDict.Add(ZOOM_100, new Command(
            ZOOM_100,
            " Come back to orignal text size",
            "Ctrl+0",
            new Bitmap(Image.FromFile("../../Images/Zoom100.png")),
            () => this.ZoomDefault()
        ));

            //Shortcut for Open File
            commandDict.Add(OPEN, new Command(
            OPEN,
            "Open new file",
            "Ctrl+P",
                 new Bitmap(Image.FromFile("../../Images/folder-open-o.png")),
                 () => this.openBtn_Click(openBtn, new EventArgs())
              ));


        }

        private void InitColors()
        {
            TextArea.SetSelectionBackColor(true, Color.Gray);
            TextArea.StyleResetDefault();
            TextArea.Styles[Style.Default].Font = "Consolas";
            TextArea.Styles[Style.Default].Size = 12;
            TextArea.Styles[Style.Default].ForeColor = Color.Red;
        }


        private void my_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 32)
            {
                // Prevent control characters from getting inserted into the text buffer
                e.Handled = true;
                return;
            }
        }



        //Shortcut for Open File
        private void openBtn_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.P)
            {
                openBtn_Click(openBtn, e);
            }

            if (e.KeyCode == Keys.F1)
            {
                InitHelpForm();
            }


        }




        private void InitHotkeys()
        {

            // register the hotkeys with the form
            HotKeyManager.AddHotKey(this, Uppercase, Keys.U, true);
            HotKeyManager.AddHotKey(this, Lowercase, Keys.L, true);
            HotKeyManager.AddHotKey(this, ZoomIn, Keys.Oemplus, true);
            HotKeyManager.AddHotKey(this, ZoomOut, Keys.OemMinus, true);
            HotKeyManager.AddHotKey(this, ZoomDefault, Keys.O, true);
            HotKeyManager.AddHotKey(this, newFileCommand, Keys.N, true);
            HotKeyManager.AddHotKey(this, saveCommand, Keys.S, true);
            //HotKeyManager.AddHotKey(this, InitHelpForm, Keys.F1, true);
            HotKeyManager.AddHotKey(this, Undo1, Keys.Z, true);
            HotKeyManager.AddHotKey(this, Redo1, Keys.Y, true);

            HotKeyManager.AddHotKey(this, copyCommand, Keys.C, true);
            HotKeyManager.AddHotKey(this, cutCommand, Keys.X, true);
            HotKeyManager.AddHotKey(this, pasteCommand, Keys.V, true);


            // remove conflicting hotkeys from scintilla
            TextArea.ClearCmdKey(Keys.Control | Keys.F);
            TextArea.ClearCmdKey(Keys.Control | Keys.R);
            TextArea.ClearCmdKey(Keys.Control | Keys.H);
            TextArea.ClearCmdKey(Keys.Control | Keys.L);
            TextArea.ClearCmdKey(Keys.Control | Keys.U);
            TextArea.ClearCmdKey(Keys.Control | Keys.N);
            TextArea.ClearCmdKey(Keys.Control | Keys.S);
            TextArea.ClearCmdKey(Keys.Control | Keys.F1);

            TextArea.ClearCmdKey(Keys.Control | Keys.C);
            TextArea.ClearCmdKey(Keys.Control | Keys.X);
            TextArea.ClearCmdKey(Keys.Control | Keys.V);


            TextArea.ClearCmdKey(Keys.Control | Keys.Z);
            TextArea.ClearCmdKey(Keys.Control | Keys.Y);
            TextArea.ClearCmdKey(Keys.Control | Keys.O);

            //for open file
            TextArea.ClearCmdKey(Keys.Control | Keys.P);
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            changeFileTitle();
        }


        private void LoadDataFromFile(string path)
        {
            if (File.Exists(path))
            {
                currentFileName = path;
                TextArea.Text = File.ReadAllText(path);
                TextArea.SetSavePoint();
                changeFileTitle();
            }
        }

        #region Main Menu Commands



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadDataFromFile(openFileDialog.FileName);
            }
        }


        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutCommand();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyCommand();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteCommand();
        }


        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.SelectAll();
        }

        private void selectLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Line line = TextArea.Lines[TextArea.CurrentLine];
            TextArea.SetSelection(line.Position + line.Length, line.Position);
        }

        private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.SetEmptySelection(0);
        }

        private void indentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Indent();
        }

        private void outdentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Outdent();
        }

        private void uppercaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uppercase();
        }

        private void lowercaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lowercase();
        }

        private void wordWrapToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            // toggle word wrap
            wordWrapItem.Checked = !wordWrapItem.Checked;
            TextArea.WrapMode = wordWrapItem.Checked ? WrapMode.Word : WrapMode.None;
        }

        private void indentGuidesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // toggle indent guides
            indentGuidesItem.Checked = !indentGuidesItem.Checked;
            TextArea.IndentationGuides = indentGuidesItem.Checked ? IndentView.LookBoth : IndentView.None;
        }

        private void hiddenCharactersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // toggle view whitespace
            hiddenCharactersItem.Checked = !hiddenCharactersItem.Checked;
            TextArea.ViewWhitespace = hiddenCharactersItem.Checked ? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible;
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void zoom100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomDefault();
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.FoldAll(FoldAction.Contract);
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextArea.FoldAll(FoldAction.Expand);
        }


        #endregion

        #region Uppercase / Lowercase

        private void Lowercase()
        {

            // save the selection
            int start = TextArea.SelectionStart;
            int end = TextArea.SelectionEnd;

            // modify the selected text
            TextArea.ReplaceSelection(TextArea.GetTextRange(start, end - start).ToLower());

            // preserve the original selection
            TextArea.SetSelection(start, end);
            addRecentCommand(LOWERCASE);
        }

        private void Uppercase()
        {

            // save the selection
            int start = TextArea.SelectionStart;
            int end = TextArea.SelectionEnd;

            // modify the selected text
            TextArea.ReplaceSelection(TextArea.GetTextRange(start, end - start).ToUpper());

            // preserve the original selection
            TextArea.SetSelection(start, end);
            addRecentCommand(UPPERCASE);
        }

        #endregion

        #region Indent / Outdent

        private void Indent()
        {
            // we use this hack to send "Shift+Tab" to scintilla, since there is no known API to indent,
            // although the indentation function exists. Pressing TAB with the editor focused confirms this.
            GenerateKeystrokes("{TAB}");
            addRecentCommand(INDENT);
        }

        private void Outdent()
        {
            // we use this hack to send "Shift+Tab" to scintilla, since there is no known API to outdent,
            // although the indentation function exists. Pressing Shift+Tab with the editor focused confirms this.
            GenerateKeystrokes("+{TAB}");
            addRecentCommand(OUTDENT);
        }

        private void GenerateKeystrokes(string keys)
        {
            HotKeyManager.Enable = false;
            TextArea.Focus();
            SendKeys.Send(keys);
            HotKeyManager.Enable = true;
        }

        #endregion

        #region Zoom

        private void ZoomIn()
        {
            TextArea.ZoomIn();
            addRecentCommand(ZOOM_IN);
        }

        private void ZoomOut()
        {
            TextArea.ZoomOut();
            addRecentCommand(ZOOM_OUT);

        }

        private void ZoomDefault()
        {
            TextArea.Zoom = 0;
            addRecentCommand(ZOOM_100);
        }


        #endregion


        #region Utils

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        public void InvokeIfNeeded(Action action)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }




        #endregion



        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveCommand();

        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadDataFromFile(openFileDialog.FileName);
            }

            addRecentCommand(OPEN);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveCommand();

        }

        /**
         * CUT, COPY, PASTE
         */
        private void copyBtn_Click(object sender, EventArgs e)
        {
            copyCommand();

        }

        #region COMMANDS

        // when user clicks command add it to the list of recent commands
        private void addRecentCommand(String command)
        {
            List<ImageComboItem> existingItems = new List<ImageComboItem>();
            foreach (ImageComboItem item in recentCmdImgCombo.Items)
            {
                existingItems.Add(item);
            }

            recentCmdImgCombo.ImageList.Images.Clear();
            recentCmdImgCombo.Items.Clear();

            // Add initial command to top of list
            recentCmdImgCombo.ImageList.Images.Add(commandDict[command].getImage());
            recentCmdImgCombo.Items.Add(new ImageComboItem(
                commandDict[command].getImageComboText(),
                recentCmdImgCombo.ImageList.Images.Count - 1,
                command));

            foreach (ImageComboItem item in existingItems)
            {
                string commandText = item.ItemText;
                string commandKey = commandText.Substring(0, item.ItemText.IndexOf("-")).Trim();
                Console.WriteLine(commandText, commandKey);
                if (recentCmdImgCombo.FindStringExact(commandText) == -1)
                {
                    recentCmdImgCombo.ImageList.Images.Add(commandDict[commandKey].getImage());
                    recentCmdImgCombo.Items.Add(new ImageComboItem(commandDict[commandKey].getImageComboText(),
                        recentCmdImgCombo.ImageList.Images.Count - 1,
                        commandKey));
                }
            }

            //Focus comes back to TextArea
            TextArea.Focus();
        }

        public void Redo1()
        {
            TextArea.Redo();
            addRecentCommand(REDO);


        }
        public void Undo1()
        {
            TextArea.Undo();
            addRecentCommand(UNDO);


        }
        public void cutCommand()
        {
            TextArea.Cut();
            addRecentCommand(CUT);

            //Focus comes back to TextArea
            TextArea.Focus();
        }

        public void copyCommand()
        {
            TextArea.Copy();
            addRecentCommand(COPY);

            //Focus comes back to TextArea
            TextArea.Focus();
        }

        public void pasteCommand()
        {
            TextArea.Paste();
            addRecentCommand(PASTE);

            //Focus comes back to TextArea
            TextArea.Focus();
        }

        public void newFileCommand()
        {
            if (TextArea.Modified == true)
            {
                var confirmResult = MessageBox.Show("The document has unsaved changes. Do you want to save the changes?",
                                                      "Unsaved Changes",
                                                      MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    saveCommand();
                }
            }
            else
            {
                TextArea.Document = Document.Empty;
                currentFileName = null;
                changeFileTitle();
            }
            addRecentCommand(NEW_FILE);

            //Focus comes back to TextArea
            TextArea.Focus();
        }

        //Suppress Control Characters
        private void ctlScintilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 32)
            {
                // Prevent control characters from getting inserted into the text buffer
                e.Handled = true;
                return;
            }
        }


        //test code

        private void saveCommand()
        {
            if (currentFileName == null)
            {
                // Displays a SaveFileDialog so the user can save the Image  
                // assigned to Button2.  
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Save File";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.  
                if (saveFileDialog1.FileName != "")
                {
                    currentFileName = saveFileDialog1.FileName;
                    // Saves the Image via a FileStream created by the OpenFile method.  


                    File.WriteAllText(saveFileDialog1.FileName, TextArea.Text);

                }
            }
            else
            {
                File.WriteAllText(currentFileName, TextArea.Text);

            }
            TextArea.SetSavePoint();
            changeFileTitle();
            addRecentCommand(SAVE);


            //Focus comes back to TextArea
            TextArea.Focus();
        }


        #endregion

        private void pasteBtn_Click(object sender, EventArgs e)
        {
            pasteCommand();
        }

        private void newFile_Click(object sender, EventArgs e)
        {
            newFileCommand();
        }

        private void cutBtn_Click(object sender, EventArgs e)
        {
            cutCommand();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitHelpForm();
        }

        private void allCommandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllCommandsForm acf = new AllCommandsForm(this);
            acf.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFileCommand();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void indentBtn_Click(object sender, EventArgs e)
        {
            Indent();
        }

        private void btnOutdent_Click(object sender, EventArgs e)
        {
            Outdent();
        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            Undo1();

        }

        private void redoBtn_Click(object sender, EventArgs e)
        {
            Redo1();
        }

        private void zoomInBtn_Click(object sender, EventArgs e)
        {
            ZoomIn();

        }

        private void zoomOutBtn_Click(object sender, EventArgs e)
        {
            ZoomOut();

        }

        private void noviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userType = UserType.NOVICE;
        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userType = UserType.AVERAGE;
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userType = UserType.EXPERT;
        }

        private void allCommandBtn_Click(object sender, EventArgs e)
        {
            AllCommandsForm acf = new AllCommandsForm(this);
            acf.ShowDialog();
        }

        private void recentCmdImgCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            String command = ((ImageComboItem)recentCmdImgCombo.SelectedItem).CommandKey;
            commandDict[command].performAction();
            recentCmdImgCombo.SelectedIndex = -1;
            recentCmdImgCombo.Text = "";
            this.ActiveControl = TextArea;
        }



    }
}
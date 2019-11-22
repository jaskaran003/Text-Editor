using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SmartPadPlusPlus
{
    public class Command
    {
        String name;
        String description;
        String shortcut;
        Bitmap image;
        private readonly Action action;

        public Command(String name, String description, String shortcut, Bitmap image, System.Action action)
        {
            this.name = name;
            this.image = image;
            this.description = description;
            this.shortcut = shortcut;
            this.action = action;
        }

        public string[] getListViewText()
        {
            return new string[] { name, description, shortcut };
        }

        public String getImageComboText()
        {
            return name + " - shortcut: " + shortcut;
        }

        public Bitmap getImage()
        {
            return this.image;
        }

        public void performAction()
        {
            action();
        }
    }
}

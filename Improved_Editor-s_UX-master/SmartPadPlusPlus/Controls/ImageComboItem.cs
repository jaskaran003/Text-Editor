﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SmartPadPlusPlus.Controls
{
    class ImageComboItem : object
    {
        private Color clrForeColor = Color.FromKnownColor(KnownColor.Transparent);

        private bool blnIndicate = false;

        private int intIndex = -1;

        private object objTag = null;
        private string strText = null;
        private String commandKey = null;

        public ImageComboItem()
        {
        }

        public ImageComboItem(string Text)
        {
            strText = Text;
        }

        public ImageComboItem(string stText, int intImageIndex)
        {
            strText = stText;
            intIndex = intImageIndex;

        }

        public ImageComboItem(string stText, int intImageIndex, String commandKey)
        {
            strText = stText;
            intIndex = intImageIndex;
            this.commandKey = commandKey;
        }

        public ImageComboItem(string stText, int intImageIndex, bool blnIndi)
        {

            strText = stText;

            intIndex = intImageIndex;

            blnIndicate = blnIndi;

        }

        public ImageComboItem(string stText, int intImageIndex, bool blnIndi, Color clForeColor)

        {
            strText = stText;
            intIndex = intImageIndex;
            blnIndicate = blnIndi;
            clrForeColor = clForeColor;
        }

        public ImageComboItem(string stText, int intImageIndex, bool blnIndi, Color clForeColor, object oTag)
        {
            strText = stText;
            intIndex = intImageIndex;
            blnIndicate = blnIndi;
            clrForeColor = clForeColor;
            objTag = oTag;
        }

        public Color ForeColor
        {
            get
            {
                return clrForeColor;
            }

            set
            {
                clrForeColor = value;
            }
        }

        public int ImageIndex
        {
            get
            {
                return intIndex;
            }

            set
            {
                intIndex = value;
            }
        }

        public bool Indicate
        {
            get
            {
                return blnIndicate;
            }

            set
            {
                blnIndicate = value;
            }
        }

        public object Tag
        {
            get
            {
                return objTag;
            }

            set
            {
                objTag = value;
            }
        }

        public string ItemText
        {
            get
            {
                return strText;
            }

            set
            {
                strText = value;
            }
        }

        public String CommandKey
        {
            get
            {
                return commandKey;
            }

            set
            {
                commandKey = value;
            }
        }

        public override string ToString()
        {
            return strText;
        }
    }

}

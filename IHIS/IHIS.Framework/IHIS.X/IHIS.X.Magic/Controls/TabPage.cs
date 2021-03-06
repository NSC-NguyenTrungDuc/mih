// *****************************************************************************
// 
//  (c) Crownwood Consulting Limited 2002 
//  All rights reserved. The software and associated documentation 
//  supplied hereunder are the proprietary information of Crownwood Consulting 
//	Limited, Haxey, North Lincolnshire, England and are supplied subject to 
//	licence terms.
// 
//  Magic Version 1.7.4 	www.dotnetmagic.com
// *****************************************************************************

using System;
using System.IO;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using IHIS.X.Magic.Win32;
using IHIS.X.Magic.Menus;
using IHIS.X.Magic.Common;
using IHIS.X.Magic.Collections;

namespace IHIS.X.Magic.Controls
{
    [ToolboxItem(false)]
    [DefaultProperty("Title")]
    [DefaultEvent("PropertyChanged")]
    public class TabPage : Panel
    {
        // Enumeration of property change events
        public enum Property
        {
            Title,
            Control,
            ImageIndex,
            ImageList,
            Icon,
            Selected,
			TitleTextColor
        }

        // Declare the property change event signature
        public delegate void PropChangeHandler(TabPage page, Property prop, object oldValue);

        // Public events
        public event PropChangeHandler PropertyChanged;

        // Instance fields
        protected string _title;
        protected Control _control;
        protected int _imageIndex;
        protected ImageList _imageList;
        protected Icon _icon;
        protected bool _selected;
		protected Control _startFocus;
		protected bool _shown;
		//2006.01.13 Title의 TextColor 반영
		protected Color titleTextColor = Control.DefaultForeColor;
		const int ALPAH_VALUE = 170;
		protected Color inactiveTitleTextColor = Color.FromArgb(ALPAH_VALUE, Control.DefaultForeColor);

        public TabPage()
        {
            InternalConstruct("Page", null, null, -1, null);
        }

        public TabPage(string title)
        {
            InternalConstruct(title, null, null, -1, null);
        }

        public TabPage(string title, Control control)
        {
            InternalConstruct(title, control, null, -1, null);
        }
			
        public TabPage(string title, Control control, int imageIndex)
        {
            InternalConstruct(title, control, null, imageIndex, null);
        }

        public TabPage(string title, Control control, ImageList imageList, int imageIndex)
        {
            InternalConstruct(title, control, imageList, imageIndex, null);
        }

        public TabPage(string title, Control control, Icon icon)
        {
            InternalConstruct(title, control, null, -1, icon);
        }

        protected void InternalConstruct(string title, 
                                         Control control, 
                                         ImageList imageList, 
                                         int imageIndex,
                                         Icon icon)
        {
			SetStyle(ControlStyles.AllPaintingInWmPaint|ControlStyles.UserPaint|ControlStyles.DoubleBuffer, true);

            // Assign parameters to internal fields
            _title = title;
            _control = control;
            _imageIndex = imageIndex;
            _imageList = imageList;
            _icon = icon;

            // Appropriate defaults
            _selected = false;
			_startFocus = null;
        }

        [DefaultValue("Page")]
        [Localizable(true)]
		[Category("추가속성")]
        public string Title
        {
            get { return _title; }
		   
            set 
            { 
                if (_title != value)
                {
                    string oldValue = _title;
                    _title = value; 

                    OnPropertyChanged(Property.Title, oldValue);
                }
            }
        }

        [DefaultValue(null)]
		[Category("추가속성")]
        public Control Control
        {
            get { return _control; }

            set 
            { 
                if (_control != value)
                {
                    Control oldValue = _control;
                    _control = value; 

                    OnPropertyChanged(Property.Control, oldValue);
                }
            }
        }

        [DefaultValue(-1)]
		[Category("추가속성")]
        public int ImageIndex
        {
            get { return _imageIndex; }
		
            set 
            { 
                if (_imageIndex != value)
                {
                    int oldValue = _imageIndex;
                    _imageIndex = value; 

                    OnPropertyChanged(Property.ImageIndex, oldValue);
                }
            }
        }

        [DefaultValue(null)]
		[Category("추가속성")]
        public ImageList ImageList
        {
            get { return _imageList; }
		
            set 
            { 
                if (_imageList != value)
                {
                    ImageList oldValue = _imageList;
                    _imageList = value; 

                    OnPropertyChanged(Property.ImageList, oldValue);
                }
            }
        }

        [DefaultValue(null)]
		[Category("추가속성")]
        public Icon Icon
        {
            get { return _icon; }
		
            set 
            { 
                if (_icon != value)
                {
                    Icon oldValue = _icon;
                    _icon = value; 

                    OnPropertyChanged(Property.Icon, oldValue);
                }
            }
        }

        [DefaultValue(true)]
		[Category("추가속성")]
        public bool Selected
        {
            get { return _selected; }

            set
            {
                if (_selected != value)
                {
                    bool oldValue = _selected;
                    _selected = value;

                    OnPropertyChanged(Property.Selected, oldValue);
                }
            }
        }
		[Category("추가속성")]
		public Color TitleTextColor
		{
			get { return titleTextColor;}
			set 
			{
				if (titleTextColor != value)
				{
					Color oldColor = titleTextColor;
					titleTextColor = value;
					inactiveTitleTextColor = Color.FromArgb(ALPAH_VALUE, value);
					OnPropertyChanged(Property.TitleTextColor, oldColor);
				}
			}
		}
		private bool ShouldSerializeTitleTextColor()
		{
			return titleTextColor != Control.DefaultForeColor;
		}
		private void ResetTitleTextColor()
		{
			TitleTextColor = Control.DefaultForeColor;
		}
		internal Color InactiveTitleTextColor
		{
			get { return this.inactiveTitleTextColor;}
		}

        [DefaultValue(null)]
		[Category("추가속성")]
        public Control StartFocus
        {
            get { return _startFocus; }
            set { _startFocus = value; }
        }

        public virtual void OnPropertyChanged(Property prop, object oldValue)
        {
            // Any attached event handlers?
            if (PropertyChanged != null)
                PropertyChanged(this, prop, oldValue);
        }
        
        internal bool Shown
        {
            get { return _shown; }
            set { _shown = value; }
        }
    }
}

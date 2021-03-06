// *****************************************************************************
// 
//  (c) Crownwood Consulting Limited 2002 
//  All rights reserved. The software and associated documentation 
//  supplied hereunder are the proprietary information of Crownwood Consulting 
//	Limited, Haxey, North Lincolnshire, England and are supplied subject to 
//	licence terms.
// 
//  Magic Version 1.6.1 	www.dotnetmagic.com
// *****************************************************************************

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.ComponentModel;
using IHIS.X.Magic.Collections;

namespace IHIS.X.Magic.Menus
{
    // Declare event signature
    public delegate void CommandHandler(MenuCommand item);

    // Should animation be shown?
    public enum Animate
    {
        No,
        Yes,
        System
    }
    
    // How should animation be displayed?
    public enum Animation
    {
        System                  = 0x00100000,
        Blend                   = 0x00080000,
        SlideCenter             = 0x00040010,
        SlideHorVerPositive     = 0x00040005,
        SlideHorVerNegative     = 0x0004000A,
        SlideHorPosVerNegative  = 0x00040009,
        SlideHorNegVerPositive  = 0x00040006
    }

	// How show glyph fading be calculated?
	public enum GlyphFading
	{
		None,
		Default,       
		Grayscale, 
		DecreaseColorDepth, 
		Enlighten 
	}


	[ToolboxItem(false)]
    [DefaultProperty("Text")]
    [DefaultEvent("Click")]
    public class MenuCommand : Component
    {
        // Enumeration of property change events
        public enum Property
        {
            Text,
            Enabled,
			Image,
            Shortcut,
            Checked,
            RadioCheck,
            Break,
            Infrequent,
            Visible,
            Description
        }

        // Declare the property change event signature
        public delegate void PropChangeHandler(MenuCommand item, Property prop);

        // Instance fields
        protected bool _visible;
        protected bool _break;
        protected string _text;
        protected string _description;
        protected bool _enabled;
        protected bool _checked;
        protected bool _infrequent;
        protected object _tag;
        protected bool _radioCheck;
        protected Shortcut _shortcut;
		protected Image _image;
		protected MenuCommandCollection _menuItems;

        // Exposed events
        public event EventHandler Click;
        public event EventHandler Update;
        public event CommandHandler PopupStart;
        public event CommandHandler PopupEnd;
        public event PropChangeHandler PropertyChanged;

        public MenuCommand()
        {
            InternalConstruct("MenuItem", null, Shortcut.None, null);
        }

        public MenuCommand(string text)
        {
            InternalConstruct(text, null, Shortcut.None, null);
        }

        public MenuCommand(string text, EventHandler clickHandler)
        {
            InternalConstruct(text, null, Shortcut.None, clickHandler);
        }

        public MenuCommand(string text, Shortcut shortcut)
        {
            InternalConstruct(text, null, shortcut, null);
        }

        public MenuCommand(string text, Shortcut shortcut, EventHandler clickHandler)
        {
            InternalConstruct(text, null, shortcut, clickHandler);
        }

        public MenuCommand(string text, Image image)
        {
            InternalConstruct(text, image, Shortcut.None, null);
        }

        public MenuCommand(string text, Image image, Shortcut shortcut)
        {
            InternalConstruct(text, image, shortcut, null);
        }

        public MenuCommand(string text, Image image, EventHandler clickHandler)
        {
            InternalConstruct(text, image, Shortcut.None, clickHandler);
        }

        public MenuCommand(string text, 
                           Image image, 
                           Shortcut shortcut, 
                           EventHandler clickHandler)
        {
            InternalConstruct(text, image, shortcut, clickHandler);
        }

        protected void InternalConstruct(string text, 
                                         Image image, 
                                         Shortcut shortcut, 
                                         EventHandler clickHandler)
        {
            // Save parameters
            _text = text;
			_image = image;
			_shortcut = shortcut;
            _description = text;

            if (clickHandler != null)
                Click += clickHandler;
		
            // Define defaults for others
            _enabled = true;
            _checked = false;
            _radioCheck = false;
            _break = false;
            _tag = null;
            _visible = true;
            _infrequent = false;

            // Create the collection of embedded menu commands
            _menuItems = new MenuCommandCollection();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MenuCommandCollection MenuCommands
        {
            get { return _menuItems; }
        }

        [DefaultValue("MenuItem")]
        [Localizable(true)]
        public string Text
        {
            get { return _text; }
			
            set 
            { 
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged(Property.Text);
                } 
            }
        }

        [DefaultValue(true)]
        public bool Enabled
        {
            get { return _enabled; }

            set 
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnPropertyChanged(Property.Enabled);
                }
            }
        }

		[DefaultValue(null)]
		public Image Image
		{
			get { return _image; }

			set 
			{ 
				if (_image != value)
				{
					_image = value;
					OnPropertyChanged(Property.Image);
				}
			}
		}

        [DefaultValue(typeof(Shortcut), "None")]
        public Shortcut Shortcut
        {
            get { return _shortcut; }

            set 
            { 
                if (_shortcut != value)
                {
                    _shortcut = value;
                    OnPropertyChanged(Property.Shortcut);
                }
            }
        }

        [DefaultValue(false)]
        public bool Checked
        {
            get { return _checked; }

            set 
            { 
                if (_checked != value)
                {
                    _checked = value;
                    OnPropertyChanged(Property.Checked);
                }
            }
        }

        [DefaultValue(false)]
        public bool RadioCheck
        {
            get { return _radioCheck; }

            set 
            { 
                if (_radioCheck != value)
                {
                    _radioCheck = value;
                    OnPropertyChanged(Property.RadioCheck);
                }
            }
        }

        [DefaultValue(false)]
        public bool Break
        {
            get { return _break; }
			
            set 
            { 
                if (_break != value)
                {
                    _break = value;
                    OnPropertyChanged(Property.Break);
                }
            }
        }

        [DefaultValue(false)]
        public bool Infrequent
        {
            get { return _infrequent; }
			
            set 
            {	
                if (_infrequent != value)
                {
                    _infrequent = value;
                    OnPropertyChanged(Property.Infrequent);
                }
            }
        }

        [DefaultValue(true)]
        public bool Visible
        {
            get { return _visible; }

            set 
            { 
                if (_visible != value)
                {
                    _visible = value;
                    OnPropertyChanged(Property.Visible);
                }
            }
        }

        [Browsable(false)]
        public bool IsParent
        {
            get { return (_menuItems.Count > 0); }
        }

        [DefaultValue("")]
        [Localizable(true)]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [DefaultValue(null)]
        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        public virtual void OnPropertyChanged(Property prop)
        {
            // Any attached event handlers?
            if (PropertyChanged != null)
                PropertyChanged(this, prop);
        }

        public void PerformClick()
        {
            // Update command with correct state
            OnUpdate(EventArgs.Empty);
            
            // Notify event handlers of click event
            OnClick(EventArgs.Empty);
        }
  
        public virtual void OnClick(EventArgs e)
        {
            // Any attached event handlers?
            if (Click != null)
                Click(this, e);
        }

        public virtual void OnUpdate(EventArgs e)
        {
            // Any attached event handlers?
            if (Update != null)
                Update(this, e);
        }

        public virtual void OnPopupStart()
        {
            // Any attached event handlers?
            if (PopupStart != null)
                PopupStart(this);
        }
            
        public virtual void OnPopupEnd()
        {
            // Any attached event handlers?
            if (PopupEnd != null)
                PopupEnd(this);
        }
    }
}
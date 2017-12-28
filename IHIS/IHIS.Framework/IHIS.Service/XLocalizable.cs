using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace IHIS.Framework
{
    enum Languages
    {
        Japanese,
        Korean,
        Vietnamese,
        English
    }

    public class XLocalizable
    {
        private static readonly Font DefaultFont = new Font("MS UI Gothic", 9.75f);
        private static readonly Font UnicodeFont = new Font(FontFamily.GenericSansSerif, 8.25f);
        private static Languages _defaultLanguages = Languages.Vietnamese;
        private static CultureInfo _defaultCultureInfo = new CultureInfo("ja-JP");
       // private bool _initialized = false;

       public static void SetFont(Control control)
       {
            foreach (Control c in control.Controls)
            {
                c.Font = XLocalizable.Font;
                SetFont(c);
            }
        }

        public static Font Font
        {
            get
            {
                if (_defaultLanguages == Languages.Vietnamese ||
                    _defaultLanguages == Languages.Japanese)
                {
                    return UnicodeFont;
                }
                return DefaultFont;
            }
        }

        static XLocalizable()
        {
            string languageConfig = Service.GetConfigString("LANG", "MODE", "Jr");
            switch (languageConfig)
            {
                case "Jr":
                    _defaultLanguages = Languages.Japanese;
                    _defaultCultureInfo = new CultureInfo("ja-JP");
                    break;
                case "Ko":
                     _defaultLanguages = Languages.Korean;
                     _defaultCultureInfo = new CultureInfo("ko-KR");
                    break;
                case "Vi":
                    _defaultLanguages = Languages.Vietnamese;
                    _defaultCultureInfo = new CultureInfo("vi-VN");
                    break;
                case "En":
                    _defaultLanguages = Languages.English;
                    _defaultCultureInfo = new CultureInfo("en-US");
                    break;
                default:
                    throw new NotSupportedException("Not supported language '" + languageConfig + "'.");
            }
        }

        public static CultureInfo CultureInfo
        {
            get
            {
                return _defaultCultureInfo;
            }
        }

    }
}
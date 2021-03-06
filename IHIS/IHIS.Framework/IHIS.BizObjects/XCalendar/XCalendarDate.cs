using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing; 

namespace IHIS.Framework
{
	/// <summary>
	/// XCalendarDate에 대한 요약 설명입니다.
	/// </summary>
	[Serializable,
	ToolboxItem(false),
	DesignTimeVisible(false)]
	public class XCalendarDate : System.ComponentModel.Component
	{
		#region Private class members
		private XCalendar calendar = null;
		private DateTime date;
		private XColor backColor = XColor.XCalendarDateBackColor;
		private XColor dateTextColor = XColor.XCalendarDateTextColor;
		private XColor conentTextColor = XColor.XCalendarContentTextColor;
        private XColor conentTextColorMultiLine = XColor.XCalendarContentTextColor;
		private Font  dateFont = new Font("MS UI Gothic", 9.75f, FontStyle.Bold);
		private Font  contentFont = new Font("MS UI Gothic", 9.75f);
		private ContentAlignment dateAlign = ContentAlignment.TopRight;
		private ContentAlignment contentAlign = ContentAlignment.BottomLeft;
		private ContentAlignment imageAlign = ContentAlignment.TopLeft;
		private string contentText = "";
		private int imageIndex = -1;
		private bool enabled  = true;
        private bool contentMultiline = false;
		private object tag = null;   //다른 자료를 보관하는 Tag
		#endregion

		#region properties
		[Browsable(false)]
		internal XCalendar Calendar
		{
			get { return calendar;}
			set { calendar = value;}
		}
		[Description("해당 날짜를 지정합니다.")]	
		[Category("추가속성")]
		public DateTime Date
		{
			get { return date;}
			set { date = value;}
		}
		[Category("추가속성")]
		[Description("해당 날의 Enable 속성을 지정합니다.")]
		[DefaultValue(true)]
		public bool Enabled
		{
			get { return enabled;}
			set { enabled = value;}
		}

		[Category("추가속성"),
		DefaultValue(typeof(XColor),"XCalendarDateBackColor"),
		Description("Date의 배경색을 지정합니다.")]	
		public XColor BackColor
		{
			get { return backColor;}
			set { backColor = value;}
		}
		
		[Category("추가속성"),
		DefaultValue(typeof(XColor),"XCalendarDateTextColor"),
		Description("Date의 날짜의 텍스트색을 지정합니다.")]	
		public XColor DateTextColor
		{
			get { return dateTextColor; }
			set { dateTextColor = value;}
		}

		[Category("추가속성"),
		DefaultValue(typeof(XColor),"XCalendarContentTextColor"),
		Description("Date의 내용 Text의 텍스트색을 지정합니다.")]	
		public XColor ContentTextColor
		{
			get { return conentTextColor; }
			set { conentTextColor = value;}
		}

        [Category("추가속성"),
        DefaultValue(typeof(XColor), "XCalendarContentMultiLineTextColor"),
        Description("Date의 내용 Text의 텍스트색을 지정합니다.")]
        public XColor ContentTextColorMultiLine
        {
            get { return conentTextColorMultiLine; }
            set { conentTextColorMultiLine = value; }
        }

		[Category("추가속성"),
		DefaultValue(""),
		Description("해당 날짜의 내용 Text를 지정합니다.")]	
		public string ContentText
		{
			get { return contentText;}
			set { contentText = value;}
		}
		
		[Category("추가속성"),
		DefaultValue(-1),
		Description("해당 날짜의 ImageIndex를 지정합니다.")]
		[Editor(typeof(IHIS.Framework.XCalendarImageMapEditor),typeof(System.Drawing.Design.UITypeEditor))]
		[TypeConverter(typeof(XCalendarImageTypeConverter))]
		public int ImageIndex
		{
			get { return imageIndex;}
			set { imageIndex = value;}
		}
		[Category("추가속성"),
		DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt, style=Bold"),
		Description("해당 날짜의 날짜 Font를 지정합니다.")]	
		public Font DateFont
		{
			get { return dateFont;}
			set { dateFont = value;}
		}
		[Category("추가속성"),
		DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt"),
		Description("해당 날짜의 Content Font를 지정합니다.")]	
		public Font ContentFont
		{
			get { return contentFont;}
			set { contentFont = value;}
		}
		[Category("추가속성"),
		DefaultValue(ContentAlignment.TopRight),
		Description("해당날짜의 날짜Text의 Align을 지정합니다.")]	
		public ContentAlignment DateAlign
		{
			get { return dateAlign;}
			set { dateAlign = value;}
		}
		[Category("추가속성"),
		DefaultValue(ContentAlignment.BottomLeft),
		Description("해당날짜의 Content Text의 Align을 지정합니다.")]	
		public ContentAlignment ContentAlign
		{
			get { return contentAlign;}
			set { contentAlign = value;}
		}
		[Category("추가속성"),
		DefaultValue(ContentAlignment.TopLeft),
		Description("해당날짜의 Image Align을 지정합니다.")]	
		public ContentAlignment ImageAlign
		{
			get { return imageAlign;}
			set { imageAlign = value;}
		}
		[Category("추가속성"),
		DefaultValue(null),
		Description("해당날짜의 추가적인 정보를 저장하는 Tag를 지정합니다.")]	
		public object Tag
		{
			get { return tag;}
			set { tag = value;}
		}
		#endregion
		
		#region Constructor
		public XCalendarDate()
		{
            // MED-14286
            this.SetFont();
		}
		public XCalendarDate(DateTime date)
		{
			this.date = date;

            // MED-14286
            this.SetFont();
		}
        public bool ContentMultiLine
        {
            get { return contentMultiline; }
            set { contentMultiline = value; }
        }
		#endregion

		#region GetImageList (XCalendarImageMapEditor에서 Call)
		internal ImageList GetImageList()
		{
			if (calendar!=null)
				return calendar.ImageList;
			else
				return null;
		}

        private void SetFont()
        {
            // MED-14286
            if (NetInfo.Language != LangMode.Jr)
            {
                this.dateFont = Service.COMMON_FONT_BOLD;
                this.contentFont = Service.COMMON_FONT;
            }
        }

		#endregion
	
		
	}
}

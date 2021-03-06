using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace IHIS.Framework
{
	#region Enum XDefinedColor
	/// <summary>
	/// Platform에 정의된 Color를 나타내는 Enum입니다.
	/// </summary>
	public enum XDefinedColor
	{
		/// <summary>
		/// XForm의 배경색
		/// </summary>
		XFormBackColor,
		/// <summary>
		/// XScreen의 배경색
		/// </summary>
		XScreenBackColor,
		/// <summary>
		/// XUserControl의 배경색
		/// </summary>
		XUserControlBackColor,
		/// <summary>
		/// 에러 메세지의 텍스트색
		/// </summary>
		ErrMsgForeColor,
		//Control 공통
		/// <summary>
		/// 컨트롤 기본 텍스트색
		/// </summary>
		NormalForeColor,
		/// <summary>
		/// 컨트롤 수정상태 텍스트색
		/// </summary>
		UpdatedForeColor,
		/// <summary>
		/// 컨트롤 새로입력상태 텍스트색
		/// </summary>
		InsertedForeColor,
		/// <summary>
		/// 컨트롤 3D로 그릴때 텍스트색
		/// </summary>
		ShadowForeColor,
		/// <summary>
		/// 컨트롤 비활성시 텍스트색
		/// </summary>
		DisabledForeColor,
		/// <summary>
		/// 컨트롤 기본 테두리색
		/// </summary>
		NormalBorderColor,
		/// <summary>
		/// 컨트롤 활성시 테두리색
		/// </summary>
		ActiveBorderColor,
		//Control 별
		/// <summary>
		/// XCheckBox 배경색
		/// </summary>
		XCheckBoxBackColor,
		/// <summary>
		/// XComboBox 배경색
		/// </summary>
		XComboBoxBackColor,
		/// <summary>
		/// XTextBox 배경색
		/// </summary>
		XTextBoxBackColor,
		/// <summary>
		/// XTextBox Focus시 배경색
		/// </summary>
		XTextBoxFocusBackColor,
		/// <summary>
		/// XGroupBox 배경색
		/// </summary>
		XGroupBoxBackColor,
		/// <summary>
		/// XGroupBox 텍스트색
		/// </summary>
		XGroupBoxForeColor,
		/// <summary>
		/// XLabel 배경색
		/// </summary>
		XLabelBackColor,
		/// <summary>
		/// XLabel 텍스트색
		/// </summary>
		XLabelForeColor,
		/// <summary>
		/// XLabel Gradient시작색
		/// </summary>
		XLabelGradientStartColor,
		/// <summary>
		/// XLabel Gradient종료색
		/// </summary>
		XLabelGradientEndColor,
		/// <summary>
		/// XLabel 테두리색
		/// </summary>
		XLabelBorderColor,
		/// <summary>
		/// XDisplayBox 배경색
		/// </summary>
		XDisplayBoxBackColor,
		/// <summary>
		/// XDisplayBox 텍스트색
		/// </summary>
		XDisplayBoxForeColor,
		/// <summary>
		/// XDisplayBox Gradient시작색
		/// </summary>
		XDisplayBoxGradientStartColor,
		/// <summary>
		/// XDisplayBox Gradient종료색
		/// </summary>
		XDisplayBoxGradientEndColor,
		/// <summary>
		/// XDisplayBox 테두리색
		/// </summary>
		XDisplayBoxBorderColor,
		/// <summary>
		/// XPanel 배경색
		/// </summary>
		XPanelBackColor,
		/// <summary>
		/// XPanel Border Color
		/// </summary>
		XPanelBorderColor,
		/// <summary>
		/// XNumericUpDown 배경색
		/// </summary>
		XNumericUpDownBackColor,
		/// <summary>
		/// XDomainUpDown 배경색
		/// </summary>
		XDomainUpDownBackColor,
		/// <summary>
		/// XTrackBar 배경색
		/// </summary>
		XTrackBarBackColor,
		/// <summary>
		/// FindBox의 Find영역의 배경색
		/// </summary>
		XFindBoxFindBackColor,
		/// <summary>
		/// XListView 배경색
		/// </summary>
		XListViewBackColor,
		/// <summary>
		/// XListView 헤더 배경색
		/// </summary>
		XListViewHeaderBackColor,
		/// <summary>
		/// XListView 헤더 텍스트색
		/// </summary>
		XListViewHeaderForeColor,
		/// <summary>
		/// XListBox 배경색
		/// </summary>
		XListBoxBackColor,
		/// <summary>
		/// XListBox Item 배경색
		/// </summary>
		XListBoxItemBackColor,
		/// <summary>
		/// XListBox 교대로 반복되는 Item 배경색
		/// </summary>
		XListBoxAlternatingItemBackColor,
		/// <summary>
		/// XListBox Item 테두리색
		/// </summary>
		XListBoxItemBorderColor,
		/// <summary>
		/// XCheckedListBox 배경색
		/// </summary>
		XCheckedListBoxBackColor,
		/// <summary>
		/// PictureBox 배경색
		/// </summary>
		XPictureBoxBackColor,
		/// <summary>
		/// RadioButton 배경색
		/// </summary>
		XRadioButtonBackColor,
		/// <summary>
		/// RichXTextBox 배경색
		/// </summary>
		XRichTextBoxBackColor,
		/// <summary>
		/// TreeView 배경색
		/// </summary>
		XTreeViewBackColor,
		/// <summary>
		/// TabControl 배경색
		/// </summary>
		XTabControlBackColor,
		//XMonthCalendar 
		/// <summary>
		/// XMonthCalendar 배경색
		/// </summary>
		XMonthCalendarBackColor,
		/// <summary>
		/// XMonthCalendar Title 배경색
		/// </summary>
		XMonthCalendarTitleBackColor,
		/// <summary>
		/// XMonthCalendar Title 전경색
		/// </summary>
		XMonthCalendarTitleForeColor,
		/// <summary>
		/// XMonthCalendar Trailing Text 색
		/// </summary>
		XMonthCalendarTrailingForeColor,
		//XDataGrid
		/// <summary>
		/// XDataGrid 배경색
		/// </summary>
		XDataGridBackgroundColor,
		/// <summary>
		/// XDataGrid 라인색
		/// </summary>
		XDataGridLineColor,
		/// <summary>
		/// XDataGrid Caption 배경색
		/// </summary>
		XDataGridCaptionBackColor,
		/// <summary>
		/// XDataGrid Caption 텍스트색
		/// </summary>
		XDataGridCaptionForeColor,
		/// <summary>
		/// XDataGrid Row의 배경색
		/// </summary>
		XDataGridBackColor,
		/// <summary>
		/// XDataGrid Row의 텍스트색
		/// </summary>
		XDataGridForeColor,
		/// <summary>
		/// XDataGrid 교대로반복되는 Row의 배경색
		/// </summary>
		XDataGridAlternatingBackColor,
		/// <summary>
		/// XDataGrid 선택된 Row의 배경색
		/// </summary>
		XDataGridSelectionBackColor,
		/// <summary>
		/// XDataGrid 선택된 Row의 텍스트색
		/// </summary>
		XDataGridSelectionForeColor,
		/// <summary>
		/// XDataGrid Header의 텍스트색
		/// </summary>
		XDataGridHeaderForeColor,
		/// <summary>
		/// XDataGrid Header 배경색
		/// </summary>
		XDataGridHeaderBackColor,
		/// <summary>
		/// XDataGrid Link 배경색
		/// </summary>
		XDataGridLinkColor,
		/// <summary>
		/// XDataGrid ParentRow 배경색
		/// </summary>
		XDataGridParentRowsBackColor,
		/// <summary>
		/// XDataGrid ParentRow 텍스트색
		/// </summary>
		XDataGridParentRowsForeColor,
		//XGrid
		/// <summary>
		/// XGrid 테두리색
		/// </summary>
		XGridBorderColor,
		/// <summary>
		/// XGrid 배경색
		/// </summary>
		XGridBackColor,
		/// <summary>
		/// XGrid ColHeader 배경색
		/// </summary>
		XGridColHeaderBackColor,
		/// <summary>
		/// XGrid ColHeader Gradient시작색
		/// </summary>
		XGridColHeaderGradientStartColor,
		/// <summary>
		/// XGrid ColHeader Gradient종료색
		/// </summary>
		XGridColHeaderGradientEndColor,
		/// <summary>
		/// XGrid ColHeader 텍스트색
		/// </summary>
		XGridColHeaderForeColor,
		/// <summary>
		/// XGrid RowHeader 배경색
		/// </summary>
		XGridRowHeaderBackColor,
		/// <summary>
		/// XGrid RowHeader 텍스트색
		/// </summary>
		XGridRowHeaderForeColor,
		/// <summary>
		/// XGrid Row의 배경색
		/// </summary>
		XGridRowBackColor,
		/// <summary>
		/// XGrid 교대로 반복되는 Row의 배경색
		/// </summary>
		XGridAlterateRowBackColor,
		/// <summary>
		/// XGrid 선택된 Cell의 배경색
		/// </summary>
		XGridSelectedCellBackColor,
		/// <summary>
		/// XGrid 선택된 Cell의 텍스트색
		/// </summary>
		XGridSelectedCellForeColor,
		/// <summary>
		/// XGrid Cell 기본 테두리색
		/// </summary>
		XGridNormalCellBorderColor,
		/// <summary>
		/// XGrid Cell Focus시 테두리색
		/// </summary>
		XGridFocusCellBorderColor,
		/// <summary>
		/// XGrid의 Computed컬럼의 배경색
		/// </summary>
		XGridComputedCellBackColor,
		/// <summary>
		/// XGrid의 GroupBandCell의 배경색
		/// </summary>
		XGridGroupBandCellBackColor,
		/// <summary>
		/// XGrid의 FooterCell 배경색
		/// </summary>
		XGridFooterCellBackColor,
		/// <summary>
		/// XButtonList 배경색
		/// </summary>
		XButtonListBackColor,
		/// <summary>
		/// XCalendar 배경색
		/// </summary>
		XCalendarBackColor,
		/// <summary>
		/// XCalendar 테두리색
		/// </summary>
		XCalendarBorderColor,
		/// <summary>
		/// XCalendar Header 배경색
		/// </summary>
		XCalendarHeaderBackColor,
		/// <summary>
		/// XCalendar Heade 텍스트색
		/// </summary>
		XCalendarHeaderTextColor,
		/// <summary>
		/// XCalendar Footer 배경색
		/// </summary>
		XCalendarFooterBackColor,
		/// <summary>
		/// XCalendar Footer 텍스트색
		/// </summary>
		XCalendarFooterTextColor,
		/// <summary>
		/// XCalendar Weekday 배경색
		/// </summary>
		XCalendarWeekDayBackColor,
		/// <summary>
		/// XCalendar Weekday 텍스트색
		/// </summary>
		XCalendarWeekDayTextColor,
		/// <summary>
		/// XCalendar Month 배경색
		/// </summary>
		XCalendarMonthBackColor,
		/// <summary>
		/// XCalendar Date 배경색
		/// </summary>
		XCalendarDateBackColor,
		/// <summary>
		/// XCalendar Month Border 색
		/// </summary>
		XCalendarDateBorderColor,
		/// <summary>
		/// XCalendar Month 선택시 배경색
		/// </summary>
		XCalendarSelectedDateBackColor,
		/// <summary>
		/// XCalendar Month 선택시 테투리색
		/// </summary>
		XCalendarSelectedDateBorderColor,
		/// <summary>
		/// XCalendar Date 텍스트색
		/// </summary>
		XCalendarDateTextColor,
		/// <summary>
		/// XCalendar Date의 내용 텍스트색
		/// </summary>
		XCalendarContentTextColor,
		/// <summary>
		/// XCalendar Disable 날짜 배경색
		/// </summary>
		XCalendarDisabledDateBackColor,
		/// <summary>
		/// XCalendar Disable 날짜 텍스트색
		/// </summary>
		XCalendarDisabledDateTextColor,
		/// <summary>
		/// XCalendar 따라오는 날짜(이전달,다음달) 날짜 배경색
		/// </summary>
		XCalendarTrailingDateBackColor,
		/// <summary>
		/// XCalendar 따라오는 날짜(이전달,다음달) 날짜 텍스트색
		/// </summary>
		XCalendarTrailingDateTextColor,
		/// <summary>
		/// XCalendar 토요일 날짜 배경색
		/// </summary>
		XCalendarHalfHolidayBackColor,
		/// <summary>
		/// XCalendar 토요일 날짜 텍스트색
		/// </summary>
		XCalendarHalfHolidayTextColor,
		/// <summary>
		/// XCalendar 일요일 날짜 배경색
		/// </summary>
		XCalendarFullHolidayBackColor,
		/// <summary>
		/// XCalendar 일요일 날짜 텍스트색
		/// </summary>
		XCalendarFullHolidayTextColor,
		/// <summary>
		/// XProgressBar의 배경색
		/// </summary>
		XProgressBarBackColor,
		/// <summary>
		/// XProgressBar의 Text 색
		/// </summary>
		XProgressBarTextColor,
		/// <summary>
		/// XProgressBar의 Bar의 테두리부분색
		/// </summary>
		XProgressBarGradientStartColor,
		/// <summary>
		/// XProgressBar의 Bar의 Center색
		/// </summary>
		XProgressBarGradientEndColor,
		/// <summary>
		/// XMatrix 배경색
		/// </summary>
		XMatrixBackColor,
		/// <summary>
		/// XMatrix ColHeader 색
		/// </summary>
		XMatrixColHeaderBackColor,
		/// <summary>
		/// XMatrix RowHeader 색
		/// </summary>
		XMatrixRowHeaderBackColor,
		/// <summary>
		/// XMatrix Line 색
		/// </summary>
		XMatrixLineColor,
		/// <summary>
		/// XMatrix Item 배경 색
		/// </summary>
		XMatrixItemBackColor,
		/// <summary>
		/// XToolTip 창의 배경색
		/// </summary>
		XToolTipBackColor,
		/// <summary>
		/// XToolTip 창의 Text 색
		/// </summary>
		XToolTipTextColor,
		/// <summary>
		/// XCTrackBar Bar Clolor
		/// </summary>
		XCTrackBarColor,
		/// <summary>
		/// XCTrackBar Border Clolor
		/// </summary>
		XCTrackBarBorderColor,
		/// <summary>
		/// XCTrackBar Tracker Back Clolor
		/// </summary>
		XCTrackBarTrackerColor,
		/// <summary>
		/// XCTrackBar Tracker Border Clolor
		/// </summary>
		XCTrackBarTrackerBorderColor,
		/// <summary>
		/// XRoundPanel 배경색
		/// </summary>
		XRoundPanelBackColor,
		/// <summary>
		/// XRoundPanel Gradient Start Color
		/// </summary>
		XRoundPanelGradientStartColor,
		/// <summary>
		/// XRoundPanel Gradient End Color
		/// </summary>
		XRoundPanelGradientEndColor,
		/// <summary>
		/// XRoundPanel Border Color
		/// </summary>
		XRoundPanelBorderColor,
		/// <summary>
		/// Menu GradientStart Color
		/// </summary>
		MenuGradientStartColor,
		/// <summary>
		/// Menu GradientEnd Color
		/// </summary>
		MenuGradientEndColor,
		/// <summary>
		/// Docking Gradient Start Color
		/// </summary>
		DockingGradientStartColor,
		/// <summary>
		/// Docking Gradient End Color
		/// </summary>
		DockingGradientEndColor,
		/// <summary>
		/// XRotator Border Color
		/// </summary>
		XRotatorBorderColor,
		XRotatorBackColor,
		XRotatorGradientStartColor,
		XRotatorGradientEndColor,
		XRotatorTitleTextColor,
		XRotatorHeaderTextColor,
		XRotatorHeaderBackColor,
		XRotatorHeaderGradientStartColor,
		XRotatorHeaderGradientEndColor,
		XRotatorBodyTextColor,
		XRotatorBodyBackColor,
		XRotatorBodyGradientStartColor,
		XRotatorBodyGradientEndColor
	}
	#endregion

	/// <summary>
	/// XColor에 대한 요약설명입니다.
	/// </summary>
	[TypeConverter(typeof(XColorTypeConverter)),
	Category("Color"),
	MergableProperty(true),
	Editor(typeof(XColorEditor), typeof(UITypeEditor))]
	public class XColor
	{
		#region Instance Members
		private Color	color = Color.Empty;
		private bool	isXColor = false;
		private string	colorName = string.Empty;
		/// <summary>
		/// Color를 가져옵니다.
		/// </summary>
		public Color Color
		{
			get { return color;}
		}
		/// <summary>
		/// Platform에서 정의한 Color인지 여부를 가져옵니다.
		/// </summary>
		public bool IsXColor
		{
			get { return isXColor;}
		}
		/// <summary>
		/// Color의 이름을 가져옵니다.
		/// </summary>
		public string ColorName
		{
			get 
			{ 
				if (isXColor)
					return colorName;
				else
					return color.Name;
			}
		}
		/// <summary>
		/// XColor 생성자
		/// </summary>
		/// <param name="color"> Color 개체 </param>
		public XColor(Color color)
		{
			this.color = color;
			this.isXColor = false;
		}
		internal XColor(Color color, bool isXColor, string colorName)
		{
			this.color = color;
			this.isXColor = isXColor;
			this.colorName = colorName;
		}
		/// <summary>
		/// XColor를 표현하는 문자열(Color명)을 가져옵니다.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (isXColor)
				return colorName;
			else if (color.IsKnownColor)  //Web, System Color
				return color.Name;
			else  //User Defined Color
				return color.R.ToString() + ", " + color.G.ToString() + ", " + color.B.ToString();
		}
		#endregion

		#region Static 공용 Properties 및 Methos
		private static bool colorStyleRef = false;
		private static XColor[] XColorArray;
		private static Color[] colorArray;
		//주의:::ColorArray에는 XDefinedColor의 Enum순서대로 색깔을 지정해야함
		private static Color[] defaultColorArray = new Color[] 
										{
											Color.FromArgb(255, 231, 243, 235),         //XFormBackColor
											Color.FromArgb(255, 231, 243, 235),         //XScreenBackColor
											Color.FromArgb(255, 231, 243, 235),         //XUserControlBackColor
											Color.FromArgb(255, 255,  32,  32),         //ErrMsgForeColor
											Color.FromArgb(255,   0,   0,   0),	        //NormalForeColor
											Color.FromArgb(255,   0, 128,   0),		    //UpdatedForeColor
											Color.FromArgb(255,   0,   0, 255),		    //InsertedForeColor
											Color.FromArgb(255, 255, 255, 255),		    //ShadowForeColor
											Color.FromArgb(255, 128, 128, 128),	    	//DisabledForeColor
											Color.FromArgb(255, 128, 128, 128),		    //NormalBorderColor
											Color.FromArgb(255,  48,  96, 197),			//ActiveBorderColor
											Color.FromArgb(255, 231, 243, 235),			//XCheckBoxBackColor
											Color.FromArgb(255, 255, 255, 255),			//XComboBoxBackColor
											Color.FromArgb(255, 255, 255, 255),			//XTextBoxBackColor
											Color.FromArgb(255, 247, 249, 251),		    //XTextBoxFocusBackColor
											Color.FromArgb(255, 231, 243, 235),	        //XGroupBoxBackColor	
											Color.FromArgb(255, 233, 149, 123),			//XGroupBoxForeColor
											Color.FromArgb(255, 231, 243, 235),			//XLabelBackColor
											Color.FromArgb(255,   0,   0,   0),			//XLabelForeColor
											Color.FromArgb(255, 255, 255, 255),			//XLabelGradientStartColor
											Color.FromArgb(255, 231, 243, 235),			//XLabelGradientEndColor
											Color.FromArgb(255, 139, 158, 199),			//XLabelBorderColor
											Color.FromArgb(255, 237, 237, 253),			//XDisplayBoxBackColor
											Color.FromArgb(255,   0,   0,   0),			//XDisplayBoxForeColor
											Color.FromArgb(255, 254, 254, 244),			//XDisplayBoxGradientStartColor
											Color.FromArgb(255, 216, 222, 236),			//XDisplayBoxGradientEndColor
											Color.FromArgb(255, 139, 158, 199),			//XDisplayBoxBorderColor
											Color.FromArgb(255, 231, 243, 235),			//XPanelBackColor
											Color.FromArgb(255, 167, 190, 191),			//XPanelBorderColor
											Color.FromArgb(255, 255, 255, 255),			//XNumericUpDownBackColor
											Color.FromArgb(255, 255, 255, 255),			//XDomainUpDownBackColor
											Color.FromArgb(255, 231, 243, 235),			//XTrackBarBackColor
											Color.FromArgb(255, 255, 255, 255),			//XFindBoxFindBackColor
											Color.FromArgb(255, 247, 249, 251),			//XListViewBackColor
											Color.FromArgb(255, 245, 245, 221),			//XListViewHeaderBackColor
											Color.FromArgb(255,   0,   0,   0),			//XListViewHeaderForeColor
											Color.FromArgb(255, 247, 249, 251),			//XListBoxBackColor
											Color.FromArgb(255, 255, 255, 255),			//XListBoxItemBackColor
											Color.FromArgb(255, 245, 245, 245),			//XListBoxAlternatingItemBackColor
											Color.FromArgb(255, 176, 196, 222),			//XListBoxItemBorderColor
											Color.FromArgb(255, 231, 243, 235),			//XCheckedListBoxBackColor
											Color.FromArgb(255, 247, 249, 251),			//XPictureBoxBackColor
											Color.FromArgb(255, 231, 243, 235),			//XRadioButtonBackColor
											Color.FromArgb(255, 255, 255, 255),			//XRichTextBoxBackColor
											Color.FromArgb(255, 247, 249, 251),			//XTreeViewBackColor
											Color.FromArgb(255, 227, 235, 249),			//XTabControlBackColor
											Color.FromArgb(255, 247, 249, 251),			//XMonthCalendarBackColor
											Color.FromArgb(255,  94, 137, 176),			//XMonthCalendarTitleBackColor
											Color.FromArgb(255, 255, 255, 255),			//XMonthCalendarTitleForeColor
											Color.FromArgb(255, 172, 168, 153),			//XMonthCalendarTrailingForeColor
											Color.FromArgb(255, 247, 249, 251),	    	//XDataGridBackgroundColor
											Color.FromArgb(255, 178, 178, 178),			//XDataGridLineColor
											Color.FromArgb(255,  94, 158, 160),			//XDataGridCaptionBackColor
											Color.FromArgb(255,   0,   0,   0),		    //XDataGridCaptionForeColor
											Color.FromArgb(255, 255, 255, 255),		    //XDataGridBackColor
											Color.FromArgb(255,   0,   0,   0),			//XDataGridForeColor
											Color.FromArgb(255, 245, 245, 245),			//XDataGridAlternatingBackColor
											Color.FromArgb(255, 231, 243, 235),			//XDataGridSelectionBackColor
											Color.FromArgb(255,   0,   0,   0),			//XDataGridSelectionForeColor
											Color.FromArgb(255,   0,   0,   0),			//XDataGridHeaderForeColor
											Color.FromArgb(255, 245, 245, 221),			//XDataGridHeaderBackColor
											Color.FromArgb(255,   0,   0, 128),		    //XDataGridLinkColor
											Color.FromArgb(255, 236, 233, 216),			//XDataGridParentRowsBackColor
											Color.FromArgb(255, 255, 255, 255),		    //XDataGridParentRowsForeColor
											Color.FromArgb(255, 178, 178, 178),			//XGridBorderColor
											Color.FromArgb(255, 247, 249, 251),			//XGridBackColor
											Color.FromArgb(255, 168, 199, 230),			//XGridColHeaderBackColor
											Color.FromArgb(255, 240, 240, 254),			//XGridColHeaderGradientStartColor
											Color.FromArgb(255, 168, 199, 230),			//XGridColHeaderGradientEndColor
											Color.FromArgb(255,   0,   0,   0),		    //XGridColHeaderForeColor
											Color.FromArgb(255, 168, 199, 230),	   		//XGridRowHeaderBackColor
											Color.FromArgb(255,   0,   0,   0),		    //XGridRowHeaderForeColor
											Color.FromArgb(255, 255, 255, 255),		    //XGridRowBackColor
											Color.FromArgb(255, 245, 245, 245),			//XGridAlterateRowBackColor
											Color.FromArgb(255, 214, 213, 217),			//XGridSelectedCellBackColor
											Color.FromArgb(255,   0,   0,   0),		    //XGridSelectedCellForeColor
											Color.FromArgb(255, 178, 178, 178),			//XGridNormalCellBorderColor
											Color.FromArgb(255, 201, 215, 219),			//XGridFocusCellBorderColor
											Color.FromArgb(255, 245, 240, 240),			//XGridComputedCellBackColor 
											Color.FromArgb(255, 245, 245, 245),			//XGridGroupBandCellBackColor (WhiteSmoke)
											Color.FromArgb(255, 255, 245, 238),		    //XGridFooterCellBackColor(SeaShell)
											Color.FromArgb(255, 231, 243, 235),		    //XButtonListBackColor
											Color.FromArgb(255, 247, 249, 251),		    //XCalendarBackColor
											Color.FromArgb(255, 176, 196, 222),			//XCalendarBorderColor
											Color.FromArgb(255,   0, 191, 255),         //XCalendarHeaderBackColor
											Color.FromArgb(255, 255, 255, 255),			//XCalendarHeaderTextColor
											Color.FromArgb(255, 240, 248, 255),		    //XCalendarFooterBackColor
											Color.FromArgb(255,   0,   0,   0),			//XCalendarFooterTextColor
											Color.FromArgb(255, 135, 206, 250),		    //XCalendarWeekDayBackColor
											Color.FromArgb(255, 105, 105, 105),			//XCalendarWeekDayTextColor
											Color.FromArgb(255, 240, 248, 255),			//XCalendarMonthBackColor
											Color.FromArgb(255, 250, 250, 210),			//XCalendarDateBackColor
											Color.FromArgb(255, 176, 196, 222),			//XCalendarDateBorderColor
											Color.FromArgb(255, 255, 215,   0),			//XCalendarSelectedDateBackColor
											Color.FromArgb(255, 176, 196, 222),			//XCalendarSelectedDateBorderColor
											Color.FromArgb(255,   0,   0,   0),			//XCalendarDateTextColor
											Color.FromArgb(255,   0,   0,   0),			//XCalendarContentTextColor
											Color.FromArgb(255, 210, 210, 210),			//XCalendarDisabledDateBackColor
											Color.FromArgb(255, 168, 168, 168),			//XCalendarDisabledDateTextColor
											Color.FromArgb(255, 250, 250, 210),			//XCalendarTrailingDateBackColor
											Color.FromArgb(255, 168, 168, 168),			//XCalendarTrailingDateTextColor
											Color.FromArgb(255, 232, 245, 254),			//XCalendarHalfHolidayBackColor
											Color.FromArgb(255,   0,   0, 255),			//XCalendarHalfHolidayTextColor
											Color.FromArgb(255, 255, 235, 205),			//XCalendarFullHolidayBackColor
											Color.FromArgb(255, 255,   0,   0),			//XCalendarFullHolidayTextColor
											Color.FromArgb(255, 255, 255, 255),			//XProgressBarBackColor
											Color.FromArgb(255, 240, 240, 240),			//XProgressBarTextColor
											Color.FromArgb(255, 170, 240, 170),			//XProgressBarGradientStartColor
											Color.FromArgb(255,  10, 150,  10),			//XProgressBarGradientEndColor
											Color.FromArgb(255, 255, 255, 255),			//XMatrixBackColor
											Color.FromArgb(255, 233, 240, 251),			//XMatrixColHeaderBackColor
											Color.FromArgb(255, 250, 245, 250),			//XMatrixRowHeaderBackColor
											Color.FromArgb(255, 179, 141, 221),			//XMatrixLineColor
											Color.FromArgb(255, 255, 255, 255),			//XMatrixItemBackColor
											Color.FromArgb(255, 250, 250, 210),			//XToolTipBackColor
											Color.FromArgb(255,   0,   0,   0),			//XToolTipTextColor
											Color.FromArgb(255, 246, 252, 162), 		//XCTrackBarColor
											Color.FromArgb(255, 155, 167,   5), 		//XCTrackBarBorderColor
											Color.FromArgb(255, 255, 153,   0), 		//XCTrackBarTrackerColor
											Color.FromArgb(255, 108,  64,   0),   		//XCTrackBarTrackerBorderColor
											Color.FromArgb(255, 224, 224, 224),			//XRoundPanelBackColor
											Color.FromArgb(255, 234, 234, 234),			//XRoundPanelGradientStartColor
											Color.FromArgb(255, 220, 220, 220),			//XRoundPanelGradientEndColor
											Color.FromArgb(255, 216, 216, 216),			//XRoundPanelBorderColor
											Color.FromArgb(255, 220, 236, 254),			//MenuGradientStartColor
											Color.FromArgb(255, 140, 177, 230),			//MenuGradientEndColor
											Color.FromArgb(255, 220, 236, 254),			//DockingGradientStartColor
											Color.FromArgb(255, 140, 177, 230),			//DockingGradientEndColor
											Color.FromArgb(255,   0,  25, 108),			//XRotatorBorderColor
											Color.FromArgb(255, 210, 240, 251),			//XRotatorBackColor
											Color.FromArgb(255,  44, 135, 208),			//XRotatorGradientStartColor
											Color.FromArgb(255, 225, 245, 253),			//XRotatorGradientEndColor
											Color.FromArgb(255,   0,  10,  20),			//XRotatorTitleTextColor
											Color.FromArgb(255,   0,  10,  20),			//XRotatorHeaderTextColor
											Color.FromArgb(255, 198, 232, 241),			//XRotatorHeaderBackColor
											Color.FromArgb(255, 198, 232, 241),			//XRotatorHeaderGradientStartColor
											Color.FromArgb(155, 225, 245, 253),			//XRotatorHeaderGradientEndColor
											Color.FromArgb(255,   0,  10,  20),			//XRotatorBodyTextColor
											Color.FromArgb(255, 255, 255, 255),			//XRotatorBodyBackColor
											Color.FromArgb(255, 254, 218, 156),			//XRotatorBodyGradientStartColor
											Color.FromArgb(155, 225, 245, 253)			//XRotatorBodyGradientEndColor
											
										};
		/// <summary>
		/// Color를 관리하는 기본 Array를 가져옵니다.
		/// </summary>
		public static Color[] DefaultColorArray
		{
			get { return defaultColorArray; }
		}
		/// <summary>
		/// Color를 관리하는 현재 Array를 가져옵니다.
		/// </summary>
		public static Color[] ActiveColorArray
		{
			get { return colorArray; }
			set
			{
				colorArray = value;
				for (int i = 0; i < XColorArray.Length; i++)
					XColorArray[i].color = colorArray[i];

				colorStyleRef = true;
			}
		}
		/// <summary>
		/// XColor 생성자
		/// </summary>
		static XColor()
		{
			colorArray = defaultColorArray;
			XColorArray = new XColor[defaultColorArray.Length];
			// Class 생성시 XColor 항목을 모두 생성한다.
			for (int i = 0; i < XColorArray.Length; i++)
				XColorArray[i] = new XColor(colorArray[i], true, ((XDefinedColor)i).ToString());
		}

		/// <summary>
		/// XColor를 나타내는 Enum으로 XColor 개체를 반환합니다.
		/// </summary>
		/// <param name="definedColor">XColor Color를 나타내는 Enum </param>
		/// <returns> XColor 개체 </returns>
		public static XColor FromDefinedColor(XDefinedColor definedColor)
		{
			if (!colorStyleRef)
				ReferenceColorStyle();

			return XColorArray[(int)definedColor];
		}
		/// <summary>
		/// Platform Color를 나타내는 Enum으로 Color 개체를 반환합니다.
		/// </summary>
		/// <param name="definedColor"> Platform Color를 나타내는 Enum </param>
		/// <returns> 해당하는 Color 개체 </returns>
		public static Color GetColor(XDefinedColor definedColor)
		{
			return colorArray[(int)definedColor];
		}
		// 현재 Site의 ColorStyle이 있으면, Active ColorStyle설정을 따른다.
		/// <summary>
		/// Color Style을 정의한 XML문서로 ActiveColorStyle을 지정합니다.
		/// </summary>
		/// <returns> 지정성공시 true, 실패시 false </returns>
		private static bool ReferenceColorStyle()
		{
			colorStyleRef = true;
			try
			{
				Assembly asm = Assembly.GetExecutingAssembly();
				// Static 변수를 가져오는 것만으로 현재 ColorStyle 설정이 완료된다.
				Type colorStyleType = asm.GetType("IHIS.Framework.ColorStyle");
				PropertyInfo pi = colorStyleType.GetProperty("ActiveColorStyle");
				object val = pi.GetValue(null, null);
				return (colorStyleType != null);
			}
			catch (Exception e)
			{
				Debug.WriteLine("ColorStyle 참조 오류 : " + e.Message);
				return false;
			}
		}
		#endregion

		#region 화면 Color
		/// <summary>
		/// XForm의 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XForm"), Description("XForm BackColor")]
		public static XColor XFormBackColor //Control
		{
			get { return FromDefinedColor(XDefinedColor.XFormBackColor);}
		}
		/// <summary>
		/// XScreen의 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XScreen"), Description("XScreen BackColor")]
		public static XColor XScreenBackColor //Control
		{
			get { return FromDefinedColor(XDefinedColor.XScreenBackColor);}
		}
		/// <summary>
		/// XScreen의 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XUserControl"), Description("XUserControl BackColor")]
		public static XColor XUserControlBackColor //Control
		{
			get { return FromDefinedColor(XDefinedColor.XUserControlBackColor);}
		}
		/// <summary>
		/// 에러 메세지의 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XScreen"), Description("Status Bar Error Message Color")]
		public static XColor ErrMsgForeColor //Dark Red(0)
		{
			get { return FromDefinedColor(XDefinedColor.ErrMsgForeColor);}
		}
		#endregion

		#region Control 공통
		/// <summary>
		/// 컨트롤 기본 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("Control"), Description("Nomal Text Color")]
		public static XColor NormalForeColor
		{
			get { return FromDefinedColor(XDefinedColor.NormalForeColor);}
		}
		/// <summary>
		/// 컨트롤 수정상태 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("Control"), Description("Updated Text Color")]
		public static XColor UpdatedForeColor //Green
		{
			get { return FromDefinedColor(XDefinedColor.UpdatedForeColor);}
		}
		/// <summary>
		/// 컨트롤 새로입력상태 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("Control"), Description("Inserted Text Color")]
		public static XColor InsertedForeColor //Blue
		{
			get { return FromDefinedColor(XDefinedColor.InsertedForeColor);}
		}
		/// <summary>
		/// 컨트롤 텍스트를 3D로 그릴때 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("Control"), Description("Text Shadow Color")]
		public static XColor ShadowForeColor //White
		{
			get { return FromDefinedColor(XDefinedColor.ShadowForeColor);}
		}
		/// <summary>
		/// 컨트롤 비활성시 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("Control"), Description("Disabled Text Color")]
		public static XColor DisabledForeColor  // LightGray
		{
			get { return FromDefinedColor(XDefinedColor.DisabledForeColor);}
		}
		/// <summary>
		/// 컨트롤 기본 테두리색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("Control"), Description("Normal Control Border Color")]
		public static XColor NormalBorderColor  // Black
		{
			get { return FromDefinedColor(XDefinedColor.NormalBorderColor);}
		}
		/// <summary>
		/// 컨트롤 활성시 테두리색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("Control"), Description("Hovered Control Border Color")]
		public static XColor ActiveBorderColor //Navy
		{
			get { return FromDefinedColor(XDefinedColor.ActiveBorderColor);}
		}
		#endregion

		#region XCheckBox Color
		/// <summary>
		/// XCheckBox 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XCheckBox"), Description("XCheckBox BackColor")]
		public static XColor XCheckBoxBackColor //Control
		{
			get { return FromDefinedColor(XDefinedColor.XCheckBoxBackColor);}
		}
		#endregion

		#region XComboBox Color
		/// <summary>
		/// XComboBox 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XComboBox"), Description("XComboBox BackColor")]
		public static XColor XComboBoxBackColor //White
		{
			get { return FromDefinedColor(XDefinedColor.XComboBoxBackColor);}
		}
		#endregion

		#region XPanel Color
		/// <summary>
		/// XPanel 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XPanel"), Description("XPanel BackColor")]
		public static XColor XPanelBackColor //Control
		{
			get { return FromDefinedColor(XDefinedColor.XPanelBackColor);}
		}
		/// <summary>
		/// XPanel Border 색깔(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XPanel"), Description("XPanel BorderColor")]
		public static XColor XPanelBorderColor
		{
			get { return FromDefinedColor(XDefinedColor.XPanelBorderColor);}
		}
		#endregion

		#region XNumericUpDown Color
		/// <summary>
		/// XNumericUpDown 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XNumericUpDown"), Description("XNumericUpDown BackColor")]
		public static XColor XNumericUpDownBackColor //White
		{
			get { return FromDefinedColor(XDefinedColor.XNumericUpDownBackColor);}
		}
		#endregion

		#region XDomainUpDown Color
		/// <summary>
		/// XDomainUpDown 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDomainUpDown"), Description("XDomainUpDown BackColor")]
		public static XColor XDomainUpDownBackColor //White
		{
			get { return FromDefinedColor(XDefinedColor.XDomainUpDownBackColor);}
		}
		#endregion

		#region XTrackBar Color
		/// <summary>
		/// XTrackBar 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XTrackBar"), Description("XTrackBar BackColor")]
		public static XColor XTrackBarBackColor 
		{
			get { return FromDefinedColor(XDefinedColor.XTrackBarBackColor);}
		}
		#endregion

		#region XGroupBox Color
		/// <summary>
		/// XGroupBox 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGroupBox"), Description("XGroupBox BackColor")]
		public static XColor XGroupBoxBackColor //Control
		{
			get { return FromDefinedColor(XDefinedColor.XGroupBoxBackColor);}
		}
		/// <summary>
		/// XGroupBox 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGroupBox"), Description("XGroupBox Text Color")]
		public static XColor XGroupBoxForeColor //Black
		{
			get { return FromDefinedColor(XDefinedColor.XGroupBoxForeColor);}
		}
		#endregion
		
		#region XFindBox Color
		/// <summary>
		/// FindBox 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XFindBox"), Description("FindBox Button BackColor")]
		public static XColor XFindBoxFindBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XFindBoxFindBackColor);}
		}
		#endregion

		#region XListView Color
		/// <summary>
		/// XListView 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XListView"), Description("XListView BackColor")]
		public static XColor XListViewBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XListViewBackColor);}
		}
		/// <summary>
		/// XListView 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XListView"), Description("XListView Header BackColor")]
		public static XColor XListViewHeaderBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XListViewHeaderBackColor);}
		}
		/// <summary>
		/// XListView 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XListView"), Description("XListView Header Text Color")]
		public static XColor XListViewHeaderForeColor
		{
			get { return FromDefinedColor(XDefinedColor.XListViewHeaderForeColor);}
		}
		#endregion

		#region XListBox	Color
		/// <summary>
		/// XListBox 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XListBox"), Description("XListBox BackColor")]
		public static XColor XListBoxBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XListBoxBackColor);}
		}
		/// <summary>
		/// XListBox Item 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XListBox"), Description("XListBox Item BackColor")]
		public static XColor XListBoxItemBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XListBoxItemBackColor);}
		}
		/// <summary>
		/// XListBox 교대로 반복되는 Item 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XListBox"), Description("XListBox Alterate Item BackColor")]
		public static XColor XListBoxAlternatingItemBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XListBoxAlternatingItemBackColor);}
		}
		/// <summary>
		/// XListBox Item 테두리색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XListBox"), Description("XListBox Item Border")]
		public static XColor XListBoxItemBorderColor
		{
			get { return FromDefinedColor(XDefinedColor.XListBoxItemBorderColor);}
		}
		#endregion

		#region XCheckedListBox	Color
		/// <summary>
		/// XListBox 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XCheckedListBox"), Description("XCheckedListBox BackColor")]
		public static XColor XCheckedListBoxBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XCheckedListBoxBackColor);}
		}
		#endregion

		#region XPictureBox Color
		/// <summary>
		/// PictureBox 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XPictureBox"), Description("XPictureBox BackColor")]
		public static XColor XPictureBoxBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XPictureBoxBackColor);}
		}
		#endregion

		#region XRadioButton Color
		/// <summary>
		/// RadioButton 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XRadioButton"), Description("XRadioButton BackColor")]
		public static XColor XRadioButtonBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XRadioButtonBackColor);}
		}
		#endregion

		#region XRichTextBox Color
		/// <summary>
		/// RichXTextBox 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XRichTextBox"), Description("XRichTextBox BackColor")]
		public static XColor XRichTextBoxBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XRichTextBoxBackColor);}
		}
		#endregion

		#region XTreeView Color
		/// <summary>
		/// TreeView 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XTreeView"), Description("XTreeView BackColor")]
		public static XColor XTreeViewBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XTreeViewBackColor);}
		}
		#endregion

		#region XTabControl Color
		/// <summary>
		/// XTabControl 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XTabControl"), Description("XTabControl BackColor")]
		public static XColor XTabControlBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XTabControlBackColor);}
		}
		#endregion

		#region XTextBox Color
		/// <summary>
		/// XTextBox 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XTextBox"), Description("XTextBox BackColor")]
		public static XColor XTextBoxBackColor //White
		{
			get { return FromDefinedColor(XDefinedColor.XTextBoxBackColor);}
		}
		/// <summary>
		/// XTextBox Focus시 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XTextBox"), Description("XTextBox Hovered BackColor")]
		public static XColor XTextBoxFocusBackColor //FloralWhite
		{
			get { return FromDefinedColor(XDefinedColor.XTextBoxFocusBackColor);}
		}
		#endregion

		#region XLabel Color
		/// <summary>
		/// XLabel 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XLabel"), Description("XLabel Solid BackColor")]
		public static XColor XLabelBackColor //Control
		{
			get { return FromDefinedColor(XDefinedColor.XLabelBackColor);}
		}
		/// <summary>
		/// XLabel 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XLabel"), Description("XLabel Text Color")]
		public static XColor XLabelForeColor
		{
			get { return FromDefinedColor(XDefinedColor.XLabelForeColor);}
		}
		/// <summary>
		/// XLabel Gradient시작색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XLabel"), Description("XLabel Gradient BackColor Start Color")]
		public static XColor XLabelGradientStartColor  // White (Gradient기준)
		{
			get { return FromDefinedColor(XDefinedColor.XLabelGradientStartColor);}
		}
		/// <summary>
		/// XLabel Gradient종료색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XLabel"), Description("XLabel Gradient BackColor End Color")]
		public static XColor XLabelGradientEndColor  //DarkGray
		{
			get { return FromDefinedColor(XDefinedColor.XLabelGradientEndColor);}
		}
		/// <summary>
		/// XLabel 테두리색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XLabel"), Description("XLabel Border Color")]
		public static XColor XLabelBorderColor
		{
			get { return FromDefinedColor(XDefinedColor.XLabelBorderColor);}
		}
		#endregion

		#region XDisplayBox Color
		/// <summary>
		/// XDisplayBox 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDisplayBox"), Description("XDisplayBox Solid BackColor")]
		public static XColor XDisplayBoxBackColor //Control
		{
			get { return FromDefinedColor(XDefinedColor.XDisplayBoxBackColor);}
		}
		/// <summary>
		/// XDisplayBox 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDisplayBox"), Description("XDisplayBox Text Color")]
		public static XColor XDisplayBoxForeColor //Control
		{
			get { return FromDefinedColor(XDefinedColor.XDisplayBoxForeColor);}
		}
		/// <summary>
		/// XDisplayBox Gradient시작색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDisplayBox"), Description("XDisplayBox Gradient BackColor Start Color")]
		public static XColor XDisplayBoxGradientStartColor  // White (Gradient기준)
		{
			get { return FromDefinedColor(XDefinedColor.XDisplayBoxGradientStartColor);}
		}
		/// <summary>
		/// XDisplayBox Gradient종료색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDisplayBox"), Description("XDisplayBox Gradient BackColor End Color")]
		public static XColor XDisplayBoxGradientEndColor  //DarkGray
		{
			get { return FromDefinedColor(XDefinedColor.XDisplayBoxGradientEndColor);}
		}
		/// <summary>
		/// XDisplayBox 테두리색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDisplayBox"), Description("XDisplayBox Border Color")]
		public static XColor XDisplayBoxBorderColor
		{
			get { return FromDefinedColor(XDefinedColor.XDisplayBoxBorderColor);}
		}
		#endregion

		#region XMonthCalendar Color
		/// <summary>
		/// XMonthCalendar 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XMonthCalendar"), Description("XMonthCalendar BackColor")]
		public static XColor XMonthCalendarBackColor //Control
		{
			get { return FromDefinedColor(XDefinedColor.XMonthCalendarBackColor);}
		}
		/// <summary>
		/// XMonthCalendar Title 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XMonthCalendar"), Description("XMonthCalendar Title BackColor")]
		public static XColor XMonthCalendarTitleBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XMonthCalendarTitleBackColor);}
		}
		/// <summary>
		/// XMonthCalendar Title Text 색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XMonthCalendar"), Description("XMonthCalendar Title Text Color")]
		public static XColor XMonthCalendarTitleForeColor
		{
			get { return FromDefinedColor(XDefinedColor.XMonthCalendarTitleForeColor);}
		}
		/// <summary>
		/// XMonthCalendar Trailing Text 색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XMonthCalendar"), Description("XMonthCalendar Trailing Text Color")]
		public static XColor XMonthCalendarTrailingForeColor
		{
			get { return FromDefinedColor(XDefinedColor.XMonthCalendarTrailingForeColor);}
		}
		#endregion

		#region XDataGrid Color
		/// <summary>
		/// XDataGrid 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid BackgroundColor")]
		public static XColor XDataGridBackgroundColor  // WhiteSmoke
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridBackgroundColor);}
		}
		/// <summary>
		/// XDataGrid 라인색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid Line Color")]
		public static XColor XDataGridLineColor  //LightGray
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridLineColor);}
		}
		/// <summary>
		/// XDataGrid 라인색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid Caption BackColor")]
		public static XColor XDataGridCaptionBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridCaptionBackColor);}
		}
		/// <summary>
		/// XDataGrid 라인색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid Caption Text Color")]
		public static XColor XDataGridCaptionForeColor
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridCaptionForeColor);}
		}
		/// <summary>
		/// XDataGrid Row의 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid BackColor")]
		public static XColor XDataGridBackColor  //White
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridBackColor);}
		}
		/// <summary>
		/// XDataGrid Row의 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid Row Text Color")]
		public static XColor XDataGridForeColor
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridForeColor);}
		}
		/// <summary>
		/// XDataGrid 교대로반복되는 Row의 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid AlteratingBackColor")]
		public static XColor XDataGridAlternatingBackColor // MintCream
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridAlternatingBackColor);}
		}
		/// <summary>
		/// XDataGrid 선택된 Row의 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid Selected Row BackColor")]
		public static XColor XDataGridSelectionBackColor  //LightGray
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridSelectionBackColor);}
		}
		/// <summary>
		/// XDataGrid 선택된 Row의 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid Selected Row Text Color")]
		public static XColor XDataGridSelectionForeColor  //White
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridSelectionForeColor);}
		}
		/// <summary>
		/// XDataGrid Header의 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid Header Text Color")]
		public static XColor XDataGridHeaderForeColor //Black
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridHeaderForeColor);}
		}
		/// <summary>
		/// XDataGrid Header 배경색을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid Header BackColor")]
		public static XColor XDataGridHeaderBackColor //WhiteBlue(0)
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridHeaderBackColor);}
		}
		/// <summary>
		/// XDataGrid LinkColor(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid Link Color")]
		public static XColor XDataGridLinkColor
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridLinkColor);}
		}
		/// <summary>
		/// XDataGrid ParentRow BackColor(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid ParentRow BackColor")]
		public static XColor XDataGridParentRowsBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridParentRowsBackColor);}
		}
		/// <summary>
		/// XDataGrid ParentRow ForeColor(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XDataGrid"), Description("XDataGrid ParentRow Fore Color")]
		public static XColor XDataGridParentRowsForeColor
		{
			get { return FromDefinedColor(XDefinedColor.XDataGridParentRowsForeColor);}
		}
		#endregion

		#region XGrid Color
		/// <summary>
		/// XGrid 테두리색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid Border Color")]
		public static XColor XGridBorderColor
		{
			get { return FromDefinedColor(XDefinedColor.XGridBorderColor);}
		}
		/// <summary>
		/// XGrid 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid BackColor")]
		public static XColor XGridBackColor  
		{
			get { return FromDefinedColor(XDefinedColor.XGridBackColor);}
		}
		/// <summary>
		/// XGrid ColHeader 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid ColumnHeader Solid BackColor")]
		public static XColor XGridColHeaderBackColor //WhiteMoreBlue
		{
			get { return FromDefinedColor(XDefinedColor.XGridColHeaderBackColor);}
		}
		/// <summary>
		/// XGrid ColHeader Gradient시작색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid ColumnHeader Gradient Start Color")]
		public static XColor XGridColHeaderGradientStartColor
		{
			get { return FromDefinedColor(XDefinedColor.XGridColHeaderGradientStartColor);}
		}
		/// <summary>
		/// XGrid ColHeader Gradient종료색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid ColumnHeader Gradient End Color")]
		public static XColor XGridColHeaderGradientEndColor
		{
			get { return FromDefinedColor(XDefinedColor.XGridColHeaderGradientEndColor);}
		}
		/// <summary>
		/// XGrid ColHeader 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid ColumnHeader Text Color")]
		public static XColor XGridColHeaderForeColor  //Black
		{
			get { return FromDefinedColor(XDefinedColor.XGridColHeaderForeColor);}
		}
		/// <summary>
		/// XGrid RowHeader 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid RowHeader BackColor")]
		public static XColor XGridRowHeaderBackColor //WhiteMoreBlue
		{
			get { return FromDefinedColor(XDefinedColor.XGridRowHeaderBackColor);}
		}
		/// <summary>
		/// XGrid RowHeader 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid RowHeader Text Color")]
		public static XColor XGridRowHeaderForeColor  //Black
		{
			get { return FromDefinedColor(XDefinedColor.XGridRowHeaderForeColor);}
		}
		/// <summary>
		/// XGrid Row의 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid Row BackColor ")]
		public static XColor XGridRowBackColor  //White
		{
			get { return FromDefinedColor(XDefinedColor.XGridRowBackColor);}
		}
		/// <summary>
		/// XGrid 교대로 반복되는 Row의 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid Alterate Row BackColor")]
		public static XColor XGridAlterateRowBackColor // MintCream
		{
			get { return FromDefinedColor(XDefinedColor.XGridAlterateRowBackColor);}
		}
		/// <summary>
		/// XGrid 선택된 Cell의 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid Selected Cell BackColor")]
		public static XColor XGridSelectedCellBackColor  //HighLight
		{
			get { return FromDefinedColor(XDefinedColor.XGridSelectedCellBackColor);}
		}
		/// <summary>
		/// XGrid 선택된 Cell의 텍스트색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid Selected Cell Text Color")]
		public static XColor XGridSelectedCellForeColor  //White
		{
			get { return FromDefinedColor(XDefinedColor.XGridSelectedCellForeColor);}
		}
		/// <summary>
		/// XGrid Cell 기본 테두리색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid Normal Cell Border Color")]
		public static XColor XGridNormalCellBorderColor  //LightGray
		{
			get { return FromDefinedColor(XDefinedColor.XGridNormalCellBorderColor);}
		}
		/// <summary>
		/// XGrid Cell Focus시 테두리색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid Focused Cell Border Color")]
		public static XColor XGridFocusCellBorderColor  //HighLight
		{
			get { return FromDefinedColor(XDefinedColor.XGridFocusCellBorderColor);}
		}
		/// <summary>
		/// XGrid ComputedCell의 배경색을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid ComputedCell Back Color")]
		public static XColor XGridComputedCellBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XGridComputedCellBackColor);}
		}
		/// <summary>
		/// XGrid GroupBandCell의 배경색을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid GroupBandCell Back Color")]
		public static XColor XGridGroupBandCellBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XGridGroupBandCellBackColor);}
		}
		/// <summary>
		/// XGrid FooterCell의 배경색을 가져옵니다.
		/// </summary>
		[Category("XGrid"), Description("XGrid FooterCell Back Color")]
		public static XColor XGridFooterCellBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XGridFooterCellBackColor);}
		}
		#endregion

		#region XButtonList Color
		/// <summary>
		/// XButtonList 배경색(XColor형)을 가져옵니다.
		/// </summary>
		[Category("XButtonList"), Description("XButtonList BackColor")]
		public static XColor XButtonListBackColor  
		{
			get { return FromDefinedColor(XDefinedColor.XButtonListBackColor);}
		}
		#endregion

		#region XCalendar Color
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendar BackColor")]
		public static XColor XCalendarBackColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarBackColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarBorderColor")]
		public static XColor XCalendarBorderColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarBorderColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarHeaderBackColor")]
		public static XColor XCalendarHeaderBackColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarHeaderBackColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarHeaderTextColor")]
		public static XColor XCalendarHeaderTextColor
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarHeaderTextColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarFooterBackColor")]
		public static XColor XCalendarFooterBackColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarFooterBackColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarFooterTextColor")]
		public static XColor XCalendarFooterTextColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarFooterTextColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarWeekDayBackColor")]
		public static XColor XCalendarWeekDayBackColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarWeekDayBackColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarWeekDayTextColor")]
		public static XColor XCalendarWeekDayTextColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarWeekDayTextColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarMonthBackColor")]
		public static XColor XCalendarMonthBackColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarMonthBackColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarDateBorderColor")]
		public static XColor XCalendarDateBorderColor
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarDateBorderColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarSelectedDateBackColor")]
		public static XColor XCalendarSelectedDateBackColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarSelectedDateBackColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarSelectedDateBorderColor")]
		public static XColor XCalendarSelectedDateBorderColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarSelectedDateBorderColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarDateBackColor")]
		public static XColor XCalendarDateBackColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarDateBackColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarDateTextColor")]
		public static XColor XCalendarDateTextColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarDateTextColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarContentTextColor")]
		public static XColor XCalendarContentTextColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarContentTextColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarDisabledDateBackColor")]
		public static XColor XCalendarDisabledDateBackColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarDisabledDateBackColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarDisabledDateTextColor")]
		public static XColor XCalendarDisabledDateTextColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarDisabledDateTextColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarTrailingDateBackColor")]
		public static XColor XCalendarTrailingDateBackColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarTrailingDateBackColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarTrailingDateTextColor")]
		public static XColor XCalendarTrailingDateTextColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarTrailingDateTextColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarHalfHolidayBackColor")]
		public static XColor XCalendarHalfHolidayBackColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarHalfHolidayBackColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarHalfHolidayTextColor")]
		public static XColor XCalendarHalfHolidayTextColor  
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarHalfHolidayTextColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarFullHolidayBackColor")]
		public static XColor XCalendarFullHolidayBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarFullHolidayBackColor);}
		}
		/// <summary>
		/// 
		/// </summary>
		[Category("XCalendarColor"), Description("XCalendarFullHolidayTextColor")]
		public static XColor XCalendarFullHolidayTextColor
		{
			get { return FromDefinedColor(XDefinedColor.XCalendarFullHolidayTextColor);}
		}
		#endregion

		#region XProgressBar
		[Category("XProgressBarColor"), Description("XProgressBar BackColor")]
		public static XColor XProgressBarBackColor 
		{
			get { return FromDefinedColor(XDefinedColor.XProgressBarBackColor);}
		}
		[Category("XProgressBarColor"), Description("XProgressBar TextColor")]
		public static XColor XProgressBarTextColor 
		{
			get { return FromDefinedColor(XDefinedColor.XProgressBarTextColor);}
		}
		[Category("XProgressBarColor"), Description("XProgressBar GradientStartColor")]
		public static XColor XProgressBarGradientStartColor
		{
			get { return FromDefinedColor(XDefinedColor.XProgressBarGradientStartColor);}
		}
		[Category("XProgressBarColor"), Description("XProgressBar GradientEndColor")]
		public static XColor XProgressBarGradientEndColor 
		{
			get { return FromDefinedColor(XDefinedColor.XProgressBarGradientEndColor);}
		}
		#endregion

		#region XMatrix
		[Category("XMatrixColor"), Description("XMatrix BackColor")]
		public static XColor XMatrixBackColor 
		{
			get { return FromDefinedColor(XDefinedColor.XMatrixBackColor);}
		}
		[Category("XMatrixColor"), Description("XMatrix ColHeaderBackColor")]
		public static XColor XMatrixColHeaderBackColor 
		{
			get { return FromDefinedColor(XDefinedColor.XMatrixColHeaderBackColor);}
		}
		[Category("XMatrixColor"), Description("XMatrix RowHeaderBackColor")]
		public static XColor XMatrixRowHeaderBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XMatrixRowHeaderBackColor);}
		}
		[Category("XMatrixColor"), Description("XMatrix Line Color")]
		public static XColor XMatrixLineColor 
		{
			get { return FromDefinedColor(XDefinedColor.XMatrixLineColor);}
		}
		[Category("XMatrixColor"), Description("XMatrix Item BackColor")]
		public static XColor XMatrixItemBackColor 
		{
			get { return FromDefinedColor(XDefinedColor.XMatrixItemBackColor);}
		}
		#endregion

		#region XToolTip
		[Category("XToolTipColor"), Description("XToolTip BackColor")]
		public static XColor XToolTipBackColor 
		{
			get { return FromDefinedColor(XDefinedColor.XToolTipBackColor);}
		}
		[Category("XToolTipColor"), Description("XToolTip TextColor")]
		public static XColor XToolTipTextColor 
		{
			get { return FromDefinedColor(XDefinedColor.XToolTipTextColor);}
		}
		#endregion

		#region XRoundPanel
		[Category("XRoundPanelColor"), Description("XRoundPanelColor BackColor")]
		public static XColor XRoundPanelBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XRoundPanelBackColor); }
		}
		[Category("XRoundPanelColor"), Description("XRoundPanelColor GradientStartColor")]
		public static XColor XRoundPanelGradientStartColor
		{
			get { return FromDefinedColor(XDefinedColor.XRoundPanelGradientStartColor); }
		}
		[Category("XRoundPanelColor"), Description("XRoundPanelColor GradientEndColor")]
		public static XColor XRoundPanelGradientEndColor
		{
			get { return FromDefinedColor(XDefinedColor.XRoundPanelGradientEndColor); }
		}
		[Category("XRoundPanelColor"), Description("XRoundPanelColor BorderColor")]
		public static XColor XRoundPanelBorderColor
		{
			get { return FromDefinedColor(XDefinedColor.XRoundPanelBorderColor); }
		}
        
		#endregion

		#region XCTrackBar
		[Category("XCTrackBar"), Description("XCTrackBar BackColor")]
		public static XColor XCTrackBarColor 
		{
			get { return FromDefinedColor(XDefinedColor.XCTrackBarColor);}
		}
		[Category("XCTrackBar"), Description("XCTrackBar BorderColor")]
		public static XColor XCTrackBarBorderColor 
		{
			get { return FromDefinedColor(XDefinedColor.XCTrackBarBorderColor);}
		}
		[Category("XCTrackBar"), Description("XCTrackBar Tracker BackColor")]
		public static XColor XCTrackBarTrackerColor 
		{
			get { return FromDefinedColor(XDefinedColor.XCTrackBarTrackerColor);}
		}
		[Category("XCTrackBar"), Description("XCTrackBar Tracker BorderColor")]
		public static XColor XCTrackBarTrackerBorderColor 
		{
			get { return FromDefinedColor(XDefinedColor.XCTrackBarTrackerBorderColor);}
		}
		#endregion

		#region XRotator
		[Category("XRotatorColor"), Description("XRotator Border Color")]
		public static XColor XRotatorBorderColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorBorderColor); }
		}
		[Category("XRotatorColor"), Description("XRotator Back Color")]
		public static XColor XRotatorBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorBackColor); }
		}
		[Category("XRotatorColor"), Description("XRotator Gradient Start Color")]
		public static XColor XRotatorGradientStartColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorGradientStartColor); }
		}
		[Category("XRotatorColor"), Description("XRotator GradientEnd Color")]
		public static XColor XRotatorGradientEndColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorGradientEndColor); }
		}
		[Category("XRotatorColor"), Description("XRotator Title Text Color")]
		public static XColor XRotatorTitleTextColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorTitleTextColor); }
		}
		[Category("XRotatorColor"), Description("XRotator Header Text Color")]
		public static XColor XRotatorHeaderTextColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorHeaderTextColor); }
		}
		[Category("XRotatorColor"), Description("XRotator Header BackColor")]
		public static XColor XRotatorHeaderBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorHeaderBackColor); }
		}
		[Category("XRotatorColor"), Description("XRotator Header Gradient Start Color")]
		public static XColor XRotatorHeaderGradientStartColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorHeaderGradientStartColor); }
		}
		[Category("XRotatorColor"), Description("XRotator Header Gradient End Color")]
		public static XColor XRotatorHeaderGradientEndColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorHeaderGradientEndColor); }
		}
		[Category("XRotatorColor"), Description("XRotator Body Text Color")]
		public static XColor XRotatorBodyTextColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorBodyTextColor); }
		}
		[Category("XRotatorColor"), Description("XRotator Body BackColor")]
		public static XColor XRotatorBodyBackColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorBodyBackColor); }
		}
		[Category("XRotatorColor"), Description("XRotator Body Gradient Start Color")]
		public static XColor XRotatorBodyGradientStartColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorBodyGradientStartColor); }
		}
		[Category("XRotatorColor"), Description("XRotator Body Gradient End Color")]
		public static XColor XRotatorBodyGradientEndColor
		{
			get { return FromDefinedColor(XDefinedColor.XRotatorBodyGradientEndColor); }
		}
		#endregion

		#region Menu, Docking
		[Category("MenuColor"), Description("Menu Gradient Start Color")]
		public static XColor MenuGradientStartColor
		{
			get { return FromDefinedColor(XDefinedColor.MenuGradientStartColor); }
		}
		[Category("MenuColor"), Description("Menu Gradient End Color")]
		public static XColor MenuGradientEndColor
		{
			get { return FromDefinedColor(XDefinedColor.MenuGradientEndColor); }
		}
		[Category("DockingControlColor"), Description("DockingControl Gradient Start Color")]
		public static XColor DockingGradientStartColor
		{
			get { return FromDefinedColor(XDefinedColor.DockingGradientStartColor); }
		}
		[Category("DockingControlColor"), Description("DockingControl Gradient End Color")]
		public static XColor DockingGradientEndColor
		{
			get { return FromDefinedColor(XDefinedColor.DockingGradientEndColor); }
		}
		#endregion


		#region Equals, ==, != Method
		/// <summary>
		/// 두 XColor가 같은색인지 여부를 반환합니다.
		/// </summary>
		/// <param name="left"> XColor 개체 </param>
		/// <param name="right"> XColor 개체 </param>
		/// <returns> 같으면 true, 다르면 false </returns>
		public static bool operator ==(XColor left, XColor right)
		{
			return left.Equals(right);
		}
		/// <summary>
		/// 두 XColor가 다른색인지 여부를 반환합니다.
		/// </summary>
		/// <param name="left"> XColor 개체 </param>
		/// <param name="right"> XColor 개체 </param>
		/// <returns> 다르면 true, 같으면 false </returns>
		public static bool operator !=(XColor left, XColor right)
		{
			return !left.Equals(right);
		}
		/// <summary>
		/// 같은 XColor인지 여부를 반환합니다.
		/// </summary>
		/// <param name="obj"> XColor 개체 </param>
		/// <returns> 같으면 true, 다르면 false </returns>
		public override bool Equals(object obj)
		{
			XColor color = obj as XColor;
			if (obj == null)
				return false;

			if (this.isXColor != color.isXColor)
				return false;
			else if (this.isXColor)
				return (this.colorName == color.colorName);
			else
				return (this.color == color.color);
		}
		/// <summary>
		/// 현재 영역의 해시 코드를 가져옵니다.
		/// </summary>
		/// <returns> 현재 영역의 해시 코드 </returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		#endregion
	}
}
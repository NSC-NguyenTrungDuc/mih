using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region Enum
	/// <summary>
	/// 그리기 패턴을 나타내는 Enum입니다.
	/// </summary>
	public enum DrawPattern
	{
		/// <summary>
		/// 배경을 평면으로 그림.
		/// </summary>
		Flat,
		/// <summary>
		/// 배경을 Horizontal Gradient로 그림.
		/// </summary>
		HorizonGRAD1,
		/// <summary>
		/// 배경을 Horizontal Gradient로 그림.
		/// </summary>
		HorizonGRAD2,
		/// <summary>
		/// 배경을 Diagonal Gradient로 그림.
		/// </summary>
		DiagonalGRAD,
		/// <summary>
		/// 배경을 Surround Gradient로 그림.
		/// </summary>
		SurroundGRAD
	};
	#endregion

	/// <summary>
	/// XDisplayBox에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(IHIS.Framework.XDisplayBox), "Images.XDisplayBox.bmp")]
	[Designer(typeof(XDisplayBoxDesigner))]
	public class XDisplayBox : System.Windows.Forms.Label, IDataControl
	{
		#region Class Variables
		private DrawPattern lp = DrawPattern.Flat;	// 기본값
		private XColor gradientStart	= XColor.XDisplayBoxGradientStartColor;
		private XColor gradientEnd		= XColor.XDisplayBoxGradientEndColor;
		private XColor borderColor		= XColor.XDisplayBoxBorderColor;
		private XColor xBackColor		= XColor.XDisplayBoxBackColor;
		private XColor xForeColor		= XColor.XDisplayBoxForeColor;
		private bool	edgeRounding = true;
		private Point[]	regionPoints;
		private MaskType editMaskType = MaskType.String;
		private string   mask = "";
		private int      decimalDigits = 0;
		private bool	 amPmStyle = false;  //Time형을 AM, PM 형태로 보여줄지 여부
		private bool	generalNumberFormat = false; //Number의 Format이 일반형식(g)인지 n형식인지 여부
		private ArrayList maskSymbols = new ArrayList();
		private bool	isJapanYearType = false;  //일본와력 표시Type인지 여부
		private const int cMargin = 2;  //Draw시 Margin
		private bool	invalidDateIsStringEmpty = true; //Date,DateTime, Time, Month형 컬럼의 값이 유효하지 않을때 ""를 보여줄지여부를 관리
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
        ToolTip toolTip = new ToolTip();
		#endregion

		#region base 속성 재정의
		[DefaultValue(typeof(XColor),"XDisplayBoxBackColor"),
		Description("배경색을 지정합니다.")]
		public new XColor BackColor
		{
			get { return xBackColor;}
			set 
			{
				xBackColor = value;
				base.BackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDisplayBoxForeColor"),
		Description("텍스트색을 지정합니다.")]
		public new XColor ForeColor
		{
			get { return xForeColor;}
			set 
			{
				xForeColor = value;
				base.ForeColor = value.Color;
			}
		}
		/// <summary>
		/// 컨트롤의 테두리 스타일을 가져오거나 설정합니다(재정의 Not Browsable)
		/// </summary>
		[Browsable(false)]
		public override BorderStyle BorderStyle 
		{
			get { return base.BorderStyle;}
			set { base.BorderStyle = value;}
		}
		/// <summary>
		/// 레이블 컨트롤의 평면 스타일 모양을 가져오거나 설정합니다(재정의 Not Browsable)
		/// </summary>
		[Browsable(false)]
		public new FlatStyle FlatStyle
		{
			get { return base.FlatStyle;}
			set { base.FlatStyle = value;}
		}
		//TextAlign 기본속성
		/// <summary>
		/// 텍스트 맞춤을 가져오거나 설정합니다.(Default Value 재정의)
		/// </summary>
		[DefaultValue(ContentAlignment.MiddleLeft)]
		public new ContentAlignment TextAlign
		{
			get {return base.TextAlign;}
			set {base.TextAlign = value;}
		}
		//Serialize, Reset 은 의미가 없음
//		private bool ShouldSerializeTextAlign()
//		{
//			ContentAlignment align = ContentAlignment.MiddleLeft;
//			switch (editMaskType)
//			{
//				case MaskType.Date:
//				case MaskType.Month:
//				case MaskType.DateTime:
//				case MaskType.Time:
//					align = ContentAlignment.MiddleCenter;
//					break;
//				case MaskType.Number:
//				case MaskType.Decimal:
//					align = ContentAlignment.MiddleRight;
//					break;
//				default:
//					align = ContentAlignment.MiddleLeft;
//					break;
//			}
//			return (TextAlign != align);
//		}
//		// 다시설정시 기본값
//		private void ResetTextAlign()
//		{	
//			switch (editMaskType)
//			{
//				case MaskType.Date:
//				case MaskType.Month:
//				case MaskType.DateTime:
//				case MaskType.Time:
//					TextAlign = ContentAlignment.MiddleCenter;
//					break;
//				case MaskType.Number:
//				case MaskType.Decimal:
//					TextAlign = ContentAlignment.MiddleRight;
//					break;
//				default:
//					TextAlign = ContentAlignment.MiddleLeft;
//					break;
//			}
//		}
		
		/// <summary>
		/// Text를 설정합니다.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public override string Text 
		{
			get { return base.Text;}
			set { base.Text = value; }
		}
		/// <summary>
		/// Image를 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(null)]
		public new Image Image 
		{
			get { return base.Image;}
			set 
			{
				if (base.Image != value)
				{
					//ImageFormat이 BMP이면 TransParent 지정
					if (value != null)
					{
						try
						{
							Bitmap bmp = (Bitmap) value;
							bmp.MakeTransparent();
							base.Image = bmp;
						}
						catch{}
					}
					else
						base.Image = value;
				}
			}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		#endregion

		#region Properties
		object IDataControl.DataValue
		{
			get	{ return this.DataValue; }
			set	{ this.DataValue = (value == null ? "" : value.ToString());}
		}
		ControlDataType IDataControl.ContType
		{
			get
			{
				ControlDataType contType = ControlDataType.String;
				switch (this.editMaskType)
				{
					case MaskType.Number:
					case MaskType.Decimal:
						contType = ControlDataType.Number;
						break;
					case MaskType.Date:
						contType = ControlDataType.Date;
						break;
					case MaskType.DateTime:
						contType = ControlDataType.DateTime;
						break;
					case MaskType.Time:
						contType = ControlDataType.Time;
						break;

				}
				return contType;
			}
		}
		/// <summary>
		/// DataValue는 외부로 노출하지 않고, Method(GetDataValue, SetDataValue(..)를 통해 접근함.
		/// </summary>
		protected virtual string DataValue
		{
			get
			{
				//2006.01.09 IsJapanYearType 추가
				if (this.isJapanYearType && ((this.editMaskType == MaskType.Date)||(this.editMaskType == MaskType.Month)))
					return JapanYearHelper.GetDataValue(this.editMaskType, this.Text);
				else
					return MaskHelper.GetDataValue(this.editMaskType, this.maskSymbols, ConvertText(true, this.Text));

			}
			set
			{
				//2006.01.09 IsJapanYearType 추가, 유효한 데이타가 아니면 ""로 return (
				if (this.isJapanYearType && ((this.editMaskType == MaskType.Date)||(this.editMaskType == MaskType.Month)))
					Text = JapanYearHelper.GetDisplayText(this.editMaskType, value, this.invalidDateIsStringEmpty);
				else // DisplayText로 Text Set
					Text = ConvertText(false, MaskHelper.GetDisplayText(this.editMaskType, this.maskSymbols, this.decimalDigits, this.generalNumberFormat, value, true, this.invalidDateIsStringEmpty));
			}
		}
		/// <summary>
		/// 컨트롤이 편집가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),Category("추가속성"),DefaultValue(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Protect
		{ 
			get { return !Enabled;}
			set { Enabled  = !value;}
		}
		/// <summary>
		/// 컨트롤의 값이 변경되었는지 여부를 가져옵니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		DefaultValue(false)]
		public bool DataChanged
		{
			get { return false; }
			set {}
		}
		/// <summary>
		/// XDisplayBox의 EditMaskType을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(MaskType.String),
		MergableProperty(true),
		Description("XDisplayBox의 EditMaskType을 지정합니다")]
		public MaskType EditMaskType
		{
			get { return editMaskType; }
			set 
			{ 
				if (editMaskType != value)
				{
					//2006.01.09 IsJapanYearType Reset
					this.isJapanYearType = false;

					editMaskType = value; 
					// MaskType에 따라 TextAlign Set (String Left, Number right, Date, Time은 Center)
					switch(editMaskType)
					{
						case MaskType.String:
							this.TextAlign = ContentAlignment.MiddleLeft;
							this.mask = MaskHelper.CStringDefaultMask;
							break;
						case MaskType.Date:
							this.TextAlign = ContentAlignment.MiddleCenter;
							this.mask = MaskHelper.CDateDefaultMask;
							break;
						case MaskType.DateTime:
							this.TextAlign = ContentAlignment.MiddleCenter;
							this.mask = MaskHelper.CDateTimeDefaultMask;
							break;
						case MaskType.Time:
							this.TextAlign = ContentAlignment.MiddleCenter;
							this.mask = MaskHelper.CTimeDefaultMask;
							break;
						case MaskType.Month:
							this.TextAlign = ContentAlignment.MiddleCenter;
							this.mask = MaskHelper.CMonthDefaultMask;
							break;
						case MaskType.Number:
						case MaskType.Decimal:
							this.TextAlign = ContentAlignment.MiddleRight;
							this.mask = MaskHelper.CStringDefaultMask;
							break;
						default:
							this.TextAlign = ContentAlignment.MiddleLeft;
							this.mask = MaskHelper.CStringDefaultMask;
							break;
					}
					//MaskSymbols SET
					MaskHelper.SetMaskSymbols(this.editMaskType, this.mask, this.maskSymbols);
					//Text를 NullText로 SET
					Text = ConvertText(false, MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits,true,this.invalidDateIsStringEmpty));
					//2006.01.10 Date,Month형은 NullText대신에 
					Invalidate(ClientRectangle);
				}
			}
		}
		/// <summary>
		/// EditMask의 Mask를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		Description("EditMask의 Mask를 지정합니다")]
		public string Mask
		{
			get { return mask; }
			set 
			{ 
				//2006.01.09 일본어 Type이면 적용하지 않음
				if (this.isJapanYearType) return;

				if (mask != value)
				{
					string errMsg = "";
					if (!MaskHelper.IsValidMask(this.editMaskType, value, out errMsg))
					{
						MessageBox.Show(errMsg);
						return;
					}
					mask = value;
					//MaskSymbols SET
					MaskHelper.SetMaskSymbols(this.editMaskType, this.mask, this.maskSymbols);
					//Text를 NullText로 SET
					Text = ConvertText(false, MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits));
					Invalidate(ClientRectangle);
				}
			}
		}
		// Mask의 Serialize 통제 Method
		// Mask의 DefaultValue Attribute를 주지 않고, Case에 따라 DefaultValue 변경
		private bool ShouldSerializeMask()
		{
			// Date(YYYY/MM/DD), DateTime(YYYY/MM/DD HH:MI:SS), Time(HH:MI:SS) Month(YYYY/MM)Default
			if (editMaskType == MaskType.Date)
				return (mask != MaskHelper.CDateDefaultMask);
			else if (editMaskType == MaskType.DateTime)
				return (mask != MaskHelper.CDateTimeDefaultMask);
			else if (editMaskType == MaskType.Time)
				return (mask != MaskHelper.CTimeDefaultMask);
			else if (editMaskType == MaskType.Month)
				return (mask != MaskHelper.CMonthDefaultMask);
			else
				return (mask != MaskHelper.CStringDefaultMask);
		}
		// 다시설정시 기본값
		// Mask의 DefaultValue Attribute를 주지 않고, Case에 따라 DefaultValue 변경
		private void ResetMask()
		{	
			// Date(YYYY/MM/DD), DateTime(YYYY/MM/DD HH:MI:SS), Time(HH:MI:SS) Month(YYYY/MM) Default
			if (editMaskType == MaskType.Date)
				Mask = MaskHelper.CDateDefaultMask;
			else if (editMaskType == MaskType.DateTime)
				Mask = MaskHelper.CDateTimeDefaultMask;
			else if (editMaskType == MaskType.Time)
				Mask = MaskHelper.CTimeDefaultMask;
			else if (editMaskType == MaskType.Month)
				Mask = MaskHelper.CMonthDefaultMask;
			else
				Mask = MaskHelper.CStringDefaultMask;
		}
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("Date,Month형일 경우 일본와력 표시여부를 지정합니다.")]
		public bool IsJapanYearType
		{
			get { return isJapanYearType;}
			set 
			{
				//Date, Month만 적용
				if ((this.editMaskType != MaskType.Date) && (this.editMaskType != MaskType.Month)) return;

				if (isJapanYearType != value)
				{
					//MaskReset
					ResetMask();
					if (value)
					{
						//일본 연호형식으로 Text Set, 유효한 값이 아니면 ""로 Return
						Text = JapanYearHelper.GetDisplayText(this.editMaskType, this.DataValue, this.invalidDateIsStringEmpty);
					}
					else  //현재데이타로 Text 다시 설정
					{
						//MaskSymbols SET
						MaskHelper.SetMaskSymbols(this.editMaskType, this.mask, this.maskSymbols);
						//Text를 NullText로 SET
						Text = ConvertText(false, MaskHelper.GetDisplayText(this.editMaskType, this.maskSymbols, this.decimalDigits, this.generalNumberFormat, this.DataValue, true, this.invalidDateIsStringEmpty));
					}
					Invalidate(ClientRectangle);
					isJapanYearType = value;

				}
			}
		}
		/// <summary>
		/// Date,DateTime,Time,Month형 컬럼일때 값이 유효하지 않을때 ""를 보여줄지 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		Description("Date,DateTime,Time,Month형 컬럼일때 값이 유효하지 않을때 String.Empty를 보여줄지 여부를 지정합니다")]
		public virtual bool InvalidDateIsStringEmpty
		{
			get { return invalidDateIsStringEmpty;}
			set 
			{
				if (invalidDateIsStringEmpty != value)
				{
					invalidDateIsStringEmpty = value;
					//Text 다시 설정
					if (this.isJapanYearType)
					{
						//일본 연호형식으로 Text Set, 유효한 값이 아니면 ""로 Return
						Text = JapanYearHelper.GetDisplayText(this.editMaskType, this.DataValue, this.invalidDateIsStringEmpty);
					}
					else
					{
						//Text를 NullText로 SET
						Text = ConvertText(false, MaskHelper.GetDisplayText(this.editMaskType, this.maskSymbols, this.decimalDigits, this.generalNumberFormat, this.DataValue, true, this.invalidDateIsStringEmpty));
					}
				}
			}
		}
		/// <summary>
		/// Decimal Type의 Digits를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(0),
		MergableProperty(true),
		Description("Decimal Type의 Digits를 지정합니다")]
		public int DecimalDigits
		{
			get { return decimalDigits;}
			set { decimalDigits = Math.Max(0,value);}
		}
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("Number형의 형식이 일반형식(1234)인지 숫자(1,234)형식인지 여부를 지정합니다.")]
		public bool GeneralNumberFormat
		{
			get { return generalNumberFormat;}
			set 
			{ 
				if (generalNumberFormat != value)
				{
					generalNumberFormat = value;
					//RunTime시는 Text 변경
					if (!this.DesignMode)
						Text = MaskHelper.GetDisplayText(this.editMaskType, this.maskSymbols, this.decimalDigits, value, this.DataValue);
				}
			}
		}
		/// <summary>
		/// Time형일때 AM,PM형태로 보여줄지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("Time형을 AM,PM형태로 보여줄지 여부를 지정합니다.(05:04:12 AM)")]
		public bool AmPmStyle
		{
			get { return amPmStyle;}
			set 
			{ 
				if (amPmStyle != value)
				{
					amPmStyle = value;
					if (this.editMaskType == MaskType.Time)
					{
						//Text 변경
						this.Text = ConvertText(false, MaskHelper.GetDisplayText(this.editMaskType, this.maskSymbols, this.decimalDigits, this.generalNumberFormat, this.DataValue));
					}
				}
			}
		}
		/// <summary>
		/// 배경색 칠하기 패턴(Plat,Gradient등)을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), 
		Category("추가속성"),
		DefaultValue(DrawPattern.Flat),
		MergableProperty(true),
		Description("바탕 칠하기 속성을 지정합니다.")]
		public DrawPattern BackGroundPattern
		{
			get { return lp; }
			set 
			{ 
				lp = value; 
				Invalidate(ClientRectangle); 
			}
		}
		/// <summary>
		/// 외곽 모서리를 둥글게 처리할지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),
		Category("추가속성"),
		DefaultValue(true),
		MergableProperty(true),
		Description("외곽 모서리를 둥글게 처리할지 여부를 지정합니다.")]
		public bool EdgeRounding
		{
			get { return edgeRounding; }
			set
			{
				edgeRounding = value;
				OnParentChanged(new EventArgs());
			}
		}
		/// <summary>
		/// LayoutContainer(XScreen,XForm)의 Reset호출시에 Reset을 적용할지 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("LayoutContainer(XScreen,XForm)의 Reset호출시에 Reset을 적용할지 여부를 지정합니다.")]
		public bool ApplyLayoutContainerReset
		{
			get { return applyLayoutContainerReset; }
			set { applyLayoutContainerReset = value;}
		}
		/// <summary>
		/// 배경을 Gradient로 그릴때 시작색(Color형)을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XDisplayBoxGradientStartColor"),
		MergableProperty(true),
		Description("배경을 Gradient로 그릴때 시작색을 지정합니다.")]
		public XColor GradientStartColor
		{
			get 
			{ 
				return gradientStart; 
			}
			set	
			{ 
				gradientStart = value;
				Invalidate(ClientRectangle);
			}
		}
		/// <summary>
		/// 배경을 Gradient로 그릴때 종료색(Color형)을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XDisplayBoxGradientEndColor"),
		MergableProperty(true),
		Description("배경을 Gradient로 그릴때 종료색을 지정합니다.")]
		public XColor GradientEndColor
		{
			get 
			{ 
				return gradientEnd; 
			}
			set	
			{ 
				gradientEnd = value;
				Invalidate(ClientRectangle);
			}
		}
		/// <summary>
		/// 경계선색(Color형)을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XDisplayBoxBorderColor"),
		MergableProperty(true),
		Description("경계선색을 지정합니다.")]
		public XColor BorderColor
		{
			get 
			{ 
				return borderColor; 
			}
			set	
			{ 
				borderColor = value;
				Invalidate(ClientRectangle);
			}
		}
		#endregion

		#region Event (IDataControl Implementation)
		/// <summary>
		/// 데이타 유효성검사가 진행될 때 발생하는 Event입니다.
		/// </summary>
		[Browsable(false)]
		public event DataValidatingEventHandler DataValidating;
		#endregion

		#region Constructor(s)
		/// <summary>
		/// XDisplayBox 생성자
		/// </summary>
		public XDisplayBox()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint|ControlStyles.UserPaint|ControlStyles.Opaque, true);
			this.BackColor = XColor.XDisplayBoxBackColor;
			this.ForeColor = XColor.XDisplayBoxForeColor;
			this.Text = "";
			this.TextAlign = ContentAlignment.MiddleLeft;
			this.Height = 21;

			// 2005/05/09 신종석 폰트 수정
			//this.Font = new Font("MS UI Gothic", 9.75f);

            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                this.Font = new Font("MS UI Gothic", 9.75f);
            }
            else
            {
                this.Font = Service.COMMON_FONT;
            }
		}
		#endregion

		#region Overrides
		/// <summary>
		/// 지정한 배경색,텍스트색,패턴에 따라 컨트롤을 그립니다.
		/// </summary>
		/// <param name="pe"> 이벤트 데이터가 들어 있는 PaintEventArgs </param>
		protected override void OnPaint(PaintEventArgs pe)
		{
			switch (lp)
			{
				case DrawPattern.Flat :
				{
					using (SolidBrush b = new SolidBrush(this.BackColor.Color))
						pe.Graphics.FillRectangle(b, ClientRectangle);
				}
					break;
				case DrawPattern.HorizonGRAD1 :
				{
					using (Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle,	gradientStart.Color, gradientEnd.Color, System.Drawing.Drawing2D.LinearGradientMode.Vertical))
						pe.Graphics.FillRectangle (b, ClientRectangle);
				}
					break;
				case DrawPattern.HorizonGRAD2 :
				{
					System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath();
					gPath.AddRectangle(ClientRectangle);
					System.Drawing.Drawing2D.PathGradientBrush pgb = new System.Drawing.Drawing2D.PathGradientBrush(gPath);
					pgb.CenterColor = gradientEnd.Color; 
					pgb.SurroundColors = new Color[] {gradientStart.Color};
					pgb.WrapMode = System.Drawing.Drawing2D.WrapMode.TileFlipX;
					pgb.FocusScales = new PointF(1.0f, 0.125f);
					pe.Graphics.FillPath (pgb, gPath);
					pgb.Dispose();
					gPath.Dispose();
				}
					break;
				case DrawPattern.DiagonalGRAD :
				{
					using (Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle,	gradientStart.Color, gradientEnd.Color, System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal))
						pe.Graphics.FillRectangle (b, ClientRectangle);
				}
					break;
				case DrawPattern.SurroundGRAD :
				{
					System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath();
					gPath.AddRectangle(ClientRectangle);
					System.Drawing.Drawing2D.PathGradientBrush pgb = new System.Drawing.Drawing2D.PathGradientBrush(gPath);
					pgb.CenterColor = gradientEnd.Color; 
					pgb.SurroundColors = new Color[] {gradientStart.Color};
					pgb.WrapMode = System.Drawing.Drawing2D.WrapMode.TileFlipX;
					pgb.FocusScales = new PointF(0.8f, 0.125f);
					pe.Graphics.FillPath (pgb, gPath);
					pgb.Dispose();
					gPath.Dispose();
				}
					break;
			}

			if (edgeRounding && (regionPoints != null))
			{
				Point[] points = (Point[])(regionPoints.Clone());
				points[1].Offset(-1, 0);
				points[2].Offset(-1, 0);
				points[3].Offset(-1, 0);
				points[4].Offset(-1, -1);
				points[5].Offset(-1, -1);
				points[6].Offset(-1, -1);
				points[7].Offset(0, -1);
				points[8].Offset(0, -1);
				using (Pen p = new Pen(borderColor.Color))
					pe.Graphics.DrawLines(p, points);
			}
			else
			{
				Rectangle rect = ClientRectangle;
				rect.Width --;
				rect.Height --;
				using (Pen p = new Pen(borderColor.Color))
					pe.Graphics.DrawRectangle(p, rect);
			}

			//draw text
			int length = 0;
			for (int i = 0; i < Text.Length; i++)
			{
				length += (((int) Text[i]) > 255 ? 2 : 1);
			}
			
			//Text align조정
			Rectangle txtRect = ClientRectangle;
			txtRect.X += cMargin;
			txtRect.Width -= cMargin;
			txtRect.Y += cMargin;
			txtRect.Height -= cMargin;
		
			//Image Draw
			if (this.Image != null)
			{
				PointF pointImage = DrawHelper.GetObjAlignment(this.ImageAlign,txtRect.Left, txtRect.Top, txtRect.Width, txtRect.Height, Image.Width, Image.Height);
				RectangleF imageRect = txtRect;
				imageRect.Intersect(new RectangleF(pointImage, Image.PhysicalDimension));
				//Truncate the Rectangle for appreximation problem
				pe.Graphics.DrawImageUnscaled(Image,Rectangle.Truncate(imageRect));
				//imageAlignment가 Left이면 X이동 Width 감소, Right이면 Width감소
				if (DrawHelper.IsLeft(this.ImageAlign))
				{
					txtRect.X += Image.Width;
					txtRect.Width -= Image.Width;
				}
				else if (DrawHelper.IsRight(this.ImageAlign))
				{
					txtRect.Width -= Image.Width;
				}
			}
			
			//Text Draw
			if ((Text.Length > 0) && (txtRect.Width > 2) && (txtRect.Height > 2))
			{
				SizeF txtSize = DrawHelper.MeasureString(pe.Graphics, Text, Font, this.TextAlign);
				PointF txtPoint = DrawHelper.GetObjAlignment(this.TextAlign, txtRect.Left, txtRect.Top, txtRect.Width, txtRect.Height, txtSize.Width, txtSize.Height);
				// Text
				using (Brush b = new SolidBrush(this.ForeColor.Color))
					pe.Graphics.DrawString(Text, Font, b, txtPoint);
			}
		}
		/// <summary>
		/// Resize Event를 발생시킵니다.
		/// (override) 그리기 영역을 다시 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnResize(System.EventArgs e)
		{
			base.OnResize(e);
			OnParentChanged(e);
		}
		/// <summary>
		/// ParentChanged Event를 발생시킵니다.
		/// (override) 외곽선을 둥글게 그릴때 그리기 영역을 다시 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnParentChanged(System.EventArgs e)
		{
			if (this.Parent == null) return;

			if (edgeRounding)
			{
				int X = this.Width;
				int Y = this.Height;
				int rnd = 1;
				regionPoints = new Point[] {
											   new Point(rnd, 0),
											   new Point(X-rnd, 0),
											   new Point(X-rnd, rnd),
											   new Point(X, rnd),
											   new Point(X, Y-rnd),
											   new Point(X-rnd, Y-rnd),
											   new Point(X-rnd, Y),
											   new Point(rnd, Y),
											   new Point(rnd, Y-rnd),
											   new Point(0, Y-rnd),
											   new Point(0, rnd),
											   new Point(rnd, rnd) };

				GraphicsPath path = new GraphicsPath();
				path.AddLines(regionPoints);

				this.Region = new Region(path);
				path.Dispose();
			}
			else
			{
				base.OnParentChanged(e);
				//Label이 Panel이나 TabPage등 다른 Control의 Control로 들어갈때는 영역이 주어지므로 영역을 다시 계산해야 한다.
				//영역은 Control의 Rectangle 기준
				if (this.Region != null)
					this.Region = new Region(this.ClientRectangle);
			}
		}
		#endregion

		#region Implement IDataControl
		/// <summary>
		/// 편집중인 데이타를 컨트롤의 값으로 설정합니다.
		/// </summary>
		/// <returns> 설정 성공시 true, 실패시 false </returns>
		public virtual bool AcceptData()
		{
			return true;
		}
		/// <summary>
		/// 컨트롤의 값을 Clear합니다.
		/// </summary>
		public void ResetData()
		{
			Text = ConvertText(false, MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits));
            this.SetTooltipText();
		}

		// Dummy Method (Warning 방지용)
		/// <summary>
		/// DataValidating Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 DataValidatingEventArgs </param>
		protected virtual void OnDataValidating(DataValidatingEventArgs e)
		{
			if (DataValidating != null)
				DataValidating(this, e);
		}
		#endregion

		#region ConvertText
		private string ConvertText(bool isValueType, string text)
		{
			//Time형은 AmPmStyle Property에 따라 변경, 그외는 그대로 Return
			//if ((this.editMaskType != MaskType.Time) || !this.amPmStyle)
			if (this.editMaskType != MaskType.Time)
				return text;
			
			string retText = "";
			if (!this.amPmStyle)
			{
				retText = text.Replace("AM","").Replace("PM","").Trim();
				if (text.IndexOf("PM") >= 0) // 01:11:11 PM -> 13:11:11로 변경
					retText = (Int32.Parse(retText.Substring(0,2)) + 12).ToString() + retText.Substring(2);
			}
			else
			{
				try
				{
					if (isValueType)
					{
						retText = text.Replace("AM","").Replace("PM","").Trim();
						if (text.IndexOf("PM") >= 0) // 01:11:11 PM -> 13:11:11로 변경
							retText = (Int32.Parse(retText.Substring(0,2)) + 12).ToString() + retText.Substring(2);
					}
					else
					{
						//00:00:00 -> 00:00:00 PM, 13:00:00 -> 01:00:00 PM, 12:12:00 -> 12:12:00 AM
						int hour = Int32.Parse(text.Substring(0,2));
						if (hour == 0)
							retText = text + " PM";
						else if (hour > 12)
							retText = (hour -12).ToString("00") + text.Substring(2) + " PM";
						else
							retText = text + " AM";
					}
				}
				catch
				{
					retText = text;
				}
			}
			return retText;
		}
		#endregion

		#region Data 가져오기, 설정 Method
		/// <summary>
		/// 해당 컨트롤의 DataValue를 가져옵니다.
		/// </summary>
		/// <returns></returns>
		public string GetDataValue()
		{
			return this.DataValue;
		}
		/// <summary>
		/// 해당 컨트롤의 DataValue를 지정합니다.(이떄 DataChanged는 false로 설정합니다. Validation Check하지 않음)
		/// </summary>
		/// <param name="dataValue"></param>
		public void SetDataValue(object dataValue)
		{
			((IDataControl) this).DataValue = dataValue;
            this.SetTooltipText();
		}
		/// <summary>
		/// 해당 컨트롤의 DataValue를 지정합니다.(이떄 DataChanged는 true로 설정합니다. Validation Check함)
		/// </summary>
		public void SetEditValue(object dataValue)
		{
			((IDataControl) this).DataValue = dataValue;
			this.DataChanged = true;

            this.SetTooltipText();
		}
		#endregion

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-14601
        /// </summary>
        private void SetTooltipText()
        {
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.ShowAlways = true;
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip.SetToolTip(this, this.DataValue);
        }
	}

	#region XDisplayBoxDesigner
	/// <summary>
	/// XDisplayBoxDesigner의 Designer입니다.
	/// </summary>
	internal class XDisplayBoxDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		private bool changeFlag = false;

		/// <summary>
		/// Designer를 초기화 합니다.
		/// </summary>
		/// <param name="component"> Designer를 가진 IComponent 개체 </param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			// Hook up events
			ISelectionService s = (ISelectionService) GetService(typeof(ISelectionService));
			s.SelectionChanged += new EventHandler(OnSelectionChanged);
			IComponentChangeService c = (IComponentChangeService) GetService(typeof(IComponentChangeService));
			c.ComponentChanged += new ComponentChangedEventHandler(OnComponentChanged);
		}

		/// <summary>
		/// 디자이너가 초기화될 때 호출되므로 디자이너는 구성 요소의 속성을 기본값으로 설정
		/// (override) 기본값을 정의하지 않음 
		/// </summary>
		//public override void OnSetComponentDefaults()
		//{
		//}
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            this.Control.Text = "";
        }


		private void OnSelectionChanged(object sender, System.EventArgs e)
		{
			if (!changeFlag)
			{
				ISelectionService s = (ISelectionService) GetService(typeof(ISelectionService));
		
				//Selected된 상태이면 속성 동적으로 변경
				if (s.GetComponentSelected(this.Component))
				{
					changeFlag = true;
					// EditMaskType이 바뀌면 속성 동적으로 변경
					//Refresh를 하면 PreFilterProperties,PostFilterProperties call
					TypeDescriptor.Refresh(this.Component);
				}
			}
		}
		private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
		{
			if (e.Component is XDisplayBox)
			{
				// Control삭제시 OnComponentChanged 발생, 이때 e.Member가 null이므로
				// e.Member Check 해야함
				if (e.Member != null)
				{
					if (e.Member.Name == "EditMaskType")
					{
						changeFlag = true;
						// EditMaskType이 바뀌면 속성 동적으로 변경
						//Refresh를 하면 PreFilterProperties,PostFilterProperties call
						TypeDescriptor.Refresh(this.Component);
					}
				}
			}
		}
		/// <summary>
		/// Designer의 리소스를 해제합니다.
		/// (override) 연결된 EventHandler를 해제합니다.
		/// </summary>
		/// <param name="disposing"> disposing 여부 </param>
		protected override void Dispose(bool disposing)
		{
			ISelectionService s = (ISelectionService) GetService(typeof(ISelectionService));
			IComponentChangeService c = (IComponentChangeService) GetService(typeof(IComponentChangeService));

			// Unhook events
			s.SelectionChanged -= new EventHandler(OnSelectionChanged);
			c.ComponentChanged -= new ComponentChangedEventHandler(OnComponentChanged);
			base.Dispose(disposing);
		}
		/// <summary>
		/// 디자이너에서 TypeDescriptor를 통해 노출되는 속성 집합의 항목을 변경하거나 제거하도록 합니다.
		/// (override) EditMaskType에 따라 속성을 동적으로 변경합니다.
		/// </summary>
		/// <param name="properties"> 구성 요소의 클래스에 대한 속성입니다 </param>
		protected override void PostFilterProperties(System.Collections.IDictionary properties)
		{
			// MaskType속성 변경시만 Property Change
			if (changeFlag && (this.Control != null) && (this.Control is XDisplayBox))
			{
				XDisplayBox dBox = (XDisplayBox) this.Control;
				switch (dBox.EditMaskType)
				{
					case MaskType.String:
						// Number관련 속성 Remove
						properties.Remove("DecimalDigits");
						properties.Remove("GeneralNumberFormat");
						//Time 관련속성
						properties.Remove("AmPmStyle");
						//2006.01.09 Date,Month 속성 관련
						properties.Remove("IsJapanYearType");
						properties.Remove("InvalidDateIsStringEmpty");  //Date관련 속성
						break;
					case MaskType.DateTime:
						// Number관련 속성 Remove
						properties.Remove("DecimalDigits");
						properties.Remove("GeneralNumberFormat");
						//Time 관련속성
						properties.Remove("AmPmStyle");
						//2006.01.09 Date,Month 속성 관련
						properties.Remove("IsJapanYearType");
						break;
					case MaskType.Date:
					case MaskType.Month:
						// Number관련 속성 Remove
						properties.Remove("DecimalDigits");
						properties.Remove("GeneralNumberFormat");
						//Time 관련속성
						properties.Remove("AmPmStyle");
						break;
					case MaskType.Time:
						// Number관련 속성 Remove
						properties.Remove("DecimalDigits");
						properties.Remove("GeneralNumberFormat");
						//2006.01.09 Date,Month 속성 관련
						properties.Remove("IsJapanYearType");
						break;
					case MaskType.Number:
						// Mask, DecimalDigits Remove
						properties.Remove("DecimalDigits");
						properties.Remove("Mask");
						//Time 관련속성
						properties.Remove("AmPmStyle");
						//2006.01.09 Date,Month 속성 관련
						properties.Remove("IsJapanYearType");
						properties.Remove("InvalidDateIsStringEmpty");  //Date관련 속성
						break;
					case MaskType.Decimal:
						//Mask Remove
						properties.Remove("Mask");
						//Time 관련속성
						properties.Remove("AmPmStyle");
						//2006.01.09 Date,Month 속성 관련
						properties.Remove("IsJapanYearType");
						properties.Remove("InvalidDateIsStringEmpty");  //Date관련 속성
						break;
				}
			}
			
			base.PostFilterProperties(properties);
		}
		/// <summary>
		/// 구성 요소가 TypeDescriptor를 통해 노출하는 속성 집합을 조정합니다.
		/// (override) EditMaskType에 따른 동적변경속성을 추가합니다.
		/// </summary>
		/// <param name="properties"> 구성 요소의 클래스에 대한 속성입니다 </param>
		protected override void PreFilterProperties(System.Collections.IDictionary properties)
		{
			base.PreFilterProperties(properties);
			// 동적으로 변경할 Property Add
			if ((this.Control != null) && (this.Control is XDisplayBox))
			{
				XDisplayBox dBox = (XDisplayBox) this.Control;
				if (!properties.Contains("Mask"))
					properties.Add("Mask", dBox.Mask);
				if (!properties.Contains("DecimalDigits"))
					properties.Add("DecimalDigits", dBox.DecimalDigits);
				if (!properties.Contains("AmPmStyle"))
					properties.Add("AmPmStyle", dBox.AmPmStyle);
				if (!properties.Contains("GeneralNumberFormat"))
					properties.Add("GeneralNumberFormat", dBox.GeneralNumberFormat);
				if (!properties.Contains("IsJapanYearType"))
					properties.Add("IsJapanYearType", dBox.IsJapanYearType);
				if (!properties.Contains("InvalidDateIsStringEmpty"))
					properties.Add("InvalidDateIsStringEmpty", dBox.InvalidDateIsStringEmpty);
			}
		}
	}
	#endregion
}
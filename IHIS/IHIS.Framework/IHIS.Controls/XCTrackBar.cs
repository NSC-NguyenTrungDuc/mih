using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace IHIS.Framework
{
	#region Enums
	public enum XCTrackBarStyle
	{
		Round,  //원모양
		Square  //사각형모양
	}
	#endregion

	#region XCTrackBar
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	[ToolboxBitmap(typeof(TrackBar))]
	[DefaultEvent("ValueChanged")]
	[Designer(typeof(XCTrackBarDesigner))]
	public class XCTrackBar : System.Windows.Forms.Control, IDataControl
	{
		/// <summary>
		/// Required designer variable.TODO
		/// </summary>
		#region Private Fields
		private int trackerSize= 10;
		private XCTrackBarStyle cornerStyle= XCTrackBarStyle.Square;
		private Orientation orientation = Orientation.Horizontal;
		private XColor barBorderColor = XColor.XCTrackBarBorderColor;
		private XColor barColor = XColor.XCTrackBarColor;
		private XColor trackerBorderColor= XColor.XCTrackBarTrackerBorderColor;
		private XColor trackerColor = XColor.XCTrackBarTrackerColor;
		private int trackerValue = 0;
		private int mininum=0;
		private int maxinum=100;
		private bool	dataChanged = false;
		private bool	enterKeyToTab	= true;	//Enter Key를 누르면 TAB Key를 발생시킬지 여부
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		
		private int borderWidth = 1;
		private Rectangle trackRect= Rectangle.Empty;
		private int mousestartPos = -1;
		private bool leftbuttonDown=false;
		#endregion

		#region Public Properites
		[Browsable(true),Category("추가속성"),DefaultValue(10),
		MergableProperty(true),
		Description("TrackBar의 위치를 표시하는 Tracker의 Size를 표시합니다.(Round모양은 크기에 관계없이 Size설정됨)")]
		public int TrackerSize
		{
			get	{ return trackerSize;}
			set
			{
				//최소 5이상
				if (trackerSize != value)
				{
					//Round형식이면 Orientation에 따라 너비,높이로 설정
					if(cornerStyle==XCTrackBarStyle.Round)
					{
						switch(orientation)
						{
							case Orientation.Horizontal:
								value=this.Height;
								break;
							case Orientation.Vertical:
								value=this.Width;
								break;
						}
					}
					else
					{
						trackerSize = Math.Max(5, value);
						//최대높이 기준
						switch(orientation)
						{
							case Orientation.Horizontal:
								if(value > ClientRectangle.Width/2)
									trackerSize = ClientRectangle.Width/2;
								break;
							case Orientation.Vertical:
								if(value > ClientRectangle.Height/2)
									value = ClientRectangle.Height/2;
								break;
						}
					}
					trackerSize=value;
					trackRect=Rectangle.Empty;
					this.Invalidate();
				}
			}
		}
		[Browsable(true),Category("추가속성"),DefaultValue(0),
		MergableProperty(true),
		Description("트렉표시줄에서 슬라이트 위치의 최소값을 지정합니다.")]
		public int Minimum
		{
			get{ return this.mininum; }
			set
			{
				if (mininum != value)
				{
					mininum = Math.Min(value, maxinum);  //Max 보다는 작아야 함.
					//TrackerValue는 min보다 커야함
					this.trackerValue = Math.Max(this.trackerValue, mininum);
					trackRect=Rectangle.Empty;
					this.Invalidate();
				}
			}
			
		}
		[Browsable(true),Category("추가속성"),DefaultValue(100),
		MergableProperty(true),
		Description("트렉표시줄에서 슬라이트 위치의 최대값을 지정합니다.")]
		public int Maximum
		{
			get{ return this.maxinum; }
			set
			{
				if (maxinum != value)
				{
					maxinum = Math.Max(value, mininum);  //Min 보다는 커야함.
					//TrackerValue는 max보다 작아야함.
					this.trackerValue = Math.Min(this.trackerValue, maxinum);
					trackRect=Rectangle.Empty;
					this.Invalidate();
				}
			}
		}
		[Browsable(true),Category("추가속성"),DefaultValue(Orientation.Horizontal),
		MergableProperty(true),
		Description("트랙바의 방향을 표시합니다.")]
		public Orientation Orientation
		{
			get{ return this.orientation; }
			set
			{
				if (orientation != value)
				{
					this.orientation = value;
					//Size 조정
					base.Size=new Size(base.Size.Height,base.Size.Width); 
					trackRect=Rectangle.Empty;
					this.Invalidate();
				}
			}
		}
		[Browsable(true),Category("추가속성"),DefaultValue(XCTrackBarStyle.Square),
		MergableProperty(true),
		Description("트랙바의 Corner의 모양을 지정합니다.")]
		public XCTrackBarStyle CornerStyle
		{
			get{ return this.cornerStyle; }
			set
			{
				if (cornerStyle != value)
				{
					this.cornerStyle = value;
					//Orientation에 따라 tracker Size 다시 조정
					switch(orientation)
					{
						case Orientation.Horizontal:
							if(value == XCTrackBarStyle.Round)
							{
								if(this.Width < this.Height)
									this.Width = this.Height;
								this.trackerSize = this.Height;
							}
							break;
						case Orientation.Vertical:
							if(value==XCTrackBarStyle.Round)
							{
								if(this.Height<this.Width)
									this.Height=this.Width;
								this.trackerSize=this.Width;
							}
							break;
						default:
							break;
					}
				
					trackRect=Rectangle.Empty;
					this.Invalidate();

				}
			}
			
		}
		[Browsable(true),Category("추가속성"),DefaultValue(0),
		MergableProperty(true),
		Description("트랙바의 Value를 지정합니다.")]
		public int Value
		{
			get { return trackerValue; }
			set
			{
				if (trackerValue != value)
				{
					trackerValue = Math.Max(mininum, Math.Min(value, maxinum));
					trackRect = Rectangle.Empty;
					//Value changed Event Call
					this.OnValueChanged();
					this.Invalidate();
				}
			}
		}

		[DefaultValue(typeof(XColor),"XCTrackBarBorderColor"),
		Description("트랙바 보더색을 지정합니다.")]
		public XColor BarBorderColor
		{
			get { return this.barBorderColor;}
			set
			{
				if (barBorderColor != value)
				{
					barBorderColor = value;
					this.Invalidate();
				}
			}
		}
		[DefaultValue(typeof(XColor),"XCTrackBarColor"),
		Description("트랙바 배경색을 지정합니다.")]
		public XColor BarColor
		{
			get { return this.barColor;}
			set
			{
				if (barColor != value)
				{
					barColor = value;
					this.Invalidate();
				}	
			}
		}
		
		[DefaultValue(typeof(XColor),"XCTrackBarTrackerBorderColor"),
		Description("트랙바 Tracker Border색을 지정합니다.")]
		public XColor TrackerBorderColor
		{
			get { return this.trackerBorderColor;}
			set
			{
				if (trackerBorderColor != value)
				{
					trackerBorderColor = value;
					this.Invalidate();
				}	
			}
		}
		[DefaultValue(typeof(XColor),"XCTrackBarTrackerColor"),
		Description("트랙바 Tracker의 배경색을 지정합니다.")]
		public XColor TrackerColor
		{
			get { return this.trackerColor;}
			set
			{
				if (trackerColor != value)
				{
					trackerColor = value;
					this.Invalidate();
				}	
			}
		}
		object IDataControl.DataValue
		{
			get	{ return this.DataValue; }
			set	
			{ 
				this.DataValue = (value == null ? "" : value.ToString());
				//IDataControl을 통해서 DataValue 설정시는 DataChanged = false (DataValidating Event call하지 않음)
				this.DataChanged = false;
			}
		}
		ControlDataType IDataControl.ContType
		{
			get{return ControlDataType.Number;}
		}
		/// <summary>
		/// 컨트롤이 편집가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("Protect속성을 지정합니다.")]
		public bool Protect
		{ 
			get { return !Enabled;}
			set 
			{ 
				this.Enabled = !value;
				this.TabStop = !value;
			}
		}
		/// <summary>
		/// Enter Key를 입력시 TAB Key를 발생시킬지 여부를 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("Enter Key를 입력시 TAB Key를 발생시킬지 여부를 설정합니다.")]
		public bool EnterKeyToTab
		{
			get { return enterKeyToTab; }
			set { enterKeyToTab = value;}
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
		/// DataValue는 외부로 노출하지 않고, Method(GetDataValue, SetDataValue(..)를 통해 접근함.
		/// </summary>
		protected virtual string DataValue
		{
			get	{ return this.Value.ToString(); }
			set	
			{ 
				//IntType 일때만 SET
				if (TypeCheck.IsInt(value))
					this.Value = Convert.ToInt32(value);
			}
		}
		/// <summary>
		/// 컨트롤의 값이 변경되었는지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		DefaultValue(false)]
		public bool DataChanged
		{
			get { return dataChanged; }
			set { dataChanged = value;}
		}
		#endregion

		#region Events
		/// <summary>
		/// Fires when track bar posotion has changed
		/// </summary>
		[Description("컨트롤의 값이 변경될때 발생하는 Event 입니다.")]
		[Category("추가속성")]
		public event EventHandler ValueChanged;
		/// <summary>
		/// Fires when track bar changes positions
		/// </summary>
		[Description("Event fires when the Trackbar position is changed")]
		[Category("추가속성")]
		public event EventHandler Scroll;
		/// <summary>
		/// 데이타 유효성검사가 진행될 때 발생하는 Event입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("데이타 유효성검사가 진행될 때 발생합니다.")]
		public event DataValidatingEventHandler DataValidating;
		#endregion

		#region Event Invoker
		protected virtual void OnScroll()
		{
			if (Scroll != null)
			{
				Scroll(this, EventArgs.Empty);
			}
		}
		protected virtual void OnValueChanged()
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, EventArgs.Empty);
			}
			dataChanged = true;
		}
		#endregion

		#region Position Macros
		public static ushort LowWord(uint value)
		{    
			return (ushort)(value & 0xFFFF);
		}
		public static ushort HighWord(uint value)
		{    
			return (ushort)(value >> 16);
		}
		#endregion


		#region WndProc
		protected override void WndProc(ref Message m)
		{
			//WM_LBUTTONDOWN
			#region WM_LBUTTONDOWN
			if(m.Msg== (int) Win32.Msgs.WM_LBUTTONDOWN)
			{
				Point CurPoint=new Point(LowWord((uint)m.LParam),HighWord((uint)m.LParam));
				if(trackRect.Contains(CurPoint))
				{
					if(!leftbuttonDown)
					{
						leftbuttonDown=true;
						switch(this.orientation)
						{
							case Orientation.Horizontal:
								mousestartPos= CurPoint.X-trackRect.X;
								break;
							case Orientation.Vertical:
								mousestartPos= CurPoint.Y-trackRect.Y;
								break;
						}
					}
				}
				else
				{
					int OffSet=0;
					switch(this.orientation)
					{
						case Orientation.Horizontal:
							if(trackRect.Right+(CurPoint.X-trackRect.X-(trackRect.Width/2))>=this.Width)
								OffSet=this.Width-trackRect.Right-1;
							else if(trackRect.Left+(CurPoint.X-trackRect.X-(trackRect.Width/2))<=0)
								OffSet=(trackRect.Left-1)*-1;
							else
								OffSet=CurPoint.X-trackRect.X-(trackRect.Width/2);
							trackRect.Offset(OffSet,0);
							trackerValue=(int)( ((trackRect.X-1) * (maxinum-mininum))/(this.Width-trackerSize-2));
							break;
						case Orientation.Vertical:
							if(trackRect.Bottom+(CurPoint.Y-trackRect.Y-(trackRect.Height/2))>=this.Height)
								OffSet=this.Height-trackRect.Bottom-1;
							else if(trackRect.Top+(CurPoint.Y-trackRect.Y-(trackRect.Height/2))<=0)
								OffSet=(trackRect.Top-1)*-1;
							else
								OffSet=CurPoint.Y-trackRect.Y-(trackRect.Height/2);
							trackRect.Offset(0,OffSet);
							trackerValue=(int)( ((trackRect.Y-1) * (maxinum-mininum))/(this.Height-trackerSize-2));
							break;
						default:
							break;
					}
					trackerValue+=mininum;
					this.Invalidate();
					if(OffSet!=0)
					{
						OnScroll();
						OnValueChanged();
					}
				}
				this.Focus();
			}
			#endregion

			#region WM_LBUTTONUP
			if(m.Msg == (int) Win32.Msgs.WM_LBUTTONUP)
			{
				leftbuttonDown=false;
			}
			#endregion

			#region WM_MOUSEMOVE
			//WM_MOUSEMOVE
			if(m.Msg==(int) Win32.Msgs.WM_MOUSEMOVE)
			{
				int OldValue=trackerValue;
				Point CurPoint=new Point(LowWord((uint)m.LParam),HighWord((uint)m.LParam));
				if(leftbuttonDown && ClientRectangle.Contains(CurPoint))
				{
					int OffSet=0;
					try
					{
						switch(this.orientation)
						{
							case Orientation.Horizontal:
								if(trackRect.Right+(CurPoint.X-trackRect.X-mousestartPos)>=this.Width)
									OffSet=this.Width-trackRect.Right-1;
								else if(trackRect.Left+(CurPoint.X-trackRect.X-mousestartPos)<=0)
									OffSet=(trackRect.Left-1)*-1;
								else
									OffSet=CurPoint.X-trackRect.X-mousestartPos;
								trackRect.Offset(OffSet,0);
								trackerValue=(int)( ((trackRect.X-1) * (maxinum-mininum))/(this.Width-trackerSize-2));
								break;
							case Orientation.Vertical:
								if(trackRect.Bottom+(CurPoint.Y-trackRect.Y-mousestartPos)>=this.Height)
									OffSet=this.Height-trackRect.Bottom-1;
								else if(trackRect.Top+(CurPoint.Y-trackRect.Y-mousestartPos)<=0)
									OffSet=(trackRect.Top-1)*-1;
								else
									OffSet=CurPoint.Y-trackRect.Y-mousestartPos;
								trackRect.Offset(0,OffSet);
								trackerValue=(int)( ((trackRect.Y-1) * (maxinum-mininum))/(this.Height-trackerSize-2));
								break;
						}

					}
					catch(Exception){}
					finally
					{
						//force redraw
						trackerValue+=mininum;
						this.Invalidate();
						if(OffSet!=0)
						{
							OnScroll();
							OnValueChanged();
						}
					}
				}
			}
			#endregion
			base.WndProc (ref m);
		}
		#endregion

		#region Class Consruct and Dispose
		public XCTrackBar()
		{
			//set initla size
			base.Size = new Size(100,20);
			//set styles
			SetStyle(ControlStyles.AllPaintingInWmPaint |ControlStyles.ResizeRedraw |ControlStyles.UserPaint|
				ControlStyles.DoubleBuffer|ControlStyles.SupportsTransparentBackColor,true);
			//set cursor
			this.Cursor=Cursors.Hand;
		}
		#endregion

		#region Overrides
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			if (this.enterKeyToTab && e.KeyChar == (char)13)
			{
				SendKeys.Send("{TAB}");
			}
		}
		/// <summary>
		/// Validating Event를 발생시킵니다.
		/// (override) 데이타 변경시 DataValidating Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 CancelEventArgs </param>
		protected override void OnValidating(CancelEventArgs e)
		{
			if (dataChanged)
			{
				DataValidatingEventArgs ve = new DataValidatingEventArgs(e.Cancel, DataValue);
				OnDataValidating(ve);
				e.Cancel = ve.Cancel;
			}
			base.OnValidating(e);
			//Cancel이 아니면 dataChanged Clear
			if (!e.Cancel)
				dataChanged = false;
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			trackRect = Rectangle.Empty;
			base.OnSizeChanged (e);
			OnParentChanged(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			DrawControl(e.Graphics);
			base.OnPaint (e);
		}
		/// <summary>
		/// ParentChanged Event를 발생시킵니다.
		/// (override) 외곽선을 둥글게 그릴때 그리기 영역을 다시 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnParentChanged(System.EventArgs e)
		{
			if (this.Parent == null) return;

			if (this.cornerStyle == XCTrackBarStyle.Round)
			{
				int X = this.Width;
				int Y = this.Height;
				int rnd = 1;
				Point[] points = new Point[] {
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
				path.AddLines(points);

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
			if (dataChanged)
			{
				DataValidatingEventArgs ve = new DataValidatingEventArgs(false, DataValue);
				//2006.05.02 Call전에 DataChanged Flag Clear (DataValidating Event에서 AcceptData를 호출하는 Logic이 들어가는 경우 무한 Loop방지)
				dataChanged = false;
				OnDataValidating(ve);
				//Cancel시에 Flag 다시 설정
				if (ve.Cancel)
					dataChanged = true;

				return !ve.Cancel;
			}
			else
				return true;
		}
		/// <summary>
		/// 컨트롤의 값을 Clear합니다.
		/// </summary>
		public void ResetData()
		{
			this.Value = this.Minimum;
			dataChanged = false;
		}
		/// <summary>
		/// DataValidating Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 ValidateEventArgs </param>
		protected virtual void OnDataValidating(DataValidatingEventArgs e)
		{
			if (DataValidating != null)
				DataValidating(this, e);
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
		}
		/// <summary>
		/// 해당 컨트롤의 DataValue를 지정합니다.(이떄 DataChanged는 true로 설정합니다. Validation Check함)
		/// </summary>
		public void SetEditValue(object dataValue)
		{
			((IDataControl) this).DataValue = dataValue;
			this.DataChanged = true;
		}
		#endregion

		#region Drawing GDI+
		private void DrawControl(Graphics g)
		{
			bool newRect = false;
			if(trackRect == Rectangle.Empty)
				newRect = true;
			try
			{
				//get parent color
				Color parentColor = SystemColors.Control;
				if(this.Parent!=null)
					parentColor = this.Parent.BackColor;
				switch (orientation)
				{
					case Orientation.Horizontal:
						if(trackRect == Rectangle.Empty)
						{
							int trackX = (int)(((trackerValue-mininum)*(ClientRectangle.Width-trackerSize)) / (maxinum-mininum));
							//don't go past the borders
							if(trackX==0)
								trackX++;
							if(trackX+trackerSize==ClientRectangle.Width)
								trackX--;
							trackRect = new Rectangle(trackX,1,trackerSize,ClientRectangle.Height-2);
						}
						break;

					case Orientation.Vertical:
						if(trackRect==Rectangle.Empty)
						{
							int trackY = (int)(((trackerValue-mininum)*(ClientRectangle.Height-trackerSize)) / (maxinum-mininum));
							//don't go past the borders
							if(trackY==0)
								trackY++;
							if(trackY+ClientRectangle.Width==ClientRectangle.Height)
								trackY--;
							trackRect = new Rectangle(1,trackY,ClientRectangle.Width-2,trackerSize);
						}
						break;
					default:
						break;
				}
				Region trackRegion=null;
				Region barRegion=null;
				switch (cornerStyle)
				{
					case XCTrackBarStyle.Square:
						PaintRectangle(ClientRectangle,barColor.Color,barBorderColor.Color,g);
						barRegion=new Region(ClientRectangle);
						trackRegion = new Region(trackRect);
						PaintRectangle(trackRect,trackerColor.Color,trackerBorderColor.Color,g);		
						break;
					case XCTrackBarStyle.Round:
						//first draw bar
						GraphicsPath BarPath=DrawRoundCorners(ClientRectangle,barBorderColor.Color,g);
						barRegion = new Region(BarPath);
						PaintPath(BarPath,barColor.Color ,g);
						//check if tracker size is correct
						if(trackRect.Width!=trackRect.Height)
						{
							if(orientation==Orientation.Horizontal)
							{
								trackRect = new Rectangle(trackRect.Location,
									new Size(ClientRectangle.Height,ClientRectangle.Height-2));
							}
							else
							{
								trackRect = new Rectangle(trackRect.Location,
									new Size(ClientRectangle.Width-2,ClientRectangle.Width));
							}
						}
						//now draw Tracker
						GraphicsPath TrackPath = DrawRoundCorners(trackRect,trackerBorderColor.Color,g);
						trackRegion = new Region(TrackPath);
						PaintPath(TrackPath,trackerColor.Color,g);
						break;
					default:
						break;
				}

			}
			catch(Exception Err)
			{
				throw new Exception("DrawBackGround Error: "+Err.Message);
			}
			finally
			{
				if(newRect)
				{
					OnScroll();
					OnValueChanged();
				}
			}
		}
		
		private void PaintRectangle(Rectangle Rect,Color RectColor,Color RectBorderColor,Graphics g)
		{
			//draw rectangle
			Pen LinePen = new Pen(RectBorderColor, borderWidth);
			g.DrawRectangle(LinePen,new Rectangle(Rect.X,Rect.Y,Rect.Width-1,Rect.Height-1));
			LinePen.Dispose();
			Rect = new Rectangle(Rect.X+1,Rect.Y+1,Rect.Width-2,Rect.Height-2);
			//
			// Fill background
			//
			SolidBrush bgBrush = new SolidBrush(ControlPaint.Dark(RectColor));
			g.FillRectangle(bgBrush, Rect);
			bgBrush.Dispose();
			
			//
			// The gradient brush
			//
			LinearGradientBrush brush;
			Rectangle FirstRect,SecondRect;
			switch(orientation)
			{
				case Orientation.Horizontal:
					FirstRect= new Rectangle(Rect.X,Rect.Y, Rect.Width, Rect.Height / 2);
					SecondRect=new Rectangle(Rect.X, Rect.Height / 2, Rect.Width, Rect.Height / 2);
					// Paint upper half
					brush = new LinearGradientBrush(
						new Point(FirstRect.Width/2,FirstRect.Top),
						new Point(FirstRect.Width/2,FirstRect.Bottom),
						ControlPaint.Dark(RectColor),
						RectColor);
					g.FillRectangle(brush, FirstRect);
					brush.Dispose();
					// Paint lower half
					// (SecondRect.Y - 1 because there would be a dark line in the middle of the bar)
					brush = new LinearGradientBrush(
						new Point(SecondRect.Width/2, SecondRect.Top-1),
						new Point(SecondRect.Width/2, SecondRect.Bottom), 
						RectColor, 
						ControlPaint.Dark(RectColor));
					g.FillRectangle(brush, SecondRect);
					brush.Dispose();
					
					break;
				case Orientation.Vertical:
					FirstRect= new Rectangle(Rect.X,Rect.Y, Rect.Width/2, Rect.Height);
					SecondRect=new Rectangle(Rect.Width / 2,Rect.Y, Rect.Width/2, Rect.Height);
					// Paint left half
					brush = new LinearGradientBrush(
						new Point(FirstRect.Left, FirstRect.Height/2),
						new Point(FirstRect.Right,FirstRect.Height/2),
						ControlPaint.Dark(RectColor),
						RectColor);
					g.FillRectangle(brush, FirstRect);
					brush.Dispose();
					// Paint right half
					// (SecondRect.X - 1 because there would be a dark line in the middle of the bar)
					brush = new LinearGradientBrush(
						new Point(SecondRect.Left - 1,SecondRect.Height/2),
						new Point(SecondRect.Right,SecondRect.Height/2),
						RectColor, 
						ControlPaint.Dark(RectColor));
					g.FillRectangle(brush, SecondRect);
					brush.Dispose();
					break;
				default:
					break;
			}
		}
		private void PaintPath(GraphicsPath PaintPath,Color PathColor,Graphics g)
		{
			Region FirstRegion,SecondRegion;
			FirstRegion = new Region(PaintPath);
			SecondRegion= new Region(PaintPath);
			//
			// Fill background
			//
			SolidBrush bgBrush = new SolidBrush(ControlPaint.Dark(PathColor));
			g.FillRegion(bgBrush, new Region(PaintPath));
			bgBrush.Dispose();

			//
			// The gradient brush
			//
			LinearGradientBrush brush;
			Rectangle FirstRect,SecondRect;
			Rectangle RegionRect = Rectangle.Truncate(PaintPath.GetBounds());
			switch(orientation)
			{
				case Orientation.Horizontal:
					FirstRect= new Rectangle(RegionRect.X,RegionRect.Y, RegionRect.Width, RegionRect.Height / 2);
					SecondRect=new Rectangle(RegionRect.X, RegionRect.Height / 2, RegionRect.Width, RegionRect.Height / 2);
					//only get the bar region
					FirstRegion.Intersect(FirstRect);
					SecondRegion.Intersect(SecondRect);
					// Paint upper half
					brush = new LinearGradientBrush(
						new Point(FirstRect.Width/2,FirstRect.Top),
						new Point(FirstRect.Width/2,FirstRect.Bottom),
						ControlPaint.Dark(PathColor),
						PathColor);
					g.FillRegion(brush, FirstRegion);
					brush.Dispose();
					// Paint lower half
					// (SecondRect.Y - 1 because there would be a dark line in the middle of the bar)
					brush = new LinearGradientBrush(
						new Point(SecondRect.Width/2, SecondRect.Top-1),
						new Point(SecondRect.Width/2, SecondRect.Bottom), 
						PathColor, 
						ControlPaint.Dark(PathColor));
					g.FillRegion(brush, SecondRegion);
					brush.Dispose();
					
					break;
				case Orientation.Vertical:
					FirstRect= new Rectangle(RegionRect.X,RegionRect.Y, RegionRect.Width/2, RegionRect.Height);
					SecondRect=new Rectangle(RegionRect.Width / 2,RegionRect.Y, RegionRect.Width/2, RegionRect.Height);
					//only get the bar region
					FirstRegion.Intersect(FirstRect);
					SecondRegion.Intersect(SecondRect);
					// Paint left half
					brush = new LinearGradientBrush(
						new Point(FirstRect.Left, FirstRect.Height/2),
						new Point(FirstRect.Right,FirstRect.Height/2),
						ControlPaint.Dark(PathColor),
						PathColor);
					g.FillRegion(brush, FirstRegion);
					brush.Dispose();
					// Paint right half
					// (SecondRect.X - 1 because there would be a dark line in the middle of the bar)
					brush = new LinearGradientBrush(
						new Point(SecondRect.Left - 1,SecondRect.Height/2),
						new Point(SecondRect.Right,SecondRect.Height/2),
						PathColor, 
						ControlPaint.Dark(PathColor));
					g.FillRegion(brush, SecondRegion);
					brush.Dispose();
					break;
				default:
					break;
			}
		}
		private GraphicsPath DrawRoundCorners(Rectangle Rect,Color BorderColor,Graphics g)
		{
			GraphicsPath gPath = new GraphicsPath();
			try
			{
				Pen LinePen = new Pen(BorderColor,borderWidth+1);
				switch(orientation)
				{
					case Orientation.Horizontal:
						Rectangle LeftRect,RightRect;
						LeftRect=new Rectangle(Rect.X,Rect.Y+1,Rect.Height-1,Rect.Height-2);
						RightRect = new Rectangle(Rect.X+(Rect.Width-Rect.Height),Rect.Y+1,Rect.Height-1,Rect.Height-2);
						//build shape
						
						gPath.AddArc(LeftRect,90,180);
						gPath.AddLine(
							LeftRect.X+LeftRect.Width/2+2,LeftRect.Top+1,
							RightRect.X+(RightRect.Width/2)-1,RightRect.Top+1);
						gPath.AddArc(RightRect,270,180);
						gPath.AddLine(RightRect.X+(RightRect.Width/2),RightRect.Bottom,LeftRect.X+(LeftRect.Width/2),LeftRect.Bottom);
						
						gPath.CloseFigure();
						g.DrawPath(LinePen,gPath);
						break;
					case Orientation.Vertical:
						Rectangle TopRect,BotRect;
						TopRect=new Rectangle(Rect.X+1,Rect.Y,Rect.Width-2,Rect.Width-1);
						BotRect = new Rectangle(Rect.X+1,Rect.Y+(Rect.Height-Rect.Width),Rect.Width-2,Rect.Width-1);
						//build shape
						gPath.AddArc(TopRect,180,180);
						gPath.AddLine(TopRect.Right,TopRect.Y+TopRect.Height/2,BotRect.Right,BotRect.Y+BotRect.Height/2+1);
						gPath.AddArc(BotRect,0,180);
						gPath.AddLine(BotRect.Left+1,BotRect.Y+BotRect.Height/2-1,
							TopRect.Left+1,TopRect.Y+TopRect.Height/2+2);
						gPath.CloseFigure();
						g.DrawPath(LinePen,gPath);
						break;
					default:
						break;
				}
			}
			catch(Exception Err)
			{
				throw new Exception("DrawRoundCornersException: "+Err.Message);
			}
			return gPath;

		}
		#endregion
	}
	#endregion

	#region XCTrackBar Designer
	internal class XCTrackBarDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		public XCTrackBarDesigner()
		{}

		// clean up some unnecessary properties
		protected override void PostFilterProperties(IDictionary Properties)
		{
			Properties.Remove("AllowDrop");
			Properties.Remove("BackgroundImage");
			Properties.Remove("ContextMenu");
			Properties.Remove("FlatStyle");
			Properties.Remove("Image");
			Properties.Remove("ImageAlign");
			Properties.Remove("ImageIndex");
			Properties.Remove("ImageList");
			Properties.Remove("Text");
			Properties.Remove("TextAlign");
			Properties.Remove("BackColor");
			Properties.Remove("Font");
			Properties.Remove("ForeColor");
			Properties.Remove("Cursor");
		}
		protected override void PostFilterEvents(IDictionary events)
		{
			//actions
			events.Remove("Click");
			events.Remove("DoubleClick");
			//appearence
			events.Remove("Paint");
			//behavior
			events.Remove("ChangeUICues");
			events.Remove("ImeModeChanged");
			events.Remove("QueryAccessibilityHelp");
			events.Remove("StyleChanged");
			events.Remove("SystemColorsChanged");
			//Drag Drop
			events.Remove("DragDrop");
			events.Remove("DragEnter");
			events.Remove("DragLeave");
			events.Remove("DragOver");
			events.Remove("GiveFeedback");
			events.Remove("QueryContinueDrag");
			events.Remove("DragDrop");
			//layout
			events.Remove("Layout");
			events.Remove("Move");
			events.Remove("Resize");
			//PropertyChanged
			events.Remove("BackColorChanged");
			events.Remove("BackgroundImageChanged");
			events.Remove("BindingContextChanged");
			events.Remove("CausesValidationChanged");
			events.Remove("CursorChanged");
			events.Remove("FontChanged");
			events.Remove("ForeColorChanged");
			events.Remove("RightToLeftChanged");
			events.Remove("SizeChanged");
			events.Remove("TextChanged");
			
			base.PostFilterEvents (events);
		}

	}
	#endregion
}

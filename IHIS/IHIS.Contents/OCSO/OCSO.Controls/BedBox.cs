using System;
using System.Net;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using IHIS.Framework;

namespace IHIS.OCSO
{
	/// <summary>
	/// BedBox(ｺｴｻﾇ ﾈｯﾀﾚ Display)ｿ｡ ｴ・ﾑ ｿ萓・ｼｳｸ暲ﾔｴﾏｴﾙ.
	/// </summary>
	internal class BedBox : System.Windows.Forms.PictureBox
	{
		#region enum (BedBoxﾀﾇ ﾇ・Mouse Overｻﾂ)
		private enum States
		{
			Normal, //ﾁ､ｻﾂ
			SuNameMouseOver,   //ﾈｯﾀﾚﾀﾌｸｧMouseOver
			BottomLeftMouseOver //ﾃﾟｰ｡Orderｿｵｿｪ MouseOver
		}
		#endregion

		#region ｱﾗｸｮｱ・ｰ・ﾃ Fields
		const int BEDNUMBER_WIDTH = 10;
		const int TITLE_WIDTH = 80;
		const int TITLE_HEIGHT = 20;
		const int BOTTOM_HEIGHT = 16;
		const int WIDTH_GAP = 2;  //TITLEｰ・Statusｻ鄲ﾌﾀﾇ Gap
		const int STATUS_WIDTH = 10;
		const int STATUS_HEIGHT = 17;
		const int STATUS_GAP = 2;
		private Font numberFont = new Font("MS UI Gothic", 8.0f);
		private Font titleFont = new Font("MS UI Gothic", 10.0f);
		private Pen rectPen = Pens.White;
		private Rectangle suNameBounds = new Rectangle(BEDNUMBER_WIDTH, 0, TITLE_WIDTH, TITLE_HEIGHT); //MouseOverｽﾃｿ｡ ﾈｯﾀﾚﾀﾌｸｧ ｿｵｿｪ
		private Rectangle bottomLeftBounds = new Rectangle(BEDNUMBER_WIDTH, TITLE_HEIGHT, TITLE_WIDTH/2, BOTTOM_HEIGHT); //ﾃﾟｰ｡OrderｹﾟｻDisplayｿｵｿｪ
		private SolidBrush textBrush = new SolidBrush(Color.FromArgb(86,41,0));
		private SolidBrush bedStatus1Brush = new SolidBrush(Color.FromArgb(219,219,219));
		private SolidBrush bedStatus2Brush = new SolidBrush(Color.FromArgb(236,232,185));
		private SolidBrush bedStatus3Brush = new SolidBrush(Color.FromArgb(138,255,0));
		private SolidBrush bedStatus4Brush = new SolidBrush(Color.FromArgb(255,0,102));
		private SolidBrush manBrush = new SolidBrush(Color.FromArgb(140,207,215));
		private SolidBrush womanBrush = new SolidBrush(Color.FromArgb(229,187,149));
		private SolidBrush emptyBedBrush = new SolidBrush(Color.FromArgb(219,219,219));
		private SolidBrush bLStatus1Brush = new SolidBrush(Color.FromArgb(226,255,248));
		private SolidBrush bLStatus2Brush = new SolidBrush(Color.FromArgb(98,196,172));
		private SolidBrush bRStatus1Brush = new SolidBrush(Color.FromArgb(255,237,252));
		private SolidBrush bRStatus2Brush = new SolidBrush(Color.FromArgb(218,147,216));
		private SolidBrush rTStatus1Brush = new SolidBrush(Color.FromArgb(255,125,1));
		private SolidBrush rTStatus2Brush = new SolidBrush(Color.FromArgb(255,255,0));
		private SolidBrush rTStatus3Brush = new SolidBrush(Color.FromArgb(255,0,0)); 
		private SolidBrush rBStatus1Brush = new SolidBrush(Color.FromArgb(101,159,255));
		private SolidBrush rBStatus2Brush = new SolidBrush(Color.FromArgb(148,101,255));
		private SolidBrush rBStatus3Brush = new SolidBrush(Color.FromArgb(97,217,73));
		private SolidBrush rBStatus4Brush = new SolidBrush(Color.FromArgb(19,40,197));
		private SolidBrush rBStatus5Brush = new SolidBrush(Color.FromArgb(233,34,212));
		private SolidBrush rBStatus6Brush = new SolidBrush(Color.FromArgb(206,222,33));
		private StringFormat textFormat = new StringFormat(StringFormatFlags.NoWrap);
		#endregion

		#region Fields having Property
		private string bunho = "";   //ﾈｯﾀﾚｹ｣
		private int    pkinp1001 = 0; //ﾀﾔｿｰ
		private string hoCode = "";  //ﾈ｣ｵｿCode 
		private int bedNumber = 1;   //ｺｴｻ｣
		private string suName = "";  //ﾈｯﾀﾚｸ・
		private BedStatus bedStatus = BedStatus.State1;  //Default ｰｮ
		private RightTopStatus  rTStatus = RightTopStatus.State1;
		private RightBottomStatus rBStatus = RightBottomStatus.State1;
		private BottomLeftStatus  bLStatus = BottomLeftStatus.State1;
		private BottomRightStatus  bRStatus = BottomRightStatus.State1;
		private HumanSex  sexKind = HumanSex.Man;
		private bool redraw = true;  //ｼﾓｼｺ ｺｯｰ貎ﾃ OnPaintｿ｡ｼｭ ｺｯｰ豬ﾈ ｼﾓｼｺｿ｡ ｵ鄕･ Paintｸｦ ﾇﾒﾁ・ｿｩｺﾎ(ﾃﾖﾃﾊ ｵ･ﾀﾌﾅｸｸｦ ｰ｡ﾁ・ｼﾓｼｺｼｳﾁ､ﾇﾒｶｧ ﾀﾚﾁﾖ ｱﾗｸｮｴﾂ ｰﾍﾀｻ ｹ戝・
		private States state = States.Normal; //BedBoxﾀﾇ ｻﾂ
		private bool selected = false;  //Mouseﾀﾇ LeftButtonﾀｻ Clickﾇﾟｴﾂﾁ・ｿｩｺﾎ(ｼｱﾅﾃｵﾈ ｻﾂ ｺｸｿｩﾁﾖｱ・
		#endregion

		#region Properties
		[DefaultValue(""),Category("ﾃﾟｰ｡ｼﾓｼｺ"),
		Description("ｺｴｻﾇ ﾈｯﾀﾚｹ｣ｸｦ ｼｳﾁ､ﾇﾕｴﾏｴﾙ.")]
		public string Bunho
		{
			get { return bunho;}
			set 
			{
				if (bunho != value)
				{
					bunho = value;
					Invalidate(true);
				}
			}
		}
		[DefaultValue(""),Category("ﾃﾟｰ｡ｼﾓｼｺ"),
		Description("ｺｴｻﾇ ﾀﾔｿｰｸｦ ｼｳﾁ､ﾇﾕｴﾏｴﾙ.")]
		public int Pkinp1001
		{
			get { return pkinp1001;}
			set 
			{
				if (pkinp1001 != value)
				{
					pkinp1001 = value;
					Invalidate(true);
				}
			}
		}

		[Browsable(false)]
		public string HoCode  //ﾀﾌ ｺｴｻﾌ ｼﾓﾇﾏｴﾂ HoCode
		{
			get { return hoCode;}
			set { hoCode = value;}

		}
		[DefaultValue(1),Category("ﾃﾟｰ｡ｼﾓｼｺ"),
		Description("ｺｴｻﾇ Numberｸｦ ｼｳﾁ､ﾇﾕｴﾏｴﾙ.")]
		public int BedNumber
		{
			get { return bedNumber;}
			set 
			{
				if (bedNumber != value)
				{
					bedNumber = Math.Max(value,0);
					Invalidate(true);
				}
			}
		}
		[DefaultValue(""),Category("ﾃﾟｰ｡ｼﾓｼｺ"),
		Description("ｺｴｻﾇ ﾈｯﾀﾚｸ暲ｻ ｼｳﾁ､ﾇﾕｴﾏｴﾙ.")]
		public string SuName
		{
			get { return suName;}
			set 
			{
				if (suName != value)
				{
					suName = value;
					Invalidate(true);
				}
			}
		}
		[DefaultValue(BedStatus.State1),Category("ﾃﾟｰ｡ｼﾓｼｺ"),
		Description("ｺｴｻﾇ ｻﾂｸｦ ｼｳﾁ､ﾇﾕｴﾏｴﾙ.")]
		public BedStatus BedStatus
		{
			get { return bedStatus;}
			set 
			{
				if (bedStatus != value)
				{
					bedStatus = value;
					this.Size = new Size(BEDNUMBER_WIDTH + TITLE_WIDTH, this.Height);

//					if (bedStatus == BedStatus.State1)  //ｰｮﾀﾏ ｰ豼・ﾂ SIZE ﾀﾛｰﾔ
//						this.Size = new Size(BEDNUMBER_WIDTH + TITLE_WIDTH, this.Height);
//					else  //ｻ邯ﾌ ﾀﾖﾀｸｸ・SIZE ﾅｩｰﾔ
//						this.Size = new Size(BEDNUMBER_WIDTH + TITLE_WIDTH + WIDTH_GAP + STATUS_WIDTH, this.Height);

					Invalidate(true);
				}
			}
		}
		[DefaultValue(RightTopStatus.State1),Category("ﾃﾟｰ｡ｼﾓｼｺ"),
		Description("ﾈｯﾀﾚﾀﾇ ｻﾂ(ｴ羔邁｣ﾈ｣ｻ酥ﾀ)ﾀｻ ｼｳﾁ､ﾇﾕｴﾏｴﾙ.")]
		public RightTopStatus RTStatus
		{
			get { return rTStatus;}
			set 
			{
				if (rTStatus != value)
				{
					rTStatus = value;
					Invalidate(true);
				}
			}
		}
		[DefaultValue(RightBottomStatus.State1),Category("ﾃﾟｰ｡ｼﾓｼｺ"),
		Description("ﾈｯﾀﾚﾀﾇ ｻﾂ(ﾈｯﾀﾚﾀｯﾇ・ﾀｻ ｼｳﾁ､ﾇﾕｴﾏｴﾙ.")]
		public RightBottomStatus RBStatus
		{
			get { return rBStatus;}
			set 
			{
				if (rBStatus != value)
				{
					rBStatus = value;
					Invalidate(true);
				}
			}
		}
		[DefaultValue(BottomLeftStatus.State1),Category("ﾃﾟｰ｡ｼﾓｼｺ"),
		Description("ﾈｯﾀﾚﾀﾇ ｻﾂ(ｼｱﾅﾃﾁ睚ｯﾀﾚｿｩｺﾎ)ﾀｻ ｼｳﾁ､ﾇﾕｴﾏｴﾙ.")]
		public BottomLeftStatus BLStatus
		{
			get { return bLStatus;}
			set 
			{
				if (bLStatus != value)
				{
					bLStatus = value;
					Invalidate(true);
				}
			}
		}
		[DefaultValue(BottomRightStatus.State1),Category("ﾃﾟｰ｡ｼﾓｼｺ"),
		Description("ﾈｯﾀﾚﾀﾇ ｻﾂ(CPﾈｯﾀﾚｿｩｺﾎ)ﾀｻ ｼｳﾁ､ﾇﾕｴﾏｴﾙ.")]
		public BottomRightStatus BRStatus
		{
			get { return bRStatus;}
			set 
			{
				if (bRStatus != value)
				{
					bRStatus = value;
					Invalidate(true);
				}
			}
		}
		[DefaultValue(HumanSex.Man),Category("ﾃﾟｰ｡ｼﾓｼｺ"),
		Description("ﾈｯﾀﾚﾀﾇ ｼｺｺｰﾀｻ ｼｳﾁ､ﾇﾕｴﾏｴﾙ.")]
		public HumanSex SexKind
		{
			get { return sexKind;}
			set 
			{
				if (sexKind != value)
				{
					sexKind = value;
					Invalidate(true);
				}
			}
		}
		[Browsable(false)]
		public bool Redraw
		{
			get { return redraw;}
			set
			{
				if (redraw != value)
				{
					redraw = value;
					if (redraw) //ｴﾙｽﾃ ｱﾗｸｲ
						Invalidate(true);
				}
			}
		}
		[Browsable(false)]
		public bool Selected //ﾀﾌ BedBoxｰ｡ ｼｱﾅﾃｵﾇｾ嶸ﾂﾁ・ｿｩｺﾎ
		{
			get { return selected;}
			set
			{
				if (selected != value)
				{
					selected = value;
					Invalidate(true);
				}
			}
		}
		#endregion

		#region base Property
		[Browsable(false),
		DefaultValue(typeof(Color),"Transparent")]
		public new Color BackColor
		{
			get { return base.BackColor;}
			set { base.BackColor = value;}
		}
		#endregion

		#region Event, Event Invoker
		[Browsable(true),Category("ﾃﾟｰ｡ﾀﾌｺ･ﾆｮ"),
		Description("ﾈｯﾀﾚｿｵｿｪﾀｻ Clickｽﾃｿ｡ ｹﾟｻﾇﾏｴﾂ Eventﾀﾔｴﾏｴﾙ.")]
		public event EventHandler SuNameClick;
		[Browsable(true),Category("ﾃﾟｰ｡ﾀﾌｺ･ﾆｮ"),
		Description("ﾈｯﾀﾚｿｵｿｪﾀｻ DoubleClickｽﾃｿ｡ ｹﾟｻﾇﾏｴﾂ Eventﾀﾔｴﾏｴﾙ.")]
		public event EventHandler SuNameDoubleClick;
		[Browsable(true),Category("ﾃﾟｰ｡ﾀﾌｺ･ﾆｮ"),
		Description("ﾈｯﾀﾚｿｵｿｪﾀｻ MouseDownｽﾃｿ｡ ｹﾟｻﾇﾏｴﾂ Eventﾀﾔｴﾏｴﾙ.")]
		public event MouseEventHandler SuNameMouseDown;
		[Browsable(true),Category("ﾃﾟｰ｡ﾀﾌｺ･ﾆｮ"),
		Description("ﾃﾟｰ｡ﾃｳｹ貉ﾟｻ ﾇ･ｽﾃｿｵｿｪ Clickｽﾃｿ｡ ｹﾟｻﾇﾏｴﾂ Eventﾀﾔｴﾏｴﾙ.")]
		public event EventHandler BottomLeftClick;
		[Browsable(true),Category("ﾃﾟｰ｡ﾀﾌｺ･ﾆｮ"),
		Description("ﾃﾟｰ｡ﾃｳｹ貉ﾟｻ ﾇ･ｽﾃｿｵｿｪ DoubleClickｽﾃｿ｡ ｹﾟｻﾇﾏｴﾂ Eventﾀﾔｴﾏｴﾙ.")]
		public event EventHandler BottomLeftDoubleClick;

		//Event Invoker
		private void OnSuNameClick(EventArgs e)
		{
			if (SuNameClick != null)
				SuNameClick(this, e);
		}
		private void OnSuNameDoubleClick(EventArgs e)
		{
			if (SuNameDoubleClick != null)
				SuNameDoubleClick(this, e);
		}
		private void OnSuNameMouseDown(MouseEventArgs e)
		{
			if (SuNameMouseDown != null)
				SuNameMouseDown(this, e);
		}
		private void OnBottomLeftClick(EventArgs e)
		{
			if (BottomLeftClick != null)
				BottomLeftClick(this, e);
		}
		private void OnBottomLeftDoubleClick(EventArgs e)
		{
			if (BottomLeftDoubleClick != null)
				BottomLeftDoubleClick(this, e);
		}
		#endregion

		#region ｻｼｺﾀﾚ
		//ｺｴｻｻ ｺｸｿｩﾁﾖｴﾂ Picture Box
		public BedBox()
		{
			this.Size = new Size(BEDNUMBER_WIDTH + TITLE_WIDTH, TITLE_HEIGHT + BOTTOM_HEIGHT);
			this.BackColor = Color.Transparent;  //BackColor ﾅ晙・
			textFormat.LineAlignment = StringAlignment.Center;
			textFormat.Alignment = StringAlignment.Center;
			textFormat.Trimming = StringTrimming.EllipsisCharacter;
		}
		#endregion

		#region MouseMove, MouseLeave, OnMouseDown, OnClick, OnDoubleClick
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove (e);
			//Bedｻﾂｰ｡ ｰﾌ ｾﾆｴﾒｶｧ ﾈｯﾀﾚｸ・ ﾃﾟｰ｡ Orderｿｩｺﾎ ｿｵｿｪｿ｡ ﾀﾖｴﾂﾁ・ｿｩｺﾎｿ｡ ｵ郞・BedBox ｻﾂｺｯｰ・
			if (this.bedStatus != BedStatus.State1)
			{
				//ﾈｯﾀﾚｿｵｿｪBoundｿ｡ Pointｰ｡ ﾀﾖﾀｸｸ・ｻﾂｺｯｰ・
				if (this.suNameBounds.Contains(e.X, e.Y))
				{
					if (this.state != States.SuNameMouseOver)
					{
						this.state = States.SuNameMouseOver;
						Invalidate(true);
					}
				}
					//ﾃﾟｰ｡Orderｹﾟｻ ﾇ･ｽﾃ ｿｵｿｪｿ｡ ﾀﾖﾀｻｶｧ
				else if (this.bottomLeftBounds.Contains(e.X, e.Y))  
				{
					if (this.state != States.BottomLeftMouseOver)
					{
						this.state = States.BottomLeftMouseOver;
						Invalidate(true);
					}
				}
				else  //ｱﾗｿﾜ ｿｵｿｪｿ｡ｼｭｴﾂ ﾁ､ｻ・
				{
					if (this.state != States.Normal)
					{
						this.state = States.Normal;
						Invalidate(true);
					}
				}
			}
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);
			//Bedｻﾂｰ｡ ｰﾌ ｾﾆｴﾒｶｧ, Left ButtonClickｽﾃｿ｡ ｼｱﾅﾃｻﾂ ｺｯｰ・
			if (this.bedStatus != BedStatus.State1)
			{
				//ﾈｯﾀﾚｹ｣ｿｵｿｪﾀｻ Clickﾇﾏｸ・Invalidate
				if ((e.Button == MouseButtons.Left) && this.suNameBounds.Contains(e.X, e.Y))
				{
					//SuNameMouseDown Event Call
					OnSuNameMouseDown(e);
				}
			}
			
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave (e);
			//ﾀﾏｹﾝｻﾂｰ｡ ｾﾆｴﾏｸ・ﾀﾏｹﾝｻﾂ ｺｹｱｸ
			if (state != States.Normal)
			{
				state = States.Normal;
				this.Invalidate(true);
			}
		}

		protected override void OnClick(EventArgs e)
		{
			//ﾈｯﾀﾚｿｵｿｪ Clickｽﾃｴﾂ SuNameClick Event, ﾃﾟｰ｡ﾃｳｹ貉ﾟｻﾇ･ｽﾃｿｵｿｪ Clickｽﾃｴﾂ BottomLeftClick Event ｹﾟｻｽﾃﾅｴ
			if (this.state == States.SuNameMouseOver)
				OnSuNameClick(EventArgs.Empty);
			else if (this.state == States.BottomLeftMouseOver)
				OnBottomLeftClick(EventArgs.Empty);

		}
		protected override void OnDoubleClick(EventArgs e)
		{
			//ﾈｯﾀﾚｿｵｿｪ DoubleClickｽﾃｴﾂ SuNameDoubleClick Event, ﾃﾟｰ｡ﾃｳｹ貉ﾟｻﾇ･ｽﾃｿｵｿｪ Clickｽﾃｴﾂ BottomLeftDoubleClick Event ｹﾟｻｽﾃﾅｴ
			if (this.state == States.SuNameMouseOver)
				OnSuNameDoubleClick(EventArgs.Empty);
			else if (this.state == States.BottomLeftMouseOver)
				OnBottomLeftDoubleClick(EventArgs.Empty);
		}
		#endregion


		#region OnPaint (ｺｴｻﾇ ｻﾂｿ｡ ｵ郞・ｺｴｻｻ ｱﾗｸｲ)
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			int width = this.Size.Width;
			int height = this.Size.Height;
			Rectangle rect = Rectangle.Empty;
			string drawText = "";
			SizeF fontSize = SizeF.Empty;

			//Redraw Flagｰ｡ ｼｳﾁ､ｵﾇｾ・ﾀﾖﾀｸｸ・ｱﾗｸｮﾁ・ｾﾊﾀｽ
			//ｵ･ﾀﾌﾅｸｸｦ ｰ｡ﾁ・ｼﾓｼｺ ｼｳﾁ､ｽﾃ ﾃﾖﾃﾊ falseﾇﾏｰ・ｴﾙ ｼｳﾁ､ﾇﾑ ｴﾙﾀｻｸﾞ trueｷﾎ ｼｳﾁ､ﾇﾏｿｩ Paintｸｦ ﾈｿｰ惕釥ｸｷﾎ ｼ猊ﾏｱ・ﾀｧﾇﾔ
			if (!this.redraw) return;

			try
			{
				//ｺｴｻ・Numberｿｵｿｪ Draw
				rect = new Rectangle(0,0, BEDNUMBER_WIDTH, TITLE_HEIGHT + BOTTOM_HEIGHT);
				//Fill Rect (ｺｴｻﾇ ｻﾂｿ｡ ｵ郞・ｻ・ﾁ､)
				Brush fillBrush = bedStatus1Brush;  //ｰｮ ｻ・
				switch (this.bedStatus)
				{
					case BedStatus.State2: //White
						fillBrush = bedStatus2Brush;
						break;
					case BedStatus.State3: //Yello
						fillBrush = bedStatus3Brush;
						break;
					case BedStatus.State4: //Red
						fillBrush = bedStatus4Brush;
						break;
				}
				e.Graphics.FillRectangle(fillBrush, rect);

				//Draw Rect
				e.Graphics.DrawRectangle(rectPen, rect);

				//ｺｴｽﾇｹ｣ Draw
				fontSize = DrawHelper.MeasureString(e.Graphics, this.bedNumber.ToString(), numberFont, ContentAlignment.MiddleCenter);
				e.Graphics.DrawString(this.bedNumber.ToString(), numberFont, textBrush, 
					DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter, rect.X, rect.Y, rect.Width, rect.Height, fontSize.Width, fontSize.Height));

				//ｰｮｰ・ﾈｯﾀﾚｰ｡ ﾀﾖｴﾂ ｰ豼・ﾎ ｱｸｺﾐﾇﾏｿｩ SET
				if (this.bedStatus == BedStatus.State1)
				{
					//ﾈｯﾀﾚｸ・ｿｵｿｪﾀｻ ｰｮﾀｸｷﾎ SET
					drawText = "ﾍ・ﾟﾉ"; //ｰ・

					rect = new Rectangle(BEDNUMBER_WIDTH, 0, TITLE_WIDTH , TITLE_HEIGHT + BOTTOM_HEIGHT);
					//Fill Brushｴﾂ PapayaWhip
					fillBrush = emptyBedBrush;

					e.Graphics.FillRectangle(fillBrush, rect);
					e.Graphics.DrawRectangle(rectPen, rect);
					//ｰｮ Text Draw
					fontSize = e.Graphics.MeasureString(drawText, titleFont);
					e.Graphics.DrawString(drawText, titleFont, textBrush, 
						DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter, rect.X, rect.Y, rect.Width, rect.Height, fontSize.Width, fontSize.Height));
				}
				else
				{
					//ﾈｯﾀﾚﾀﾇ ｼｺｺｰｿ｡ ｵ郞・ｹﾙﾅﾁ ｺｯｰ・
					fillBrush = manBrush;  //ｳｲｼｺﾀｺ ﾆﾄｶ・
					if (this.sexKind == HumanSex.Woman) //ｿｩｼｺﾀｺ ｻ｡ｰ｣ｻ・
						fillBrush = womanBrush;

					rect = new Rectangle(BEDNUMBER_WIDTH, 0, TITLE_WIDTH, TITLE_HEIGHT+ BOTTOM_HEIGHT);


					//ﾈｯﾀﾚｿｵｿｪｿ｡ MouseOverｻﾂﾀﾌｸ・ｰｭﾁｶ Rect Set
					if (this.state == States.SuNameMouseOver)
					{
						//ｳｲｼｺ ｻ・
						Brush overBrush = new LinearGradientBrush(rect, Color.FromArgb(193, 228, 249), Color.FromArgb(119,188,225), 90.0f);
						if (this.sexKind == HumanSex.Woman)
							overBrush = new LinearGradientBrush(rect, Color.FromArgb(253, 216, 137), Color.FromArgb(248, 178, 48), 90.0f);

						e.Graphics.FillRectangle(overBrush, rect);
						overBrush.Dispose();
					}
					else  //ﾁ､ｻﾂﾀﾌｸ・Gradientﾀ釤・ﾏﾁ・ｾﾊﾀｽ
					{
						//Fill Brush
						e.Graphics.FillRectangle(fillBrush, rect);
					}
					e.Graphics.DrawRectangle(rectPen, rect);
					
					
					//ﾈｯﾀﾚｸ・ Draw
					if (this.suName != "")
					{
						fontSize = e.Graphics.MeasureString(this.suName, titleFont);
						//StringFormat ﾀ釤・ﾏｿｩ ｱ菎ﾌｸｧﾀｺ ...ﾀｸｷﾎ ｺｸﾀﾌｰﾔﾇﾔ
						e.Graphics.DrawString(this.suName, titleFont, textBrush, rect, textFormat);
					}

					//ｾﾆｷ｡ ｿｵｿｪ Fill, Draw Rect
					rect = new Rectangle(BEDNUMBER_WIDTH, TITLE_HEIGHT, TITLE_WIDTH/2, BOTTOM_HEIGHT);

					//ｾﾆｷ｡ ﾁﾂﾃｵｿｪﾀｺ (ﾃﾟｰ｡ｿﾀｴ・ｹﾟｻｿｩｺﾎ) BottomLeftStatusｿ｡ ｵ郞・fillBrush SET
					fillBrush = this.bLStatus1Brush; //N ｱ篌ｻ LightYellow (ｾｽ)
					switch (this.bLStatus)
					{
						case BottomLeftStatus.State2:
							fillBrush = bLStatus2Brush;  //Y OrangeRed
							break;
					}

					//LeftButtonClickｻﾂﾀﾌｸ・ｼｱﾅﾃｵﾈ ｸ・ｺｸｿｩﾁﾖｱ・3Pixel -> 2Pixel)
					if (this.selected)
					{
						rect = new Rectangle(1,1, BEDNUMBER_WIDTH + TITLE_WIDTH -2 , TITLE_HEIGHT + BOTTOM_HEIGHT - 2);
						e.Graphics.DrawRectangle(Pens.OrangeRed, rect);
						rect = new Rectangle(2,2, BEDNUMBER_WIDTH + TITLE_WIDTH -4 , TITLE_HEIGHT + BOTTOM_HEIGHT - 4);
						e.Graphics.DrawRectangle(Pens.Orange, rect);
					}
				}
			}
			catch(Exception xe)
			{
				Debug.WriteLine("BedBox::OnPaint, Error=" + xe.Message);
			}
			

		}
		#endregion

		#region Dispose
		/// <summary>
		/// ﾄﾁﾆｮｷﾑｿ｡ｼｭ ｻ鄙・ﾏｴﾂ ｸｮｼﾒｽｺｸｦ ｸﾎ ﾇﾘﾁｦﾇﾕｴﾏｴﾙ.
		/// </summary>
		/// <param name="disposing"> Dispose ｿｩｺﾎ </param>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				//PenBrush Dispose
				DisposePensBrushes();
			}
			base.Dispose( disposing );
		}
		#endregion

		#region DisposePenBrushes (ｱﾗｸｮｱ篩｡ｼｭ ｻ鄙・ﾑ Brush Dispose)
		private void DisposePensBrushes()
		{
			try
			{
				textBrush.Dispose();
				bedStatus1Brush.Dispose();
				bedStatus2Brush.Dispose();
				bedStatus3Brush.Dispose();
				bedStatus4Brush.Dispose();
				manBrush.Dispose();
				womanBrush.Dispose();
				emptyBedBrush.Dispose(); 
				bLStatus1Brush.Dispose();
				bLStatus2Brush.Dispose();
				bRStatus1Brush.Dispose();
				bRStatus2Brush.Dispose();
				rTStatus1Brush.Dispose();
				rTStatus2Brush.Dispose();
				rTStatus3Brush.Dispose();
				rBStatus1Brush.Dispose();
				rBStatus2Brush.Dispose();
				rBStatus3Brush.Dispose();
				rBStatus4Brush.Dispose();
				rBStatus5Brush.Dispose();
				rBStatus6Brush.Dispose();
			}
			catch{}
		}
		#endregion

	}

	#region Enum(ｺｴｻﾂｸｦ ｳｪﾅｸｳｻｴﾂ Enum)
	internal enum BedStatus  //ｺｴｻﾂ
	{
		State1,  //ｰｮ
		State2,  //ﾀﾌｵｿｰ｡ｴﾉﾈｯﾀﾚ(BR_CODE 01) - ﾈ・
		State3,  //ｵｵｿｻ ｹﾞｾﾆ ﾀﾌｵｿﾇﾒ ﾈｯﾀﾚ(BR_CODE BR) - ﾈｲｻ・
		State4   //ﾀﾌｵｿｺﾒｰ｡ﾈｯﾀﾚ(BR_CODE ABR) - ﾀ釗・
	}
	internal enum BottomLeftStatus  //ｾﾆｷ｡ ﾁﾂﾃ・ｻﾂ
	{
		State1, //ｼｱﾅﾃﾁ睚ｯﾀﾚ
		State2  //ｹﾌｼｱﾅﾃﾁ・ﾈｯﾀﾚ
	}
	internal enum BottomRightStatus //ｾﾆｷ｡ ｿ・ﾂ
	{
		State1, //CPﾈｯﾀﾚ Y
		State2  //CPﾈｯﾀﾚ N
	}
	internal enum RightTopStatus // ｿ・ﾜ ｻﾂ(ｴ羔邁｣ﾈ｣ｻ・ﾆﾀ)
	{
		State1,  //Aﾆﾀ
		State2,  //Bﾆﾀ
		State3   //Cﾆﾀ
	}
	internal enum RightBottomStatus  //ｿ・ﾏｴﾜ ｻﾂ(ﾈｯﾀﾚﾀｯﾇ・-ｹﾌﾁ､)
	{
		State1, //ｱｹｹﾎｺｸﾇ・
		State2, //ﾀﾇｷ盂ﾞｿｩ
		State3, //ｻ・酩ﾘ
		State4, //ﾀﾚｵｿﾂｸﾇ・
		State5, //ﾀﾏｹﾝ
		State6  //ｱ簀ｸ
	}
	internal enum HumanSex
	{
		Man,  //ｳｲｼｺ
		Woman //ｿｩｼｺ
	}
	#endregion
}

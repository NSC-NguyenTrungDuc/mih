using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Ink;

namespace IHIS.Framework
{
	/// <summary>
	/// XImageEditor에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(System.Windows.Forms.PictureBox))]
	public class XImageEditor : System.Windows.Forms.UserControl
	{
		#region Private enum
		private enum MagState
		{
			Magnify, //확대
			Reduce, //축소
			Original //원래크기
		}

		private enum DrawMode
		{
			Select,  //선택모드
			Text,    //Text 입력
			Pen,     //글씨 쓰기
			Rect,    //사각형
			Circle,  //원
			Line,    //Line
			Arrow    //화살표
		}
		private enum SelectedPartMode
		{
			TopLeft = 0,
			TopCenter = 1,
			TopRight = 2,
			MiddleLeft = 3,
			MiddleRight = 4,
			BottomLeft = 5,
			BottomCenter = 6,
			BottomRight = 7,
			Center = 8,
			None = 9
			
		}
		#endregion

		#region Fields
		const float MAG_RATIO = 0.1f;  //확대,축소 비율
		const int	MARGIN = 5;     //선택된 영역을 표시할때 Margin
		private Color selectedColor = Color.Black;  //선택된 칼라
		private MagState magState = MagState.Original;  //확대모드 관리
		private int lineThick = 2; //선굵기
		private DrawMode drawMode = DrawMode.Select; //그리기 모드 관리
		//private SizeF imageSize = SizeF.Empty;  //변경후 Image Size
		private ArrayList drawItemList = new ArrayList();  //DrawItem(그리기객체)를 관리하는 ArrayList
		private Point sPoint = Point.Empty; //MouseDown 시작 위치
		private Point mPoint = Point.Empty; //Mouse이동시 이전좌표
		private ArrayList selectedItemList = new ArrayList();  //선택된 DrawItem의 List
		private Size origpnlImageSize = Size.Empty;  //OnLoad시의 pnlImage의 Size
		private Color selectedRadioColor = Color.GreenYellow;
		private Color unSelectedRadioColor = Color.Beige;
		private IHIS.X.Magic.Menus.PopupMenu popupMenu = new IHIS.X.Magic.Menus.PopupMenu();
		private bool isTextModifyMode = false; //이미 편집한 Text를 Modify하는 Mode인지 여부
		private bool showSaveButton = true; //Image 저장버튼을 보일지 여부
		private Image image = null; //Image
		//private bool isMagnifyApplyed = false; //확대,축소 모드가 적용되어 있는지 여부
		private float zoom = 1F; //IF 100%

		//기능추가
		private SelectedPartMode partMode = SelectedPartMode.None;
		private System.Windows.Forms.Cursor[] m_SelectedPointCursor = new System.Windows.Forms.Cursor[10];
		private Size selectedPointerSize = new Size(10, 10);					//선택된 영역의 포인터의 크기
		private Bitmap pointBmp = null; //Point 영역 Bitmap
		
		//Ink 관련
		//private InkCollector m_InkCollector = null;		//Ink 
		//private const int m_HitTestRadius = 30;							//HistTest시 사용할 반지름
		//private Strokes m_SelectedStrokes;								//선택된 Strokes를 보관
		//private Ink inkPencil = new Ink();
		#endregion

		#region Base Properties (Not Browse)
		[Browsable(false)]
		public override bool AutoScroll
		{
			get { return base.AutoScroll;}
			set	{ base.AutoScroll = value;}
		}
		[Browsable(false)]
		[DefaultValue(typeof(Color),"WhiteSmoke")]
		public override Color BackColor
		{
			get { return base.BackColor; }
			set	{ base.BackColor = value;}
		}
		[Browsable(false)]
		public override Color ForeColor
		{
			get { return base.ForeColor; }
			set { base.ForeColor = value;}
		}

		[Browsable(false)]
		public override Image BackgroundImage
		{
			get { return base.BackgroundImage; }
			set	{ base.BackgroundImage = value;	}
		}
		[Browsable(false)]
		[DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;}
			set { base.Font = value;}
		}
		[Browsable(false)]
		public override RightToLeft RightToLeft 
		{
			get { return base.RightToLeft;}
			set { base.RightToLeft = value;}
		}
		//		[Browsable(false)]
		//		public new Size AutoScrollMargin
		//		{
		//			get { return base.AutoScrollMargin; }
		//			set { base.AutoScrollMargin = value;}
		//		}
		//		[Browsable(false)]
		//		public new Size AutoScrollMinSize
		//		{
		//			get { return base.AutoScrollMinSize; }
		//			set { base.AutoScrollMinSize = value;}
		//		}
		[Browsable(false)]
		public new ScrollableControl.DockPaddingEdges DockPadding
		{
			get { return base.DockPadding;}
		}
		#endregion

		#region Property
		[Browsable(true)]
		[DefaultValue(true)]
		[Category("추가속성")]
		[Description("이미지에디터의 이미지 저장버튼을 보이게 할지 여부를 지정합니다.")]
		public bool ShowSaveButton
		{
			get { return showSaveButton;}
			set 
			{
				showSaveButton = value;
				this.btnSave.Visible = value;
			}
		}
		[Browsable(true)]
		[DefaultValue(null)]
		[Category("추가속성")]
		[Description("이미지에디터의 이미지를 지정합니다.")]
		public Image Image
		{
			get { return this.image;}
			set
			{
				if (this.image != value)
				{
					//변수 초기화
					this.drawItemList.Clear();
					this.selectedItemList.Clear();
					pnlImage.InkPencil.Strokes.Clear(); //Ink Clear
					if (this.txtText.Visible)
					{
						this.txtText.Text = "";
						this.txtText.Visible = false;
					}
					//pnlImage의 Size를 기본 Size로 Set
					//pnlImage Size는 pnlFillSize에 맞추어 조정
					this.pnlImage.Size = GetDefaultImageSize();
					this.origpnlImageSize = pnlImage.Size;

					this.image = value;

					//Invalidate
					this.pnlImage.Invalidate(true);
				}
			}
		}
		/* Image는 Stretch 형태로 보여줌 Alignment 적용하지 않음
		[Browsable(true)]
		[DefaultValue(ContentAlignment.MiddleCenter)]
		[Category("추가속성")]
		[Description("이미지의 Align을 지정합니다.")]
		public ContentAlignment ImageAlign
		{
			get { return imageAlign;}
			set 
			{
				if (imageAlign != value)
				{
					imageAlign = value;
					if (this.Image != null)  //다시 그리기
						this.pnlImage.Invalidate(true);  
				}
			}
		}
		*/
		#endregion

		#region Event
		[Browsable(true)]
		[Description("이미지 저장버튼을 눌렀을때 발생하는 Event입니다.")]
		[Category("추가이벤트")]
		public event EventHandler SaveButtonClick;
		#endregion

		private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.RadioButton rbxColor23;
		private System.Windows.Forms.RadioButton rbxColor24;
		private System.Windows.Forms.RadioButton rbxColor19;
		private System.Windows.Forms.RadioButton rbxColor20;
		private System.Windows.Forms.RadioButton rbxColor21;
		private System.Windows.Forms.RadioButton rbxColor22;
		private System.Windows.Forms.RadioButton rbxColor17;
		private System.Windows.Forms.RadioButton rbxColor18;
		private System.Windows.Forms.RadioButton rbxColor33;
		private System.Windows.Forms.RadioButton rbxColor34;
		private System.Windows.Forms.RadioButton rbxColor35;
		private System.Windows.Forms.RadioButton rbxColor36;
		private System.Windows.Forms.RadioButton rbxColor37;
		private System.Windows.Forms.RadioButton rbxColor38;
		private System.Windows.Forms.RadioButton rbxColor39;
		private System.Windows.Forms.RadioButton rbxColor40;
		private System.Windows.Forms.RadioButton rbxColor41;
		private System.Windows.Forms.RadioButton rbxColor42;
		private System.Windows.Forms.RadioButton rbxColor43;
		private System.Windows.Forms.RadioButton rbxColor44;
		private System.Windows.Forms.RadioButton rbxColor45;
		private System.Windows.Forms.RadioButton rbxColor46;
		private System.Windows.Forms.RadioButton rbxColor47;
		private System.Windows.Forms.RadioButton rbxColor48;
		private System.Windows.Forms.RadioButton rbxColor9;
		private System.Windows.Forms.RadioButton rbxColor10;
		private System.Windows.Forms.RadioButton rbxColor11;
		private System.Windows.Forms.RadioButton rbxColor12;
		private System.Windows.Forms.RadioButton rbxColor13;
		private System.Windows.Forms.RadioButton rbxColor14;
		private System.Windows.Forms.RadioButton rbxColor15;
		private System.Windows.Forms.RadioButton rbxColor16;
		private System.Windows.Forms.RadioButton rbxColor5;
		private System.Windows.Forms.RadioButton rbxColor6;
		private System.Windows.Forms.RadioButton rbxColor7;
		private System.Windows.Forms.RadioButton rbxColor8;
		private System.Windows.Forms.RadioButton rbxColor3;
		private System.Windows.Forms.RadioButton rbxColor4;
		private System.Windows.Forms.RadioButton rbxColor2;
		private System.Windows.Forms.RadioButton rbxColor1;
		private System.Windows.Forms.Panel pnlLeftTop;
		private System.Windows.Forms.Panel pnlLeftBottom;
		private System.Windows.Forms.Label lbColor;
		private System.Windows.Forms.Label lbLineTickHeader;
		private System.Windows.Forms.Label lbLineTick;
		private System.Windows.Forms.Label lbDrawHeader;
		private System.Windows.Forms.RadioButton rbTick1;
		private System.Windows.Forms.RadioButton rbTick2;
		private System.Windows.Forms.RadioButton rbTick3;
		private System.Windows.Forms.RadioButton rbTick6;
		private System.Windows.Forms.RadioButton rbTick5;
		private System.Windows.Forms.RadioButton rbTick4;
		private System.Windows.Forms.RadioButton rbText;
		private System.Windows.Forms.RadioButton rbSelect;
		private System.Windows.Forms.Button btnErase;
		private System.Windows.Forms.RadioButton rbPen;
		private System.Windows.Forms.RadioButton rbCircle;
		private System.Windows.Forms.RadioButton rbRect;
		private System.Windows.Forms.RadioButton rbArrow;
		private System.Windows.Forms.RadioButton rbLine;
		private System.Windows.Forms.Button btnMag;
		private System.Windows.Forms.Button btnReduce;
		private System.Windows.Forms.Button btnOrig;
		private IHIS.Framework.XButton rbxColorSelect;
		private IHIS.Framework.XButton btnSave;
		private System.Windows.Forms.RichTextBox txtText;
		private IHIS.Framework.XButton btnFont;
		private System.Windows.Forms.Panel pnlFill;
		private IHIS.Framework.XImageEditorPanel pnlImage;
		private System.Windows.Forms.ToolTip toolTip;
		private System.ComponentModel.IContainer components;

		public XImageEditor()
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();

			//일본어 Mode일때 Text, ToolTip Set
			SetControlTextByLangMode();
			
			string text = XMsg.GetField("F027"); // 텍스트편집
			this.popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(text, new EventHandler(OnTextEdit)));

			//Point Bitmap Set
			pointBmp = new Bitmap(typeof(IHIS.Framework.XImageEditor), "Images.SelPointer.bmp");
			pointBmp.MakeTransparent(Color.White);

		}

		/// <summary> 
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(XImageEditor));
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.rbxColorSelect = new IHIS.Framework.XButton();
			this.lbColor = new System.Windows.Forms.Label();
			this.rbxColor23 = new System.Windows.Forms.RadioButton();
			this.rbxColor24 = new System.Windows.Forms.RadioButton();
			this.rbxColor19 = new System.Windows.Forms.RadioButton();
			this.rbxColor20 = new System.Windows.Forms.RadioButton();
			this.rbxColor21 = new System.Windows.Forms.RadioButton();
			this.rbxColor22 = new System.Windows.Forms.RadioButton();
			this.rbxColor17 = new System.Windows.Forms.RadioButton();
			this.rbxColor18 = new System.Windows.Forms.RadioButton();
			this.rbxColor33 = new System.Windows.Forms.RadioButton();
			this.rbxColor34 = new System.Windows.Forms.RadioButton();
			this.rbxColor35 = new System.Windows.Forms.RadioButton();
			this.rbxColor36 = new System.Windows.Forms.RadioButton();
			this.rbxColor37 = new System.Windows.Forms.RadioButton();
			this.rbxColor38 = new System.Windows.Forms.RadioButton();
			this.rbxColor39 = new System.Windows.Forms.RadioButton();
			this.rbxColor40 = new System.Windows.Forms.RadioButton();
			this.rbxColor41 = new System.Windows.Forms.RadioButton();
			this.rbxColor42 = new System.Windows.Forms.RadioButton();
			this.rbxColor43 = new System.Windows.Forms.RadioButton();
			this.rbxColor44 = new System.Windows.Forms.RadioButton();
			this.rbxColor45 = new System.Windows.Forms.RadioButton();
			this.rbxColor46 = new System.Windows.Forms.RadioButton();
			this.rbxColor47 = new System.Windows.Forms.RadioButton();
			this.rbxColor48 = new System.Windows.Forms.RadioButton();
			this.rbxColor9 = new System.Windows.Forms.RadioButton();
			this.rbxColor10 = new System.Windows.Forms.RadioButton();
			this.rbxColor11 = new System.Windows.Forms.RadioButton();
			this.rbxColor12 = new System.Windows.Forms.RadioButton();
			this.rbxColor13 = new System.Windows.Forms.RadioButton();
			this.rbxColor14 = new System.Windows.Forms.RadioButton();
			this.rbxColor15 = new System.Windows.Forms.RadioButton();
			this.rbxColor16 = new System.Windows.Forms.RadioButton();
			this.rbxColor5 = new System.Windows.Forms.RadioButton();
			this.rbxColor6 = new System.Windows.Forms.RadioButton();
			this.rbxColor7 = new System.Windows.Forms.RadioButton();
			this.rbxColor8 = new System.Windows.Forms.RadioButton();
			this.rbxColor3 = new System.Windows.Forms.RadioButton();
			this.rbxColor4 = new System.Windows.Forms.RadioButton();
			this.rbxColor2 = new System.Windows.Forms.RadioButton();
			this.rbxColor1 = new System.Windows.Forms.RadioButton();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.pnlLeftTop = new System.Windows.Forms.Panel();
			this.btnFont = new IHIS.Framework.XButton();
			this.btnSave = new IHIS.Framework.XButton();
			this.btnOrig = new System.Windows.Forms.Button();
			this.btnReduce = new System.Windows.Forms.Button();
			this.rbArrow = new System.Windows.Forms.RadioButton();
			this.rbLine = new System.Windows.Forms.RadioButton();
			this.rbCircle = new System.Windows.Forms.RadioButton();
			this.rbRect = new System.Windows.Forms.RadioButton();
			this.btnErase = new System.Windows.Forms.Button();
			this.rbPen = new System.Windows.Forms.RadioButton();
			this.rbSelect = new System.Windows.Forms.RadioButton();
			this.rbText = new System.Windows.Forms.RadioButton();
			this.lbDrawHeader = new System.Windows.Forms.Label();
			this.btnMag = new System.Windows.Forms.Button();
			this.pnlLeftBottom = new System.Windows.Forms.Panel();
			this.lbLineTick = new System.Windows.Forms.Label();
			this.rbTick6 = new System.Windows.Forms.RadioButton();
			this.rbTick5 = new System.Windows.Forms.RadioButton();
			this.rbTick4 = new System.Windows.Forms.RadioButton();
			this.rbTick3 = new System.Windows.Forms.RadioButton();
			this.rbTick2 = new System.Windows.Forms.RadioButton();
			this.lbLineTickHeader = new System.Windows.Forms.Label();
			this.rbTick1 = new System.Windows.Forms.RadioButton();
			this.pnlFill = new System.Windows.Forms.Panel();
			this.pnlImage = new IHIS.Framework.XImageEditorPanel();
			this.txtText = new System.Windows.Forms.RichTextBox();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.pnlBottom.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			this.pnlLeftTop.SuspendLayout();
			this.pnlLeftBottom.SuspendLayout();
			this.pnlFill.SuspendLayout();
			this.pnlImage.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlBottom
			// 
			this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlBottom.Controls.Add(this.rbxColorSelect);
			this.pnlBottom.Controls.Add(this.lbColor);
			this.pnlBottom.Controls.Add(this.rbxColor23);
			this.pnlBottom.Controls.Add(this.rbxColor24);
			this.pnlBottom.Controls.Add(this.rbxColor19);
			this.pnlBottom.Controls.Add(this.rbxColor20);
			this.pnlBottom.Controls.Add(this.rbxColor21);
			this.pnlBottom.Controls.Add(this.rbxColor22);
			this.pnlBottom.Controls.Add(this.rbxColor17);
			this.pnlBottom.Controls.Add(this.rbxColor18);
			this.pnlBottom.Controls.Add(this.rbxColor33);
			this.pnlBottom.Controls.Add(this.rbxColor34);
			this.pnlBottom.Controls.Add(this.rbxColor35);
			this.pnlBottom.Controls.Add(this.rbxColor36);
			this.pnlBottom.Controls.Add(this.rbxColor37);
			this.pnlBottom.Controls.Add(this.rbxColor38);
			this.pnlBottom.Controls.Add(this.rbxColor39);
			this.pnlBottom.Controls.Add(this.rbxColor40);
			this.pnlBottom.Controls.Add(this.rbxColor41);
			this.pnlBottom.Controls.Add(this.rbxColor42);
			this.pnlBottom.Controls.Add(this.rbxColor43);
			this.pnlBottom.Controls.Add(this.rbxColor44);
			this.pnlBottom.Controls.Add(this.rbxColor45);
			this.pnlBottom.Controls.Add(this.rbxColor46);
			this.pnlBottom.Controls.Add(this.rbxColor47);
			this.pnlBottom.Controls.Add(this.rbxColor48);
			this.pnlBottom.Controls.Add(this.rbxColor9);
			this.pnlBottom.Controls.Add(this.rbxColor10);
			this.pnlBottom.Controls.Add(this.rbxColor11);
			this.pnlBottom.Controls.Add(this.rbxColor12);
			this.pnlBottom.Controls.Add(this.rbxColor13);
			this.pnlBottom.Controls.Add(this.rbxColor14);
			this.pnlBottom.Controls.Add(this.rbxColor15);
			this.pnlBottom.Controls.Add(this.rbxColor16);
			this.pnlBottom.Controls.Add(this.rbxColor5);
			this.pnlBottom.Controls.Add(this.rbxColor6);
			this.pnlBottom.Controls.Add(this.rbxColor7);
			this.pnlBottom.Controls.Add(this.rbxColor8);
			this.pnlBottom.Controls.Add(this.rbxColor3);
			this.pnlBottom.Controls.Add(this.rbxColor4);
			this.pnlBottom.Controls.Add(this.rbxColor2);
			this.pnlBottom.Controls.Add(this.rbxColor1);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new System.Drawing.Point(0, 406);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(502, 50);
			this.pnlBottom.TabIndex = 0;
			// 
			// rbxColorSelect
			// 
			this.rbxColorSelect.Location = new System.Drawing.Point(4, 4);
			this.rbxColorSelect.Name = "rbxColorSelect";
			this.rbxColorSelect.Size = new System.Drawing.Size(52, 40);
			this.rbxColorSelect.TabIndex = 83;
			this.rbxColorSelect.Text = "색상표";
			this.toolTip.SetToolTip(this.rbxColorSelect, "색상표를 띄웁니다");
			this.rbxColorSelect.Click += new System.EventHandler(this.rbxColorSelect_Click);
			// 
			// lbColor
			// 
			this.lbColor.BackColor = System.Drawing.Color.Black;
			this.lbColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbColor.Location = new System.Drawing.Point(56, 4);
			this.lbColor.Name = "lbColor";
			this.lbColor.Size = new System.Drawing.Size(38, 40);
			this.lbColor.TabIndex = 82;
			// 
			// rbxColor23
			// 
			this.rbxColor23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor23.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor23.BackColor = System.Drawing.Color.Purple;
			this.rbxColor23.Location = new System.Drawing.Point(476, 26);
			this.rbxColor23.Name = "rbxColor23";
			this.rbxColor23.Size = new System.Drawing.Size(18, 18);
			this.rbxColor23.TabIndex = 80;
			// 
			// rbxColor24
			// 
			this.rbxColor24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor24.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor24.BackColor = System.Drawing.Color.Navy;
			this.rbxColor24.Location = new System.Drawing.Point(476, 6);
			this.rbxColor24.Name = "rbxColor24";
			this.rbxColor24.Size = new System.Drawing.Size(18, 18);
			this.rbxColor24.TabIndex = 79;
			// 
			// rbxColor19
			// 
			this.rbxColor19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor19.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor19.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.rbxColor19.Location = new System.Drawing.Point(456, 26);
			this.rbxColor19.Name = "rbxColor19";
			this.rbxColor19.Size = new System.Drawing.Size(18, 18);
			this.rbxColor19.TabIndex = 78;
			// 
			// rbxColor20
			// 
			this.rbxColor20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor20.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor20.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.rbxColor20.Location = new System.Drawing.Point(456, 6);
			this.rbxColor20.Name = "rbxColor20";
			this.rbxColor20.Size = new System.Drawing.Size(18, 18);
			this.rbxColor20.TabIndex = 77;
			// 
			// rbxColor21
			// 
			this.rbxColor21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor21.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor21.BackColor = System.Drawing.Color.Magenta;
			this.rbxColor21.Location = new System.Drawing.Point(436, 26);
			this.rbxColor21.Name = "rbxColor21";
			this.rbxColor21.Size = new System.Drawing.Size(18, 18);
			this.rbxColor21.TabIndex = 76;
			// 
			// rbxColor22
			// 
			this.rbxColor22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor22.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor22.BackColor = System.Drawing.Color.Blue;
			this.rbxColor22.Location = new System.Drawing.Point(436, 6);
			this.rbxColor22.Name = "rbxColor22";
			this.rbxColor22.Size = new System.Drawing.Size(18, 18);
			this.rbxColor22.TabIndex = 75;
			// 
			// rbxColor17
			// 
			this.rbxColor17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor17.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor17.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.rbxColor17.Location = new System.Drawing.Point(416, 26);
			this.rbxColor17.Name = "rbxColor17";
			this.rbxColor17.Size = new System.Drawing.Size(18, 18);
			this.rbxColor17.TabIndex = 74;
			// 
			// rbxColor18
			// 
			this.rbxColor18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor18.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor18.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.rbxColor18.Location = new System.Drawing.Point(416, 6);
			this.rbxColor18.Name = "rbxColor18";
			this.rbxColor18.Size = new System.Drawing.Size(18, 18);
			this.rbxColor18.TabIndex = 73;
			// 
			// rbxColor33
			// 
			this.rbxColor33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor33.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor33.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.rbxColor33.Location = new System.Drawing.Point(396, 26);
			this.rbxColor33.Name = "rbxColor33";
			this.rbxColor33.Size = new System.Drawing.Size(18, 18);
			this.rbxColor33.TabIndex = 72;
			// 
			// rbxColor34
			// 
			this.rbxColor34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor34.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor34.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.rbxColor34.Location = new System.Drawing.Point(396, 6);
			this.rbxColor34.Name = "rbxColor34";
			this.rbxColor34.Size = new System.Drawing.Size(18, 18);
			this.rbxColor34.TabIndex = 71;
			// 
			// rbxColor35
			// 
			this.rbxColor35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor35.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor35.BackColor = System.Drawing.Color.Teal;
			this.rbxColor35.Location = new System.Drawing.Point(376, 26);
			this.rbxColor35.Name = "rbxColor35";
			this.rbxColor35.Size = new System.Drawing.Size(18, 18);
			this.rbxColor35.TabIndex = 70;
			// 
			// rbxColor36
			// 
			this.rbxColor36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor36.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor36.BackColor = System.Drawing.Color.Green;
			this.rbxColor36.Location = new System.Drawing.Point(376, 6);
			this.rbxColor36.Name = "rbxColor36";
			this.rbxColor36.Size = new System.Drawing.Size(18, 18);
			this.rbxColor36.TabIndex = 69;
			// 
			// rbxColor37
			// 
			this.rbxColor37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor37.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor37.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.rbxColor37.Location = new System.Drawing.Point(356, 26);
			this.rbxColor37.Name = "rbxColor37";
			this.rbxColor37.Size = new System.Drawing.Size(18, 18);
			this.rbxColor37.TabIndex = 68;
			// 
			// rbxColor38
			// 
			this.rbxColor38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor38.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor38.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.rbxColor38.Location = new System.Drawing.Point(356, 6);
			this.rbxColor38.Name = "rbxColor38";
			this.rbxColor38.Size = new System.Drawing.Size(18, 18);
			this.rbxColor38.TabIndex = 67;
			// 
			// rbxColor39
			// 
			this.rbxColor39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor39.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor39.BackColor = System.Drawing.Color.Aqua;
			this.rbxColor39.Location = new System.Drawing.Point(336, 26);
			this.rbxColor39.Name = "rbxColor39";
			this.rbxColor39.Size = new System.Drawing.Size(18, 18);
			this.rbxColor39.TabIndex = 66;
			// 
			// rbxColor40
			// 
			this.rbxColor40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor40.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor40.BackColor = System.Drawing.Color.Lime;
			this.rbxColor40.Location = new System.Drawing.Point(336, 6);
			this.rbxColor40.Name = "rbxColor40";
			this.rbxColor40.Size = new System.Drawing.Size(18, 18);
			this.rbxColor40.TabIndex = 65;
			// 
			// rbxColor41
			// 
			this.rbxColor41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor41.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor41.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.rbxColor41.Location = new System.Drawing.Point(316, 26);
			this.rbxColor41.Name = "rbxColor41";
			this.rbxColor41.Size = new System.Drawing.Size(18, 18);
			this.rbxColor41.TabIndex = 64;
			// 
			// rbxColor42
			// 
			this.rbxColor42.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor42.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor42.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.rbxColor42.Location = new System.Drawing.Point(316, 6);
			this.rbxColor42.Name = "rbxColor42";
			this.rbxColor42.Size = new System.Drawing.Size(18, 18);
			this.rbxColor42.TabIndex = 63;
			// 
			// rbxColor43
			// 
			this.rbxColor43.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor43.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor43.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.rbxColor43.Location = new System.Drawing.Point(296, 26);
			this.rbxColor43.Name = "rbxColor43";
			this.rbxColor43.Size = new System.Drawing.Size(18, 18);
			this.rbxColor43.TabIndex = 62;
			// 
			// rbxColor44
			// 
			this.rbxColor44.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor44.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor44.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.rbxColor44.Location = new System.Drawing.Point(296, 6);
			this.rbxColor44.Name = "rbxColor44";
			this.rbxColor44.Size = new System.Drawing.Size(18, 18);
			this.rbxColor44.TabIndex = 61;
			// 
			// rbxColor45
			// 
			this.rbxColor45.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor45.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor45.BackColor = System.Drawing.Color.Olive;
			this.rbxColor45.Location = new System.Drawing.Point(276, 26);
			this.rbxColor45.Name = "rbxColor45";
			this.rbxColor45.Size = new System.Drawing.Size(18, 18);
			this.rbxColor45.TabIndex = 60;
			// 
			// rbxColor46
			// 
			this.rbxColor46.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor46.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor46.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rbxColor46.Location = new System.Drawing.Point(276, 6);
			this.rbxColor46.Name = "rbxColor46";
			this.rbxColor46.Size = new System.Drawing.Size(18, 18);
			this.rbxColor46.TabIndex = 59;
			// 
			// rbxColor47
			// 
			this.rbxColor47.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor47.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor47.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.rbxColor47.Location = new System.Drawing.Point(256, 26);
			this.rbxColor47.Name = "rbxColor47";
			this.rbxColor47.Size = new System.Drawing.Size(18, 18);
			this.rbxColor47.TabIndex = 58;
			// 
			// rbxColor48
			// 
			this.rbxColor48.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor48.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor48.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.rbxColor48.Location = new System.Drawing.Point(256, 6);
			this.rbxColor48.Name = "rbxColor48";
			this.rbxColor48.Size = new System.Drawing.Size(18, 18);
			this.rbxColor48.TabIndex = 57;
			// 
			// rbxColor9
			// 
			this.rbxColor9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor9.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor9.BackColor = System.Drawing.Color.Yellow;
			this.rbxColor9.Location = new System.Drawing.Point(236, 26);
			this.rbxColor9.Name = "rbxColor9";
			this.rbxColor9.Size = new System.Drawing.Size(18, 18);
			this.rbxColor9.TabIndex = 56;
			// 
			// rbxColor10
			// 
			this.rbxColor10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor10.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(0)));
			this.rbxColor10.Location = new System.Drawing.Point(236, 6);
			this.rbxColor10.Name = "rbxColor10";
			this.rbxColor10.Size = new System.Drawing.Size(18, 18);
			this.rbxColor10.TabIndex = 55;
			// 
			// rbxColor11
			// 
			this.rbxColor11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor11.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.rbxColor11.Location = new System.Drawing.Point(216, 26);
			this.rbxColor11.Name = "rbxColor11";
			this.rbxColor11.Size = new System.Drawing.Size(18, 18);
			this.rbxColor11.TabIndex = 54;
			// 
			// rbxColor12
			// 
			this.rbxColor12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor12.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor12.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.rbxColor12.Location = new System.Drawing.Point(216, 6);
			this.rbxColor12.Name = "rbxColor12";
			this.rbxColor12.Size = new System.Drawing.Size(18, 18);
			this.rbxColor12.TabIndex = 53;
			// 
			// rbxColor13
			// 
			this.rbxColor13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor13.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor13.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.rbxColor13.Location = new System.Drawing.Point(196, 26);
			this.rbxColor13.Name = "rbxColor13";
			this.rbxColor13.Size = new System.Drawing.Size(18, 18);
			this.rbxColor13.TabIndex = 52;
			// 
			// rbxColor14
			// 
			this.rbxColor14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor14.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor14.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.rbxColor14.Location = new System.Drawing.Point(196, 6);
			this.rbxColor14.Name = "rbxColor14";
			this.rbxColor14.Size = new System.Drawing.Size(18, 18);
			this.rbxColor14.TabIndex = 51;
			// 
			// rbxColor15
			// 
			this.rbxColor15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor15.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor15.BackColor = System.Drawing.Color.Maroon;
			this.rbxColor15.Location = new System.Drawing.Point(176, 26);
			this.rbxColor15.Name = "rbxColor15";
			this.rbxColor15.Size = new System.Drawing.Size(18, 18);
			this.rbxColor15.TabIndex = 50;
			// 
			// rbxColor16
			// 
			this.rbxColor16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor16.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor16.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.rbxColor16.Checked = true;
			this.rbxColor16.Location = new System.Drawing.Point(176, 6);
			this.rbxColor16.Name = "rbxColor16";
			this.rbxColor16.Size = new System.Drawing.Size(18, 18);
			this.rbxColor16.TabIndex = 49;
			this.rbxColor16.TabStop = true;
			// 
			// rbxColor5
			// 
			this.rbxColor5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor5.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.rbxColor5.Location = new System.Drawing.Point(156, 26);
			this.rbxColor5.Name = "rbxColor5";
			this.rbxColor5.Size = new System.Drawing.Size(18, 18);
			this.rbxColor5.TabIndex = 48;
			// 
			// rbxColor6
			// 
			this.rbxColor6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor6.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor6.BackColor = System.Drawing.Color.Gray;
			this.rbxColor6.Location = new System.Drawing.Point(156, 6);
			this.rbxColor6.Name = "rbxColor6";
			this.rbxColor6.Size = new System.Drawing.Size(18, 18);
			this.rbxColor6.TabIndex = 47;
			// 
			// rbxColor7
			// 
			this.rbxColor7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor7.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor7.BackColor = System.Drawing.Color.Red;
			this.rbxColor7.Location = new System.Drawing.Point(136, 26);
			this.rbxColor7.Name = "rbxColor7";
			this.rbxColor7.Size = new System.Drawing.Size(18, 18);
			this.rbxColor7.TabIndex = 46;
			// 
			// rbxColor8
			// 
			this.rbxColor8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor8.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor8.BackColor = System.Drawing.Color.Silver;
			this.rbxColor8.Location = new System.Drawing.Point(136, 6);
			this.rbxColor8.Name = "rbxColor8";
			this.rbxColor8.Size = new System.Drawing.Size(18, 18);
			this.rbxColor8.TabIndex = 45;
			// 
			// rbxColor3
			// 
			this.rbxColor3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor3.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.rbxColor3.Location = new System.Drawing.Point(116, 26);
			this.rbxColor3.Name = "rbxColor3";
			this.rbxColor3.Size = new System.Drawing.Size(18, 18);
			this.rbxColor3.TabIndex = 44;
			// 
			// rbxColor4
			// 
			this.rbxColor4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor4.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.rbxColor4.Location = new System.Drawing.Point(116, 6);
			this.rbxColor4.Name = "rbxColor4";
			this.rbxColor4.Size = new System.Drawing.Size(18, 18);
			this.rbxColor4.TabIndex = 43;
			// 
			// rbxColor2
			// 
			this.rbxColor2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor2.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.rbxColor2.Location = new System.Drawing.Point(96, 26);
			this.rbxColor2.Name = "rbxColor2";
			this.rbxColor2.Size = new System.Drawing.Size(18, 18);
			this.rbxColor2.TabIndex = 42;
			// 
			// rbxColor1
			// 
			this.rbxColor1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rbxColor1.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbxColor1.Location = new System.Drawing.Point(96, 6);
			this.rbxColor1.Name = "rbxColor1";
			this.rbxColor1.Size = new System.Drawing.Size(18, 18);
			this.rbxColor1.TabIndex = 41;
			// 
			// pnlLeft
			// 
			this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlLeft.Controls.Add(this.pnlLeftTop);
			this.pnlLeft.Controls.Add(this.pnlLeftBottom);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeft.Location = new System.Drawing.Point(0, 0);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Size = new System.Drawing.Size(82, 406);
			this.pnlLeft.TabIndex = 1;
			// 
			// pnlLeftTop
			// 
			this.pnlLeftTop.Controls.Add(this.btnFont);
			this.pnlLeftTop.Controls.Add(this.btnSave);
			this.pnlLeftTop.Controls.Add(this.btnOrig);
			this.pnlLeftTop.Controls.Add(this.btnReduce);
			this.pnlLeftTop.Controls.Add(this.rbArrow);
			this.pnlLeftTop.Controls.Add(this.rbLine);
			this.pnlLeftTop.Controls.Add(this.rbCircle);
			this.pnlLeftTop.Controls.Add(this.rbRect);
			this.pnlLeftTop.Controls.Add(this.btnErase);
			this.pnlLeftTop.Controls.Add(this.rbPen);
			this.pnlLeftTop.Controls.Add(this.rbSelect);
			this.pnlLeftTop.Controls.Add(this.rbText);
			this.pnlLeftTop.Controls.Add(this.lbDrawHeader);
			this.pnlLeftTop.Controls.Add(this.btnMag);
			this.pnlLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlLeftTop.Location = new System.Drawing.Point(0, 0);
			this.pnlLeftTop.Name = "pnlLeftTop";
			this.pnlLeftTop.Size = new System.Drawing.Size(80, 242);
			this.pnlLeftTop.TabIndex = 0;
			// 
			// btnFont
			// 
			this.btnFont.Location = new System.Drawing.Point(4, 180);
			this.btnFont.Name = "btnFont";
			this.btnFont.Size = new System.Drawing.Size(74, 28);
			this.btnFont.TabIndex = 13;
			this.btnFont.Text = "폰트설정";
			this.toolTip.SetToolTip(this.btnFont, "폰트를 설정합니다");
			this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(4, 212);
			this.btnSave.Name = "btnSave";
			this.btnSave.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
			this.btnSave.Size = new System.Drawing.Size(74, 28);
			this.btnSave.TabIndex = 12;
			this.btnSave.Text = "이미지저장";
			this.toolTip.SetToolTip(this.btnSave, "그린 이미지를 저장합니다");
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSave_MouseDown);
			// 
			// btnOrig
			// 
			this.btnOrig.BackColor = System.Drawing.Color.Beige;
			this.btnOrig.Image = ((System.Drawing.Image)(resources.GetObject("btnOrig.Image")));
			this.btnOrig.Location = new System.Drawing.Point(52, 152);
			this.btnOrig.Name = "btnOrig";
			this.btnOrig.Size = new System.Drawing.Size(24, 24);
			this.btnOrig.TabIndex = 11;
			this.btnOrig.Tag = "Original";
			this.toolTip.SetToolTip(this.btnOrig, "이미지를 원래크기로 보여줍니다");
			this.btnOrig.Click += new System.EventHandler(this.OnMagBtnClick);
			// 
			// btnReduce
			// 
			this.btnReduce.BackColor = System.Drawing.Color.Beige;
			this.btnReduce.Image = ((System.Drawing.Image)(resources.GetObject("btnReduce.Image")));
			this.btnReduce.Location = new System.Drawing.Point(28, 152);
			this.btnReduce.Name = "btnReduce";
			this.btnReduce.Size = new System.Drawing.Size(24, 24);
			this.btnReduce.TabIndex = 10;
			this.btnReduce.Tag = "Reduce";
			this.toolTip.SetToolTip(this.btnReduce, "이미지를 축소하여 보여줍니다");
			this.btnReduce.Click += new System.EventHandler(this.OnMagBtnClick);
			// 
			// rbArrow
			// 
			this.rbArrow.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbArrow.BackColor = System.Drawing.Color.Beige;
			this.rbArrow.Image = ((System.Drawing.Image)(resources.GetObject("rbArrow.Image")));
			this.rbArrow.Location = new System.Drawing.Point(40, 114);
			this.rbArrow.Name = "rbArrow";
			this.rbArrow.Size = new System.Drawing.Size(34, 30);
			this.rbArrow.TabIndex = 9;
			this.rbArrow.Tag = "Arrow";
			this.toolTip.SetToolTip(this.rbArrow, "화살표를 그립니다");
			// 
			// rbLine
			// 
			this.rbLine.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbLine.BackColor = System.Drawing.Color.Beige;
			this.rbLine.Image = ((System.Drawing.Image)(resources.GetObject("rbLine.Image")));
			this.rbLine.Location = new System.Drawing.Point(6, 114);
			this.rbLine.Name = "rbLine";
			this.rbLine.Size = new System.Drawing.Size(34, 30);
			this.rbLine.TabIndex = 8;
			this.rbLine.Tag = "Line";
			this.toolTip.SetToolTip(this.rbLine, "라인을 그립니다");
			// 
			// rbCircle
			// 
			this.rbCircle.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbCircle.BackColor = System.Drawing.Color.Beige;
			this.rbCircle.Image = ((System.Drawing.Image)(resources.GetObject("rbCircle.Image")));
			this.rbCircle.Location = new System.Drawing.Point(40, 84);
			this.rbCircle.Name = "rbCircle";
			this.rbCircle.Size = new System.Drawing.Size(34, 30);
			this.rbCircle.TabIndex = 7;
			this.rbCircle.Tag = "Circle";
			this.toolTip.SetToolTip(this.rbCircle, "원을 그립니다");
			// 
			// rbRect
			// 
			this.rbRect.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbRect.BackColor = System.Drawing.Color.Beige;
			this.rbRect.Image = ((System.Drawing.Image)(resources.GetObject("rbRect.Image")));
			this.rbRect.Location = new System.Drawing.Point(6, 84);
			this.rbRect.Name = "rbRect";
			this.rbRect.Size = new System.Drawing.Size(34, 30);
			this.rbRect.TabIndex = 6;
			this.rbRect.Tag = "Rect";
			this.toolTip.SetToolTip(this.rbRect, "사각형을 그립니다");
			// 
			// btnErase
			// 
			this.btnErase.BackColor = System.Drawing.Color.Beige;
			this.btnErase.Image = ((System.Drawing.Image)(resources.GetObject("btnErase.Image")));
			this.btnErase.Location = new System.Drawing.Point(40, 54);
			this.btnErase.Name = "btnErase";
			this.btnErase.Size = new System.Drawing.Size(34, 30);
			this.btnErase.TabIndex = 5;
			this.btnErase.Tag = "Erase";
			this.toolTip.SetToolTip(this.btnErase, "선택한 항목을 삭제합니다");
			this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
			// 
			// rbPen
			// 
			this.rbPen.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbPen.BackColor = System.Drawing.Color.Beige;
			this.rbPen.Image = ((System.Drawing.Image)(resources.GetObject("rbPen.Image")));
			this.rbPen.Location = new System.Drawing.Point(6, 54);
			this.rbPen.Name = "rbPen";
			this.rbPen.Size = new System.Drawing.Size(34, 30);
			this.rbPen.TabIndex = 4;
			this.rbPen.Tag = "Pen";
			this.toolTip.SetToolTip(this.rbPen, "자유곡선을 그립니다");
			// 
			// rbSelect
			// 
			this.rbSelect.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbSelect.BackColor = System.Drawing.Color.GreenYellow;
			this.rbSelect.Checked = true;
			this.rbSelect.Image = ((System.Drawing.Image)(resources.GetObject("rbSelect.Image")));
			this.rbSelect.Location = new System.Drawing.Point(40, 24);
			this.rbSelect.Name = "rbSelect";
			this.rbSelect.Size = new System.Drawing.Size(34, 30);
			this.rbSelect.TabIndex = 3;
			this.rbSelect.TabStop = true;
			this.rbSelect.Tag = "Select";
			this.toolTip.SetToolTip(this.rbSelect, "그린 항목을 선택합니다");
			// 
			// rbText
			// 
			this.rbText.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbText.BackColor = System.Drawing.Color.Beige;
			this.rbText.Image = ((System.Drawing.Image)(resources.GetObject("rbText.Image")));
			this.rbText.Location = new System.Drawing.Point(6, 24);
			this.rbText.Name = "rbText";
			this.rbText.Size = new System.Drawing.Size(34, 30);
			this.rbText.TabIndex = 2;
			this.rbText.Tag = "Text";
			this.toolTip.SetToolTip(this.rbText, "텍스트를 입력합니다");
			// 
			// lbDrawHeader
			// 
			this.lbDrawHeader.Location = new System.Drawing.Point(6, 2);
			this.lbDrawHeader.Name = "lbDrawHeader";
			this.lbDrawHeader.Size = new System.Drawing.Size(70, 20);
			this.lbDrawHeader.TabIndex = 1;
			this.lbDrawHeader.Text = "그리기";
			this.lbDrawHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnMag
			// 
			this.btnMag.BackColor = System.Drawing.Color.Beige;
			this.btnMag.Image = ((System.Drawing.Image)(resources.GetObject("btnMag.Image")));
			this.btnMag.Location = new System.Drawing.Point(4, 152);
			this.btnMag.Name = "btnMag";
			this.btnMag.Size = new System.Drawing.Size(24, 24);
			this.btnMag.TabIndex = 0;
			this.btnMag.Tag = "Magnify";
			this.toolTip.SetToolTip(this.btnMag, "이미지를 확대하여 보여줍니다");
			this.btnMag.Click += new System.EventHandler(this.OnMagBtnClick);
			// 
			// pnlLeftBottom
			// 
			this.pnlLeftBottom.Controls.Add(this.lbLineTick);
			this.pnlLeftBottom.Controls.Add(this.rbTick6);
			this.pnlLeftBottom.Controls.Add(this.rbTick5);
			this.pnlLeftBottom.Controls.Add(this.rbTick4);
			this.pnlLeftBottom.Controls.Add(this.rbTick3);
			this.pnlLeftBottom.Controls.Add(this.rbTick2);
			this.pnlLeftBottom.Controls.Add(this.lbLineTickHeader);
			this.pnlLeftBottom.Controls.Add(this.rbTick1);
			this.pnlLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlLeftBottom.Location = new System.Drawing.Point(0, 242);
			this.pnlLeftBottom.Name = "pnlLeftBottom";
			this.pnlLeftBottom.Size = new System.Drawing.Size(80, 162);
			this.pnlLeftBottom.TabIndex = 1;
			// 
			// lbLineTick
			// 
			this.lbLineTick.BackColor = System.Drawing.Color.Beige;
			this.lbLineTick.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbLineTick.Image = ((System.Drawing.Image)(resources.GetObject("lbLineTick.Image")));
			this.lbLineTick.Location = new System.Drawing.Point(6, 134);
			this.lbLineTick.Name = "lbLineTick";
			this.lbLineTick.Size = new System.Drawing.Size(70, 24);
			this.lbLineTick.TabIndex = 83;
			// 
			// rbTick6
			// 
			this.rbTick6.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbTick6.BackColor = System.Drawing.Color.Beige;
			this.rbTick6.Image = ((System.Drawing.Image)(resources.GetObject("rbTick6.Image")));
			this.rbTick6.Location = new System.Drawing.Point(6, 114);
			this.rbTick6.Name = "rbTick6";
			this.rbTick6.Size = new System.Drawing.Size(70, 18);
			this.rbTick6.TabIndex = 5;
			this.rbTick6.Tag = "6";
			this.toolTip.SetToolTip(this.rbTick6, "선의 굵기를 6pixel로 지정합니다");
			// 
			// rbTick5
			// 
			this.rbTick5.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbTick5.BackColor = System.Drawing.Color.Beige;
			this.rbTick5.Image = ((System.Drawing.Image)(resources.GetObject("rbTick5.Image")));
			this.rbTick5.Location = new System.Drawing.Point(6, 96);
			this.rbTick5.Name = "rbTick5";
			this.rbTick5.Size = new System.Drawing.Size(70, 18);
			this.rbTick5.TabIndex = 4;
			this.rbTick5.Tag = "5";
			this.toolTip.SetToolTip(this.rbTick5, "선의 굵기를 5pixel로 지정합니다");
			// 
			// rbTick4
			// 
			this.rbTick4.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbTick4.BackColor = System.Drawing.Color.Beige;
			this.rbTick4.Image = ((System.Drawing.Image)(resources.GetObject("rbTick4.Image")));
			this.rbTick4.Location = new System.Drawing.Point(6, 78);
			this.rbTick4.Name = "rbTick4";
			this.rbTick4.Size = new System.Drawing.Size(70, 18);
			this.rbTick4.TabIndex = 3;
			this.rbTick4.Tag = "4";
			this.toolTip.SetToolTip(this.rbTick4, "선의 굵기를 4pixel로 지정합니다");
			// 
			// rbTick3
			// 
			this.rbTick3.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbTick3.BackColor = System.Drawing.Color.Beige;
			this.rbTick3.Image = ((System.Drawing.Image)(resources.GetObject("rbTick3.Image")));
			this.rbTick3.Location = new System.Drawing.Point(6, 60);
			this.rbTick3.Name = "rbTick3";
			this.rbTick3.Size = new System.Drawing.Size(70, 18);
			this.rbTick3.TabIndex = 2;
			this.rbTick3.Tag = "3";
			this.toolTip.SetToolTip(this.rbTick3, "선의 굵기를 3pixel로 지정합니다");
			// 
			// rbTick2
			// 
			this.rbTick2.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbTick2.BackColor = System.Drawing.Color.Beige;
			this.rbTick2.Checked = true;
			this.rbTick2.Image = ((System.Drawing.Image)(resources.GetObject("rbTick2.Image")));
			this.rbTick2.Location = new System.Drawing.Point(6, 42);
			this.rbTick2.Name = "rbTick2";
			this.rbTick2.Size = new System.Drawing.Size(70, 18);
			this.rbTick2.TabIndex = 1;
			this.rbTick2.TabStop = true;
			this.rbTick2.Tag = "2";
			this.toolTip.SetToolTip(this.rbTick2, "선의 굵기를 2pixel로 지정합니다");
			// 
			// lbLineTickHeader
			// 
			this.lbLineTickHeader.Location = new System.Drawing.Point(6, 2);
			this.lbLineTickHeader.Name = "lbLineTickHeader";
			this.lbLineTickHeader.Size = new System.Drawing.Size(70, 20);
			this.lbLineTickHeader.TabIndex = 0;
			this.lbLineTickHeader.Text = "선 굵기";
			this.lbLineTickHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// rbTick1
			// 
			this.rbTick1.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbTick1.BackColor = System.Drawing.Color.Beige;
			this.rbTick1.Image = ((System.Drawing.Image)(resources.GetObject("rbTick1.Image")));
			this.rbTick1.Location = new System.Drawing.Point(6, 24);
			this.rbTick1.Name = "rbTick1";
			this.rbTick1.Size = new System.Drawing.Size(70, 18);
			this.rbTick1.TabIndex = 0;
			this.rbTick1.Tag = "1";
			this.toolTip.SetToolTip(this.rbTick1, "선의 굵기를 1pixel로 지정합니다");
			// 
			// pnlFill
			// 
			this.pnlFill.AutoScroll = true;
			this.pnlFill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFill.Controls.Add(this.pnlImage);
			this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlFill.Location = new System.Drawing.Point(82, 0);
			this.pnlFill.Name = "pnlFill";
			this.pnlFill.Size = new System.Drawing.Size(420, 406);
			this.pnlFill.TabIndex = 2;
			// 
			// pnlImage
			// 
			this.pnlImage.BackColor = System.Drawing.Color.White;
			this.pnlImage.Controls.Add(this.txtText);
			this.pnlImage.Location = new System.Drawing.Point(0, 0);
			this.pnlImage.Name = "pnlImage";
			this.pnlImage.Size = new System.Drawing.Size(418, 404);
			this.pnlImage.TabIndex = 2;
			this.pnlImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseUp);
			this.pnlImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlImage_Paint);
			this.pnlImage.DoubleClick += new System.EventHandler(this.pnlImage_DoubleClick);
			this.pnlImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseMove);
			this.pnlImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlImage_MouseDown);
			// 
			// txtText
			// 
			this.txtText.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtText.Location = new System.Drawing.Point(24, 32);
			this.txtText.MaxLength = 500;
			this.txtText.Name = "txtText";
			this.txtText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.txtText.Size = new System.Drawing.Size(126, 128);
			this.txtText.TabIndex = 1;
			this.txtText.Text = "";
			this.txtText.Visible = false;
			this.txtText.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.txtText_ContentsResized);
			this.txtText.VisibleChanged += new System.EventHandler(this.txtText_VisibleChanged);
			// 
			// XImageEditor
			// 
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Controls.Add(this.pnlFill);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.pnlBottom);
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "XImageEditor";
			this.Size = new System.Drawing.Size(502, 456);
			this.pnlBottom.ResumeLayout(false);
			this.pnlLeft.ResumeLayout(false);
			this.pnlLeftTop.ResumeLayout(false);
			this.pnlLeftBottom.ResumeLayout(false);
			this.pnlFill.ResumeLayout(false);
			this.pnlImage.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			//컬러 버튼 Event 연결
			foreach (Control cont in this.pnlBottom.Controls)
				if (cont is System.Windows.Forms.RadioButton)
					((RadioButton)cont).CheckedChanged += new EventHandler(OnColorSelected);

			//선 굵기 RadioButton Event 연결
			foreach (Control cont in this.pnlLeftBottom.Controls)
				if (cont is System.Windows.Forms.RadioButton)
					((RadioButton) cont).CheckedChanged += new EventHandler(OnLineTickSelected);

			//그리기 모드 RadioButton Event 연결
			foreach (Control cont in this.pnlLeftTop.Controls)
				if (cont is System.Windows.Forms.RadioButton)
					((RadioButton) cont).CheckedChanged += new EventHandler(OnDrawModeSelected);


			//기능확장
			this.SetSelectedPointCursor();
			
			//Ink
			//잉크 생성
			pnlImage.InkCollector = new InkCollector(this.pnlImage.Handle);

			//--- 잉크 이벤트 설정 -------------------------------------------------------------------
			//잉크 스트로크 추가시			
			pnlImage.InkCollector.Stroke += new InkCollectorStrokeEventHandler(InkCollector_Stroke);

			//Ink값 초기화
			this.InitInkStatus();

			//잉크초기 비활성화
			pnlImage.InkCollector.Enabled = false;
		}
		
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged (e);

			//Size 변경시에 pnlImage의 Size는 pnlFill의 Size와 동일하게 (ScrollBar가 생기지 않게 -2)
			//Image가 없으면 pnlFillSize에 맞추고 있으면 ImageSize에 따라 조정
			if (this.Image == null)
			{
				this.pnlImage.Size = GetDefaultImageSize();
				this.origpnlImageSize = this.pnlImage.Size;
			}
			else
			{
				//기본 적용
				if (this.zoom != 1.0f)
				{
					this.btnOrig.PerformClick();
				}
				//확대,축소모드가 적용되어 있는 경우와 없는 경우를 나누어 적용
				//확대,축소모드인 경우는 Size 변경하지 않음
				if (this.zoom == 1.0f) ////기본크기이면 Size Default로 설정
				{
					this.pnlImage.Size = GetDefaultImageSize();
					this.origpnlImageSize = this.pnlImage.Size;
				}
			}
		}
		public Size GetDefaultImageSize()
		{
			//pnlFill Size에 맞추어 조정한 Size return (ScrollBar가 생기지 않게 -2)
			return new Size(this.pnlFill.Size.Width -2, this.pnlFill.Size.Height - 2);
		}
		#endregion

		#region Event Handler
		//색깔 선택 버튼 Click Event
		private void OnColorSelected(object sender, EventArgs e)
		{
			RadioButton rbx = (RadioButton) sender;
			if (rbx.Checked)
			{
				//칼라 선택 처리
				ColorSelectedSub(rbx.BackColor);
			}
		}

		//색상표 선택
		private void rbxColorSelect_Click(object sender, System.EventArgs e)
		{
			//색상표에서 칼라 선택
			ColorDialog dlg = new ColorDialog();
			dlg.Color = this.selectedColor;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				ColorSelectedSub(dlg.Color);
			}
		}

		private void ColorSelectedSub(Color color)
		{
			this.selectedColor = color;
			this.lbColor.BackColor = color;
			//TextBox의 ForeColor 변경
			this.txtText.ForeColor = color;
			//현재 편집중일때 DrawItem의 Color도 변경
			if (this.txtText.Visible && (this.txtText.Tag is DrawItem))
				((DrawItem) txtText.Tag).Color = color;

			//Ink Color 변경
			this.SetInkColor(this.selectedColor);

			//선택 모드 일때 선택된 Item이 있으면 선택된 Item의 Color 변경
			if ((this.drawMode == DrawMode.Select) && (this.selectedItemList.Count > 0))
			{
				foreach (DrawItem item in selectedItemList)
					item.Color = color;
				this.pnlImage.Invalidate(true);
			}
		}
		
		//확대,축소, 원래크기 버튼 Click 공통 Event Handler
		private void OnMagBtnClick(object sender, EventArgs e)
		{
			//Image가 설정되지 않았으면 Return
			if (this.Image == null) return;

			Control cont = (Control) sender;
			this.magState = (MagState) Enum.Parse(typeof(MagState), cont.Tag.ToString());

			//선택 Item Clear
			foreach (DrawItem item in this.selectedItemList)
				item.Selected = false;
			this.selectedItemList.Clear();
		
			//case에 따라 처리하기
			switch (magState)
			{
				case MagState.Magnify:  //확대
					if (this.zoom >= 1.5f) return; //3배까지만 확대
					//Image Size MAG_RATIO만큼 확대
					this.zoom += MAG_RATIO;
					this.pnlImage.Size = new Size( (int)((float)origpnlImageSize.Width * this.zoom), (int)((float)origpnlImageSize.Height * this.zoom));
					break;
				case MagState.Reduce:  // 축소
					if (this.zoom <= 0.5f) return;
					//Image Size MAG_RATIO만큼 확대
					this.zoom -= MAG_RATIO;
					this.pnlImage.Size = new Size( (int)((float)origpnlImageSize.Width * this.zoom), (int)((float)origpnlImageSize.Height * this.zoom));
					break;
				case MagState.Original: //원래크기
					this.zoom = 1.0f;
					this.pnlImage.Size = this.origpnlImageSize;
					break;
			}
			
			
			//잉크의 배율 조정
			using (Matrix m = new Matrix())
			{
				m.Scale(this.zoom, this.zoom);
				pnlImage.InkCollector.Renderer.SetViewTransform(m);
			}

			//DrawItem의 배율 조정
			foreach (DrawItem item in this.drawItemList)
			{
				item.Point = new Point((int)((float) item.OrigPoint.X * zoom), (int)((float) item.OrigPoint.Y * zoom));
				item.Size = new Size((int)((float) item.OrigSize.Width * zoom), (int)((float) item.OrigSize.Height * zoom));
				for (int i = 0 ; i < item.PointList.Count ; i++)
				{
					Point pt = (Point) item.OrigPointList[i];
					item.PointList[i] = new Point((int)((float) pt.X * zoom), (int)((float) pt.Y * zoom));
				}
				//선택된 상태이면 선택영역 다시 설정
				if (item.Selected)
				{
					item.SelectedArea = new Rectangle(item.Point.X, item.Point.Y, item.Size.Width, item.Size.Height);
					item.SelectedArea.Inflate(MARGIN,MARGIN);
					item.DraggingArea = item.SelectedArea;
					this.SetSelectedPointList(item);
				}
			}
			//이미지 다시 그림
			this.pnlImage.Invalidate(true);

		}
		//선굵기 RadioButton 공통 Event Handler
		private void OnLineTickSelected(object sender, EventArgs e)
		{
			RadioButton rbo = (RadioButton) sender;
			if (rbo.Checked)  //Tag에 선굵기 관리
			{
				this.lineThick = Int32.Parse(rbo.Tag.ToString());
				//Image Set
				this.lbLineTick.Image = rbo.Image;

				//Ink Tick 변경
				this.SetInkTick(this.lineThick);

				//선택 모드 일때 선택된 Item이 있으면 선택된 Item의 lineThick 변경
				if ((this.drawMode == DrawMode.Select) && (this.selectedItemList.Count > 0))
				{
					foreach (DrawItem item in selectedItemList)
					{
						item.Thick = this.lineThick;
					}
					this.pnlImage.Invalidate(true);
				}
			}
		}
		//그리기 모드 선택 RadioButton 공통 Event Handler
		private void OnDrawModeSelected(object sender, EventArgs e)
		{
			RadioButton rbo = (RadioButton) sender;
			if (rbo.Checked)  //Tag에 DrawMode 관리
			{
				rbo.BackColor = this.selectedRadioColor;
				this.drawMode = (DrawMode) Enum.Parse(typeof(DrawMode), rbo.Tag.ToString());

				//DrawMode가 Select가 아니면 기존 선택 리스트 Clear
				if (drawMode != DrawMode.Select)
				{
					if (this.selectedItemList.Count > 0)
					{
						foreach (DrawItem item in this.selectedItemList)
						{
							item.Selected = false;
							item.SelectedArea = Rectangle.Empty;
							item.DraggingArea = Rectangle.Empty;
						}
						this.selectedItemList.Clear();
					}
					this.pnlImage.Invalidate(true);
					//Cursor Cross
					this.pnlImage.Cursor = System.Windows.Forms.Cursors.Default;

					//Ink추가
					if (drawMode == DrawMode.Pen)
					{
						if (this.pnlImage.InkCollector != null)
						{
							this.SetInkColorAndTick(this.selectedColor, this.lineThick);
							pnlImage.InkCollector.Enabled = true;  //Ink Enable
						}
						
					}
					else
						if (this.pnlImage.InkCollector != null) pnlImage.InkCollector.Enabled = false; //Ink Disable
				}
				else //Select Mode Cursor Cross
				{
					this.pnlImage.Cursor = System.Windows.Forms.Cursors.Cross;
					pnlImage.InkCollector.Enabled = false; //Ink Disable
				}

				if ((drawMode != DrawMode.Text) && this.txtText.Visible) //Text Mode가 아닐때 TextBox가 Visible하면 Not Visible
					this.txtText.Visible = false;  //Logic 처리는 VisibleChanged Event에서 처리함
			}
			else
				rbo.BackColor = this.unSelectedRadioColor;
		}
		private void btnFont_Click(object sender, System.EventArgs e)
		{
			//Text Font 설정
			FontDialog dlg = new FontDialog();
			dlg.Font = this.txtText.Font;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				this.txtText.Font = dlg.Font;
				//현재 편집중일때 DrawItem의 Font도 변경
				if (this.txtText.Visible && (this.txtText.Tag is DrawItem))
					((DrawItem) txtText.Tag).Font = dlg.Font;

				//선택된 Item중 Text Item의 Font 변경
				for (int i = 0 ; i < this.selectedItemList.Count ; i++)
				{
					DrawItem item = (DrawItem) this.selectedItemList[i];
					if (item.ItemType == DrawItemType.Text)
						item.Font = dlg.Font;
				}
				this.pnlImage.Invalidate(true);
			}
		}
		private void btnErase_Click(object sender, System.EventArgs e)
		{
			//삭제 버튼 Click
			//Erase는 한번 확인처리
			//삭제할 항목 선택여부를 확인하고 없으면 에러, 지우기 다시 확인후 지우기 처리
			string title = XMsg.GetMsg("M006"); //삭제확인
			string msg = "";
			if (this.selectedItemList.Count < 1)
			{
				msg = XMsg.GetMsg("M007"); // 삭제할 항목을 선택하십시오.
				XMessageBox.Show(msg, title);
				return;
			}
			//삭제확인후 선택된 Item Remove	
			msg = XMsg.GetMsg("M008"); // 선택한 항목을 삭제하시겠습니까?"
			if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = selectedItemList.Count - 1 ; i >= 0 ; i--)
					this.drawItemList.Remove(selectedItemList[i]);
				this.pnlImage.Cursor = System.Windows.Forms.Cursors.Cross;
				this.selectedItemList.Clear(); //Clear
				//Ink Clear
				this.pnlImage.InkPencil.Strokes.Clear();
				//다시 그림
				this.pnlImage.Invalidate(true);
			}
		}
		private void btnSave_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//btnSave의 Click에서 선택된 Item을 Clear하고 Invalidate()를 호출해도 선택된 영역이 그대로 남아서 Image로 저장된다.
			//MouseDown Event가 Click보다 먼저 발생하므로 여기서 Invalidate() 처리한다.
			if (e.Button == MouseButtons.Left)
			{
				//Image를 원 Size로 변경
				if (this.magState != MagState.Original)
					OnMagBtnClick(this.btnOrig, EventArgs.Empty);

				//SelectedItemList Clear
				if (this.selectedItemList.Count > 0)
				{
					foreach (DrawItem item in this.selectedItemList)
						item.Selected = false;
					this.selectedItemList.Clear();
					this.pnlImage.Invalidate(true);
				
				}
			}
		}
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (this.Image == null) return;
			
			/* 선택Item을 Clear하고 Invalidate하여도 선택영역이 Clear되기 전에 Image가 만들어짐, 따라서, MouseDown Event에서 처리
			//Image를 원 Size로 변경
			if (this.magState != MagState.Original)
				OnMagBtnClick(this.btnOrig, EventArgs.Empty);
			
			
			//SelectedItemList Clear
			if (this.selectedItemList.Count > 0)
			{
				foreach (DrawItem item in this.selectedItemList)
					item.Selected = false;
				this.selectedItemList.Clear();
				this.pnlImage.Invalidate(true);
				
			}
			*/
			
			/*
			//Copy Image
			using (Graphics srcPic = this.pnlImage.CreateGraphics())
			{
				Bitmap srcBmp = new Bitmap(this.pnlImage.Width, this.pnlImage.Height, srcPic);
				using (Graphics srcMem = Graphics.FromImage(srcBmp))
				{
					IntPtr HDC1 = srcPic.GetHdc();
					IntPtr HDC2 = srcMem.GetHdc();
					Gdi32.BitBlt(HDC2,0,0,this.pnlImage.Width, this.pnlImage.Height, HDC1,this.pnlImage.ClientRectangle.X , this.pnlImage.ClientRectangle.Y ,(int)Win32.PatBltTypes.SRCCOPY);
					this.Image = (Image) srcBmp.Clone();
					srcPic.ReleaseHdc(HDC1);
					srcMem.ReleaseHdc(HDC2);
				}
			}
			*/
			
			/* Metafile 이용하여 Save 
			 * 위 Logic BitBlt는 화면 Capture Logic이고, Bitmap을 생성하여 Image 생성시는 Ink가 깨어짐 */
			string fileName = String.Format("{0}\\{1}.wmf", Application.StartupPath, DateTime.Now.ToString("yyyyMMddHHmmss"));
			try
			{
				using (Graphics tG1 = Graphics.FromHwnd(this.pnlImage.Handle))
				{
					IntPtr HDC = tG1.GetHdc();
					using (Metafile mf = new Metafile(fileName, HDC, EmfType.EmfPlusOnly))
					{
						using (Graphics tG2 = Graphics.FromImage(mf))
						{
							tG2.SmoothingMode = SmoothingMode.AntiAlias;
							tG2.Clear(Color.White);
							this.DrawImageSub(tG2);
						}
					}
					tG1.ReleaseHdc(HDC);
				}
			}
			catch
			{
				return;
			}
			if (!File.Exists(fileName)) return;

			//Image.FromFile로 Image를 가져오면 Temp File을 삭제할 수 없으므로 Stream으로 처리함.
			//this.Image = Image.FromFile(fileName);
			FileStream fs = new FileStream(fileName, FileMode.Open);
			try
			{
				long byteCount = fs.Seek(0, SeekOrigin.End);
				fs.Seek(0, SeekOrigin.Begin);
				using (BinaryReader br = new BinaryReader(fs))
				{
					byte[] binary = br.ReadBytes((int) byteCount);
					//Image 객체가 Dispose되기 전에는 Stream이 Close 되면 안되므로 using을 쓰지 않고 처리함.
					MemoryStream ms = new MemoryStream(binary, false);
					this.Image = Image.FromStream(ms);
				}
			}
			catch
			{
				return;
			}
			finally
			{
				fs.Close();
				//임시 파일 삭제
				try
				{
					File.Delete(fileName);
				}
				catch{}
			}
	
			//DrawItemList Clear
			this.drawItemList.Clear();
			

			OnSaveButtonClick(e);
		}
		#endregion

		#region pnlImage Event Handler (그리기, Mouse Event)
		private void pnlImage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			//Image가 없으면 return
			if (this.Image == null) return;
			
			//sub Routine (저장시에도 사용하기 위해)
			DrawImageSub(e.Graphics);
		}
		private void DrawImageSub(Graphics g)
		{
			g.CompositingQuality = CompositingQuality.AssumeLinear;

			g.DrawImage(this.Image, pnlImage.ClientRectangle);
			//Ink Draw
			//PaintInk(g);

			//DrawItemList에 저장된 DrawItem 그리기
			//먼저 저장된 DrawItem이 먼저 그려진 것이므로 Zorder상으로 아래에 위치해야 한다.
			foreach (DrawItem item in this.drawItemList)
				DrawingItem(g, item);
		}
		private Point GetBasePointXAxis(ArrayList pointList, bool isMaxX)
		{
			//X좌표를 기준으로 pointList에서 기준좌표 잡기, isMaxX이면 Max값, isMaxX = false이면 Min값의 좌표
			Point basePoint = Point.Empty;
			for(int i = 0 ; i < pointList.Count ; i++)
			{
				Point point = (Point) pointList[i];
				if (i == 0) basePoint = point;
				if (isMaxX && (basePoint.X <= point.X))
					basePoint = point;
				else if (!isMaxX && (basePoint.X >= point.X))
					basePoint = point;
			}
			return basePoint;
		}
		private Point GetBasePointYAxis(ArrayList pointList, bool isMaxY)
		{
			//Y좌표를 기준으로 pointList에서 기준좌표 잡기, isMaxY이면 Max값, isMaxY = false이면 Min값의 좌표
			Point basePoint = Point.Empty;
			for(int i = 0 ; i < pointList.Count ; i++)
			{
				Point point = (Point) pointList[i];
				if (i == 0) basePoint = point;
				if (isMaxY && (basePoint.Y <= point.Y))
					basePoint = point;
				else if (!isMaxY && (basePoint.Y >= point.Y))
					basePoint = point;
			}
			return basePoint;
		}
		private void pnlImage_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//Left Button Up시에 DrawMode에 따라 처리
			if (e.Button == MouseButtons.Left)
			{
				int xDist = e.X - sPoint.X;
				int yDist = e.Y - sPoint.Y;
				//이동한 위치가 3이하이면 Return
				if ((Math.Abs(xDist) < 2) && (Math.Abs(yDist) < 2)) return;
				
				switch (this.drawMode)
				{
					case DrawMode.Select:  //선택모드
						//선택된 List가 있으면 선택된 리스트를 이동하고, 없으면 해당 영역에 있는 선택가능한 DrawItem을 찾아서 Select한다.
						if (this.selectedItemList.Count > 0)
						{
							/*선택된 모드에 따라 처리 
							 * Center시는 Point만 이동
							 * Size가 변경시는 Rectangle, Circle, Text는 방향에 관계없이 X, Y, Width , Height 변경
							 */
							if (this.partMode != SelectedPartMode.None)
							{
								//기존 BandRect Remove
								//BandRect Remove
								foreach (DrawItem item in this.selectedItemList)
									DrawBandRect(item.DraggingArea.Left, item.DraggingArea.Top, item.DraggingArea.Right, item.DraggingArea.Bottom);

								//선택영역의 Width와 Height는 Inflate(MARGIN,MARGIN)으로 실제 Item의 Size에 2*MARGIN 하므로 배율 계산시에 2*MARGIN을 제외하고 계산함.
								RectangleF rectMove = RectangleF.Empty;

								foreach (DrawItem item in this.selectedItemList)
								{
									switch (item.ItemType)
									{
										case DrawItemType.Rect:
										case DrawItemType.Circle:
										case DrawItemType.Text:
											rectMove = new RectangleF(item.DraggingArea.X - item.SelectedArea.X, item.DraggingArea.Y - item.SelectedArea.Y, (float)(item.DraggingArea.Width -2*MARGIN) /(float)(item.SelectedArea.Width - 2*MARGIN), (float)(item.DraggingArea.Height -2*MARGIN) /(float)(item.SelectedArea.Height - 2*MARGIN));
											item.Point = new Point(item.Point.X + (int)rectMove.X, item.Point.Y + (int)rectMove.Y);
											item.Size = new Size((int)((float)item.Size.Width * rectMove.Width),(int)((float)item.Size.Height * rectMove.Height));
											break;
										case DrawItemType.Line:
										case DrawItemType.Arrow:
											rectMove = new RectangleF(item.DraggingArea.X - item.SelectedArea.X, item.DraggingArea.Y - item.SelectedArea.Y, (float)(item.DraggingArea.Width -2*MARGIN) /(float)(item.SelectedArea.Width - 2*MARGIN), (float)(item.DraggingArea.Height -2*MARGIN) /(float)(item.SelectedArea.Height - 2*MARGIN));
											item.Point = new Point(item.Point.X + (int)rectMove.X, item.Point.Y + (int)rectMove.Y);
											item.Size = new Size((int)((float)item.Size.Width * rectMove.Width),(int)((float)item.Size.Height * rectMove.Height));
											
											if (partMode == SelectedPartMode.Center) //이동만
											{
												//좌표만 변경
												for(int i = 0 ; i < item.PointList.Count ; i++)
												{
													Point point = (Point) item.PointList[i];
													item.PointList[i] = new Point(point.X + (int)rectMove.X, point.Y + (int)rectMove.Y);
												}
											}
											else //Size가 변경되므로 기준좌표를 기준으로 이동처리
											{
												//rectMove.X, Y Top이동시는 .Top 좌표를 기준으로 Bottom이동시는 .Bottom좌표를 기준으로 rectMove 계산
												//Left이동시는 .Left좌표기준, Right이동시는 .Right좌표기준
												//Pen,Arrow,Line은 rectMove.X,와 Y를 Bottom, Right로 이동시에 다시 조정해야함.
												if (partMode.ToString().IndexOf("Bottom") >= 0)
													rectMove.Y = item.DraggingArea.Bottom - item.SelectedArea.Bottom;

												if (partMode.ToString().IndexOf("Right") >= 0)
													rectMove.X = item.DraggingArea.Right - item.SelectedArea.Right;

												/*기준이되는 Point는 변경하지 않고, 나머지 Point만 변경
												 * Top으로 이동시는 Y가 큰값, Bottom으로 이동시는 Y가 작은값, 
												 * Left로 이동시는 X가 큰값, Right로 이동시는 X가 작은값이 기준점
												*/
												Point basePoint = Point.Empty;

												//Y축 좌표 이동
												if (partMode.ToString().IndexOf("Top") >= 0) //Top
													basePoint = this.GetBasePointYAxis(item.PointList, true);
												else if (partMode.ToString().IndexOf("Bottom") >= 0) //Bottom
													basePoint = this.GetBasePointYAxis(item.PointList, false);

												if (basePoint != Point.Empty)
												{
													for(int i = 0 ; i < item.PointList.Count ; i++)
													{
														Point point = (Point) item.PointList[i];
														if (!point.Equals(basePoint))  //기준 Point는 변경하지 않음
															item.PointList[i] = new Point(point.X, point.Y + (int)rectMove.Y);
													}
												}
												basePoint = Point.Empty;
												//X축 좌표이동
												if (partMode.ToString().IndexOf("Left") >= 0) //Left
													basePoint = this.GetBasePointXAxis(item.PointList, true);
												else if (partMode.ToString().IndexOf("Right") >= 0) //Right
													basePoint = this.GetBasePointXAxis(item.PointList, false);

												if (basePoint != Point.Empty)
												{
													for(int i = 0 ; i < item.PointList.Count ; i++)
													{
														Point point = (Point) item.PointList[i];
														if (!point.Equals(basePoint))  //기준 Point는 변경하지 않음
															item.PointList[i] = new Point(point.X + (int)rectMove.X, point.Y);
													}
												}
											}
											break;
										case DrawItemType.Pen:
											rectMove = new RectangleF(item.DraggingArea.X - item.SelectedArea.X, item.DraggingArea.Y - item.SelectedArea.Y, (float)(item.DraggingArea.Width -2*MARGIN) /(float)(item.SelectedArea.Width - 2*MARGIN), (float)(item.DraggingArea.Height -2*MARGIN) /(float)(item.SelectedArea.Height - 2*MARGIN));
											item.Point = new Point(item.Point.X + (int)rectMove.X, item.Point.Y + (int)rectMove.Y);
											item.Size = new Size((int)((float)item.Size.Width * rectMove.Width),(int)((float)item.Size.Height * rectMove.Height));
											if (partMode == SelectedPartMode.Center) //위치만 변경
											{
												Point ptInk = new Point((int) rectMove.X, (int) rectMove.Y);
												PixelToInkSpace(ref ptInk);
												//Stroke Move
												item.PenStroke.Move(ptInk.X, ptInk.Y);
											}
											else //Size 변경
											{
												Rectangle rectInk = item.DraggingArea;
												rectInk.Inflate(-MARGIN,-MARGIN);
												PixelToInkSpace(ref rectInk);
												//Stroke Resize
												item.PenStroke.ScaleToRectangle(rectInk);
											}
											break;
										default:
											break;
									}

									//Item의 SelectedArea, SelectedPoints 다시 SET
									item.SelectedArea = new Rectangle(item.Point.X, item.Point.Y, item.Size.Width, item.Size.Height);
									item.SelectedArea.Inflate(MARGIN,MARGIN);
									item.DraggingArea = Rectangle.Empty;
									this.SetSelectedPointList(item);
								}
								//선택영역
								//Invalidate() - 다시 그림
								this.pnlImage.Invalidate(true);

							}
						}
						else
						{
							//시작위치과 끝위치 Rectangle에 속하는 DrawItem Select
							Rectangle outRect = new Rectangle(Math.Min(e.X, sPoint.X), Math.Min(e.Y, sPoint.Y), Math.Abs(xDist), Math.Abs(yDist));

							foreach (DrawItem item in this.drawItemList)
							{
								//선택영역안에 속하는 DrawItem은 선택상태로 변경
								//Rectangle 기준이 아닌 시작 Point 기준으로 선정함
								if (outRect.Contains(item.Point))
								{
									item.Selected = true;
									//선택 리스트에 Add
									this.selectedItemList.Add(item);
									item.SelectedArea = new Rectangle(item.Point.X, item.Point.Y, item.Size.Width, item.Size.Height);
									item.SelectedArea.Inflate(MARGIN,MARGIN);
									item.DraggingArea = item.SelectedArea;
									this.SetSelectedPointList(item);
								}
							}
							this.pnlImage.Invalidate(true);
						}
						break;

					case DrawMode.Arrow:  //화살표,원,라인,사각형은 동일한 Logic
					case DrawMode.Circle:
					case DrawMode.Line:
					case DrawMode.Rect:
						//2005.12.13 Arrow, Line은 DrawBandLine Call (Rectangle로 표시하지 않고 Line으로 표시함)
						if ((drawMode == DrawMode.Arrow) || (drawMode == DrawMode.Line))
							DrawBandLine(sPoint.X, sPoint.Y, e.X, e.Y);
						else//BandRect Remove
							DrawBandRect(sPoint.X, sPoint.Y, e.X, e.Y);

						//새로운 DrawItem을 생성하여 그리기
						DrawItemType itemType = (DrawItemType) Enum.Parse(typeof(DrawItemType), drawMode.ToString());
						//Point 계산 (시작점과 끝점의 X, Y의 초소값으로 정의함)
						Point pt  = new Point( Math.Min(e.X, sPoint.X), Math.Min(e.Y, sPoint.Y));
						//Size는 절대값으로 구함
						Size size = new Size( Math.Abs(e.X - sPoint.X), Math.Abs(e.Y - sPoint.Y));
						DrawItem drawItem = new DrawItem(itemType, pt, size, this.lineThick,  this.selectedColor);
						//원 Point, Size 보관
						drawItem.OrigPoint = pt;
						drawItem.OrigSize = size;
						//Arrow, Line은 시작점과 끝점을 PointList에 저장
						if ((drawMode == DrawMode.Arrow) || (drawMode == DrawMode.Line))
						{
							//시작점과 끝점을 DrawItem의 PointList에 Add
							drawItem.PointList.Add(this.sPoint);
							drawItem.PointList.Add(new Point(e.X, e.Y));
							//원 Point List 보관
							drawItem.OrigPointList.Add(this.sPoint);
							drawItem.OrigPointList.Add(new Point(e.X, e.Y));
						}
						//List에 Add
						this.drawItemList.Add(drawItem);
						//Item Draw
						DrawingItem(drawItem);
						break;
					
					case DrawMode.Text:
						//txtText Size 조절하여 Visible하게 처리함
						//Point 계산 (시작점과 끝점의 X, Y의 초소값으로 정의함)
						Point pt1  = new Point( Math.Min(e.X, sPoint.X), Math.Min(e.Y, sPoint.Y));
						//Size는 절대값으로 구함
						Size size1 = new Size( Math.Abs(e.X - sPoint.X), Math.Abs(e.Y - sPoint.Y));
						DrawItem drawItem1 = new DrawItem(DrawItemType.Text, pt1, size1, this.lineThick,  this.selectedColor);
						drawItem1.Font = this.txtText.Font;
						//원 Point, Size 보관
						drawItem1.OrigPoint = pt1;
						drawItem1.OrigSize = size1;
						//List에 Add
						this.drawItemList.Add(drawItem1);
						
						//TextBox Visible, Focus
						//Tag에 drawItem 보관
						this.txtText.Location = pt1;
						this.txtText.Size = size1;
						this.txtText.Visible = true;
						this.txtText.Focus();
						this.txtText.Tag = drawItem1;

						break;
					case DrawMode.Pen:
						break;
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				//오른쪽 MouseClick시에 Select Mode에서 한개가 Text가 Selected 되었을때 Popup
				if ((this.drawMode == DrawMode.Select) && (this.selectedItemList.Count == 1))
				{
					DrawItem item  = this.selectedItemList[0] as DrawItem;
					if (item.ItemType == DrawItemType.Text)
						popupMenu.TrackPopup(pnlImage.PointToScreen(new Point(e.X,e.Y)));
				}

			}
		}
		private void pnlImage_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//Left Button시에 DrawMode에 따라 처리
			if (e.Button == MouseButtons.Left) 
			{
				switch (this.drawMode)
				{
					case DrawMode.Select:  //선택
						//선택된 DrawItem이 있으면 그 DrawItem을 Move함, 없으면 BandRect Draw
						if (this.selectedItemList.Count > 0)
						{
							foreach (DrawItem item in this.selectedItemList)
							{
								//기존 BandRect XOR Draw로 Remove
								DrawBandRect(item.DraggingArea.Left, item.DraggingArea.Top, item.DraggingArea.Right, item.DraggingArea.Bottom);
								//새 Dragging Rect 적용
								if (this.SetSelectedItemDraggingArea(item, this.sPoint, new Point(e.X, e.Y)))
									DrawBandRect(item.DraggingArea.Left, item.DraggingArea.Top, item.DraggingArea.Right, item.DraggingArea.Bottom);
							}
						}
						else //선택된 것이 없으면
						{
							//이전 Band Rect Remove
							DrawBandRect(this.sPoint.X, this.sPoint.Y, mPoint.X, mPoint.Y);

							//새 Band Rect Draw
							DrawBandRect(this.sPoint.X, this.sPoint.Y, e.X, e.Y);
						}
						//Move Point Set
						this.mPoint = new Point(e.X, e.Y);
						break;
					case DrawMode.Arrow:
					case DrawMode.Line:
						//이전 BandLine Remove
						DrawBandLine(this.sPoint.X, this.sPoint.Y, mPoint.X, mPoint.Y);
						//X, Y의 차이가 있으면 영역표시 Line 그리기
						if ((e.X - this.sPoint.X != 0) || (e.Y - this.sPoint.Y != 0))
							DrawBandLine(this.sPoint.X, this.sPoint.Y, e.X, e.Y);

						//Move Point Set
						this.mPoint = new Point(e.X, e.Y);
						break;
					case DrawMode.Circle:
					case DrawMode.Rect:
					case DrawMode.Text:

						//이전 BandRect Remove
						DrawBandRect(this.sPoint.X, this.sPoint.Y, mPoint.X, mPoint.Y);
						//X, Y의 차이가 있으면 영역표시 Rect 그리기
						if ((e.X - this.sPoint.X != 0) || (e.Y - this.sPoint.Y != 0))
							DrawBandRect(this.sPoint.X, this.sPoint.Y, e.X, e.Y);

						//Move Point Set
						this.mPoint = new Point(e.X, e.Y);

						break;
					case DrawMode.Pen:
						break;
				}
			}
			else if ((this.drawMode == DrawMode.Select) && (e.Button == MouseButtons.None)) //Select Mode에서 Left Click 하지 않고 Mouse만 이동시
			{
				//선택상태일때 Cursor Set
				if (this.selectedItemList.Count > 0)
				{
					this.partMode = this.GetSelectedPartMode(new Point(e.X, e.Y));
					this.pnlImage.Cursor = this.m_SelectedPointCursor[(int) partMode];
				}
			}
		}
		private void pnlImage_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//Left Button Down시에 DrawMode에 따라 처리
			if (e.Button == MouseButtons.Left)
			{
				this.mPoint = this.sPoint = new Point(e.X, e.Y);

				switch(this.drawMode)
				{
					case DrawMode.Select:  //선택
						//현재 선택된 모드가 None일 경우만 적용
						if (this.partMode != SelectedPartMode.None) return;

						//현재 Mouse Point가 선택된 DrawItem의 영역에 있는지 확인
						bool isInRegion = false;
						foreach (DrawItem item in this.selectedItemList)
						{
							if ((new Rectangle(item.Point, item.Size)).Contains(this.sPoint))
							{
								isInRegion = true;
								break;
							}
						}
						
						if (!isInRegion)
						{
							//선택된 영역안에 없으면 기존 선택영역 Clear, 선택상태 해제
							foreach (DrawItem item in this.selectedItemList)
							{
								item.Selected = false;
								item.SelectedArea = Rectangle.Empty;
								item.DraggingArea = Rectangle.Empty;
							}
							//기존 선택 List Clear
							this.selectedItemList.Clear();

							//drawItemList에 저장된 Item중에서 ZOrder가 앞(List순서상으로는 뒤)부터 검색하여
							//이 Point에 위치하는 DrawItem이 있으면 선택모드로 변경, 선택
							for (int i = this.drawItemList.Count - 1 ; i >= 0 ; i--)
							{
								DrawItem item = this.drawItemList[i] as DrawItem;
								//해당 Item 영역에 속하면 break;
								if ((new Rectangle(item.Point, item.Size)).Contains(this.sPoint))
								{
									this.selectedItemList.Add(item);  //선택된 Item List Add
									item.Selected = true; //선택됨 Flag Set
									item.SelectedArea = new Rectangle(item.Point.X, item.Point.Y, item.Size.Width, item.Size.Height);
									item.SelectedArea.Inflate(MARGIN,MARGIN);
									item.DraggingArea = item.SelectedArea;
									this.SetSelectedPointList(item);
									break;
								}
							}
							//선택된 건이 있으면 다시 그림
							if (this.selectedItemList.Count > 0)
							{
								//Center 선택상태로 변경
								this.partMode = SelectedPartMode.Center;
								this.pnlImage.Cursor = System.Windows.Forms.Cursors.SizeAll;
							}
							this.pnlImage.Invalidate(true);
						}
						break;
					case DrawMode.Text:
						//MouseDown시에 TextBox Visible이면 Visible False
						//Text처리는 TextBox의 VisibleChanged Event에서 처리함.
						if (this.txtText.Visible)
							this.txtText.Visible = false;

						//이미 편집한 Text를 Modify하는 Mode이면 DrawMode를 다시 Selet로 변경
						if (this.isTextModifyMode)
						{
							this.rbSelect.Checked = true;
							this.isTextModifyMode = false;
						}
						break;
					default:
						break;
				}
			}
		}
		private void pnlImage_DoubleClick(object sender, System.EventArgs e)
		{
			//선택모드에서 현재 선택된 DrawItem이 Text일때 Text편집모드로 전환
			if ((this.drawMode == DrawMode.Select) && (this.selectedItemList.Count == 1))
			{
				DrawItem item = this.selectedItemList[0] as DrawItem;
				if (item.ItemType == DrawItemType.Text)
					OnTextEdit(this.pnlImage, EventArgs.Empty);
			}
		}
		#endregion

		#region Image 그리기 DrawingItem
		private void DrawingItem(Graphics g, DrawItem item)
		{
			//DrawItem이 선택된 상태이면 선택 Rectangle Draw
			//선택된 상태는 BandRect로 Draw
			if (item.Selected && (item.SelectedArea != Rectangle.Empty))
			{
				using (SolidBrush sb = new SolidBrush(Color.FromArgb(100, Color.FromArgb(155, 165, 200))))
						   g.FillRectangle(sb, item.SelectedArea);
				using (Pen pen = new Pen(Color.FromArgb(70, 100, 170)))
					g.DrawRectangle(pen, item.SelectedArea);

				for (int i = 0; i < item.SelectedPoints.Length - 1 ; i++) //마지막 Center는 제외
				{
					Rectangle rect = item.SelectedPoints[i];
					g.DrawImage(pointBmp, rect, new RectangleF(0, 0, pointBmp.Width, pointBmp.Height), GraphicsUnit.Pixel);

				}
			}
			switch (item.ItemType)
			{
				case DrawItemType.Line:
				case DrawItemType.Arrow:
					using (Pen pen = new Pen(item.Color, (float) item.Thick))
					{
						//Arrow는 EndCap설정
						if (item.ItemType == DrawItemType.Arrow)
						{
							AdjustableArrowCap arrowCap = new AdjustableArrowCap(4,4);
							pen.EndCap = LineCap.Custom;
							pen.CustomEndCap = arrowCap;
							//pen.EndCap = LineCap.ArrowAnchor;

						}
						//item의 PointList에 저장된 시작점과 끝점으로 Draw
						g.DrawLine(pen, (Point) item.PointList[0], (Point) item.PointList[1]);
					}
					break;
				case DrawItemType.Circle:
					using (Pen pen = new Pen(item.Color, (float) item.Thick))
						g.DrawEllipse(pen, new Rectangle(item.Point, item.Size));
					break;
				case DrawItemType.Rect:
					using (Pen pen = new Pen(item.Color, (float) item.Thick))
						g.DrawRectangle(pen, new Rectangle(item.Point, item.Size));
					break;
				case DrawItemType.Text:
					//Text Draw
					if (item.Text != "")
					{
						using (Brush br = new SolidBrush(item.Color))
							g.DrawString(item.Text, item.Font, br, new RectangleF((PointF) item.Point, (SizeF) item.Size));
					}
					break;
				case DrawItemType.Pen:
					
					if (item.PenStroke == null) return;
					try
					{
						pnlImage.InkCollector.Renderer.Draw(g, item.PenStroke);
					}
					catch(Exception xe)
					{
						Debug.WriteLine("DrawingItem Error=" + xe.Message + "," + xe.StackTrace);
					}
					break;
			}
		}
		//이동시 Rectangle 그리기
		private void DrawBandRect(int X1, int Y1, int X2, int Y2)
		{
			using (Graphics g = Graphics.FromHwnd(this.pnlImage.Handle))
			{
				BandRectangle rect = new BandRectangle();
				rect.DrawXORRectangle(g, X1, Y1, X2, Y2);
			}
		}
		//이동시 Line 그리기 (Arrow, Line)
		private void DrawBandLine(int X1, int Y1, int X2, int Y2)
		{
			using (Graphics g = Graphics.FromHwnd(this.pnlImage.Handle))
			{
				BandRectangle rect = new BandRectangle();
				rect.DrawXORLine(g, X1, Y1, X2, Y2);
			}
		}

		private void DrawingItem(DrawItem item)
		{
			using (Graphics g = Graphics.FromHwnd(this.pnlImage.Handle))
				DrawingItem(g, item);
		}
		#endregion

		#region ProcessCmdKey override (Delete Key 처리)
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			//선택모드일때 Delete Key는 삭제처리 (Erase는 버튼으로 처리하기)
			if (keyData == Keys.Delete && this.drawMode == DrawMode.Select)
				this.btnErase.PerformClick();

			return base.ProcessCmdKey (ref msg, keyData);
		}
		#endregion

		#region TextBox Event Handler
		private void txtText_ContentsResized(object sender, System.Windows.Forms.ContentsResizedEventArgs e)
		{
			//TextBox의 내용이 창크기보다 크거나 작을때 발생하므로 이 이벤트에서 TextBox의 Size를 조정하고
			//Tag에 저장된 DrawItem의 Height도 변경함
			if(this.txtText.Size.Height < e.NewRectangle.Height)
			{
				txtText.Size = new Size(txtText.Width, e.NewRectangle.Height + 5);
				
				if (txtText.Tag is DrawItem)
				{
					DrawItem item = txtText.Tag as DrawItem;
					item.Size = txtText.Size;
				}
			}
		}

		private void txtText_VisibleChanged(object sender, System.EventArgs e)
		{
			//TextBox의 Not Visible시에 Text가 있으면 DrawItem에 Set하고 없으면 Remove
			if (!this.txtText.Visible && (this.txtText.Tag is DrawItem))
			{
				DrawItem item = (DrawItem) this.txtText.Tag;
				item.Font = this.txtText.Font;
				//Text가 있으면 item Draw 없으면 item Remove
				if (this.txtText.Text.TrimEnd() != "")
				{
					item.Text = this.txtText.Text.TrimEnd(); //Text Set
					DrawingItem(item);  //DrawItem
				}
				else
					this.drawItemList.Remove(item);

				//TextBox Clear
				this.txtText.Text = "";
				this.txtText.Location = new Point( -1, -1);
			}
		}
		#endregion

		#region Event Invoker
		protected virtual void OnSaveButtonClick(EventArgs e)
		{
			if (this.SaveButtonClick != null)
				SaveButtonClick(this, e);
		}
		#endregion

		#region Public Method
		public void SetTextBox(string text)
		{
			//TextBox 입력모드이고 TextBox가 Visible일때 Text Set
			if (this.txtText.Visible)
				this.txtText.Text = text;
		}
		/// <summary>
		/// 편집한 이미지를 저장합니다.
		/// </summary>
		public void Save()
		{
			//2005.12.13 Save Button이 Not visible일때 PerformClick시에 Event(btnSave_Click)가 Call되지 않음
			//this.btnSave.PerformClick();
			this.btnSave_Click(this.btnSave, EventArgs.Empty);  //Click Event 직접 Call
		}
		#endregion

		#region OnTextEdit
		private void OnTextEdit(object sender, EventArgs e)
		{
			//이전에 편집된 Text를 새로 편집처리
			//txtText를 Visible하고 Text Set
			if (!this.txtText.Visible)
			{
				DrawItem item = this.selectedItemList[0] as DrawItem;
				this.txtText.Location = item.Point;
				this.txtText.Size = item.Size;
				this.txtText.Text = item.Text;
				this.txtText.ForeColor = item.Color;
				//Tag에 DrawItem 저장
				this.txtText.Tag = item;
				this.txtText.Visible = true;
				this.txtText.Focus();
				this.txtText.SelectionStart = this.txtText.Text.Length;

				//item의 Selection Clear
				item.Selected = false;
				this.pnlImage.Invalidate();

				//Flag Set(이미 편집한 Text를 변경중임, MouseUp Event에서 DrawMode를 다시 Selete로 변경하기 위해 사용)
				this.isTextModifyMode = true;
				
				//DrawMode는 Text로 변경
				this.rbText.Checked = true;
			}
			
			
		}
		#endregion

		#region SetControlTextByLangMode
		private void SetControlTextByLangMode()
		{
			this.lbDrawHeader.Text = XMsg.GetField("F028"); //그리기
			this.lbLineTickHeader.Text = XMsg.GetField("F029"); //라인굵기
			this.btnFont.Text = XMsg.GetField("F030"); //폰트지정
			this.btnSave.Text = XMsg.GetField("F031"); //이미지저장
			this.rbxColorSelect.Text = XMsg.GetField("F032"); //색상표

			//ToolTipText
			this.toolTip.SetToolTip(this.rbText, XMsg.GetMsg("M009")); //텍스트를 입력합니다
			this.toolTip.SetToolTip(this.rbSelect, XMsg.GetMsg("M010")); //그린 항목을 선택합니다
			this.toolTip.SetToolTip(this.rbPen, XMsg.GetMsg("M011")); //자유곡선을 그립니다
			this.toolTip.SetToolTip(this.btnErase, XMsg.GetMsg("M012")); //선택한 항목을 삭제합니다
			this.toolTip.SetToolTip(this.rbRect, XMsg.GetMsg("M013")); //사각형을 그립니다
			this.toolTip.SetToolTip(this.rbCircle, XMsg.GetMsg("M014")); //원을 그립니다
			this.toolTip.SetToolTip(this.rbLine, XMsg.GetMsg("M015")); //라인을 그립니다
			this.toolTip.SetToolTip(this.rbArrow, XMsg.GetMsg("M016")); //화살표를 그립니다
			this.toolTip.SetToolTip(this.btnMag, XMsg.GetMsg("M017")); //이미지를 확대하여 보여줍니다
			this.toolTip.SetToolTip(this.btnReduce, XMsg.GetMsg("M018")); //이미지를 축소하여 보여줍니다
			this.toolTip.SetToolTip(this.btnOrig, XMsg.GetMsg("M019")); //이미지를 원래크기로 보여줍니다
			this.toolTip.SetToolTip(this.btnFont, XMsg.GetMsg("M020")); //폰트를 설정합니다
			this.toolTip.SetToolTip(this.btnSave, XMsg.GetMsg("M021")); //그린 이미지를 저장합니다
			this.toolTip.SetToolTip(this.rbTick1, XMsg.GetMsg("M022")); //선의 굵기를 1pixel로 지정합니다
			this.toolTip.SetToolTip(this.rbTick2, XMsg.GetMsg("M023")); //선의 굵기를 2pixel로 지정합니다
			this.toolTip.SetToolTip(this.rbTick3, XMsg.GetMsg("M024")); //선의 굵기를 3pixel로 지정합니다
			this.toolTip.SetToolTip(this.rbTick4, XMsg.GetMsg("M025")); //선의 굵기를 4pixel로 지정합니다
			this.toolTip.SetToolTip(this.rbTick5, XMsg.GetMsg("M026")); //선의 굵기를 5pixel로 지정합니다
			this.toolTip.SetToolTip(this.rbTick6, XMsg.GetMsg("M027")); //선의 굵기를 6pixel로 지정합니다
			this.toolTip.SetToolTip(this.rbxColorSelect, XMsg.GetMsg("M028")); //색상표를 띄웁니다
		}
		#endregion

		#region 기능추가 Method
		/// <summary>
		/// 선택 포인터들의 영역을 계산한다.
		/// </summary>
		/// <param name="bShow"></param>
		private void SetSelectedPointList(DrawItem item)
		{
			if (item == null) return;
			//   0     1     2
			//   X-----X-----X
			//   |           |
			//   |           |
			//   X 3   8     X 4
			//   |           |
			//   |           |
			//   X-----X-----X
			//   5     6     7
			
			for (int i = 0 ; i < item.SelectedPoints.Length ; i++)
				item.SelectedPoints[i].Size = selectedPointerSize;

			Size szPH = new Size(selectedPointerSize.Width/2-1, selectedPointerSize.Height/2-1);

			// 0
			item.SelectedPoints[0].X = item.SelectedArea.X - szPH.Width;
			item.SelectedPoints[0].Y = item.SelectedArea.Y - szPH.Height;
			// 1
			item.SelectedPoints[1].X = (int)((float)item.SelectedArea.X + ((float)item.SelectedArea.Width / 2F)) - szPH.Width - 1;
			item.SelectedPoints[1].Y = item.SelectedArea.Y - szPH.Height;
			// 2 
			item.SelectedPoints[2].X = item.SelectedArea.Right - szPH.Width - 1;
			item.SelectedPoints[2].Y = item.SelectedArea.Y - szPH.Height;;
			// 3 
			item.SelectedPoints[3].X = item.SelectedArea.X - szPH.Width;
			item.SelectedPoints[3].Y = (int)((float)item.SelectedArea.Y + ((float)item.SelectedArea.Height / 2F)) - szPH.Height - 1;
			// 4 
			item.SelectedPoints[4].X = item.SelectedArea.Right - szPH.Width - 1;
			item.SelectedPoints[4].Y = (int)((float)item.SelectedArea.Y + ((float)item.SelectedArea.Height / 2F)) - szPH.Height - 1;;
			// 5 
			item.SelectedPoints[5].X = item.SelectedArea.X - szPH.Width;
			item.SelectedPoints[5].Y = item.SelectedArea.Bottom - szPH.Height - 1;
			// 6 
			item.SelectedPoints[6].X = (int)((float)item.SelectedArea.X + ((float)item.SelectedArea.Width / 2F)) - szPH.Width - 1;
			item.SelectedPoints[6].Y = item.SelectedArea.Bottom - szPH.Height - 1;;
			// 7 
			item.SelectedPoints[7].X = item.SelectedArea.Right - szPH.Width - 1;
			item.SelectedPoints[7].Y = item.SelectedArea.Bottom - szPH.Height - 1;
			//8 전체영역
			item.SelectedPoints[8].X = item.SelectedArea.X;
			item.SelectedPoints[8].Y = item.SelectedArea.Y;
			item.SelectedPoints[8].Width = item.SelectedArea.Width;
			item.SelectedPoints[8].Height = item.SelectedArea.Height;

		}

		private SelectedPartMode GetSelectedPartMode(Point pt)
		{
			SelectedPartMode mode = SelectedPartMode.None;
			//선택된 Item이 없으면 None Mode
			if (this.selectedItemList.Count < 1) return partMode;
			
			for (int i = 0 ; i < selectedItemList.Count ; i++)
			{
				DrawItem item = (DrawItem) selectedItemList[i];
				for (int j = 0 ; j < item.SelectedPoints.Length ; j++)
				{
					if (item.SelectedPoints[j].Contains(pt))
					{
						mode = (SelectedPartMode)j;
						break;
					}
				}
			}
			return mode;
		}

		/// <summary>
		/// 선택된 개체의 이동 영역
		/// </summary>
		/// <param name="itsPart"></param>
		private bool SetSelectedItemDraggingArea(DrawItem item, Point startPt, Point endPt)
		{
			bool bRet = false;
			Size szMinimum = new Size(15, 15);
			Point ptApp = new Point(endPt.X - startPt.X, endPt.Y - startPt.Y);

			switch (this.partMode)
			{
				case SelectedPartMode.Center:		//선택 영역 이동
				{
					item.DraggingArea = item.SelectedArea;
					item.DraggingArea.X += ptApp.X; 
					item.DraggingArea.Y += ptApp.Y;
					bRet = true;
					break;
				}
				case SelectedPartMode.TopLeft:
				{
					if (((item.SelectedArea.Width - ptApp.X) > szMinimum.Width) && ((item.SelectedArea.Height - ptApp.Y > szMinimum.Height)))
					{
						item.DraggingArea = item.SelectedArea;
						item.DraggingArea.X = item.SelectedArea.X + ptApp.X;
						item.DraggingArea.Y = item.SelectedArea.Y + ptApp.Y;
						item.DraggingArea.Width = item.SelectedArea.Width - ptApp.X;
						item.DraggingArea.Height = item.SelectedArea.Height - ptApp.Y;
					}

					bRet = true;
					break;
				}
				case SelectedPartMode.TopCenter:
				{
					if ((item.SelectedArea.Height - ptApp.Y) > szMinimum.Height)
					{
						item.DraggingArea = item.SelectedArea;
						item.DraggingArea.Y = item.SelectedArea.Y + ptApp.Y;
						item.DraggingArea.Height = item.SelectedArea.Height - ptApp.Y;
					}

					bRet = true;
					break;
				}
				case SelectedPartMode.TopRight:
				{
					if (((item.SelectedArea.Width + ptApp.X) > szMinimum.Width) && ((item.SelectedArea.Height - ptApp.Y > szMinimum.Height)))
					{
						item.DraggingArea = item.SelectedArea;
						item.DraggingArea.Y = item.SelectedArea.Y + ptApp.Y;
						item.DraggingArea.Width = item.SelectedArea.Width + ptApp.X;
						item.DraggingArea.Height = item.SelectedArea.Height - ptApp.Y;
					}

					bRet = true;
					break;
				}
				case SelectedPartMode.MiddleLeft:
				{
					if ((item.SelectedArea.Width - ptApp.X) > szMinimum.Width)
					{
						item.DraggingArea = item.SelectedArea;
						item.DraggingArea.X = item.SelectedArea.X + ptApp.X;
						item.DraggingArea.Width = item.SelectedArea.Width - ptApp.X;
					}

					bRet = true;
					break;
				}
				case SelectedPartMode.MiddleRight:
				{
					if ((item.SelectedArea.Width + ptApp.X) > szMinimum.Width)
					{
						item.DraggingArea = item.SelectedArea;
						item.DraggingArea.Width = item.SelectedArea.Width + ptApp.X;
					}

					bRet = true;
					break;
				}
				case SelectedPartMode.BottomLeft:
				{
					if (((item.SelectedArea.Width - ptApp.X) > szMinimum.Width) && ((item.SelectedArea.Height + ptApp.Y > szMinimum.Height)))
					{
						item.DraggingArea = item.SelectedArea;
						item.DraggingArea.X = item.SelectedArea.X + ptApp.X;
						item.DraggingArea.Width = item.SelectedArea.Width - ptApp.X;
						item.DraggingArea.Height = item.SelectedArea.Height + ptApp.Y;
					}
					
					bRet = true;
					break;
				}
				case SelectedPartMode.BottomCenter:
				{
					if ((item.SelectedArea.Height + ptApp.Y) > szMinimum.Height)
					{
						item.DraggingArea = item.SelectedArea;
						item.DraggingArea.Height = item.SelectedArea.Height + ptApp.Y;
					}

					bRet = true;
					break;
				}
				case SelectedPartMode.BottomRight:
				{
					if (((item.SelectedArea.Width + ptApp.X) > szMinimum.Width) && ((item.SelectedArea.Height + ptApp.Y > szMinimum.Height)))
					{
						item.DraggingArea = item.SelectedArea;
						item.DraggingArea.Width = item.SelectedArea.Width + ptApp.X;
						item.DraggingArea.Height = item.SelectedArea.Height + ptApp.Y;
					}
					bRet = true;
					break;
				}
			}

			return bRet;
		}
		/// <summary>
		/// 각 선택 포이터의 커서를 설정한다.
		/// </summary>
		private void SetSelectedPointCursor()
		{
			m_SelectedPointCursor[0] = System.Windows.Forms.Cursors.SizeNWSE;  //TopLeft
			m_SelectedPointCursor[1] = System.Windows.Forms.Cursors.SizeNS;  //TopCenter
			m_SelectedPointCursor[2] = System.Windows.Forms.Cursors.SizeNESW;  //TopRight
			m_SelectedPointCursor[3] = System.Windows.Forms.Cursors.SizeWE;  //MiddleLeft
			m_SelectedPointCursor[4] = System.Windows.Forms.Cursors.SizeWE;  //MiddleRight
			m_SelectedPointCursor[5] = System.Windows.Forms.Cursors.SizeNESW;  //BottomLeft
			m_SelectedPointCursor[6] = System.Windows.Forms.Cursors.SizeNS;  //BottomCenter
			m_SelectedPointCursor[7] = System.Windows.Forms.Cursors.SizeNWSE;  //BottomRight
			m_SelectedPointCursor[8] = System.Windows.Forms.Cursors.SizeAll;  //Center
			m_SelectedPointCursor[9] = System.Windows.Forms.Cursors.Cross;  //None
		}
		#endregion

		#region InkCollector_Stroke
		/// <summary>
		/// Ink Stroke가 발생한다.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InkCollector_Stroke(object sender, InkCollectorStrokeEventArgs e)
		{
			//Ink로 그리기가 완료후 (Pen으로 그리기시에 MouseUp후에 발생함)
			if (!e.Cursor.Inverted)
			{
				Rectangle rect = e.Stroke.GetBoundingBox();
				InkSpaceToPixel(ref rect);
				//Stroke의 Rect를 Pixel로 Conversion하면 rect이 실제 pnlImage에서의 위치가 나온다. 이 Rect를 가지고, Item을 추가한다.
				DrawItem item = new DrawItem();
				item.ItemType = DrawItemType.Pen;
				item.Point = new Point(rect.X, rect.Y);
				item.Size = new Size(rect.Width, rect.Height);
				item.OrigPoint = item.Point;
				item.OrigSize = item.Size;
				item.SelectedArea = new Rectangle(item.Point, item.Size);
				item.SelectedArea.Inflate(MARGIN,MARGIN);
				item.DraggingArea = item.SelectedArea;
				this.SetSelectedPointList(item);
				//DrawItem List에 Add
				this.drawItemList.Add(item);
				AddStroke(e.Stroke, item);
			}
			e.Cancel = true;
		}
		
		/// <summary>
		/// Ink Stroke를 추가한다.
		/// </summary>
		private void AddStroke(Stroke itsStroke, DrawItem item)
		{
			try
			{
				Ink ink2 = itsStroke.Ink.Clone();
				ink2.Strokes.Scale(1F, 1F);
				RectangleF rectInk = new RectangleF(this.pnlImage.ClientRectangle.X, this.pnlImage.ClientRectangle.Y, this.pnlImage.ClientRectangle.Width, this.pnlImage.ClientRectangle.Height);
				PixelToInkSpace(ref rectInk);
				ink2.Strokes.Move(rectInk.X * -1, rectInk.Y * -1);
				pnlImage.InkPencil.AddStrokesAtRectangle(ink2.Strokes, ink2.Strokes.GetBoundingBox());
				//추가된 Stroke DrawItem의 PenStroke에 할당
				item.PenStroke = pnlImage.InkPencil.Strokes[pnlImage.InkPencil.Strokes.Count - 1];
			}
			catch(Exception xe)
			{
				Debug.WriteLine("AddStroke Error=" + xe.Message + "," + xe.StackTrace);
			}
		}
		/// <summary>
		/// Pixel 단위로 이루어진 RectangleF를 InkSpace로 변경한다.
		/// </summary>
		/// <param name="r"></param>
		private void PixelToInkSpace(ref RectangleF r)
		{
			using (InkCollector ink = new InkCollector())
			{
				using (Graphics g = Graphics.FromHwnd(this.pnlImage.Handle))
				{
					Point leftTop = new Point((int)r.X, (int)r.Y);
					Point widthHeight = new Point((int)r.Width, (int)r.Height);
					ink.Renderer.PixelToInkSpace(g, ref leftTop);
					ink.Renderer.PixelToInkSpace(g, ref widthHeight);

					r.Location = leftTop;
					r.Size = new Size(widthHeight);
				}
			}
		}
		private void PixelToInkSpace(ref Rectangle r)
		{
			using (InkCollector ink = new InkCollector())
			{
				using (Graphics g = Graphics.FromHwnd(this.pnlImage.Handle))
				{
					Point leftTop = new Point(r.X, r.Y);
					Point widthHeight = new Point(r.Width, r.Height);
					ink.Renderer.PixelToInkSpace(g, ref leftTop);
					ink.Renderer.PixelToInkSpace(g, ref widthHeight);

					r.Location = leftTop;
					r.Size = new Size(widthHeight);
				}
			}
		}
		private void PixelToInkSpace(ref Point pt)
		{
			using (InkCollector ink = new InkCollector())
			{
				using (Graphics g = Graphics.FromHwnd(this.pnlImage.Handle))
				{
					ink.Renderer.PixelToInkSpace(g, ref pt);
				}
			}
		}
		private void InkSpaceToPixel(ref Rectangle r)
		{
			using (InkCollector ink = new InkCollector())
			{
				using (Graphics g = Graphics.FromHwnd(this.pnlImage.Handle))
				{
					Point leftTop = new Point(r.X, r.Y);
					Point widthHeight = new Point(r.Width, r.Height);
					ink.Renderer.InkSpaceToPixel(g, ref leftTop);
					ink.Renderer.InkSpaceToPixel(g, ref widthHeight);

					r.Location = leftTop;
					r.Size = new Size(widthHeight);
				}
			}
		}
		private void InkSpaceToPixel(ref Point pt)
		{
			using (InkCollector ink = new InkCollector())
			{
				using (Graphics g = Graphics.FromHwnd(this.pnlImage.Handle))
				{
					ink.Renderer.InkSpaceToPixel(g, ref pt);
				}
			}
		}
		private void InitInkStatus()
		{
			//잉크 상태 초기화.
			pnlImage.InkCollector.DefaultDrawingAttributes.Color = Color.Black;
			pnlImage.InkCollector.DefaultDrawingAttributes.Width = 30;
			pnlImage.InkCollector.DefaultDrawingAttributes.Height = 30;
			pnlImage.InkCollector.DefaultDrawingAttributes.PenTip = PenTip.Ball;
			pnlImage.InkCollector.DefaultDrawingAttributes.Transparency = 0;
			pnlImage.InkCollector.DefaultDrawingAttributes.RasterOperation = RasterOperation.CopyPen;
		}
		private void SetInkColor(Color color)
		{
			pnlImage.InkCollector.DefaultDrawingAttributes.Color = color;
			//현재 선택된 DrawItem중에서 Pen 형식의 Tick도 변경
			if (this.drawMode == DrawMode.Select)
			{
				foreach (DrawItem item in this.selectedItemList)
				{
					if (item.ItemType == DrawItemType.Pen)
					{
						if (item.PenStroke != null)
						{
							item.PenStroke.DrawingAttributes.Color = color;
						}
					}
				}
			}
		}
		private int[] inkTicks = new int[7] {0, 20, 50, 80, 110, 140, 170};
		private void SetInkTick(int tickIndex)
		{
			int tick = inkTicks[tickIndex];
			pnlImage.InkCollector.DefaultDrawingAttributes.Width = tick;
			pnlImage.InkCollector.DefaultDrawingAttributes.Height = tick;
			//현재 선택된 DrawItem중에서 Pen 형식의 Tick도 변경
			if (this.drawMode == DrawMode.Select)
			{
				foreach (DrawItem item in this.selectedItemList)
				{
					if (item.ItemType == DrawItemType.Pen)
					{
						if (item.PenStroke != null)
						{
							item.PenStroke.DrawingAttributes.Width = tick;
							item.PenStroke.DrawingAttributes.Height = tick;
						}
					}
				}
			}
		}
		private void SetInkColorAndTick(Color color, int tickIndex)
		{
			int tick = inkTicks[tickIndex];
			pnlImage.InkCollector.DefaultDrawingAttributes.Width = tick;
			pnlImage.InkCollector.DefaultDrawingAttributes.Height = tick;
			pnlImage.InkCollector.DefaultDrawingAttributes.Color = color;
			//현재 선택된 DrawItem중에서 Pen 형식의 Tick도 변경
			if (this.drawMode == DrawMode.Select)
			{
				foreach (DrawItem item in this.selectedItemList)
				{
					if (item.ItemType == DrawItemType.Pen)
					{
						if (item.PenStroke != null)
						{
							item.PenStroke.DrawingAttributes.Width = tick;
							item.PenStroke.DrawingAttributes.Height = tick;
							item.PenStroke.DrawingAttributes.Color = color;
						}
					}
				}
			}
		}
		#endregion

	}
}

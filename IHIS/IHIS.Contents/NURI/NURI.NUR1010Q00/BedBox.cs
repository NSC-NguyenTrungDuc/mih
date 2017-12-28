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

namespace IHIS.NURI
{
	/// <summary>
	/// BedBox(병상의 환자 Display)에 대한 요약 설명입니다.
	/// </summary>
	internal class BedBox : System.Windows.Forms.PictureBox
	{
		#region static Images
		private static Image ipwonImage = null;
		private static Image orderImage1 = null; //당일 확인 오더 
        private static Image orderImage2 = null; //추후 확인 오더
		private static Image bunmanImage = null;
		private static Image ipwonReserImage = null;		
		private static Image cleanImage = null;
		private static Image toiwonResImage = null;
		private static Image outYnImage = null;
		private static Image ingongYnImage = null;
        private static Image secImage = null;
        private static Image bedLockImage = null;
        private static Image flag1Image = null;
        private static Image flag2Image = null;
        private static Image flag3Image = null;
        private static Image flag4Image = null;
        private static Image flag5Image = null;
		#endregion

		#region enum (BedBox의 현재 Mouse Over상태)
		private enum States
		{
			Normal, //정상상태
			SuNameMouseOver,   //환자이름MouseOver
			BottomLeftMouseOver //추가Order영역 MouseOver
		}
		#endregion

		#region 그리기 관련 Fields
		const int BEDNUMBER_WIDTH = 20;
		const int TITLE_WIDTH = 98; 
		const int TITLE_HEIGHT = 30;
		const int BOTTOM_HEIGHT = 26;
        const int BOTTOM_RIGHT_WIDTH = 80;
        const int BOTTOM_LEFT_WIDTH = 18;
		const int WIDTH_GAP = 1;  // TITLE과 Status사이의 Gap  2
        const int STATUS_WIDTH = 23; //25
		const int STATUS_HEIGHT = 28;
		const int STATUS_GAP = 2;
		private Font numberFont = new Font("MS UI Gothic", 10.0f);
        //private Font titleFont = new Font("MS UI Gothic", 10.5f);
        private Font titleFont = new Font("MS UI Gothic", 9.0f);
		
		private Pen rectPen = Pens.White;
		private Rectangle suNameBounds = new Rectangle(BEDNUMBER_WIDTH, 0, TITLE_WIDTH, TITLE_HEIGHT); //MouseOver시에 환자이름 영역
		private Rectangle bottomLeftBounds = new Rectangle(BEDNUMBER_WIDTH, TITLE_HEIGHT, TITLE_WIDTH/2, BOTTOM_HEIGHT); //추가Order발생Display영역
		private SolidBrush textBrush = new SolidBrush(Color.FromArgb(86,41,0));
        private SolidBrush bedStatus1Brush = new SolidBrush(Color.FromArgb(219, 219, 219));   // 공석색깔 Gray
        private SolidBrush bedStatus2Brush = new SolidBrush(Color.FromArgb(36, 36, 255));   // 일반 환자 Blue
        private SolidBrush bedStatus3Brush = new SolidBrush(Color.FromArgb(255, 255, 38));     // 도움 필요 환자 Yellow
        private SolidBrush bedStatus4Brush = new SolidBrush(Color.FromArgb(255, 21, 21));     // 이동 불가 환자 Red
        private SolidBrush manBrush = new SolidBrush(Color.FromArgb(163, 228, 243));    // 남자 병상 색상
        private SolidBrush womanBrush = new SolidBrush(Color.FromArgb(255, 193, 224));  // 여자 병상 색상
		private SolidBrush emptyBedBrush = new SolidBrush(Color.FromArgb(219,219,219));
		private SolidBrush bLStatus1Brush = new SolidBrush(Color.FromArgb(226,255,248));
		private SolidBrush bLStatus2Brush = new SolidBrush(Color.FromArgb(98,196,172));
		private SolidBrush bRStatus1Brush = new SolidBrush(Color.FromArgb(255,237,252)); //연핑크
		private SolidBrush bRStatus2Brush = new SolidBrush(Color.FromArgb(218,147,216)); //연보라

        //private SolidBrush rTStatus1Brush = new SolidBrush(Color.FromArgb(255, 54, 54)); //빨강
        //private SolidBrush rTStatus2Brush = new SolidBrush(Color.FromArgb(54, 54, 243)); //파랑
        //private SolidBrush rTStatus3Brush = new SolidBrush(Color.FromArgb(255, 255, 54)); //노랑
        //private SolidBrush rTStatus4Brush = new SolidBrush(Color.FromArgb(172, 242, 0)); //녹색
        //private SolidBrush rTStatus5Brush = new SolidBrush(Color.FromArgb(255, 178, 255)); //핑크

        private SolidBrush rTStatus1Brush = new SolidBrush(Color.FromArgb(200, 200, 200)); //하양
        private SolidBrush rTStatus2Brush = new SolidBrush(Color.FromArgb(255, 54, 54)); //빨강
        private SolidBrush rTStatus3Brush = new SolidBrush(Color.FromArgb(200, 200, 200)); //하양
        private SolidBrush rTStatus4Brush = new SolidBrush(Color.FromArgb(200, 200, 200)); //하양
        private SolidBrush rTStatus5Brush = new SolidBrush(Color.FromArgb(200, 200, 200)); //하양

		private SolidBrush rBStatus1Brush = null; //= new SolidBrush(Color.FromArgb(101,159,255));
        private SolidBrush rBStatus2Brush = null; //= new SolidBrush(Color.FromArgb(148,101,255));
        private SolidBrush rBStatus3Brush = null; //= new SolidBrush(Color.FromArgb(97,217,73));
        private SolidBrush rBStatus4Brush = null; //= new SolidBrush(Color.FromArgb(19,40,197));
        private SolidBrush rBStatus5Brush = null; //= new SolidBrush(Color.FromArgb(233,34,212));
        private SolidBrush rBStatus6Brush = null; //= new SolidBrush(Color.FromArgb(206,222,33));

		private StringFormat textFormat   = new StringFormat(StringFormatFlags.NoWrap);
		private SolidBrush doctorBrush ;

		private Image drawImage = null;
		#endregion

		#region Fields having Property
		private string bunho = "";   //환자번호
		private int    pkinp1001 = 0; //입원키
        private string hoDong = "";  //병실Code
		private string hoCode = "";  //호동Code 
        private string kaikei_HoDong = ""; //회계 병동 Code
        private string kaikei_HoCode = ""; //회계 병실 Code
		private int bedNumber = 1;   //병상번호
		private string suName = "";  //환자명
		private string hoSex = "";  //해당병실의 성별
		private bool   isTodayIpwon = false; //당일입원여부
		private bool   isBunman = false;  //분만여부
        private string isYokchangYn = "N";  //욕창환자여부
        private string isGamyumYn = "N";  //감염환자여부
        private bool isIpwonReser = false; //미래입원예약여부
        private string reserInfo = ""; //미래예약정보
		private string ipwonMokjuk  = ""; //입원목적
		private BedStatus bedStatus = BedStatus.State1;  //Default 공석
		private RightTopStatus  rTStatus = RightTopStatus.State1;
		private RightBottomStatus rBStatus = RightBottomStatus.State1;
		private BottomLeftStatus  bLStatus = BottomLeftStatus.State1;
		private BottomRightStatus  bRStatus = BottomRightStatus.State1;
		private HumanSex  sexKind = HumanSex.Man;
		private bool redraw = false;  //속성 변경시 OnPaint에서 변경된 속성에 따른 Paint를 할지 여부(최초 데이타를 가지고 속성설정할때 자주 그리는 것을 방지)
		private States state = States.Normal; //BedBox의 상태
		private bool selected = false;  //Mouse의 LeftButton을 Click했는지 여부(선택된 상태 보여주기)
		private string rgb    = "";
        private string bedCStatus = "";     // 베드상태(청소중....)
        private string toiwonResDate = "";  // 퇴원 예약 시간 
        private string toiwonGojiYn = "";   // 오더종료여부
        private string bedLockText = "";    // 병상잠금
		private bool   isOut = false;       // 외출 여부
		private bool   isIngongYn = false;  // 인공호흡기여부
		private bool   issecYn = false;     // 환자의입원사실을비밀로해야하는여부
        private bool status_flag1 = false;  // 상태 플래그 1 == 산소 호흡기 여부
        private bool status_flag2 = false;  // 상태 플래그 2 == 심전도 여부
        private bool status_flag3 = false;  // 상태 플래그 3 == 点灯虫
        private bool status_flag4 = false;  // 상태 플래그 4
        private bool status_flag5 = false;  // 상태 플래그 5

        private string not_yet_drg_date = "";

		#endregion

		#region Properties
		[DefaultValue(""),Category("추가속성"),
		Description("병상의 환자번호를 설정합니다.")]
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
		[DefaultValue(""),Category("추가속성"),
		Description("병상의 DOCTOR RGB값을 설정합니다.")]
		public string Rgb
		{
			get { return rgb;}
			set 
			{
				if (rgb != value)
				{
					rgb = value;
					Invalidate(true);
				}
			}
		}
		[DefaultValue(""),Category("추가속성"),
		Description("병상의 입원키를 설정합니다.")]
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
        public string HoDong  //이 병상이 속하는 HoDong
        {
            get { return hoDong; }
            set { hoDong = value; }

        }

		[Browsable(false)]
		public string HoCode  //이 병상이 속하는 HoCode
		{
			get { return hoCode;}
			set { hoCode = value;}

		}
        [Browsable(false)]
        public string Kaikei_HoDong
        {
            get { return kaikei_HoDong; }
            set { kaikei_HoDong = value; }

        }
        [Browsable(false)]
        public string Kaikei_HoCode
        {
            get { return kaikei_HoCode; }
            set { kaikei_HoCode = value; }

        }
		//당일입원여부
		[Browsable(false)]
		public bool IsTodayIpwon  
		{
			get { return isTodayIpwon;}
			set { isTodayIpwon = value;}

		}
		//분만여부
		[Browsable(false)]
		public bool IsBunman
		{
			get { return isBunman;}
			set { isBunman = value;}

		}
		//욕창환자여부
		[Browsable(false)]
		public string IsYokchangYn
		{
			get { return isYokchangYn;}
			set { isYokchangYn = value;}

        }
        //감염증환자여부
        [Browsable(false)]
        public string IsGamyumYn
        {
            get { return isGamyumYn; }
            set { isGamyumYn = value; }

        }
		//외출 여부
		[Browsable(false)]
		public bool IsOut
		{
			get { return isOut;}
			set { isOut = value;}

		}
		//인공호흡기
		[Browsable(false)]
		public bool IsIngongYn
		{
			get { return isIngongYn;}
			set { isIngongYn = value;}

		}
		//환자의입원사실을비밀로해야하는여부
		[Browsable(false)]
		public bool IssecYn
		{
			get { return issecYn;}
			set { issecYn = value;}

		}
		//미래예약여부
		[Browsable(false)]
		public bool IsIpwonReser
		{
			get { return isIpwonReser;}
			set { isIpwonReser = value;}

		}
        //미래예약정보
		[Browsable(false)]
        public string ReserInfo
		{
            get { return reserInfo; }
            set { reserInfo = value; }

		}
        
		//입원목적
		[Browsable(false)]
		public string IpwonMokjuk
		{
			get { return ipwonMokjuk;}
			set { ipwonMokjuk = value;}

		}
		//베드상태(청소중....)
		[Browsable(false)]
		public string BedCStatus
		{
			get { return bedCStatus;}
			set { bedCStatus = value;}

		}
		//퇴원예정일시
		[Browsable(false)]
		public string ToiwonResDate
		{
			get { return toiwonResDate;}
			set { toiwonResDate = value;}

		}
        //오더종료여부
        [Browsable(false)]
        public string ToiwonGojiYn
        {
            get { return toiwonGojiYn; }
            set { toiwonGojiYn = value; }

        }
        //상태 플래그 1
        [Browsable(false)]
        public bool Status_Flag1
        {
            get { return status_flag1; }
            set { status_flag1 = value; }

        }
        //상태 플래그 2
        [Browsable(false)]
        public bool Status_Flag2
        {
            get { return status_flag2; }
            set { status_flag2 = value; }

        }
        //상태 플래그 3
        [Browsable(false)]
        public bool Status_Flag3
        {
            get { return status_flag3; }
            set { status_flag3 = value; }

        }
        //상태 플래그 4
        [Browsable(false)]
        public bool Status_Flag4
        {
            get { return status_flag4; }
            set { status_flag4 = value; }

        }
        //상태 플래그 5
        [Browsable(false)]
        public bool Status_Flag5
        {
            get { return status_flag5; }
            set { status_flag5 = value; }

        }

        //투약 최근 날짜
        [Browsable(false)]
        public string Not_yet_drg_date
        {
            get { return not_yet_drg_date; }
            set { not_yet_drg_date = value; }
        }

        //병상의 성별
		[Browsable(false)]
		public string HoSex  
		{
			get { return hoSex;}
			set { hoSex = value;}

		}
		[DefaultValue(1),Category("추가속성"),
		Description("병상의 Number를 설정합니다.")]
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
		[DefaultValue(""),Category("추가속성"),
		Description("병상의 환자명을 설정합니다.")]
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
		[DefaultValue(BedStatus.State1),Category("추가속성"),
		Description("병상의 상태를 설정합니다.")]
		public BedStatus BedStatus
		{
			get { return bedStatus;}
			set 
			{
				if (bedStatus != value)
				{
					bedStatus = value;

                    if (bedStatus == BedStatus.State1)  //공석일 경우는 SIZE 작게
                        this.Size = new Size(BEDNUMBER_WIDTH + TITLE_WIDTH, this.Height);
                    else  //사람이 있으면 SIZE 크게
                        this.Size = new Size(BEDNUMBER_WIDTH + TITLE_WIDTH + WIDTH_GAP + STATUS_WIDTH, this.Height);

					Invalidate(true);
				}
			}
		}
		[DefaultValue(RightTopStatus.State1),Category("추가속성"),
		Description("환자의 상태(담당간호사팀)을 설정합니다.")]
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
		[DefaultValue(RightBottomStatus.State1),Category("추가속성"),
		Description("환자의 상태(환자유형)을 설정합니다.")]
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
		[DefaultValue(BottomLeftStatus.State1),Category("추가속성"),
		Description("환자의 상태(선택진료환자여부)을 설정합니다.")]
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
		[DefaultValue(BottomRightStatus.State1),Category("추가속성"),
		Description("환자의 상태(CP환자여부)을 설정합니다.")]
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
		[DefaultValue(HumanSex.Man),Category("추가속성"),
		Description("환자의 성별을 설정합니다.")]
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
					if (redraw) //다시 그림
						Invalidate(true);
				}
			}
		}
		[Browsable(false)]
		public bool Selected //이 BedBox가 선택되었는지 여부
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
        [DefaultValue(""), Category("추가속성"),
        Description("병상의 잠금정보를 설정합니다.")]
        public string BedLockText
        {
            get { return bedLockText; }
            set
            {
                this.bedLockText = value;
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
		[Browsable(true),Category("추가이벤트"),
		Description("환자영역을 Click시에 발생하는 Event입니다.")]
		public event EventHandler SuNameClick;
		[Browsable(true),Category("추가이벤트"),
		Description("환자영역을 DoubleClick시에 발생하는 Event입니다.")]
		public event EventHandler SuNameDoubleClick;
		[Browsable(true),Category("추가이벤트"),
		Description("환자영역을 MouseDown시에 발생하는 Event입니다.")]
		public event MouseEventHandler SuNameMouseDown;
		[Browsable(true),Category("추가이벤트"),
		Description("추가처방발생 표시영역 Click시에 발생하는 Event입니다.")]
		public event EventHandler BottomLeftClick;
		[Browsable(true),Category("추가이벤트"),
		Description("추가처방발생 표시영역 DoubleClick시에 발생하는 Event입니다.")]
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

		#region 생성자
		//병상을 보여주는 Picture Box
		public BedBox()
		{
			this.Size = new Size(BEDNUMBER_WIDTH + TITLE_WIDTH, TITLE_HEIGHT + BOTTOM_HEIGHT);
			this.BackColor = Color.Transparent;  //BackColor 투명색
			textFormat.LineAlignment = StringAlignment.Center;
			textFormat.Alignment = StringAlignment.Center;
			textFormat.Trimming = StringTrimming.EllipsisCharacter;

			System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
			BedBox.ipwonImage = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.ipwon.ico"));
            //BedBox.orderImage = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.order.ico"));
            //BedBox.orderImage1 = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.orangpuls.gif"));
            BedBox.orderImage1 = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.8.gif"));
            //BedBox.orderImage = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.grnpuls.gif"));
            //BedBox.orderImage2 = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.aquapuls.gif"));
            BedBox.orderImage2 = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.3.gif"));
			BedBox.bunmanImage = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.bunman.ico"));
			BedBox.ipwonReserImage = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.ipwonReser.gif"));
			BedBox.toiwonResImage = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.toiwonRes.gif"));
			BedBox.cleanImage = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.clean.gif"));
			BedBox.outYnImage = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.isout.gif"));
			BedBox.ingongYnImage = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.O2.ico"));
            BedBox.secImage = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.secImage.gif"));
            BedBox.bedLockImage = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.lock.gif"));
            BedBox.flag1Image = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.flag1.ico"));
            BedBox.flag2Image = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.flag2.ico"));
            BedBox.flag3Image = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.flag3.ico"));
            BedBox.flag4Image = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.flag4.ico"));
            BedBox.flag5Image = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.NURI.Images.flag5.ico"));

            //ImageAnimator.Animate(orderImage1, new EventHandler(this.OnFrameChanged));
            //ImageAnimator.Animate(orderImage2, new EventHandler(this.OnFrameChanged));
		}
		#endregion
        
        private void OnFrameChanged(object sender, EventArgs e)
        {
            //Invalidate();
        }

		#region MouseMove, MouseLeave, OnMouseDown, OnClick, OnDoubleClick
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove (e);
			//Bed상태가 공상이 아닐때 환자명, 추가 Order여부 영역에 있는지 여부에 따라 BedBox 상태변경 
			if (this.bedStatus != BedStatus.State1)
			{
				//환자영역Bound에 Point가 있으면 상태변경
				if (this.suNameBounds.Contains(e.X, e.Y))
				{
					if (this.state != States.SuNameMouseOver)
					{
						this.state = States.SuNameMouseOver;
						Invalidate(true);
					}
				}
					//추가Order발생 표시 영역에 있을때
				else if (this.bottomLeftBounds.Contains(e.X, e.Y))  
				{
					if (this.state != States.BottomLeftMouseOver)
					{
						this.state = States.BottomLeftMouseOver;
						Invalidate(true);
					}
				}
				else  //그외 영역에서는 정상
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
			//Bed상태가 공상이 아닐때, Left ButtonClick시에 선택상태 변경
            //if (this.bedStatus != BedStatus.General)
            //{
				//환자번호영역을 Click하면 Invalidate
				if ((e.Button == MouseButtons.Left) && this.suNameBounds.Contains(e.X, e.Y))
				{
					//SuNameMouseDown Event Call
					OnSuNameMouseDown(e);
				}
            //}
			
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave (e);
			//일반상태가 아니면 일반상태 복구
			if (state != States.Normal)
			{
				state = States.Normal;
				this.Invalidate(true);
			}
		}
		protected override void OnClick(EventArgs e)
		{
			//환자영역 Click시는 SuNameClick Event, 추가처방발생표시영역 Click시는 BottomLeftClick Event 발생시킴
			if (this.state == States.SuNameMouseOver)
				OnSuNameClick(EventArgs.Empty);
			else if (this.state == States.BottomLeftMouseOver)
				OnBottomLeftClick(EventArgs.Empty);

            this.Focus();

		}
		protected override void OnDoubleClick(EventArgs e)
		{
			//환자영역 DoubleClick시는 SuNameDoubleClick Event, 추가처방발생표시영역 Click시는 BottomLeftDoubleClick Event 발생시킴
			if (this.state == States.SuNameMouseOver)
				OnSuNameDoubleClick(EventArgs.Empty);
			else if (this.state == States.BottomLeftMouseOver)
				OnBottomLeftDoubleClick(EventArgs.Empty);
		}
		#endregion

		#region OnPaint (병상의 상태에 따라 병상을 그림)

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			int width = this.Size.Width;
			int height = this.Size.Height;
			Rectangle rect = Rectangle.Empty;
			string drawText = "";
			SizeF fontSize = SizeF.Empty;

			//Redraw Flag가 설정되어 있으면 그리지 않음
			//데이타를 가지고 속성 설정시 최초 false하고 다 설정한 다음에 true로 설정하여 Paint를 효과적으로 수행하기 위함
			if (!this.redraw) return;

            try
            {
                //병상 Number영역 Draw
                rect = new Rectangle(0, 0, BEDNUMBER_WIDTH, TITLE_HEIGHT + BOTTOM_HEIGHT);
                //Fill Rect (병상의 상태에 따라 색깔 지정)
                Brush fillBrush = bedStatus1Brush;

                switch (this.bedStatus)
                {
                    case BedStatus.State1: //공석
                        fillBrush = bedStatus1Brush;  //Gray
                        break;
                    case BedStatus.State2: //호송
                        fillBrush = bedStatus2Brush; //Ivory
                        break;
                    case BedStatus.State3: //독보
                        fillBrush = bedStatus3Brush; //Green
                        break;
                    case BedStatus.State4: //단송
                        fillBrush = bedStatus4Brush; //Red
                        break;
                }

                e.Graphics.FillRectangle(fillBrush, rect);
                //Draw Rect
                e.Graphics.DrawRectangle(rectPen, rect);
                //병실번호 Draw
                //fontSize = e.Graphics.MeasureString(this.bedNumber.ToString(), numberFont);
                fontSize = DrawHelper.MeasureString(e.Graphics, this.bedNumber.ToString(), numberFont, ContentAlignment.MiddleCenter);
                e.Graphics.DrawString(this.bedNumber.ToString(), numberFont, textBrush,
                    DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter, rect.X, rect.Y, rect.Width, rect.Height, fontSize.Width, fontSize.Height));

                //공석과 환자가 있는 경우로 구분하여 SET
                if (this.bedStatus == BedStatus.State1)
                {
                    drawImage = null;
                    switch (this.bedCStatus)
                    {
                        //병상의 상태에 따라 텍스트, 이미지 세팅
                        case "01":
                            if (this.isIpwonReser)
                            {
                                drawText = "予約中"; //예약중
                                drawImage = BedBox.ipwonReserImage;
                            }
                            break;
                        case "04":
                            drawText = "清掃中"; //청소중
                            drawImage = BedBox.cleanImage;
                            break;
                        case "05":
                            drawText = "ロック中"; //잠금중
                            drawImage = BedBox.bedLockImage;
                            break;
                        default:
                            drawText = "空 床"; //공상
                            drawImage = null;
                            break;
                    }

                    //병상 right draw 영역
                    rect = new Rectangle(BEDNUMBER_WIDTH, 0, TITLE_WIDTH, TITLE_HEIGHT + BOTTOM_HEIGHT);
                    //Fill Brush는 Gray
                    fillBrush = emptyBedBrush;

                    e.Graphics.FillRectangle(fillBrush, rect);
                    e.Graphics.DrawRectangle(rectPen, rect); //흰색 지정

                    //공석 Text Draw
                    fontSize = e.Graphics.MeasureString(drawText, titleFont);
                    e.Graphics.DrawString(drawText, titleFont, textBrush,
                        DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter, rect.X, rect.Y, rect.Width, rect.Height, fontSize.Width, fontSize.Height));

                    if (drawImage != null)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.MiddleLeft, rect.Left, rect.Top, rect.Width, rect.Height, drawImage.Width, drawImage.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        e.Graphics.DrawImage(drawImage, Rectangle.Truncate(imageRect));
                    }

                    //LeftButtonClick상태이면 선택된 모양 보여주기(3Pixel -> 2Pixel)
                    if (this.selected)
                    {
                        rect = new Rectangle(1, 1, BEDNUMBER_WIDTH + TITLE_WIDTH - 2, TITLE_HEIGHT + BOTTOM_HEIGHT - 4);
                        e.Graphics.DrawRectangle(Pens.OrangeRed, rect);
                        rect = new Rectangle(2, 2, BEDNUMBER_WIDTH + TITLE_WIDTH - 4, TITLE_HEIGHT + BOTTOM_HEIGHT - 6);
                        e.Graphics.DrawRectangle(Pens.Red, rect);

                    }
                }
                else
                {
                    //분만환자 이미지 표시
                    drawImage = null;
                    if (this.isBunman)
                        drawImage = BedBox.bunmanImage;

                    if (drawImage != null)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.BottomCenter, rect.Left, rect.Top, rect.Width, rect.Height, drawImage.Width, drawImage.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        e.Graphics.DrawImage(drawImage, Rectangle.Truncate(imageRect));
                    }

                    //외출중 이미지 표시
                    drawImage = null;
                    if (this.isOut)
                        drawImage = BedBox.outYnImage;

                    if (drawImage != null)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.TopCenter, rect.Left, rect.Top, rect.Width, rect.Height, drawImage.Width, drawImage.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        e.Graphics.DrawImage(drawImage, Rectangle.Truncate(imageRect));
                    }

                    //인공호흡기 이미지 표시
                    drawImage = null;
                    if (this.isIngongYn)
                        drawImage = BedBox.ingongYnImage;

                    if (drawImage != null)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.TopCenter, rect.Left, rect.Top, rect.Width, rect.Height, drawImage.Width, drawImage.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        e.Graphics.DrawImage(drawImage, Rectangle.Truncate(imageRect));
                    }

                    //환자의 성별에 따라 바탕 변경
                    fillBrush = manBrush;  //남성은 파란색
                    if (this.sexKind == HumanSex.Woman) //여성은 빨간색
                        fillBrush = womanBrush;
                    rect = new Rectangle(BEDNUMBER_WIDTH, 0, TITLE_WIDTH, TITLE_HEIGHT);

                    //환자영역에 MouseOver상태이면 강조 Rect Set
                    if (this.state == States.SuNameMouseOver)
                    {
                        //Man Mouse Over Color
                        Brush overBrush = new LinearGradientBrush(rect, Color.FromArgb(193, 228, 249), Color.FromArgb(119, 188, 225), 90.0f);
                        //Woman Mouse Over Color
                        if (this.sexKind == HumanSex.Woman)
                            overBrush = new LinearGradientBrush(rect, Color.FromArgb(253, 216, 137), Color.FromArgb(248, 178, 48), 90.0f);

                        e.Graphics.FillRectangle(overBrush, rect);
                        overBrush.Dispose();
                    }
                    else  //정상상태이면 Gradient적용하지 않음
                    {
                        //Fill Brush
                        e.Graphics.FillRectangle(fillBrush, rect);
                    }
                    e.Graphics.DrawRectangle(rectPen, rect);


                    //환자명  Draw
                    if (this.suName != "")
                    {
                        fontSize = e.Graphics.MeasureString(this.suName, titleFont);
                        //StringFormat 적용하여 긴이름은 ...으로 보이게함
                        e.Graphics.DrawString(this.suName, titleFont, textBrush, rect, textFormat);
                    }

                    //입원사실을 비밀로 해야 하는 환자 이미지 표현
                    drawImage = null;

                    if (this.issecYn)
                        drawImage = BedBox.secImage;
                    else
                        drawImage = null;

                    if (drawImage != null)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.BottomCenter, rect.Left, rect.Top, rect.Width, rect.Height, drawImage.Width, drawImage.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        e.Graphics.DrawImage(drawImage, Rectangle.Truncate(imageRect));
                    }

                    //아래 영역 Fill, Draw Rect
                    //rect = new Rectangle(BEDNUMBER_WIDTH, TITLE_HEIGHT, TITLE_WIDTH/2, BOTTOM_HEIGHT);
                    rect = new Rectangle(BEDNUMBER_WIDTH, TITLE_HEIGHT, BOTTOM_LEFT_WIDTH, BOTTOM_HEIGHT);

                    //아래 좌측영역은 (추가오더 발생여부) BottomLeftStatus에 따라 fillBrush SET
                    fillBrush = this.bLStatus1Brush; //N 기본 LightYellow (없음)
                    switch (this.bLStatus)
                    {
                        case BottomLeftStatus.State2:
                            fillBrush = bLStatus2Brush;  //Y OrangeRed
                            break;
                    }

                    //아래좌축영역이 MouseOver상태이면 표시
                    if (this.state == States.BottomLeftMouseOver)
                    {
                        Brush overBrush = new LinearGradientBrush(rect, Color.FromArgb(226, 255, 248), Color.FromArgb(107, 224, 254), 90.0f);
                        //추가오더가 있으면 더 진하게
                        if (this.bLStatus == BottomLeftStatus.State2 || this.bLStatus == BottomLeftStatus.State3)
                            overBrush = new LinearGradientBrush(rect, Color.FromArgb(178, 245, 205), Color.FromArgb(44, 154, 90), 90.0f);

                        e.Graphics.FillRectangle(overBrush, rect);
                        overBrush.Dispose();
                    }
                    else
                        e.Graphics.FillRectangle(fillBrush, rect);

                    //DrawRect
                    e.Graphics.DrawRectangle(rectPen, rect);

                    //미확인오더가 있는경우 이미지 표시

                    if (this.bLStatus == BottomLeftStatus.State2)
                        drawImage = BedBox.orderImage1;
                    else if (this.bLStatus == BottomLeftStatus.State3)
                        drawImage = BedBox.orderImage2;

                    if (drawImage != null)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter, rect.Left, rect.Top, rect.Width, rect.Height, drawImage.Width, drawImage.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        ImageAnimator.UpdateFrames();
                        e.Graphics.DrawImage(drawImage, Rectangle.Truncate(imageRect));
                    }


                    //rect = new Rectangle(BEDNUMBER_WIDTH + TITLE_WIDTH/2, TITLE_HEIGHT, TITLE_WIDTH/2, BOTTOM_HEIGHT);
                    rect = new Rectangle(BEDNUMBER_WIDTH + BOTTOM_LEFT_WIDTH, TITLE_HEIGHT, BOTTOM_RIGHT_WIDTH, BOTTOM_HEIGHT);
                    //아래 우측영역은 (CP환자여부 환자여부) BottomRightStatus에 따라 fillBrush SET
                    fillBrush = bRStatus1Brush; //N 기본 연핑크
                    switch (this.bRStatus)
                    {
                        case BottomRightStatus.State2:
                            fillBrush = bRStatus2Brush;  //Y 연보라
                            break;
                    }
                    e.Graphics.FillRectangle(fillBrush, rect);
                    e.Graphics.DrawRectangle(rectPen, rect);

                    //상태에 대한 이미지 세팅

                    int flag_Xpos = rect.Left;

                    if (status_flag1)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.MiddleLeft, flag_Xpos, rect.Top, rect.Width, rect.Height, flag1Image.Width, flag1Image.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, BedBox.flag1Image.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        ImageAnimator.UpdateFrames();
                        e.Graphics.DrawImage(BedBox.flag1Image, Rectangle.Truncate(imageRect));
                    }

                    flag_Xpos += flag1Image.Width;

                    if (status_flag2)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.MiddleLeft, flag_Xpos, rect.Top, rect.Width, rect.Height, flag2Image.Width, flag2Image.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, BedBox.flag2Image.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        ImageAnimator.UpdateFrames();
                        e.Graphics.DrawImage(BedBox.flag2Image, Rectangle.Truncate(imageRect));
                    }
                    flag_Xpos += flag2Image.Width;
                    if (status_flag3)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.MiddleLeft, flag_Xpos, rect.Top, rect.Width, rect.Height, flag3Image.Width, flag3Image.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, BedBox.flag3Image.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        ImageAnimator.UpdateFrames();
                        e.Graphics.DrawImage(BedBox.flag3Image, Rectangle.Truncate(imageRect));
                    }
                    flag_Xpos += flag3Image.Width;
                    if (status_flag4)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.MiddleLeft, flag_Xpos, rect.Top, rect.Width, rect.Height, flag4Image.Width, flag4Image.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, BedBox.flag4Image.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        ImageAnimator.UpdateFrames();
                        e.Graphics.DrawImage(BedBox.flag4Image, Rectangle.Truncate(imageRect));
                    }
                    flag_Xpos += flag4Image.Width;
                    if (status_flag5)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.MiddleLeft, flag_Xpos, rect.Top, rect.Width, rect.Height, flag5Image.Width, flag5Image.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, BedBox.flag5Image.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        ImageAnimator.UpdateFrames();
                        e.Graphics.DrawImage(BedBox.flag5Image, Rectangle.Truncate(imageRect));
                    }

                    //LeftButtonClick상태이면 선택된 모양 보여주기(3Pixel -> 2Pixel)
                    if (this.selected)
                    {
                        rect = new Rectangle(1, 1, BEDNUMBER_WIDTH + TITLE_WIDTH - 2, TITLE_HEIGHT + BOTTOM_HEIGHT - 4);
                        e.Graphics.DrawRectangle(Pens.OrangeRed, rect);
                        rect = new Rectangle(2, 2, BEDNUMBER_WIDTH + TITLE_WIDTH - 4, TITLE_HEIGHT + BOTTOM_HEIGHT - 6);
                        e.Graphics.DrawRectangle(Pens.Red, rect);
                    }

                    //RightTop영역 Draw (담당간호팀)
                    //fillBrush = rTStatus1Brush;  //A팀 Red
                    //switch (this.rTStatus)
                    //{
                    //    case RightTopStatus.State2:  //B팀 Blue
                    //        fillBrush = rTStatus2Brush;
                    //        break;
                    //    case RightTopStatus.State3:  //C팀 Yellow
                    //        fillBrush = rTStatus3Brush;
                    //        break;
                    //    case RightTopStatus.State4:  //D팀 Green
                    //        fillBrush = rTStatus4Brush;
                    //        break;
                    //    case RightTopStatus.State5:  //E팀 Pink
                    //        fillBrush = rTStatus5Brush;
                    //        break;
                    //}


                    if (this.not_yet_drg_date == "")
                    {
                        fillBrush = rTStatus1Brush;  // 미 투약 없음
                    }
                    else
                    {
                        fillBrush = rTStatus2Brush;  // 미투약 있음
                    }
                 
                    //위 상태 영역 Draw
                    rect = new Rectangle(BEDNUMBER_WIDTH + TITLE_WIDTH + WIDTH_GAP, 0, STATUS_WIDTH, STATUS_HEIGHT);//kbh
                    e.Graphics.FillRectangle(fillBrush, rect);
                    e.Graphics.DrawRectangle(rectPen, rect);
                    //당일입원인경우 이미지 표시
                    drawImage = null;
                    if (this.isTodayIpwon)
                        drawImage = BedBox.ipwonImage;

                    if (drawImage != null)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter, rect.Left, rect.Top, rect.Width, rect.Height, drawImage.Width, drawImage.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        e.Graphics.DrawImage(drawImage, Rectangle.Truncate(imageRect));
                    }
                    //퇴원예약인 환자표시
                    drawImage = null;
                    if (this.toiwonResDate != "")
                        drawImage = BedBox.toiwonResImage;

                    if (drawImage != null)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter, rect.Left, rect.Top, rect.Width, rect.Height, drawImage.Width, drawImage.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        e.Graphics.DrawImage(drawImage, Rectangle.Truncate(imageRect));
                    }


                    //의사의 고유 색상(의사의 고유 색상이 없으면 과의 고유 색상으로 과의 고유 색상이 없으면 흰색으로.
                    if (this.Rgb.Length > 0)
                    {
                        if (this.Rgb.Split(',').Length == 3)
                            doctorBrush = new SolidBrush(Color.FromArgb(int.Parse(this.Rgb.Split(',')[0]), int.Parse(this.Rgb.Split(',')[1]), int.Parse(this.Rgb.Split(',')[2])));
                    }
                    fillBrush = doctorBrush;

                    //환자보험종별구분별 색상표시
                    //1.국민보험, 2.노인보험, 3.노재,4.자동차보험,5.일반, 그외 6.기타    하트라이프
                    //1.국민보험, 2.사보, 3.자동차보험, 5.노재, 그외 6.기타              오카다
                    //switch (this.rBStatus)
                    //{
                    //    case RightBottomStatus.General: //국민보험
                    //        fillBrush = rBStatus1Brush;
                    //        break;
                    //    case RightBottomStatus.Special: //사보
                    //        fillBrush = rBStatus2Brush;
                    //        break;
                    //    case RightBottomStatus.Other: //자동차보험
                    //        fillBrush = rBStatus3Brush;
                    //        break;
                    //    case RightBottomStatus.State4: //없음
                    //        fillBrush = rBStatus4Brush;
                    //        break;
                    //    case RightBottomStatus.State5: // 노재
                    //        fillBrush = rBStatus5Brush;
                    //        break;
                    //    case RightBottomStatus.State6:
                    //        fillBrush = rBStatus6Brush;
                    //        break;
                    //}

                    rect = new Rectangle(BEDNUMBER_WIDTH + TITLE_WIDTH + WIDTH_GAP, STATUS_HEIGHT + STATUS_GAP, STATUS_WIDTH, STATUS_HEIGHT);
                    e.Graphics.FillRectangle(fillBrush, rect);
                    e.Graphics.DrawRectangle(rectPen, rect);

                    //예약여부
                    drawImage = null;
                    if (this.isIpwonReser)
                        drawImage = BedBox.ipwonReserImage;

                    if (drawImage != null)
                    {
                        PointF pointImage = DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter, rect.Left, rect.Top, rect.Width, rect.Height, drawImage.Width, drawImage.Height);
                        RectangleF imageRect = rect;
                        imageRect.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
                        //Truncate the Rectangle for appreximation problem
                        e.Graphics.DrawImage(drawImage, Rectangle.Truncate(imageRect));
                    }

                }
            }
            catch (Exception xe)
            {
                Debug.WriteLine("BedBox::OnPaint, Error=" + xe.Message);
            }
		}
		#endregion

		#region Dispose
		/// <summary>
		/// 컨트롤에서 사용하는 리소스를 모두 해제합니다.
		/// </summary>
		/// <param name="disposing"> Dispose 여부 </param>
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

		#region DisposePenBrushes (그리기에서 사용한 Brush Dispose)
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
                rTStatus4Brush.Dispose();
                rTStatus5Brush.Dispose();
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

	#region Enum(병상상태를 나타내는 Enum)
	internal enum BedStatus  //병상상태
	{
		State1,  //공석
		State2,  //이동가능환자(BR_CODE 01) - 흰색
		State3,  //도움을 받아 이동할 환자(BR_CODE BR) - 황색
		State4   //이동불가환자(BR_CODE ABR) - 적색
	}
	internal enum BottomLeftStatus  //아래 좌측 상태
	{
		State1, // 오더가 있는 환자
		State2, // 당일 간호 확인이 필요한 환자
        State3  // 추후 간호 확인이 필요한 환자
	}
	internal enum BottomRightStatus //아래 우측상태
	{
		State1, //CP환자 Y
		State2  //CP환자 N
	}
	internal enum RightTopStatus // 우측상단 상태(담당간호사 팀)
	{
		State1,  //A팀
		State2,  //B팀
		State3,  //C팀
        State4,  //D팀
        State5,  //E팀
	}
	internal enum RightBottomStatus  //우측하단 상태(환자유형 -미정)
	{
		State1, //국민보험
		State2, //의료급여
		State3, //산업재해
		State4, //자동차보험
		State5, //일반
		State6  //기타
	}
	internal enum HumanSex
	{
		Man,  //남성
		Woman //여성
	}
	#endregion
}

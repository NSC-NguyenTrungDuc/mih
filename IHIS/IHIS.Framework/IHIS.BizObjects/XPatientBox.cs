using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework.Properties;

namespace IHIS.Framework
{
	/// <summary>
	/// XPatientBox에 대한 요약 설명입니다.
	/// </summary>
	[DefaultEvent("PatientSelected")]
	[DefaultProperty("BoxType")]
	[ToolboxBitmap(typeof(IHIS.Framework.XPatientBox), "Images.XPatientBox.bmp")]
	public class XPatientBox : System.Windows.Forms.UserControl, ISupportInitialize, IHIS.Framework.IUserObject
	{
		#region Fields
		private ILayoutContainer layoutContainer = null;
		private Patient paInfo = new Patient();
		private PatientBoxType boxType = PatientBoxType.NormalSimple;
		private XColor xBackColor = XColor.XScreenBackColor;
		private bool isEditableBunho = true;  //환자번호를 편집가능한지 여부
		private bool showBoxImage = true;  //상세정보 Image를 보여줄지 여부를 지정합니다.
		private bool applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		private bool showInHospitalImage = false; //환자번호 입력시에 입원중이미지를 보여줄지 여부(2007/01/17추가)
		private Image inHospitalImage = null; //입원중 이미지 Icon
        private string hospCode = "";
		#endregion

		#region Base Property
		[DefaultValue(typeof(XColor),"XScreenBackColor"),
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
		//기본값 변경
		[DefaultValue(AnchorStyles.Top|AnchorStyles.Left)]
		public override AnchorStyles Anchor
		{
			get	{ return base.Anchor;}
			set	{ base.Anchor = value;}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		#endregion

		#region Properties
		[Browsable(true), Category("추가속성"),
		DefaultValue(PatientBoxType.NormalSimple),
		MergableProperty(true),
		Description("환자번호 Box의 기본 기능 Type을 지정합니다.")]
		public PatientBoxType BoxType
		{
			get { return boxType;}
			set 
			{
				if (boxType != value)
				{
					boxType = value;
					if (this.DesignMode)
						this.InitialzePatientBox();
				}
			}
		}
		[Browsable(true), Category("추가속성"),
		DefaultValue(true),
		MergableProperty(true),
		Description("환자번호를 편집가능한지 여부를 지정합니다.")]
		public bool IsEditableBunho
		{
			get { return isEditableBunho;}
			set 
			{
				if (isEditableBunho != value)
				{
					isEditableBunho = value;
					//편집가능이면 txtBunho, 버튼 Enable 아니면 반대
					this.txtBunHo.Enabled = value;
					this.btnFind.Enabled = value;
				}
			}
		}
		[Browsable(true), Category("추가속성"),
		DefaultValue(true),
		MergableProperty(true),
		Description("맨오른쪽의 상세정보조회 Image를 보여줄지 여부를 지정합니다.")]
		public bool ShowBoxImage
		{
			get { return showBoxImage;}
			set 
			{
				if (showBoxImage != value)
				{
					showBoxImage = value;
					//pnlRight의 Size를 변경처리함 (보이면 20, 아니면 0)
					if (value)
						pnlRight.Size = new Size(20, pnlRight.Height);
					else
						pnlRight.Size = new Size(0, pnlRight.Height);
				}
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
		[Browsable(true), Category("추가속성"),
		DefaultValue(false),
		MergableProperty(true),
		Description("환자번호 입력시에 입원중인 환자일 경우 입원Image를 보여줄지 여부를 지정합니다.")]
		public bool ShowInHospitalImage
		{
			get { return showInHospitalImage;}
			set 
			{
				if (showInHospitalImage != value)
				{
					showInHospitalImage = value;
					ChangeBunhoLabelFormat(); //환자번호 Label 모양 변경
				}
			}
		}
		//환자번호
		[Browsable(false), DataBindable]
		public string BunHo
		{
			get { return paInfo.BunHo;}
		}
		[Browsable(false)]
		public string SuName
		{
			get { return paInfo.SuName; }
		}
		[Browsable(false)]
		public string SuName2
		{
			get { return paInfo.SuName2; }
		}

		// 성별
		[Browsable(false)]
		public string Sex
		{
			get { return paInfo.Sex; }
		}

		// 나이(년 단위)
		[Browsable(false)]
		public int YearAge
		{
			get 
			{
				if (TypeCheck.IsInt(paInfo.YearAge))
					return Int32.Parse(paInfo.YearAge);
				else
					return 0;
			}
		}
		// 나이(월 단위)
		[Browsable(false)]
		public int MonthAge
		{
			get 
			{
				if (TypeCheck.IsInt(paInfo.MonthAge))
					return Int32.Parse(paInfo.MonthAge);
				else
					return 0;
			}
		}
		// 보험구분
		[Browsable(false)]
		public string Gubun
		{
			get { return paInfo.Gubun; }
		}

		// 보험구분명
		[Browsable(false)]
		public string GubunName
		{
			get { return paInfo.GubunName; }
		}
		// 생일
		[Browsable(false)]
		public string Birth
		{
			get { return paInfo.Birth; }
		}

		// 전화번호
		[Browsable(false)]
		public string Tel
		{
			get 
			{ 
				return (paInfo.Tel != "" ? paInfo.Tel : paInfo.Tel1);
			}
		}
		//핸드폰 번호
		[Browsable(false)]
		public string TelHP
		{
			get { return paInfo.TelHP;}
		}

		// 우편번호1
		[Browsable(false)]
		public string Zip1
		{
			get { return paInfo.Zip1; }
		}

		// 우편번호2
		[Browsable(false)]
		public string Zip2
		{
			get { return paInfo.Zip2; }
		}

		// 주소1
		[Browsable(false)]
		public string Address1
		{
			get { return paInfo.Address1; }
		}

		// 주소2
		[Browsable(false)]
		public string Address2
		{
			get { return paInfo.Address2; }
		}
		//입원중여부 (2007/01/17 추가)
		[Browsable(false)]
		public bool InHospital
		{
			get { return paInfo.InHospital; }
		}

        [Browsable(false)]
        public string Email
        {
            get { return paInfo.Email; }
        }
		#endregion

		#region Event
		/// <summary>
		/// 환자번호가 입력되었을때 발생하는 Event 입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("환자번호가 입력(선택)되었을때 발생합니다.")]
		public event EventHandler PatientSelected;
		/// <summary>
		/// 환자번호를 잘못 입력하였을때 발생하는 Event입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("환자번호를 잘못 입력하였을때 발생합니다.")]
		public event EventHandler PatientSelectionFailed;
		#endregion

		private System.Windows.Forms.Label lbPaInfo;
		private System.Windows.Forms.Label lbPaid;
		private System.Windows.Forms.Panel pnlLeft;
		private IHIS.Framework.XTextBox txtBunHo;
		private IHIS.Framework.XButton btnFind;
		private System.Windows.Forms.PictureBox pbxBallStop;
		private System.Windows.Forms.PictureBox pbxBallMove;
		private System.Windows.Forms.Panel pnlRight;
		private System.Windows.Forms.ToolTip toolTip;
		private IHIS.Framework.SingleLayout layPaInfo;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem1;
        private IHIS.Framework.SingleLayoutItem singleLayoutItem2;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem5;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem6;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem7;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem8;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem9;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem10;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem11;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem12;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem13;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem14;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem15;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem16;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem17;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem18;
		private IHIS.Framework.SingleLayoutItem singleLayoutItem19;
		private System.ComponentModel.IContainer components;

		#region 생성자
		public XPatientBox()
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();

			this.Size = new Size(800,32);
			this.BackColor = XColor.XScreenBackColor;
			// this.Font = new Font("MS UI Gothic", 9.75f);

            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                this.Font = new Font("MS UI Gothic", 9.75f);
            }
            else
            {
                this.Font = Service.COMMON_FONT;
            }

			//Ancher는 BottomRight
			this.Anchor = AnchorStyles.Top|AnchorStyles.Left;
			this.lbPaid.Text = Resource.lbPaidNameVN;
			//ToolTip Text Set
            //Fix bug MED-10280
            //this.toolTip.SetToolTip(this.pbxBallMove, (NetInfo.Language == LangMode.Ko ? "클릭시에 상세정보를 보여줍니다."
            //    : "クリックすると細部情報が見えます。"));
            //this.toolTip.SetToolTip(this.btnFind, (NetInfo.Language == LangMode.Ko ? "클릭시에 환자검색창을 보여줍니다."
            //    :"クリックすると患者検索画面が見えます。"));
            this.toolTip.SetToolTip(this.pbxBallMove, (NetInfo.Language == LangMode.Ko ? "클릭시에 상세정보를 보여줍니다." : Resource.pbxBallMove_ToolTip));
            this.toolTip.SetToolTip(this.btnFind, (NetInfo.Language == LangMode.Ko ? "클릭시에 상세정보를 보여줍니다." : Resource.btnFind_ToolTip));            
			//입원중 이미지 GET
			System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
			this.inHospitalImage = Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.Framework.Images.InHospital.gif"));

			//2007/01/30 환자번호길이에 따라 txtBunho의 MaxLength 변경처리
			this.txtBunHo.MaxLength = EnvironInfo.BunhoLength;

		    this.layPaInfo.ExecuteQuery = GetPatienInfo;
		  

		}
		#endregion

		#region Dispose
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
		#endregion

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XPatientBox));
            this.pbxBallStop = new System.Windows.Forms.PictureBox();
            this.pbxBallMove = new System.Windows.Forms.PictureBox();
            this.lbPaInfo = new System.Windows.Forms.Label();
            this.lbPaid = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.txtBunHo = new IHIS.Framework.XTextBox();
            this.btnFind = new IHIS.Framework.XButton();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.layPaInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem10 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem11 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem12 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem13 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem14 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem15 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem16 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem17 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem18 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem19 = new IHIS.Framework.SingleLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBallStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBallMove)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxBallStop
            // 
            this.pbxBallStop.AccessibleDescription = null;
            this.pbxBallStop.AccessibleName = null;
            resources.ApplyResources(this.pbxBallStop, "pbxBallStop");
            this.pbxBallStop.BackgroundImage = null;
            this.pbxBallStop.Font = null;
            this.pbxBallStop.ImageLocation = null;
            this.pbxBallStop.Name = "pbxBallStop";
            this.pbxBallStop.TabStop = false;
            this.toolTip.SetToolTip(this.pbxBallStop, resources.GetString("pbxBallStop.ToolTip"));
            // 
            // pbxBallMove
            // 
            this.pbxBallMove.AccessibleDescription = null;
            this.pbxBallMove.AccessibleName = null;
            resources.ApplyResources(this.pbxBallMove, "pbxBallMove");
            this.pbxBallMove.BackgroundImage = null;
            this.pbxBallMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxBallMove.Font = null;
            this.pbxBallMove.ImageLocation = null;
            this.pbxBallMove.Name = "pbxBallMove";
            this.pbxBallMove.TabStop = false;
            this.toolTip.SetToolTip(this.pbxBallMove, resources.GetString("pbxBallMove.ToolTip"));
            this.pbxBallMove.Click += new System.EventHandler(this.pbxBallMove_Click);
            // 
            // lbPaInfo
            // 
            this.lbPaInfo.AccessibleDescription = null;
            this.lbPaInfo.AccessibleName = null;
            resources.ApplyResources(this.lbPaInfo, "lbPaInfo");
            this.lbPaInfo.Font = null;
            this.lbPaInfo.Name = "lbPaInfo";
            this.toolTip.SetToolTip(this.lbPaInfo, resources.GetString("lbPaInfo.ToolTip"));
            // 
            // lbPaid
            // 
            this.lbPaid.AccessibleDescription = null;
            this.lbPaid.AccessibleName = null;
            resources.ApplyResources(this.lbPaid, "lbPaid");
            this.lbPaid.Font = null;
            this.lbPaid.Name = "lbPaid";
            this.toolTip.SetToolTip(this.lbPaid, resources.GetString("lbPaid.ToolTip"));
            // 
            // pnlLeft
            // 
            this.pnlLeft.AccessibleDescription = null;
            this.pnlLeft.AccessibleName = null;
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.BackgroundImage = null;
            this.pnlLeft.Controls.Add(this.txtBunHo);
            this.pnlLeft.Controls.Add(this.btnFind);
            this.pnlLeft.Controls.Add(this.lbPaid);
            this.pnlLeft.Font = null;
            this.pnlLeft.Name = "pnlLeft";
            this.toolTip.SetToolTip(this.pnlLeft, resources.GetString("pnlLeft.ToolTip"));
            // 
            // txtBunHo
            // 
            this.txtBunHo.AccessibleDescription = null;
            this.txtBunHo.AccessibleName = null;
            resources.ApplyResources(this.txtBunHo, "txtBunHo");
            this.txtBunHo.BackgroundImage = null;
            this.txtBunHo.Font = null;
            this.txtBunHo.Name = "txtBunHo";
            this.toolTip.SetToolTip(this.txtBunHo, resources.GetString("txtBunHo.ToolTip"));
            this.txtBunHo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBunHo_KeyDown);
            this.txtBunHo.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtBunHo_DataValidating);
            // 
            // btnFind
            // 
            this.btnFind.AccessibleDescription = null;
            this.btnFind.AccessibleName = null;
            resources.ApplyResources(this.btnFind, "btnFind");
            this.btnFind.BackgroundImage = null;
            this.btnFind.Font = null;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Name = "btnFind";
            this.btnFind.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnFind.TabStop = false;
            this.toolTip.SetToolTip(this.btnFind, resources.GetString("btnFind.ToolTip"));
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.AccessibleDescription = null;
            this.pnlRight.AccessibleName = null;
            resources.ApplyResources(this.pnlRight, "pnlRight");
            this.pnlRight.BackgroundImage = null;
            this.pnlRight.Controls.Add(this.pbxBallStop);
            this.pnlRight.Controls.Add(this.pbxBallMove);
            this.pnlRight.Font = null;
            this.pnlRight.Name = "pnlRight";
            this.toolTip.SetToolTip(this.pnlRight, resources.GetString("pnlRight.ToolTip"));
            // 
            // layPaInfo
            // 
            this.layPaInfo.ExecuteQuery = null;
            this.layPaInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem5,
            this.singleLayoutItem6,
            this.singleLayoutItem7,
            this.singleLayoutItem8,
            this.singleLayoutItem9,
            this.singleLayoutItem10,
            this.singleLayoutItem11,
            this.singleLayoutItem12,
            this.singleLayoutItem13,
            this.singleLayoutItem14,
            this.singleLayoutItem15,
            this.singleLayoutItem16,
            this.singleLayoutItem17,
            this.singleLayoutItem18,
            this.singleLayoutItem19});
            this.layPaInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPaInfo.ParamList")));
            this.layPaInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPaInfo_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "SuName";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "SuName2";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "Sex";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "YearAge";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.DataName = "MonthAge";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.DataName = "Gubun";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "GubunName";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.DataName = "Birth";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.DataName = "Tel";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.DataName = "Tel1";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.DataName = "TelHP";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.DataName = "Email";
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.DataName = "Zip1";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.DataName = "Zip2";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.DataName = "Address1";
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.DataName = "Address2";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.DataName = "InHospital";
            // 
            // XPatientBox
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.lbPaInfo);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "XPatientBox";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.pbxBallStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBallMove)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region ISupportInitialize Implemetation
		//ISupportInitialize를 사용하면 속성에 대한 여러 설정에 컨트롤을 최적화할 수 있습니다. 
		//따라서 디자인 타임에서 상호 종속적인 속성을 초기화하거나 여러 속성을 일괄 설정할 수 있습니다.
		//초기화가 시작됨을 개체에 알리기 위해 BeginInit 메서드를 호출합니다. 
		//초기화가 완료됨을 개체에 알리기 위해 EndInit 메서드를 호출합니다

		/// <summary>
		/// 초기화가 시작됨을 개체에 알립니다.
		/// </summary>
		void ISupportInitialize.BeginInit()
		{
		}
		/// <summary>
		/// 초기화 종료시 환자번호 BOX 초기화(InitialzePatientBox)합니다.
		/// </summary>
		void ISupportInitialize.EndInit()
		{
			InitialzePatientBox();
			if (!this.DesignMode)  //RunTime시에 ILayoutContainer SET
			{
				//ILayoutContainer SET
				SetLayoutContainer();
			}
		}
		#endregion

		#region IUserObject Implementation
		//UserObject의 Control은 Binding 허용하지 않음
		bool IUserObject.AllowBindControls
		{
			get { return false;}
		}
		//지정한 Property는 Binding 허용함
		bool IUserObject.AllowBindVariables
		{
			get { return true;}
		}
		public void Reset()
		{
			//컨트롤, 환자정보 Clear
			this.txtBunHo.Text = "";
			this.lbPaInfo.Text = "";
			this.pbxBallStop.Visible = true;
			this.pbxBallMove.Visible = false;
			this.paInfo.Reset();
		}
		#endregion

		#region InitialzePatientBox (환자번호 Box 초기화)
		public void InitialzePatientBox()
		{
			//추후 업무확정후 추가
		}
		#endregion

		#region ParentIsILayoutContainer, SetLayoutContainer
		/// <summary>
		/// Parent Control이 ILayoutContainer인지 여부를 반환합니다.
		/// </summary>
		/// <param name="parent"> Parent Control </param>
		/// <param name="parentControl"> (out) Parent Control 개체 </param>
		/// <returns> ILayoutContainer이면 true, 아니면 false </returns>
		protected bool ParentIsILayoutContainer(Control parent, out Control parentControl)
		{
			parentControl = null;
			if(parent is ILayoutContainer)
			{
				parentControl = parent;
				return true;
			}
			else
			{
				if(parent.Parent != null)
					return ParentIsILayoutContainer(parent.Parent, out parentControl);
				else
					return false;
			}
		}
		/// <summary>
		/// 환자번호 Box가 있는 화면,Form이 ILayoutContainer인지 SET 
		/// InitializeComponent에서 모든 Control이 설정되고 난후 반영되도록 EndInit에 추가함.
		/// </summary>
		private void SetLayoutContainer()
		{
			if (this.layoutContainer == null)
			{
				Control parentControl = null;
				if (this.Parent != null)
				{
					// DataLayout Container의 Current DataLayout 초기화
					if(ParentIsILayoutContainer(this.Parent, out parentControl))
					{
						this.layoutContainer = (ILayoutContainer) parentControl;
					}
				}
			}	
		}
		#endregion

		#region SetMsg
		private void SetMsg(string msg, MsgType msgType)
		{
			//Screen위에 있으면 Screen으로 Msg를 보내고 ,없으면 MsgBox
			if (this.layoutContainer != null)
				this.layoutContainer.SetMsg(msg, msgType);
			else if (msg != "")
				XMessageBox.Show(msg, "PatientBox");
		}
		#endregion

		#region Event Handler
		private void txtBunHo_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			//Msg Clear
			SetMsg("", MsgType.Normal);

//			if (this.txtBunHo.Text.Trim() == "") return;

			//입력환자번호 표준환자번호로 SET (환자번호가 입력되어 있을 경우에만)
			if (this.txtBunHo.Text.Trim() != "")
				this.txtBunHo.SetEditValue(BizCodeHelper.GetStandardBunHo(this.txtBunHo.Text));
			//환자정보 조회
			bool ret = QueryPatientInfo();
			e.Cancel = !ret; //실패시는 Cancel
			if (ret)  //성공시 DataChanged Clear
				this.txtBunHo.DataChanged = false;
		}
		private void txtBunHo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//번호에서 F4 Key를 환자선택창 Popup
			if (e.KeyCode == Keys.F4)
				btnFind.PerformClick();
		}
		#endregion

		#region Methods
		private bool QueryPatientInfo()  //환자번호로 환자정보 조회
		{
			this.paInfo.Reset();
			this.lbPaInfo.Text = "";
			this.pbxBallMove.Visible = false;
			this.pbxBallStop.Visible = true;
			SetMsg("", MsgType.Normal);
			//환자번호 Label, 입원중이미지 Reset
			ChangeBunhoLabelFormat();

			string msg = "";
			//환자번호 입력여부 확인
			if (this.txtBunHo.Text.Trim() == "")
			{
//				 msg = (NetInfo.Language == LangMode.Ko ? "환자번호를 입력하십시오"
//					: "患者番号を入力してください。");
//				SetMsg(msg, MsgType.Error);
				//환자번호 조회실패 Event Call
				OnPatientSelectionFailed(EventArgs.Empty);
				this.txtBunHo.Focus();
				return true;
			}
			if (!this.layPaInfo.QueryLayout()) //환자정보 조회 실패시 Msg Set
			{
				msg = (NetInfo.Language == LangMode.Ko ? "환자번호를 잘못 입력하셨습니다."
                    : Resource.Msg_00001);
				SetMsg(msg, MsgType.Error);
				//환자번호 조회실패 Event Call
				OnPatientSelectionFailed(EventArgs.Empty);
				this.txtBunHo.Focus();
				this.txtBunHo.SelectAll();
				return false;
			}
			//성공시에 환자정보 설정
			paInfo.BunHo		= this.txtBunHo.Text.Trim();
			paInfo.SuName		= layPaInfo.GetItemValue("SuName").ToString();
			paInfo.SuName2		= layPaInfo.GetItemValue("SuName2").ToString();
			paInfo.Sex			= layPaInfo.GetItemValue("Sex").ToString();
			paInfo.YearAge		= layPaInfo.GetItemValue("YearAge").ToString();
			paInfo.MonthAge		= layPaInfo.GetItemValue("MonthAge").ToString();
			paInfo.Gubun		= layPaInfo.GetItemValue("Gubun").ToString();
			paInfo.GubunName	= layPaInfo.GetItemValue("GubunName").ToString();
			paInfo.Birth		= layPaInfo.GetItemValue("Birth").ToString();
			paInfo.Tel			= layPaInfo.GetItemValue("Tel").ToString();
			paInfo.Tel1			= layPaInfo.GetItemValue("Tel1").ToString();
			paInfo.TelHP		= layPaInfo.GetItemValue("TelHP").ToString();
			paInfo.Email		= layPaInfo.GetItemValue("Email").ToString();
			paInfo.Zip1			= layPaInfo.GetItemValue("Zip1").ToString();
			paInfo.Zip2			= layPaInfo.GetItemValue("Zip2").ToString();
			paInfo.Address1		= layPaInfo.GetItemValue("Address1").ToString();
			paInfo.Address2		= layPaInfo.GetItemValue("Address2").ToString();
			paInfo.InHospital   = ( layPaInfo.GetItemValue("InHospital").ToString() == "Y" ? true : false); //입원중여부

			//PatientBoxType에 따라 lbPaInfo의 Text 설정 (업무확정후 추후 추가)
			switch (this.boxType)
			{
				case PatientBoxType.NormalSimple:
					//환자명 한자, 환자명 가나 , 성별/나이
					this.lbPaInfo.Text = "   " + paInfo.SuName + "   " + paInfo.SuName2 + "   " + GetSex(paInfo.Sex) + " / " + GetAge(paInfo.YearAge);
					break;
				case PatientBoxType.NormalMiddle:
					//환자명한자, 환자명 가나, 성별/나이 생년월일(와력으로), 전화번호
					this.lbPaInfo.Text = "   " + paInfo.SuName + "   " + paInfo.SuName2 + "   " + GetSex(paInfo.Sex) + " / " + GetAge(paInfo.YearAge) +
										 "   " + GetBirth(paInfo.Birth) + "   TEL : " + this.Tel;
					break;
				case PatientBoxType.NormalDetail:
					//환자명 한자, 환자명 가나, 성별/나이, 생년월일(와력으로) , 주소
					this.lbPaInfo.Text = "   " + paInfo.SuName + "   " + paInfo.SuName2 + "   " + GetSex(paInfo.Sex) + " / " + GetAge(paInfo.YearAge) + 
										 "   " + GetBirth(paInfo.Birth) + "    " + paInfo.Address1.Trim() + " " + paInfo.Address2.Trim();
					break;
				default:
					break;
			}

            toolTip.SetToolTip(this.lbPaInfo, lbPaInfo.Text);
			//환자번호 입력됨 이미지 SET
			this.pbxBallStop.Visible = false;
			this.pbxBallMove.Visible = true;

			//환자번호 Label, 입원중이미지 Set
			ChangeBunhoLabelFormat();
			
			//환자번호 선택 Event Call
			OnPatientSelected(EventArgs.Empty);

			return true;
		}
		internal static string GetSex(string sexCode)  //M/W
		{
			//M -> 남　（男）, W->여（女）
		    if (sexCode == "M")
				return (NetInfo.Language == LangMode.Ko ? "남" : Resource.XPatientBox_TEXT1);
			else
				return (NetInfo.Language == LangMode.Ko ? "여" : Resource.XPatientBox_TEXT2);
		}
		internal static string GetAge(string age)
		{
			//19 -> 19세（才）, 
			return (NetInfo.Language == LangMode.Ko ? age + "세" : age + Resource.XPatientBox_TEXT3);
		}
		internal static string GetBirth(string birth)
		{
			//yyyy/MM/dd형으로 일본이면 일본연호를 사용하여 생년월일 Return
			try
			{
				DateTime day = DateTime.Parse(birth);
                if (NetInfo.Language == LangMode.Ko)
                {
                    return day.Year.ToString() + "년 " + day.Month.ToString() + "월 " + day.Day.ToString() + "일생";
                }
                else if (NetInfo.Language == LangMode.Jr)
                {
                    string period = "";
                    int year = 0;
                    JapanYearHelper.ConvertToJapanYear(day, out period, out year);
                    return period + " " + year.ToString() + "年 " + day.Month.ToString() + "月 " + day.Day.ToString() + "日生";

                    // Localize VN
                    //return Resource.XPatientBox_TEXT4 + ": " + day.ToString("d", CultureInfo.CreateSpecificCulture("vi-VN"));
                    //return Resource.XPatientBox_TEXT4 + ": " + day.ToString("d", CultureInfo.CreateSpecificCulture("ja-JP"));
                }
                else // Vi
                {
                    return "Ngày " + day.Day.ToString() + " Tháng " + day.Month.ToString() + " Năm " + day.Year.ToString();
                }
			}
			catch
			{
				return birth;
			}
		}
		#endregion

		#region Event Invoker
		protected virtual void OnPatientSelected(EventArgs e)
		{
			if (this.PatientSelected != null)
				PatientSelected(this, e);
		}
		protected virtual void OnPatientSelectionFailed(EventArgs e)
		{
			if (this.PatientSelectionFailed != null)
				PatientSelectionFailed(this, e);
		}
		#endregion

		#region 환자번호 설정 Method
		public void SetPatientID(string bunHo)
		{
			//환자번호 설정후 DataValidating Call
			this.txtBunHo.Text = bunHo;
			//환자정보 조회
			txtBunHo_DataValidating(this.txtBunHo, new DataValidatingEventArgs(false, this.txtBunHo.GetDataValue()));
		}

        public void SetPatientID(string bunHo, string hospCode)
        {
            //환자번호 설정후 DataValidating Call
            this.txtBunHo.Text = bunHo;
            this.hospCode = hospCode;
            //환자정보 조회
            txtBunHo_DataValidating(this.txtBunHo, new DataValidatingEventArgs(false, this.txtBunHo.GetDataValue()));
        }
		#endregion

		#region 환자번호 검색 버튼 Click
		private void btnFind_Click(object sender, System.EventArgs e)
		{
			FindPatientForm dlg = new FindPatientForm(this.btnFind);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				this.txtBunHo.SetDataValue(dlg.BunHo);
				//환자정보 조회
				QueryPatientInfo();
			}
		}
		#endregion

		#region 환자번호 MoveBall Click시에 환자상세정보 조회)
		private void pbxBallMove_Click(object sender, System.EventArgs e)
		{
			//상세정보 완료전까지 일단 Comment 처리
			DetailPaInfoForm dlg = new DetailPaInfoForm(this.paInfo, this.pbxBallMove);
			dlg.ShowDialog(EnvironInfo.MdiForm);
			dlg.Dispose();
		}
		#endregion

		#region ChangeBunhoLabelFormat(환자상태에 따른 환자번호 Label 모양 변경, 입원중 Icon 표시 변경)
		private void ChangeBunhoLabelFormat()
		{
			//입원중 Show이고, 환자번호 입력, 재원중환자이면 입원중이미지 Show
			if (this.showInHospitalImage && (this.BunHo != "") && this.InHospital)
			{
				//이미지 Left, 환자번호 글씨는 Right로
				this.lbPaid.Image = this.inHospitalImage;
				this.lbPaid.TextAlign = ContentAlignment.MiddleRight; 
			}
			else
			{
				//이미지 null, 환자번호 글씨는 Center
				this.lbPaid.Image = null;
				this.lbPaid.TextAlign = ContentAlignment.MiddleCenter; 
			}
		}
		#endregion

		private void layPaInfo_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
            // Create paramlist
            List<string> parmLists = new List<string>();
            parmLists.Add("f_bunho");
		    layPaInfo.ParamList = parmLists;
			//f_bunho BIND 변수 SET
			layPaInfo.SetBindVarValue("f_bunho", this.txtBunHo.GetDataValue());
		}

	    private IList<object[]> GetPatienInfo(BindVarCollection bindVarCollection)
	    {
            IList<object[]> listResult = new List<object[]>();
	        try
	        {
                GetPatientByCodeArgs getPatientByCodeArgs = new GetPatientByCodeArgs(bindVarCollection["f_bunho"].VarValue, hospCode);
                GetPatientByCodeResult patientByCodeResult =
                    CloudService.Instance.Submit<GetPatientByCodeResult, GetPatientByCodeArgs>(getPatientByCodeArgs);
                if (patientByCodeResult != null)
                {
                    IList<PatientInfo> lsPatientInfos = patientByCodeResult.LstPatientInfos;
                    if (lsPatientInfos != null)
                    {
                        foreach (PatientInfo patientInfo in lsPatientInfos)
                        {
                            object[] _patientInfo =
                            {
                                patientInfo.PatientName1,
                                patientInfo.PatientName2,
                                patientInfo.Sex,
                                patientInfo.YearAge,
                                patientInfo.MonthAge,
                                patientInfo.Type,
                                patientInfo.CodeNm,
                                patientInfo.Birth,
                                patientInfo.Tel,
                                patientInfo.Tel1,
                                patientInfo.TelHp,
                                patientInfo.Email,
                                patientInfo.ZipCode1,
                                patientInfo.ZipCode2,
                                patientInfo.Address1,
                                patientInfo.Address2,
                                patientInfo.TelGubun1,
                                patientInfo.TelGubun2,
                                patientInfo.TelGubun3,
                                patientInfo.Pwd
                            };
                            listResult.Add(_patientInfo);
                        }
                    }
                }
	            return listResult;
	        }
            catch (Exception e)
            {
                Console.WriteLine("Exception", e.Message);
            }
	        return listResult;
	    }
	}

	#region PatientBoxType Enum
	/// <summary>
	/// 기능의 성격을 관리하는 Enum
	/// </summary>
	public enum PatientBoxType
	{
		/// <summary>
		/// 일반형 Simple (환자번호입력, Find버튼, 환자명 한자, 환자명 가나 , 성별/나이
		/// </summary>
		NormalSimple,
		/// <summary>
		/// 일반형 중간형(환자번호입력, Find버튼, 환자명한자, 환자명 가나, 성별/나이 생년월일(와력으로), 전화번호
		/// </summary>
		NormalMiddle,
		/// <summary>
		/// 일반형 상세 (환자번호입력, Find버튼, 환자명 한자, 환자명 가나, 성별/나이, 생년월일(와력으로) , 주소
		/// </summary>
		NormalDetail
	}
	#endregion

	#region Patient (환자정보 관리 Class)

    internal class Patient
	{
		#region Fields
		string bunHo = "";		//환자번호
		string suName = "";		//환자명(한자명)
		string suName2 ="";     //가나명
		string sex = "";		//성별(M/W)
		string yearAge = "";		//나이(년)
		string monthAge = "";		//나이(개월수)
		string gubun = "";		//환자유형
		string gubunName = "";	//환자유형명
		string birth = "";		//생년월일
		string tel = "";		//전화번호
		string tel1 = "";		//전화번호1
		string telHP = "";		//핸드폰번호
		string email = "";		//E-mail
		string zip1 = "";		//우편번호1
		string zip2 = "";		//우편번호2
		string address1 = "";	//주소1(대주소)
		string address2 = "";	//주소2(상세주소)
		bool   inHospital = false; //입원중여부 (2007/01/17추가)
		#endregion

		#region Properties
		public string BunHo
		{
			get { return bunHo;}
			set { bunHo = value;}
		}
		public string SuName
		{
			get { return suName; }
			set { suName = value; }
		}
		public string SuName2
		{
			get { return suName2; }
			set { suName2 = value; }
		}

		public string Sex
		{
			get { return sex; }
			set { sex = value; }
		}

		public string YearAge
		{
			get { return yearAge; }
			set { yearAge = value; }
		}

		public string MonthAge
		{
			get { return monthAge; }
			set { monthAge = value; }
		}

		public string Gubun
		{
			get { return gubun; }
			set { gubun = value; }
		}

		public string GubunName
		{
			get { return gubunName; }
			set { gubunName = value; }
		}
		public string Birth
		{
			get { return birth; }
			set { birth = value; }
		}

		public string Tel
		{
			get { return tel; }
			set { tel = value; }
		}
		public string Tel1
		{
			get { return tel1; }
			set { tel1 = value; }
		}
		public string TelHP
		{
			get { return telHP; }
			set { telHP = value; }
		}
		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		public string Zip1
		{
			get { return zip1; }
			set { zip1 = value; }
		}

		public string Zip2
		{
			get { return zip2; }
			set { zip2 = value; }
		}

		public string Address1
		{
			get { return address1; }
			set { address1 = value; }
		}

		public string Address2
		{
			get { return address2; }
			set { address2 = value; }
		}
		public bool InHospital
		{
			get { return inHospital;}
			set { inHospital = value;}
		}
		#endregion

		#region 생성자
		public Patient()
		{
		}
		#endregion

		#region Reset
		public void Reset()
		{
			bunHo = "";		//환자번호
			suName = "";	//환자명
			suName2 = "";	//환자명
			sex = "";		//성별(M/W)
			yearAge = "";		//나이
			monthAge = "";		//나이
			gubun = "";		//환자유형
			gubunName = "";	//환자유형명
			birth = "";		//생년월일
			tel = "";		//전화번호
			tel1 = "";		//전화번호1
			telHP = "";		//HP전화번호
			email = "";		//E-mail
			zip1 = "";		//우편번호1
			zip2 = "";		//우편번호2
			address1 = "";	//주소1(대주소)
			address2 = "";	//주소2(상세주소)
			inHospital = false;
		}
		#endregion
	}
	#endregion
}

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Utility;

namespace IHIS.Framework
{
	/// <summary>
	/// XPaComment에 대한 요약 설명입니다.
	/// </summary>
	[DefaultEvent("PaCommentQueryEnd")]
	[DefaultProperty("BoxType")]
	[ToolboxBitmap(typeof(IHIS.Framework.XPaComment), "Images.XPatientBox.bmp")]
	public class XPaComment : System.Windows.Forms.UserControl, ISupportInitialize, IHIS.Framework.IUserObject
	{
		#region Fields
		private ILayoutContainer layoutContainer = null;
        private CommentInfo commentInfo = new CommentInfo();
        private PaCommentType boxType = PaCommentType.PatientComment;
		private XColor xBackColor = XColor.XScreenBackColor;
        private bool showTabControl = true;             //Tab Control을 보여줄지 여부를 지정합니다.
        private bool showButtons = false;               //버튼을 보여줄지 여부를 지정.
        private bool showDisplayOCS = true;             //ocs 표시 컬럼을 보여줄지 여부를 지정.
        private bool isReadOnly = false;                //comment 그리드의 readOnly 여부
        private bool applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
        private static Hashtable defaultImageList = new Hashtable();
        const string IMAGE_PATH = "IHIS.Framework.Images.";
        const int GRD_LEFT_HEADER_WIDTH = 25;
        const int DISPLAY_YN_COL_WIDTH = 63;
        const int GRD_LIGHT_MARGIN = 20;
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
        DefaultValue(false),
        MergableProperty(true),
        Description("코멘트 그리드의 Read only 여부를 지정합니다.")]
        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set
            {
                if (isReadOnly != value)
                {
                    isReadOnly = value;
                    //comment grid 의 readOnly 설정
                    grdCmmtFwk.ReadOnly = value;
                }
            }
        }
        [Browsable(true), Category("추가속성"),
        DefaultValue(true),
        MergableProperty(true),
        Description("상단의 코멘트 구분 tab control을 보여줄지 여부를 지정합니다.")]
        public bool ShowTabControl
        {
            get { return showTabControl; }
            set
            {
                if (showTabControl != value)
                {
                    showTabControl = value;
                    //tabCmmtFwk의 Size를 변경처리함 (보이면 24, 아니면 0)
                    if (value)
                        tabCmmtFwk.Size = new Size(tabCmmtFwk.Width, 24);
                    else
                        tabCmmtFwk.Size = new Size(tabCmmtFwk.Width, 0);
                }
            }
        }
        [Browsable(true), Category("추가속성"),
        DefaultValue(false),
        MergableProperty(true),
        Description("하단의 button control을 보여줄지 여부를 지정합니다.")]
        public bool ShowButtons
        {
            get { return showButtons; }
            set
            {
                if (showButtons != value)
                {
                    showButtons = value;
                    //fwkPnlBottom의 Size를 변경처리함 (보이면 25, 아니면 0)
                    if (value)
                        fwkPnlBottom.Size = new Size(fwkPnlBottom.Width, 25);
                    else
                        fwkPnlBottom.Size = new Size(fwkPnlBottom.Width, 0);
                }
            }
        }
        [Browsable(true), Category("추가속성"),
        DefaultValue(true),
        MergableProperty(true),
        Description("그리드의 OCS 표시 COLUMN을 보여줄지 여부를 지정합니다.")]
        public bool ShowDisplayOCS
        {
            get { return showDisplayOCS; }
            set
            {
                if (showDisplayOCS != value)
                {
                    showDisplayOCS = value;
                    //ocs 표시 컬럼의 Size를 변경처리함
                    if (value)
                    {
                        grdCmmtFwk.AutoSizeColumn(1, grdCmmtFwk.Width - GRD_LIGHT_MARGIN - GRD_LEFT_HEADER_WIDTH - DISPLAY_YN_COL_WIDTH);
                        grdCmmtFwk.AutoSizeColumn(2, DISPLAY_YN_COL_WIDTH);
                    }
                    else
                    {
                        grdCmmtFwk.AutoSizeColumn(1, grdCmmtFwk.Width - GRD_LIGHT_MARGIN - GRD_LEFT_HEADER_WIDTH);
                        grdCmmtFwk.AutoSizeColumn(2, 0);
                    }
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

        //환자번호
        [Browsable(false), DataBindable]
        public string BunHo
        {
            get { return commentInfo.BunHo; }
        }
        //ocs 표시 여부
        [Browsable(false)]
        public string DisplayYn
        {
            get { return commentInfo.DisplayYn; }
        }
        //fkocs
        [Browsable(false), DataBindable]
        public string Fkocs
        {
            get { return commentInfo.Fkocs; }
        }
        //항목코드
        [Browsable(false)]
        public string HangmogCode
        {
            get { return commentInfo.HangmogCode; }
        }
        //입원 외래 구분
        [Browsable(false), DataBindable]
        public string InOutGubun
        {
            get { return commentInfo.InOutGubun; }
        }
        //전달파트
        [Browsable(false), DataBindable]
        public string JundalPart
        {
            get { return commentInfo.JundalPart; }
        }
        //전달 테이블
        [Browsable(false), DataBindable]
        public string JundalTable
        {
            get { return commentInfo.JundalTable; }
        }
        #endregion

		#region Event
		/// <summary>
		/// 환자번호가 입력되었을때 발생하는 Event 입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("환자번호가 입력(선택)되었을때 발생합니다.")]
		public event EventHandler PaCommentQueryEnd;
		#endregion

        private System.Windows.Forms.ToolTip fwkToolTip;
        private XTabControl tabCmmtFwk;
        private XEditGrid grdCmmtFwk;
        private XEditGridCell xFwkEditGridCell1;
        private XEditGridCell xFwkEditGridCell2;
        private XEditGridCell xFwkEditGridCell3;
        private XEditGridCell xFwkEditGridCell4;
        private XEditGridCell xFwkEditGridCell5;
        private XEditGridCell xFwkEditGridCell6;
        private XEditGridCell xFwkEditGridCell7;
        private XEditGridCell xFwkEditGridCell8;
        private XEditGridCell xFwkEditGridCell9;
        private XEditGridCell xFwkEditGridCell10;
        private MultiLayout layCmmtGubunfwk;
        private MultiLayoutItem fwkMultiLayoutItem1;
        private MultiLayoutItem fwkMultiLayoutItem2;
        private Panel fwkPnlBottom;
        private XButton btnQueryFwk;
        private XButton btnUpdateFwk;
        private XButton btnDeleteFwk;
        private XButton btnInsertFwk;
		private System.ComponentModel.IContainer components;

		#region 생성자
        static XPaComment()
        {
            //Button에 사용되는 기본이미지 GET
            System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
            defaultImageList.Add("U", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Update.gif")));
            defaultImageList.Add("I", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Insert.gif")));
            defaultImageList.Add("Q", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Query.gif")));
            defaultImageList.Add("D", Bitmap.FromStream(l_as.GetManifestResourceStream(IMAGE_PATH + "Delete.gif")));
        }

        public XPaComment()
        {
            // 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
            InitializeComponent();

            //this.Size = new Size(800,32);
            this.BackColor = XColor.XScreenBackColor;
            this.Font = new Font("MS UI Gothic", 9.75f);
            //Ancher는 BottomRight
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            btnInsertFwk.Text = XMsg.GetField("F003"); // 입 력
            btnInsertFwk.Image = (Image)defaultImageList["I"];
            btnDeleteFwk.Text = XMsg.GetField("F004"); // 삭 제
            btnDeleteFwk.Image = (Image)defaultImageList["D"];
            btnQueryFwk.Text = XMsg.GetField("F005"); // 조 회
            btnQueryFwk.Image = (Image)defaultImageList["Q"];
            btnUpdateFwk.Text = XMsg.GetField("F007"); // 저 장
            btnUpdateFwk.Image = (Image)defaultImageList["U"];

            /*
            this.lbPaid.Text = (NetInfo.Language == LangMode.Ko ? "환자번호" : "患者番号");
            //ToolTip Text Set
            this.fwkToolTip.SetToolTip(this.pbxBallMove, (NetInfo.Language == LangMode.Ko ? "클릭시에 상세정보를 보여줍니다."
                : "クリックすると細部情報が見えます。"));
            this.fwkToolTip.SetToolTip(this.btnFind, (NetInfo.Language == LangMode.Ko ? "클릭시에 환자검색창을 보여줍니다."
                :"クリックすると患者検索画面が見えます。"));

            //입원중 이미지 GET
            System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
            this.inHospitalImage = Bitmap.FromStream(l_as.GetManifestResourceStream("IHIS.Framework.Images.InHospital.gif"));

            //2007/01/30 환자번호길이에 따라 txtBunho의 MaxLength 변경처리
            this.txtBunHo.MaxLength = EnvironInfo.BunhoLength;
            */
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XPaComment));
            this.fwkToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.fwkPnlBottom = new System.Windows.Forms.Panel();
            this.btnQueryFwk = new IHIS.Framework.XButton();
            this.btnInsertFwk = new IHIS.Framework.XButton();
            this.btnDeleteFwk = new IHIS.Framework.XButton();
            this.btnUpdateFwk = new IHIS.Framework.XButton();
            this.grdCmmtFwk = new IHIS.Framework.XEditGrid();
            this.xFwkEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xFwkEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xFwkEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xFwkEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xFwkEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xFwkEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xFwkEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xFwkEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xFwkEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xFwkEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.tabCmmtFwk = new IHIS.Framework.XTabControl();
            this.layCmmtGubunfwk = new IHIS.Framework.MultiLayout();
            this.fwkMultiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.fwkMultiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.fwkPnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCmmtFwk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCmmtGubunfwk)).BeginInit();
            this.SuspendLayout();
            // 
            // fwkPnlBottom
            // 
            this.fwkPnlBottom.AccessibleDescription = null;
            this.fwkPnlBottom.AccessibleName = null;
            resources.ApplyResources(this.fwkPnlBottom, "fwkPnlBottom");
            this.fwkPnlBottom.BackgroundImage = null;
            this.fwkPnlBottom.Controls.Add(this.btnQueryFwk);
            this.fwkPnlBottom.Controls.Add(this.btnInsertFwk);
            this.fwkPnlBottom.Controls.Add(this.btnDeleteFwk);
            this.fwkPnlBottom.Controls.Add(this.btnUpdateFwk);
            this.fwkPnlBottom.Font = null;
            this.fwkPnlBottom.Name = "fwkPnlBottom";
            this.fwkToolTip.SetToolTip(this.fwkPnlBottom, resources.GetString("fwkPnlBottom.ToolTip"));
            // 
            // btnQueryFwk
            // 
            this.btnQueryFwk.AccessibleDescription = null;
            this.btnQueryFwk.AccessibleName = null;
            resources.ApplyResources(this.btnQueryFwk, "btnQueryFwk");
            this.btnQueryFwk.BackgroundImage = null;
            this.btnQueryFwk.Font = null;
            this.btnQueryFwk.Name = "btnQueryFwk";
            this.fwkToolTip.SetToolTip(this.btnQueryFwk, resources.GetString("btnQueryFwk.ToolTip"));
            this.btnQueryFwk.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnInsertFwk
            // 
            this.btnInsertFwk.AccessibleDescription = null;
            this.btnInsertFwk.AccessibleName = null;
            resources.ApplyResources(this.btnInsertFwk, "btnInsertFwk");
            this.btnInsertFwk.BackgroundImage = null;
            this.btnInsertFwk.Font = null;
            this.btnInsertFwk.Name = "btnInsertFwk";
            this.fwkToolTip.SetToolTip(this.btnInsertFwk, resources.GetString("btnInsertFwk.ToolTip"));
            this.btnInsertFwk.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnDeleteFwk
            // 
            this.btnDeleteFwk.AccessibleDescription = null;
            this.btnDeleteFwk.AccessibleName = null;
            resources.ApplyResources(this.btnDeleteFwk, "btnDeleteFwk");
            this.btnDeleteFwk.BackgroundImage = null;
            this.btnDeleteFwk.Font = null;
            this.btnDeleteFwk.Name = "btnDeleteFwk";
            this.fwkToolTip.SetToolTip(this.btnDeleteFwk, resources.GetString("btnDeleteFwk.ToolTip"));
            this.btnDeleteFwk.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnUpdateFwk
            // 
            this.btnUpdateFwk.AccessibleDescription = null;
            this.btnUpdateFwk.AccessibleName = null;
            resources.ApplyResources(this.btnUpdateFwk, "btnUpdateFwk");
            this.btnUpdateFwk.BackgroundImage = null;
            this.btnUpdateFwk.Font = null;
            this.btnUpdateFwk.Name = "btnUpdateFwk";
            this.fwkToolTip.SetToolTip(this.btnUpdateFwk, resources.GetString("btnUpdateFwk.ToolTip"));
            this.btnUpdateFwk.Click += new System.EventHandler(this.btn_Click);
            // 
            // grdCmmtFwk
            // 
            resources.ApplyResources(this.grdCmmtFwk, "grdCmmtFwk");
            this.grdCmmtFwk.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xFwkEditGridCell1,
            this.xFwkEditGridCell2,
            this.xFwkEditGridCell3,
            this.xFwkEditGridCell4,
            this.xFwkEditGridCell5,
            this.xFwkEditGridCell6,
            this.xFwkEditGridCell7,
            this.xFwkEditGridCell8,
            this.xFwkEditGridCell9,
            this.xFwkEditGridCell10});
            this.grdCmmtFwk.ColPerLine = 2;
            this.grdCmmtFwk.Cols = 3;
            this.grdCmmtFwk.ExecuteQuery = null;
            this.grdCmmtFwk.FixedCols = 1;
            this.grdCmmtFwk.FixedRows = 1;
            this.grdCmmtFwk.HeaderHeights.Add(21);
            this.grdCmmtFwk.Name = "grdCmmtFwk";
            this.grdCmmtFwk.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdCmmtFwk.ParamList")));
            this.grdCmmtFwk.QuerySQL = resources.GetString("grdCmmtFwk.QuerySQL");
            this.grdCmmtFwk.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdCmmtFwk.RowHeaderVisible = true;
            this.grdCmmtFwk.Rows = 2;
            this.fwkToolTip.SetToolTip(this.grdCmmtFwk, resources.GetString("grdCmmtFwk.ToolTip"));
            this.grdCmmtFwk.ToolTipActive = true;
            // 
            // xFwkEditGridCell1
            // 
            this.xFwkEditGridCell1.CellLen = 80;
            this.xFwkEditGridCell1.CellName = "comments";
            this.xFwkEditGridCell1.CellWidth = 295;
            this.xFwkEditGridCell1.Col = 1;
            this.xFwkEditGridCell1.ExecuteQuery = null;
            this.xFwkEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xFwkEditGridCell1, "xFwkEditGridCell1");
            // 
            // xFwkEditGridCell2
            // 
            this.xFwkEditGridCell2.CellName = "display_yn";
            this.xFwkEditGridCell2.CellWidth = 88;
            this.xFwkEditGridCell2.Col = 2;
            this.xFwkEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xFwkEditGridCell2.ExecuteQuery = null;
            this.xFwkEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xFwkEditGridCell2, "xFwkEditGridCell2");
            // 
            // xFwkEditGridCell3
            // 
            this.xFwkEditGridCell3.CellName = "bunho";
            this.xFwkEditGridCell3.Col = -1;
            this.xFwkEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xFwkEditGridCell3, "xFwkEditGridCell3");
            this.xFwkEditGridCell3.IsVisible = false;
            this.xFwkEditGridCell3.Row = -1;
            // 
            // xFwkEditGridCell4
            // 
            this.xFwkEditGridCell4.CellName = "cmmt_gubun";
            this.xFwkEditGridCell4.Col = -1;
            this.xFwkEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xFwkEditGridCell4, "xFwkEditGridCell4");
            this.xFwkEditGridCell4.IsVisible = false;
            this.xFwkEditGridCell4.Row = -1;
            // 
            // xFwkEditGridCell5
            // 
            this.xFwkEditGridCell5.CellName = "jundal_table";
            this.xFwkEditGridCell5.Col = -1;
            this.xFwkEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xFwkEditGridCell5, "xFwkEditGridCell5");
            this.xFwkEditGridCell5.IsVisible = false;
            this.xFwkEditGridCell5.Row = -1;
            // 
            // xFwkEditGridCell6
            // 
            this.xFwkEditGridCell6.CellName = "jundal_part";
            this.xFwkEditGridCell6.Col = -1;
            this.xFwkEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xFwkEditGridCell6, "xFwkEditGridCell6");
            this.xFwkEditGridCell6.IsVisible = false;
            this.xFwkEditGridCell6.Row = -1;
            // 
            // xFwkEditGridCell7
            // 
            this.xFwkEditGridCell7.CellName = "in_out_gubun";
            this.xFwkEditGridCell7.Col = -1;
            this.xFwkEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xFwkEditGridCell7, "xFwkEditGridCell7");
            this.xFwkEditGridCell7.IsVisible = false;
            this.xFwkEditGridCell7.Row = -1;
            // 
            // xFwkEditGridCell8
            // 
            this.xFwkEditGridCell8.CellName = "fkocs";
            this.xFwkEditGridCell8.Col = -1;
            this.xFwkEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xFwkEditGridCell8, "xFwkEditGridCell8");
            this.xFwkEditGridCell8.IsVisible = false;
            this.xFwkEditGridCell8.Row = -1;
            // 
            // xFwkEditGridCell9
            // 
            this.xFwkEditGridCell9.CellName = "hangmog_code";
            this.xFwkEditGridCell9.Col = -1;
            this.xFwkEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xFwkEditGridCell9, "xFwkEditGridCell9");
            this.xFwkEditGridCell9.IsVisible = false;
            this.xFwkEditGridCell9.Row = -1;
            // 
            // xFwkEditGridCell10
            // 
            this.xFwkEditGridCell10.CellName = "ser";
            this.xFwkEditGridCell10.Col = -1;
            this.xFwkEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xFwkEditGridCell10, "xFwkEditGridCell10");
            this.xFwkEditGridCell10.IsVisible = false;
            this.xFwkEditGridCell10.Row = -1;
            // 
            // tabCmmtFwk
            // 
            this.tabCmmtFwk.AccessibleDescription = null;
            this.tabCmmtFwk.AccessibleName = null;
            resources.ApplyResources(this.tabCmmtFwk, "tabCmmtFwk");
            this.tabCmmtFwk.BackgroundImage = null;
            this.tabCmmtFwk.Font = null;
            this.tabCmmtFwk.IDEPixelArea = true;
            this.tabCmmtFwk.IDEPixelBorder = false;
            this.tabCmmtFwk.Name = "tabCmmtFwk";
            this.fwkToolTip.SetToolTip(this.tabCmmtFwk, resources.GetString("tabCmmtFwk.ToolTip"));
            this.tabCmmtFwk.SelectionChanged += new System.EventHandler(this.tabCmmtFwk_SelectionChanged);
            // 
            // layCmmtGubunfwk
            // 
            this.layCmmtGubunfwk.ExecuteQuery = null;
            this.layCmmtGubunfwk.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.fwkMultiLayoutItem1,
            this.fwkMultiLayoutItem2});
            this.layCmmtGubunfwk.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCmmtGubunfwk.ParamList")));
            // 
            // fwkMultiLayoutItem1
            // 
            this.fwkMultiLayoutItem1.DataName = "code";
            // 
            // fwkMultiLayoutItem2
            // 
            this.fwkMultiLayoutItem2.DataName = "code_name";
            // 
            // XPaComment
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdCmmtFwk);
            this.Controls.Add(this.tabCmmtFwk);
            this.Controls.Add(this.fwkPnlBottom);
            this.Name = "XPaComment";
            this.fwkToolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Resize += new System.EventHandler(this.XPaComment_Resize);
            this.fwkPnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCmmtFwk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCmmtGubunfwk)).EndInit();
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
		/// 초기화 종료시 환자번호 BOX 초기화(InitialzePaComment)합니다.
		/// </summary>
		void ISupportInitialize.EndInit()
		{
			InitialzePaComment();
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
            this.grdCmmtFwk.Reset();
		}
		#endregion

		#region InitialzePaComment (환자번호 Box 초기화)
		public void InitialzePaComment()
		{
			//추후 업무확정후 추가
            this.grdCmmtFwk.SavePerformer = new XSavePerformer(this);
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
		/// 환자특이사항 Box가 있는 화면,Form이 ILayoutContainer인지 SET 
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
			else
				XMessageBox.Show(msg, "PaComment");
		}
		#endregion

		#region Methods
        private bool QueryPatientInfo()  //환자번호로 환자 특이사항 조회
        {
            //PaCommentType에 따라 텝 선택시 그리드 편집 모두 변경
            switch (this.boxType)
            {
                case PaCommentType.PatientComment:
                    break;
                case PaCommentType.PartComment:
                    break;
                case PaCommentType.OrderComment:
                    break;
                default:
                    break;
            }

            //특이사항 조회
            return false;
        }
        #endregion

        #region Event Invoker
        protected virtual void OnPaCommentQueryEnd(EventArgs e)
        {
            if (this.PaCommentQueryEnd != null)
                PaCommentQueryEnd(this, e);
        }
        #endregion

        #region 조회 조건 셋팅 Method
        public void SetQueryVar(string bunHo, string cmmtGubun, string jundalTable, string jundalPart, string fkocs)
        {
            this.commentInfo.BunHo = bunHo;
            this.commentInfo.CmmtGubun = cmmtGubun;
            this.commentInfo.JundalTable = jundalTable;
            this.commentInfo.JundalPart = jundalPart;
            this.commentInfo.Fkocs = fkocs;
        }
        #endregion

        #region 코멘트 정보 셋팅 Method
        /// <summary>
        /// 환자코멘트 정보.. 번호 setting method
        /// </summary>
        public void SetCommentInfo(string bunHo)
        {
            this.commentInfo.BunHo = bunHo;
        }
        public void SetCommentInfo(string bunHo, string cmmtGubun)
        {
            this.commentInfo.BunHo = bunHo;
            this.commentInfo.CmmtGubun = cmmtGubun;
        }
        public void SetCommentInfo(string bunHo, string cmmtGubun, string jundalTable)
        {
            this.commentInfo.BunHo = bunHo;
            this.commentInfo.CmmtGubun = cmmtGubun;
            this.commentInfo.JundalTable = jundalTable;
        }
        public void SetCommentInfo(string bunHo, string cmmtGubun, string jundalTable, string jundalPart)
        {
            this.commentInfo.BunHo = bunHo;
            this.commentInfo.CmmtGubun = cmmtGubun;
            this.commentInfo.JundalTable = jundalTable;
            this.commentInfo.JundalPart = jundalPart;
        }
        public void SetCommentInfo(string bunHo, string cmmtGubun, string jundalTable, string jundalPart, string fkocs)
        {
            this.commentInfo.BunHo = bunHo;
            this.commentInfo.CmmtGubun = cmmtGubun;
            this.commentInfo.JundalTable = jundalTable;
            this.commentInfo.JundalPart = jundalPart;
            this.commentInfo.Fkocs = fkocs;
        }
        public void SetCommentInfo(string bunHo, string cmmtGubun, string jundalTable, string jundalPart, string fkocs, string inOutGubun)
        {
            this.commentInfo.BunHo = bunHo;
            this.commentInfo.CmmtGubun = cmmtGubun;
            this.commentInfo.JundalTable = jundalTable;
            this.commentInfo.JundalPart = jundalPart;
            this.commentInfo.Fkocs = fkocs;
            this.commentInfo.InOutGubun = inOutGubun;
        }
        public void SetCommentInfo(string bunHo, string cmmtGubun, string jundalTable, string jundalPart, string fkocs, string inOutGubun, string hangmogCode)
        {
            this.commentInfo.BunHo = bunHo;
            this.commentInfo.CmmtGubun = cmmtGubun;
            this.commentInfo.JundalTable = jundalTable;
            this.commentInfo.JundalPart = jundalPart;
            this.commentInfo.Fkocs = fkocs;
            this.commentInfo.InOutGubun = inOutGubun;
            this.commentInfo.HangmogCode = hangmogCode;
        }
        //환자번호셋팅
        public void SetBunho(string aBunho)
        {
            this.commentInfo.BunHo = aBunho;
        }
        //코멘트 구분 셋팅
        public void SetCmmtGubun(string aCmmtGubun)
        {
            this.commentInfo.CmmtGubun = aCmmtGubun;
        }
        //전달 테이블 셋팅
        public void SetJundalTable(string aJundalTable)
        {
            this.commentInfo.JundalTable = aJundalTable;
        }
        //전달 파트 셋팅
        public void SetJundalPart(string aJundalPart)
        {
            this.commentInfo.JundalPart = aJundalPart;
        }
        //ocs key 셋팅
        public void SetFkocs(string aFkocs)
        {
            this.commentInfo.Fkocs = aFkocs;
        }
        //입원/외래 셋팅
        public void SetInOutGubun(string aInOutGubun)
        {
            this.commentInfo.InOutGubun = aInOutGubun;
        }
        //항콕코드 셋팅
        public void SetHangmogCode(string aHangmogCode)
        {
            this.commentInfo.HangmogCode = aHangmogCode;
        }
        #endregion

        #region 탭 생성
        public void TabCreate()
        {
            try
            {
                tabCmmtFwk.TabPages.Clear();
            }
            catch { }

            // Updated by Cloud
            layCmmtGubunfwk.ExecuteQuery = GetLayCmmtGubunfwk;
            layCmmtGubunfwk.QueryLayout(true);

            // 텝 페이지 생성시 첫번째 페이지가 선택된것으로 간주된다.
            // 따라서 전체조회가 되므로 잠시 이벤트를 없애놓음
            this.tabCmmtFwk.SelectionChanged -= new System.EventHandler(this.tabCmmtFwk_SelectionChanged);

            // 텝 페이지 생성
            for (int i = 0; i < layCmmtGubunfwk.RowCount; i++)
            {
                string cmmtGubun = layCmmtGubunfwk.GetItemString(i, "code");
                string cmmtGubunName = layCmmtGubunfwk.GetItemString(i, "code_name");

                IHIS.X.Magic.Controls.TabPage tabPage =
                    new IHIS.X.Magic.Controls.TabPage(cmmtGubunName);
                tabPage.Tag = cmmtGubun;
                tabCmmtFwk.TabPages.Add(tabPage);
            }

            this.tabCmmtFwk.SelectionChanged += new System.EventHandler(this.tabCmmtFwk_SelectionChanged);

            if (layCmmtGubunfwk.RowCount > 0)
            {
                //comment gubun의 탭을 선택하여 해당 데이터를 조회한다.
                tabCmmtFwk.SelectedIndex = 0;
                tabCmmtFwk.Refresh();
                QueryComment("B");
            }
        }
        #endregion

        #region 코멘트 구분별 코멘트 조회
        //'B' -> 환자별
        //'P' -> 파트별
        //'O' -> 오더별
        public void QueryComment(string aCmmtGubun)
        {
            if (TypeCheck.IsNull(commentInfo.BunHo)) return;

            commentInfo.CmmtGubun = aCmmtGubun;
            if (aCmmtGubun == null)
            {
                if (tabCmmtFwk.TabCount > 0)
                    commentInfo.CmmtGubun = tabCmmtFwk.SelectedTab.Tag.ToString();
            }

            // updated by Cloud
            grdCmmtFwk.ParamList = new List<string>(new string[]
                {
                    "f_cmmt_gubun",
                    "f_bunho",
                    "f_jundal_table",
                    "f_jundal_part",
                    "f_fkocs",
                });
            grdCmmtFwk.ExecuteQuery = GetGrdCmmtFwk;

            grdCmmtFwk.SetBindVarValue("f_cmmt_gubun", commentInfo.CmmtGubun);
            grdCmmtFwk.SetBindVarValue("f_bunho", commentInfo.BunHo);
            grdCmmtFwk.SetBindVarValue("f_jundal_table", commentInfo.JundalTable);
            grdCmmtFwk.SetBindVarValue("f_jundal_part", commentInfo.JundalPart);
            grdCmmtFwk.SetBindVarValue("f_fkocs", commentInfo.Fkocs);

            if (!grdCmmtFwk.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }

            //특이사항 조회 후 Event Call
            OnPaCommentQueryEnd(EventArgs.Empty);

        }
        #endregion

        #region 탭 선택 처리
        private void tabCmmtFwk_SelectionChanged(object sender, EventArgs e)
        {
            QueryComment(tabCmmtFwk.SelectedTab.Tag.ToString());
        }
        #endregion

        #region 저장로직
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private XPaComment parent = null;

            public XSavePerformer(XPaComment parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdQry = null;

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("f_user_id", UserInfo.UserID);

                switch (item.RowState)
                {
                    case DataRowState.Added:

                        string cmdText = @"SELECT NVL(MAX(A.SER), 0) + 1 SER
                                             FROM OUT0106 A
                                            WHERE A.HOSP_CODE = :f_hosp_code
                                              AND A.BUNHO = :f_bunho";

                        BindVarCollection bindVars = new BindVarCollection();
                        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                        bindVars.Add("f_bunho", parent.commentInfo.BunHo);

                        object retVal = Service.ExecuteScalar(cmdText, bindVars);
                        if (retVal == null)
                        {
                            XMessageBox.Show(Service.ErrFullMsg + "順番がありません。");
                            return false;
                        }
                        else
                        {
                            item.BindVarList.Add("f_ser1", retVal.ToString());
                            item.BindVarList.Add("f_bunho1", parent.commentInfo.BunHo);
                            item.BindVarList.Add("f_jundal_table1", parent.commentInfo.JundalTable);
                            item.BindVarList.Add("f_jundal_part1", parent.commentInfo.JundalPart);
                            item.BindVarList.Add("f_in_out_gubun1", parent.commentInfo.InOutGubun);
                            item.BindVarList.Add("f_fkocs1", parent.commentInfo.Fkocs);
                            item.BindVarList.Add("f_hangmog_code1", parent.commentInfo.HangmogCode);
                            item.BindVarList.Add("f_cmmt_gubun1", parent.commentInfo.CmmtGubun);
                        }

                        cmdQry = @"INSERT INTO OUT0106( SYS_DATE		, SYS_ID    	  , UPD_DATE       , UPD_ID
                                                      , HOSP_CODE       , COMMENTS		  , SER		       , BUNHO
												      , DISPLAY_YN      , JUNDAL_TABLE    , JUNDAL_PART    , IN_OUT_GUBUN
                                                      , FKOCS           , HANGMOG_CODE    , CMMT_GUBUN     )
												VALUES( SYSDATE 		, :f_user_id      , SYSDATE        , :f_user_id
                                                      , :f_hosp_code    , :f_comments     , :f_ser1	       , :f_bunho1
												      , :f_display_yn   , :f_jundal_table1, :f_jundal_part1, :f_in_out_gubun1
                                                      , :f_fkocs1       , :f_hangmog_code1, :f_cmmt_gubun1 )";
                        break;

                    case DataRowState.Modified:

                        cmdQry = @"UPDATE OUT0106 A
									  SET A.UPD_ID          = :f_user_id
										, A.UPD_DATE        = SYSDATE
										, A.COMMENTS        = :f_comments
										, A.DISPLAY_YN      = :f_display_yn
									WHERE A.HOSP_CODE       = :f_hosp_code 
                                      AND A.BUNHO           = :f_bunho
									  AND A.SER             = :f_ser";
                        break;

                    case DataRowState.Deleted:

                        cmdQry = @"DELETE FROM OUT0106 A
									WHERE A.HOSP_CODE       = :f_hosp_code 
                                      AND A.BUNHO           = :f_bunho
									  AND A.SER             = :f_ser";
                        break;

                }
                if (!Service.ExecuteNonQuery(cmdQry, item.BindVarList))
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                    return false;
                }
                return true;
            }
        }
        #endregion

        #region 저장 메소드
        public void InsertRow()
        {
            if (tabCmmtFwk.SelectedTab.Tag.ToString() == "B" && commentInfo.BunHo == null)
            {
                //환자번호 정보가 존재하지 않습니다.확인해 주세요.
                XMessageBox.Show(XMsg.GetMsg("M037"), XMsg.GetField("F052"));
            }
            else if (tabCmmtFwk.SelectedTab.Tag.ToString() == "P" && commentInfo.JundalPart == null)
            {
                //파트정보가 존재하지 않습니다.확인해 주세요.
                XMessageBox.Show(XMsg.GetMsg("M038"), XMsg.GetField("F052"));
            }
            else if (tabCmmtFwk.SelectedTab.Tag.ToString() == "O" && commentInfo.JundalPart == null)
            {
                //오더정보가 존재하지 않습니다.확인해 주세요.
                XMessageBox.Show(XMsg.GetMsg("M039"), XMsg.GetField("F052"));
            }
            else
            {
                this.grdCmmtFwk.InsertRow();
            }
        }
        public void deleteRow()
        {
            if (tabCmmtFwk.SelectedTab.Tag.ToString() == "B" && commentInfo.BunHo == null)
            {
                //환자번호 정보가 존재하지 않습니다.확인해 주세요.
                XMessageBox.Show(XMsg.GetMsg("M037"), XMsg.GetField("F052"));
            }
            else if (tabCmmtFwk.SelectedTab.Tag.ToString() == "P" && commentInfo.JundalPart == null)
            {
                //파트정보가 존재하지 않습니다.확인해 주세요.
                XMessageBox.Show(XMsg.GetMsg("M038"), XMsg.GetField("F052"));
            }
            else if (tabCmmtFwk.SelectedTab.Tag.ToString() == "O" && commentInfo.JundalPart == null)
            {
                //오더정보가 존재하지 않습니다.확인해 주세요.
                XMessageBox.Show(XMsg.GetMsg("M039"), XMsg.GetField("F052"));
            }
            else
            {
                this.grdCmmtFwk.DeleteRow();
            }
        }
        public void SaveComment()
        {
            if (tabCmmtFwk.SelectedTab.Tag.ToString() == "B" && commentInfo.BunHo == null)
            {
                //환자번호 정보가 존재하지 않습니다.확인해 주세요.
                XMessageBox.Show(XMsg.GetMsg("M037"), XMsg.GetField("F052"));
            }
            else if (tabCmmtFwk.SelectedTab.Tag.ToString() == "P" && commentInfo.JundalPart == null)
            {
                //파트정보가 존재하지 않습니다.확인해 주세요.
                XMessageBox.Show(XMsg.GetMsg("M038"), XMsg.GetField("F052"));
            }
            else if (tabCmmtFwk.SelectedTab.Tag.ToString() == "O" && commentInfo.JundalPart == null)
            {
                //오더정보가 존재하지 않습니다.확인해 주세요.
                XMessageBox.Show(XMsg.GetMsg("M039"), XMsg.GetField("F052"));
            }
            else
            {
                this.grdCmmtFwk.SaveLayout();
            }
            
        }
        #endregion

        #region 버튼 클릭 이벤트
        private void btn_Click(object sender, EventArgs e)
        {
            XButton aBtn = (XButton)sender;
            switch (aBtn.Name)
            {
                case "btnQueryFwk":
                    QueryComment(commentInfo.CmmtGubun);
                    break;
                case "btnInsertFwk":
                    InsertRow();
                    break;
                case "btnDeleteFwk":
                    deleteRow();
                    break;
                case "btnUpdateFwk":
                    SaveComment();
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void XPaComment_Resize(object sender, EventArgs e)
        {
            int width = grdCmmtFwk.Width - GRD_LIGHT_MARGIN; //현재 그리드 width
            if ( grdCmmtFwk.RowHeaderVisible )
                width = width - GRD_LEFT_HEADER_WIDTH; //rowHeader width 빼기
            if (!ShowDisplayOCS)
                width = width + DISPLAY_YN_COL_WIDTH;
            //코멘트 컬럼을 제외한 컬럼의 width 를 빼기
            foreach ( XGridCell cellInfo in grdCmmtFwk.CellInfos )
            {
                if ( (cellInfo.IsVisible) && (cellInfo.CellName != "comments"))
                    width = width - cellInfo.CellWidth;
            }
            grdCmmtFwk.AutoSizeColumn(1, width);
        }

        #region Cloud updated code

        #region GetGrdCmmtFwk
        /// <summary>
        /// GetGrdCmmtFwk
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdCmmtFwk(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            FwPaCommentGrdCmmtFwkArgs args      = new FwPaCommentGrdCmmtFwkArgs();
            args.Bunho                          = bvc["f_bunho"].VarValue;
            args.CmmtGubun                      = bvc["f_cmmt_gubun"].VarValue;
            args.Fkocs                          = bvc["f_fkocs"].VarValue;
            args.JundalPart                     = bvc["f_jundal_part"].VarValue;
            args.JundalTable                    = bvc["f_jundal_table"].VarValue;
            FwPaCommentGrdCmmtFwkResult res = CloudService.Instance.Submit<FwPaCommentGrdCmmtFwkResult, FwPaCommentGrdCmmtFwkArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdCmmtFwkItem.ForEach(delegate(FwPaCommentGrdCmmtFwkInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Comments,
                        item.DisplayYn,
                        item.Bunho,
                        item.CmmtGubun,
                        item.JundalTable,
                        item.JundalPart,
                        item.InOutGubun,
                        item.Fkocs,
                        item.HangmogCode,
                        item.Ser,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayCmmtGubunfwk
        /// <summary>
        /// GetLayCmmtGubunfwk
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayCmmtGubunfwk(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ComboResult res = CacheService.Instance.Get<FwBizObjectXPaCommentLayCmmtGubunfwkArgs, ComboResult>(
                new FwBizObjectXPaCommentLayCmmtGubunfwkArgs(), delegate(ComboResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
                });

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #endregion

    }

	#region PaCommentType Enum
	/// <summary>
	/// 기능의 성격을 관리하는 Enum
	/// </summary>
	public enum PaCommentType
	{
		/// <summary>
		/// 환자별 코멘트 등록만 가능
		/// </summary>
		PatientComment,
		/// <summary>
		/// 환자별,파트별 코멘트 등록만 가능
		/// </summary>
		PartComment,
		/// <summary>
		/// 환자별,파트별,오더별 코멘트 등록 모두 가능
		/// </summary>
		OrderComment
	}
	#endregion

    #region CommentInfo (환자 코멘트 정보 관리 Class)
    internal class CommentInfo
    {
        #region Fields
        string bunho       = "";	//환자번호
        string cmmtGubun   = "";	//comment 구분 ('B':환자별,'P':파트별,'O':오더별)
        string jundalTable = "";    //전달 table
        string jundalPart  = "";	//전달 파트
        string fkocs       = "";	//오더키
        string hangmogCode = "";	//항목코드
        string inOutGubun  = "";	//입원 외래 구분
        string displayYn   = "";	//OCS 표시 여부
        #endregion

        #region Properties
        public string BunHo
        {
            get { return bunho; }
            set { bunho = value; }
        }
        public string CmmtGubun
        {
            get { return cmmtGubun; }
            set { cmmtGubun = value; }
        }
        public string JundalTable
        {
            get { return jundalTable; }
            set { jundalTable = value; }
        }

        public string JundalPart
        {
            get { return jundalPart; }
            set { jundalPart = value; }
        }

        public string Fkocs
        {
            get { return fkocs; }
            set { fkocs = value; }
        }

        public string HangmogCode
        {
            get { return hangmogCode; }
            set { hangmogCode = value; }
        }

        public string InOutGubun
        {
            get { return inOutGubun; }
            set { inOutGubun = value; }
        }

        public string DisplayYn
        {
            get { return displayYn; }
            set { displayYn = value; }
        }
        #endregion

        #region 생성자
        public CommentInfo()
        {
        }
        #endregion

        #region Reset
        public void Reset()
        {
            bunho       = "";	//환자번호
            cmmtGubun   = "";	//comment 구분 ('B':환자별,'P':파트별,'O':오더별)
            jundalTable = "";   //전달 table
            jundalPart  = "";	//전달 파트
            fkocs       = "";	//오더키
            hangmogCode = "";	//항목코드
            inOutGubun  = "";	//입원 외래 구분
            displayYn   = "";	//OCS 표시 여부
        }
        #endregion
    }
    #endregion
}

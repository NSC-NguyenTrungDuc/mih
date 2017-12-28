using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using IHIS.Framework;

namespace IHIS.ADMM
{
	/// <summary>
	/// MsgTreeForm에 대한 요약 설명입니다.
	/// </summary>
	internal class MsgTreeForm : System.Windows.Forms.Form
	{
		#region Fields, Property
		private MainForm parentForm = null;
		//수신자 리스트 관리 ArrayList
		internal ArrayList MsgTreeItemList = new ArrayList();
		private Hashtable beopoDescList = new Hashtable(); //배포목록의 설명관리 Hashtable
		private ListViewColumnSorter lvwSrchColumnSorter = new ListViewColumnSorter(); //검색리스트View Sorter
		private ListViewColumnSorter lvwRecvColumnSorter = new ListViewColumnSorter(); //수신자리스트 Sorter
		#endregion

        #region private Controls
        private System.Windows.Forms.TabControl tabCont;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TreeView tvwList;
		private System.Windows.Forms.Label lbSearchText;
		private IHIS.Framework.XTextBox txtSearch;
		private IHIS.Framework.XButton btnSearch;
		private System.Windows.Forms.Label lbSearchDesc;
		private System.Windows.Forms.Label lbCnt;
		private System.Windows.Forms.ListView lvwSrchList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.GroupBox gbxBeopo;
		private System.Windows.Forms.ListView lvwDetList;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ListView lvwBList;
		private IHIS.Framework.XButton btnConfirm;
		private IHIS.Framework.XButton btnBeapoSave;
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XButton btnDelete;
		private IHIS.Framework.XButton btnAdd;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ListView lvwRecvList;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private IHIS.Framework.XButton btnDeleteBeopo;
		private System.Windows.Forms.Label lbBPIF;
		private System.Windows.Forms.ImageList imageListDrag;
		private IHIS.Framework.MultiLayout layTreeList;
        private IHIS.Framework.MultiLayout laySearchTree;
        private IHIS.Framework.MultiLayout layBeopoList;
        private IHIS.Framework.MultiLayout layRecverInfo;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayout layBeopoListDetail;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
		private System.ComponentModel.IContainer components;
        #endregion private Controls

        public MsgTreeForm(MainForm parent, ArrayList msgTreeItemList)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//일본어 번경
			SetControlNameByLangMode();

			this.parentForm = parent;
			//기 지정한 수신자 Item Set
			foreach (MsgTreeItem item in msgTreeItemList)
				this.MsgTreeItemList.Add(item);
			
			//컬럼 Sorter Mapping
			this.lvwSrchList.ListViewItemSorter = this.lvwSrchColumnSorter;
			this.lvwRecvList.ListViewItemSorter = this.lvwRecvColumnSorter;

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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgTreeForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("病院");
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabCont = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tvwList = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvwSrchList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.lbCnt = new System.Windows.Forms.Label();
            this.lbSearchDesc = new System.Windows.Forms.Label();
            this.btnSearch = new IHIS.Framework.XButton();
            this.txtSearch = new IHIS.Framework.XTextBox();
            this.lbSearchText = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDeleteBeopo = new IHIS.Framework.XButton();
            this.lvwDetList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.gbxBeopo = new System.Windows.Forms.GroupBox();
            this.lbBPIF = new System.Windows.Forms.Label();
            this.lvwBList = new System.Windows.Forms.ListView();
            this.btnClose = new IHIS.Framework.XButton();
            this.btnConfirm = new IHIS.Framework.XButton();
            this.btnBeapoSave = new IHIS.Framework.XButton();
            this.btnDelete = new IHIS.Framework.XButton();
            this.btnAdd = new IHIS.Framework.XButton();
            this.lvwRecvList = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.imageListDrag = new System.Windows.Forms.ImageList(this.components);
            this.layTreeList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.laySearchTree = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.layBeopoList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.layRecverInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.layBeopoListDetail = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.tabCont.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gbxBeopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySearchTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBeopoList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layRecverInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBeopoListDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            // 
            // tabCont
            // 
            this.tabCont.Controls.Add(this.tabPage1);
            this.tabCont.Controls.Add(this.tabPage2);
            this.tabCont.Controls.Add(this.tabPage3);
            this.tabCont.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabCont.ImageList = this.imageList1;
            this.tabCont.Location = new System.Drawing.Point(2, 2);
            this.tabCont.Name = "tabCont";
            this.tabCont.SelectedIndex = 0;
            this.tabCont.Size = new System.Drawing.Size(321, 396);
            this.tabCont.TabIndex = 3;
            this.tabCont.SelectedIndexChanged += new System.EventHandler(this.tabCont_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.tabPage1.Controls.Add(this.tvwList);
            this.tabPage1.ImageIndex = 2;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(313, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "조직도";
            // 
            // tvwList
            // 
            this.tvwList.AllowDrop = true;
            this.tvwList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwList.HideSelection = false;
            this.tvwList.ImageIndex = 0;
            this.tvwList.ImageList = this.imageList1;
            this.tvwList.Location = new System.Drawing.Point(0, 0);
            this.tvwList.Name = "tvwList";
            treeNode1.Name = "";
            treeNode1.Text = "病院";
            this.tvwList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvwList.SelectedImageIndex = 0;
            this.tvwList.Size = new System.Drawing.Size(313, 369);
            this.tvwList.TabIndex = 0;
            this.tvwList.DoubleClick += new System.EventHandler(this.tvwList_DoubleClick);
            this.tvwList.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwList_BeforeSelect);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.tabPage2.Controls.Add(this.lvwSrchList);
            this.tabPage2.Controls.Add(this.lbCnt);
            this.tabPage2.Controls.Add(this.lbSearchDesc);
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.txtSearch);
            this.tabPage2.Controls.Add(this.lbSearchText);
            this.tabPage2.ImageIndex = 3;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 60, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(313, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "검 색";
            // 
            // lvwSrchList
            // 
            this.lvwSrchList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwSrchList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSrchList.FullRowSelect = true;
            this.lvwSrchList.HideSelection = false;
            this.lvwSrchList.Location = new System.Drawing.Point(2, 60);
            this.lvwSrchList.Name = "lvwSrchList";
            this.lvwSrchList.Size = new System.Drawing.Size(309, 307);
            this.lvwSrchList.SmallImageList = this.imageList1;
            this.lvwSrchList.TabIndex = 5;
            this.lvwSrchList.UseCompatibleStateImageBehavior = false;
            this.lvwSrchList.View = System.Windows.Forms.View.Details;
            this.lvwSrchList.DoubleClick += new System.EventHandler(this.lvwSrchList_DoubleClick);
            this.lvwSrchList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwSrchList_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "검색한 수신자";
            this.columnHeader1.Width = 265;
            // 
            // lbCnt
            // 
            this.lbCnt.Location = new System.Drawing.Point(68, 40);
            this.lbCnt.Name = "lbCnt";
            this.lbCnt.Size = new System.Drawing.Size(104, 23);
            this.lbCnt.TabIndex = 4;
            // 
            // lbSearchDesc
            // 
            this.lbSearchDesc.Location = new System.Drawing.Point(8, 40);
            this.lbSearchDesc.Name = "lbSearchDesc";
            this.lbSearchDesc.Size = new System.Drawing.Size(55, 23);
            this.lbSearchDesc.TabIndex = 3;
            this.lbSearchDesc.Text = "검색수";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageIndex = 3;
            this.btnSearch.ImageList = this.imageList1;
            this.btnSearch.Location = new System.Drawing.Point(246, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 26);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "찾 기 ";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSearch.Location = new System.Drawing.Point(60, 10);
            this.txtSearch.MaxLength = 15;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(182, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // lbSearchText
            // 
            this.lbSearchText.Location = new System.Drawing.Point(8, 12);
            this.lbSearchText.Name = "lbSearchText";
            this.lbSearchText.Size = new System.Drawing.Size(50, 18);
            this.lbSearchText.TabIndex = 0;
            this.lbSearchText.Text = "검색어";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.tabPage3.Controls.Add(this.btnDeleteBeopo);
            this.tabPage3.Controls.Add(this.lvwDetList);
            this.tabPage3.Controls.Add(this.gbxBeopo);
            this.tabPage3.ImageIndex = 4;
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(313, 369);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "배포목록";
            // 
            // btnDeleteBeopo
            // 
            this.btnDeleteBeopo.Location = new System.Drawing.Point(224, 128);
            this.btnDeleteBeopo.Name = "btnDeleteBeopo";
            this.btnDeleteBeopo.Size = new System.Drawing.Size(82, 26);
            this.btnDeleteBeopo.TabIndex = 4;
            this.btnDeleteBeopo.Text = "목록삭제";
            this.btnDeleteBeopo.Click += new System.EventHandler(this.btnDeleteBeopo_Click);
            // 
            // lvwDetList
            // 
            this.lvwDetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvwDetList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvwDetList.HideSelection = false;
            this.lvwDetList.Location = new System.Drawing.Point(0, 161);
            this.lvwDetList.Name = "lvwDetList";
            this.lvwDetList.Size = new System.Drawing.Size(313, 208);
            this.lvwDetList.SmallImageList = this.imageList1;
            this.lvwDetList.TabIndex = 1;
            this.lvwDetList.UseCompatibleStateImageBehavior = false;
            this.lvwDetList.View = System.Windows.Forms.View.Details;
            this.lvwDetList.DoubleClick += new System.EventHandler(this.lvwDetList_DoubleClick);
            this.lvwDetList.Enter += new System.EventHandler(this.lvwDetList_Enter);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "상세 리스트";
            this.columnHeader2.Width = 281;
            // 
            // gbxBeopo
            // 
            this.gbxBeopo.Controls.Add(this.lbBPIF);
            this.gbxBeopo.Controls.Add(this.lvwBList);
            this.gbxBeopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxBeopo.Location = new System.Drawing.Point(0, 0);
            this.gbxBeopo.Name = "gbxBeopo";
            this.gbxBeopo.Size = new System.Drawing.Size(313, 160);
            this.gbxBeopo.TabIndex = 0;
            this.gbxBeopo.TabStop = false;
            this.gbxBeopo.Text = "목록함";
            // 
            // lbBPIF
            // 
            this.lbBPIF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbBPIF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBPIF.Location = new System.Drawing.Point(3, 113);
            this.lbBPIF.Name = "lbBPIF";
            this.lbBPIF.Size = new System.Drawing.Size(307, 44);
            this.lbBPIF.TabIndex = 1;
            // 
            // lvwBList
            // 
            this.lvwBList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwBList.FullRowSelect = true;
            this.lvwBList.HideSelection = false;
            this.lvwBList.Location = new System.Drawing.Point(3, 16);
            this.lvwBList.MultiSelect = false;
            this.lvwBList.Name = "lvwBList";
            this.lvwBList.Size = new System.Drawing.Size(307, 97);
            this.lvwBList.SmallImageList = this.imageList1;
            this.lvwBList.TabIndex = 0;
            this.lvwBList.UseCompatibleStateImageBehavior = false;
            this.lvwBList.View = System.Windows.Forms.View.List;
            this.lvwBList.SelectedIndexChanged += new System.EventHandler(this.lvwBList_SelectedIndexChanged);
            this.lvwBList.DoubleClick += new System.EventHandler(this.lvwBList_DoubleClick);
            this.lvwBList.Enter += new System.EventHandler(this.lvwBList_Enter);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(336, 296);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Size = new System.Drawing.Size(68, 27);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "닫  기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(336, 256);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnConfirm.Size = new System.Drawing.Size(68, 27);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "확  인";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnBeapoSave
            // 
            this.btnBeapoSave.Location = new System.Drawing.Point(336, 192);
            this.btnBeapoSave.Name = "btnBeapoSave";
            this.btnBeapoSave.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnBeapoSave.Size = new System.Drawing.Size(68, 27);
            this.btnBeapoSave.TabIndex = 7;
            this.btnBeapoSave.Text = "배포 저장";
            this.btnBeapoSave.Click += new System.EventHandler(this.btnBeapoSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(336, 136);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnDelete.Size = new System.Drawing.Size(68, 27);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "삭  제";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(336, 96);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnAdd.Size = new System.Drawing.Size(68, 27);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "추  가";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwRecvList
            // 
            this.lvwRecvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.lvwRecvList.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvwRecvList.FullRowSelect = true;
            this.lvwRecvList.HideSelection = false;
            this.lvwRecvList.Location = new System.Drawing.Point(414, 2);
            this.lvwRecvList.Name = "lvwRecvList";
            this.lvwRecvList.Size = new System.Drawing.Size(224, 396);
            this.lvwRecvList.SmallImageList = this.imageList1;
            this.lvwRecvList.TabIndex = 6;
            this.lvwRecvList.UseCompatibleStateImageBehavior = false;
            this.lvwRecvList.View = System.Windows.Forms.View.Details;
            this.lvwRecvList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwRecvList_ColumnClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "수신자 리스트";
            this.columnHeader6.Width = 198;
            // 
            // imageListDrag
            // 
            this.imageListDrag.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListDrag.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListDrag.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // layTreeList
            // 
            this.layTreeList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.layTreeList.QuerySQL = resources.GetString("layTreeList.QuerySQL");
            this.layTreeList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layTreeList_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "title";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "recv_spot_yn";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "buseo_code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "user_id";
            // 
            // laySearchTree
            // 
            this.laySearchTree.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10});
            this.laySearchTree.QuerySQL = resources.GetString("laySearchTree.QuerySQL");
            this.laySearchTree.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySearchTree_QueryStarting);
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "title";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "recv_spot_yn";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "buseo_code";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "user_id";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "atch_buseo";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "atch_buseo_nm";
            // 
            // layBeopoList
            // 
            this.layBeopoList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem15,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20});
            this.layBeopoList.QuerySQL = "SELECT A.USER_ID\r\n     , A.SEQ\r\n     , A.BEOPO_DESC\r\n     , A.BEOPO_NAME\r\n  FROM " +
                "ADM0740 A\r\n WHERE A.HOSP_CODE = :f_hosp_code\r\n   AND A.USER_ID   = :f_user_id";
            this.layBeopoList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layBeopoList_QueryStarting);
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "user_id";
            this.multiLayoutItem15.IsUpdItem = true;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "seq";
            this.multiLayoutItem18.IsUpdItem = true;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "beopo_desc";
            this.multiLayoutItem19.IsUpdItem = true;
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "beopo_name";
            this.multiLayoutItem20.IsUpdItem = true;
            // 
            // layRecverInfo
            // 
            this.layRecverInfo.CallerID = '2';
            this.layRecverInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem16});
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "beopo_gubun";
            this.multiLayoutItem13.IsUpdItem = true;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "recv_spot";
            this.multiLayoutItem14.IsUpdItem = true;
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "user_id";
            this.multiLayoutItem16.IsUpdItem = true;
            // 
            // layBeopoListDetail
            // 
            this.layBeopoListDetail.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem17,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23});
            this.layBeopoListDetail.QuerySQL = resources.GetString("layBeopoListDetail.QuerySQL");
            this.layBeopoListDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layBeopoListDetail_QueryStarting);
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "title";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "recv_spot_yn";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "buseo_code";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "user_id";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "atch_buseo";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "atch_buseo_nm";
            // 
            // MsgTreeForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(640, 400);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnBeapoSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tabCont);
            this.Controls.Add(this.lvwRecvList);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MsgTreeForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "수신자 지정";
            this.tabCont.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.gbxBeopo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySearchTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBeopoList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layRecverInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBeopoListDetail)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		private TreeNode rootNode = null;
        public string mHospCode = "";
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            mHospCode = EnvironInfo.HospCode;

            this.layBeopoList.SavePerformer = new XSavePerformer(this);
            this.layRecverInfo.SavePerformer = this.layBeopoList.SavePerformer;

            this.tabCont.TabPages[2].Width = 0;
			//rootNode Set
			this.rootNode = this.tvwList.Nodes[0];
			this.rootNode.Tag = new MsgTreeItem(); //Tag에 MsgTreeItem Set (ROOT)
			//조직도 구성 (ROOT)
			SetMsgTree(rootNode, "ROOT", "ROOT");
            foreach (TreeNode node in this.tvwList.Nodes[0].Nodes)
            {
                MsgTreeItem mItem = (MsgTreeItem) node.Tag;
                if (mItem.ItemType == ItemType.Buseo)
                {
                    SetMsgTree(node, mItem.Buseo, mItem.Title);
                }
            }
			rootNode.Expand();
			//배포목록조회
			this.SetBeopoList();
			//기 수신자리스트에 지정된 사항이 있으면 수신자리스트 SET
			string text;
			foreach (MsgTreeItem item in this.MsgTreeItemList)
			{
				ListViewItem vItem = new ListViewItem();
				text = GetItemText(item);
				vItem.Text = text;
				vItem.Tag = item;
				//ItemType이 사용자이면 ImageIndex = 1, 그룹,Beopo면 ImageIndex = 0
				if (item.ItemType == ItemType.User)
					vItem.ImageIndex = 1;
				else
					vItem.ImageIndex = 0;
				lvwRecvList.Items.Add(vItem);
			}
		}
		#endregion

		private void SetMsgTree(TreeNode parentNode, string parentBuseo, string parentBuseoName)
		{

			TreeNode tNode = null;
			ItemType itemType = ItemType.Buseo;
			//기존 Node Clear
			parentNode.Nodes.Clear();

            //Input은 상위부서코드 SET
            this.layTreeList.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layTreeList.SetBindVarValue("f_buseo_code", parentBuseo);

            if (layTreeList.QueryLayout(false))
            {
                foreach (DataRow dtRow in layTreeList.LayoutTable.Rows)
                {
                    tNode = new TreeNode(dtRow["title"].ToString());
                    itemType = (dtRow["recv_spot_yn"].ToString() == "Y" ? ItemType.Buseo : ItemType.User);
                    tNode.Tag = new MsgTreeItem(dtRow["title"].ToString(), parentBuseo, parentBuseoName, dtRow["buseo_code"].ToString(), dtRow["user_id"].ToString(), itemType);
                    //ImageIndex Set
                    if (itemType == ItemType.Buseo)
                    {
                        tNode.ImageIndex = 0;  //목록
                        tNode.SelectedImageIndex = 0;
                    }
                    else
                    {
                        tNode.ImageIndex = 1;  //사용자
                        tNode.SelectedImageIndex = 1;
                    }
                    parentNode.Nodes.Add(tNode);
                }
            }
            else
            {
                string msg = "組織図リストの生成に失敗しました。\n\n" + "エラー[" + Service.ErrFullMsg + "]";
                XMessageBox.Show(msg);
            }
            
		}

		private void SetBeopoList()
		{
			//배포리스트 조회
			this.lvwBList.Items.Clear();
			this.beopoDescList.Clear();
			ListViewItem lvItem = null;

            this.layBeopoList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layBeopoList.SetBindVarValue("f_user_id", MainForm.CurrUserID);

            if (this.layBeopoList.QueryLayout(true))
            {
                foreach (DataRow dtRow in this.layBeopoList.LayoutTable.Rows)
                {
                    lvItem = new ListViewItem(dtRow["beopo_name"].ToString(), 4);
                    //Tag에 MsgTreeItem 저장
                    lvItem.Tag = new MsgTreeItem(dtRow["beopo_name"].ToString(), dtRow["seq"].ToString());
                    lvwBList.Items.Add(lvItem);
                    //beopoDescList에 배포목록 설명 저장
                    beopoDescList.Add(dtRow["seq"].ToString(), dtRow["beopo_desc"].ToString());
                }
            }
            else
            {
                string msg = (NetInfo.Language == LangMode.Ko ? "배포목록 생성하지 못했습니다.\n" + "에러[" + Service.ErrFullMsg + "]"
                    : "配布リストの生成に失敗しました。\n" + "エラー[" + Service.ErrFullMsg + "]");
                XMessageBox.Show(msg);
            }
		}
		private void SetDetailBeopoList(string beopoID) //배포그룹 ID
		{
			//배포상세리스트 조회
			this.lvwDetList.Items.Clear();
			ListViewItem lvItem = null;
			ItemType itemType = ItemType.Buseo;
			MsgTreeItem msgItem = null;

            //Input Set (사용자ID + SEQ)
            //this.dsvQryDetailBeopo.SetInValue("user_id", MainForm.CurrUserID);
            //this.dsvQryDetailBeopo.SetInValue("seq", beopoID);
         

            this.layBeopoListDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layBeopoListDetail.SetBindVarValue("f_user_id", MainForm.CurrUserID);
            this.layBeopoListDetail.SetBindVarValue("f_seq", beopoID);

            if (this.layBeopoListDetail.QueryLayout(true))
            {
                foreach (DataRow dtRow in this.layBeopoListDetail.LayoutTable.Rows)
                {
                    lvItem = new ListViewItem();
                    itemType = (dtRow["recv_spot_yn"].ToString() == "Y" ? ItemType.Buseo : ItemType.User);
                    //ImageIndex Set
                    if (itemType == ItemType.Buseo)
                        lvItem.ImageIndex = 0;  //목록
                    else
                        lvItem.ImageIndex = 1;  //사용자

                    msgItem = new MsgTreeItem(dtRow["title"].ToString(), dtRow["atch_buseo"].ToString(), dtRow["atch_buseo_nm"].ToString(),
                                              dtRow["buseo_code"].ToString(), dtRow["user_id"].ToString(), itemType);
                    //Tag에 MsgTreeItem Set
                    lvItem.Tag = msgItem;
                    lvItem.Text = GetItemText(msgItem);
                    lvwDetList.Items.Add(lvItem);
                }
            }
            else
            {
                string msg = (NetInfo.Language == LangMode.Ko ? "배포상세내역을 생성하지 못했습니다.\n" + "에러[" + Service.ErrFullMsg + "]"
                    : "配布詳細リストの生成に失敗しました。\n" + "エラー[" + Service.ErrFullMsg + "]");
                XMessageBox.Show(msg);

            }
		}

		private void SetRecvListItem(string name, MsgTreeItem treeItem)
		{
			//이미 존재하는지 여부 확인
			bool isExist = false;
			MsgTreeItem tItem = null;
			foreach (ListViewItem lvItem in this.lvwRecvList.Items)
			{
				tItem = (MsgTreeItem) lvItem.Tag;
				if (tItem.ItemType == ItemType.Beopo) //배포그룹은 GroupID 비교
				{
					if (tItem.BeopoID == treeItem.BeopoID)
					{
						isExist = true;
						break;
					}
				}
				else if (tItem.ItemType == ItemType.Buseo) //부서코드 비교
				{
					if (tItem.Buseo == treeItem.Buseo)
					{
						isExist = true;
						break;
					}
				}
				else //사용자
				{
					if (tItem.UserID == treeItem.UserID)
					{
						isExist = true;
						break;
					}
				}
			}
			if (isExist)
			{
				string msg = (NetInfo.Language == LangMode.Ko ? "[" + name + "] 이미 수신자 목록에 있습니다."
					:"[" + name + "]さんは既に受信先リストに登録されています。");
				XMessageBox.Show(msg);
				return;
			}
			ListViewItem vItem = new ListViewItem(name);
			vItem.Tag = treeItem;
			//ItemType이 사용자이면 ImageIndex = 1, 그룹 ImageIndex = 0, 배포는 4
			if (treeItem.ItemType == ItemType.User)
				vItem.ImageIndex = 1;
			else if (treeItem.ItemType == ItemType.Beopo)
				vItem.ImageIndex = 4;
			else
				vItem.ImageIndex = 0;
			lvwRecvList.Items.Add(vItem);
		}
		
		private void SetSearchListView(string srchText) //검색어
		{
			//배포상세리스트 조회
			this.lvwSrchList.Items.Clear();
			ListViewItem lvItem = null;
			ItemType itemType = ItemType.Buseo;
			MsgTreeItem msgItem = null;

            this.laySearchTree.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.laySearchTree.SetBindVarValue("f_search_text", srchText);
            if (this.laySearchTree.QueryLayout(true))
            {
                foreach (DataRow dtRow in this.laySearchTree.LayoutTable.Rows)
                {
                    lvItem = new ListViewItem();
                    itemType = (dtRow["recv_spot_yn"].ToString() == "Y" ? ItemType.Buseo : ItemType.User);
                    //ImageIndex Set
                    if (itemType == ItemType.Buseo)
                        lvItem.ImageIndex = 0;  //목록
                    else
                        lvItem.ImageIndex = 1;  //사용자

                    //Tag에 MsgTreeItem Set
                    msgItem = new MsgTreeItem(dtRow["title"].ToString(), dtRow["atch_buseo"].ToString(), dtRow["atch_buseo_nm"].ToString(),
                                              dtRow["buseo_code"].ToString(), dtRow["user_id"].ToString(), itemType);
                    lvItem.Tag = msgItem;
                    lvItem.Text = GetItemText(msgItem);

                    lvwSrchList.Items.Add(lvItem);
                }
            }
            else
            {
                string msg = "検索内訳の生成に失敗しました。\n\n" + "エラー[" + Service.ErrFullMsg + "]";
            }

			//검색건수 SET
			this.lbCnt.Text = lvwSrchList.Items.Count.ToString();

			//컬럼 Sorter Reset
			this.lvwSrchColumnSorter.SortColumnIndex = -1;
		}

		#region 조직,사용자여부에 따른 Text Get
		private string GetItemText(MsgTreeItem item)
		{
			string text = item.Title;
			if (item.ItemType == ItemType.Buseo) //그룹은 조직명[상위조직명]
				text = item.Title + "[" + item.AtchBuseoName + "]";
			else if (item.ItemType == ItemType.User)
				text = item.Title + "[" + item.AtchBuseoName + ":" + item.UserID + "]";
			return text;
		}
		#endregion

		#region Event Handler
		private void tvwList_DoubleClick(object sender, System.EventArgs e)
		{
			//현재 선택된 Node를 수신자리스트에 Add, Tag에 저장된 MsgTreeItem도 전달
			//단 ROOT Node는 제외
			if ((tvwList.SelectedNode != null) && (tvwList.SelectedNode.Parent != null))
			{
				MsgTreeItem mItem = tvwList.SelectedNode.Tag as MsgTreeItem;
				//부서전체이면 경고창 확인후 SET
				if (mItem != null)
				{
					string text = GetItemText(mItem);
					if (mItem.ItemType == ItemType.Buseo)
					{
						string msg = (NetInfo.Language == LangMode.Ko ? text + " 부서의 모든사람이 수신자가 됩니다.\n\n" + "추가하시겠습니까?" 
							: text + " 部署の全員が受信先になります。\n" + "追加しますか。" );
						string title = (NetInfo.Language == LangMode.Ko ? "추가확인" : "追加確認");
						if (XMessageBox.Show(msg , title, MessageBoxButtons.YesNo) != DialogResult.Yes)
							return;
					}
					SetRecvListItem(text, mItem);
				}
			}
		}
		private void tvwList_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			//해당 Node의 하위노드 생성(하위Node가 있으면 다시 생성하지 않음)
			//조직일때만 하위노드 조회
			if ((e.Node.Nodes.Count < 1) && (e.Node.Tag != null) && (e.Node.Tag is MsgTreeItem))
			{
				MsgTreeItem mItem = (MsgTreeItem) e.Node.Tag;
				if (mItem.ItemType == ItemType.Buseo)
				{
					this.SetMsgTree(e.Node, mItem.Buseo, mItem.Title);	
					e.Node.Expand();
				}
			}				
		}
		#endregion

		private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//Enter Key 입력시 검색시작
			if (e.KeyChar == (char) 13)
				this.btnSearch.PerformClick();
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			string msg = "";
			if (this.txtSearch.Text.Trim() == "")
			{
				msg = (NetInfo.Language == LangMode.Ko ? "검색할 대상을 입력하십시오"
					: "検索対象を入力してください。");
				XMessageBox.Show(msg);
				this.txtSearch.Focus();
				return;
			}
            //if (this.txtSearch.Text.Trim().Length < 2)
            //{
            //    msg = (NetInfo.Language == LangMode.Ko ? "검색 대상을 2자이상 입력하십시오"
            //        : "検索対象を２文字以上入力してください。");
            //    XMessageBox.Show(msg);
            //    this.txtSearch.Focus();
            //    return;
            //}
			SetSearchListView(this.txtSearch.Text);
		}

		private void lvwSrchList_DoubleClick(object sender, System.EventArgs e)
		{
			//현재 선택된 Node를 수신자리스트에 Add, Tag에 저장된 MsgTreeItem도 전달
			if (lvwSrchList.SelectedItems.Count > 0)
			{
				MsgTreeItem mItem = lvwSrchList.SelectedItems[0].Tag as MsgTreeItem;
				//부서전체이면 경고창 확인후 SET
				if(mItem != null)
				{
					string text = GetItemText(mItem);
					if (mItem.ItemType == ItemType.Buseo)
					{
						string msg = (NetInfo.Language == LangMode.Ko ? text + " 부서의 모든사람이 수신자가 됩니다.\n\n" + "추가하시겠습니까?" 
							: text + " 部署の全員が受信先になります。\n" + "追加しますか。" );
						string title = (NetInfo.Language == LangMode.Ko ? "추가확인" : "追加確認");
						if (XMessageBox.Show(msg , title, MessageBoxButtons.YesNo) != DialogResult.Yes)
							return;
					}
					SetRecvListItem(text, mItem);
				}
			}
		}

		private void lvwBList_DoubleClick(object sender, System.EventArgs e)
		{
			//선택된 배포목록 수신자리스트에 Add, Tag에 저장된 MsgTreeItem도 전달
			if (lvwBList.SelectedItems.Count > 0)
			{
				MsgTreeItem mItem = lvwBList.SelectedItems[0].Tag as MsgTreeItem;
				if (mItem != null)
					SetRecvListItem(lvwBList.SelectedItems[0].Text, mItem);
			}
		}

		private void lvwDetList_DoubleClick(object sender, System.EventArgs e)
		{
			//선택된 상세배포내역 수신자리스트에 Add, Tag에 저장된 MsgTreeItem도 전달
			if (lvwDetList.SelectedItems.Count > 0)
			{
				MsgTreeItem mItem = lvwDetList.SelectedItems[0].Tag as MsgTreeItem;
				if (mItem != null)
				{
					string text = GetItemText(mItem);
					if (mItem.ItemType == ItemType.Buseo)
					{
						string msg = (NetInfo.Language == LangMode.Ko ? text + " 부서의 모든사람이 수신자가 됩니다.\n\n" + "추가하시겠습니까?" 
							: text + " 部署の全員が受信先になります。\n" + "追加しますか。" );
						string title = (NetInfo.Language == LangMode.Ko ? "추가확인" : "追加確認");
						if (XMessageBox.Show(msg , title, MessageBoxButtons.YesNo) != DialogResult.Yes)
							return;
					}
					SetRecvListItem(text, mItem);
				}
			}
		}

		private void lvwBList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//배포목록 설명 SET
			if (lvwBList.SelectedItems.Count > 0)
			{
				try
				{
					MsgTreeItem item = lvwBList.SelectedItems[0].Tag as MsgTreeItem;
					this.lbBPIF.Text = this.beopoDescList[item.BeopoID].ToString();
					//상세배포내역 조회
					SetDetailBeopoList(item.BeopoID);
				}
				catch
				{
					this.lbBPIF.Text = "";
				}
			}
		}

		private void btnConfirm_Click(object sender, System.EventArgs e)
		{
			//기존리스트 Clear
			this.MsgTreeItemList.Clear();

			if (this.lvwRecvList.Items.Count < 1)
			{
				string msg = (NetInfo.Language == LangMode.Ko ? "수신자를 선택하십시오"
					: "受信先を選んでください。");
				XMessageBox.Show(msg);
				return;
			}

			//수신자리스트 관리 ArrayList에 MsgTreeItem Add
			foreach (ListViewItem lvItem in lvwRecvList.Items)
				this.MsgTreeItemList.Add(lvItem.Tag);

			this.DialogResult = DialogResult.OK;
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

        //저장용 시퀀스
        public string mSEQ = "";
		private void btnBeapoSave_Click(object sender, System.EventArgs e)
		{
			string msg = "";
			//수신자리스트가 있는지 확인
			if (this.lvwRecvList.Items.Count < 1)
			{
				msg = (NetInfo.Language == LangMode.Ko ? "수신자리스트를 먼저 선택하십시오"
					: "先に受信先リストを選んでください。");
				XMessageBox.Show(msg);
				return;
			}
			//배포목록이 포함되어 있으면 배포목록을 다시 만들수 없음
			foreach (ListViewItem lvItem in this.lvwRecvList.Items)
			{
				MsgTreeItem mItem = (MsgTreeItem) lvItem.Tag;
				if (mItem.ItemType == ItemType.Beopo)
				{
					msg = (NetInfo.Language == LangMode.Ko ? "배포목록이 포함되어 있습니다.\n\n" + "배포목록을 다른 배포목록에 포함할 수 없습니다."
						: "配布リストが含まれています。\n\n" + "配布リストを他の配布リストに入れる事はできません。");
					XMessageBox.Show(msg);
					return;
				}
			}
			BeopoForm dlg = new BeopoForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				/* 배포목록Layout SET , 사용자ID + 배포설명 + 배포명 */
				this.layBeopoList.Reset();
				this.layRecverInfo.Reset();
				int rowNum = this.layBeopoList.InsertRow(-1);
				this.layBeopoList.SetItemValue(rowNum, "user_id", MainForm.CurrUserID);
				this.layBeopoList.SetItemValue(rowNum, "beopo_desc", dlg.BeopoDesc);
				this.layBeopoList.SetItemValue(rowNum, "beopo_name", dlg.BeopoName);
				
				//수신자정보생성(layRecverInfo)
				string beopoGubun, resvSpot;
				foreach (ListViewItem lvItem in this.lvwRecvList.Items)
				{
					MsgTreeItem item = (MsgTreeItem) lvItem.Tag;

					rowNum = layRecverInfo.InsertRow(-1);
					//배포구분은 부서이면 B, 사용자이면 U로 설정
					beopoGubun = (item.ItemType == ItemType.Buseo ? "B" : "U");
					//수신장소는 B이면 부서코드, U.이면 사용자 ID
					resvSpot   = (item.ItemType == ItemType.Buseo ? item.Buseo : item.UserID);
					layRecverInfo.SetItemValue(rowNum, "beopo_gubun", beopoGubun);
                    layRecverInfo.SetItemValue(rowNum, "recv_spot", resvSpot);
                    layRecverInfo.SetItemValue(rowNum, "user_id", MainForm.CurrUserID);
				}

                try
                {
                    Service.BeginTransaction();
                    mSEQ = "";

                    if (this.layBeopoList.SaveLayout())
                    {
                        string cmdText = @"DELETE ADM0750 A
                                            WHERE A.HOSP_CODE = :f_hosp_code
                                              AND A.USER_ID   = :f_user_id
                                              AND A.SEQ       = ( SELECT Z.SEQ
                                                                    FROM ADM0740       Z
                                                                   WHERE Z.HOSP_CODE   = A.HOSP_CODE
                                                                     AND Z.USER_ID     = A.USER_ID
                                                                     AND Z.BEOPO_NAME  = :f_beopo_name
                                                                )
                                          ";
                        BindVarCollection bc = new BindVarCollection();
                        bc.Add("f_hosp_code", this.mHospCode);
                        bc.Add("f_user_id", MainForm.CurrUserID);
                        bc.Add("f_beopo_name", dlg.BeopoName);

                        if (!Service.ExecuteNonQuery(cmdText, bc))
                            throw new Exception();

                        if (!this.layRecverInfo.SaveLayout())
                            throw new Exception();
                    }
                    else
                        throw new Exception();
                    Service.CommitTransaction();

                    //배포목록 다시조회
                    this.SetBeopoList();
                }
                catch
                {
                    Service.RollbackTransaction();
                    msg = (NetInfo.Language == LangMode.Ko ? "배포내역을 생성하지 못했습니다.\n\n" + "에러[" + Service.ErrFullMsg + "]"
                        : "配布リストの生成に失敗しました。\n\n" + "エラー[" + Service.ErrFullMsg + "]");
                    XMessageBox.Show(msg);
                
                }
			}
			dlg.Dispose();
		}

		private void btnDeleteBeopo_Click(object sender, System.EventArgs e)
		{
			string msg = "";
			//선택한 배포목록 삭제
			if (this.lvwBList.SelectedItems.Count < 1)
			{
				msg = (NetInfo.Language == LangMode.Ko ? "삭제할 배포목록을 선택하십시오"
					: "削除する配布リストを選んでください。");
				XMessageBox.Show(msg);
				return;
			}
			//수신리스트에 삭제할 배포목록이 포함되어 있는지 여부 확인
			MsgTreeItem bItem = (MsgTreeItem) lvwBList.SelectedItems[0].Tag;
			MsgTreeItem mItem = null;
			foreach (ListViewItem lvItem in this.lvwRecvList.Items)
			{
				mItem = (MsgTreeItem) lvItem.Tag;
				if (mItem.ItemType == ItemType.Beopo)
				{
					if (mItem.BeopoID == bItem.BeopoID)
					{
						msg = (NetInfo.Language == LangMode.Ko ? "수신자리스트에 삭제할 배포목록이 있습니다.\n\n" + "수신자리스트에서 배포목록을 제거하십시오."
							: "受信先リストに削除対象の配布リストが含まれています。\n\n" + "受信先リストから配布リストを削除してください。");
						XMessageBox.Show(msg);
						return;
					}
				}
			}
			msg = (NetInfo.Language == LangMode.Ko ? "배포목록[" + bItem.Title + "]을 삭제하시겠습니까?"
				:"配布リスト[" + bItem.Title + "]を削除しますか。");
			string title = (NetInfo.Language == LangMode.Ko ? "삭제확인" : "削除確認");

			if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
                string cmdText = "";
                BindVarCollection bc = new BindVarCollection();
                bc.Add("f_hosp_code", this.mHospCode);
                bc.Add("f_user_id", MainForm.CurrUserID);
                bc.Add("f_seq", bItem.BeopoID);


                try{
                    Service.BeginTransaction();
                    cmdText = @" DELETE ADM0740     A
                                  WHERE A.HOSP_CODE = :f_hosp_code
                                    AND A.USER_ID   = :f_user_id
                                    AND A.SEQ       = :f_seq
                               ";

                    if(!Service.ExecuteNonQuery(cmdText, bc))
                        throw new Exception();

                    cmdText = @" DELETE ADM0750     A
                                  WHERE A.HOSP_CODE = :f_hosp_code
                                    AND A.USER_ID   = :f_user_id
                                    AND A.SEQ       = :f_seq
                               ";
                    if (!Service.ExecuteNonQuery(cmdText, bc))
                        throw new Exception();

                    Service.CommitTransaction();

                    //해당 배포내역 삭제
                    this.lvwBList.Items.Remove(lvwBList.SelectedItems[0]);
                    // 배포설명, 상세배포리스트 Clear
                    this.lbBPIF.Text = "";
                    this.lvwDetList.Items.Clear();
                }
                catch
                {
                    Service.RollbackTransaction();
                    msg = (NetInfo.Language == LangMode.Ko ? "배포목록을 삭제하지 못했습니다.\n\n" + "에러[" + Service.ErrFullMsg + "]"
                        : "配布リストの削除に失敗しました。\n\n" + "エラー[" + Service.ErrFullMsg + "]");
                    XMessageBox.Show(msg);
                
                }
			}
			
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			//수신자리스트 선택여부 확인
			if (this.lvwRecvList.SelectedItems.Count < 1)
			{
				string msg = (NetInfo.Language == LangMode.Ko ? "삭제할 수신자리스트를 선택하십시오"
					:"削除する受信先リストを選んでください。");
				XMessageBox.Show(msg);
				return;
			}
			//선택된 목록 저장(바로 목록에서 삭제
			foreach (ListViewItem item in lvwRecvList.SelectedItems)
				lvwRecvList.Items.Remove(item);
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			MsgTreeItem mItem = null;
			string text = "";
			string msg = "";
			string title = "";
			if (this.tabCont.SelectedIndex == 0) //조직도
			{
				//TreeView Double Click Event 발생처리 (추가처리)
				if (tvwList.SelectedNode != null)
					this.tvwList_DoubleClick(tvwList, EventArgs.Empty);
			}
			else if (this.tabCont.SelectedIndex == 1) // 검색
			{
				//현재 선택된 Node를 수신자리스트에 Add, Tag에 저장된 MsgTreeItem도 전달
				if (lvwSrchList.SelectedItems.Count > 0)
				{
					foreach (ListViewItem lvItem in lvwSrchList.SelectedItems)
					{
						mItem = lvItem.Tag as MsgTreeItem;
						if (mItem != null)
						{
							text = GetItemText(mItem);
							if (mItem.ItemType == ItemType.Buseo)
							{
								msg = (NetInfo.Language == LangMode.Ko ? text + " 부서의 모든사람이 수신자가 됩니다.\n\n" + "추가하시겠습니까?" 
									: text + " 部署の全員が受信先になります。\n" + "追加しますか。" );
								title = (NetInfo.Language == LangMode.Ko ? "추가확인" : "追加確認");
								if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo) == DialogResult.Yes)
									SetRecvListItem(text, mItem);
							}
							else
								SetRecvListItem(text, mItem);
						}
					}
				}
			}
			else //배포목록
			{
				//배포목록 SelectedItems Check 있으면 배포목록 Double Click
				if (this.lvwBList.SelectedItems.Count > 0)
				{
					this.lvwBList_DoubleClick(lvwBList, EventArgs.Empty);
				}
				else if (this.lvwDetList.SelectedItems.Count > 0)
				{
					foreach (ListViewItem lvItem in lvwDetList.SelectedItems)
					{
						mItem = lvItem.Tag as MsgTreeItem;
						if (mItem != null)
						{
							text = GetItemText(mItem);
							if (mItem.ItemType == ItemType.Buseo)
							{
								msg = (NetInfo.Language == LangMode.Ko ? text + " 부서의 모든사람이 수신자가 됩니다.\n\n" + "추가하시겠습니까?" 
									: text + " 部署の全員が受信先になります。\n" + "追加しますか。" );
								title = (NetInfo.Language == LangMode.Ko ? "추가확인" : "追加確認");
								if (XMessageBox.Show(msg, title, MessageBoxButtons.YesNo) == DialogResult.Yes)
									SetRecvListItem(text, mItem);
							}
							else
								SetRecvListItem(text, mItem);
						}
					}
				}
			}
		}

		private void tabCont_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//배포목록창 선택시 배포목록 Selection을 Clear
			if (tabCont.SelectedIndex == 2)
			{
				lvwBList.SelectedItems.Clear();
			}
			else if (tabCont.SelectedIndex == 1)
			{
				this.txtSearch.Focus();
			}
			else
			{
				this.tvwList.Focus();
			}
		}

		private void lvwBList_Enter(object sender, System.EventArgs e)
		{
			this.lvwDetList.SelectedItems.Clear();
		}

		private void lvwDetList_Enter(object sender, System.EventArgs e)
		{
			this.lvwBList.SelectedItems.Clear();
		}

		#region 검색리스트View, 수신자 ListView Sort
		private void lvwSrchList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//열머리글 Click시에 Sort 적용 (검색수신자)
			if (e.Column == 0)
			{
				if ( e.Column == lvwSrchColumnSorter.SortColumnIndex)  //같은 Header Click
				{
					if (lvwSrchColumnSorter.OrderOfSort == SortOrder.Ascending) //ASC -> DESC
						lvwSrchColumnSorter.OrderOfSort = SortOrder.Descending;
					else
						lvwSrchColumnSorter.OrderOfSort = SortOrder.Ascending;
				}
				else
				{
					lvwSrchColumnSorter.SortColumnIndex = e.Column;
					lvwSrchColumnSorter.OrderOfSort = SortOrder.Ascending;
				}
				//Sort
				this.lvwSrchList.Sort();
			}
		}
		private void lvwRecvList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//열머리글 Click시에 Sort 적용 (검색수신자)
			if (e.Column == 0)
			{
				if ( e.Column == lvwRecvColumnSorter.SortColumnIndex)  //같은 Header Click
				{
					if (lvwRecvColumnSorter.OrderOfSort == SortOrder.Ascending) //ASC -> DESC
						lvwRecvColumnSorter.OrderOfSort = SortOrder.Descending;
					else
						lvwRecvColumnSorter.OrderOfSort = SortOrder.Ascending;
				}
				else
				{
					lvwRecvColumnSorter.SortColumnIndex = e.Column;
					lvwRecvColumnSorter.OrderOfSort = SortOrder.Ascending;
				}
				//Sort
				this.lvwRecvList.Sort();
			}
		}
		#endregion

		#region SetControlNameByLangMode (일본어 변환)
		private void SetControlNameByLangMode()
		{
			if (NetInfo.Language == LangMode.Jr)
			{
				this.Text = "受信先指定";  //수신자 지정
				//버튼
				this.btnAdd.Text = "追  加"; //추가
				this.btnClose.Text = "閉じる"; //닫기
				this.btnDelete.Text = "削  除"; //삭제
				this.btnConfirm.Text = "確  認"; //확인
				this.btnBeapoSave.Text = "リスト保存"; //배포저장
				this.btnDeleteBeopo.Text = "リスト削除"; //목록삭제
				this.btnSearch.Text = "検索"; //찾기
				
				//ColumnHeader
				this.columnHeader1.Text = "検索受信先";
				this.columnHeader2.Text = "詳細リスト";
                this.columnHeader6.Text = "受信先リスト";

				//Tab
				this.tabPage2.Text = "検 索";
				this.tabPage1.Text = "組織図";
				this.tabPage3.Text = "配布リスト";
				
				//기타
                // <<2013.12.08>> LKH
				tvwList.Nodes[0].Text = "九十九里病院"; 
				this.lbSearchDesc.Text = "検索数";
				this.lbSearchText.Text = "検索語";
				this.gbxBeopo.Text = "リスト";
			}
		}
		#endregion


        public class XSavePerformer : ISavePerformer
        {
            MsgTreeForm parent;

            public XSavePerformer(MsgTreeForm parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("f_user_id", MainForm.CurrUserID);

                switch (callerID)
                {
                    case '1':

                        cmdText = @"SELECT A.SEQ
                                      FROM ADM0740       A
                                     WHERE A.HOSP_CODE   = :f_hosp_code
                                       AND A.USER_ID     = :f_user_id
                                       AND A.BEOPO_NAME  = :f_beopo_name 
                                   ";

                        object retVal= Service.ExecuteScalar(cmdText, item.BindVarList);

                        if (!TypeCheck.IsNull(retVal))
                        {
                            parent.mSEQ = retVal.ToString();
                            cmdText = @"UPDATE ADM0740      A
                                           SET A.BEOPO_DESC = :f_beopo_desc
                                         WHERE A.HOSP_CODE  = :f_hosp_code
                                           AND A.USER_ID    = :f_user_id
                                           AND A.BEOPO_NAME = :f_beopo_name
                                       ";
                        }
                        else
                        {
                            /* 해당사용자의 배포목록(ADM0740) 순번 생성 MAX + 1 */
                            cmdText = @"SELECT NVL(MAX(A.SEQ),0) + 1 
                                          FROM ADM0740     A
                                         WHERE A.HOSP_CODE = :f_hosp_code 
                                           AND A.USER_ID   = :f_user_id
                                       ";

                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                            item.BindVarList.Add("t_seq", retVal.ToString());
                            parent.mSEQ = retVal.ToString();

                            cmdText = @"INSERT INTO ADM0740 (
                                                              HOSP_CODE      , USER_ID        , SEQ    
                                                            , BEOPO_NAME     , BEOPO_DESC
                                                            , CR_MEMB        , CR_TIME        , CR_TRM
                                                   ) VALUES (
                                                              :f_hosp_code   , :f_user_id     , :t_seq  
                                                            , :f_beopo_name  , :f_beopo_desc
                                                            , :f_user_id     , SYSDATE        , :q_user_trm
                                                   )
                                       ";
                        }


                        break;


                    case '2':

                        item.BindVarList.Add("t_seq", parent.mSEQ);

                        cmdText = @"INSERT INTO ADM0750 (
                                                           HOSP_CODE        , USER_ID          , SEQ
                                                         , BEOPO_GUBUN      , RECV_SPOT    
                                                         , CR_MEMB          , CR_TIME          , CR_TRM   
                                               ) VALUES (
                                                           :f_hosp_code     , :f_user_id       , :t_seq
                                                         , :f_beopo_gubun   , :f_recv_spot  
                                                         , :f_user_id       , SYSDATE          , :q_user_trm 
                                               )
                                   ";

                        break;


                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }

        }

        private void laySearchTree_QueryStarting(object sender, CancelEventArgs e)
        {
            this.laySearchTree.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layBeopoList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layBeopoList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layTreeList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layTreeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layBeopoListDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layBeopoListDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
	}

	#region ItemType Enum
	internal enum ItemType
	{
		Root,  //Root Node
		Buseo, //부서(사용자ID가 없는 Node)
		User,  //사용자(사용자ID가 있는 Node)
		Beopo  //배포목록에서 가져온 Item (배포목록을 바로 수신에 적용시에 처리)

	}
	internal class MsgTreeItem
	{
		private string title = "";  //부서명,배포그룹명,사용자명
		private string buseo = "";  //부서명 (선택된 Item이 부서일때 부서코드)
		private string atchBuseo = ""; //소속부서명(선택된 Item이 부서일때는 부모부서코드, 사용자이면 소속부서)
		private string atchBuseoName = ""; //소속부서명
		private string userID = "";  //사용자 ID
		private string beopoID = ""; //선택된 Item이 배포그룹일때 배포그룹의 ID
		private ItemType itemType = ItemType.Root;  //Node의 Type
		public string Title
		{
			get { return title;}
		}
		public string Buseo
		{
			get { return buseo;}
		}
		public string AtchBuseo
		{
			get { return atchBuseo;}
			set { atchBuseo = value;}
		}
		public string AtchBuseoName
		{
			get { return atchBuseoName;}
			set { atchBuseoName = value;}
		}
		public string UserID
		{
			get { return userID;}
		}
		public string BeopoID
		{
			get { return beopoID;}
			set { beopoID = value;}
		}
		public ItemType ItemType
		{
			get { return itemType;}
		}
		public MsgTreeItem()
		{
		}
		public MsgTreeItem(string title, string atchBuseo, string atchBuseoName, string buseo, string userID, ItemType itemType)
		{
			this.title = title;
			this.buseo = buseo;
			this.atchBuseo = atchBuseo;
			this.atchBuseoName = atchBuseoName;
			this.userID = userID;
			this.itemType = itemType;
		}
		public MsgTreeItem(string title, string beopoID)  //배포목록 그릅ID로 설정
		{
			this.title = title; //
			this.beopoID = beopoID;
			this.itemType = ItemType.Beopo;
		}
	}
	#endregion

	#region ListViewColumnSorter
	internal class ListViewColumnSorter : IComparer
	{
		private int sortColumnIndex = -1;
		private SortOrder orderOfSort = SortOrder.None;
		public int SortColumnIndex
		{
			get { return sortColumnIndex;}
			set { sortColumnIndex = value;}
		}
		public SortOrder OrderOfSort
		{
			get { return orderOfSort;}
			set { orderOfSort = value;}
		}
		public ListViewColumnSorter()
		{
		}

		public int Compare(object x, object y)
		{
			if (orderOfSort == SortOrder.None) return 0;

			ListViewItem listviewX, listviewY;
			listviewX = (ListViewItem)x;
			listviewY = (ListViewItem)y;

			int result = 0;
			string compX = listviewX.SubItems[sortColumnIndex].Text;
			string compY = listviewY.SubItems[sortColumnIndex].Text;
			result = compX.CompareTo(compY);
			if (orderOfSort == SortOrder.Descending)
				result = -result;
			return result;

		}
	}
	#endregion


}

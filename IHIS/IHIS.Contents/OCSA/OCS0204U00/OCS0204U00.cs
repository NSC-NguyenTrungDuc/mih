#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0204U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0204U00 : IHIS.Framework.XScreen
	{
		bool isgrdOCS0204Save = false;
		bool isgrdOCS0205Save = false;

		bool isSavedOCS0204 = false;
		bool isSavedOCS0205 = false;

		#region [Instance Variable]
		//사용자
		private string mMemb = ""; 
		//Message처리
		string mbxMsg = "", mbxCap = "";		

		private DataTable mLayDtBuffer       = null; // 상병 Copy & Paste용 Buffer DataTable		

        string mHospCode = EnvironInfo.HospCode;

        private IHIS.OCS.OrderBiz mOrderBiz;

		#endregion

		private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XFindBox fbxmemb;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XMstGrid grdOCS0204;
		private IHIS.Framework.XEditGrid grdOCS0205;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XButton btnSangGubunDown;
		private IHIS.Framework.XButton btnSangGubunUp;
		private IHIS.Framework.XButton btnSangDown;
		private IHIS.Framework.XButton btnSangUp;
		private IHIS.Framework.XPictureBox pbxCopy;
		private IHIS.Framework.XButton btnPaste;
		private IHIS.Framework.XButton btnCopy;
        private XDictComboBox cboGwa;
        private XLabel xLabel1;
        private XDisplayBox dbxMembName;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

	    private List<ComboListItemInfo> gwaComboItemList;

		public OCS0204U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			SaveLayoutList.Add(grdOCS0204);
			SaveLayoutList.Add(grdOCS0205);

			/*grdOCS0204.SavePerformer = new XSavePerformer(this);
			grdOCS0205.SavePerformer = grdOCS0204.SavePerformer;*/

		    grdOCS0204.ParamList = CreateGrdOCS0204U00ParamList();
		    grdOCS0204.ExecuteQuery = LoadGrdOCS0204U00;

            grdOCS0205.ParamList = CreateGrdOCS0205U00ParamList();
            grdOCS0205.ExecuteQuery = LoadGrdOCS0205U00;
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

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0204U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxMembName = new IHIS.Framework.XDisplayBox();
            this.cboGwa = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.fbxmemb = new IHIS.Framework.XFindBox();
            this.grdOCS0204 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0205 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.pbxCopy = new IHIS.Framework.XPictureBox();
            this.btnPaste = new IHIS.Framework.XButton();
            this.btnCopy = new IHIS.Framework.XButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnSangGubunDown = new IHIS.Framework.XButton();
            this.btnSangGubunUp = new IHIS.Framework.XButton();
            this.btnSangDown = new IHIS.Framework.XButton();
            this.btnSangUp = new IHIS.Framework.XButton();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0204)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0205)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopy)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.dbxMembName);
            this.xPanel1.Controls.Add(this.cboGwa);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.fbxmemb);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // dbxMembName
            // 
            this.dbxMembName.AccessibleDescription = null;
            this.dbxMembName.AccessibleName = null;
            resources.ApplyResources(this.dbxMembName, "dbxMembName");
            this.dbxMembName.Image = null;
            this.dbxMembName.Name = "dbxMembName";
            // 
            // cboGwa
            // 
            this.cboGwa.AccessibleDescription = null;
            this.cboGwa.AccessibleName = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.BackgroundImage = null;
            this.cboGwa.ExecuteQuery = null;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGwa.ParamList")));
            this.cboGwa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // fbxmemb
            // 
            this.fbxmemb.AccessibleDescription = null;
            this.fbxmemb.AccessibleName = null;
            resources.ApplyResources(this.fbxmemb, "fbxmemb");
            this.fbxmemb.BackgroundImage = null;
            this.fbxmemb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxmemb.Name = "fbxmemb";
            this.fbxmemb.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxMemb_DataValidating);
            this.fbxmemb.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxMemb_FindClick);
            // 
            // grdOCS0204
            // 
            resources.ApplyResources(this.grdOCS0204, "grdOCS0204");
            this.grdOCS0204.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdOCS0204.ColPerLine = 2;
            this.grdOCS0204.Cols = 3;
            this.grdOCS0204.ExecuteQuery = null;
            this.grdOCS0204.FixedCols = 1;
            this.grdOCS0204.FixedRows = 1;
            this.grdOCS0204.FocusColumnName = "sang_gubun";
            this.grdOCS0204.HeaderHeights.Add(23);
            this.grdOCS0204.Name = "grdOCS0204";
            this.grdOCS0204.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0204.ParamList")));
            this.grdOCS0204.QuerySQL = resources.GetString("grdOCS0204.QuerySQL");
            this.grdOCS0204.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0204.RowHeaderVisible = true;
            this.grdOCS0204.Rows = 2;
            this.grdOCS0204.ToolTipActive = true;
            this.grdOCS0204.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOCS0204_GiveFeedback);
            this.grdOCS0204.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdOCS0204_MouseUp);
            this.grdOCS0204.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0204_PreSaveLayout);
            this.grdOCS0204.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0204_GridColumnChanged);
            this.grdOCS0204.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOCS0204_DragEnter);
            this.grdOCS0204.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0204_MouseDown);
            this.grdOCS0204.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOCS0204_DragDrop);
            this.grdOCS0204.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grdOCS0204_MouseMove);
            this.grdOCS0204.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdOCS0204.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0204_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "memb";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "seq";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 7;
            this.xEditGridCell3.CellName = "sang_gubun";
            this.xEditGridCell3.CellWidth = 124;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 80;
            this.xEditGridCell4.CellName = "sang_gubun_name";
            this.xEditGridCell4.CellWidth = 206;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            // 
            // grdOCS0205
            // 
            resources.ApplyResources(this.grdOCS0205, "grdOCS0205");
            this.grdOCS0205.ApplyPaintEventToAllColumn = true;
            this.grdOCS0205.CallerID = '2';
            this.grdOCS0205.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell10,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell8,
            this.xEditGridCell11,
            this.xEditGridCell7,
            this.xEditGridCell9,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35});
            this.grdOCS0205.ColPerLine = 4;
            this.grdOCS0205.Cols = 5;
            this.grdOCS0205.EnableMultiSelection = true;
            this.grdOCS0205.ExecuteQuery = null;
            this.grdOCS0205.FixedCols = 1;
            this.grdOCS0205.FixedRows = 1;
            this.grdOCS0205.FocusColumnName = "sang_code";
            this.grdOCS0205.HeaderHeights.Add(23);
            this.grdOCS0205.MasterLayout = this.grdOCS0204;
            this.grdOCS0205.Name = "grdOCS0205";
            this.grdOCS0205.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0205.ParamList")));
            this.grdOCS0205.QuerySQL = resources.GetString("grdOCS0205.QuerySQL");
            this.grdOCS0205.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0205.RowHeaderVisible = true;
            this.grdOCS0205.Rows = 2;
            this.grdOCS0205.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0205.SelectionModeChangeable = true;
            this.grdOCS0205.TogglingRowSelection = true;
            this.grdOCS0205.ToolTipActive = true;
            this.grdOCS0205.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOCS0205_GiveFeedback);
            this.grdOCS0205.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdOCS0205_MouseUp);
            this.grdOCS0205.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0205_PreSaveLayout);
            this.grdOCS0205.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdOCS0205_GridButtonClick);
            this.grdOCS0205.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0205_GridColumnChanged);
            this.grdOCS0205.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOCS0205_DragEnter);
            this.grdOCS0205.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0205_MouseDown);
            this.grdOCS0205.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOCS0205_DragDrop);
            this.grdOCS0205.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grdOCS0205_MouseMove);
            this.grdOCS0205.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS0205_GridFindClick);
            this.grdOCS0205.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdOCS0205.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0205_GridCellPainting);
            this.grdOCS0205.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS0205_GridColumnProtectModify);
            this.grdOCS0205.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0205_QueryStarting);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "pk_seq";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "memb";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsNotNull = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 7;
            this.xEditGridCell6.CellName = "sang_gubun";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsNotNull = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 7;
            this.xEditGridCell8.CellName = "sang_code";
            this.xEditGridCell8.CellWidth = 131;
            this.xEditGridCell8.Col = 1;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.ImeMode = IHIS.Framework.ColumnImeMode.Katakana;
            this.xEditGridCell8.IsNotNull = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.ToolTipText = global::IHIS.OCSA.Properties.Resource.ToolTipText1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.CellLen = 200;
            this.xEditGridCell11.CellName = "dis_sang_name";
            this.xEditGridCell11.CellWidth = 325;
            this.xEditGridCell11.Col = 3;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.ToolTipText = global::IHIS.OCSA.Properties.Resource.ToolTipText1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "ser";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 200;
            this.xEditGridCell9.CellName = "sang_name";
            this.xEditGridCell9.CellWidth = 475;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "pre_modifier1";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "pre_modifier2";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "pre_modifier3";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "pre_modifier4";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "pre_modifier5";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "pre_modifier6";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "pre_modifier7";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "pre_modifier8";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "pre_modifier9";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "pre_modifier10";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellLen = 500;
            this.xEditGridCell22.CellName = "pre_modifier_name";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "post_modifier1";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "post_modifier2";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "post_modifier3";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "post_modifier4";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "post_modifier5";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "post_modifier6";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "post_modifier7";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "post_modifier8";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "post_modifier9";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "post_modifier10";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellLen = 500;
            this.xEditGridCell33.CellName = "post_modifier_name";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell34.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell34.ButtonImage")));
            this.xEditGridCell34.CellName = "susik_button";
            this.xEditGridCell34.CellWidth = 70;
            this.xEditGridCell34.Col = 2;
            this.xEditGridCell34.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.ToolTipText = global::IHIS.OCSA.Properties.Resource.ToolTipText1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell35.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell35.ApplyPaintingEvent = true;
            this.xEditGridCell35.CellName = "doubt";
            this.xEditGridCell35.CellWidth = 58;
            this.xEditGridCell35.Col = 4;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsUpdCol = false;
            this.xEditGridCell35.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell35.ToolTipText = global::IHIS.OCSA.Properties.Resource.ToolTipText1;
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel2.Controls.Add(this.pbxCopy);
            this.xPanel2.Controls.Add(this.btnPaste);
            this.xPanel2.Controls.Add(this.btnCopy);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // pbxCopy
            // 
            this.pbxCopy.AccessibleDescription = null;
            this.pbxCopy.AccessibleName = null;
            resources.ApplyResources(this.pbxCopy, "pbxCopy");
            this.pbxCopy.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.pbxCopy.BackgroundImage = null;
            this.pbxCopy.Font = null;
            this.pbxCopy.ImageLocation = null;
            this.pbxCopy.Name = "pbxCopy";
            this.pbxCopy.Protect = false;
            this.pbxCopy.TabStop = false;
            this.pbxCopy.Click += new System.EventHandler(this.pbxCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.AccessibleDescription = null;
            this.btnPaste.AccessibleName = null;
            resources.ApplyResources(this.btnPaste, "btnPaste");
            this.btnPaste.BackgroundImage = null;
            this.btnPaste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.AccessibleDescription = null;
            this.btnCopy.AccessibleName = null;
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.BackgroundImage = null;
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnSangGubunDown);
            this.xPanel3.Controls.Add(this.btnSangGubunUp);
            this.xPanel3.Controls.Add(this.grdOCS0204);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnSangGubunDown
            // 
            this.btnSangGubunDown.AccessibleDescription = null;
            this.btnSangGubunDown.AccessibleName = null;
            resources.ApplyResources(this.btnSangGubunDown, "btnSangGubunDown");
            this.btnSangGubunDown.BackgroundImage = null;
            this.btnSangGubunDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSangGubunDown.Image = ((System.Drawing.Image)(resources.GetObject("btnSangGubunDown.Image")));
            this.btnSangGubunDown.Name = "btnSangGubunDown";
            this.btnSangGubunDown.Click += new System.EventHandler(this.btnSangGubunDown_Click);
            // 
            // btnSangGubunUp
            // 
            this.btnSangGubunUp.AccessibleDescription = null;
            this.btnSangGubunUp.AccessibleName = null;
            resources.ApplyResources(this.btnSangGubunUp, "btnSangGubunUp");
            this.btnSangGubunUp.BackgroundImage = null;
            this.btnSangGubunUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSangGubunUp.Image = ((System.Drawing.Image)(resources.GetObject("btnSangGubunUp.Image")));
            this.btnSangGubunUp.Name = "btnSangGubunUp";
            this.btnSangGubunUp.Click += new System.EventHandler(this.btnSangGubunUp_Click);
            // 
            // btnSangDown
            // 
            this.btnSangDown.AccessibleDescription = null;
            this.btnSangDown.AccessibleName = null;
            resources.ApplyResources(this.btnSangDown, "btnSangDown");
            this.btnSangDown.BackgroundImage = null;
            this.btnSangDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSangDown.Image = ((System.Drawing.Image)(resources.GetObject("btnSangDown.Image")));
            this.btnSangDown.Name = "btnSangDown";
            this.btnSangDown.Click += new System.EventHandler(this.btnSangDown_Click);
            // 
            // btnSangUp
            // 
            this.btnSangUp.AccessibleDescription = null;
            this.btnSangUp.AccessibleName = null;
            resources.ApplyResources(this.btnSangUp, "btnSangUp");
            this.btnSangUp.BackgroundImage = null;
            this.btnSangUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSangUp.Image = ((System.Drawing.Image)(resources.GetObject("btnSangUp.Image")));
            this.btnSangUp.Name = "btnSangUp";
            this.btnSangUp.Click += new System.EventHandler(this.btnSangUp_Click);
            // 
            // OCS0204U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnSangDown);
            this.Controls.Add(this.btnSangUp);
            this.Controls.Add(this.grdOCS0205);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0204U00";
            this.UserChanged += new System.EventHandler(this.OCS0204U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0204U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0204)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0205)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopy)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		#region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
		public override object Command(string command, CommonItemCollection commandParam)
		{	
			string dis_sang_name;

			switch(command.Trim())
			{
				case "CHT0115Q00": // 수식어정보
					if (commandParam.Contains("CHT0115") && (MultiLayout)commandParam["CHT0115"] != null && 
						((MultiLayout)commandParam["CHT0115"]).RowCount > 0)
					{
						if (this.grdOCS0205.CurrentRowNumber >= 0)
						{
							this.grdOCS0205.Focus();
							this.grdOCS0205.SetFocusToItem(this.grdOCS0205.CurrentRowNumber, "sang_code");
							
							foreach(XEditGridCell cell in grdOCS0205.CellInfos)
							{
								if(((MultiLayout)commandParam["CHT0115"]).LayoutItems.Contains(cell.CellName))
									grdOCS0205.SetItemValue( grdOCS0205.CurrentRowNumber, cell.CellName, ((MultiLayout)commandParam["CHT0115"]).GetItemString(0, cell.CellName));
							}

							//display 상병명
							dis_sang_name = grdOCS0205.GetItemString(grdOCS0205.CurrentRowNumber, "pre_modifier_name") 
								+ grdOCS0205.GetItemString(grdOCS0205.CurrentRowNumber, "sang_name") 
								+ grdOCS0205.GetItemString(grdOCS0205.CurrentRowNumber, "post_modifier_name");
							grdOCS0205.SetItemValue(grdOCS0205.CurrentRowNumber, "dis_sang_name", dis_sang_name);

							grdOCS0205.Refresh();
						}
					}
					break;

				case "CHT0110Q01": // 상병조회
					if (commandParam.Contains("CHT0110") && (MultiLayout)commandParam["CHT0110"] != null && 
						((MultiLayout)commandParam["CHT0110"]).RowCount > 0)
					{
						int insertRow;
						int currentRow = this.grdOCS0205.CurrentRowNumber;
						this.grdOCS0205.Focus();
                        string memb = "";
                        string sang_gubun = "";

                        memb = grdOCS0205.GetItemString(currentRow, "memb");
                        sang_gubun = grdOCS0205.GetItemString(currentRow, "sang_gubun");

						foreach(DataRow row in ((MultiLayout)commandParam["CHT0110"]).LayoutTable.Rows)
						{
							if(CheckDoubleSang_code(row["sang_code"].ToString())) continue;

							if (currentRow >= 0)
							{
                                this.grdOCS0205.SetItemValue(currentRow, "memb", memb);
                                this.grdOCS0205.SetItemValue(currentRow, "sang_gubun", sang_gubun);
								this.grdOCS0205.SetItemValue(currentRow, "sang_code", row["sang_code"]);
								this.grdOCS0205.SetItemValue(currentRow, "sang_name", row["sang_name"]);                                
								dis_sang_name = grdOCS0205.GetItemString(grdOCS0205.CurrentRowNumber, "pre_modifier_name") 
									+ grdOCS0205.GetItemString(grdOCS0205.CurrentRowNumber, "sang_name") 
									+ grdOCS0205.GetItemString(grdOCS0205.CurrentRowNumber, "post_modifier_name");
								grdOCS0205.SetItemValue(grdOCS0205.CurrentRowNumber, "dis_sang_name", dis_sang_name);
                            
								grdOCS0205.Refresh();
								currentRow = -1;								
							}
							else
							{
								insertRow = this.grdOCS0205.InsertRow(this.grdOCS0205.CurrentRowNumber);
                                this.grdOCS0205.SetItemValue(insertRow, "memb", memb);
                                this.grdOCS0205.SetItemValue(insertRow, "sang_gubun", sang_gubun);
								this.grdOCS0205.SetItemValue(insertRow, "sang_code"    , row["sang_code"]);
								this.grdOCS0205.SetItemValue(insertRow, "sang_name"    , row["sang_name"]);
								this.grdOCS0205.SetItemValue(insertRow, "dis_sang_name", row["sang_name"]);
							}
						}

						this.grdOCS0205.AcceptData();
					}

					break;					
			}

			return base.Command (command, commandParam);
		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
		}

        private void OCS0204U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            this.mOrderBiz = new IHIS.OCS.OrderBiz(this.Name);
            /// 사용자 변경 Event Call ///////////////////////////////////////
            //this.OCS0204U00_UserChanged(this, new System.EventArgs());
            ///////////////////////////////////////////////////////////////////

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

		private void PostLoad()
		{
            
			
			//Set Current Grid
			this.CurrMSLayout = this.grdOCS0204;
			this.CurrMQLayout = this.grdOCS0204;

			//Set M/D Relation
			grdOCS0205.SetRelationKey("memb", "memb");
			grdOCS0205.SetRelationKey("sang_gubun", "sang_gubun");

            this.OCS0204U00_UserChanged(this, new System.EventArgs());
		}

		private void OCS0204U00_UserChanged(object sender, System.EventArgs e)
		{
            this.Reset();
            
            //grdOCS0204.SetBindVarValue("f_memb", mMemb);
            //grdOCS0204.SetBindVarValue("f_sang_gubun", "");
            //grdOCS0204.QueryLayout(false);

            if (UserInfo.UserGubun == UserType.Doctor)
            {
                this.fbxmemb.SetEditValue(UserInfo.UserID);
                this.fbxmemb.AcceptData();

                this.cboGwa.SetEditValue(UserInfo.Gwa);
            }
            else
            {
                if (UserInfo.UserGroup != "ADMIN" &&
                    UserInfo.UserGroup != "OCSA")
                {
                    MessageBox.Show(XMsg.GetMsg("M001"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
		}
		#endregion

		#region [Load Code Name]
		/// <summary>
		/// 해당 코드에 대한 명을 가져옵니다.
		/// </summary>
		/// <param name="codeMode">코드구분</param>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCodeName(string codeMode, string code)
		{
			string codeName = "";
			string cmdText = "";
			IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
			object retVal = null;

			if(code.Trim() == "" ) return codeName;

			switch (codeMode)
			{
				case "sang_gubun":
					/*cmdText = "SELECT A.SANG_GUBUN_NAME "   
						    + "  FROM OCS0204 A "
						    + " WHERE A.HOSP_CODE = '" + mHospCode + "' "
                            + "   AND A.MEMB = :f_memb "
                            + "   AND A.MEMB_GUBUN = '1' "
						    + "   AND A.SANG_GUBUN = :f_code ";

					bindVars.Clear();
					bindVars.Add("f_memb",mMemb);
					bindVars.Add("f_code",code);

					retVal = Service.ExecuteScalar(cmdText,bindVars);
                    
					if(retVal == null)
						codeName = "";
					else
						codeName = retVal.ToString();*/

                    // cloud service
                    OcsaOCS0204U00SangGubunNameArgs ocsArgs = new OcsaOCS0204U00SangGubunNameArgs();
                    ocsArgs.Memb = mMemb;
                    ocsArgs.Code = code;
                    OcsaOCS0204U00SangGubunNameResult ocsResult =
                        CloudService.Instance
                            .Submit<OcsaOCS0204U00SangGubunNameResult, OcsaOCS0204U00SangGubunNameArgs>(ocsArgs);
			        if (ocsResult.ExecutionStatus == ExecutionStatus.Success && ocsResult.SangGubunName != null)
			        {
			            codeName = ocsResult.SangGubunName;
			        }
					break;
				case "sang_code":
					/*cmdText = "SELECT A.SANG_NAME "   
						    + "  FROM CHT0110 A " 
						    + " WHERE A.HOSP_CODE = '" + mHospCode + "' "
                            + "   AND A.SANG_CODE = :f_code ";

					bindVars.Clear();
					bindVars.Add("f_code",code);

					retVal = Service.ExecuteScalar(cmdText,bindVars);

					if(retVal == null)
						codeName = "";						
					else
						codeName = retVal.ToString();*/

                    // cloud service
                    OcsaOCS0204U00SangNameArgs args = new OcsaOCS0204U00SangNameArgs();
                    args.Code = code;
                    OcsaOCS0204U00SangNameResult result =
                        CloudService.Instance
                            .Submit<OcsaOCS0204U00SangNameResult, OcsaOCS0204U00SangNameArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.SangName != null)
                    {
                        codeName = result.SangName;
                    }
					break;
				default:
					break;
			}

			return codeName;
		}
		#endregion

		#region [GetFindWorker]
		private XFindWorker GetFindWorker(string findMode)
		{
			XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();
			
			switch (findMode)
			{	
                case "memb":

                    fdwCommon.AutoQuery = true;
                    fdwCommon.ServerFilter = false;

                    /*fdwCommon.InputSQL = " SELECT A.USER_ID, B.USER_NM, 3 "
                                         + " FROM ADM3200 A, ADM3211 B "
                                         + " WHERE A.HOSP_CODE = '" + mHospCode + "' "
                                         + "   AND A.USER_ID = B.USER_ID "
                                         + "   AND B.START_DATE = ( SELECT MAX(X.START_DATE) "
                                         + "                    FROM ADM3211 X "
                                         + "                   WHERE X.HOSP_CODE = '" + mHospCode + "' "
                                         + "                     AND B.HOSP_CODE = X.HOSP_CODE "
                                         + "                     AND X.USER_ID = B.USER_ID "
                                         + "                     AND X.START_DATE <= TRUNC(SYSDATE) ) "
                                         + "  AND B.USER_NM LIKE :f_find1 || '%' "
                                         + " ORDER BY 3, 1";*/
			        fdwCommon.ParamList = CreateFdwCommonParamList();
			        fdwCommon.ExecuteQuery = LoadFdwCommon;
                    fdwCommon.FormText = Resource.fdwCommonText1;
                    fdwCommon.ColInfos.Add("memb", Resource.fdwCommonColInfosHeader1, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add("memb_name", Resource.fdwCommonColInfosHeader2, FindColType.String, 300, 0, true, FilterType.Yes);

                    break;

				case "sang_gubun":
                    // not use

					/*fdwCommon.AutoQuery = true;	
					fdwCommon.ServerFilter = false;
					fdwCommon.InputSQL = "SELECT A.SANG_GUBUN, A.SANG_GUBUN_NAME "   
						+ "  FROM MEMB A "
						+ " WHERE A.SANG_GUBUN = '" + mMemb + "' "
						+ " ORDER BY A.SEQ ";

					fdwCommon.FormText = Resource.fdwCommonText2;
					fdwCommon.ColInfos.Add("sang_gubun", Resource.fdwCommonColInfosHeader3, FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("sang_gubun_name", Resource.fdwCommonColInfosHeader4, FindColType.String, 300, 0, true, FilterType.Yes);*/
					break;

				case "sang_code":
                    // not use

					/*fdwCommon.AutoQuery = true;
					fdwCommon.ServerFilter = false;
					fdwCommon.InputSQL = "SELECT A.SANG_CODE, A.SANG_NAME "   
						+ "  FROM CHT0110 A "
                        + " WHERE A.HOSP_CODE = '" + mHospCode + "' "
                        + " ORDER BY 1, 2";

					fdwCommon.FormText = Resource.fdwCommonText3;
					fdwCommon.ColInfos.Add("sang_code", Resource.fdwCommonColInfosHeader5, FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("sang_name", Resource.fdwCommonColInfosHeader6, FindColType.String, 300, 0, true, FilterType.No);*/
					break;
				default:
					break;
			}

			return fdwCommon;
		}
		#endregion

        #region [ 전부 초기화 ]

        private void InitializeAll()
        {
            this.mMemb = "";

            this.cboGwa.ComboItems.Clear();
        }

        #endregion

        #region [Control Event]
        private void fbxMemb_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            string name = "";
            if (e.DataValue == "")
            {
                this.dbxMembName.SetDataValue("");
                this.SetMsg("");

                InitializeAll();
                return;
            }
            // cloud service
            OcsaOCS0204U00GwaResult result = GetGwaDataList(e.DataValue);
            gwaComboItemList = result.ComboList;
            // 사용자 체크 
            /*this.mOrderBiz.LoadColumnCodeName("user_id", e.DataValue, ref name);*/
            name = result.ColumnCodeName;

            if (name == "")
            {
                this.dbxMembName.SetDataValue("");
                // 사용자정보가 정확하지 않습니다.
                MessageBox.Show(XMsg.GetMsg("M001"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.SetMsg(XMsg.GetMsg("M001"), MsgType.Error);
                e.Cancel = true;
                InitializeAll();
                return;
            }

            this.dbxMembName.SetDataValue(name);

            this.MakeGwaCombo(e.DataValue);
		}

		private void fbxMemb_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			fbxmemb.FindWorker = GetFindWorker("memb");
		}
		#endregion

        #region [ 사용자별 진료과 ]

        private void MakeGwaCombo(string aMemb)
        {
            this.cboGwa.SelectedValueChanged -= new EventHandler(cboGwa_SelectedValueChanged);
            /*this.cboGwa.UserSQL = " SELECT A.DOCTOR_GWA, B.GWA_NAME "
                                + "   FROM BAS0272 A "
                                + "      , BAS0260 B "
                                + "  WHERE A.HOSP_CODE = '" + mHospCode + "' "
                                + "    AND A.SABUN = '" + aMemb + "' "
                                + "    AND B.HOSP_CODE = A.HOSP_CODE "
                                + "    AND A.DOCTOR_GWA = B.GWA "
                                + "    AND TRUNC(SYSDATE) BETWEEN B.START_DATE AND NVL(B.END_DATE, TO_DATE('99981231', 'YYYYMMDD')) "
                                + "  ORDER BY DECODE(NVL(A.MAIN_GWA_YN, 'N'), 'Y', '0', '9') || A.DOCTOR_GWA ";*/
            this.cboGwa.ExecuteQuery = LoadGwaCombo;
            this.cboGwa.SetDictDDLB();
            this.cboGwa.SelectedValueChanged += new EventHandler(cboGwa_SelectedValueChanged);
        }

        void cboGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            this.mMemb = this.cboGwa.GetDataValue() + this.fbxmemb.GetDataValue();

            btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        #region [grdOCS0204 Event]
        private void grdOCS0204_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			e.Cancel = false;

			switch (e.ColName)
			{
				case "sang_gubun":
                    
					if(e.ChangeValue.ToString().Trim() == "" ) break;
                    
					// 중복 Check
					// 현재 화면
					for(int i = 0; i < grdOCS0204.RowCount; i++)
					{
						if(i != e.RowNumber)
						{
							if( grdOCS0204.GetItemString(i, "sang_gubun").Trim() == e.ChangeValue.ToString().Trim() )
							{
								mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.XMessageBox1_Jp : Resource.XMessageBox1_Ko;
								mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
								XMessageBox.Show(mbxMsg, mbxCap);
								e.Cancel= true;								
							}
						}
					} 

					if(e.Cancel) break;

					// Delete Table Check
					// 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
					bool deleted = false;
					if(grdOCS0204.DeletedRowTable != null)
					{
						foreach(DataRow row in grdOCS0204.DeletedRowTable.Rows)
						{
							if(row[e.ColName].ToString() == e.ChangeValue.ToString())
							{
								deleted = true;
								break;
							}
						}
					}

					if(deleted) break;
                    
					//Check Origin Data
					string sang_gubun_name = this.GetCodeName(e.ColName, e.ChangeValue.ToString());

					if(sang_gubun_name != "")
					{
                        mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.XMessageBox1_Jp : Resource.XMessageBox1_Ko;
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);
						e.Cancel= true;								
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region [grdOCS0205 Event]
		private void grdOCS0205_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			switch (e.ColName)
			{				
				case "susik_button":
					ShowSusik(e.RowNumber);
					break;
				default:
					break;
			}
		}

		private void grdOCS0205_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if(e.ColName == "doubt")
			{
				if(e.DataRow["sang_code"].ToString().Trim() == "0000999")
				{
					e.Image = ImageList.Images[2];
					return;
				}

				if(CheckDoubt(grdOCS0205, e.RowNumber))
					e.Image = this.ImageList.Images[1];
				else
					e.Image = this.ImageList.Images[0];
			}
		}

		private void grdOCS0205_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			e.Cancel = false;

			switch (e.ColName)
			{
				case "sang_code":
					string pre_modifier_name  = e.DataRow["pre_modifier_name" ].ToString();
					string post_modifier_name = e.DataRow["post_modifier_name"].ToString();
                    
					grdOCS0205.SetItemValue(e.RowNumber, "sang_name", "");
                    grdOCS0205.AcceptData();
                    grdOCS0205.Update();

					if(e.ChangeValue.ToString().Trim() == "0000999" )
					{
						//display상병명을 상병명으로 가져간다.
						ClearSangName(grdOCS0205, e.RowNumber);	
						grdOCS0205.SetItemValue(e.RowNumber, "sang_name", e.DataRow["dis_sang_name"]);	
						break;
					}

					grdOCS0205.SetItemValue(e.RowNumber, "dis_sang_name", pre_modifier_name + post_modifier_name);

					if(e.ChangeValue.ToString().Trim() == "" ) break;
					
					string sang_name = GetCodeName(e.ColName, e.ChangeValue.ToString().Trim());

					if(sang_name == "")
					{
						CommonItemCollection openParams  = new CommonItemCollection();
						openParams.Add("sang_inx", e.ChangeValue.ToString().Trim());
						XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
						break;
					}
					else
						grdOCS0205.SetItemValue(e.RowNumber, "sang_name", sang_name);

					//display 상병명
					grdOCS0205.SetItemValue(e.RowNumber, "dis_sang_name", pre_modifier_name + sang_name + post_modifier_name);										
					break;
				case "dis_sang_name":
					ClearSangName(grdOCS0205, e.RowNumber);
					grdOCS0205.SetItemValue(e.RowNumber, "sang_code", "0000999");	
					grdOCS0205.SetItemValue(e.RowNumber, "sang_name", e.ChangeValue);					
					break;
				default:
					break;
			}
		}

		private void grdOCS0205_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
			if(e.ColName == "dis_sang_name")
			{
				if(e.DataRow["sang_code"].ToString().Trim() == "0000999" || e.DataRow["sang_code"].ToString().Trim() == "")
					e.Protect = false;
				else
					e.Protect = true;
			}
			else if(e.ColName == "susik_button")
			{
				if(e.DataRow["sang_code"].ToString().Trim() == "0000999" )
					e.Protect = true;
				else
					e.Protect = false;
			}
		}

		private void grdOCS0205_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			if (sender == null || ((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.EditorStyle != XCellEditorStyle.FindBox) return;

			switch (e.ColName)
			{
				case "sang_code": // 상병코드
					CommonItemCollection openParams  = new CommonItemCollection();
					XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
					e.Cancel = true; //Find창을 사용하지 않는다
					break;
				default:
					break;
			}
		}
		#endregion

		#region [상병중복 check]
		private bool CheckDoubleSang_code(string sang_code)
		{
			bool checkDuble = false;
			//중복 Check
			for(int i = 0; i < grdOCS0205.RowCount; i++)
			{
				if(i != grdOCS0205.CurrentRowNumber )
				{
					if( grdOCS0205.GetItemString(i, "sang_code").Trim() == sang_code )
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.XMessageBox2_Jp + sang_code + Resource.XMessageBox3_Jp : Resource.XMessageBox2_Ko + sang_code + Resource.XMessageBox3_Ko;
						mbxCap = NetInfo.Language == LangMode.Jr ? Resource.mbxCap_Jp : Resource.mbxCap_Ko;
						XMessageBox.Show(mbxMsg, mbxCap);
						checkDuble= true;
						break;
					}
				}
			} 

			return checkDuble;
		}
		#endregion

		#region [Button List Event]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert:

					e.IsBaseCall = false;
					
					DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);

					if(chkCell.RowNumber < 0)
					{
						int currentRow = -1;
						if(this.CurrMSLayout == grdOCS0204)
						{
							currentRow = grdOCS0204.InsertRow();
							grdOCS0204.SetItemValue(currentRow, "memb", mMemb);
						}
						else if(this.CurrMSLayout == grdOCS0205)
						{
							currentRow = grdOCS0205.InsertRow();
							grdOCS0205.SetItemValue(currentRow, "memb"      , mMemb);
							grdOCS0205.SetItemValue(currentRow, "sang_gubun", grdOCS0204.GetItemString(grdOCS0204.CurrentRowNumber, "sang_gubun"));							
						}
					}
					else
						((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
					break;
				case FunctionType.Query:
                    
                    e.IsBaseCall = false;

                    this.grdOCS0204.QueryLayout(true);

					break;
				case FunctionType.Update:
                    e.IsBaseCall = false;
                    OcsaOCS0204U00SaveLayoutArgs args = new OcsaOCS0204U00SaveLayoutArgs();
                    args.Grd0204SaveItem = GetOcs0204ListDataForSaveLayout();
                    args.Grd0205SaveItem = GetOcs0205ListDataForSaveLayout();
                    if (args.Grd0204SaveItem.Count == 0 && args.Grd0205SaveItem.Count == 0)
                    {
                        return;
                    }
                    if (ValidateItem(args.Grd0204SaveItem, args.Grd0205SaveItem) == false)
                    {
                        XMessageBox.Show(Resource.XMessageBox10_Jp, Resource.mbxCap_Jp, MessageBoxIcon.Warning);
                        return;
                    }
                    args.UserId = UserInfo.UserID;
                    UpdateResult result = CloudService.Instance.Submit<UpdateResult, OcsaOCS0204U00SaveLayoutArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.Result == true)
                    {
                        XMessageBox.Show(Resource.XMessageBox8_Jp, Resource.mbxCap_Jp, MessageBoxIcon.Information);
                        grdOCS0204.QueryLayout(true);
                        grdOCS0205.QueryLayout(false); 
                    }
                    else
                    {
                        XMessageBox.Show(Resource.XMessageBox9_Jp, Resource.mbxCap_Jp, MessageBoxIcon.Error);
                    }
					break;
				case FunctionType.Delete:
					if(CurrMSLayout == grdOCS0204)
					{
						if(CheckDetailData(grdOCS0204))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.XMessageBox4_Jp : Resource.XMessageBox4_Ko; 
							mbxCap = NetInfo.Language == LangMode.Jr ? Resource.mbxCap2_Jp : Resource.mbxCap2_Ko;
							XMessageBox.Show(mbxMsg, mbxCap);
							e.IsBaseCall = false;
						}
					}
					break;
				default:
					break;
			}
		}

        private bool ValidateItem(List<OcsaOCS0204U00GrdOCS0204ListInfo> list0204, List<OcsaOCS0204U00GrdOCS0205ListInfo> list0205)
        {
            if (null != list0204 && list0204.Count > 0)
            {
                foreach (OcsaOCS0204U00GrdOCS0204ListInfo item0204 in list0204)
                {
                    if (item0204.Memb == "" || item0204.SangGubun == "" || item0204.SangGubunName == "")
                    {
                        return false;
                    }
                }
            }
            if (null != list0205 && list0205.Count > 0)
            {
                foreach (OcsaOCS0204U00GrdOCS0205ListInfo item0205 in list0205)
                {
                    if (item0205.Memb == "" || item0205.SangGubun == "" || item0205.SangCode == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

		private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert:
					break;
				default:
					break;
			}
		}
		#endregion

		#region [OCS0205 Key값을 가져온다.]
		private int GetPK_SEQ()
		{
			string cmdText = "SELECT OCS0205_SEQ.NEXTVAL FROM DUAL " ;

			object retSeq = Service.ExecuteScalar(cmdText);

			if(retSeq == null)
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.XMessageBox5_Jp : Resource.XMessageBox5_Ko;
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap);						
			}
			else
			{
				return int.Parse(retSeq.ToString());
			}

			return 0; 
		}
		#endregion

		#region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)
		/// <summary>
		/// Insert한 Row 중에 Not Null필드 미입력 Row Search
		/// </summary>
		/// <remarks>
		/// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
		/// </remarks>
		/// <param name="aGrd"> XEditGrid  </param>
		/// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
		private DataGridCell GetEmptyNewRow(object aGrd)
		{
			DataGridCell celReturn = new DataGridCell(-1, -1);

			if (aGrd == null) return celReturn;

			XEditGrid grdChk = null;
            
			try
			{
				grdChk = (XEditGrid)aGrd;
			}
			catch
			{
				return celReturn;
			}

			foreach (XEditGridCell cell in grdChk.CellInfos)
			{
				// NotNull Check
				if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly) 
				{
					for( int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
					{
						if(grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
						{
							celReturn.ColumnNumber = cell.Col;
							celReturn.RowNumber   = rowIndex;
							break;
						}
					}

					if(celReturn.RowNumber < 0) 
						continue;
					else
						break;
				}

			}

			return celReturn;
		}
		#endregion

		#region [상병]
		private void ShowSusik(int currentRow)
		{
			IHIS.Framework.MultiLayout laySusikInfo = new MultiLayout();
			laySusikInfo.LayoutItems.Add("sang_name"         ,DataType.String );
			laySusikInfo.LayoutItems.Add("pre_modifier1"     ,DataType.String );			
			laySusikInfo.LayoutItems.Add("pre_modifier2"     ,DataType.String );			
			laySusikInfo.LayoutItems.Add("pre_modifier3"     ,DataType.String );			
			laySusikInfo.LayoutItems.Add("pre_modifier4"     ,DataType.String );			
			laySusikInfo.LayoutItems.Add("pre_modifier5"     ,DataType.String );			
			laySusikInfo.LayoutItems.Add("pre_modifier6"     ,DataType.String );			
			laySusikInfo.LayoutItems.Add("pre_modifier7"     ,DataType.String );			
			laySusikInfo.LayoutItems.Add("pre_modifier8"     ,DataType.String );			
			laySusikInfo.LayoutItems.Add("pre_modifier9"     ,DataType.String );			
			laySusikInfo.LayoutItems.Add("pre_modifier10"    ,DataType.String );			
			laySusikInfo.LayoutItems.Add("pre_modifier_name" ,DataType.String );			
			laySusikInfo.LayoutItems.Add("post_modifier1"    ,DataType.String );			
			laySusikInfo.LayoutItems.Add("post_modifier2"    ,DataType.String );			
			laySusikInfo.LayoutItems.Add("post_modifier3"    ,DataType.String );			
			laySusikInfo.LayoutItems.Add("post_modifier4"    ,DataType.String );			
			laySusikInfo.LayoutItems.Add("post_modifier5"    ,DataType.String );			
			laySusikInfo.LayoutItems.Add("post_modifier6"    ,DataType.String );			
			laySusikInfo.LayoutItems.Add("post_modifier7"    ,DataType.String );			
			laySusikInfo.LayoutItems.Add("post_modifier8"    ,DataType.String );			
			laySusikInfo.LayoutItems.Add("post_modifier9"    ,DataType.String );			
			laySusikInfo.LayoutItems.Add("post_modifier10"   ,DataType.String );			
			laySusikInfo.LayoutItems.Add("post_modifier_name",DataType.String );			
			laySusikInfo.InitializeLayoutTable();

			int insertRow = laySusikInfo.InsertRow(-1);

			foreach(XEditGridCell cell in grdOCS0205.CellInfos)
			{
				if(laySusikInfo.LayoutItems.Contains(cell.CellName))
					laySusikInfo.SetItemValue(insertRow, cell.CellName, grdOCS0205.GetItemValue(currentRow, cell.CellName));
			}

			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add( "SANGINFO", laySusikInfo);
			//서식지처방 조회 화면 Open
			XScreen.OpenScreenWithParam( this, "CHTS", "CHT0115Q00", ScreenOpenStyle.ResponseFixed, openParams);
		}

		/// <summary>
		/// 해당 Row에 의증을 set/Reset한다.
		/// </summary>		
		private void SetDoubt(bool addMode, XEditGrid grdSang, int currentRow)
		{	
			string colName = "";
			if(addMode)
			{	
				for(int i = 1; i <= 10; i++)
				{
					colName = "post_modifier" + i.ToString();
					if(grdSang.GetItemString(currentRow, colName).Trim() == "")
					{
						grdSang.SetItemValue(currentRow, colName, "8002");
						grdSang.SetItemValue(currentRow, "post_modifier_name", grdSang.GetItemString(currentRow, "post_modifier_name") + Resource.XMessageBox10_ko);
                        grdSang.SetItemValue(currentRow, "dis_sang_name", grdSang.GetItemString(currentRow, "dis_sang_name") + Resource.XMessageBox10_ko);
						break;
					}
				}				
			}
			else
			{
				for(int i = 1; i <= 10; i++)
				{
					colName = "post_modifier" + i.ToString();
					if(grdSang.GetItemString(currentRow, colName).Trim() == "8002")
					{
						grdSang.SetItemValue(currentRow, colName, "");
                        grdSang.SetItemValue(currentRow, "post_modifier_name", grdSang.GetItemString(currentRow, "post_modifier_name").Replace(Resource.XMessageBox10_ko, ""));
                        grdSang.SetItemValue(currentRow, "dis_sang_name", grdSang.GetItemString(currentRow, "dis_sang_name").Replace(Resource.XMessageBox10_ko, ""));
						break;
					}
				}
			}
		}

		/// <summary>
		/// 해당 Row에 의증이 등록되어 있는지 check한다.
		/// </summary>
		private bool CheckDoubt(XEditGrid grdSang, int currentRow)
		{
			bool returnValue = false;

			//접미어
			if( grdSang.GetItemString(currentRow, "post_modifier1").Trim() == "8002")
				returnValue = true;
			else if( grdSang.GetItemString(currentRow, "post_modifier2").Trim() == "8002")
				returnValue = true;
			else if( grdSang.GetItemString(currentRow, "post_modifier3").Trim() == "8002")
				returnValue = true;
			else if( grdSang.GetItemString(currentRow, "post_modifier4").Trim() == "8002")
				returnValue = true;
			else if( grdSang.GetItemString(currentRow, "post_modifier5").Trim() == "8002")
				returnValue = true;
			else if( grdSang.GetItemString(currentRow, "post_modifier6").Trim() == "8002")
				returnValue = true;
			else if( grdSang.GetItemString(currentRow, "post_modifier7").Trim() == "8002")
				returnValue = true;
			else if( grdSang.GetItemString(currentRow, "post_modifier8").Trim() == "8002")
				returnValue = true;
			else if( grdSang.GetItemString(currentRow, "post_modifier9").Trim() == "8002")
				returnValue = true;
			else if( grdSang.GetItemString(currentRow, "post_modifier10").Trim() == "8002")
				returnValue = true;

			return returnValue;
		}
        
		/// <summary>
		/// 해당 Row의 수식어를 Clear한다.
		/// </summary>
		private void ClearSangName(XEditGrid grdSang, int currentRow)
		{
			string colName = "";

			for(int i = 1; i <= 10; i++)
			{
				colName = "pre_modifier" + i.ToString();
				if(grdSang.GetItemString(currentRow, colName).Trim() != "")
					grdSang.SetItemValue(currentRow, colName, "");

				colName = "post_modifier" + i.ToString();
				if(grdSang.GetItemString(currentRow, colName).Trim() != "")
					grdSang.SetItemValue(currentRow, colName, "");
			}		

			grdSang.SetItemValue(currentRow, "pre_modifier_name" , "");
			grdSang.SetItemValue(currentRow, "post_modifier_name", "");
		}
		#endregion

		#region [Detail Data존재여부 check]
		/// <summary>
		/// Detail Data 존재여부를 check합니다.
		/// </summary>
		private bool CheckDetailData(object aGrd)
		{
			bool returnValue = false;

			if (aGrd == null) return returnValue;

			XMstGrid mstGrid = null;
            
			try
			{
				mstGrid = (XMstGrid)aGrd;
			}
			catch
			{
				return returnValue;
			}

			int chk = 0;

			try
			{
				foreach( object obj in this.Controls )
				{
					if( obj.GetType().Name.ToString().IndexOf("Panel") >= 0 )
					{
						foreach( object panObj in ((Panel)obj).Controls )
						{
							if( panObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)panObj).MasterLayout == mstGrid)
							{	
								chk = chk + ((XGrid)panObj).RowCount;						
							}
							else if( panObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)panObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XEditGrid)panObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XEditGrid)panObj).DeletedRowCount;

							}
							else if( panObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)panObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XMstGrid)panObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XMstGrid)panObj).DeletedRowCount;
							}
						}
					}
					else if( obj.GetType().Name.ToString().IndexOf("GroupBox") >= 0 )
					{
						foreach( object gbxObj in ((GroupBox)obj).Controls )
						{						
							if( gbxObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)gbxObj).MasterLayout == mstGrid)
							{	
								chk = chk + ((XGrid)gbxObj).RowCount;						
							}
							else if( gbxObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)gbxObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XEditGrid)gbxObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XEditGrid)gbxObj).DeletedRowCount;

							}
							else if( gbxObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)gbxObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XMstGrid)gbxObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XMstGrid)gbxObj).DeletedRowCount;
							}
						}
					}
					else if( obj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)obj).MasterLayout == mstGrid)
					{	
						chk = chk + ((XGrid)obj).RowCount;						
					}
					else if( obj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)obj).MasterLayout == mstGrid )
					{
						foreach( DataRow row in ((XEditGrid)obj).LayoutTable.Rows )
							if(row.RowState != DataRowState.Added) chk = chk + 1;

						chk = chk + ((XEditGrid)obj).DeletedRowCount;

					}
					else if( obj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)obj).MasterLayout == mstGrid )
					{
						foreach( DataRow row in ((XMstGrid)obj).LayoutTable.Rows )
							if(row.RowState != DataRowState.Added) chk = chk + 1;

						chk = chk + ((XMstGrid)obj).DeletedRowCount;
					}
				}
			}
			catch {}

			if(chk > 0)							
				returnValue = true;

			return returnValue;
		}
		#endregion

		#region [Drag 순서변경]
		
		private bool mIsDrag = false;
		private int mDragX = 0;
		private int mDragY = 0;

		#region [순서변경]
		private void grdOCS0204_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (mIsDrag && (Math.Abs(e.X - mDragX) > 3 || Math.Abs(e.Y - mDragY) > 3))
			{
				mIsDrag = false;
				
				int curRowIndex = grdOCS0204.GetHitRowNumber(mDragY);

				if( curRowIndex < 0 || TypeCheck.IsNull(grdOCS0204.GetItemString(curRowIndex, "sang_gubun"))) return;
				
				string dragInfo = "[" + grdOCS0204.GetItemString(curRowIndex, "sang_gubun") + "]" + grdOCS0204.GetItemString(curRowIndex, "sang_gubun_name");
				DragHelper.CreateDragCursor(grdOCS0204, dragInfo, this.Font);
				// Drag시 rowNumber를 넘겨준다.
				grdOCS0204.DoDragDrop("OCS0204|" + curRowIndex.ToString(), DragDropEffects.Move);		
			}
		}

		private void grdOCS0204_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			mIsDrag = false;
		}

		private void grdOCS0204_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if(grdOCS0204.GetHitRowNumber(e.Y) < 0 ) return;

				int curRowIndex = grdOCS0204.GetHitRowNumber(e.Y);

				mIsDrag = true;
				mDragX  = e.X;
				mDragY  = e.Y;
			}		
		}

		private void grdOCS0204_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void grdOCS0204_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}
		}

		private void grdOCS0204_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetData("System.String").ToString().Split('|')[0] != "OCS0204") return;

			// Client Point			
			int   fromRowNum  = int.Parse(e.Data.GetData("System.String").ToString().Split('|')[1]);
			Point clientPoint = grdOCS0204.PointToClient(new Point(e.X, e.Y));

			int toRowNum = grdOCS0204.GetHitRowNumber(clientPoint.Y);

			if(toRowNum == fromRowNum || toRowNum < 0 ) return;

			int currentColNum = grdOCS0204.CurrentColNumber;
			if(currentColNum == -1) currentColNum = 0;
		
			AlterGridRowPosition(grdOCS0204, fromRowNum, toRowNum);
		}
		#endregion

		#region [상병 Drag 처리]
		private void grdOCS0205_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (mIsDrag && (Math.Abs(e.X - mDragX) > 3 || Math.Abs(e.Y - mDragY) > 3))
			{
				mIsDrag = false;
				
				int curRowIndex = grdOCS0205.GetHitRowNumber(mDragY);

				if( curRowIndex < 0 || TypeCheck.IsNull(grdOCS0205.GetItemString(curRowIndex, "sang_code"))) return;
				
				string dragInfo = "[" + grdOCS0205.GetItemString(curRowIndex, "sang_code") + "]" + grdOCS0205.GetItemString(curRowIndex, "dis_sang_name");
				DragHelper.CreateDragCursor(grdOCS0205, dragInfo, this.Font);
				// Drag시 rowNumber를 넘겨준다.
				grdOCS0205.DoDragDrop("OCS0205|" + curRowIndex.ToString(), DragDropEffects.Move);		
			}
		}

		private void grdOCS0205_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			mIsDrag = false;
		}

		private void grdOCS0205_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if(grdOCS0205.GetHitRowNumber(e.Y) < 0 ) return;

				//의증 + 접미어
				if(grdOCS0205.CurrentColName == "doubt")
				{
					if(grdOCS0205.GetHitRowNumber(e.Y) < 0) return;		

					int curRowIndex = grdOCS0205.GetHitRowNumber(e.Y);

					if(grdOCS0205.CurrentColName == "doubt")
					{
						if(grdOCS0205.GetItemString(curRowIndex, "sang_code") != "0000999")
						{
							if(CheckDoubt(grdOCS0205, curRowIndex))
							{
								SetDoubt(false, grdOCS0205, curRowIndex);
							}
							else
							{
								SetDoubt(true, grdOCS0205, curRowIndex);
							}
						}
						else
							grdOCS0205[curRowIndex + grdOCS0205.HeaderHeights.Count, 3].Image = this.ImageList.Images[2];	
				
						grdOCS0205.Refresh();
					}				
				}
				else
				{
					mIsDrag = true;
					mDragX  = e.X;
					mDragY  = e.Y;
				}
			}
		}

		private void grdOCS0205_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시
		}

		private void grdOCS0205_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}
		}

		private void grdOCS0205_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetData("System.String").ToString().Split('|')[0] != "OCS0205") return;

			// Client Point			
			int   fromRowNum  = int.Parse(e.Data.GetData("System.String").ToString().Split('|')[1]);
			Point clientPoint = grdOCS0205.PointToClient(new Point(e.X, e.Y));

			int toRowNum = grdOCS0205.GetHitRowNumber(clientPoint.Y);

			if(toRowNum == fromRowNum || toRowNum < 0 ) return;

			AlterGridRowPosition(grdOCS0205, fromRowNum, toRowNum);
		}	
		#endregion

		#region [Button Sort]
		private void btnSangGubunUp_Click(object sender, System.EventArgs e)
		{
			//0 위치에서는 변경을 막는다.
			if(grdOCS0204.RowCount > 1 && grdOCS0204.CurrentRowNumber == 0) return;

			int fromRowNum = grdOCS0204.CurrentRowNumber;
			int toRowNum   = fromRowNum - 1;

			AlterGridRowPosition(grdOCS0204, fromRowNum, toRowNum);
		}

		private void btnSangGubunDown_Click(object sender, System.EventArgs e)
		{
			//마지막 위치에서는 변경을 막는다.
			if(grdOCS0204.RowCount > 1 && grdOCS0204.CurrentRowNumber == grdOCS0204.RowCount - 1) return;

			int fromRowNum = grdOCS0204.CurrentRowNumber;
			int toRowNum   = fromRowNum + 1;

			AlterGridRowPosition(grdOCS0204, fromRowNum, toRowNum);
		}

		private void btnSangUp_Click(object sender, System.EventArgs e)
		{
			//0 위치에서는 변경을 막는다.
			if(grdOCS0205.RowCount > 1 && grdOCS0205.CurrentRowNumber == 0) return;

			int fromRowNum = grdOCS0205.CurrentRowNumber;
			int toRowNum   = fromRowNum - 1;

			AlterGridRowPosition(grdOCS0205, fromRowNum, toRowNum);
		}

		private void btnSangDown_Click(object sender, System.EventArgs e)
		{
			//마지막 위치에서는 변경을 막는다.
			if(grdOCS0205.RowCount > 1 && grdOCS0205.CurrentRowNumber == grdOCS0205.RowCount - 1) return;

			int fromRowNum = grdOCS0205.CurrentRowNumber;
			int toRowNum   = fromRowNum + 1;

			AlterGridRowPosition(grdOCS0205, fromRowNum, toRowNum);
		}

		/// <summary>
		/// 선택한 Row (from row)를 to row위치로 가져간다.
		/// </summary>
		/// <param name="grd">해당 Grid</param>
		/// <param name="fromRowNum">대상 row위치  </param>
		/// <param name="toRowNum"  >변경할 row위치</param>
		private void AlterGridRowPosition(XEditGrid grd, int fromRowNum, int toRowNum)
		{
			if( fromRowNum < 0 || toRowNum < 0 ||
				fromRowNum >= grd.RowCount || toRowNum >= grd.RowCount ) return;

			if(grd == grdOCS0204) grdOCS0205.MasterLayout = null;
			
			int currentColNum = grd.CurrentColNumber;
			if(currentColNum == -1) currentColNum = 0;

			MultiLayout copyLay = grd.CopyToLayout();
			grd.LayoutTable.Rows.Clear();

			for(int i = 0; i < copyLay.RowCount; i++ )
			{
				if( i == fromRowNum )
					continue;

				//변경위치로 Row를 가져간다.
				if( i == toRowNum )
				{
					if( fromRowNum < toRowNum )
						grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
					
					grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[fromRowNum]);

					if( fromRowNum > toRowNum )
						grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
				}
				else
					grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
			}

			grd.DisplayData();
			grd.SetFocusToItem(toRowNum, currentColNum);	
			grd.SelectRow(toRowNum);

			if(grd == grdOCS0204) grdOCS0205.MasterLayout = grdOCS0204;
		}
		#endregion

		#endregion

		#region 상병 Copy
		private void pbxCopy_Click(object sender, System.EventArgs e)
		{
			if (this.btnCopy != null) this.btnCopy.PerformClick();
		}
		private void btnCopy_Click(object sender, System.EventArgs e)
		{
			string mbxMsg = "", mbxCap = "";

			if (grdOCS0205.LayoutTable == null) return;

			bool isSelectedRow = false; // Select 여부 
			ArrayList selectedRow = new ArrayList();  // Selected Row's

			for (int i = 0; i < this.grdOCS0205.RowCount; i++)
			{
				if (this.grdOCS0205.IsSelectedRow(i) && this.grdOCS0205.IsVisibleRow(i) && !TypeCheck.IsNull(grdOCS0205.GetItemString(i, "dis_sang_name"))) // Select 여부 체크
				{					
					selectedRow.Add(i);
					isSelectedRow = true; 
				}
			}
			
			if (!isSelectedRow) 
			{
                //https://sofiamedix.atlassian.net/browse/MED-12036
                mbxMsg = Resource.XMessageBox6; //NetInfo.Language == LangMode.Jr ? Resource.XMessageBox6_Jp : Resource.XMessageBox6_Ko;

				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;			
			}

			this.pbxCopy.Visible = false; // 디폴트 Copy할 데이타 선택여부 False

			// DataTable 비워 있는 경우 테이블 구조 복제
			if (this.mLayDtBuffer == null) this.mLayDtBuffer = this.grdOCS0205.LayoutTable.Clone();

			this.mLayDtBuffer.Rows.Clear(); // Buffer DataTable Clear

			for (int i = 0; i < selectedRow.Count; i++)
			{
				this.mLayDtBuffer.ImportRow(this.grdOCS0205.LayoutTable.Rows[(int)selectedRow[i]]);
			}

			this.pbxCopy.Visible = true; // Copy할 데이타 선택여부 true
			this.grdOCS0205.UnSelectAll();
		}
		#endregion
		
		#region 상병 Paste
		private void btnPaste_Click(object sender, System.EventArgs e)
		{
			if(grdOCS0204.CurrentRowNumber < 0) return;

			string mbxMsg = "", mbxCap = "";

			if (this.mLayDtBuffer == null || this.mLayDtBuffer.Rows.Count == 0) 
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.XMessageBox7_Jp : Resource.XMessageBox7_Ko;

				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;
			}

			foreach (DataRow row in this.mLayDtBuffer.Rows) 
			{
				row["memb"] = mMemb;
				row["sang_gubun"] = grdOCS0204.GetItemString(grdOCS0204.CurrentRowNumber, "sang_gubun");
				
				int insertRow = -1;
				insertRow = grdOCS0205.InsertRow(-1);
				foreach(XGridCell cell in this.grdOCS0205.CellInfos)
				{
					grdOCS0205.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);					
				}	
			}

			this.grdOCS0205.UnSelectAll();

		}
		#endregion

		#region [Query Starting]
		private void grdOCS0204_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
            grdOCS0204.SetBindVarValue("f_memb", this.mMemb);
            grdOCS0204.SetBindVarValue("f_hosp_code",  EnvironInfo.HospCode);
		}

		private void grdOCS0205_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			grdOCS0205.SetBindVarValue("f_memb",       grdOCS0204.GetItemString(grdOCS0204.CurrentRowNumber,"memb"));
            grdOCS0205.SetBindVarValue("f_sang_gubun", grdOCS0204.GetItemString(grdOCS0204.CurrentRowNumber, "sang_gubun"));
            grdOCS0205.SetBindVarValue("f_hosp_code",  mHospCode);
		}

		#endregion

        #region [ PreSaveLayout ]
        private void grdOCS0204_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            int seq = 1;

            //grdOCS0204
            for (int rowIndex = 0; rowIndex < grdOCS0204.RowCount; rowIndex++)
            {
                if (grdOCS0204.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0204.GetItemString(rowIndex, "sang_gubun").Trim() == "")
                    {
                        grdOCS0204.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                    }
                }

                seq = rowIndex + 1;

                if (grdOCS0204.GetItemString(rowIndex, "seq") != seq.ToString()) grdOCS0204.SetItemValue(rowIndex, "seq", seq);
            }
        }

        private void grdOCS0205_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            int seq = 1;

            //grdOCS0205
            for (int rowIndex = 0; rowIndex < grdOCS0205.RowCount; rowIndex++)
            {
                if (grdOCS0205.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    grdOCS0205.SetItemValue(rowIndex, "memb", mMemb);
                    grdOCS0205.SetItemValue(rowIndex, "sang_gubun", grdOCS0204.GetItemString(grdOCS0204.CurrentRowNumber, "sang_gubun"));

                    //Key값이 없으면 삭제처리
                    if (grdOCS0205.GetItemString(rowIndex, "sang_code").Trim() == "")
                    {
                        grdOCS0205.DeleteRow(rowIndex);
                        rowIndex--;
                    }
                }

                seq = rowIndex + 1;

                if (grdOCS0205.GetItemString(rowIndex, "ser") != seq.ToString()) grdOCS0205.SetItemValue(rowIndex, "ser", seq);
            }
        }
        #endregion

        #region [ SaveEnd ]
        private void SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            switch (e.CallerID)
            {
                case '1':
                    isgrdOCS0204Save = e.IsSuccess;
                    isSavedOCS0204 = true;
                    break;
                case '2':
                    isgrdOCS0205Save = e.IsSuccess;
                    isSavedOCS0205 = true;
                    break;
            }
            if (isSavedOCS0204 && isSavedOCS0205)
            {
                if (isgrdOCS0204Save && isgrdOCS0205Save)
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.XMessageBox8_Jp : Resource.XMessageBox8_Ko;
                    SetMsg(mbxMsg);
                    grdOCS0205.QueryLayout(false);
                }
                else
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? Resource.XMessageBox9_Jp : Resource.XMessageBox9_ko;
                    mbxMsg = mbxMsg + Service.ErrMsg;
                    mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                    XMessageBox.Show(mbxMsg, mbxCap);
                }
            }

            isgrdOCS0204Save = false;
            isgrdOCS0205Save = false;

            isSavedOCS0204 = false;
            isSavedOCS0205 = false;
        }
        #endregion

		#region [XSavePerformer Class]
		/*private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private OCS0204U00 parent = null;

			public XSavePerformer(OCS0204U00 parent)
			{
				this.parent = parent;
			}

			public bool Execute(char callerID, RowDataItem item)
			{
				string cmdText = "";
				item.BindVarList.Add("f_user_id",UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

				switch(callerID)
				{
					case '1':
					switch(item.RowState)
					{
						case DataRowState.Added :
                            cmdText = @"INSERT INTO OCS0204
                                              ( SYS_DATE, SYS_ID       , MEMB               , MEMB_GUBUN  ,
                                                SEQ     , SANG_GUBUN   , SANG_GUBUN_NAME    , HOSP_CODE                )
                                         VALUES
                                              ( SYSDATE , :f_user_id   , :f_memb            , NVL(:f_memb_gubun, '1') ,
                                                :f_seq  , :f_sang_gubun, :f_sang_gubun_name , :f_hosp_code             )";
							break;
						case DataRowState.Modified :
                            cmdText = @"UPDATE OCS0204
                                           SET UPD_ID          = :f_user_id, 
                                               UPD_DATE        = SYSDATE   , 
                                               SEQ             = :f_seq    , 
                                               SANG_GUBUN_NAME = :f_sang_gubun_name 
                                         WHERE MEMB            = :f_memb
                                           AND MEMB_GUBUN      =  '1'
                                           AND SANG_GUBUN      = :f_sang_gubun
                                           AND HOSP_CODE       = :f_hosp_code";
							break;
						case DataRowState.Deleted :
							cmdText = "DELETE OCS0204 "
									+"	WHERE MEMB       = :f_memb "
                                    +"    AND MEMB_GUBUN = '1'"
                                    + "	  AND SANG_GUBUN = :f_sang_gubun"
                                    + "	  AND HOSP_CODE  = :f_hosp_code";
							break;
					}
						break;
					case '2':
					switch(item.RowState)
					{
						case DataRowState.Added :
							cmdText = @"INSERT INTO OCS0205
                                             ( SYS_DATE, SYS_ID, PK_SEQ, MEMB, MEMB_GUBUN, SANG_GUBUN, SANG_CODE, SER, 
                                               SANG_NAME, PRE_MODIFIER1, PRE_MODIFIER2, PRE_MODIFIER3, PRE_MODIFIER4,  
                                               PRE_MODIFIER5, PRE_MODIFIER6, PRE_MODIFIER7, PRE_MODIFIER8, PRE_MODIFIER9,  
                                               PRE_MODIFIER10, PRE_MODIFIER_NAME, POST_MODIFIER1, POST_MODIFIER2,  
                                               POST_MODIFIER3, POST_MODIFIER4, POST_MODIFIER5, POST_MODIFIER6, POST_MODIFIER7,  
                                               POST_MODIFIER8, POST_MODIFIER9, POST_MODIFIER10, POST_MODIFIER_NAME, HOSP_CODE) 
                                         SELECT
                                               SYSDATE, :f_user_id, NVL(MAX(PK_SEQ), 0) + 1, :f_memb, NVL(:f_memb_gubun, '1'), :f_sang_gubun,
                                               :f_sang_code, :f_ser, :f_sang_name, :f_pre_modifier1, :f_pre_modifier2, :f_pre_modifier3, 
                                               :f_pre_modifier4, :f_pre_modifier5, :f_pre_modifier6, :f_pre_modifier7, 
                                               :f_pre_modifier8, :f_pre_modifier9, :f_pre_modifier10, :f_pre_modifier_name, 
                                               :f_post_modifier1, :f_post_modifier2, :f_post_modifier3, :f_post_modifier4, 
                                               :f_post_modifier5, :f_post_modifier6, :f_post_modifier7, :f_post_modifier8, 
                                               :f_post_modifier9, :f_post_modifier10, :f_post_modifier_name, :f_hosp_code
                                           FROM OCS0205
                                          WHERE MEMB = :f_memb
                                            AND MEMB_GUBUN = '1'
                                            AND SANG_GUBUN = :f_sang_gubun
                                            AND HOSP_CODE  = :f_hosp_code";
							break;
						case DataRowState.Modified :
							cmdText = "UPDATE OCS0205 "
									+"	  SET UPD_ID             = :f_user_id           , "
									+"		  UPD_DATE           = SYSDATE              , "
									+"		  SER                = :f_ser               , "
									+"		  SANG_NAME          = :f_sang_name         , "
									+"		  PRE_MODIFIER1      = :f_pre_modifier1     , "
									+"		  PRE_MODIFIER2      = :f_pre_modifier2     , "
									+"		  PRE_MODIFIER3      = :f_pre_modifier3     , "
									+"		  PRE_MODIFIER4      = :f_pre_modifier4     , "
									+"		  PRE_MODIFIER5      = :f_pre_modifier5     , "
									+"		  PRE_MODIFIER6      = :f_pre_modifier6     , "
									+"		  PRE_MODIFIER7      = :f_pre_modifier7     , "
									+"		  PRE_MODIFIER8      = :f_pre_modifier8     , "
									+"		  PRE_MODIFIER9      = :f_pre_modifier9     , "
									+"		  PRE_MODIFIER10     = :f_pre_modifier10    , "
									+"		  PRE_MODIFIER_NAME  = :f_pre_modifier_name , "
									+"		  POST_MODIFIER1     = :f_post_modifier1    , "
									+"		  POST_MODIFIER2     = :f_post_modifier2    , "
									+"		  POST_MODIFIER3     = :f_post_modifier3    , "
									+"		  POST_MODIFIER4     = :f_post_modifier4    , "
									+"		  POST_MODIFIER5     = :f_post_modifier5    , "
									+"		  POST_MODIFIER6     = :f_post_modifier6    , "
									+"		  POST_MODIFIER7     = :f_post_modifier7    , "
									+"		  POST_MODIFIER8     = :f_post_modifier8    , "
									+"		  POST_MODIFIER9     = :f_post_modifier9    , "
									+"		  POST_MODIFIER10    = :f_post_modifier10   , "
									+"		  POST_MODIFIER_NAME = :f_post_modifier_name "
									+"	WHERE MEMB       = :f_memb "
                                    +"    AND MEMB_GUBUN = '1' "
									+"	  AND SANG_GUBUN = :f_sang_gubun "
									+"	  AND PK_SEQ     = :f_pk_seq"
                                    +"    AND HOSP_CODE  = :f_hosp_code";
							break;
						case DataRowState.Deleted :
							cmdText = "DELETE OCS0205 "
                                    + "	WHERE MEMB       = :f_memb "
                                    +"    AND MEMB_GUBUN = '1' "
									+"	  AND SANG_GUBUN = :f_sang_gubun "
									+"	  AND PK_SEQ     = :f_pk_seq"
                                    +"    AND HOSP_CODE  = :f_hosp_code";
							break;
					}
						break;
				}

				return Service.ExecuteNonQuery(cmdText,item.BindVarList);
			}
		}*/
		#endregion

        #region cloud service
        private List<string> CreateGrdOCS0204U00ParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_memb");
            return paramList;
        }

        private List<object[]> LoadGrdOCS0204U00(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OcsaOCS0204U00GrdOCS0204ListArgs args = new OcsaOCS0204U00GrdOCS0204ListArgs();
            args.FMemb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            OcsaOCS0204U00GrdOCS0204ListResult result =
                CloudService.Instance.Submit<OcsaOCS0204U00GrdOCS0204ListResult, OcsaOCS0204U00GrdOCS0204ListArgs>(
                    args);
            if (result != null)
            {
                foreach (OcsaOCS0204U00GrdOCS0204ListInfo item in result.Grd0204Item)
                {
                    object[] objects = 
				{ 
					item.Memb, 
					item.FSeq, 
					item.SangGubun, 
					item.SangGubunName
				};
                    res.Add(objects);
                }
            }
            return res; 
        }

        private List<string> CreateGrdOCS0205U00ParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_memb");
            paramList.Add("f_sang_gubun");
            return paramList;
        }

        private List<object[]> LoadGrdOCS0205U00(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OcsaOCS0204U00GrdOCS0205ListArgs args = new OcsaOCS0204U00GrdOCS0205ListArgs();
            args.FMemb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            args.SangGubun = bc["f_sang_gubun"] != null ? bc["f_sang_gubun"].VarValue : "";
            OcsaOCS0204U00GrdOCS0205ListResult result =
                CloudService.Instance.Submit<OcsaOCS0204U00GrdOCS0205ListResult, OcsaOCS0204U00GrdOCS0205ListArgs>(args);
            if (result != null)
            {
                foreach (OcsaOCS0204U00GrdOCS0205ListInfo item in result.Grd0205Item)
                {
                    object[] objects = 
				{ 
					item.PkSeq, 
					item.Memb, 
					item.SangGubun, 
					item.SangCode, 
					item.DisSangName, 
					item.Ser, 
					item.SangName, 
					item.PreModifier1, 
					item.PreModifier2, 
					item.PreModifier3, 
					item.PreModifier4, 
					item.PreModifier5, 
					item.PreModifier6, 
					item.PreModifier7, 
					item.PreModifier8, 
					item.PreModifier9, 
					item.PreModifier10, 
					item.PreModifierName, 
					item.PostModifier1, 
					item.PostModifier2, 
					item.PostModifier3, 
					item.PostModifier4, 
					item.PostModifier5, 
					item.PostModifier6, 
					item.PostModifier7, 
					item.PostModifier8, 
					item.PostModifier9, 
					item.PostModifier10, 
					item.PostModifierName
				};
                    res.Add(objects);
                }
            }
            return res; 
        }

	    private List<string> CreateFdwCommonParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_find1");
            return paramList;
        }

        private List<object[]> LoadFdwCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OcsaOCS0204U00FindWorkerListArgs args = new OcsaOCS0204U00FindWorkerListArgs();
            args.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            OcsaOCS0204U00FindWorkerListResult result =
                CloudService.Instance.Submit<OcsaOCS0204U00FindWorkerListResult, OcsaOCS0204U00FindWorkerListArgs>(args);
            if (result != null)
            {
                foreach (OcsaOCS0204U00MembListInfo item in result.MembList)
                {
                    object[] objects = 
				{ 
					item.UserId, 
					item.UserNm
				};
                    res.Add(objects);
                }
            }
            return res; 
        }

	    private OcsaOCS0204U00GwaResult GetGwaDataList(string aMemb)
	    {
	        OcsaOCS0204U00GwaArgs args = new OcsaOCS0204U00GwaArgs();
            args.RequestValue = new LoadColumnCodeNameInfo();
	        args.RequestValue.ColName = "user_id";
	        args.RequestValue.Arg1 = aMemb;
	        args.Sabun = aMemb;
	        return CloudService.Instance.Submit<OcsaOCS0204U00GwaResult, OcsaOCS0204U00GwaArgs>(args);
	    }

        private List<object[]> LoadGwaCombo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            foreach (ComboListItemInfo item in gwaComboItemList)
            {
                object[] objects = 
			    { 
				    item.Code, 
				    item.CodeName
			    };
                res.Add(objects);
            }
            return res; 
        }

        private List<OcsaOCS0204U00GrdOCS0204ListInfo> GetOcs0204ListDataForSaveLayout()
        {
            List<OcsaOCS0204U00GrdOCS0204ListInfo> lstResult = new List<OcsaOCS0204U00GrdOCS0204ListInfo>();

            for (int i = 0; i < grdOCS0204.RowCount; i++)
            {
                OcsaOCS0204U00GrdOCS0204ListInfo item = new OcsaOCS0204U00GrdOCS0204ListInfo();
                if (grdOCS0204.GetRowState(i) == DataRowState.Added || grdOCS0204.GetRowState(i) == DataRowState.Modified)
                {
                    item.Memb = grdOCS0204.GetItemString(i, "memb");
                    item.FSeq = grdOCS0204.GetItemString(i, "seq");
                    item.SangGubun = grdOCS0204.GetItemString(i, "sang_gubun");
                    item.SangGubunName = grdOCS0204.GetItemString(i, "sang_gubun_name");

                    item.DataRowState = grdOCS0204.GetRowState(i).ToString();
                    lstResult.Add(item);
                }
            }

            // Delete
            if (null != grdOCS0204.DeletedRowTable)
            {
                foreach (DataRow dr in grdOCS0204.DeletedRowTable.Rows)
                {
                    OcsaOCS0204U00GrdOCS0204ListInfo item = new OcsaOCS0204U00GrdOCS0204ListInfo();
                    item.Memb = Convert.ToString(dr["memb"]);
                    item.SangGubun = Convert.ToString(dr["sang_gubun"]);
                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        private List<OcsaOCS0204U00GrdOCS0205ListInfo> GetOcs0205ListDataForSaveLayout()
        {
            List<OcsaOCS0204U00GrdOCS0205ListInfo> lstResult = new List<OcsaOCS0204U00GrdOCS0205ListInfo>();

            for (int i = 0; i < grdOCS0205.RowCount; i++)
            {
                OcsaOCS0204U00GrdOCS0205ListInfo item = new OcsaOCS0204U00GrdOCS0205ListInfo();
                if (grdOCS0205.GetRowState(i) == DataRowState.Added || grdOCS0205.GetRowState(i) == DataRowState.Modified)
                {
                    item.PkSeq = grdOCS0205.GetItemString(i, "pk_seq");
                    item.Memb = grdOCS0205.GetItemString(i, "memb");
                    item.SangGubun = grdOCS0205.GetItemString(i, "sang_gubun");
                    item.SangCode = grdOCS0205.GetItemString(i, "sang_code");
                    item.DisSangName = grdOCS0205.GetItemString(i, "dis_sang_name");
                    item.Ser = grdOCS0205.GetItemString(i, "ser");
                    item.SangName = grdOCS0205.GetItemString(i, "sang_name");
                    item.PreModifier1 = grdOCS0205.GetItemString(i, "pre_modifier1");
                    item.PreModifier2 = grdOCS0205.GetItemString(i, "pre_modifier2");
                    item.PreModifier3 = grdOCS0205.GetItemString(i, "pre_modifier3");
                    item.PreModifier4 = grdOCS0205.GetItemString(i, "pre_modifier4");
                    item.PreModifier5 = grdOCS0205.GetItemString(i, "pre_modifier5");
                    item.PreModifier6 = grdOCS0205.GetItemString(i, "pre_modifier6");
                    item.PreModifier7 = grdOCS0205.GetItemString(i, "pre_modifier7");
                    item.PreModifier8 = grdOCS0205.GetItemString(i, "pre_modifier8");
                    item.PreModifier9 = grdOCS0205.GetItemString(i, "pre_modifier9");
                    item.PreModifier10 = grdOCS0205.GetItemString(i, "pre_modifier10");
                    item.PreModifierName = grdOCS0205.GetItemString(i, "pre_modifier_name");
                    item.PostModifier1 = grdOCS0205.GetItemString(i, "post_modifier1");
                    item.PostModifier2 = grdOCS0205.GetItemString(i, "post_modifier2");
                    item.PostModifier3 = grdOCS0205.GetItemString(i, "post_modifier3");
                    item.PostModifier4 = grdOCS0205.GetItemString(i, "post_modifier4");
                    item.PostModifier5 = grdOCS0205.GetItemString(i, "post_modifier5");
                    item.PostModifier6 = grdOCS0205.GetItemString(i, "post_modifier6");
                    item.PostModifier7 = grdOCS0205.GetItemString(i, "post_modifier7");
                    item.PostModifier8 = grdOCS0205.GetItemString(i, "post_modifier8");
                    item.PostModifier9 = grdOCS0205.GetItemString(i, "post_modifier9");
                    item.PostModifier10 = grdOCS0205.GetItemString(i, "post_modifier10");
                    item.PostModifierName = grdOCS0205.GetItemString(i, "post_modifier_name");

                    item.DataRowState = grdOCS0205.GetRowState(i).ToString();
                    lstResult.Add(item);
                }
            }

            // Delete
            if (null != grdOCS0205.DeletedRowTable)
            {
                foreach (DataRow dr in grdOCS0205.DeletedRowTable.Rows)
                {
                    OcsaOCS0204U00GrdOCS0205ListInfo item = new OcsaOCS0204U00GrdOCS0205ListInfo();
                    item.Memb = Convert.ToString(dr["memb"]);
                    item.SangGubun = Convert.ToString(dr["sang_gubun"]);
                    item.PkSeq = Convert.ToString(dr["pk_seq"]);
                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        #endregion

    }

    #region Enum SetMode

    internal enum SetMode
    {
        UserMode,        // 사용자를 선택한경우
        DoctorMode,      // 사용자중 의사를 선택한 경우
        NurseMode,       // 사용자중 간호사를 선택한 경우
        GwaMode,         // 진료과를 선택한경우
        HospitalMode     // 병원을 선택한경우
    }

    #endregion
}


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
	/// OCS0131U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0131U00 : IHIS.Framework.XScreen
	{
		string mbxMsg = "", mbxCap = "";

		bool isgrdOCS0131Save = false;
		bool isSaved0131 = false;
		bool isgrdOCS0132Save = false;
		bool isSaved0132 = false;

        string mHospCode = EnvironInfo.HospCode;

		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리
		
		private Hashtable mHtControl = null; // Control과 연결할 HashTable //

		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlLeft;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XFlatLabel xFlatLabel1;	
		private IHIS.Framework.XMstGrid grdOCS0131;
		private IHIS.Framework.XEditGrid grdOCS0132;
		private IHIS.Framework.XFindBox fbxCode_Type;
		private IHIS.Framework.XDisplayBox dbxCode_Type_Name;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCellcode_type;
		private IHIS.Framework.XEditGridCell xEditGridCellcode_type_name;
		private IHIS.Framework.XEditGridCell xEditGridCellment;
		private IHIS.Framework.XEditGridCell xEditGridCellcode;
		private IHIS.Framework.XEditGridCell xEditGridCellcode_name;
		private IHIS.Framework.XEditGridCell xEditGridCellsort_key;
		private IHIS.Framework.XEditGridCell xEditGridCellgroup_key;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
        private XFindWorker fwkCode;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0131U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                    // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                   // OCS 그룹 Function 라이브러리
		
            // TODO comment use connect cloud
			/*SaveLayoutList.Add(grdOCS0131);
			SaveLayoutList.Add(grdOCS0132);

			grdOCS0131.SavePerformer = new XSavePerformer(this);
			grdOCS0132.SavePerformer = grdOCS0131.SavePerformer;*/

            // Create ParamList and ExecuteQuery
            fwkCode.ParamList = new List<string>(new String[] {"f_find1"});
		    fwkCode.ExecuteQuery = ExecuteQueryGetFwkCode;

            grdOCS0131.ParamList = new List<string>(new String[] { "f_code_type" });
		    grdOCS0131.ExecuteQuery = ExecuteQueryGrdOCS0131;

            grdOCS0132.ParamList = new List<string>(new String[] { "f_code_type" });
		    grdOCS0132.ExecuteQuery = ExecuteQueryGrdOCS0132;
            if(NetInfo.Language != LangMode.Jr)
            {
                xFlatLabel1.Font = new Font("Arial", (float)8.75);
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0131U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.dbxCode_Type_Name = new IHIS.Framework.XDisplayBox();
            this.fbxCode_Type = new IHIS.Framework.XFindBox();
            this.fwkCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdOCS0131 = new IHIS.Framework.XMstGrid();
            this.xEditGridCellcode_type = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellcode_type_name = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellment = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdOCS0132 = new IHIS.Framework.XEditGrid();
            this.xEditGridCellcode = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellcode_name = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellsort_key = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellgroup_key = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0131)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0132)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlTop.Controls.Add(this.xFlatLabel1);
            this.pnlTop.Controls.Add(this.dbxCode_Type_Name);
            this.pnlTop.Controls.Add(this.fbxCode_Type);
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.AccessibleDescription = null;
            this.xFlatLabel1.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.Name = "xFlatLabel1";
            // 
            // dbxCode_Type_Name
            // 
            this.dbxCode_Type_Name.AccessibleDescription = null;
            this.dbxCode_Type_Name.AccessibleName = null;
            resources.ApplyResources(this.dbxCode_Type_Name, "dbxCode_Type_Name");
            this.dbxCode_Type_Name.Image = null;
            this.dbxCode_Type_Name.Name = "dbxCode_Type_Name";
            // 
            // fbxCode_Type
            // 
            this.fbxCode_Type.AccessibleDescription = null;
            this.fbxCode_Type.AccessibleName = null;
            resources.ApplyResources(this.fbxCode_Type, "fbxCode_Type");
            this.fbxCode_Type.BackgroundImage = null;
            this.fbxCode_Type.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxCode_Type.FindWorker = this.fwkCode;
            this.fbxCode_Type.Name = "fbxCode_Type";
            this.fbxCode_Type.FindClick += new System.ComponentModel.CancelEventHandler(this.Control_FindClick);
            // 
            // fwkCode
            // 
            this.fwkCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCode.ExecuteQuery = null;
            this.fwkCode.FormText = global::IHIS.OCSA.Properties.Resources.FWKCODE_FORMTEXT;
            this.fwkCode.IsSetControlText = true;
            this.fwkCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCode.ParamList")));
            this.fwkCode.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkCode.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code_type";
            this.findColumnInfo1.ColWidth = 172;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_type_name";
            this.findColumnInfo2.ColWidth = 332;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // pnlLeft
            // 
            this.pnlLeft.AccessibleDescription = null;
            this.pnlLeft.AccessibleName = null;
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.BackgroundImage = null;
            this.pnlLeft.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlLeft.Controls.Add(this.grdOCS0131);
            this.pnlLeft.DrawBorder = true;
            this.pnlLeft.Font = null;
            this.pnlLeft.Name = "pnlLeft";
            // 
            // grdOCS0131
            // 
            resources.ApplyResources(this.grdOCS0131, "grdOCS0131");
            this.grdOCS0131.ApplyAutoInsertion = true;
            this.grdOCS0131.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCellcode_type,
            this.xEditGridCellcode_type_name,
            this.xEditGridCellment,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdOCS0131.ColPerLine = 2;
            this.grdOCS0131.ColResizable = true;
            this.grdOCS0131.Cols = 2;
            this.grdOCS0131.ExecuteQuery = null;
            this.grdOCS0131.FixedRows = 1;
            this.grdOCS0131.HeaderHeights.Add(21);
            this.grdOCS0131.Name = "grdOCS0131";
            this.grdOCS0131.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0131.ParamList")));
            this.grdOCS0131.Rows = 2;
            this.grdOCS0131.ToolTipActive = true;
            this.grdOCS0131.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0131_GridColumnChanged);
            this.grdOCS0131.Enter += new System.EventHandler(this.grdOCS0131_Enter);
            this.grdOCS0131.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0131_RowFocusChanged);
            this.grdOCS0131.ProcessKeyDown += new System.Windows.Forms.KeyEventHandler(this.grdOCS0131_ProcessKeyDown);
            this.grdOCS0131.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdOCS0131.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0131_GridCellPainting);
            this.grdOCS0131.GridCellFocusChanged += new IHIS.Framework.XGridCellFocusChangedEventHandler(this.grdOCS0131_GridCellFocusChanged);
            this.grdOCS0131.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS0131_GridColumnProtectModify);
            this.grdOCS0131.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0131_QueryStarting);
            // 
            // xEditGridCellcode_type
            // 
            this.xEditGridCellcode_type.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCellcode_type.ApplyPaintingEvent = true;
            this.xEditGridCellcode_type.CellLen = 30;
            this.xEditGridCellcode_type.CellName = "code_type";
            this.xEditGridCellcode_type.CellWidth = 121;
            this.xEditGridCellcode_type.Col = -1;
            this.xEditGridCellcode_type.ExecuteQuery = null;
            this.xEditGridCellcode_type.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCellcode_type, "xEditGridCellcode_type");
            this.xEditGridCellcode_type.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellcode_type.IsNotNull = true;
            this.xEditGridCellcode_type.IsUpdatable = false;
            this.xEditGridCellcode_type.IsVisible = false;
            this.xEditGridCellcode_type.Row = -1;
            this.xEditGridCellcode_type.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCellcode_type_name
            // 
            this.xEditGridCellcode_type_name.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCellcode_type_name.CellLen = 100;
            this.xEditGridCellcode_type_name.CellName = "code_type_name";
            this.xEditGridCellcode_type_name.CellWidth = 242;
            this.xEditGridCellcode_type_name.ExecuteQuery = null;
            this.xEditGridCellcode_type_name.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCellcode_type_name, "xEditGridCellcode_type_name");
            this.xEditGridCellcode_type_name.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            this.xEditGridCellcode_type_name.IsReadOnly = true;
            this.xEditGridCellcode_type_name.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCellment
            // 
            this.xEditGridCellment.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCellment.AutoInsertAtEnterKey = true;
            this.xEditGridCellment.CellLen = 200;
            this.xEditGridCellment.CellName = "ment";
            this.xEditGridCellment.CellWidth = 179;
            this.xEditGridCellment.Col = 1;
            this.xEditGridCellment.ExecuteQuery = null;
            this.xEditGridCellment.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCellment, "xEditGridCellment");
            this.xEditGridCellment.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            this.xEditGridCellment.IsReadOnly = true;
            this.xEditGridCellment.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "choice_user";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellLen = 8;
            this.xEditGridCell5.CellName = "user_id";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlFill.Controls.Add(this.grdOCS0132);
            this.pnlFill.DrawBorder = true;
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            // 
            // grdOCS0132
            // 
            resources.ApplyResources(this.grdOCS0132, "grdOCS0132");
            this.grdOCS0132.ApplyAutoInsertion = true;
            this.grdOCS0132.CallerID = '2';
            this.grdOCS0132.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCellcode,
            this.xEditGridCellcode_name,
            this.xEditGridCellsort_key,
            this.xEditGridCellgroup_key,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell13,
            this.xEditGridCell12});
            this.grdOCS0132.ColPerLine = 4;
            this.grdOCS0132.ColResizable = true;
            this.grdOCS0132.Cols = 4;
            this.grdOCS0132.ExecuteQuery = null;
            this.grdOCS0132.FixedRows = 1;
            this.grdOCS0132.HeaderHeights.Add(19);
            this.grdOCS0132.MasterLayout = this.grdOCS0131;
            this.grdOCS0132.Name = "grdOCS0132";
            this.grdOCS0132.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0132.ParamList")));
            this.grdOCS0132.Rows = 2;
            this.grdOCS0132.ToolTipActive = true;
            this.grdOCS0132.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0132_GridColumnChanged);
            this.grdOCS0132.Enter += new System.EventHandler(this.grdOCS0132_Enter);
            this.grdOCS0132.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0132_RowFocusChanged);
            this.grdOCS0132.ProcessKeyDown += new System.Windows.Forms.KeyEventHandler(this.grdOCS0132_ProcessKeyDown);
            this.grdOCS0132.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.grdOCS0132.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0132_GridCellPainting);
            this.grdOCS0132.GridCellFocusChanged += new IHIS.Framework.XGridCellFocusChangedEventHandler(this.grdOCS0132_GridCellFocusChanged);
            this.grdOCS0132.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS0132_GridColumnProtectModify);
            this.grdOCS0132.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0132_QueryStarting);
            // 
            // xEditGridCellcode
            // 
            this.xEditGridCellcode.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCellcode.ApplyPaintingEvent = true;
            this.xEditGridCellcode.CellLen = 30;
            this.xEditGridCellcode.CellName = "code";
            this.xEditGridCellcode.CellWidth = 59;
            this.xEditGridCellcode.ExecuteQuery = null;
            this.xEditGridCellcode.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCellcode, "xEditGridCellcode");
            this.xEditGridCellcode.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellcode.IsNotNull = true;
            this.xEditGridCellcode.IsUpdatable = false;
            this.xEditGridCellcode.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCellcode_name
            // 
            this.xEditGridCellcode_name.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCellcode_name.CellLen = 100;
            this.xEditGridCellcode_name.CellName = "code_name";
            this.xEditGridCellcode_name.CellWidth = 188;
            this.xEditGridCellcode_name.Col = 1;
            this.xEditGridCellcode_name.ExecuteQuery = null;
            this.xEditGridCellcode_name.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCellcode_name, "xEditGridCellcode_name");
            this.xEditGridCellcode_name.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            this.xEditGridCellcode_name.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCellsort_key
            // 
            this.xEditGridCellsort_key.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCellsort_key.CellName = "sort_key";
            this.xEditGridCellsort_key.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCellsort_key.CellWidth = 86;
            this.xEditGridCellsort_key.Col = 2;
            this.xEditGridCellsort_key.ExecuteQuery = null;
            this.xEditGridCellsort_key.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCellsort_key, "xEditGridCellsort_key");
            this.xEditGridCellsort_key.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCellgroup_key
            // 
            this.xEditGridCellgroup_key.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCellgroup_key.CellLen = 30;
            this.xEditGridCellgroup_key.CellName = "group_key";
            this.xEditGridCellgroup_key.CellWidth = 75;
            this.xEditGridCellgroup_key.Col = -1;
            this.xEditGridCellgroup_key.ExecuteQuery = null;
            this.xEditGridCellgroup_key.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCellgroup_key, "xEditGridCellgroup_key");
            this.xEditGridCellgroup_key.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCellgroup_key.IsUpdatable = false;
            this.xEditGridCellgroup_key.IsUpdCol = false;
            this.xEditGridCellgroup_key.IsVisible = false;
            this.xEditGridCellgroup_key.Row = -1;
            this.xEditGridCellgroup_key.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.AutoInsertAtEnterKey = true;
            this.xEditGridCell10.CellLen = 200;
            this.xEditGridCell10.CellName = "ment";
            this.xEditGridCell10.CellWidth = 111;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellName = "value_point";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellLen = 8;
            this.xEditGridCell13.CellName = "user_id";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellLen = 30;
            this.xEditGridCell12.CellName = "code_type";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // pnlBottom
            // 
            this.pnlBottom.AccessibleDescription = null;
            this.pnlBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.BackgroundImage = null;
            this.pnlBottom.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Font = null;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // OCS0131U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = null;
            this.Name = "OCS0131U00";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0131)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0132)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [메소드 모듈]

		#region HashTable과 연결할 Control's Setting (SetHashTableBinding)
		/// <summary>
		/// HashTable과 연결할 Control's Setting
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="aHt"> HashTable 해당 Object </param>
		/// <param name="aObj"> object 해당 Object </param>
		/// <returns> void </returns>
		private void SetHashTableBinding(Hashtable aHt, object aObj)
		{
			if (aObj == null) return;

			if (aHt == null) aHt = new Hashtable();

			try
			{
				if (aObj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XComboBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XComboBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XComboBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XComboBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XComboBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XComboBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XComboBox)aObj).SelectedIndexChanged += new System.EventHandler(this.Control_SelectedIndexChanged);
				}
				else if (aObj.GetType().Name.ToString().IndexOf("XListBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XListBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XListBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XListBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XListBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XListBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XListBox)aObj).SelectedIndexChanged += new System.EventHandler(this.Control_SelectedIndexChanged);
				}
				else if(aObj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XTextBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XTextBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XTextBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XTextBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XTextBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XTextBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
				{						
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XEditMask)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XEditMask)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XEditMask)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XEditMask)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XEditMask)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XEditMask)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().ToString().IndexOf("XCheckBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XCheckBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XCheckBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XCheckBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XCheckBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XCheckBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XCheckBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XCheckBox)aObj).CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
				}
				else if(aObj.GetType().ToString().IndexOf("XRadioButton") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XRadioButton)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XRadioButton)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XRadioButton)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XRadioButton)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XRadioButton)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XRadioButton)aObj).CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
				}
				else if(aObj.GetType().ToString().IndexOf("XDatePicker") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XDatePicker)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XDatePicker)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XDatePicker)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XDatePicker)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XDatePicker)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XDatePicker)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XDisplayBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XDisplayBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XDisplayBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XDisplayBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XDisplayBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XDisplayBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().ToString().IndexOf("XMemoBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XMemoBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XMemoBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XMemoBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XMemoBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XMemoBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XMemoBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().ToString().IndexOf("XFindBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XFindBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XFindBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XFindBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XFindBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XFindBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XFindBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XFindBox)aObj).FindClick += new System.ComponentModel.CancelEventHandler(this.Control_FindClick);
					((XFindBox)aObj).FindSelected += new IHIS.Framework.FindEventHandler(this.Control_FindSelected);
				}

			}
			catch(Exception ex)
			{
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.Message, "HashTable Binding Error");
			}			
		}
		#endregion

		#region Row Insert시 Insert 가능여부 체크 (IsInsertRowEanbled)
		/// <summary>
		/// Row Insert시 Insert 가능여부 체크
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="aGrd"> XEditGrid  </param>
		/// <param name="aInsertRow"> int Insert Row </param>
		/// <returns> bool </returns>
		private bool IsInsertRowEanbled(XEditGrid aGrd, int aInsertRow)
		{
			if (aGrd == null) return false;

			string mbxMsg = "", mbxCap = "";

			if (aGrd == this.grdOCS0131) // Master
			{
			}
			else if (aGrd == this.grdOCS0132) // Detail
			{
				if (this.grdOCS0131.RowCount == 0 || 
					TypeCheck.IsNull(this.grdOCS0131.GetItemValue(this.grdOCS0131.CurrentRowNumber, "code_type")))
				{
					mbxMsg = Resources.MSG001_MSG;
					mbxCap = Resources.MSG001_CAP;

					XMessageBox.Show(mbxMsg, mbxCap, 2);

					return false;
				}
			}

			return true;
		}
		#endregion

		#region Row Delete시 Delete 가능여부 체크 (IsDeleteRowEanbled)
		/// <summary>
		/// Row Delete시 Delete 가능여부 체크
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="aGrd"> XEditGrid  </param>
		/// <param name="aDeleteRow"> int Delete Row </param>
		/// <returns> bool </returns>
		private bool IsDeleteRowEanbled(XEditGrid aGrd, int aDeleteRow)
		{
			if (aGrd == null || (aDeleteRow < 0 || aDeleteRow >= aGrd.RowCount)) return false;

			string mbxMsg = "", mbxCap = "";

			if (aGrd == this.grdOCS0131) // Master
			{
				// Detail 존재여부 체크 (**Master/Detail관계인 경우 FrameWork에선 Table Select하여 존재여부 체크를 한다(SetRelationTable..))
				if (this.grdOCS0132.RowCount > 0) 
				{					
					mbxMsg = Resources.MSG002_MSG;
					mbxMsg = String.Format(mbxMsg, aGrd.GetItemString(aGrd.CurrentRowNumber, "code_type"));
					mbxCap = Resources.MSG002_CAP;

					XMessageBox.Show(mbxMsg, mbxCap, 2);
					
					return false;
				}
			}
			else if (aGrd == this.grdOCS0132) // Detail
			{

			}

			return true;
		}
		#endregion

		#endregion

		#region [Screen Event]

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
			this.PostLoad();
		}

		/// <summary>
		/// Screen Load시 Post Event로 Call 되서 Load시 처리할 로직들을 기술한다
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <returns> void </returns>
		private void PostLoad()
		{	
			//Set Current Grid
			this.CurrMSLayout = this.grdOCS0131; this.CurrMQLayout = this.grdOCS0131;
 
			// HashTable과 연결할 Control's Setting
			foreach(object obj in this.pnlTop.Controls)
			{
				this.SetHashTableBinding(this.mHtControl, obj);
			}

			// Master/Detail Key 
			this.grdOCS0132.SetRelationTable("OCS0132");
			this.grdOCS0132.SetRelationKey("code_type", "code_type");

			// 전체 데이타 조회
			this.btnList.PerformClick(FunctionType.Query);

			// 첫번째 Focus Control 세팅
			this.fbxCode_Type.Focus();
		}
		#endregion

		#region [ButtonList Event]

		#region buttonList ButtonList 클릭 Event : Find SQL조건 및 필드 정의 (btnList_ButtonClick)
		/// <remarks>
		/// </remarks>
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Reset: // 화면 Reset

					break;

				case FunctionType.Query: // 조회

					break;

                case FunctionType.Insert: // 입력

                    if (this.CurrMQLayout == this.grdOCS0131)
                    {
                        e.IsBaseCall = false;
                        return;
                    }

					// ReadOnly인 경우는 처리불가
					if (((XEditGrid)this.CurrMSLayout).ReadOnly) {e.IsSuccess  = false;	e.IsBaseCall = false; break;}

					// Key입력(F5..)으로도 버튼클릭이 가능하므로, 최종 에디트중인 데이타 있으면 Aceept해야함
					if (!this.AcceptData()) {e.IsSuccess  = false; e.IsBaseCall = false; break;}

					// Insert한 Row 중에 Not Null필드 미입력 Row Search 하여 해당 Row로 이동
					XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.CurrMSLayout);

					if (emptyNewCell != null) 
					{
						e.IsSuccess  = false;
						e.IsBaseCall = false;                                     
						((XEditGrid)this.CurrMSLayout).SetFocusToItem(emptyNewCell.Row, emptyNewCell.CellName);
						break;
					}

					// Insert 가능여부 체크 
					if (!this.IsInsertRowEanbled(((XEditGrid)this.CurrMSLayout), ((XEditGrid)this.CurrMSLayout).CurrentRowNumber))
					{
						e.IsSuccess  = false;
						e.IsBaseCall = false; 
						break;		 
					}

					break;

				case FunctionType.Delete: // 삭제

                    if (this.CurrMQLayout == this.grdOCS0131)
                    {
                        e.IsBaseCall = false;
                        return;
                    }

					// ReadOnly인 경우는 처리불가
					if (((XEditGrid)this.CurrMSLayout).ReadOnly) {e.IsSuccess  = false;	e.IsBaseCall = false; break;}

					// Delete 가능여부 체크 
					if (!this.IsDeleteRowEanbled(((XEditGrid)this.CurrMSLayout), ((XEditGrid)this.CurrMSLayout).CurrentRowNumber))
					{
						e.IsSuccess  = false;
						e.IsBaseCall = false;
						break;		 
					}

					break;

				case FunctionType.Update: // 저장

					// InsertRow나 저장의 경우 BaseCall로 FrameWork에서 저장하지 않고 직접 로직을 기술하는 경우
					// 반드시 처리전에 AcceptData()를 Call해서, 최종Control Value Check를 해야함.
					// 유저가 버튼클릭(Focus이동)에 의하지 않고, 평션키로 로직수행하는 경우 최종 에디트 데이타 반영안됨
					// e.IsBaseCall = false;
					//if (!this.AcceptData()) {e.IsSuccess  = false; e.IsBaseCall = false; break;}					
					//if (!this.DataServiceCall(this.dsvSave)) e.IsSuccess = false;

                    // Update 
			        e.IsSuccess = OCS0131U00SaveLayOut();
                    isgrdOCS0131Save = e.IsSuccess;
                    isSaved0131 = true;
                    isgrdOCS0132Save = e.IsSuccess;
                    isSaved0132 = true;

                    if (isSaved0131 && isSaved0132 )
                    {
                        if (isgrdOCS0131Save && isgrdOCS0132Save && checkValidate())
                        {
                            mbxMsg = Resources.MSG007_MSG;
                            mbxCap = Resources.MSG001_CAP;
                            XMessageBox.Show(mbxMsg, mbxCap);
                            grdOCS0131.ResetUpdate();
                            grdOCS0132.ResetUpdate();
                        }
                        else
                        {
                            mbxMsg = Resources.MSG008_MSG + "\n\r" + Resources.MSG009_MSG;
//                            mbxMsg += "\r\n[" + e.ErrMsg + "]";
                            mbxCap = Resources.MSG001_CAP;
                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Hand);
                        }

                        isgrdOCS0131Save = false;
                        isSaved0131 = false;
                        isgrdOCS0132Save = false;
                        isSaved0132 = false;
                    }

					break;

				default:
					break;
			}

		}
		#endregion

		#region buttonList ButtonList 클릭 성공 이후 Event : 작업성공시 처리 로직을 기술한다 (btnList_PostButtonClick)
		/// <remarks>
		/// Insert Row후에 디폴트값 세팅등.. 버튼리스트 작업후 기술사항을 기술한다
		/// </remarks>
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{

				case FunctionType.Query: // 조회

					break;

				case FunctionType.Insert: // 입력 

					// 입력후 Default값 세팅할 경우가 있는 경우 여기서 기술한다

					break;

				case FunctionType.Delete: // 삭제

					break;

				case FunctionType.Update: // 저장

					break;

				default:
					break;
			}		
		}
		#endregion
	
		#endregion

		#region [Control's Event]
		
		#region Control Get Focus시 구동 Event (Control_Enter)
		/// <remarks>
		/// Binding된 Grid가 있는 경우 Current Grid 세팅등도 해야함
		/// </remarks>
		private void Control_Enter(object sender, System.EventArgs e)
		{
			if (sender == null) return;
		}
		#endregion

		#region Control Lost Focus시 구동 Event (Control_Leave)
		/// <remarks>
		/// </remarks>
		private void Control_Leave(object sender, System.EventArgs e)
		{
			if (sender == null) return;
		}
		#endregion

		#region Control Value변경시 처리 Event (Control_DataValidating)
		/// <remarks>
		/// Binding된 Grid가 있는 경우 Current Grid 세팅등도 해야함
		/// </remarks>
		private void Control_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{	
			if (sender == null) return;

			string mbxMsg = "", mbxCap = "";

			string colName = this.mOrderFunc.GetHashTableColumnName(sender); // 현재 매핑되는 컬럼명을 얻어온다

			string dataValue = e.DataValue.ToString().Trim();

			switch (colName)
			{
				case "code_type": // 코드타입

					// 각종기준정보에서 코드타입명칭을 얻어온다
					if (TypeCheck.IsNull(dataValue) || dataValue == "%") 
					{
						this.dbxCode_Type_Name.SetDataValue("");
					}
					else 
					{
						DataRow dRow = this.mOrderBiz.LoadOcs0131Info(dataValue);

						if (dRow != null)
						{
							this.dbxCode_Type_Name.SetDataValue(dRow["code_type_name"]);
						}
						else
						{
							mbxMsg = Resources.MSG003_MSG;
							mbxCap = Resources.MSG001_CAP;
							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);

							e.Cancel = true;

							return;							
						}
					}

					// 입력 코드로 데이타 조회
					grdOCS0131.QueryLayout(false);

					break;

				default:
					break;
			}
		}
		#endregion

		#region Control 더블클릭시 구동 Event (Control_DoubleClick)
		/// <remarks>
		/// </remarks>
		private void Control_DoubleClick(object sender, System.EventArgs e)
		{
			if (sender == null) return;
		}
		#endregion

		#region Control KeyDown Event (Control_KeyPress)
		/// <remarks>
		/// </remarks>
		private void Control_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (sender == null) return;		
		}
		#endregion

		#region Control Keyup Event (Control_KeyPress)
		/// <remarks>
		/// </remarks>
		private void Control_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (sender == null) return;		
		}
		#endregion

		#region Combo Control SelectIndexChanged시 구동 Event (Control_SelectedIndexChanged)
		/// <remarks>
		/// </remarks>
		private void Control_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (sender == null || (sender.GetType().Name.ToString().IndexOf("XComboBox") < 0 && sender.GetType().Name.ToString().IndexOf("XListBox") < 0)) return;
		}
		#endregion

		#region Check Control Check Changed시 구동 Event (Control_CheckedChanged)
		/// <remarks>
		/// </remarks>
		private void Control_CheckedChanged(object sender, System.EventArgs e)
		{
			if (sender == null || sender.GetType().Name.ToString().IndexOf("XCheckBox") < 0) return;
		}
		#endregion

		#region Find Control FindClick Event : Find SQL조건 및 필드 정의 (Control_FindClick)
		/// <remarks>
		/// </remarks>
		private void Control_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (sender == null || sender.GetType().Name.ToString().IndexOf("XFindBox") < 0) return;

            //XFindBox fbx = sender as XFindBox;

            //string colName = this.mOrderFunc.GetHashTableColumnName(sender);

            //fbx.FindWorker = this.mOrderBiz.GetFindWorker(colName); // 컬럼별 Find 정보 얻기
		}
		#endregion

		#region Find Control FindSelected Event : Find 데이타 선택시 Value 세팅.. (Control_FindSelected)
		private void Control_FindSelected(object sender, IHIS.Framework.FindEventArgs e)
		{
			if (sender == null || sender.GetType().Name.ToString().IndexOf("XFindBox") < 0) return;

			XFindBox fbx = sender as XFindBox;

			string colName = this.mOrderFunc.GetHashTableColumnName(sender);

			fbx.AcceptData(); // DataValidating Event에서 선택한 값에 대한 Validation / 정보 세팅 로직 처리함 		
		}
		#endregion

		#endregion

		#region [Master Grid Event]

		#region Focus 진입시 (Enter)
		/// <remarks>
		/// 빈 Grid시 New Row Insert
		/// </remarks>
		private void grdOCS0131_Enter(object sender, System.EventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;

			//Set Current Grid
			this.CurrMSLayout = grd; this.CurrMQLayout = grd;

			// 빈 Grid시 New Row Insert
			if (grd.RowCount == 0) this.btnList.PerformClick(FunctionType.Insert); // <= ButtonList 클릭 : 추후 PostEvent로 바꿀에정임.(사용자 클릭시 바로 Edit상태가 안되므로..)
		}
		#endregion

		#region 컬럼 Focus 이동시 (GridCellFocusChanged)	
		/// <remarks>
		/// 컬럼 Focus시 디폴트 값이나, 특정 컬럼이 미리 입력이 되어 있어야 되는 경우등 처리..
		/// </remarks>
		private void grdOCS0131_GridCellFocusChanged(object sender, IHIS.Framework.XGridCellFocusChangedEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;
		}
		#endregion

		#region Row 이동시 (RowFocusChanged)
		/// <remarks>
		/// </remarks>
		private void grdOCS0131_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;		
		}
		#endregion

		#region 컬럼 값 변경시 (GridColumnChanged)
		/// <remarks>
		/// Validation Check, 추가 정보 세팅..
		/// </remarks>
		private void grdOCS0131_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			string mbxMsg = "", mbxCap = "";

			object previousValue = grd.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value

			switch (e.ColName)
			{
				case "code_type": // 코드형태
					string code_type = e.ChangeValue.ToString().Trim();

					if (TypeCheck.IsNull(code_type)) break;

					// 각종기준정보에서 코드타입명칭을 얻어온다 (기존 데이타 여부 확인)
					DataRow dRow = this.mOrderBiz.LoadOcs0131Info(code_type);

					if (dRow != null)
					{
						mbxMsg = Resources.MSG004_MSG;
						mbxMsg = String.Format(mbxMsg, code_type);
						mbxCap = Resources.MSG001_CAP;
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);

						e.Cancel = true;

						return;
					}

					break;

				default:
					break;
			}
		}
		#endregion

		#region 필드 Protect관리 Event(GridColumnProtectModify)
		/// <remarks>
		/// 로직으로 수정불가 필드 정의
		/// </remarks>
		private void grdOCS0131_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;		
		}
		#endregion

		#region  필드 색상/폰트 관리 Event  (GridCellPainting)
		/// <remarks>
		/// 로직으로 필드 색상 변경
		/// </remarks>
		private void grdOCS0131_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			// 필드속성이 수정불가인 경우 BackColor를 회색으로 바꾸어 유저한테 입력불가상태임을 알린다
			if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable && 
				(grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified))
			{
				e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
				e.BackColor = XColor.XGridAlterateRowBackColor.Color;
			}

		}
		#endregion

		#region 특수Key Input시 (ProcessKeyDown)
		/// <remarks>
		/// Last Row에서 Key Down시 Insert Row처리
		/// </remarks>
		private void grdOCS0131_ProcessKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;

			if (grd.FocusCell == null) return;

			switch (e.KeyCode)
			{

				case Keys.Down: // Key Down 입력시 Last Row인 경우 Insert Row를 수행함
					/*----------------------------------------------------------------------------------------------------------------
					 * KeyDown 구동안됨.. 일단 보류.
										if (grd.CurrentRowNumber == (grd.RowCount -1))
										{
											// Insert한 Row 중에 Not Null필드 미입력 Row Search하여 미입력 데이타가 없는 경우 Insert
											if (this.GetEmptyNewRow((XEditGrid)this.CurrMSLayout) < 0)
											{		
												this.btnList.PerformClick(FunctionType.Insert);

												// Edit 상태
												PostCallHelper.PostCall(new PostMethod(grd.StartEdit));
											}
										}
					----------------------------------------------------------------------------------------------------------------*/
					break;
			}
		}
		#endregion

		#endregion

		#region [Detail Grid Event]

		#region Focus 진입시 (Enter)
		/// <remarks>
		/// 빈 Grid시 New Row Insert
		/// </remarks>
		private void grdOCS0132_Enter(object sender, System.EventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;		

			//Set Current Grid
			this.CurrMSLayout = grd; this.CurrMQLayout = grd;

			// 빈 Grid시 New Row Insert
			if (grd.RowCount == 0) this.btnList.PerformClick(FunctionType.Insert); // <= ButtonList 클릭 : 추후 PostEvent로 바꿀에정임.(사용자 클릭시 바로 Edit상태가 안되므로..)		
		}
		#endregion

		#region 컬럼 Focus 이동시 (GridCellFocusChanged)	
		/// <remarks>
		/// 컬럼 Focus시 디폴트 값이나, 특정 컬럼이 미리 입력이 되어 있어야 되는 경우등 처리..
		/// </remarks>
		private void grdOCS0132_GridCellFocusChanged(object sender, IHIS.Framework.XGridCellFocusChangedEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;
		}
		#endregion

		#region Row 이동시 (RowFocusChanged)
		/// <remarks>
		/// </remarks>
		private void grdOCS0132_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;		
		}
		#endregion

		#region 컬럼 값 변경시 (GridColumnChanged)
		/// <remarks>
		/// Validation Check, 추가 정보 세팅..
		/// </remarks>
		private void grdOCS0132_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{	
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			string mbxMsg = "", mbxCap = "";

			object previousValue = grd.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value

			if (this.grdOCS0131.RowCount == 0 || 
				TypeCheck.IsNull(this.grdOCS0131.GetItemValue(this.grdOCS0131.CurrentRowNumber, "code_type")))
			{
				mbxMsg = Resources.MSG005_MSG;
				mbxCap = Resources.MSG001_CAP;

				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);

				e.Cancel = true;
				return;
			}

			string code_type = this.grdOCS0131.GetItemValue(this.grdOCS0131.CurrentRowNumber, "code_type").ToString();

			switch (e.ColName)
			{
				case "code": // 코드
					string code = e.ChangeValue.ToString().Trim();
                    
					if (TypeCheck.IsNull(code)) break;

					// 각종기준정보에서 코드명칭을 얻어온다 (기존 데이타 여부 확인)
					DataRow dRow = this.mOrderBiz.LoadOcs0132Info(code_type, code);

					if (dRow != null)
					{
						mbxMsg = Resources.MSG006_MSG;
						mbxMsg = String.Format(mbxMsg, code);
						mbxCap = Resources.MSG001_CAP;
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);

						e.Cancel = true;

						return;
					}

					break;

				default:
					break;
			}

		}
		#endregion

		#region 필드 Protect관리 Event(GridColumnProtectModify)
		/// <remarks>
		/// 로직으로 수정불가 필드 정의
		/// </remarks>
		private void grdOCS0132_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;		
		}
		#endregion

		#region  필드 색상/폰트 관리 Event  (GridCellPainting)
		/// <remarks>
		/// 로직으로 필드 색상 변경
		/// </remarks>
		private void grdOCS0132_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			// 필드속성이 수정불가인 경우 BackColor를 회색으로 바꾸어 유저한테 입력불가상태임을 알린다
			if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable && 
				(grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified))
			{
				e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
				e.BackColor = XColor.XGridAlterateRowBackColor.Color;
			}
		}
		#endregion

		#region 특수Key Input시 (ProcessKeyDown)
		/// <remarks>
		/// Last Row에서 Key Down시 Insert Row처리
		/// </remarks>
		private void grdOCS0132_ProcessKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;		

		}
		#endregion

		#endregion

		#region [Query Event]
		private void grdOCS0131_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
            grdOCS0131.SetBindVarValue("f_code_type", this.fbxCode_Type.GetDataValue());
            grdOCS0131.SetBindVarValue("f_hosp_code", mHospCode);
		}

		private void grdOCS0132_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
            grdOCS0132.SetBindVarValue("f_code_type", grdOCS0131.GetItemString(grdOCS0131.CurrentRowNumber, "code_type"));
            grdOCS0132.SetBindVarValue("f_hosp_code", mHospCode);
		}
		#endregion

		#region[Save Event]
		private void SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
		{
			switch(e.CallerID)
			{
				case '1':
					isgrdOCS0131Save = e.IsSuccess;
					isSaved0131 = true;
					break;
				case '2':
					isgrdOCS0132Save = e.IsSuccess;
					isSaved0132 = true;
					break;
			}

			if(isSaved0131 && isSaved0132)
			{
				if(isgrdOCS0131Save && isgrdOCS0132Save)
				{
					mbxMsg = Resources.MSG007_MSG;
					mbxCap = Resources.MSG001_CAP;
					XMessageBox.Show(mbxMsg, mbxCap, 2);
				}
				else
				{
					mbxMsg = Resources.MSG008_MSG;
					mbxMsg += "\r\n[" + e.ErrMsg + "]";
					mbxCap = Resources.MSG001_CAP;
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Hand);
				}

				isgrdOCS0131Save = false;
				isSaved0131 = false;
				isgrdOCS0132Save = false;
				isSaved0132 = false;
			}
		}

        #endregion

        #region Connect to cloud service

        /// <summary>
        /// ExecuteQueryGetFwkCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGetFwkCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0131U00GetFwkCodeArgs vOCS0131U00GetFwkCodeArgs = new OCS0131U00GetFwkCodeArgs();
            vOCS0131U00GetFwkCodeArgs.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            OCS0131U00GetFwkCodeResult result = CloudService.Instance.Submit<OCS0131U00GetFwkCodeResult, OCS0131U00GetFwkCodeArgs>(vOCS0131U00GetFwkCodeArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ListItem)
                {
                    object[] objects = 
				{ 
					item.Code, 
					item.CodeName
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdOCS0131
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOCS0131(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0131U00GrdOCS0131Args vOCS0131U00GrdOCS0131Args = new OCS0131U00GrdOCS0131Args();
            vOCS0131U00GrdOCS0131Args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            OCS0131U00GrdOCS0131Result result = CloudService.Instance.Submit<OCS0131U00GrdOCS0131Result, OCS0131U00GrdOCS0131Args>(vOCS0131U00GrdOCS0131Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0131U00GrdOCS0131Info item in result.GrdOcs0131Info)
                {
                    object[] objects =
                    {
                        item.CodeType,
                        item.CodeTypeName,
                        item.Ment,
                        item.ChoiceUser,
                        item.UserId
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdOCS0132
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOCS0132(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0131U00GrdOCS0132Args vOCS0131U00GrdOCS0132Args = new OCS0131U00GrdOCS0132Args();
            vOCS0131U00GrdOCS0132Args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            OCS0131U00GrdOCS0132Result result = CloudService.Instance.Submit<OCS0131U00GrdOCS0132Result, OCS0131U00GrdOCS0132Args>(vOCS0131U00GrdOCS0132Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0131U00GrdOCS0132Info item in result.GrdOcs0132Info)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName,
                        item.SortKey,
                        item.GroupKey,
                        item.Ment,
                        item.ValuePoint,
                        item.UserId,
                        item.CodeType
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// OCS0131U00SaveLayOut
        /// </summary>
        /// <returns></returns>
        private bool OCS0131U00SaveLayOut()
        {
            OCS0131U00XSavePerformerArgs args = new OCS0131U00XSavePerformerArgs();
            args.Grdocs0131Info = CreateListGrd0131Item();
            args.Grdocs0132Info = CreateGrdOCS0132Item();
            args.UserId = UserInfo.UserID;
            if (!checkValidate())
            {
                return false;
            }
            else
            {
                UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, OCS0131U00XSavePerformerArgs>(args);
                if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                    updateResult.Result == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// CreateListGrd0131Item
        /// </summary>
        /// <returns></returns>
        private List<OCS0131U00GrdOCS0131Info> CreateListGrd0131Item()
        {
            List<OCS0131U00GrdOCS0131Info> listGrdOcs0131Info = new List<OCS0131U00GrdOCS0131Info>();
            for (int i = 0; i < grdOCS0131.RowCount; i++)
            {
                if (grdOCS0131.GetRowState(i) == DataRowState.Added ||
                    grdOCS0131.GetRowState(i) == DataRowState.Modified)
                {
                    OCS0131U00GrdOCS0131Info ocs0131Info = new OCS0131U00GrdOCS0131Info();
                    ocs0131Info.CodeType = grdOCS0131.GetItemString(i, "code_type");
                    ocs0131Info.CodeTypeName = grdOCS0131.GetItemString(i, "code_type_name");
                    ocs0131Info.Ment = grdOCS0131.GetItemString(i, "ment");
                    ocs0131Info.ChoiceUser = grdOCS0131.GetItemString(i, "choice_user");
                    //	                ocs0131Info.UserId = grdOCS0131.GetItemString(i, "user_id");
                    ocs0131Info.DataRowSate = grdOCS0131.GetRowState(i).ToString();

                    listGrdOcs0131Info.Add(ocs0131Info);
                }
            }

            if (grdOCS0131.DeletedRowTable != null || grdOCS0131.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdOCS0131.DeletedRowTable.Rows)
                {
                    OCS0131U00GrdOCS0131Info ocs0131Info = new OCS0131U00GrdOCS0131Info();
                    ocs0131Info.CodeType = row["code_type"].ToString();
                    ocs0131Info.CodeTypeName = row["code_type_name"].ToString();
                    ocs0131Info.Ment = row["ment"].ToString();
                    ocs0131Info.ChoiceUser = row["choice_user"].ToString();
                    //                    ocs0131Info.UserId = row["user_id"].ToString();
                    ocs0131Info.DataRowSate = DataRowState.Deleted.ToString();

                    listGrdOcs0131Info.Add(ocs0131Info);
                }

            }
            return listGrdOcs0131Info;
        }

        /// <summary>
        /// CreateGrdOCS0132Item
        /// </summary>
        /// <returns></returns>
        private List<OCS0131U00GrdOCS0132Info> CreateGrdOCS0132Item()
        {
            List<OCS0131U00GrdOCS0132Info> ListGrdOCS0132Item = new List<OCS0131U00GrdOCS0132Info>();
            for (int i = 0; i < grdOCS0132.RowCount; i++)
            {
                if (grdOCS0132.GetRowState(i) == DataRowState.Added || grdOCS0132.GetRowState(i) == DataRowState.Modified)
                {
                    OCS0131U00GrdOCS0132Info info = new OCS0131U00GrdOCS0132Info();
                    info.Code = grdOCS0132.GetItemString(i, "code");
                    info.CodeName = grdOCS0132.GetItemString(i, "code_name");
                    info.SortKey = grdOCS0132.GetItemString(i, "sort_key");
                    info.GroupKey = grdOCS0132.GetItemString(i, "group_key");
                    info.Ment = grdOCS0132.GetItemString(i, "ment");
                    info.ValuePoint = grdOCS0132.GetItemString(i, "value_point");
                    //                    info.UserId = grdOCS0132.GetItemString(i, "user_id");
                    info.CodeType = grdOCS0131.GetItemString(grdOCS0131.CurrentRowNumber, "code_type");
                    info.DataRowState = grdOCS0132.GetRowState(i).ToString();

                    ListGrdOCS0132Item.Add(info);
                }
            }
            if (grdOCS0132.DeletedRowTable != null && grdOCS0132.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdOCS0132.DeletedRowTable.Rows)
                {
                    OCS0131U00GrdOCS0132Info info = new OCS0131U00GrdOCS0132Info();
                    info.Code = row["code"].ToString();
                    info.CodeName = row["code_name"].ToString();
                    info.SortKey = row["sort_key"].ToString();
                    info.GroupKey = row["group_key"].ToString();
                    info.Ment = row["ment"].ToString();
                    info.ValuePoint = row["value_point"].ToString();
                    //	                info.UserId = row["user_id"].ToString();
                    info.CodeType = grdOCS0131.GetItemString(grdOCS0131.CurrentRowNumber, "code_type");
                    info.DataRowState = DataRowState.Deleted.ToString();

                    ListGrdOCS0132Item.Add(info);
                }
            }
            return ListGrdOCS0132Item;
        }
        #endregion
        private bool checkValidate()
        {
            List<OCS0131U00GrdOCS0131Info> lstItem = CreateListGrd0131Item();
            List<OCS0131U00GrdOCS0132Info> lstItem1 = CreateGrdOCS0132Item();
            foreach (OCS0131U00GrdOCS0131Info info in lstItem)
            {
                if (info.UserId == "")
                {
                    return false;
                }
                if (info.CodeType == "")
                {
                    return false;
                }
                if (info.CodeTypeName == "")
                {
                    return false;
                }
            }
            foreach (OCS0131U00GrdOCS0132Info info in lstItem1)
            {
                if (info.Code == "")
                {
                    return false;
                }
                if (info.CodeName == "")
                {
                    return false;
                }
                if (info.CodeType == "")
                {
                    return false;
                }
            }
            return true;

        }

        #region [XSavePerformer]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private OCS0131U00 parent = null;

			public XSavePerformer(OCS0131U00 parent)
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
						case DataRowState.Added:
							cmdText = @"INSERT INTO OCS0131 
								  	 	     ( SYS_DATE
                                             , SYS_ID
                                             , UPD_DATE
                                             , CODE_TYPE
                                             , CODE_TYPE_NAME
                                             , ADMIN_GUBUN
                                             , MENT
                                             , CHOICE_USER
                                             , HOSP_CODE  )
								 	    VALUES
                                             ( SYSDATE
                                             , :f_user_id
                                             , SYSDATE
                                             , :f_code_type
                                             , :f_code_type_name
                                             , 'USER'
                                             , :f_ment
                                             , :f_choice_user
                                             , :f_hosp_code )";
							break;
						case DataRowState.Modified:
                            cmdText = @"UPDATE OCS0131
                                           SET UPD_ID         = :f_user_id
                                             , UPD_DATE       = SYSDATE
                                             , CODE_TYPE_NAME = :f_code_type_name
                                             , MENT           = :f_ment
                                             , CHOICE_USER    = :f_choice_user
                                         WHERE CODE_TYPE      = :f_code_type
                                           AND HOSP_CODE      = :f_hosp_code";
							break;
						case DataRowState.Deleted:
							cmdText = "DELETE OCS0131"
								    +"  WHERE CODE_TYPE = :f_code_type"
                                    +"    AND HOSP_CODE = :f_hosp_code";
							break;
					}
						break;
					case '2':
					switch(item.RowState)
					{
						case DataRowState.Added:
                            cmdText = @"INSERT INTO OCS0132 
                                             ( SYS_DATE
                                             , SYS_ID
                                             , UPD_DATE
                                             , CODE_TYPE
                                             , CODE
                                             , CODE_NAME
                                             , SORT_KEY
                                             , GROUP_KEY
                                             , MENT
                                             , VALUE_POINT 
                                             , HOSP_CODE  ) 
                                        VALUES 
                                             ( SYSDATE
                                             , :f_user_id
                                             , SYSDATE
                                             , :f_code_type
                                             , :f_code
                                             , :f_code_name
                                             , TO_NUMBER(NVL(:f_sort_key,'0'))
                                             , :f_group_key
                                             , :f_ment
                                             , TO_NUMBER(NVL(:f_value_point,'0'))
                                             , :f_hosp_code)";
							break;
						case DataRowState.Modified:
							cmdText = @"UPDATE OCS0132 
                                           SET UPD_ID           = :f_user_id
                                             , UPD_DATE         = SYSDATE
                                             , CODE_NAME        = :f_code_name
                                             , SORT_KEY         = TO_NUMBER(NVL(:f_sort_key,'0'))
                                             , GROUP_KEY        = :f_group_key
                                             , MENT             = :f_ment
                                             , VALUE_POINT      = TO_NUMBER(NVL(:f_value_point,'0'))
                                         WHERE CODE_TYPE        = :f_code_type
                                           AND CODE             = :f_code";
							break;
						case DataRowState.Deleted:
							cmdText = "DELETE OCS0132"
							        +"	WHERE CODE_TYPE = :f_code_type"
							        +"	  AND CODE      = :f_code"
                                    +"    AND HOSP_CODE = :f_hosp_code";
							break;
					}
						break;
				}

				return Service.ExecuteNonQuery(cmdText,item.BindVarList);
			}
		}
		#endregion

    }
    
}


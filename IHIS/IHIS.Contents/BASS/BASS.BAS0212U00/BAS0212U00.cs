#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;

#endregion

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0212U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0212U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XFindBox fbxGongbi;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XDisplayBox dbxGongbiName;
		private IHIS.Framework.XDatePicker dtpJukyongDate;
		private IHIS.Framework.XEditGrid grdBAS0212;
		private IHIS.Framework.XFindWorker fwkGongbiCode;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.SingleLayout layGongbiCode;
        private IHIS.Framework.SingleLayout layDupCheck;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0212U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
		    InitializeComponent();
		    
		 
		    // this.grdBAS0212.SavePerformer = new XSavePeformer(this);
            //set ParamList
            this.grdBAS0212.ParamList = new List<string>(new String[] { "f_start_date" });
            this.layDupCheck.ParamList = new List<string>(new String[] { "f_start_date", "f_code" });
            this.fwkGongbiCode.ParamList = new List<string>(new String[] { "f_find1" });
            this.layGongbiCode.ParamList = new List<string>(new String[] { "f_code", "f_start_date", "gongbi_name"});
            //Exe
            this.grdBAS0212.ExecuteQuery = LoadDataGrd;
            this.layDupCheck.ExecuteQuery = LoadDataLayDupCheck;
            this.fwkGongbiCode.ExecuteQuery = LoadDataFwkGongbiCode;
            this.layGongbiCode.ExecuteQuery = loadGongbiName;
		}

        #region CloudServices

        private IList<object[]> LoadDataFwkGongbiCode(BindVarCollection bc)
	    {
            IList<object[]> lObj = new List<object[]>();

            BAS0212U00fwkGongbiCodeArgs args = new BAS0212U00fwkGongbiCodeArgs();
            args.StartDate = dtpJukyongDate.GetDataValue();
            args.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            BAS0212U00fwkGongbiCodeResult res = CloudService.Instance.Submit<BAS0212U00fwkGongbiCodeResult, BAS0212U00fwkGongbiCodeArgs>(args);

            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    res.Fwk.ForEach(delegate(BAS0212U00fwkGongbiCodeInfo item)
            //    {
            //        lObj.Add(new object[] { item.GongbiCode, item.GongbiName });
            //    });
            //}
            if (res != null && res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0212U00fwkGongbiCodeInfo item in res.Fwk)
                {
                    object[] objects =
                    {
                        item.GongbiCode,
                        item.GongbiName
                    };
                    lObj.Add(objects);
                }
            }
            return lObj;
	    }


	    private List<object[]> LoadDataGrd(BindVarCollection bc)
	    {
            List<object[]> res = new List<object[]>();
            BAS0212U00GrdItemArgs args = new BAS0212U00GrdItemArgs();
            args.StartDate = bc["f_start_date"] != null ? bc["f_start_date"].VarValue : "";
            args.GongbiCode = this.fbxGongbi.Text;
            BAS0212U00GrdItemResult result =
                CloudService.Instance.Submit<BAS0212U00GrdItemResult, BAS0212U00GrdItemArgs>(
                    args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0212U00GrdItemInfo item in result.GrdInit)
                {
                    object[] objects =
	                {
	                    item.GongbiCode,
	                    item.GongbiJiyeok,
	                    item.GongbiName,
	                    item.LawNo,
	                    item.StartDate,
	                    item.TotalYn,
	                    item.EndDate,
	                    
	                };
                    res.Add(objects);
                }
            }
            return res;
	    }
        private List<object[]> LoadDataLayDupCheck(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0212U00LaydupCheckArgs args = new BAS0212U00LaydupCheckArgs();

            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            args.StartDate = bc["f_start_date"].VarValue;
            BAS0212U00LaydupCheckResult result = CloudService.Instance.Submit<BAS0212U00LaydupCheckResult, BAS0212U00LaydupCheckArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.LayDupResult
                });
            }

            return res;
        }
        private List<object[]> loadGongbiName(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0212U00ListItemArgs args = new BAS0212U00ListItemArgs();

            args.Code = bc["f_code"] != null ? bc["f_code"].VarValue : "";
            args.StartDate = bc["f_start_date"].VarValue;
            BAS0212U00CListItemResult result = CloudService.Instance.Submit<BAS0212U00CListItemResult, BAS0212U00ListItemArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0212U00ListItemRequestInfo item  in result.ComboName)
                {
                    object[] objects =
                    {
                        item.GongbiName
                        
                    };
                    res.Add(objects);
                }
                
            }

            return res;


        }
        private bool SaveGrid()
        {

            List<BAS0212U00GrdItemInfo> inputList = GetListFromGrd();
            if (inputList.Count == 0)
            {
                return true;
            }
            BAS0212U00TransactionalArgs args = new BAS0212U00TransactionalArgs(inputList, UserInfo.UserID);
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, BAS0212U00TransactionalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }

            return false;
        }

        private List<BAS0212U00GrdItemInfo> GetListFromGrd()
        {
            List<BAS0212U00GrdItemInfo> dataList = new List<BAS0212U00GrdItemInfo>();
            for (int i = 0; i < grdBAS0212.RowCount; i++)
            {
                if (grdBAS0212.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                BAS0212U00GrdItemInfo info = new BAS0212U00GrdItemInfo();
                info.GongbiCode = grdBAS0212.GetItemString(i, "gongbi_code");
                info.GongbiName = grdBAS0212.GetItemString(i, "gongbi_name");
                info.GongbiJiyeok = grdBAS0212.GetItemString(i, "gongbi_jiyeok");
                info.LawNo = grdBAS0212.GetItemString(i, "law_no");
                info.TotalYn = grdBAS0212.GetItemString(i, "total_yn");
                info.StartDate = grdBAS0212.GetItemString(i, "start_date");
                info.EndDate = grdBAS0212.GetItemString(i, "end_date");
                info.RowState = grdBAS0212.GetRowState(i).ToString();

                dataList.Add(info);
            }

            if (grdBAS0212.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdBAS0212.DeletedRowTable.Rows)
                {
                    BAS0212U00GrdItemInfo info = new BAS0212U00GrdItemInfo();
                    info.GongbiCode = row["gongbi_code"].ToString();
                    info.StartDate = row["start_date"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }
            return dataList;
        }

        #endregion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0212U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxGongbiName = new IHIS.Framework.XDisplayBox();
            this.fbxGongbi = new IHIS.Framework.XFindBox();
            this.fwkGongbiCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpJukyongDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grdBAS0212 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.layGongbiCode = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layDupCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0212)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.dbxGongbiName);
            this.xPanel1.Controls.Add(this.fbxGongbi);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dtpJukyongDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.pictureBox1);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // dbxGongbiName
            // 
            this.dbxGongbiName.AccessibleDescription = null;
            this.dbxGongbiName.AccessibleName = null;
            resources.ApplyResources(this.dbxGongbiName, "dbxGongbiName");
            this.dbxGongbiName.Font = null;
            this.dbxGongbiName.Image = null;
            this.dbxGongbiName.Name = "dbxGongbiName";
            // 
            // fbxGongbi
            // 
            this.fbxGongbi.AccessibleDescription = null;
            this.fbxGongbi.AccessibleName = null;
            resources.ApplyResources(this.fbxGongbi, "fbxGongbi");
            this.fbxGongbi.BackgroundImage = null;
            this.fbxGongbi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxGongbi.FindWorker = this.fwkGongbiCode;
            this.fbxGongbi.Font = null;
            this.fbxGongbi.Name = "fbxGongbi";
            this.fbxGongbi.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxGongbi_DataValidating);
            this.fbxGongbi.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxGongbi_FindClick);
            // 
            // fwkGongbiCode
            // 
            this.fwkGongbiCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkGongbiCode.ExecuteQuery = null;
            this.fwkGongbiCode.FormText = global::IHIS.BASS.Resource.TEXT1;
            this.fwkGongbiCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkGongbiCode.ParamList")));
            this.fwkGongbiCode.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkGongbiCode.ServerFilter = true;
            this.fwkGongbiCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkGongbiCode_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.ColWidth = 84;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 340;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = null;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpJukyongDate
            // 
            this.dtpJukyongDate.AccessibleDescription = null;
            this.dtpJukyongDate.AccessibleName = null;
            resources.ApplyResources(this.dtpJukyongDate, "dtpJukyongDate");
            this.dtpJukyongDate.BackgroundImage = null;
            this.dtpJukyongDate.Font = null;
            this.dtpJukyongDate.Name = "dtpJukyongDate";
            this.dtpJukyongDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpJukyongDate_KeyDown);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = null;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleDescription = null;
            this.pictureBox1.AccessibleName = null;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Font = null;
            this.pictureBox1.ImageLocation = null;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // grdBAS0212
            // 
            this.grdBAS0212.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdBAS0212, "grdBAS0212");
            this.grdBAS0212.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell12,
            this.xEditGridCell15});
            this.grdBAS0212.ColPerLine = 6;
            this.grdBAS0212.Cols = 6;
            this.grdBAS0212.ExecuteQuery = null;
            this.grdBAS0212.FixedRows = 2;
            this.grdBAS0212.HeaderHeights.Add(21);
            this.grdBAS0212.HeaderHeights.Add(21);
            this.grdBAS0212.Name = "grdBAS0212";
            this.grdBAS0212.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0212.ParamList")));
            this.grdBAS0212.QuerySQL = resources.GetString("grdBAS0212.QuerySQL");
            this.grdBAS0212.Rows = 3;
            this.grdBAS0212.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdBAS0212_GridColumnChanged);
            this.grdBAS0212.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0212_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 3;
            this.xEditGridCell1.CellName = "gongbi_code";
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "start_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 100;
            this.xEditGridCell2.Col = 4;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.RowSpan = 2;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "end_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 100;
            this.xEditGridCell3.Col = 5;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.RowSpan = 2;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 2;
            this.xEditGridCell4.CellName = "law_no";
            this.xEditGridCell4.CellWidth = 50;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.RowSpan = 2;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "gongbi_name";
            this.xEditGridCell5.CellWidth = 300;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell5.RowSpan = 2;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "total_yn";
            this.xEditGridCell12.CellWidth = 53;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "gongbi_jiyeok";
            this.xEditGridCell15.CellWidth = 120;
            this.xEditGridCell15.Col = 3;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.RowSpan = 2;
            this.xEditGridCell15.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.Font = null;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // layGongbiCode
            // 
            this.layGongbiCode.ExecuteQuery = null;
            this.layGongbiCode.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layGongbiCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layGongbiCode.ParamList")));
            this.layGongbiCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layGongbiCode_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxGongbiName;
            this.singleLayoutItem1.DataName = "gongbi_name";
            // 
            // layDupCheck
            // 
            this.layDupCheck.ExecuteQuery = null;
            this.layDupCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layDupCheck.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupCheck.ParamList")));
            this.layDupCheck.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupCheck_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "dup_yn";
            // 
            // BAS0212U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xButtonList1);
            this.Controls.Add(this.grdBAS0212);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "BAS0212U00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.BAS0212U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0212)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수

		private string mMsg = "";
		private string mCaption = "";

		#endregion

        #region Validation Service
        private void fbxGongbi_DataValidating(object sender, DataValidatingEventArgs e)
        {
           
            
            this.layGongbiCode.QueryLayout();
            this.grdBAS0212.QueryLayout(false);
            
        }

	    

	    #endregion

		#region Grid

		private void grdBAS0212_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			string msg = "";
			switch (e.ColName)
			{
				case "gongbi_code":
					if (DupCheck(e.ChangeValue.ToString(), this.grdBAS0212.GetItemString(e.RowNumber, "start_date")))
					{
						msg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재합니다." : Resource.TEXT2);

						this.SetMsg(msg, MsgType.Error);

						e.Cancel = true;
					}
					break;
				case "start_date":
					if (DupCheck(this.grdBAS0212.GetItemString(e.RowNumber, "gongbi_code"), e.ChangeValue.ToString() ))
					{
						msg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재합니다." : Resource.TEXT2);

						this.SetMsg(msg, MsgType.Error);

						e.Cancel = true;
					}
					break;
			}
		}

		#endregion

		#region DupCheck

        private void layGongbiCode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layGongbiCode.SetBindVarValue("f_hosp_code" , EnvironInfo.HospCode);
            this.layGongbiCode.SetBindVarValue("f_code"      , this.fbxGongbi.GetDataValue());
            this.layGongbiCode.SetBindVarValue("f_start_date", this.dtpJukyongDate.GetDataValue());
        }

		private bool DupCheck(string aGongbiCode, string aFromJYDate)
		{
			// Deleted Table 에서 검색
			if (this.grdBAS0212.DeletedRowTable != null)
			{
                foreach (DataRow dr in grdBAS0212.DeletedRowTable.Rows)
                {
                    if (dr["gongbi_code"].ToString() == aGongbiCode &&
                        dr["start_date"].ToString() == aFromJYDate)
                        return false;
                }
                //for(int i = 0 ; i < grdBAS0212.RowCount ; i++)
                //{
                //    if(i == this.grdBAS0212.CurrentRowNumber)
                //        continue;

                    
                //    if (grdBAS0212.GetItemString(i,"gongbi_code") == aGongbiCode &&
                //        grdBAS0212.GetItemString(i,"start_date") == aFromJYDate )
                //        return false;
                //}
			}

			// 현재 Table 에서 검색
			for (int i=0; i<this.grdBAS0212.RowCount; i++)
			{
				if (i != grdBAS0212.CurrentRowNumber &&
					this.grdBAS0212.GetItemString(i, "gongbi_code") == aGongbiCode &&
					this.grdBAS0212.GetItemString(i, "start_date") == aFromJYDate )
				{
					return true;
				}
			}

			// 서버에서 검색
			this.layDupCheck.QueryLayout();

			if (this.layDupCheck.GetItemValue("dup_yn").ToString() == "Y")
			{
				return true;
			}
			return false;
		}

		#endregion

		#region ScreenOpen

		private void BAS0212U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            this.grdBAS0212.FixedCols = 2;

			// 적용일자를 오늘 날자로
			this.dtpJukyongDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.grdBAS0212.QueryLayout(false);
			this.fbxGongbi.Focus();
		}

		#endregion

		#region ButtonList

		private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Reset:
					this.dtpJukyongDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					this.fbxGongbi.Focus();
					break;

				case FunctionType.Insert:
					this.GridDefaultSetting();
					break;					
			}
		}

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Update:
			       

                        if (SaveGrid())
			            {
                            //this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : Resource.TEXT3;

                            //this.mCaption = NetInfo.Language == LangMode.Ko ? "저장완료" : Resource.TEXT4;
                            this.mMsg = Resources.MSG_SAVE_SUCCESS;
                            this.mCaption = Resources.MSG_SAVE_SUCCESS_CAP;
			                XMessageBox.Show(this.mMsg, this.mCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

			                this.grdBAS0212.QueryLayout(false);
			            }
			            else
			            {
                            //this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : Resource.TEXT5;

                            //this.mMsg += "\r\n" + Service.ErrFullMsg;

                            //this.mCaption = NetInfo.Language == LangMode.Ko ? "저장실패" : Resource.TEXT6;
                            this.mMsg = Resources.MSG_SAVE_ERROR;
                            this.mCaption = Resources.MSG_SAVE_ERROR;
			                XMessageBox.Show(this.mMsg, this.mCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);

			            }
			        
			        e.IsBaseCall = false;
					break;
			}
		}

		#endregion

		#region DatePicker

		private void dtpJukyongDate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                this.grdBAS0212.QueryLayout(false);
			}
		}

		#endregion

		#region Grid Default Setting

		private void GridDefaultSetting()
		{
			// From 적용기간은 오늘로
			this.grdBAS0212.SetItemValue(grdBAS0212.CurrentRowNumber, "start_date", this.dtpJukyongDate.GetDataValue());

            this.grdBAS0212.SetItemValue(grdBAS0212.CurrentRowNumber, "end_date", "9998/12/31");

			// TOTAL_YN 은 "y"로
			this.grdBAS0212.SetItemValue(grdBAS0212.CurrentRowNumber, "total_yn", "Y");
		}

		#endregion

        private void fwkGongbiCode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkGongbiCode.SetBindVarValue("f_hosp_code",  EnvironInfo.HospCode);
            this.fwkGongbiCode.SetBindVarValue("f_start_date", this.dtpJukyongDate.GetDataValue());
        }

        private void grdBAS0212_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0212.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdBAS0212.SetBindVarValue("f_gongbi_code", fbxGongbi.GetDataValue());
            this.grdBAS0212.SetBindVarValue("f_start_date", dtpJukyongDate.GetDataValue());
        }
        
        private void layDupCheck_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupCheck.SetBindVarValue("f_code", this.grdBAS0212.GetItemString(grdBAS0212.CurrentRowNumber, "gongbi_code"));
            this.layDupCheck.SetBindVarValue("f_start_date", this.grdBAS0212.GetItemString(grdBAS0212.CurrentRowNumber, "start_date"));
        }

        private void fbxGongbi_FindClick(object sender, CancelEventArgs e)
        {

            //this.grdBAS0212.QueryLayout(true);

        }

        #region XSavePeformer
//        private class XSavePeformer : ISavePerformer
//        {
//            private BAS0212U00 parent = null;

//            public XSavePeformer(BAS0212U00 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerId, RowDataItem item)
//            {
//                string cmdText = "";
//                object t_dup_check = "";

//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                switch (callerId)
//                {
//                    case '1':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                cmdText = @"SELECT 'Y'
//                                                FROM DUAL
//                                               WHERE EXISTS (SELECT 'X'
//                                                               FROM BAS0212
//                                                              WHERE HOSP_CODE   = :f_hosp_code
//                                                                AND GONGBI_CODE = :f_gongbi_code
//                                                                AND START_DATE  = :f_start_date   ) ";

//                                t_dup_check = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (!TypeCheck.IsNull(t_dup_check))
//                                {
//                                    if (t_dup_check.ToString() == "Y")
//                                    {
//                                        XMessageBox.Show("「" + item.BindVarList["f_gongbi_code"].VarValue + "」"+Resource.TEXT7, Resource.TEXT8, MessageBoxIcon.Warning);
//                                        return false;
//                                    }
//                                }

//                                /* 기존의 데이터에 END_DATE를 새로운 데이터
//                                   START_DATE - 1 로 셋팅한다 */
//                                cmdText = @"UPDATE BAS0212 A
//                                               SET A.UPD_ID      = :q_user_id
//                                                 , A.UPD_DATE    = SYSDATE
//                                                 , A.END_DATE    = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1
//                                             WHERE A.HOSP_CODE   = :f_hosp_code
//                                               AND A.GONGBI_CODE = :f_gongbi_code
//                                               AND A.END_DATE    = TO_DATE('9998/12/31', 'YYYY/MM/DD')
//                                               AND TO_DATE(:f_start_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";

//                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                                {
//                                    //return false;
//                                }

//                                    cmdText = @"INSERT INTO BAS0212
//                                                       ( SYS_DATE         , SYS_ID             , UPD_DATE           , UPD_ID    , HOSP_CODE
//                                                       , GONGBI_CODE      , START_DATE         , END_DATE           , LAW_NO
//                                                       , GONGBI_NAME      , TOTAL_YN           , GONGBI_JIYEOK      )
//                                                  VALUES (
//                                                         SYSDATE          , :q_user_id         , SYSDATE            , :q_user_id  , :f_hosp_code
//                                                       , :f_gongbi_code   , :f_start_date      , :f_end_date        , :f_law_no
//                                                       , :f_gongbi_name   , :f_total_yn        , :f_gongbi_jiyeok)";

//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE BAS0212
//                                             SET UPD_ID        = :q_user_id
//                                               , UPD_DATE      = SYSDATE
//                                               , END_DATE      = :f_end_date
//                                               , LAW_NO        = :f_law_no
//                                               , GONGBI_NAME   = :f_gongbi_name
//                                               , TOTAL_YN      = :f_total_yn
//                                               , GONGBI_JIYEOK = :f_gongbi_jiyeok
//                                           WHERE HOSP_CODE     = :f_hosp_code
//                                             AND GONGBI_CODE   = :f_gongbi_code
//                                             AND START_DATE    = :f_start_date";

//                                break;

//                            case DataRowState.Deleted:
//                                //                                /* 이전놈 찾아서 돌려 놓는다. */
//                                cmdText = @"UPDATE BAS0212
//                                               SET END_DATE        = TO_DATE('9998/12/31', 'YYYY/MM/DD')
//                                             WHERE HOSP_CODE     = :f_hosp_code
//                                               AND GONGBI_CODE   = :f_gongbi_code
//                                               AND END_DATE        = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1
//                                               ";
//                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

//                                    cmdText = @"DELETE FROM BAS0212
//                                                   WHERE HOSP_CODE   = :f_hosp_code
//                                                     AND GONGBI_CODE = :f_gongbi_code
//                                                     AND START_DATE  = :f_start_date";

//                                break;
//                        }
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

        

    }
}


#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0319U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0319U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XFindWorker fwkCommon;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XDatePicker dtpJukyongDate;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdBAS0319;
		private IHIS.Framework.SingleLayout layCommon;
        private IHIS.Framework.SingleLayout layDupCheck;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0319U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0319U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dtpJukyongDate = new IHIS.Framework.XDatePicker();
            this.grdBAS0319 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layDupCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0319)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.dtpJukyongDate);
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // dtpJukyongDate
            // 
            resources.ApplyResources(this.dtpJukyongDate, "dtpJukyongDate");
            this.dtpJukyongDate.Name = "dtpJukyongDate";
            // 
            // grdBAS0319
            // 
            this.grdBAS0319.AddedHeaderLine = 1;
            this.grdBAS0319.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.grdBAS0319.ColPerLine = 6;
            this.grdBAS0319.Cols = 6;
            resources.ApplyResources(this.grdBAS0319, "grdBAS0319");
            this.grdBAS0319.FixedRows = 2;
            this.grdBAS0319.HeaderHeights.Add(21);
            this.grdBAS0319.HeaderHeights.Add(0);
            this.grdBAS0319.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdBAS0319.Name = "grdBAS0319";
            this.grdBAS0319.QuerySQL = resources.GetString("grdBAS0319.QuerySQL");
            this.grdBAS0319.Rows = 3;
            this.grdBAS0319.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0319_QueryStarting);
            this.grdBAS0319.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdBAS0319_GridColumnChanged);
            this.grdBAS0319.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdBAS0319_GridFindClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AutoTabDataSelected = true;
            this.xEditGridCell1.CellLen = 2;
            this.xEditGridCell1.CellName = "jusa_susuryo";
            this.xEditGridCell1.CellWidth = 55;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell1.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.Row = 1;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCommon.FormText = global::IHIS.BASS.Resource.TEXT1;
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkCommon.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 232;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 80;
            this.xEditGridCell2.CellName = "code_name";
            this.xEditGridCell2.CellWidth = 189;
            this.xEditGridCell2.Col = 1;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.Row = 1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AutoTabDataSelected = true;
            this.xEditGridCell3.CellLen = 2;
            this.xEditGridCell3.CellName = "jusa";
            this.xEditGridCell3.CellWidth = 58;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell3.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.Row = 1;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 80;
            this.xEditGridCell4.CellName = "jusa_name";
            this.xEditGridCell4.CellWidth = 176;
            this.xEditGridCell4.Col = 3;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.Row = 1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "start_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 115;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsJapanYearType = true;
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "end_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 119;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsJapanYearType = true;
            this.xEditGridCell6.IsUpdatable = false;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 55;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 2;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 58;
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layCommon
            // 
            this.layCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "code_name";
            // 
            // layDupCheck
            // 
            this.layDupCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layDupCheck.QuerySQL = resources.GetString("layDupCheck.QuerySQL");
            this.layDupCheck.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupCheck_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "dup_yn";
            // 
            // BAS0319U00
            // 
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdBAS0319);
            this.Controls.Add(this.xPanel1);
            this.Name = "BAS0319U00";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.BAS0319U00_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0319)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수 

		private string mMsg = "";
        private string mCap = "";

		#endregion

		#region Form Load

		private void BAS0319U00_Load(object sender, System.EventArgs e)
		{
            this.grdBAS0319.SavePerformer = new XSavePeformer(this);
			this.InitializeScreen();
            this.grdBAS0319.QueryLayout(false);
		}

		#endregion

		#region function

		private void InitializeScreen()
		{
			this.dtpJukyongDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
		}

		private bool IsDuplicate()
		{
			this.layDupCheck.QueryLayout();
			
			if (this.layDupCheck.GetItemValue("dup_yn").ToString() == "Y")
			{
				return true;
			}
			else
			{
				return false;
			}
	    }

		#endregion

		#region XButton List

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert :

					break;

				case FunctionType.Update :

                    if (!this.grdBAS0319.SaveLayout())
					{
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : Resource.TEXT2;

                        this.mMsg += "\r\n" + Service.ErrFullMsg;

                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : Resource.TEXT3;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

                    this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : Resource.TEXT4;

                    this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : Resource.TEXT5;

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.grdBAS0319.QueryLayout(false);

					break;
			}
		}

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Reset:

					this.InitializeScreen();

					break;

				case FunctionType.Insert:

					this.grdBAS0319.SetItemValue(grdBAS0319.CurrentRowNumber, "start_date", this.dtpJukyongDate.GetDataValue());
					this.grdBAS0319.SetItemValue(grdBAS0319.CurrentRowNumber, "end_date"  , "9998/12/31");

					break;
			}
		}

		#endregion

		#region XGrid

		private void grdBAS0319_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			switch (e.ColName)
			{
				case "jusa_susuryo":

					// 파인드 워커 설정
                    this.fwkCommon.InputSQL = @"SELECT A.CODE
                                                     , A.CODE_NAME
                                                  FROM BAS0102 A
                                                 WHERE A.HOSP_CODE    = :f_hosp_code 
                                                   AND A.CODE_TYPE    = :f_code_type
                                                   AND (  A.CODE      LIKE :f_find1 || '%'
                                                       OR A.CODE_NAME LIKE :f_find1 || '%' )
                                                 ORDER BY A.CODE";

                    // In 변수 설정
                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkCommon.SetBindVarValue("f_code_type", "SUSURYO_GUBUN");

					break;

				case "jusa":

					// 파인드 워커 설정
					this.fwkCommon.InputSQL = @"SELECT A.CODE
                                                     , A.CODE_NAME
                                                  FROM OCS0132 A
                                                 WHERE A.HOSP_CODE    = :f_hosp_code 
                                                   AND A.CODE_TYPE = 'JUSA'
                                                   AND (  A.CODE      LIKE '%' || :f_find1 || '%'
                                                       OR A.CODE_NAME LIKE '%' || :f_find1 || '%' )
                                                   ORDER BY A.CODE";

                    // In 변수 설정
                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);				
                    break;
			}
		}

		private void grdBAS0319_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			switch (e.ColName)
			{
				case "jusa_susuryo" :

					if (e.ChangeValue.ToString() == "")
					{
						this.grdBAS0319.SetItemValue(e.RowNumber, "code_name", "");

						return ;
					}

					// 중복체크 
					if (this.IsDuplicate())
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Resource.TEXT6);

						this.SetMsg (this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}

                    this.layCommon.QuerySQL = @"SELECT CODE_NAME
                                                     , SORT_KEY
                                                  FROM BAS0102
                                                 WHERE HOSP_CODE = :f_hosp_code 
                                                   AND CODE_TYPE = :f_code_type
                                                   AND CODE      = :f_code    ";

                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layCommon.SetBindVarValue("f_code_type", "SUSURYO_GUBUN");
                    this.layCommon.SetBindVarValue("f_code", e.ChangeValue.ToString());

					this.layCommon.QueryLayout();

                    this.grdBAS0319.SetItemValue(e.RowNumber, "code_name", this.layCommon.GetItemValue("code_name").ToString());

                    if (this.layCommon.GetItemValue("code_name").ToString() == "")
                    {
                        this.mMsg = (NetInfo.Language == LangMode.Ko ? "코드가 정확하지 않습니다. 확인해 주세요." : Resource.TEXT7);

                        this.SetMsg(this.mMsg, MsgType.Error);

                        e.Cancel = true;

                        return;
                    }
					break;

				case "jusa":

					if (e.ChangeValue.ToString() == "")
					{
						this.grdBAS0319.SetItemValue(e.RowNumber, "jusa_name", "");

						return ;
					}

					// 중복체크 
					if (this.IsDuplicate())
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Resource.TEXT6);

						this.SetMsg (this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}

                    this.layCommon.QuerySQL = @"SELECT A.CODE_NAME
                                                    FROM OCS0132 A
                                                   WHERE A.HOSP_CODE = :f_hosp_code 
                                                     AND A.CODE_TYPE = 'JUSA'
                                                     AND A.CODE      = :f_code";

                    //this.layCommon.SetInValue("code_type", "JUSA");
                    this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layCommon.SetBindVarValue("f_code", e.ChangeValue.ToString());

					this.layCommon.LayoutItems.Clear();
                    this.layCommon.LayoutItems.Add("code_name");

					this.layCommon.QueryLayout();
                    this.grdBAS0319.SetItemValue(e.RowNumber, "jusa_name", this.layCommon.GetItemValue("code_name").ToString());

					if (this.layCommon.GetItemValue("code_name").ToString() == "")
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "코드가 정확하지 않습니다. 확인해 주세요." : Resource.TEXT7);

						this.SetMsg(this.mMsg, MsgType.Error);

						e.Cancel = true;

						return ;
					}
					break;

				case "start_date":

					// 중복체크 
					if (this.IsDuplicate())
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Resource.TEXT6);

						this.SetMsg (this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}

					break;
				case "end_date":

					// 중복체크 
					if (this.IsDuplicate())
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "동일한 코드가 존재 합니다." : Resource.TEXT6);

						this.SetMsg (this.mMsg, MsgType.Error);

						e.Cancel = true;

						return;
					}

					break;
			}
		}

		#endregion

        private void grdBAS0319_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0319.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdBAS0319.SetBindVarValue("f_jy_date", this.dtpJukyongDate.GetDataValue());
        }

        private void layDupCheck_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDupCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupCheck.SetBindVarValue("f_start_date", this.grdBAS0319.GetItemString(this.grdBAS0319.CurrentRowNumber, "start_date"));
            this.layDupCheck.SetBindVarValue("f_end_date", this.grdBAS0319.GetItemString(this.grdBAS0319.CurrentRowNumber, "end_date"));
            this.layDupCheck.SetBindVarValue("f_jusa", this.grdBAS0319.GetItemString(this.grdBAS0319.CurrentRowNumber, "jusa"));
            this.layDupCheck.SetBindVarValue("f_jusa_susuryo", this.grdBAS0319.GetItemString(this.grdBAS0319.CurrentRowNumber, "jusa_susuryo"));
        }

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0319U00 parent = null;

            public XSavePeformer(BAS0319U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerId, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                switch (callerId)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT 'Y' 
            	                              FROM DUAL
            	                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0319
                                                             WHERE HOSP_CODE    = :f_hosp_code 
                                                               AND JUSA_SUSURYO = :f_jusa_susuryo
                                                               AND JUSA         = :f_jusa
                                                               AND START_DATE   = :f_start_date
                                                               AND END_DATE     = :f_end_date   )   ";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show(Resource.TEXT8 + " :「" + item.BindVarList["f_jusa_susuryo"].VarValue + "」\r\n" +
                                                         Resource.TEXT9 + " :「" + item.BindVarList["f_jusa"].VarValue + "」\r\n" +
                                                         Resource.TEXT10 + " :「" + item.BindVarList["f_start_date"].VarValue + "」\r\n" +
                                                         Resource.TEXT11 + " :「" + item.BindVarList["f_end_date"].VarValue + "」\r\n" +
                                                         Resource.TEXT12, Resource.TEXT13, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                /* 입력된 시작일 이후로의 데이터가 존재 하는지 체크 */
                                cmdText = @"SELECT 'Y'
            	                              FROM DUAL
            	                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0319
                                                             WHERE HOSP_CODE    = :f_hosp_code 
                                                               AND JUSA_SUSURYO = :f_jusa_susuryo
                                                               AND JUSA         = :f_jusa
                                                               AND START_DATE   >= :f_start_date )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show(Resource.TEXT8 + " :「" + item.BindVarList["f_jusa_susuryo"].VarValue + "」\r\n" +
                                                         Resource.TEXT9 + " :「" + item.BindVarList["f_jusa"].VarValue + "」\r\n" +
                                                         Resource.TEXT14 + " :「" + item.BindVarList["f_start_date"].VarValue + "」より\r\n" +
                                                         Resource.TEXT15, Resource.TEXT13, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"UPDATE BAS0319
            	                               SET UPD_DATE     = SYSDATE
                                                 , UPD_ID       = :q_user_id
                                                 , END_DATE     = TO_DATE(:f_start_date, 'YYYY/MM/DD') -1
            	                             WHERE HOSP_CODE    = :f_hosp_code 
                                               AND JUSA_SUSURYO = :f_jusa_susuryo
                                               AND JUSA         = :f_jusa
            	                               AND END_DATE     = TO_DATE('9998/12/31', 'YYYY/MM/DD') 
                                               AND TO_DATE(:f_start_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";
                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"INSERT INTO BAS0319
                                                 ( SYS_DATE
                                                 , SYS_ID
                                                 , UPD_DATE
                                                 , UPD_ID
                                                 , HOSP_CODE
                                                 , START_DATE
                                                 , END_DATE
                                                 , JUSA
                                                 , JUSA_SUSURYO
                                                 , CODE_NAME         )
                                            VALUES(SYSDATE
                                                 , :q_user_id
                                                 , SYSDATE
                                                 , :q_user_id
                                                 , :f_hosp_code
                                                 , :f_start_date
                                                 , :f_end_date
                                                 , :f_jusa
                                                 , :f_jusa_susuryo
                                                 , :f_code_name      )";

                                break;

                            case DataRowState.Modified:

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"UPDATE BAS0319
            	                               SET UPD_DATE     = SYSDATE
                                                 , UPD_ID       = :q_user_id
                                                 , END_DATE     = TO_DATE('9998/12/31', 'YYYY/MM/DD')
            	                             WHERE HOSP_CODE    = :f_hosp_code 
                                               AND END_DATE     = TO_DATE(:f_start_date, 'YYYY/MM/DD') -1
                                               AND JUSA         = :f_jusa
                                               AND JUSA_SUSURYO = :f_jusa_susuryo";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"DELETE FROM BAS0319
                                             WHERE HOSP_CODE    = :f_hosp_code 
                                               AND START_DATE   = :f_start_date
                                               AND END_DATE     = :f_end_date
                                               AND JUSA         = :f_jusa
                                               AND JUSA_SUSURYO = :f_jusa_susuryo";

                                break;
                        }
                        break;

                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion
	}
}


#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
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
	/// BAS0324U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0324U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XTextBox txtRemark;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XDatePicker dtpQueryDate;
		private IHIS.Framework.XEditGrid grdBAS0324;
		private IHIS.Framework.SingleLayout layHangmogName;
		private IHIS.Framework.SingleLayout laySgname;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0324U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0324U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dtpQueryDate = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.grdBAS0324 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.txtRemark = new IHIS.Framework.XTextBox();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.layHangmogName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.laySgname = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0324)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.dtpQueryDate);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Name = "xPanel1";
            // 
            // dtpQueryDate
            // 
            resources.ApplyResources(this.dtpQueryDate, "dtpQueryDate");
            this.dtpQueryDate.Name = "dtpQueryDate";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // grdBAS0324
            // 
            this.grdBAS0324.AddedHeaderLine = 1;
            this.grdBAS0324.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7});
            this.grdBAS0324.ColPerLine = 6;
            this.grdBAS0324.Cols = 7;
            this.grdBAS0324.ControlBinding = true;
            resources.ApplyResources(this.grdBAS0324, "grdBAS0324");
            this.grdBAS0324.FixedCols = 1;
            this.grdBAS0324.FixedRows = 2;
            this.grdBAS0324.HeaderHeights.Add(24);
            this.grdBAS0324.HeaderHeights.Add(0);
            this.grdBAS0324.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdBAS0324.Name = "grdBAS0324";
            this.grdBAS0324.QuerySQL = resources.GetString("grdBAS0324.QuerySQL");
            this.grdBAS0324.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdBAS0324.RowHeaderVisible = true;
            this.grdBAS0324.Rows = 3;
            this.grdBAS0324.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdBAS0324_GridColumnChanged);
            this.grdBAS0324.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdBAS0324_GridFindClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "buwi_group";
            this.xEditGridCell1.CellWidth = 147;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.MaxDropDownItems = 20;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell1.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102 \r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE" +
                "()\r\n   AND CODE_TYPE = \'BUWI_GROUP\'";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hangmog_code";
            this.xEditGridCell2.CellWidth = 113;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.Row = 1;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "sg_code";
            this.xEditGridCell3.CellWidth = 104;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.RowSpan = 2;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.txtRemark;
            this.xEditGridCell4.CellLen = 4000;
            this.xEditGridCell4.CellName = "remark";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // txtRemark
            // 
            this.txtRemark.ApplyByteLimit = true;
            resources.ApplyResources(this.txtRemark, "txtRemark");
            this.txtRemark.Name = "txtRemark";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "start_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 111;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsJapanYearType = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.RowSpan = 2;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "end_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 114;
            this.xEditGridCell6.Col = 6;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsJapanYearType = true;
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "hangmog_name";
            this.xEditGridCell7.CellWidth = 275;
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.Row = 1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 2;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 113;
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.txtRemark);
            this.xPanel2.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // layHangmogName
            // 
            this.layHangmogName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layHangmogName.QuerySQL = "SELECT A.HANGMOG_NAME \r\n  FROM OCS0103 A\r\n WHERE A.HOSP_CODE    = :f_hosp_code \r\n" +
                "   AND A.HANGMOG_CODE = :f_hangmog_code";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "hangmog_name";
            // 
            // laySgname
            // 
            this.laySgname.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.laySgname.QuerySQL = resources.GetString("laySgname.QuerySQL");
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "sg_name";
            // 
            // BAS0324U00
            // 
            this.Controls.Add(this.grdBAS0324);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xPanel1);
            this.Name = "BAS0324U00";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.BAS0324U00_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0324)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수

		private string mMsg = "";
		private string mCap = "";

		#endregion

		#region Function

		#region InitScreen

		private void InitScreen ()
		{
			// 조회일자
			this.dtpQueryDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
		}

		#endregion

		#region InitGrid

		private void InitGrid ()
		{
            // 시작일자 일단 셋팅
            this.grdBAS0324.SetItemValue(grdBAS0324.CurrentRowNumber, "start_date", this.dtpQueryDate.GetDataValue());
            this.grdBAS0324.SetItemValue(grdBAS0324.CurrentRowNumber, "end_date", "9998/12/31");
		}

		#endregion

		#endregion

		#region Screen Load

		private void BAS0324U00_Load(object sender, System.EventArgs e)
		{
            this.grdBAS0324.SavePerformer = new XSavePeformer(this);

			this.InitScreen();
            this.LoadBAS0324();
		}

		#endregion

		#region DataLoad

		private void LoadBAS0324 ()
        {
            this.grdBAS0324.SetBindVarValue("f_hosp_code" , EnvironInfo.HospCode);
			this.grdBAS0324.SetBindVarValue("f_query_date", this.dtpQueryDate.GetDataValue());

			this.grdBAS0324.QueryLayout(false);
		}

		#endregion

		#region Open Screen 

		private void Open_BAS0311Q00 ()
		{
			CommonItemCollection param = new CommonItemCollection();

			param.Add("sg_ymd",  this.grdBAS0324.GetItemString(grdBAS0324.CurrentRowNumber, "start_date"));
			param.Add("sg_code", this.grdBAS0324.GetItemString(grdBAS0324.CurrentRowNumber, "sg_code")   );

			XScreen.OpenScreenWithParam(this, "BASS", "BAS0311Q00", ScreenOpenStyle.ResponseFixed, param);
		}

		private void Open_OCS0103Q00 ()
		{
			CommonItemCollection param = new CommonItemCollection();

			param.Add("hangmogCode", this.grdBAS0324.GetItemString(grdBAS0324.CurrentRowNumber, "hangmog_code"));
			param.Add("multiSelect", true);

			XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, param);
		}

		#endregion

		#region XEditGrid

		#region GridFindClick

		private void grdBAS0324_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			switch (e.ColName)
			{
				case "hangmog_code" :

					this.Open_OCS0103Q00();

					break;

				case "sg_code" :
 
					this.Open_BAS0311Q00();

					break;
			}
		}

		#endregion

		#region GridColumnChanged

		private void grdBAS0324_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			string name = "";

			switch (e.ColName)
			{
				case "hangmog_code" :

					#region 오더코드

					if (e.ChangeValue.ToString() == "")
					{
						this.grdBAS0324.SetItemValue(e.RowNumber, "hangmog_name", "");
						this.SetMsg("");
						return;
					}

                    this.layHangmogName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.layHangmogName.SetBindVarValue("f_hangmog_code", e.ChangeValue.ToString());

                    if (this.layHangmogName.QueryLayout())
					{
						name = this.layHangmogName.GetItemValue("hangmog_name").ToString();

						if (name == "")
						{
							this.mMsg = (NetInfo.Language == LangMode.Ko ? "코드가 정확하지않습니다. 확인바랍니다." : Resource.TEXT1);
							this.SetMsg(this.mMsg, MsgType.Error);
							
							e.Cancel = true;
						}
						else
						{
							this.grdBAS0324.SetItemValue(e.RowNumber, "hangmog_name", name);
							this.SetMsg("");
						}
					}
					else
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "코드가 정확하지않습니다. 확인바랍니다." : Resource.TEXT1);
						this.SetMsg(this.mMsg, MsgType.Error);
							
						e.Cancel = true;
					}

					#endregion

					break;

				case "sg_code" :

					#region 점수코드

					if (e.ChangeValue.ToString() == "")
					{
						this.SetMsg("");
						return;
					}

                    this.laySgname.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
					this.laySgname.SetBindVarValue("f_sg_code", e.ChangeValue.ToString());
                    this.laySgname.SetBindVarValue("f_sg_ymd", this.grdBAS0324.GetItemString(e.RowNumber, "start_date"));

					if (this.laySgname.QueryLayout())
					{
						name = this.laySgname.GetItemValue("sg_name").ToString();

						if (name == "")
						{
							this.mMsg = (NetInfo.Language == LangMode.Ko ? "코드가 정확하지않습니다. 확인바랍니다." : Resource.TEXT1);
							this.SetMsg(this.mMsg, MsgType.Error);
							
							e.Cancel = true;
						}
						else
						{
							this.SetMsg("");
						}
					}
					else
					{
						this.mMsg = (NetInfo.Language == LangMode.Ko ? "코드가 정확하지않습니다. 확인바랍니다." : Resource.TEXT1);
						this.SetMsg(this.mMsg, MsgType.Error);
							
						e.Cancel = true;
					}

					#endregion

					break;
			}
		}

		#endregion


		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert :

					break;

				case FunctionType.Query :

					e.IsBaseCall = false;

					this.LoadBAS0324();

					break;

				case FunctionType.Update :

					e.IsBaseCall = false;

					if (this.grdBAS0324.SaveLayout())
					{
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 완료되었습니다." : Resource.TEXT2;
                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : Resource.TEXT3;
                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

						this.LoadBAS0324();
					}
					else
					{
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "저장에 실패 하였습니다." : Resource.TEXT4;
                        this.mMsg += "\r\n" + Service.ErrFullMsg;
                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : Resource.TEXT4;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					break;

                case FunctionType.Reset:

                    e.IsBaseCall = false;
                    this.grdBAS0324.Reset();
                    this.dtpQueryDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                    break;
			}
		}

		private void btnList_PostButtonClick(object sender,IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert :

					this.InitGrid();

					break;
			}
		}

		#endregion

		#region Command

		public override object Command(string command, CommonItemCollection commandParam)
		{
			switch (command)
			{
				case "BAS0311Q00":
					this.grdBAS0324.SetFocusToItem(grdBAS0324.CurrentRowNumber, "sg_code");
					this.grdBAS0324.SetEditorValue(((MultiLayout)(commandParam["BAS0311"])).GetItemString(0, "sg_code"));
					this.grdBAS0324.AcceptData();
					break;

				case "OCS0103Q00":

					this.grdBAS0324.SetFocusToItem(grdBAS0324.CurrentRowNumber, "hangmog_code");
                    this.grdBAS0324.SetEditorValue(((MultiLayout)(commandParam["OCS0103"])).GetItemString(0, "hangmog_code"));
					this.grdBAS0324.AcceptData();

					break;
			}

			return base.Command (command, commandParam);
		}

		#endregion

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0324U00 parent = null;

            public XSavePeformer(BAS0324U00 parent)
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

                                if (item.BindVarList["f_start_date"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT5, Resource.TEXT6, MessageBoxIcon.Error);
                                    return false;
                                }
                                else if (item.BindVarList["f_hangmog_code"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT7, Resource.TEXT6, MessageBoxIcon.Error);
                                    return false; 
                                }
                                else if (item.BindVarList["f_sg_code"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT8, Resource.TEXT6, MessageBoxIcon.Error);
                                    return false;
                                }

                                cmdText = @"SELECT 'Y' 
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0324 A
                                                             WHERE A.HOSP_CODE    = :f_hosp_code 
                                                               AND A.START_DATE   = :f_start_date 
                                                               AND A.HANGMOG_CODE = :f_hangmog_code
                                                               AND A.SG_CODE      = :f_sg_code )  ";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show(Resource.TEXT9+":「" + item.BindVarList["f_hangmog_code"].VarValue + "」\r\n" +
                                                         Resource.TEXT10+":「" + item.BindVarList["f_sg_code"].VarValue + "」\r\n" +
                                                         Resource.TEXT11+":「" + item.BindVarList["f_start_date"].VarValue + "」\r\n" +
                                                         Resource.TEXT12, Resource.TEXT6, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                /* 입력된 시작일 이후로의 데이터가 존재 하는지 체크 */
                                cmdText = @"SELECT 'Y'
            	                              FROM DUAL
            	                             WHERE EXISTS ( SELECT 'X'
            	                                              FROM BAS0324 B
            	                                             WHERE B.HOSP_CODE    = :f_hosp_code 
                                                               AND B.SG_CODE      = :f_sg_code
            	                                               AND B.HANGMOG_CODE = :f_hangmog_code 
            	                                               AND B.START_DATE   >= :f_start_date )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show(Resource.TEXT9+":「" + item.BindVarList["f_hangmog_code"].VarValue + "」\r\n" +
                                                         Resource.TEXT10+" :「" + item.BindVarList["f_sg_code"].VarValue + "」\r\n" +
                                                         Resource.TEXT11+":「" + item.BindVarList["f_start_date"].VarValue + "」より\r\n" +
                                                         Resource.TEXT13, Resource.TEXT6, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"UPDATE BAS0324 A
            	                               SET A.UPD_ID       = :q_user_id
                                                 , A.UPD_DATE     = SYSDATE
                                                 , A.END_DATE     = TO_DATE(:f_start_date, 'YYYY/MM/DD') -1
            	                             WHERE A.HOSP_CODE    = :f_hosp_code 
                                               AND A.SG_CODE      = :f_sg_code
            	                               AND A.HANGMOG_CODE = :f_hangmog_code
            	                               AND A.END_DATE     = TO_DATE('9998/12/31', 'YYYY/MM/DD') ";
                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"INSERT INTO BAS0324
                                                 ( SYS_DATE         , SYS_ID          , UPD_DATE     , UPD_ID   , HOSP_CODE 
                                                 , START_DATE       , HANGMOG_CODE    , SG_CODE
                                                 , BUWI_GROUP       , END_DATE        , REMARK       )
                                            VALUES 
                                                 ( SYSDATE          , :q_user_id      , SYSDATE      , :q_user_id  , :f_hosp_code
                                                  , :f_start_date   , :f_hangmog_code , :f_sg_code     
                                                  , :f_buwi_group   , :f_end_date     , :f_remark       )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE BAS0324
                                               SET UPD_ID         = :q_user_id
                                                 , UPD_DATE       = SYSDATE
                                                 , BUWI_GROUP     = :f_buwi_group
                                                 , END_DATE       = :f_end_date
                                                 , REMARK         = :f_remark
                                             WHERE START_DATE     = :f_start_date
                                               AND HANGMOG_CODE   = :f_hangmog_code
                                               AND SG_CODE        = :f_sg_code";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"UPDATE BAS0324
            	                               SET END_DATE     = TO_DATE('9998/12/31', 'YYYY/MM/DD')
            	                             WHERE HOSP_CODE    = :f_hosp_code 
                                               AND SG_CODE      = :f_sg_code
            	                               AND HANGMOG_CODE = :f_hangmog_code
            	                               AND END_DATE     = TO_DATE(:f_start_date, 'YYYY/MM/DD') -1";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"DELETE BAS0324
                                             WHERE HOSP_CODE    = :f_hosp_code 
                                               AND START_DATE   = :f_start_date
                                               AND HANGMOG_CODE = :f_hangmog_code
                                               AND SG_CODE      = :f_sg_code";
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


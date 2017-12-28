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
	/// BAS0250U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0251U00 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XFindWorker fwkCommon;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.SingleLayout layComm;
        private XToolTip xToolTip1;
        private XPanel xPanel1;
        private XEditGrid grdBAS0251;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0251U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0251U00));
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layComm = new IHIS.Framework.SingleLayout();
            this.xToolTip1 = new IHIS.Framework.XToolTip();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdBAS0251 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0251)).BeginInit();
            this.SuspendLayout();
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCommon.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 293;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xToolTip1
            // 
            this.xToolTip1.AutoPopDelay = 10000;
            this.xToolTip1.InitialDelay = 200;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // grdBAS0251
            // 
            this.grdBAS0251.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdBAS0251.ColPerLine = 5;
            this.grdBAS0251.Cols = 6;
            resources.ApplyResources(this.grdBAS0251, "grdBAS0251");
            this.grdBAS0251.FixedCols = 1;
            this.grdBAS0251.FixedRows = 1;
            this.grdBAS0251.HeaderHeights.Add(21);
            this.grdBAS0251.Name = "grdBAS0251";
            this.grdBAS0251.QuerySQL = "SELECT HO_GRADE\r\n     , HO_GRADE_NAME\r\n     , HO_AMT\r\n     , START_DATE\r\n     , E" +
                "ND_DATE\r\n  FROM BAS0251\r\n WHERE HOSP_CODE = :f_hosp_code";
            this.grdBAS0251.RowHeaderVisible = true;
            this.grdBAS0251.Rows = 2;
            this.grdBAS0251.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0251_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 3;
            this.xEditGridCell1.CellName = "ho_grade";
            this.xEditGridCell1.CellWidth = 130;
            this.xEditGridCell1.Col = 1;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "ho_grade_name";
            this.xEditGridCell2.CellWidth = 170;
            this.xEditGridCell2.Col = 2;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "ho_amt";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell3.CellWidth = 90;
            this.xEditGridCell3.Col = 3;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "start_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 100;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "end_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 100;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsNotNull = true;
            // 
            // BAS0251U00
            // 
            this.Controls.Add(this.grdBAS0251);
            this.Controls.Add(this.xPanel1);
            this.Name = "BAS0251U00";
            resources.ApplyResources(this, "$this");
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.BAS0250U00_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0251)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen변수 

		private string mMsg = "";
		private string mCaption = "";
        private string mHospCode = "";

		#endregion

		#region Screen Open

		private void BAS0250U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            mHospCode = EnvironInfo.HospCode;
            this.grdBAS0251.SavePerformer = new XSavePeformer(this);
            this.CurrMQLayout = this.grdBAS0251;
            this.CurrMSLayout = this.grdBAS0251;

            this.grdBAS0251.QueryLayout(false);
		}

		#endregion

		

		#region ButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Delete:

					
					break;

				case FunctionType.Insert:

					
					break;
				case FunctionType.Update:

					// 업데이트 서비스 콜
                    try
                    {
                        Service.BeginTransaction();

                        if (this.grdBAS0251.SaveLayout())
                        {
                           
                        }
                        else
                            throw new Exception();
                        Service.CommitTransaction();
                    }
                    catch
                    {
                        this.mMsg =Resource.TEXT1+"\r\n" + Service.ErrFullMsg;
                        XMessageBox.Show(this.mMsg, Resource.TEXT1, MessageBoxIcon.Error);
                    }

					e.IsBaseCall = false;
					break;
			}
		}

		
		#endregion
           
        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0251U00 parent = null;

            public XSavePeformer(BAS0251U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerId, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
                switch (callerId)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0251
                                                             WHERE HOSP_CODE  = :f_hosp_code
                                                               AND HO_GRADE   = :f_ho_grade
                                                               AND START_DATE = :f_start_date )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show("「" + item.BindVarList["f_ho_grade"].VarValue + "」"+Resource.TEXT2, Resource.TEXT3, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"UPDATE BAS0251
                                               SET UPD_ID = :q_user_id
                                                 , UPD_DATE = SYSDATE
                                                 , END_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND HO_GRADE   = :f_ho_grade
                                               AND END_DATE    = TO_DATE('9998/12/31', 'YYYY/MM/DD')
                                               AND TO_DATE(:f_start_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";
                                Service.ExecuteScalar(cmdText, item.BindVarList);

                                cmdText = @"INSERT INTO BAS0251
                                                 ( SYS_DATE            , SYS_ID           , UPD_DATE           , UPD_ID           , HOSP_CODE
                                                 , START_DATE          , END_DATE         
                                                 , HO_GRADE            , HO_GRADE_NAME    , HO_AMT       )
                                            VALUES
                                                 ( SYSDATE             , :q_user_id       , SYSDATE            , :q_user_id       , :f_hosp_code
                                                 , :f_start_date       , :f_end_date      
                                                 , :f_ho_grade         , :f_ho_grade_name , :f_ho_amt   )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE BAS0251
                                               SET UPD_DATE         = SYSDATE
                                                 , UPD_ID           = :q_user_id
                                                 , HO_GRADE_NAME    = :f_ho_grade_name
                                                 , HO_AMT           = :f_ho_amt 
                                                 , END_DATE         = :f_end_date
                                             WHERE HOSP_CODE  = :f_hosp_code
                                               AND HO_GRADE    = :f_ho_grade
                                               AND START_DATE = :f_start_date";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"UPDATE BAS0251
                                               SET UPD_ID      = :q_user_id
                                                 , UPD_DATE    = SYSDATE
                                                 , END_DATE    = TO_DATE('9998/12/31', 'YYYY/MM/DD') 
                                             WHERE HOSP_CODE   = :f_hosp_code
                                               AND HO_CODE     = :f_ho_code
                                               AND BED_NO      = :f_bed_no
                                               AND END_DATE    = TO_DATE(:f_end_date, 'YYYY/MM/DD') -1 ";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);



                                cmdText = @"DELETE FROM BAS0251
                                             WHERE HOSP_CODE  = :f_hosp_code
                                               AND HO_GRADE    = :f_ho_grade
                                               AND START_DATE = :f_start_date";

                                break;
                        }
                   
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdBAS0251_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0251.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

	}
}


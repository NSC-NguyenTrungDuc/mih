#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Injs;
using IHIS.CloudConnector.Contracts.Models.Injs;
using IHIS.CloudConnector.Contracts.Results.Injs;
using IHIS.Framework;
using IHIS.INJS.Properties;

#endregion

namespace IHIS.INJS
{
    /// <summary>
    /// INJ1002R01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class INJ1002R01 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XPanel pnlLeft;
        private IHIS.Framework.XDatePicker dtpJupsuDate;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XPanel pnlFill;
 //       private IHIS.Framework.XDataWindow dw1;
        private IHIS.Framework.XDatePicker dtpToDate;
        private IHIS.Framework.XGroupBox gbxDate;
        private IHIS.Framework.XRadioButton rbxMon;
        private IHIS.Framework.XRadioButton rbxDay;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.MultiLayout layQuery;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private XPanel pnlDay;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public INJ1002R01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INJ1002R01));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.pnlDay = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpJupsuDate = new IHIS.Framework.XDatePicker();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.gbxDate = new IHIS.Framework.XGroupBox();
            this.rbxMon = new IHIS.Framework.XRadioButton();
            this.rbxDay = new IHIS.Framework.XRadioButton();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.layQuery = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlDay.SuspendLayout();
            this.gbxDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisiblePreview = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlDay);
            this.pnlLeft.Controls.Add(this.gbxDate);
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.DrawBorder = true;
            this.pnlLeft.Name = "pnlLeft";
            // 
            // pnlDay
            // 
            this.pnlDay.Controls.Add(this.xLabel1);
            this.pnlDay.Controls.Add(this.xLabel2);
            this.pnlDay.Controls.Add(this.dtpJupsuDate);
            this.pnlDay.Controls.Add(this.dtpToDate);
            resources.ApplyResources(this.pnlDay, "pnlDay");
            this.pnlDay.Name = "pnlDay";
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpJupsuDate
            // 
            resources.ApplyResources(this.dtpJupsuDate, "dtpJupsuDate");
            this.dtpJupsuDate.IsVietnameseYearType = false;
            this.dtpJupsuDate.Name = "dtpJupsuDate";
            this.dtpJupsuDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDataValidating);
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDataValidating);
            // 
            // gbxDate
            // 
            this.gbxDate.Controls.Add(this.rbxMon);
            this.gbxDate.Controls.Add(this.rbxDay);
            resources.ApplyResources(this.gbxDate, "gbxDate");
            this.gbxDate.Name = "gbxDate";
            this.gbxDate.TabStop = false;
            // 
            // rbxMon
            // 
            resources.ApplyResources(this.rbxMon, "rbxMon");
            this.rbxMon.Name = "rbxMon";
            this.rbxMon.UseVisualStyleBackColor = false;
            this.rbxMon.Click += new System.EventHandler(this.rbxMon_Click);
            // 
            // rbxDay
            // 
            this.rbxDay.Checked = true;
            resources.ApplyResources(this.rbxDay, "rbxDay");
            this.rbxDay.Name = "rbxDay";
            this.rbxDay.TabStop = true;
            this.rbxDay.UseVisualStyleBackColor = false;
            this.rbxDay.Click += new System.EventHandler(this.rbxDay_Click);
            // 
            // pnlFill
            // 
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.Name = "pnlFill";
            // 
            // layQuery
            // 
            this.layQuery.ExecuteQuery = null;
            this.layQuery.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8});
            this.layQuery.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layQuery.ParamList")));
            this.layQuery.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layQuery_QueryStarting);
            this.layQuery.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layQuery_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "gwa";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "buseo_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "acting_date";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "hangmog_code";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "hangmog_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "ord_danui";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "inwon_cnt";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "subul_suryang";
            // 
            // INJ1002R01
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Name = "INJ1002R01";
            resources.ApplyResources(this, "$this");
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlDay.ResumeLayout(false);
            this.pnlDay.PerformLayout();
            this.gbxDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layQuery)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        [Browsable(false), DataBindable]
        public string DateGubun
        {
            get { return (rbxDay.Checked ? "1" : "2"); }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string mSysDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            this.dtpJupsuDate.SetDataValue(mSysDate);
            this.dtpToDate.SetDataValue(mSysDate);

            ApplyMultiLangDw();
      //      dw1.Modify("DataWindow.Print.Orientation= 1"); //가로 설정
            this.layQuery.QueryLayout(true);
        }

        private void ApplyMultiLangDw()
        {
            //if (dw1.DataWindowObject == "d_inj1002_1")
            //{
            //    //dw1
            //    dw1.Modify(string.Format("t_1.text = '{0}'", Resources.DW_TXT_001));
            //    dw1.Modify(string.Format("t_4.text = '{0}'", Resources.DW_TXT_002));
            //    dw1.Modify(string.Format("t_5.text = '{0}'", Resources.DW_TXT_003));
            //    dw1.Modify(string.Format("inj1001_gwa_t.text = '{0}'", Resources.DW_TXT_004));
            //    dw1.Modify(string.Format("t_9.text = '{0}'", Resources.DW_TXT_005));
            //    dw1.Modify(string.Format("inj1002_reser_date_t.text = '{0}'", Resources.DW_TXT_006));
            //    dw1.Modify(string.Format("inj1002_hangmog_code_t.text = '{0}'", Resources.DW_TXT_007));
            //    dw1.Modify(string.Format("inwon_cnt_t.text = '{0}'", Resources.DW_TXT_008));
            //}
            //else
            //{
            //    dw1.Modify(string.Format("t_1.text = '{0}'", Properties.Resources.DW_TXT_009));
            //    dw1.Modify(string.Format("t_6.text = '{0}'", Properties.Resources.DW_TXT_010));
            //    dw1.Modify(string.Format("t_7.text = '{0}'", Properties.Resources.DW_TXT_011));
            //    dw1.Modify(string.Format("inj1001_gwa_t.text = '{0}'", Properties.Resources.DW_TXT_012));
            //    dw1.Modify(string.Format("inj1002_reser_date_t.text = '{0}'", Properties.Resources.DW_TXT_013));
            //    dw1.Modify(string.Format("inj1002_hangmog_code_t.text = '{0}'", Properties.Resources.DW_TXT_014));
            //    dw1.Modify(string.Format("inwon_cnt_t.text = '{0}'", Properties.Resources.DW_TXT_015));
            //}


        }

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
    //                dw1.Reset();
                    this.layQuery.QueryLayout(true);
                    break;
                case FunctionType.Print:
   //                 dw1.Print();
                    break;
                default:
                    break;
            }
        }

        private void rbxDay_Click(object sender, System.EventArgs e)
        {
      //      dw1.DataWindowObject = "d_inj1002_1";

      //      dw1.Reset();
            ApplyMultiLangDw();
            this.layQuery.QueryLayout(true);
        }

        private void rbxMon_Click(object sender, System.EventArgs e)
        {
     //       dw1.DataWindowObject = "d_inj1002_2";
            DateTime currentDate = EnvironInfo.GetSysDate();
            string year = currentDate.Year.ToString();
            string month = currentDate.Month.ToString();
            string lastday = DateTime.DaysInMonth(currentDate.Year, currentDate.Month).ToString();

            this.dtpJupsuDate.SetDataValue(year + "/" + month + "/01");
            this.dtpToDate.SetDataValue(year + "/" + month + "/" + lastday);

     //       dw1.Reset();
            ApplyMultiLangDw();
            this.layQuery.QueryLayout(true);
        }

        private void layQuery_QueryStarting(object sender, CancelEventArgs e)
        {
            if (this.DateGubun == "1") //일별
            {
                //                this.layQuery.QuerySQL = @"SELECT B.GWA                                            GWA
                //                                                 , FN_BAS_LOAD_GWA_NAME(B.GWA, A.ACTING_DATE)       BUSEO_NAME
                //                                                 , A.ACTING_DATE                                    ACTING_DATE
                //                                                 , A.HANGMOG_CODE                                   HANGMOG_CODE
                //                                                 , D.HANGMOG_NAME                                   HANGMOG_NAME
                //                                                 , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI)  ORD_DANUI
                //                                                 , COUNT(1)                                         INWON_CNT
                //                                                 , SUM(A.SUNAB_SURYANG)                             SUBUL_SURYANG
                //                                              FROM OCS0103 D
                //                                                 , INJ1001 B
                //                                                 , INJ1002 A
                //                                             WHERE A.HOSP_CODE      = :f_hosp_code
                //                                               AND B.HOSP_CODE      = A.HOSP_CODE
                //                                               AND D.HOSP_CODE      = A.HOSP_CODE
                //                                               AND A.HANGMOG_CODE   =  D.HANGMOG_CODE(+) -- 2006.01.01 임시
                //                                               AND A.FKINJ1001      =  B.PKINJ1001
                //                                               AND NVL(A.DC_YN,'N') =  'N'
                //                                               AND A.ACTING_DATE   IS NOT NULL
                //                                               AND A.ACTING_DATE    >=  TO_DATE(:f_from_date, 'YYYY/MM/DD')
                //                                               AND A.ACTING_DATE    <=  TO_DATE(:f_to_date  , 'YYYY/MM/DD')
                //                                             GROUP BY B.GWA             
                //                                                 , A.ACTING_DATE
                //                                                 , A.HANGMOG_CODE        
                //                                                 , D.HANGMOG_NAME
                //                                                 , D.ORD_DANUI
                //                                             ORDER BY 1, 3, 4";
                //                this.layQuery.SetBindVarValue("f_from_date", this.dtpJupsuDate.GetDataValue());
                //                this.layQuery.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());

                this.layQuery.ExecuteQuery = LoadDataLayQueryCase1;
            }
            else if (this.DateGubun == "2") //월별
            {
                //                this.layQuery.QuerySQL = @"SELECT B.GWA                                                GWA          
                //                                                 , FN_BAS_LOAD_GWA_NAME(B.GWA, A.RESER_DATE)            BUSEO_NAME   
                //                                                 , trunc(sysdate)                                       ACTING_DATE   
                //                                                 , A.HANGMOG_CODE                                       HANGMOG_CODE 
                //                                                 , D.HANGMOG_NAME                                       HANGMOG_NAME 
                //                                                 , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', D.ORD_DANUI )     ORD_DANUI    
                //                                                 , COUNT(1)                                             INWON_CNT    
                //                                                 , SUM(A.SUNAB_SURYANG)                                 SUBUL_SURYANG
                //                                              FROM OCS0103 D                                               
                //                                                 , INJ1001 B                                               
                //                                                 , INJ1002 A                                               
                //                                             WHERE A.HOSP_CODE      = :f_hosp_code
                //                                               AND B.HOSP_CODE      = A.HOSP_CODE
                //                                               AND D.HOSP_CODE      = A.HOSP_CODE
                //                                               AND A.HANGMOG_CODE   =  D.HANGMOG_CODE(+) -- 2006.01.01 임시                      
                //                                               AND A.FKINJ1001      =  B.PKINJ1001                         
                //                                               AND NVL(A.DC_YN,'N') =  'N'                                 
                //                                               AND A.ACTING_DATE   IS NOT NULL                             
                //                                               AND A.ACTING_DATE    >=  TO_DATE(:f_from_date, 'YYYY/MM/DD')
                //                                               AND A.ACTING_DATE    <=  TO_DATE(:f_to_date  , 'YYYY/MM/DD')
                //                                             GROUP BY B.GWA              
                //                                                 , FN_BAS_LOAD_GWA_NAME(B.GWA, A.RESER_DATE)                         
                //                                                 , A.HANGMOG_CODE                                        
                //                                                 , D.HANGMOG_NAME                                        
                //                                                 , D.ORD_DANUI                                           
                //                                             ORDER BY 1, 3, 4";

                //                this.layQuery.SetBindVarValue("f_from_date", this.dtpJupsuDate.GetDataValue());
                //                this.layQuery.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());

                this.layQuery.ExecuteQuery = LoadDataLayQueryCase2;
            }
            //this.layQuery.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private IList<object[]> LoadDataLayQueryCase2(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            INJ1002R01LayQuery2Args args = new INJ1002R01LayQuery2Args(this.dtpJupsuDate.GetDataValue(), dtpToDate.GetDataValue());
            INJ1002R01LayQueryResult result =
                CloudService.Instance.Submit<INJ1002R01LayQueryResult, INJ1002R01LayQuery2Args>(args);
            if (result != null)
            {
                List<INJ1002R01LayQueryListItemInfo> layList = result.LayQuerryList;
                if (layList != null && layList.Count > 0)
                {
                    foreach (INJ1002R01LayQueryListItemInfo info in layList)
                    {
                        dataList.Add(new object[]
	                    {
	                        info.Gwa,
	                        info.BuseoName,
	                        info.ActingDate,
	                        info.HangmogCode,
	                        info.HangmogName,
	                        info.OrdDanui,
	                        info.InwonCnt,
	                        info.SubulSuryang
	                    });
                    }
                }
            }

            return dataList;
        }

        private IList<object[]> LoadDataLayQueryCase1(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            INJ1002R01LayQuery1Args args = new INJ1002R01LayQuery1Args(this.dtpJupsuDate.GetDataValue(), dtpToDate.GetDataValue());
            INJ1002R01LayQueryResult result =
                CloudService.Instance.Submit<INJ1002R01LayQueryResult, INJ1002R01LayQuery1Args>(args);
            if (result != null)
            {
                List<INJ1002R01LayQueryListItemInfo> layList = result.LayQuerryList;
                if (layList != null && layList.Count > 0)
                {
                    foreach (INJ1002R01LayQueryListItemInfo info in layList)
                    {
                        dataList.Add(new object[]
	                    {
	                        info.Gwa,
	                        info.BuseoName,
	                        info.ActingDate,
	                        info.HangmogCode,
	                        info.HangmogName,
	                        info.OrdDanui,
	                        info.InwonCnt,
	                        info.SubulSuryang
	                    });
                    }
                }
            }

            return dataList;
        }

        private void layQuery_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
    //            dw1.FillData(layQuery.LayoutTable);

                //if (dw1.DataWindowObject == "d_inj1002_1")
                //{
                //    dw1.Modify("t_from.text = '" + dtpJupsuDate.GetDataValue().ToString() + "'");
                //    dw1.Modify("t_to.text   = '" + dtpToDate.GetDataValue().ToString() + "'");
                //}
                //else
                //{
                //    dw1.Modify("t_from.text = '" + dtpToDate.GetDataValue().ToString() + "'");
                //}
 //               dw1.Modify("t_from.text = '" + dtpJupsuDate.GetDataValue().ToString() + "'");
  //              dw1.Modify("t_to.text   = '" + dtpToDate.GetDataValue().ToString() + "'");
            }

        }

        private void dtpDataValidating(object sender, DataValidatingEventArgs e)
        {
  //          dw1.Reset();
            this.layQuery.QueryLayout(true);
        }

        private void dw1_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
  //          dw1.Refresh();
        }
    }
}


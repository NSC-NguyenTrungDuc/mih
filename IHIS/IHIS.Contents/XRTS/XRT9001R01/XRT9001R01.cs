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
using System.Runtime.InteropServices;
using System.Collections.Generic;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using IHIS.CloudConnector.Contracts.Results.Xrts;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.XRT.Properties;
#endregion

namespace IHIS.XRTS
{
    /// <summary>
    /// DRG9001R01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class XRT9001R01 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XMonthBox xMonthBox1;
        private IHIS.Framework.MultiLayout lay9001R;
 //       private IHIS.Framework.XDataWindow dw1;
        private IHIS.Framework.XPanel xPanel2;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem19;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public XRT9001R01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // updated by Cloud
            lay9001R.ParamList = new List<string>(new string[] { "f_hosp_code", "f_date" });
            lay9001R.ExecuteQuery = GetLay9001R;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XRT9001R01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xMonthBox1 = new IHIS.Framework.XMonthBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.lay9001R = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay9001R)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xMonthBox1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xMonthBox1
            // 
            resources.ApplyResources(this.xMonthBox1, "xMonthBox1");
            this.xMonthBox1.IsVietnameseYearType = false;
            this.xMonthBox1.Name = "xMonthBox1";
            this.xMonthBox1.NextButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.xMonthBox1_ButtonClick);
            this.xMonthBox1.PrevButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.xMonthBox1_ButtonClick);
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
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "Excel", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.IsVisiblePreview = false;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // lay9001R
            // 
            this.lay9001R.ExecuteQuery = null;
            this.lay9001R.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem19});
            this.lay9001R.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("lay9001R.ParamList")));
            this.lay9001R.QueryStarting += new System.ComponentModel.CancelEventHandler(this.lay9001R_QueryStarting);
            this.lay9001R.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.lay9001R_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "acting_date";
            this.multiLayoutItem1.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "cr_cnt_n";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "cr_cnt_y";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "dr_cnt_n";
            this.multiLayoutItem4.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "dr_cnt_y";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "ct_cnt_n";
            this.multiLayoutItem13.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "ct_cnt_y";
            this.multiLayoutItem14.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "mri_cnt_n";
            this.multiLayoutItem15.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "mri_cnt_y";
            this.multiLayoutItem16.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "total";
            this.multiLayoutItem19.DataType = IHIS.Framework.DataType.Number;
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // XRT9001R01
            // 
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.xPanel1);
            resources.ApplyResources(this, "$this");
            this.Name = "XRT9001R01";
            this.xPanel1.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay9001R)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad (e);
            xMonthBox1.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyyMM"));
            xMonthBox1.AcceptData();

 //           dw1.Reset();
            ApplyMultiLangDataWindow();
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(939, rc.Height - 125);
            this.lay9001R.QueryLayout(true);
        }

        private void ApplyMultiLangDataWindow()
        {
 //           dw1.Modify(string.Format("order_date_t_1.text = '{0}'", Resources.DW_ShootingDate));
//            dw1.Modify(string.Format("inp_t_1.text = '{0}'", IHIS.XRT.Properties.Resources.DW_General));

            string today = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            if (NetInfo.Language == LangMode.Jr) {
                today = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            } 
   //         dw1.Modify(string.Format("date_10.text = '{0}'", today));

            //dw1
            //dw1.Modify(string.Format("t_1.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_001));
            //dw1.Modify(string.Format("t_2.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_002));
            //dw1.Modify(string.Format("t_3.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_003));
            //dw1.Modify(string.Format("t_4.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_004));
            //dw1.Modify(string.Format("t_5.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_005));
            //dw1.Modify(string.Format("t_6.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_006));
            //dw1.Modify(string.Format("t_7.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_007));
            //dw1.Modify(string.Format("t_8.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_008));
            //dw1.Modify(string.Format("t_9.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_009));
            //dw1.Modify(string.Format("t_13.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_013));
            //dw1.Modify(string.Format("t_11.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_011));
            //dw1.Modify(string.Format("t_10.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_010));

        }

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch(e.Func)
            {
                case FunctionType.Query:
    //                dw1.Reset();
                    this.lay9001R.QueryLayout(true);
                    break;
                case FunctionType.Process:
   //                 dw1.Export();
                    break;
                case FunctionType.Print:
                    //dw1.PrintProperties.PrinterName = "NEC MultiWriter1500N";
   //                 dw1.Print();
                    break;
                default:
                    break;

            }
        }

        private void lay9001R_QueryStarting(object sender, CancelEventArgs e)
        {
            this.lay9001R.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.lay9001R.SetBindVarValue("f_date", xMonthBox1.GetDataValue());
        }

        private void lay9001R_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
   //             dw1.FillData(lay9001R.LayoutTable);
            }

        }

        private void xMonthBox1_ButtonClick(object sender, XMonthBoxButtonClickEventArgs e)
        {
 //           dw1.Reset();
            ApplyMultiLangDataWindow();

            this.lay9001R.QueryLayout(true);

        }

        private void dw1_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
   //         this.dw1.Refresh();
        }

        private void dw1_Click(object sender, EventArgs e)
        {
     //       this.dw1.Refresh();
        }

        #region Cloud updated code

        #region GetLay9001R
        /// <summary>
        /// GetLay9001R
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLay9001R(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT9001R01Lay9001RArgs args = new XRT9001R01Lay9001RArgs();
            args.Date = bvc["f_date"].VarValue;
            XRT9001R01Lay9001RResult res = CloudService.Instance.Submit<XRT9001R01Lay9001RResult, XRT9001R01Lay9001RArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Lay9001RList.ForEach(delegate(XRT9001R01Lay9001RListItemInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.ActingDate,
                        item.CrCntN,
                        item.CrCntY,
                        item.DrCntN,
                        item.DrCntY,
                        item.CtCntN,
                        item.CtCntY,
                        item.MriCntN,
                        item.MriCntY,
                        item.TotalCnt,
                        item.ZeroValue,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #endregion
    }
}


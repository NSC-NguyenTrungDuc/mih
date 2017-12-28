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
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using IHIS.CloudConnector.Contracts.Results.Xrts;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results;
#endregion

namespace IHIS.XRTS
{
    /// <summary>
    /// XRT9001R03에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class XRT9001R03 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XButtonList xButtonList1;
 //       private IHIS.Framework.XDataWindow dw1;
        private IHIS.Framework.XEditMask emkYear;
        private IHIS.Framework.XButton btnNext;
        private IHIS.Framework.XButton btnPre;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel2;
        private MultiLayout lay9003R;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public XRT9001R03()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // updated by Cloud
            this.lay9003R.ParamList = new List<string>(new string[] { "f_hosp_code", "f_date" });
            this.lay9003R.ExecuteQuery = GetLay9003R;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XRT9001R03));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnPre = new IHIS.Framework.XButton();
            this.btnNext = new IHIS.Framework.XButton();
            this.emkYear = new IHIS.Framework.XEditMask();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.lay9003R = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay9003R)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "뒤로.gif");
            this.ImageList.Images.SetKeyName(1, "앞으로.gif");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.btnPre);
            this.xPanel1.Controls.Add(this.btnNext);
            this.xPanel1.Controls.Add(this.emkYear);
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Name = "xLabel2";
            // 
            // btnPre
            // 
            resources.ApplyResources(this.btnPre, "btnPre");
            this.btnPre.ImageIndex = 1;
            this.btnPre.ImageList = this.ImageList;
            this.btnPre.Name = "btnPre";
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.ImageIndex = 0;
            this.btnNext.ImageList = this.ImageList;
            this.btnNext.Name = "btnNext";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // emkYear
            // 
            resources.ApplyResources(this.emkYear, "emkYear");
            this.emkYear.EditVietnameseMaskType = IHIS.Framework.MaskType.String;
            this.emkYear.IsVietnameseYearType = false;
            this.emkYear.Name = "emkYear";
            // 
            // pnlBottom
            // 
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Controls.Add(this.xButtonList1);
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
            // lay9003R
            // 
            this.lay9003R.ExecuteQuery = null;
            this.lay9003R.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19});
            this.lay9003R.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("lay9003R.ParamList")));
            this.lay9003R.QueryStarting += new System.ComponentModel.CancelEventHandler(this.lay9003R_QueryStarting);
            this.lay9003R.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.lay9003R_QueryEnd);
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "acting_date";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "cr_cnt_n";
            this.multiLayoutItem7.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "cr_cnt_y";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "dr_cnt_n";
            this.multiLayoutItem9.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "dr_cnt_y";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "ct_cnt_n";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "ct_cnt_y";
            this.multiLayoutItem12.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "mri_cnt_n";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "mri_cnt_y";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "total";
            this.multiLayoutItem19.DataType = IHIS.Framework.DataType.Number;
            // 
            // XRT9001R03
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.xPanel1);
            this.Name = "XRT9001R03";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay9003R)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad (e);

            this.emkYear.Text = DateTime.Now.Year.ToString();

   //         dw1.Reset();
            ApplyMultiLangDataWindow();
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(889, rc.Height - 125);
            this.lay9003R.QueryLayout(true);
        }

        private void ApplyMultiLangDataWindow()
        {
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
            //dw1.Modify(string.Format("t_10.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_010));
            //dw1.Modify(string.Format("t_11.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_011));
            //dw1.Modify(string.Format("order_date_t_1.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_014));
            //dw1.Modify(string.Format("inp_t_1.text = '{0}'", IHIS.XRT.Properties.Resources.DW_TXT_015));  
                        
        }

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch(e.Func)
            {
                case FunctionType.Query:
   //                 dw1.Reset();
                    ApplyMultiLangDataWindow();

                    this.lay9003R.QueryLayout(true);
                    break;
                case FunctionType.Process:
    //                dw1.Export();
                    break;
                case FunctionType.Print:
                    //dw1.PrintProperties.PrinterName = "NEC MultiWriter1500N";
    //                dw1.Print();
                    break;
                default:
                    break;

            }
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            this.emkYear.Text = Convert.ToString((Convert.ToInt32(emkYear.Text) - 1));
   //         dw1.Reset();
            ApplyMultiLangDataWindow();

            this.lay9003R.QueryLayout(true);
        }

        private void btnPre_Click(object sender, System.EventArgs e)
        {
            this.emkYear.Text = Convert.ToString((Convert.ToInt32(emkYear.Text) + 1));
  //          dw1.Reset();
            ApplyMultiLangDataWindow();

            this.lay9003R.QueryLayout(true);
        }

        private void dw1_Click(object sender, EventArgs e)
        {
 //           this.dw1.Refresh();
        }

        private void dw1_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
   //         this.dw1.Refresh();
        }

        private void lay9003R_QueryStarting(object sender, CancelEventArgs e)
        {
            this.lay9003R.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.lay9003R.SetBindVarValue("f_date", this.emkYear.GetDataValue());
        }

        private void lay9003R_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (e.IsSuccess)
            {
    //            dw1.FillData(lay9003R.LayoutTable);
            }

        }

        #region Cloud udated code

        #region GetLay9003R
        /// <summary>
        /// GetLay9003R
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLay9003R(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT9001R03Lay9003RArgs args = new XRT9001R03Lay9003RArgs();
            args.Date = bvc["f_date"].VarValue;
            XRT9001R03Lay9003RResult res = CloudService.Instance.Submit<XRT9001R03Lay9003RResult, XRT9001R03Lay9003RArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Lay9003RList.ForEach(delegate(XRT9001R03Lay9003RListItemInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.ActingMonth,
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


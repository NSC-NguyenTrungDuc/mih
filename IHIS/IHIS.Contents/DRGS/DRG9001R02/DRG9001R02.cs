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
using IHIS.CloudConnector.Contracts.Arguments.Drgs;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results.Drgs;
using System.Collections.Generic;
#endregion

namespace IHIS.DRGS
{
	/// <summary>
	/// DRG9001R02에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG9001R02 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.MultiLayout lay9001R;
//		private IHIS.Framework.XDataWindow dw1;
		private IHIS.Framework.XEditMask emkYear;
		private IHIS.Framework.XButton btnNext;
		private IHIS.Framework.XButton btnPre;
		private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel2;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DRG9001R02()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            //MED-12133
            ApplyMultiResolution();

            this.lay9001R.ParamList = new List<string>(new string[] { "f_hosp_code", "f_date" });
            this.lay9001R.ExecuteQuery = GetLay9001R;
		}

        //MED-12133
        private void ApplyMultiResolution()
        {
            int width = SystemInformation.VirtualScreen.Width;
            int height = SystemInformation.VirtualScreen.Height;

            if (width == 1366 && height == 768)
            {
                this.Height = 590;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG9001R02));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnPre = new IHIS.Framework.XButton();
            this.btnNext = new IHIS.Framework.XButton();
            this.emkYear = new IHIS.Framework.XEditMask();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
  //          this.dw1 = new IHIS.Framework.XDataWindow();
            this.lay9001R = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay9001R)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "뒤로.gif");
            this.ImageList.Images.SetKeyName(1, "앞으로.gif");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.btnPre);
            this.xPanel1.Controls.Add(this.btnNext);
            this.xPanel1.Controls.Add(this.emkYear);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel2
            // 
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // btnPre
            // 
            this.btnPre.ImageIndex = 1;
            this.btnPre.ImageList = this.ImageList;
            resources.ApplyResources(this.btnPre, "btnPre");
            this.btnPre.Name = "btnPre";
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.ImageIndex = 0;
            this.btnNext.ImageList = this.ImageList;
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // emkYear
            // 
            resources.ApplyResources(this.emkYear, "emkYear");
            this.emkYear.Name = "emkYear";
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
            // dw1
            // 
            //this.dw1.DataWindowObject = "d_drg9001r01";
            //resources.ApplyResources(this.dw1, "dw1");
            //this.dw1.LibraryList = "DRGS\\drgs.drg9001r02.pbd";
            //this.dw1.Name = "dw1";
            //this.dw1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            //this.dw1.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dw1_RowFocusChanged);
            //this.dw1.Click += new System.EventHandler(this.dw1_Click);
            // 
            // lay9001R
            // 
            this.lay9001R.ExecuteQuery = null;
            this.lay9001R.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20});
            this.lay9001R.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("lay9001R.ParamList")));
            this.lay9001R.QuerySQL = resources.GetString("lay9001R.QuerySQL");
            this.lay9001R.QueryStarting += new System.ComponentModel.CancelEventHandler(this.lay9001R_QueryStarting);
            this.lay9001R.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.lay9001R_QueryEnd);
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "jubsu_date";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "drg_cnt";
            this.multiLayoutItem7.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "drg_group_cnt";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "drg_hangmog_cnt";
            this.multiLayoutItem9.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "inj_cnt";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "inj_group_cnt";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "inj_hangmog_cnt";
            this.multiLayoutItem12.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "drg_inj_cnt";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "drg_inj_group_cnt";
            this.multiLayoutItem19.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "drg_inj_hangmog_cnt";
            this.multiLayoutItem20.DataType = IHIS.Framework.DataType.Number;
            // 
            // DRG9001R02
            // 
      //      this.Controls.Add(this.dw1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.xPanel1);
            this.Name = "DRG9001R02";
            resources.ApplyResources(this, "$this");
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay9001R)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			this.emkYear.Text = DateTime.Now.Year.ToString();
            //apply multilang for dw
		    ApplyMultiLangDw();

 //           dw1.Reset();
            this.lay9001R.QueryLayout(true);
		}

	    private void ApplyMultiLangDw()
	    {
            //dw1
            //dw1.Modify(string.Format("t_13.text = '{0}'", Properties.Resources.DW_TXT_001));
            //dw1.Modify(string.Format("order_date_t_1.text = '{0}'", Properties.Resources.DW_TXT_002));
            //dw1.Modify(string.Format("inp_t_1.text = '{0}'", Properties.Resources.DW_TXT_003));
            //dw1.Modify(string.Format("t_8.text = '{0}'", Properties.Resources.DW_TXT_004));
            //dw1.Modify(string.Format("t_2.text = '{0}'", Properties.Resources.DW_TXT_005));
            //dw1.Modify(string.Format("t_5.text = '{0}'", Properties.Resources.DW_TXT_006));
            //dw1.Modify(string.Format("t_1.text = '{0}'", Properties.Resources.DW_TXT_007));
            //dw1.Modify(string.Format("t_3.text = '{0}'", Properties.Resources.DW_TXT_008));
            //dw1.Modify(string.Format("t_6.text = '{0}'", Properties.Resources.DW_TXT_009));
            //dw1.Modify(string.Format("t_4.text = '{0}'", Properties.Resources.DW_TXT_010));
            //dw1.Modify(string.Format("t_9.text = '{0}'", Properties.Resources.DW_TXT_011));
            //dw1.Modify(string.Format("t_7.text = '{0}'", Properties.Resources.DW_TXT_012));

            //// https://sofiamedix.atlassian.net/browse/MED-12154
            //dw1.Modify(string.Format("t_11.text = '{0}'", Properties.Resources.DW_TXT_013));
            //dw1.Modify(string.Format("t_12.text = '{0}'", Properties.Resources.DW_TXT_014));
            //dw1.Modify(string.Format("t_14.text = '{0}'", UserInfo.HospName));
	    }

	    private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
	//				dw1.Reset();
                    this.lay9001R.QueryLayout(true);
					break;
                case FunctionType.Process:
   //                 dw1.Export();
                    break;
				case FunctionType.Print:
					//dw1.PrintProperties.PrinterName = "NEC MultiWriter1500N";
                    //try
                    //{
                    //    dw1.Print();
                    //}
                    //catch (Exception ex)
                    //{
                    //}
                    //finally
                    //{ 
                    //}
					break;
				default:
					break;

			}
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
            this.emkYear.Text = Convert.ToString((Convert.ToInt32(emkYear.Text) - 1));
    //        dw1.Reset();
            this.lay9001R.QueryLayout(true);
		}

		private void btnPre_Click(object sender, System.EventArgs e)
		{
            this.emkYear.Text = Convert.ToString((Convert.ToInt32(emkYear.Text) + 1));
   //         dw1.Reset();
            this.lay9001R.QueryLayout(true);
		}

        private void lay9001R_QueryStarting(object sender, CancelEventArgs e)
        {
            this.lay9001R.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.lay9001R.SetBindVarValue("f_date", this.emkYear.GetDataValue());
        }

        private void lay9001R_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //if (e.IsSuccess)
            //{
            //    dw1.FillData(lay9001R.LayoutTable);
            //}

        }

        private void dw1_Click(object sender, EventArgs e)
        {
  //          this.dw1.Refresh();
        }

        private void dw1_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
   //         this.dw1.Refresh();
        }

        #region Cloud connector updated code

        #region GetLay9001R
        /// <summary>
        /// GetLay9001R
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLay9001R(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            DRG9001R02Lay9001Args args = new DRG9001R02Lay9001Args();
            args.Date = bvc["f_date"].VarValue;
            DRG9001R02Lay9001Result res = CloudService.Instance.Submit<DRG9001R02Lay9001Result, DRG9001R02Lay9001Args>(args);

            if (null != res)
            {
                foreach (DRG9001R02Lay9001Info item in res.Lay9001Item)
                {
                    lObj.Add(new object[]
                    {
                        item.HoliDay,
                        item.DrgCnt,
                        item.DrgGroupCnt,
                        item.DrgHangmogCnt,
                        item.InjCnt,
                        item.InjGroupCnt,
                        item.InjHangmogCnt,
                        item.DrgInjCnt,
                        item.DrgInjGroupCnt,
                        item.DrgInjHangmogCnt,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #endregion
	}
}


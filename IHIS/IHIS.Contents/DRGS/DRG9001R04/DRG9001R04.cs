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

#endregion

namespace IHIS.DRGS
{
	/// <summary>
	/// DRG9001R04에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG9001R04 : IHIS.Framework.XScreen
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
		private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XDictComboBox cboHoDong;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DRG9001R04()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG9001R04));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cboHoDong = new IHIS.Framework.XDictComboBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnPre = new IHIS.Framework.XButton();
            this.btnNext = new IHIS.Framework.XButton();
            this.emkYear = new IHIS.Framework.XEditMask();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.lay9001R = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay9001R)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.cboHoDong);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.btnPre);
            this.xPanel1.Controls.Add(this.btnNext);
            this.xPanel1.Controls.Add(this.emkYear);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // cboHoDong
            // 
            this.cboHoDong.ExecuteQuery = null;
            resources.ApplyResources(this.cboHoDong, "cboHoDong");
            this.cboHoDong.Name = "cboHoDong";
            this.cboHoDong.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboHoDong.ParamList")));
            this.cboHoDong.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboHoDong.UserSQL = resources.GetString("cboHoDong.UserSQL");
            this.cboHoDong.SelectedValueChanged += new System.EventHandler(this.cboHoDong_SelectedValueChanged);
            // 
            // xLabel3
            // 
            this.xLabel3.EdgeRounding = false;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
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
            this.emkYear.EditVietnameseMaskType = IHIS.Framework.MaskType.String;
            this.emkYear.IsVietnameseYearType = false;
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
            // lay9001R
            // 
            this.lay9001R.ExecuteQuery = null;
            this.lay9001R.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17});
            this.lay9001R.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("lay9001R.ParamList")));
            this.lay9001R.QuerySQL = resources.GetString("lay9001R.QuerySQL");
            this.lay9001R.QueryStarting += new System.ComponentModel.CancelEventHandler(this.lay9001R_QueryStarting);
            this.lay9001R.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.lay9001R_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "jubsu_date";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "drg_cnt";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "drg_group_cnt";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "drg_hangmog_cnt";
            this.multiLayoutItem4.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "inj_cnt";
            this.multiLayoutItem12.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "inj_group_cnt";
            this.multiLayoutItem13.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "inj_hangmog_cnt";
            this.multiLayoutItem14.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "drg_inj_cnt";
            this.multiLayoutItem15.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "drg_inj_group_cnt";
            this.multiLayoutItem16.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "drg_inj_hangmog_cnt";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Number;
            // 
            // DRG9001R04
            // 
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.xPanel1);
            this.Name = "DRG9001R04";
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
            cboHoDong.SetDataValue('%');
      //      dw1.Reset();
            this.lay9001R.QueryLayout(true);
		}

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
		//			dw1.Reset();
                    this.lay9001R.QueryLayout(true);
					break;
                case FunctionType.Process:
     //               dw1.Export();
                    break;
				case FunctionType.Print:
					//dw1.PrintProperties.PrinterName = "NEC MultiWriter1500N";
	//				dw1.Print();
					break;
				default:
					break;

			}
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
            this.emkYear.Text = Convert.ToString((Convert.ToInt32(emkYear.Text) - 1));
  //          dw1.Reset();
            this.lay9001R.QueryLayout(true);
        }
        
        private void btnPre_Click(object sender, System.EventArgs e)
        {
            this.emkYear.Text = Convert.ToString((Convert.ToInt32(emkYear.Text) + 1));
  //          dw1.Reset();
            this.lay9001R.QueryLayout(true);
        }

        private void lay9001R_QueryStarting(object sender, CancelEventArgs e)
        {
            this.lay9001R.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.lay9001R.SetBindVarValue("f_date", this.emkYear.GetDataValue());
            this.lay9001R.SetBindVarValue("f_ho_dong", this.cboHoDong.GetDataValue());
        }

        private void lay9001R_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //if (e.IsSuccess)
            //{
            //    dw1.FillData(lay9001R.LayoutTable);
            //    dw1.Modify("t_11.text = '" + this.cboHoDong.Text + "'");
            //}
        }

        private void dw1_Click(object sender, EventArgs e)
        {
    //        dw1.Refresh();
        }

        private void dw1_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
     //       dw1.Refresh();
        }

        private void cboHoDong_SelectedValueChanged(object sender, EventArgs e)
        {
  //          dw1.Reset();
            this.lay9001R.QueryLayout(true);
        }
	}
}


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
	/// DRG9001R03에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG9001R03 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XMonthBox xMonthBox1;
		private IHIS.Framework.MultiLayout lay9001R;
//		private IHIS.Framework.XDataWindow dw1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XDictComboBox cboHoDong;
		private IHIS.Framework.XDictComboBox dcbGubun;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XComboItem xComboItem5;
		private IHIS.Framework.XDictComboBox dcbprintGubun;
		private IHIS.Framework.XComboItem xComboItem7;
        private IHIS.Framework.XComboItem xComboItem8;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DRG9001R03()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG9001R03));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dcbprintGubun = new IHIS.Framework.XDictComboBox();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.dcbGubun = new IHIS.Framework.XDictComboBox();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.cboHoDong = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xMonthBox1 = new IHIS.Framework.XMonthBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.lay9001R = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lay9001R)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dcbprintGubun);
            this.xPanel1.Controls.Add(this.dcbGubun);
            this.xPanel1.Controls.Add(this.cboHoDong);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.xMonthBox1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel2
            // 
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // dcbprintGubun
            // 
            this.dcbprintGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem7,
            this.xComboItem8});
            this.dcbprintGubun.ExecuteQuery = null;
            resources.ApplyResources(this.dcbprintGubun, "dcbprintGubun");
            this.dcbprintGubun.Name = "dcbprintGubun";
            this.dcbprintGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dcbprintGubun.ParamList")));
            this.dcbprintGubun.SelectedValueChanged += new System.EventHandler(this.dcbprintGubun_SelectedValueChanged);
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "A";
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "B";
            // 
            // dcbGubun
            // 
            this.dcbGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem2,
            this.xComboItem5});
            this.dcbGubun.ExecuteQuery = null;
            resources.ApplyResources(this.dcbGubun, "dcbGubun");
            this.dcbGubun.Name = "dcbGubun";
            this.dcbGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dcbGubun.ParamList")));
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "2";
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "5";
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
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xMonthBox1
            // 
            resources.ApplyResources(this.xMonthBox1, "xMonthBox1");
            this.xMonthBox1.IsJapanYearType = true;
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
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20});
            this.lay9001R.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("lay9001R.ParamList")));
            this.lay9001R.QuerySQL = resources.GetString("lay9001R.QuerySQL");
            this.lay9001R.QueryStarting += new System.ComponentModel.CancelEventHandler(this.lay9001R_QueryStarting);
            this.lay9001R.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.lay9001R_QueryEnd);
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "jubsu_date";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "drg_cnt";
            this.multiLayoutItem6.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "drg_group_cnt";
            this.multiLayoutItem7.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "drg_hangmog_cnt";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "inj_cnt";
            this.multiLayoutItem9.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "inj_group_cnt";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "inj_hangmog_cnt";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Number;
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
            // DRG9001R03
            // 
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.xPanel1);
            this.Name = "DRG9001R03";
            resources.ApplyResources(this, "$this");
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
			cboHoDong.SetDataValue('%');
            dcbGubun.SelectedIndex = 0;
			dcbprintGubun.SetDataValue('A');

    //        dw1.Reset();
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
		//			dw1.Export();
					break;
				case FunctionType.Print:
	//				dw1.Print();
					break;
				default:
					break;

			}
		}

        private void lay9001R_QueryStarting(object sender, CancelEventArgs e)
        {
            this.lay9001R.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.lay9001R.SetBindVarValue("f_print_gubun", this.dcbprintGubun.GetDataValue());
            this.lay9001R.SetBindVarValue("f_date", this.xMonthBox1.GetDataValue());
            //this.lay9001R.SetBindVarValue("f_chubang_gubun", this.dcbGubun.GetDataValue());
            this.lay9001R.SetBindVarValue("f_ho_dong", this.cboHoDong.GetDataValue());
        }

        private void lay9001R_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //if (e.IsSuccess)
            //{
            //    dw1.FillData(lay9001R.LayoutTable);
            //}
        }

        private void xMonthBox1_ButtonClick(object sender, XMonthBoxButtonClickEventArgs e)
        {
  //          dw1.Reset();
            this.lay9001R.QueryLayout(true);
        }

        private void dw1_Click(object sender, EventArgs e)
        {
   //         dw1.Refresh();
        }

        private void dw1_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
    //        dw1.Refresh();
        }

        private void cboHoDong_SelectedValueChanged(object sender, EventArgs e)
        {
            //dw1.Reset();
            //dw1.Modify("t_11.text = '" + this.cboHoDong.Text + "'");
            //dw1.Refresh();
            this.lay9001R.QueryLayout(true);
        }

        //private void dcbGubun_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    dw1.Reset();
        //    dw1.Modify("t_13.text = '" + this.dcbGubun.Text + "'");
        //    dw1.Refresh();
        //    this.lay9001R.QueryLayout(true);
        //}

        private void dcbprintGubun_SelectedValueChanged(object sender, EventArgs e)
        {
   //         dw1.Reset();
            this.lay9001R.QueryLayout(true);
        }


	}
}


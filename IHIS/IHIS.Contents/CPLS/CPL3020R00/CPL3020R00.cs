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

namespace IHIS.CPLS
{
	/// <summary>
	/// CPL3020R00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CPL3020R00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
//		private IHIS.Framework.XDataWindow dw1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XDatePicker dtpFromDate;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XDatePicker dtpToDate;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XTextBox txtFromResult;
		private System.Windows.Forms.Label label2;
		private IHIS.Framework.XTextBox txtToResult;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XFindBox fbxGumsaHangmog;
		private IHIS.Framework.XFindWorker fwkGumsaHangmog;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.MultiLayout layCPL3020R;
		private IHIS.Framework.XDisplayBox dbxGumsaName;
        private IHIS.Framework.SingleLayout vsvGumsaName;
        private SingleLayoutItem singleLayoutItem1;
        private XRadioButton rbxAll;
        private XRadioButton rbxSelected;
        private ToolTip toolTip1;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private IContainer components;

		public CPL3020R00()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL3020R00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.rbxSelected = new IHIS.Framework.XRadioButton();
            this.rbxAll = new IHIS.Framework.XRadioButton();
            this.dbxGumsaName = new IHIS.Framework.XDisplayBox();
            this.txtToResult = new IHIS.Framework.XTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFromResult = new IHIS.Framework.XTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.fbxGumsaHangmog = new IHIS.Framework.XFindBox();
            this.fwkGumsaHangmog = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
    //        this.dw1 = new IHIS.Framework.XDataWindow();
            this.layCPL3020R = new IHIS.Framework.MultiLayout();
            this.vsvGumsaName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCPL3020R)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.rbxSelected);
            this.pnlTop.Controls.Add(this.rbxAll);
            this.pnlTop.Controls.Add(this.dbxGumsaName);
            this.pnlTop.Controls.Add(this.txtToResult);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.txtFromResult);
            this.pnlTop.Controls.Add(this.xLabel3);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.fbxGumsaHangmog);
            this.pnlTop.Controls.Add(this.dtpToDate);
            this.pnlTop.Controls.Add(this.dtpFromDate);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(919, 32);
            this.pnlTop.TabIndex = 0;
            // 
            // rbxSelected
            // 
            this.rbxSelected.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxSelected.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightSalmon);
            this.rbxSelected.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxSelected.FlatAppearance.BorderSize = 20;
            this.rbxSelected.FlatAppearance.CheckedBackColor = System.Drawing.Color.OrangeRed;
            this.rbxSelected.Location = new System.Drawing.Point(818, 4);
            this.rbxSelected.Name = "rbxSelected";
            this.rbxSelected.Size = new System.Drawing.Size(94, 23);
            this.rbxSelected.TabIndex = 19;
            this.rbxSelected.Text = "登録項目照会";
            this.rbxSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxSelected.UseVisualStyleBackColor = false;
            this.rbxSelected.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            this.rbxSelected.MouseHover += new System.EventHandler(this.rbx_MouseHover);
            // 
            // rbxAll
            // 
            this.rbxAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbxAll.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.SkyBlue);
            this.rbxAll.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxAll.Checked = true;
            this.rbxAll.FlatAppearance.BorderSize = 20;
            this.rbxAll.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkCyan;
            this.rbxAll.Location = new System.Drawing.Point(723, 4);
            this.rbxAll.Name = "rbxAll";
            this.rbxAll.Size = new System.Drawing.Size(94, 23);
            this.rbxAll.TabIndex = 18;
            this.rbxAll.TabStop = true;
            this.rbxAll.Text = "選択項目照会";
            this.rbxAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbxAll.UseVisualStyleBackColor = false;
            this.rbxAll.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            this.rbxAll.MouseHover += new System.EventHandler(this.rbx_MouseHover);
            // 
            // dbxGumsaName
            // 
            this.dbxGumsaName.EdgeRounding = false;
            this.dbxGumsaName.Location = new System.Drawing.Point(424, 6);
            this.dbxGumsaName.Name = "dbxGumsaName";
            this.dbxGumsaName.Size = new System.Drawing.Size(157, 20);
            this.dbxGumsaName.TabIndex = 15;
            // 
            // txtToResult
            // 
            this.txtToResult.Location = new System.Drawing.Point(683, 6);
            this.txtToResult.Name = "txtToResult";
            this.txtToResult.Size = new System.Drawing.Size(32, 20);
            this.txtToResult.TabIndex = 14;
            this.txtToResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtToResult.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Query_DataValidating);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(671, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "~";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFromResult
            // 
            this.txtFromResult.Location = new System.Drawing.Point(639, 6);
            this.txtFromResult.Name = "txtFromResult";
            this.txtFromResult.Size = new System.Drawing.Size(32, 20);
            this.txtFromResult.TabIndex = 12;
            this.txtFromResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFromResult.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Query_DataValidating);
            // 
            // xLabel3
            // 
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Location = new System.Drawing.Point(586, 6);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(53, 20);
            this.xLabel3.TabIndex = 10;
            this.xLabel3.Text = "結果値";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(282, 6);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(64, 20);
            this.xLabel1.TabIndex = 9;
            this.xLabel1.Text = "検査項目";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fbxGumsaHangmog
            // 
            this.fbxGumsaHangmog.FindWorker = this.fwkGumsaHangmog;
            this.fbxGumsaHangmog.Location = new System.Drawing.Point(346, 6);
            this.fbxGumsaHangmog.MaxLength = 5;
            this.fbxGumsaHangmog.Name = "fbxGumsaHangmog";
            this.fbxGumsaHangmog.Size = new System.Drawing.Size(78, 20);
            this.fbxGumsaHangmog.TabIndex = 8;
            this.fbxGumsaHangmog.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxGumsaHangmog.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Query_DataValidating);
            // 
            // fwkGumsaHangmog
            // 
            this.fwkGumsaHangmog.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkGumsaHangmog.FormText = "検査項目";
            this.fwkGumsaHangmog.InputSQL = resources.GetString("fwkGumsaHangmog.InputSQL");
            this.fwkGumsaHangmog.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkGumsaHangmog.ServerFilter = true;
            this.fwkGumsaHangmog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkGumsaHangmog_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.Yes;
            this.findColumnInfo1.HeaderText = "検査コード";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 407;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.Yes;
            this.findColumnInfo2.HeaderText = "検査項目";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(181, 6);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(95, 20);
            this.dtpToDate.TabIndex = 7;
            this.dtpToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Query_DataValidating);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(68, 6);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(95, 20);
            this.dtpFromDate.TabIndex = 5;
            this.dtpFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Query_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(4, 6);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(64, 20);
            this.xLabel2.TabIndex = 4;
            this.xLabel2.Text = "検査期間";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(167, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "~";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 550);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(919, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.F12, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F1, "Excel", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.F2, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(589, 4);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(325, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // dw1
            // 
            //this.dw1.DataWindowObject = "d_cpl3020r00_a";
            //this.dw1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.dw1.LibraryList = "..\\CPLS\\cpls.cpl3020r00.pbd";
            //this.dw1.Location = new System.Drawing.Point(0, 32);
            //this.dw1.Name = "dw1";
            //this.dw1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.VerticalAndHorizontalSplit;
            //this.dw1.Size = new System.Drawing.Size(919, 518);
            //this.dw1.TabIndex = 2;
            //this.dw1.Text = "xDataWindow1";
            // 
            // layCPL3020R
            // 
            this.layCPL3020R.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26});
            this.layCPL3020R.QuerySQL = resources.GetString("layCPL3020R.QuerySQL");
            this.layCPL3020R.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCPL3020R_QueryStarting);
            // 
            // vsvGumsaName
            // 
            this.vsvGumsaName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.vsvGumsaName.QuerySQL = "SELECT DISTINCT\r\n       GUMSA_NAME\r\n  FROM CPL0101\r\n WHERE HOSP_CODE    = :f_hosp" +
                "_code \r\n   AND HANGMOG_CODE = :f_hangmog_code";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxGumsaName;
            this.singleLayoutItem1.DataName = "dbxGumsaName";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 40;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "bunho";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "suname";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "age";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "sex";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "ho_dong1";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "toiwon_date";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "toiwon_sayu";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "doctor";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "part_jubsu_date";
            this.multiLayoutItem20.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "cpl_result";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "gumsa_name";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "from_standard";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "to_standard";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "standard_yn";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "before_result";
            // 
            // CPL3020R00
            // 
     //       this.Controls.Add(this.dw1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "CPL3020R00";
            this.Size = new System.Drawing.Size(919, 590);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCPL3020R)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate().AddDays(-6));
			this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate().ToString());
			this.fbxGumsaHangmog.AcceptData();
		}

        private void Query_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.SetMsg("");

            if (this.fbxGumsaHangmog.GetDataValue() == "")
            {
                this.dbxGumsaName.ResetData();
                return;
            }

            // 시작일자, 종료일자 널체크
            if (TypeCheck.IsNull(this.dtpFromDate.GetDataValue()))
            {
                XMessageBox.Show("開示日付けを入力してください。");
                this.dtpFromDate.Focus();

                return;
            }
            if (TypeCheck.IsNull(this.dtpToDate.GetDataValue()))
            {
                XMessageBox.Show("終了日付を入力してください。");
                this.dtpToDate.Focus();

                return;
            }

            // 시작일자가 종료일자보다 전일경우 경고 메세지	
            if (this.dtpFromDate.GetDataValue().CompareTo(this.dtpToDate.GetDataValue()) > 0)
            {
                XMessageBox.Show("検査期間を確認してください。");
                this.dtpFromDate.Focus();
                return;
            }

            this.vsvGumsaName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.vsvGumsaName.SetBindVarValue("f_hangmog_code", this.fbxGumsaHangmog.GetDataValue());
            this.vsvGumsaName.QueryLayout();

            if (vsvGumsaName.GetItemValue("dbxGumsaName").ToString() == "")
            {
                e.Cancel = true;
                this.SetMsg("検査項目コードが有効ではありません。", MsgType.Error);
                return;
            }

     //       this.dw1.Modify("t_5.text = '" + dbxGumsaName.Text + "'");   //검사항목

            this.GetData();		
        }

		private void GetData()
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;

	//			this.dw1.Reset();
				this.layCPL3020R.Reset();

                this.layCPL3020R.QueryLayout(true);

    ////			this.dw1.FillData(layCPL3020R.LayoutTable);			
	
    //            this.dw1.Modify("t_11.text = '" + dtpFromDate.Text + "'");    //From일자
    //            this.dw1.Modify("t_12.text = '" + dtpToDate.Text + "'");      //To일자				
    //            this.dw1.Modify("t_7.text = '" + txtFromResult.Text + "'");       //기준치From 
    //            this.dw1.Modify("t_10.text = '" + txtToResult.Text + "'");        //기준치To

    //            this.dw1.Refresh();
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:     //조회
					e.IsBaseCall = false;
					this.GetData();
					break;
	
				case FunctionType.Process:   //Excel
					e.IsBaseCall = false;
	//				if(dw1.RowCount == 0) return;

					//엑셀로 출력물 넣기
	//				dw1.Export(true);
//					string fileName;   
//
//					SaveFileDialog saveFileDialogExcel = new SaveFileDialog();       
//					saveFileDialogExcel.Filter = "excel files (*.xls)|*.xls";
//					saveFileDialogExcel.FilterIndex = 1;
//					saveFileDialogExcel.RestoreDirectory = true ;
//					saveFileDialogExcel.OverwritePrompt  = false ;
//
//					if(saveFileDialogExcel.ShowDialog() == DialogResult.OK)
//					{   
//						fileName = saveFileDialogExcel.FileName;     
//					}
//					else
//					{
//						return;
//					}
//   
//					dw1.SaveAsFormattedText(fileName,"\t","","\r\n", true, Sybase.DataWindow.FileSaveAsEncoding.Ansi); 
					break;
	
				case FunctionType.Print:
                    //if (this.dw1.RowCount > 0)
                    //{
                    //    try
                    //    {
                    //        this.dw1.Print();
                    //    }
                    //    catch
                    //    {
                    //        //프린터설정이안되어있습니다.프린터설정을확인해주십시오
                    //        XMessageBox.Show("プリンターの設定がされていません。\r\nプリンターの設定を確認してください。");
                    //    }
                    //}
                    //break;

				default:
					break;
			}
		}


        private void fwkGumsaHangmog_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkGumsaHangmog.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layCPL3020R_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCPL3020R.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layCPL3020R.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.layCPL3020R.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            this.layCPL3020R.SetBindVarValue("f_hangmog_code", this.fbxGumsaHangmog.GetDataValue());
            this.layCPL3020R.SetBindVarValue("f_from_result", this.txtFromResult.GetDataValue());
            this.layCPL3020R.SetBindVarValue("f_to_result", this.txtToResult.GetDataValue());
            this.layCPL3020R.SetBindVarValue("f_chk_hangmog", this.rbxAll.Checked?"Y":"N");
        }

        private void rbx_CheckedChanged(object sender, EventArgs e)
        {
    //        this.dw1.Reset();

            if (this.rbxAll.Checked)
            {
                fbxGumsaHangmog.Enabled = true;
                //dw1.DataWindowObject = "d_cpl3020r00_a";
            }
            else
            {
                fbxGumsaHangmog.ResetData();
                fbxGumsaHangmog.Enabled = false;
                dbxGumsaName.ResetData();
  //              this.dw1.Modify("t_5.text = ''");   //검사항목
            }

            this.GetData();
        }

        private void rbx_MouseHover(object sender, EventArgs e)
        {
            XRadioButton rb = sender as XRadioButton;
            string tooltip_str = "";

            if(rb.Name == "rbxAll")
                tooltip_str = "照会条件で選択した検査項目を照会します。";            
            else
                tooltip_str = "基準情報に登録登録した検査項目を照会します。";

            toolTip1.SetToolTip(rb, tooltip_str); 
        }
	}
}


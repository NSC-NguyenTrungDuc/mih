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

namespace IHIS.DRGS
{
	/// <summary>
	/// DRG3010Q03에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG3010Q03 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XBuseoCombo cboBuseo;
//		private IHIS.Framework.XDataWindow dw1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XMstGrid grdMaster;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XDatePicker dptDt;
		private IHIS.Framework.MultiLayout layDetail;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private IHIS.Framework.MultiLayout layDetail2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XDictComboBox cboDong;
		private IHIS.Framework.XCheckBox chb1;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DRG3010Q03()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG3010Q03));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.chb1 = new IHIS.Framework.XCheckBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cboDong = new IHIS.Framework.XDictComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dptDt = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboBuseo = new IHIS.Framework.XBuseoCombo();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.layDetail = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.layDetail2 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBuseo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDetail2)).BeginInit();
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
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            // 
            // radioButton2
            // 
            this.radioButton2.ForeColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grdMaster);
            this.pnlTop.Controls.Add(this.xPanel1);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.cboBuseo);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Name = "pnlTop";
            // 
            // grdMaster
            // 
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell5,
            this.xEditGridCell4});
            this.grdMaster.ColPerLine = 3;
            this.grdMaster.Cols = 4;
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(28);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMaster_RowFocusChanged);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "magam_date";
            this.xEditGridCell1.CellWidth = 67;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "magam_ser";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell2.CellWidth = 32;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "magam_time";
            this.xEditGridCell3.CellWidth = 88;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.Mask = "##:##";
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "magam_gubun";
            this.xEditGridCell5.CellWidth = 58;
            this.xEditGridCell5.CodeDisplay = false;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.DictColumn = "MAGAM_GUBUN";
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell4.CellName = "magam_cancel";
            this.xEditGridCell4.CellWidth = 35;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.RowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell4.SelectedForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.chb1);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.cboDong);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dptDt);
            this.xPanel1.Controls.Add(this.radioButton2);
            this.xPanel1.Controls.Add(this.radioButton1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // chb1
            // 
            this.chb1.Checked = true;
            this.chb1.CheckedText = "締切回次別";
            this.chb1.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.chb1, "chb1");
            this.chb1.Name = "chb1";
            this.chb1.UnCheckedText = "全体";
            this.chb1.UseVisualStyleBackColor = false;
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // cboDong
            // 
            this.cboDong.ExecuteQuery = null;
            resources.ApplyResources(this.cboDong, "cboDong");
            this.cboDong.Name = "cboDong";
            this.cboDong.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDong.ParamList")));
            this.cboDong.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDong.UserSQL = resources.GetString("cboDong.UserSQL");
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // dptDt
            // 
            resources.ApplyResources(this.dptDt, "dptDt");
            this.dptDt.IsVietnameseYearType = false;
            this.dptDt.Name = "dptDt";
            this.dptDt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dptDt_DataValidating);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // cboBuseo
            // 
            resources.ApplyResources(this.cboBuseo, "cboBuseo");
            this.cboBuseo.Name = "cboBuseo";
            // 
            // pnlFill
            // 
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.DrawBorder = true;
            this.pnlFill.Name = "pnlFill";
            // 
            // layDetail
            // 
            this.layDetail.ExecuteQuery = null;
            this.layDetail.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11});
            this.layDetail.MasterLayout = this.grdMaster;
            this.layDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDetail.ParamList")));
            this.layDetail.QuerySQL = resources.GetString("layDetail.QuerySQL");
            this.layDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDetail_QueryStarting);
            this.layDetail.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layDetail_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "ho_dong";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "ho_code";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "jaeryo_code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "jaeryo_name";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "kyukyeok";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "subul_suryang";
            this.multiLayoutItem6.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "subul_danui";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "bunho";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "name";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "order_date";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "drg_bunho";
            // 
            // layDetail2
            // 
            this.layDetail2.ExecuteQuery = null;
            this.layDetail2.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17});
            this.layDetail2.MasterLayout = this.grdMaster;
            this.layDetail2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDetail2.ParamList")));
            this.layDetail2.QuerySQL = resources.GetString("layDetail2.QuerySQL");
            this.layDetail2.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDetail2_QueryStarting);
            this.layDetail2.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layDetail2_QueryEnd);
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "ho_dong";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "jaeryo_code";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "jaeryo_name";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "kyukyeok";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "subul_suryang";
            this.multiLayoutItem16.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "subul_danui";
            // 
            // DRG3010Q03
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "DRG3010Q03";
            resources.ApplyResources(this, "$this");
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.DRG3010Q03_ScreenOpen);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBuseo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDetail2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
		}
		#endregion

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			bool isSucess; // 데이타서비스 성공여부
			switch(e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					isSucess =  this.grdMaster.QueryLayout(false);

                    //dw1.DataWindowObject = "d_inj0501p01";
                    //dw1.Reset();
                    //dw1.Refresh();
					dwRetrieve();
					break;
				case FunctionType.Print:
                    //if(dw1.RowCount > 0)
                    //{
                    //    dw1.Print();
                    //}
					break;
				default:
					break;
			}
		}

		private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if (!e.IsSuccess) 
					{
						XMessageBox.Show(Service.ErrFullMsg, "Process Error");
						break;
					}
					else
					{
						radioButton1.Checked = true;
						dwRetrieve();
					}
					break;
				default:
					break;
			}
		}
		private void grdMaster_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            layDetail.QueryLayout(false);
            if (Service.ErrMsg == "")
			{
				dwRetrieve();
			}
		}

		private void dwRetrieve()
		{
	//		dw1.Reset();
			// 환자별
			if (radioButton1.Checked)
			{
                layDetail.QueryLayout(true);
			}
			// 약품별
			if (radioButton2.Checked)
			{
                layDetail2.QueryLayout(true);
			}
		}

		private void dptDt_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			xButtonList1_ButtonClick(null, new ButtonClickEventArgs(FunctionType.Query,true,true));
		}

		private void radioButton2_Click(object sender, System.EventArgs e)
		{
			dwRetrieve();
		}

		private void DRG3010Q03_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			if (e.OpenParam != null)
			{
				dptDt.SetEditValue(OpenParam["dt"]);
				xButtonList1_ButtonClick(null, new ButtonClickEventArgs(FunctionType.Query,true,true));
			}
			else
			{
				this.dptDt.SetDataValue(IHIS.Framework.EnvironInfo.GetSysDate());
			}
			cboDong.SetEditValue("%");
		}

        private void layDetail_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			if (e.IsSuccess == true)
			{
	//			dw1.DataWindowObject = "d_inj0501p01";
				string  mamag_date = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "magam_date");
				string  mamag_ser  = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "magam_ser");
				if(!chb1.Checked) mamag_ser = chb1.UnCheckedText;

                //dw1.FillData(layDetail.LayoutTable);
                //dw1.Modify("t_mamag_date.text = '" + mamag_date + "'");
                //dw1.Modify("t_mamag_ser.text  = '" + mamag_ser  + "'" );
			}		
		}

        private void layDetail2_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
            if (e.IsSuccess == true)
			{
		//		dw1.DataWindowObject = "d_inj0501p00";
				string  mamag_date = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "magam_date");
				string  mamag_ser  = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "magam_ser");
				if(!chb1.Checked) mamag_ser = chb1.UnCheckedText;

                //dw1.FillData(layDetail2.LayoutTable);
                //dw1.Modify("t_mamag_date.text = '" + mamag_date + "'");
                //dw1.Modify("t_mamag_ser.text  = '" + mamag_ser  + "'" );
			}

        }

        #region 각 그리드/레이아웃에 바인드변수 설정
        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            grdMaster.SetBindVarValue("f_magam_date", dptDt.GetDataValue());
        }

        private void layDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            layDetail.SetBindVarValue("f_ho_dong",     cboDong.GetDataValue());
            layDetail.SetBindVarValue("f_all_gubun",   chb1.GetDataValue());
            layDetail.SetBindVarValue("f_dt",          grdMaster.GetItemString(grdMaster.CurrentRowNumber, "magam_date"));
            layDetail.SetBindVarValue("f_magam_ser",   grdMaster.GetItemString(grdMaster.CurrentRowNumber, "magam_ser"));
            layDetail.SetBindVarValue("f_magam_gubun", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "magam_gubun"));
        }

        private void layDetail2_QueryStarting(object sender, CancelEventArgs e)
        {
            layDetail2.SetBindVarValue("f_ho_dong",     cboDong.GetDataValue());
            layDetail2.SetBindVarValue("f_all_gubun",   chb1.GetDataValue());
            layDetail2.SetBindVarValue("f_dt",          grdMaster.GetItemString(grdMaster.CurrentRowNumber, "magam_date"));
            layDetail2.SetBindVarValue("f_magam_ser",   grdMaster.GetItemString(grdMaster.CurrentRowNumber, "magam_ser"));
            layDetail2.SetBindVarValue("f_magam_gubun", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "magam_gubun"));
        }
        #endregion
    }
}


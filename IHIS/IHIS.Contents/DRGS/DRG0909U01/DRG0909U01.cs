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

namespace IHIS.DRGS
{
	/// <summary>
	/// DRG0909U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG0909U01 : IHIS.Framework.XScreen
	{
		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XEditGrid grdDRG0909;
		private IHIS.Framework.XComboBox cboQuery;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XLabel lblQuery;
        private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XButton btnExcel;
        private IHIS.Framework.XPanel pnlButton;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XToolTip xToolTip1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public DRG0909U01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		}
		#endregion

		#region 소멸자
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
		#endregion

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG0909U01));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cboQuery = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.lblQuery = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.pnlButton = new IHIS.Framework.XPanel();
            this.btnExcel = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdDRG0909 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xToolTip1 = new IHIS.Framework.XToolTip();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDRG0909)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cboQuery);
            this.pnlTop.Controls.Add(this.lblQuery);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1220, 31);
            this.pnlTop.TabIndex = 0;
            // 
            // cboQuery
            // 
            this.cboQuery.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.cboQuery.Location = new System.Drawing.Point(89, 5);
            this.cboQuery.MaxDropDownItems = 40;
            this.cboQuery.Name = "cboQuery";
            this.cboQuery.Size = new System.Drawing.Size(130, 21);
            this.cboQuery.TabIndex = 4;
            this.cboQuery.SelectedIndexChanged += new System.EventHandler(this.cboQuery_SelectedIndexChanged);
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "薬局";
            this.xComboItem1.ValueItem = "DRG";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "検体検査";
            this.xComboItem2.ValueItem = "CPL";
            // 
            // lblQuery
            // 
            this.lblQuery.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblQuery.EdgeRounding = false;
            this.lblQuery.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblQuery.Location = new System.Drawing.Point(9, 5);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(80, 21);
            this.lblQuery.TabIndex = 5;
            this.lblQuery.Text = "照会条件";
            this.lblQuery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlButton);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 745);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1220, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnExcel);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlButton.Location = new System.Drawing.Point(0, 0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Padding = new System.Windows.Forms.Padding(4);
            this.pnlButton.Size = new System.Drawing.Size(200, 35);
            this.pnlButton.TabIndex = 2;
            // 
            // btnExcel
            // 
            this.btnExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExcel.ImageIndex = 0;
            this.btnExcel.ImageList = this.ImageList;
            this.btnExcel.Location = new System.Drawing.Point(4, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(100, 27);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.Text = "EXCEL";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Location = new System.Drawing.Point(976, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(244, 35);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdDRG0909
            // 
            this.grdDRG0909.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19});
            this.grdDRG0909.ColPerLine = 17;
            this.grdDRG0909.ColResizable = true;
            this.grdDRG0909.Cols = 17;
            this.grdDRG0909.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDRG0909.FixedRows = 1;
            this.grdDRG0909.HeaderHeights.Add(27);
            this.grdDRG0909.Location = new System.Drawing.Point(0, 31);
            this.grdDRG0909.Name = "grdDRG0909";
            this.grdDRG0909.QuerySQL = resources.GetString("grdDRG0909.QuerySQL");
            this.grdDRG0909.ReadOnly = true;
            this.grdDRG0909.Rows = 2;
            this.grdDRG0909.Size = new System.Drawing.Size(1220, 714);
            this.grdDRG0909.TabIndex = 2;
            this.grdDRG0909.ToolTipActive = true;
            this.grdDRG0909.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDRG0909_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "hangmog_code";
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.HeaderText = "項目コード";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hangmog_name";
            this.xEditGridCell2.CellWidth = 200;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.HeaderText = "画面名";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "order_danui";
            this.xEditGridCell3.CellWidth = 64;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EnableSort = true;
            this.xEditGridCell3.HeaderText = "オーダ単位";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "sunab_danui";
            this.xEditGridCell4.CellWidth = 59;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.HeaderText = "収納単位";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "subul_danui";
            this.xEditGridCell5.CellWidth = 62;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.EnableSort = true;
            this.xEditGridCell5.HeaderText = "受払単位";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "seq";
            this.xEditGridCell6.CellWidth = 39;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.EnableSort = true;
            this.xEditGridCell6.HeaderText = "順番";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "ord_danui";
            this.xEditGridCell7.CellWidth = 93;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.EnableSort = true;
            this.xEditGridCell7.HeaderText = "オーダ単位コード";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "danui";
            this.xEditGridCell8.CellWidth = 61;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.EnableSort = true;
            this.xEditGridCell8.HeaderText = "オーダ単位";
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "change_qty1";
            this.xEditGridCell9.CellWidth = 62;
            this.xEditGridCell9.Col = 8;
            this.xEditGridCell9.EnableSort = true;
            this.xEditGridCell9.HeaderText = "変更数量1";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "change_qty2";
            this.xEditGridCell10.CellWidth = 62;
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.EnableSort = true;
            this.xEditGridCell10.HeaderText = "変更数量2";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "jaeryo_code";
            this.xEditGridCell11.Col = 10;
            this.xEditGridCell11.EnableSort = true;
            this.xEditGridCell11.HeaderText = "材料コード";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "jaeryo_name";
            this.xEditGridCell12.CellWidth = 200;
            this.xEditGridCell12.Col = 11;
            this.xEditGridCell12.EnableSort = true;
            this.xEditGridCell12.HeaderText = "材料コード名";
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "bunryu1_nm";
            this.xEditGridCell13.CellWidth = 62;
            this.xEditGridCell13.Col = 12;
            this.xEditGridCell13.EnableSort = true;
            this.xEditGridCell13.HeaderText = "分類";
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "small_code_nm";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "small_code";
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "small_code1_nm";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "small_code1";
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "sg_code";
            this.xEditGridCell16.Col = 13;
            this.xEditGridCell16.EnableSort = true;
            this.xEditGridCell16.HeaderText = "収納コード";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "sg_name";
            this.xEditGridCell17.CellWidth = 100;
            this.xEditGridCell17.Col = 14;
            this.xEditGridCell17.EnableSort = true;
            this.xEditGridCell17.HeaderText = "収納コード名";
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "sg_union";
            this.xEditGridCell18.Col = 15;
            this.xEditGridCell18.EnableSort = true;
            this.xEditGridCell18.HeaderText = "収納グループ";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "use_yn";
            this.xEditGridCell19.CellWidth = 50;
            this.xEditGridCell19.Col = 16;
            this.xEditGridCell19.HeaderText = "採用区分";
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DRG0909U01
            // 
            this.Controls.Add(this.grdDRG0909);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "DRG0909U01";
            this.Size = new System.Drawing.Size(1220, 780);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.DRG0909U01_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDRG0909)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 조회
		private void GetQuery()
		{
			if (this.cboQuery.GetDataValue().ToString() == "") return;

            if (!grdDRG0909.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg, "照会エラー", MessageBoxIcon.Hand);
                return;
            }
		}
		#endregion

		#region Screen Load
		private void DRG0909U01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			
		}
		#endregion

		#region 조회조건을 변경을 했을 때
		private void cboQuery_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//조회
			GetQuery();
		}
		#endregion

		#region 엑셀버튼을 클릭을 했을 때
		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			if(this.grdDRG0909.RowCount == 0) return;
			
			this.grdDRG0909.Export();
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if (!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					//조회
					GetQuery();
					break;
				default:
					break;
			}
		}
		#endregion

        #region grdDRG0909 바인드 변수 설정
        private void grdDRG0909_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDRG0909.SetBindVarValue("f_query",     cboQuery.GetDataValue());
            grdDRG0909.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion
    }
}

/* 2010.06.21 河中*/

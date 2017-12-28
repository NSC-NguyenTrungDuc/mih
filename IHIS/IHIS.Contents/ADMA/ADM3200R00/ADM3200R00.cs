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

namespace IHIS.ADMA
{
	/// <summary>
	/// ADM3200R00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class ADM3200R00 : IHIS.Framework.XScreen
	{
		#region 자동생성

		private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XPanel pnlLedt;
		private IHIS.Framework.XPanel pnlLeftTop;
		private IHIS.Framework.XEditGrid grdADM3200;
		private IHIS.Framework.XLabel lblHo_dong1;
        private IHIS.Framework.XBuseoCombo cboHo_dong;
        private IHIS.Framework.XButtonList btnList;
        //private IHIS.Framework.DataServiceSIMO dsvHodong_Print_List;
        //private IHIS.Framework.DataServiceSIMO dsvQuery;
        private System.Windows.Forms.ImageList imageList1;
        private IHIS.Framework.XDataWindow dw_ADM3200R00;
        private IHIS.Framework.XButton btnAllCheck;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell1;
		private System.ComponentModel.IContainer components;
		#endregion

		#region 생성자
		public ADM3200R00()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADM3200R00));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.dw_ADM3200R00 = new IHIS.Framework.XDataWindow();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlLedt = new IHIS.Framework.XPanel();
            this.btnAllCheck = new IHIS.Framework.XButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grdADM3200 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.pnlLeftTop = new IHIS.Framework.XPanel();
            this.cboHo_dong = new IHIS.Framework.XBuseoCombo();
            this.lblHo_dong1 = new IHIS.Framework.XLabel();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlLedt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdADM3200)).BeginInit();
            this.pnlLeftTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageSize = new System.Drawing.Size(28, 28);
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.dw_ADM3200R00);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 552);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(399, 38);
            this.pnlBottom.TabIndex = 1;
            // 
            // dw_ADM3200R00
            // 
            this.dw_ADM3200R00.DataWindowObject = "adm3200r00";
            this.dw_ADM3200R00.LibraryList = "..\\ADMA\\adma.adm3200r00.pbd";
            this.dw_ADM3200R00.Location = new System.Drawing.Point(8, 8);
            this.dw_ADM3200R00.Name = "dw_ADM3200R00";
            this.dw_ADM3200R00.Size = new System.Drawing.Size(26, 24);
            this.dw_ADM3200R00.TabIndex = 2;
            this.dw_ADM3200R00.Text = "xDataWindow1";
            this.dw_ADM3200R00.Visible = false;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisiblePreview = false;
            this.btnList.Location = new System.Drawing.Point(155, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(244, 38);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlLedt
            // 
            this.pnlLedt.Controls.Add(this.btnAllCheck);
            this.pnlLedt.Controls.Add(this.grdADM3200);
            this.pnlLedt.Controls.Add(this.pnlLeftTop);
            this.pnlLedt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLedt.Location = new System.Drawing.Point(0, 0);
            this.pnlLedt.Name = "pnlLedt";
            this.pnlLedt.Size = new System.Drawing.Size(399, 552);
            this.pnlLedt.TabIndex = 2;
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAllCheck.ImageList = this.imageList1;
            this.btnAllCheck.Location = new System.Drawing.Point(26, 33);
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Size = new System.Drawing.Size(37, 22);
            this.btnAllCheck.TabIndex = 7;
            this.btnAllCheck.Tag = "N";
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "YESEN1.ICO");
            this.imageList1.Images.SetKeyName(1, "YESUP1.ICO");
            this.imageList1.Images.SetKeyName(2, "전송_16.gif");
            // 
            // grdADM3200
            // 
            this.grdADM3200.ApplyPaintEventToAllColumn = true;
            this.grdADM3200.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell1});
            this.grdADM3200.ColPerLine = 5;
            this.grdADM3200.Cols = 6;
            this.grdADM3200.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdADM3200.FixedCols = 1;
            this.grdADM3200.FixedRows = 1;
            this.grdADM3200.HeaderHeights.Add(21);
            this.grdADM3200.Location = new System.Drawing.Point(0, 33);
            this.grdADM3200.Name = "grdADM3200";
            this.grdADM3200.QuerySQL = resources.GetString("grdADM3200.QuerySQL");
            this.grdADM3200.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdADM3200.RowHeaderVisible = true;
            this.grdADM3200.Rows = 2;
            this.grdADM3200.RowStateCheckOnPaint = false;
            this.grdADM3200.Size = new System.Drawing.Size(399, 519);
            this.grdADM3200.TabIndex = 1;
            this.grdADM3200.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdADM3200_ItemValueChanging);
            this.grdADM3200.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP1001_QueryStarting);
            this.grdADM3200.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdADM3200_GridCellPainting);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "user_id";
            this.xEditGridCell14.Col = 2;
            this.xEditGridCell14.HeaderText = "ID";
            this.xEditGridCell14.IsReadOnly = true;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "user_nm";
            this.xEditGridCell15.Col = 3;
            this.xEditGridCell15.HeaderText = "名前";
            this.xEditGridCell15.IsReadOnly = true;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "gwa";
            this.xEditGridCell16.Col = 4;
            this.xEditGridCell16.HeaderText = "病棟";
            this.xEditGridCell16.IsReadOnly = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "co_id";
            this.xEditGridCell17.Col = 5;
            this.xEditGridCell17.HeaderText = "社員番号";
            this.xEditGridCell17.IsReadOnly = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "check";
            this.xEditGridCell1.CellWidth = 36;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            // 
            // pnlLeftTop
            // 
            this.pnlLeftTop.Controls.Add(this.cboHo_dong);
            this.pnlLeftTop.Controls.Add(this.lblHo_dong1);
            this.pnlLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftTop.Name = "pnlLeftTop";
            this.pnlLeftTop.Size = new System.Drawing.Size(399, 33);
            this.pnlLeftTop.TabIndex = 0;
            // 
            // cboHo_dong
            // 
            this.cboHo_dong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHo_dong.IsAppendAll = true;
            this.cboHo_dong.Location = new System.Drawing.Point(70, 6);
            this.cboHo_dong.MaxDropDownItems = 40;
            this.cboHo_dong.Name = "cboHo_dong";
            this.cboHo_dong.Size = new System.Drawing.Size(107, 21);
            this.cboHo_dong.TabIndex = 1;
            this.cboHo_dong.SelectionChangeCommitted += new System.EventHandler(this.cboHo_dong_SelectionChangeCommitted);
            // 
            // lblHo_dong1
            // 
            this.lblHo_dong1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_dong1.EdgeRounding = false;
            this.lblHo_dong1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHo_dong1.Location = new System.Drawing.Point(5, 6);
            this.lblHo_dong1.Name = "lblHo_dong1";
            this.lblHo_dong1.Size = new System.Drawing.Size(65, 21);
            this.lblHo_dong1.TabIndex = 0;
            this.lblHo_dong1.Text = "病棟";
            this.lblHo_dong1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ADM3200R00
            // 
            this.Controls.Add(this.pnlLedt);
            this.Controls.Add(this.pnlBottom);
            this.Name = "ADM3200R00";
            this.Size = new System.Drawing.Size(399, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.ADM3200R00_ScreenOpen);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlLedt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdADM3200)).EndInit();
            this.pnlLeftTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 출력물 선택시 색상과 이미지 변경(클릭시)
		private void Click_SetCheckImage(object sender)
		{
			IHIS.Framework.XRadioButton rb = (IHIS.Framework.XRadioButton)sender;

			if (rb.Tag.ToString() == "N")
			{
                rb.BackColor = XColor.ActiveBorderColor; // new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveBorderColor);
				rb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rb.Tag = "Y";
				rb.Checked = true;
				rb.ImageIndex = 1;
			}
			else
			{
                rb.BackColor = XColor.XDisplayBoxBorderColor; // new IHIS.Framework.XColor(System.Drawing.SystemColors.XDisplayBoxBorderColor);
				rb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rb.Tag = "N";
				rb.Checked = false;
				rb.ImageIndex = 0;
			}
		}
		#endregion

		
		#region 조회
		private void GetQuery()
		{
			if (this.cboHo_dong.GetDataValue().ToString() == "") return;

			this.grdADM3200.Reset();

			this.btnAllCheck.ImageIndex = 0;
			this.btnAllCheck.Tag = "N";

			if (!this.grdADM3200.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg);
				return;
			}
		}
		#endregion

		#region 인쇄
		private void SetPrint(string aPrintGubun, int aRow)
		{
			this.dw_ADM3200R00.Reset();
			
			switch(aPrintGubun)
			{
				case "1": //환자명
					this.dw_ADM3200R00.InsertRow(1);
                    this.dw_ADM3200R00.SetItemString(this.dw_ADM3200R00.CurrentRow, "name", this.grdADM3200.GetItemValue(aRow, "user_nm").ToString());
                    this.dw_ADM3200R00.SetItemString(this.dw_ADM3200R00.CurrentRow, "barcode", "a" + this.grdADM3200.GetItemValue(aRow, "co_id").ToString()+"a");
                    this.dw_ADM3200R00.SetItemString(this.dw_ADM3200R00.CurrentRow, "bunho", this.grdADM3200.GetItemValue(aRow, "user_id").ToString());
					this.dw_ADM3200R00.AcceptText();

                    dw_ADM3200R00.Print(true);

					break;
				default:
					break;
			}
		}
		#endregion

		#region Screen Load
		private void ADM3200R00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			this.cboHo_dong.SelectedIndex = 0;

            if (UserInfo.HoDong.ToString() != "")
            {
                this.cboHo_dong.SetDataValue(UserInfo.HoDong.ToString());
            }
            else
            {
                this.cboHo_dong.SelectedIndex = 0;
            }

			//조회
			GetQuery();
		}
		#endregion
	
		#region 출력물을 선택을 했을 때
		private void rb1_Click(object sender, System.EventArgs e)
		{
			Click_SetCheckImage(sender);
		}
		#endregion

		#region 전체선택을 했을 때
		private void btnAllCheck_Click(object sender, System.EventArgs e)
		{
			if (this.btnAllCheck.Tag.ToString() == "N")
			{
				this.btnAllCheck.ImageIndex = 1;
				this.btnAllCheck.Tag = "Y";

				//전체선택
				for (int i= 0; i < this.grdADM3200.RowCount; i++)
				{
                    if (grdADM3200.GetItemString(i, "co_id").Trim() != "")
                    {
                        this.grdADM3200.SetItemValue(i, "check", "Y");
                    }
				}
			}
			else
			{
				this.btnAllCheck.ImageIndex = 0;
				this.btnAllCheck.Tag = "N";

				//전체선택
				for (int i= 0; i < this.grdADM3200.RowCount; i++)
				{
					this.grdADM3200.SetItemValue(i, "check", "N");
				}
			}
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
                case FunctionType.Query:
                    GetQuery();
                    break;

				case FunctionType.Print:
					if (!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					if (this.grdADM3200.RowCount <= 0) return;

					for (int i = 0; i < this.grdADM3200.RowCount; i++)
					{
						if (this.grdADM3200.GetItemValue(i, "check").ToString() == "Y")
						{
							SetPrint("1", i);
						}
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 조회조건을 변경을 했을 때
        //private void cboWing_gubun_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    //병동별 출력물 표시
        //    SetHodongPrintImage();

        //    GetQuery();
        //}

        private void cboHo_dong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetQuery();
        }

		#endregion

        #region QueryStarting
        private void grdINP1001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdADM3200.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdADM3200.SetBindVarValue("f_ho_dong", this.cboHo_dong.GetDataValue());
        }
        #endregion

        private void grdADM3200_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            grdADM3200.ItemValueChanging -= new ItemValueChangingEventHandler(grdADM3200_ItemValueChanging);
            if (grdADM3200.GetItemString(e.RowNumber, "co_id").Trim() == "")
            {
                XMessageBox.Show("社員番号が登録されていません。登録してから印刷できます。");
                grdADM3200.SetItemValue(e.RowNumber, "check", "N");
            }
            grdADM3200.ItemValueChanging += new ItemValueChangingEventHandler(grdADM3200_ItemValueChanging);
        }

        private void grdADM3200_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (grdADM3200.GetItemString(e.RowNumber, "co_id").Trim() == "")
            {
                e.BackColor = Color.LightPink;
            }
        }

        //private void grdADM3200_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        //{
        //    if (grdADM3200.GetItemString(e.RowNumber, "co_id").Trim() == "")
        //    {
        //        XMessageBox.Show("社員番号が登録されていません。登録してから選択できます。");
        //        e.Cancel = true;
        //    }
        //}
    }
}


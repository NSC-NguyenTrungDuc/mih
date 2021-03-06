using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using IHIS.Framework;

namespace IHIS.DRGS
{
	/// <summary>
	/// Findsmall에 대한 요약 설명입니다.
	/// </summary>
	public class Findsmall : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel pnlBottom;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XMstGrid grdMaster;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGrid grdDetail2;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XMstGrid grdDetail;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private string mSmallCode = string.Empty;
		private string code = string.Empty;
		private string name = string.Empty;
		private string middle_code = string.Empty;
		private string middle_name = string.Empty;
		internal string GetCode
		{
			get{return code;}
		}
		internal string GetName
		{
			get{return name;}
		}
		internal string GetMiddleCode
		{
			get{return middle_code;}
		}
		internal string GetMiddleName
		{
			get{return middle_name;}
		}

		public Findsmall(Control cont,  string smallCode)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
		    mSmallCode = smallCode;

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//

			// 위치조정(Find창을 Call한 Control의 하단에
			if (cont != null)
			{
				/*Screen이 2개이상일 경우에는 rc의 Width는 두 모니터의 Width를 더한값, Height는
				 *Second화면의 해상도가 같으면 관계없으나, 해상도가 다르면 Second화면의 WorkingArea의 Y는
				 *0부터시작하지않고, Primary의 기준에서 얼만큼 높이에 있는냐로 처리됨.
				 *ex> Primary : 1280*1024 Second 1024*768이면 Primary.WorkingArea(0,0,1280,994) Second.WorkingArea(1280,256,1024,768)
				 *따라서, 높이는 Second의 WorkingArea의 Y + Height로 설정해야함
				 */
				Rectangle rc = Screen.PrimaryScreen.WorkingArea;
				// 위치 조정(Dual Monitor일때 Second화면에 있으면 X값은 Primary화면의Width + Second에서의 위치로 표시됨
				Point pos = cont.PointToScreen(new Point(0, cont.Height));
				if (SystemInformation.MonitorCount > 1)
				{
					//pos.X가 Second Monitor에 있으면 rc 변경
					if (pos.X > rc.Width)
					{
						Rectangle sRect = Screen.AllScreens[1].WorkingArea;
						rc = new Rectangle(rc.X, rc.Y, rc.Width + sRect.Width, sRect.Y + sRect.Height);
					}
				}

				if (this.Width > rc.Width - pos.X)
				{
					pos.X = Math.Max(rc.Width - this.Width, 0);
				}
				if (this.Height > rc.Height - pos.Y)
				{
					if (this.Height > pos.Y - cont.Height)
						pos.Y = Math.Max(rc.Height - this.Height, 0);
					else
						pos.Y -= (this.Height + cont.Height);
				}
				this.Location = pos;
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdDetail = new IHIS.Framework.XMstGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.grdDetail2 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.xButtonList1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 442);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(898, 32);
            this.pnlBottom.TabIndex = 1;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Reset, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.Location = new System.Drawing.Point(573, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.Size = new System.Drawing.Size(325, 32);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdDetail);
            this.xPanel1.Controls.Add(this.grdMaster);
            this.xPanel1.Controls.Add(this.grdDetail2);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(898, 442);
            this.xPanel1.TabIndex = 7;
            // 
            // grdDetail
            // 
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.grdDetail.ColPerLine = 2;
            this.grdDetail.Cols = 3;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(21);
            this.grdDetail.Location = new System.Drawing.Point(296, 0);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.QuerySQL = "SELECT CODE\r\n      ,CODE1\r\n      ,CODE_NAME1\r\n  FROM DRG0141\r\n WHERE CODE      = " +
                ":f_code\r\n   AND HOSP_CODE = :f_hosp_code\r\n ORDER BY CODE1";
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.Size = new System.Drawing.Size(306, 442);
            this.grdDetail.TabIndex = 8;
            this.grdDetail.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdDetail_RowFocusChanged);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 4;
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 5;
            this.xEditGridCell5.CellName = "code1";
            this.xEditGridCell5.CellWidth = 51;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.HeaderText = "中分類";
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 100;
            this.xEditGridCell6.CellName = "code_name1";
            this.xEditGridCell6.CellWidth = 195;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.HeaderText = "中分類名";
            this.xEditGridCell6.IsUpdatable = false;
            // 
            // grdMaster
            // 
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMaster.ColPerLine = 2;
            this.grdMaster.Cols = 3;
            this.grdMaster.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(21);
            this.grdMaster.Location = new System.Drawing.Point(0, 0);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.QuerySQL = "SELECT A.CODE       CODE\r\n     , A.CODE_NAME  CODE_NAME\r\n  FROM DRG0140 A\r\n WHERE" +
                " CODE      LIKE :f_code||\'%\'\r\n   AND HOSP_CODE = :f_hosp_code\r\nORDER BY 1";
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.Size = new System.Drawing.Size(296, 442);
            this.grdMaster.TabIndex = 5;
            this.grdMaster.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMaster_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 4;
            this.xEditGridCell1.CellName = "code";
            this.xEditGridCell1.CellWidth = 100;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderText = "大分類";
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "code_name";
            this.xEditGridCell2.CellWidth = 146;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderText = "大分類名";
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // grdDetail2
            // 
            this.grdDetail2.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10});
            this.grdDetail2.ColPerLine = 2;
            this.grdDetail2.Cols = 3;
            this.grdDetail2.Dock = System.Windows.Forms.DockStyle.Right;
            this.grdDetail2.FixedCols = 1;
            this.grdDetail2.FixedRows = 1;
            this.grdDetail2.HeaderHeights.Add(21);
            this.grdDetail2.Location = new System.Drawing.Point(602, 0);
            this.grdDetail2.MasterLayout = this.grdDetail;
            this.grdDetail2.Name = "grdDetail2";
            this.grdDetail2.QuerySQL = "SELECT CODE\r\n      ,CODE1\r\n      ,CODE2\r\n      ,CODE_NAME2\r\n  FROM DRG0142\r\n WHER" +
                "E CODE      = :f_code\r\n   AND CODE1     = :f_code1\r\n   AND HOSP_CODE = :f_hosp_c" +
                "ode\r\n ORDER BY CODE1";
            this.grdDetail2.RowHeaderVisible = true;
            this.grdDetail2.Rows = 2;
            this.grdDetail2.Size = new System.Drawing.Size(296, 442);
            this.grdDetail2.TabIndex = 7;
            this.grdDetail2.DoubleClick += new System.EventHandler(this.grdDetail2_DoubleClick);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "code";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "code1";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "code2";
            this.xEditGridCell9.CellWidth = 66;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.HeaderText = "小分類";
            this.xEditGridCell9.IsUpdatable = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 100;
            this.xEditGridCell10.CellName = "code_name2";
            this.xEditGridCell10.CellWidth = 170;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.HeaderText = "小分類名";
            this.xEditGridCell10.IsUpdatable = false;
            // 
            // Findsmall
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(898, 496);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Findsmall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "効能別分類";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		protected override void OnLoad(EventArgs e)
		{
			grdDetail.SetRelationKey("code","code");
			grdDetail.SetRelationTable("DRG0141");

			grdDetail2.SetRelationKey("code","code");
			grdDetail2.SetRelationKey("code1","code1");
			grdDetail2.SetRelationTable("DRG0142");
			base.OnLoad (e);
			this.CurrMQLayout = this.grdMaster;
            grdMaster.SetBindVarValue("f_code", TypeCheck.NVL(mSmallCode.Substring(0, 3), "%").ToString());
            grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            if (!grdMaster.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.No;
			this.Close();
		}


		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
                    grdMaster.SetBindVarValue("f_code", TypeCheck.NVL(mSmallCode.Substring(0, 3), "%").ToString());
                    grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    if(!grdMaster.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
					break;
				case FunctionType.Process:
					code =	grdDetail2.GetItemString(grdDetail2.CurrentRowNumber,"code2") ;
					name =	grdDetail2.GetItemString(grdDetail2.CurrentRowNumber,"code_name2") ;
					middle_code = grdDetail.GetItemString(grdDetail.CurrentRowNumber,"code1");
					middle_name = grdDetail.GetItemString(grdDetail.CurrentRowNumber,"code_name1");
					this.DialogResult = DialogResult.OK;
					this.Close();
					break;
				case FunctionType.Close:
					this.DialogResult = DialogResult.Cancel;
					this.Close();
					break;
				default:
					break;
			}
		}

		private void grdDetail2_DoubleClick(object sender, System.EventArgs e)
		{
			code =	grdDetail2.GetItemString(grdDetail2.CurrentRowNumber,"code2") ;
			name =	grdDetail2.GetItemString(grdDetail2.CurrentRowNumber,"code_name2") ;
			middle_code = grdDetail.GetItemString(grdDetail.CurrentRowNumber,"code1") ;
			middle_name = grdDetail.GetItemString(grdDetail.CurrentRowNumber,"code_name1") ;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

        private void grdMaster_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            grdDetail.SetBindVarValue("f_code", grdMaster.GetItemString(e.CurrentRow, "code"));
            grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdDetail_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            grdDetail2.SetBindVarValue("f_code", grdDetail.GetItemString(e.CurrentRow, "code"));
            grdDetail2.SetBindVarValue("f_code1", grdDetail.GetItemString(e.CurrentRow, "code1"));
            grdDetail2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
	}
}

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
	/// DRG0120Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG0120Q01 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XGroupBox gbx;
		private IHIS.Framework.XFlatRadioButton rbx1;
		private IHIS.Framework.XEditGrid grdDrg0120;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XFlatRadioButton rbx4;
		private IHIS.Framework.XFlatRadioButton rbx3;
		private IHIS.Framework.XFlatRadioButton rbx2;
		private IHIS.Framework.XFlatLabel lbxDonbog;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DRG0120Q01()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG0120Q01));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdDrg0120 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.gbx = new IHIS.Framework.XGroupBox();
            this.lbxDonbog = new IHIS.Framework.XFlatLabel();
            this.rbx4 = new IHIS.Framework.XFlatRadioButton();
            this.rbx3 = new IHIS.Framework.XFlatRadioButton();
            this.rbx2 = new IHIS.Framework.XFlatRadioButton();
            this.rbx1 = new IHIS.Framework.XFlatRadioButton();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg0120)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.gbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdDrg0120);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel2.Location = new System.Drawing.Point(5, 48);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(342, 387);
            this.xPanel2.TabIndex = 1;
            // 
            // grdDrg0120
            // 
            this.grdDrg0120.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdDrg0120.ColPerLine = 2;
            this.grdDrg0120.Cols = 3;
            this.grdDrg0120.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDrg0120.FixedCols = 1;
            this.grdDrg0120.FixedRows = 1;
            this.grdDrg0120.HeaderHeights.Add(21);
            this.grdDrg0120.Location = new System.Drawing.Point(0, 0);
            this.grdDrg0120.Name = "grdDrg0120";
            this.grdDrg0120.QuerySQL = resources.GetString("grdDrg0120.QuerySQL");
            this.grdDrg0120.ReadOnly = true;
            this.grdDrg0120.RowHeaderVisible = true;
            this.grdDrg0120.Rows = 2;
            this.grdDrg0120.Size = new System.Drawing.Size(342, 387);
            this.grdDrg0120.TabIndex = 0;
            this.grdDrg0120.DoubleClick += new System.EventHandler(this.grdDrg0120_DoubleClick);
            this.grdDrg0120.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrg0120_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bogyong_code";
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderText = "服用コード";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsUpdCol = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bogyong_name";
            this.xEditGridCell2.CellWidth = 202;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderText = "服用法";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsUpdCol = false;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xButtonList1);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel3.Location = new System.Drawing.Point(5, 435);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(342, 32);
            this.xPanel3.TabIndex = 2;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.Location = new System.Drawing.Point(98, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Process;
            this.xButtonList1.Size = new System.Drawing.Size(244, 32);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.DoubleClick += new System.EventHandler(this.xButtonList1_DoubleClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // gbx
            // 
            this.gbx.Controls.Add(this.lbxDonbog);
            this.gbx.Controls.Add(this.rbx4);
            this.gbx.Controls.Add(this.rbx3);
            this.gbx.Controls.Add(this.rbx2);
            this.gbx.Controls.Add(this.rbx1);
            this.gbx.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbx.Location = new System.Drawing.Point(5, 5);
            this.gbx.Name = "gbx";
            this.gbx.Protect = true;
            this.gbx.Size = new System.Drawing.Size(342, 43);
            this.gbx.TabIndex = 3;
            this.gbx.TabStop = false;
            this.gbx.Text = "内服薬";
            // 
            // lbxDonbog
            // 
            this.lbxDonbog.Location = new System.Drawing.Point(24, 20);
            this.lbxDonbog.Name = "lbxDonbog";
            this.lbxDonbog.Size = new System.Drawing.Size(37, 16);
            this.lbxDonbog.TabIndex = 9;
            this.lbxDonbog.Text = "頓服";
            // 
            // rbx4
            // 
            this.rbx4.AccessibleDescription = "";
            this.rbx4.CheckedValue = "11";
            this.rbx4.Location = new System.Drawing.Point(240, 16);
            this.rbx4.Name = "rbx4";
            this.rbx4.Size = new System.Drawing.Size(58, 24);
            this.rbx4.TabIndex = 8;
            this.rbx4.Text = "その他";
            this.rbx4.UseVisualStyleBackColor = false;
            this.rbx4.Click += new System.EventHandler(this.rbx1_Click);
            // 
            // rbx3
            // 
            this.rbx3.CheckedValue = "05";
            this.rbx3.Location = new System.Drawing.Point(176, 16);
            this.rbx3.Name = "rbx3";
            this.rbx3.Size = new System.Drawing.Size(56, 24);
            this.rbx3.TabIndex = 7;
            this.rbx3.Text = "食間";
            this.rbx3.UseVisualStyleBackColor = false;
            this.rbx3.Click += new System.EventHandler(this.rbx1_Click);
            // 
            // rbx2
            // 
            this.rbx2.CheckedValue = "03";
            this.rbx2.Location = new System.Drawing.Point(112, 16);
            this.rbx2.Name = "rbx2";
            this.rbx2.Size = new System.Drawing.Size(56, 24);
            this.rbx2.TabIndex = 6;
            this.rbx2.Text = "食後";
            this.rbx2.UseVisualStyleBackColor = false;
            this.rbx2.Click += new System.EventHandler(this.rbx1_Click);
            // 
            // rbx1
            // 
            this.rbx1.Checked = true;
            this.rbx1.CheckedValue = "01";
            this.rbx1.Location = new System.Drawing.Point(48, 16);
            this.rbx1.Name = "rbx1";
            this.rbx1.Size = new System.Drawing.Size(56, 24);
            this.rbx1.TabIndex = 5;
            this.rbx1.TabStop = true;
            this.rbx1.Text = "食前";
            this.rbx1.UseVisualStyleBackColor = false;
            this.rbx1.Click += new System.EventHandler(this.rbx1_Click);
            // 
            // DRG0120Q01
            // 
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.gbx);
            this.Controls.Add(this.xPanel3);
            this.Name = "DRG0120Q01";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(352, 472);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.DRG0120Q01_ScreenOpen);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg0120)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.gbx.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// 회차
		/// </summary>
 		private string bogyongGubun = string.Empty;

		/// <summary>
		/// 복용코드
		/// </summary>
		private string mBongYongCode = string.Empty;

		[Browsable(false), DataBindable]
		public string gubun
		{
			get 
			{
				foreach (Control con in gbx.Controls) 
				{
					if (con is XFlatRadioButton)  
					{
						if ( ((XFlatRadioButton)con).Checked) 
							return ((XFlatRadioButton)con).CheckedValue.ToString();
					}
				}
				return "";
			}
		}
		
		[Browsable(false), DataBindable]
		public string BogYongGubun
		{
			get 
			{
				return  bogyongGubun;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			Query();
		}

		private void Query()
		{
            grdDrg0120.QueryLayout(true);
			grdDrg0120.SetTopRow(0);
		}

		private void rbx1_Click(object sender, System.EventArgs e)
		{
			Query();
		}

		private void DRG0120Q01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			lbxDonbog.Visible= false;
			if (e.OpenParam != null)
			{
				bogyongGubun = e.OpenParam["donbog_yn"].ToString();
				if (bogyongGubun == "Y" )
				{
					rbx1.Visible = false;
					rbx2.Visible = false;
					rbx3.Visible = false;
					rbx4.Visible = false;
					lbxDonbog.Visible= true;
				}
			}
		}

		private void grdDrg0120_DoubleClick(object sender, System.EventArgs e)
		{
			returnData();
			Close();
		}

		private void returnData()
        {
            mBongYongCode = grdDrg0120.GetItemString(grdDrg0120.CurrentRowNumber, "bogyong_code");

			XScreen screenOpener = (XScreen)Opener;	
			CommonItemCollection commandParams = new CommonItemCollection();
			commandParams.Add("bogyongcode", mBongYongCode);
			screenOpener.Command(ScreenID, commandParams);
		}

		private void xButtonList1_DoubleClick(object sender, System.EventArgs e)
		{
			returnData();
			Close();
		}

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			if (e.Func == FunctionType.Process)
			{
				returnData();
				Close();
			}
        }

        #region [ 그리드에 바인드변수 설정 ]
        private void grdDrg0120_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDrg0120.SetBindVarValue("f_banghyang",     gubun);
            grdDrg0120.SetBindVarValue("f_bogyong_gubun", bogyongGubun);
        }        
        #endregion
	}
}

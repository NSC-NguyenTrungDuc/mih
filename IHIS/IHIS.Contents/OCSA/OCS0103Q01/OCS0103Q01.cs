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

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0103Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0103Q01 : IHIS.Framework.XScreen
	{
		private string mHangmog_code = "";
		private IHIS.Framework.MultiLayout layReturnValue = new MultiLayout();

		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XTextBox txtHangmog_index;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPictureBox xPictureBox1;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XGrid grdOCS0103;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell4;
		private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XGridCell xGridCell6;
		private IHIS.Framework.XGridCell xGridCell7;
		private IHIS.Framework.XGridCell xGridCell8;
		private IHIS.Framework.XButton btnProcess;

		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0103Q01()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0103Q01));
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtHangmog_index = new IHIS.Framework.XTextBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPictureBox1 = new IHIS.Framework.XPictureBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnProcess = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdOCS0103 = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            this.xGridCell7 = new IHIS.Framework.XGridCell();
            this.xGridCell8 = new IHIS.Framework.XGridCell();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).BeginInit();
            this.SuspendLayout();
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(12, 8);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(88, 21);
            this.xLabel1.TabIndex = 15;
            this.xLabel1.Text = "検索語";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHangmog_index
            // 
            this.txtHangmog_index.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtHangmog_index.Location = new System.Drawing.Point(102, 8);
            this.txtHangmog_index.Name = "txtHangmog_index";
            this.txtHangmog_index.Size = new System.Drawing.Size(384, 20);
            this.txtHangmog_index.TabIndex = 14;
            this.txtHangmog_index.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtHangmog_index_DataValidating);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.txtHangmog_index);
            this.xPanel1.Controls.Add(this.xPictureBox1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(720, 36);
            this.xPanel1.TabIndex = 16;
            // 
            // xPictureBox1
            // 
            this.xPictureBox1.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.xPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPictureBox1.BackgroundImage")));
            this.xPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.xPictureBox1.Name = "xPictureBox1";
            this.xPictureBox1.Protect = false;
            this.xPictureBox1.Size = new System.Drawing.Size(718, 34);
            this.xPictureBox1.TabIndex = 16;
            this.xPictureBox1.TabStop = false;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnProcess);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 503);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(720, 42);
            this.xPanel2.TabIndex = 17;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Location = new System.Drawing.Point(446, 5);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(98, 28);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "選択";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(544, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdOCS0103);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(0, 36);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(720, 467);
            this.xPanel3.TabIndex = 18;
            // 
            // grdOCS0103
            // 
            this.grdOCS0103.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell5,
            this.xGridCell6,
            this.xGridCell7,
            this.xGridCell8});
            this.grdOCS0103.ColPerLine = 5;
            this.grdOCS0103.Cols = 5;
            this.grdOCS0103.FixedRows = 1;
            this.grdOCS0103.HeaderHeights.Add(21);
            this.grdOCS0103.Location = new System.Drawing.Point(4, 2);
            this.grdOCS0103.Name = "grdOCS0103";
            this.grdOCS0103.QuerySQL = resources.GetString("grdOCS0103.QuerySQL");
            this.grdOCS0103.Rows = 2;
            this.grdOCS0103.Size = new System.Drawing.Size(712, 461);
            this.grdOCS0103.TabIndex = 0;
            this.grdOCS0103.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0103_QueryStarting);
            this.grdOCS0103.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0103_MouseDown);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "code_name";
            this.xGridCell1.CellWidth = 100;
            this.xGridCell1.HeaderText = "オ―ダ区分";
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "hangmog_code";
            this.xGridCell2.CellWidth = 87;
            this.xGridCell2.Col = 1;
            this.xGridCell2.HeaderText = "オ―ダコード";
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "hangmog_name";
            this.xGridCell3.CellWidth = 343;
            this.xGridCell3.Col = 2;
            this.xGridCell3.HeaderText = "オ―ダコード名";
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "jaeryo_code";
            this.xGridCell4.Col = 3;
            this.xGridCell4.HeaderText = "材料コード";
            // 
            // xGridCell5
            // 
            this.xGridCell5.CellName = "subul_buseo";
            this.xGridCell5.Col = 4;
            this.xGridCell5.HeaderText = "受払部署";
            // 
            // xGridCell6
            // 
            this.xGridCell6.CellName = "slip_code";
            this.xGridCell6.Col = -1;
            this.xGridCell6.HeaderText = "slip_code";
            this.xGridCell6.IsVisible = false;
            this.xGridCell6.Row = -1;
            // 
            // xGridCell7
            // 
            this.xGridCell7.CellName = "order_gubun";
            this.xGridCell7.Col = -1;
            this.xGridCell7.HeaderText = "order_gubun";
            this.xGridCell7.IsVisible = false;
            this.xGridCell7.Row = -1;
            // 
            // xGridCell8
            // 
            this.xGridCell8.CellName = "hangmog_name_inx";
            this.xGridCell8.Col = -1;
            this.xGridCell8.HeaderText = "hangmog_name_inx";
            this.xGridCell8.IsVisible = false;
            this.xGridCell8.Row = -1;
            // 
            // OCS0103Q01
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0103Q01";
            this.Size = new System.Drawing.Size(720, 545);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OCS0103Q01_Closing);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0103)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("hangmog_code"))
					{
						if(OpenParam["hangmog_code"].ToString() != "")
						{
							mHangmog_code = OpenParam["hangmog_code"].ToString();
							txtHangmog_index.SetDataValue(mHangmog_code);
						}
					}
				}
				catch
				{
				}
			}

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void OCS0103Q01_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			if(layReturnValue.LayoutTable.Rows.Count > 0)
			{
				CommonItemCollection commandParams  = new CommonItemCollection();
				commandParams.Add( "OCS0103", layReturnValue);
				scrOpener.Command("OCS0103", commandParams);
			}
		}

		private void PostLoad()
		{	
			CreateLayout();
			grdOCS0103.SetBindVarValue("f_hangmog_idx",txtHangmog_index.GetDataValue());
			grdOCS0103.QueryLayout(false);

			txtHangmog_index.Focus();
			txtHangmog_index.SelectAll();

		}

		private void CreateLayout()
		{
			// LayoutItems 생성
			foreach(XGridCell cell in this.grdOCS0103.CellInfos)
			{
				layReturnValue.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
			}

			layReturnValue.InitializeLayoutTable();				
		}
		#endregion

		#region [Control Event]
		private void txtHangmog_index_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if(e.DataValue.Trim().Length > 0)
				this.grdOCS0103.QueryLayout(false);
		}

		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			if(grdOCS0103.CurrentRowNumber >= 0) 
				CreateReturnValue();
			else
			{
				this.Close();
			}
		}

		private void grdOCS0103_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				int rowIndex = grdOCS0103.GetHitRowNumber(e.Y);
				if(rowIndex < 0) return;

				CreateReturnValue();
			}
		}
		#endregion

		#region [Function]
		private void CreateReturnValue()
		{  
			layReturnValue.LayoutTable.Rows.Clear();
			
			try
			{
				//선택한 정보 import
				for(int i = 0; i < grdOCS0103.RowCount; i ++)
				{
					if(grdOCS0103.IsSelectedRow(i))
						layReturnValue.LayoutTable.ImportRow(grdOCS0103.LayoutTable.Rows[i]);
				}
			}
			catch
			{
			}

			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "OCS0103", layReturnValue);
			scrOpener.Command(ScreenID, commandParams);
            
			this.Close();
		}

		private void grdOCS0103_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			grdOCS0103.SetBindVarValue("f_hangmog_idx",this.txtHangmog_index.GetDataValue());
		}
		#endregion
	}
}


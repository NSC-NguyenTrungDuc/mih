#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0123Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0123Q00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XButton btnApply;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XComboBox cboSearchCondition;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XPanel pnlZipCode;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XTextBox txtAddress;
		private IHIS.Framework.XTextBox txtZipCode2;
		private IHIS.Framework.XTextBox txtZipCode1;
		private IHIS.Framework.XLabel lblSearchWord;
		private IHIS.Framework.XEditGrid grdBAS0123;
		//private IHIS.Framework.DataServiceSIMO dsvBAS0123;
		private IHIS.Framework.MultiLayout layZipCode;
		private IHIS.Framework.XButton btnQuery;
		private System.Windows.Forms.ToolTip toolTip1;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
		private System.ComponentModel.IContainer components;

		public BAS0123Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
            // Connect Cloud        

		   this.grdBAS0123.ParamList = grdBAS0123_CreateParamsList();
	       this.grdBAS0123.ExecuteQuery = grdBAS0123_GetData;
	
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0123Q00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.pnlZipCode = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.txtZipCode2 = new IHIS.Framework.XTextBox();
            this.txtZipCode1 = new IHIS.Framework.XTextBox();
            this.txtAddress = new IHIS.Framework.XTextBox();
            this.lblSearchWord = new IHIS.Framework.XLabel();
            this.cboSearchCondition = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grdBAS0123 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.btnClose = new IHIS.Framework.XButton();
            this.btnCancel = new IHIS.Framework.XButton();
            this.btnApply = new IHIS.Framework.XButton();
            this.layZipCode = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.btnQuery = new IHIS.Framework.XButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.xPanel1.SuspendLayout();
            this.pnlZipCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0123)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layZipCode)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.pnlZipCode);
            this.xPanel1.Controls.Add(this.txtAddress);
            this.xPanel1.Controls.Add(this.lblSearchWord);
            this.xPanel1.Controls.Add(this.cboSearchCondition);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.pictureBox1);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            this.toolTip1.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // pnlZipCode
            // 
            this.pnlZipCode.AccessibleDescription = null;
            this.pnlZipCode.AccessibleName = null;
            resources.ApplyResources(this.pnlZipCode, "pnlZipCode");
            this.pnlZipCode.BackgroundImage = null;
            this.pnlZipCode.Controls.Add(this.xLabel3);
            this.pnlZipCode.Controls.Add(this.txtZipCode2);
            this.pnlZipCode.Controls.Add(this.txtZipCode1);
            this.pnlZipCode.Font = null;
            this.pnlZipCode.Name = "pnlZipCode";
            this.toolTip1.SetToolTip(this.pnlZipCode, resources.GetString("pnlZipCode.ToolTip"));
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            this.toolTip1.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
            // 
            // txtZipCode2
            // 
            this.txtZipCode2.AccessibleDescription = null;
            this.txtZipCode2.AccessibleName = null;
            resources.ApplyResources(this.txtZipCode2, "txtZipCode2");
            this.txtZipCode2.BackgroundImage = null;
            this.txtZipCode2.Name = "txtZipCode2";
            this.toolTip1.SetToolTip(this.txtZipCode2, resources.GetString("txtZipCode2.ToolTip"));
            this.txtZipCode2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // txtZipCode1
            // 
            this.txtZipCode1.AccessibleDescription = null;
            this.txtZipCode1.AccessibleName = null;
            resources.ApplyResources(this.txtZipCode1, "txtZipCode1");
            this.txtZipCode1.BackgroundImage = null;
            this.txtZipCode1.Name = "txtZipCode1";
            this.toolTip1.SetToolTip(this.txtZipCode1, resources.GetString("txtZipCode1.ToolTip"));
            this.txtZipCode1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // txtAddress
            // 
            this.txtAddress.AccessibleDescription = null;
            this.txtAddress.AccessibleName = null;
            resources.ApplyResources(this.txtAddress, "txtAddress");
            this.txtAddress.BackgroundImage = null;
            this.txtAddress.Name = "txtAddress";
            this.toolTip1.SetToolTip(this.txtAddress, resources.GetString("txtAddress.ToolTip"));
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // lblSearchWord
            // 
            this.lblSearchWord.AccessibleDescription = null;
            this.lblSearchWord.AccessibleName = null;
            resources.ApplyResources(this.lblSearchWord, "lblSearchWord");
            this.lblSearchWord.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSearchWord.EdgeRounding = false;
            this.lblSearchWord.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblSearchWord.Image = null;
            this.lblSearchWord.Name = "lblSearchWord";
            this.toolTip1.SetToolTip(this.lblSearchWord, resources.GetString("lblSearchWord.ToolTip"));
            // 
            // cboSearchCondition
            // 
            this.cboSearchCondition.AccessibleDescription = null;
            this.cboSearchCondition.AccessibleName = null;
            resources.ApplyResources(this.cboSearchCondition, "cboSearchCondition");
            this.cboSearchCondition.BackgroundImage = null;
            this.cboSearchCondition.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.cboSearchCondition.Name = "cboSearchCondition";
            this.toolTip1.SetToolTip(this.cboSearchCondition, resources.GetString("cboSearchCondition.ToolTip"));
            this.cboSearchCondition.SelectedIndexChanged += new System.EventHandler(this.cboSearchCondition_SelectedIndexChanged);
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = global::IHIS.BASS.Properties.Resource.xComboItem1;
            this.xComboItem1.ValueItem = "1";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = global::IHIS.BASS.Properties.Resource.xComboItem2;
            this.xComboItem2.ValueItem = "2";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            this.toolTip1.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleDescription = null;
            this.pictureBox1.AccessibleName = null;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Font = null;
            this.pictureBox1.ImageLocation = null;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            // 
            // grdBAS0123
            // 
            resources.ApplyResources(this.grdBAS0123, "grdBAS0123");
            this.grdBAS0123.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9});
            this.grdBAS0123.ColPerLine = 7;
            this.grdBAS0123.Cols = 7;
            this.grdBAS0123.ExecuteQuery = null;
            this.grdBAS0123.FixedRows = 1;
            this.grdBAS0123.HeaderHeights.Add(24);
            this.grdBAS0123.Name = "grdBAS0123";
            this.grdBAS0123.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0123.ParamList")));
            this.grdBAS0123.QuerySQL = resources.GetString("grdBAS0123.QuerySQL");
            this.grdBAS0123.Rows = 2;
            this.toolTip1.SetToolTip(this.grdBAS0123, resources.GetString("grdBAS0123.ToolTip"));
            this.grdBAS0123.ToolTipActive = true;
            this.grdBAS0123.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdBAS0123_MouseDown);
            this.grdBAS0123.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0123_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "zip_code";
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.Mask = "###-####";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "zip_name1";
            this.xEditGridCell2.CellWidth = 178;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "zip_name2";
            this.xEditGridCell3.CellWidth = 192;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "zip_name3";
            this.xEditGridCell4.CellWidth = 201;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "zip_name_gana1";
            this.xEditGridCell5.CellWidth = 230;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "zip_name_gana2";
            this.xEditGridCell6.CellWidth = 231;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "zip_name_gana3";
            this.xEditGridCell7.CellWidth = 302;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "zip_code1";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "zip_code2";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = null;
            this.btnClose.AccessibleName = null;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackgroundImage = null;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.toolTip1.SetToolTip(this.btnClose, resources.GetString("btnClose.ToolTip"));
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = null;
            this.btnCancel.AccessibleName = null;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackgroundImage = null;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Name = "btnCancel";
            this.toolTip1.SetToolTip(this.btnCancel, resources.GetString("btnCancel.ToolTip"));
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.AccessibleDescription = null;
            this.btnApply.AccessibleName = null;
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.BackgroundImage = null;
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.Name = "btnApply";
            this.toolTip1.SetToolTip(this.btnApply, resources.GetString("btnApply.ToolTip"));
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // layZipCode
            // 
            this.layZipCode.ExecuteQuery = null;
            this.layZipCode.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9});
            this.layZipCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layZipCode.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "zip_code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "zip_name1";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "zip_name2";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "zip_name3";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "zip_name_gana1";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "zip_name_gana2";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "zip_name_gana3";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "zip_code1";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "zip_code2";
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleDescription = null;
            this.btnQuery.AccessibleName = null;
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.BackgroundImage = null;
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Name = "btnQuery";
            this.toolTip1.SetToolTip(this.btnQuery, resources.GetString("btnQuery.ToolTip"));
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // BAS0123Q00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdBAS0123);
            this.Controls.Add(this.xPanel1);
            this.Name = "BAS0123Q00";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Closing += new System.ComponentModel.CancelEventHandler(this.BAS0123Q00_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.BAS0123Q00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.pnlZipCode.ResumeLayout(false);
            this.pnlZipCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0123)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layZipCode)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void cboSearchCondition_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.cboSearchCondition.SelectedValue.ToString() == "1")
			{
				this.pnlZipCode.Visible = true;
				this.txtAddress.Visible = false;
				this.lblSearchWord.Text = Resource.xComboItem1;
				this.txtAddress.ResetData();

			}
			else
			{
				this.pnlZipCode.Visible = false;
				this.txtAddress.Visible = true;
				this.lblSearchWord.Text = Resource.xComboItem2;
				this.txtZipCode1.ResetData();
				this.txtZipCode2.ResetData();
			}
		}

		private void BAS0123Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			if (this.OpenParam != null)
			{
				if (this.OpenParam["SearchGubun"].ToString() == "zipCode")
				{
					this.cboSearchCondition.SelectedValue = "1";

					if (this.OpenParam["zip_code1"].ToString() != "")
					{
						this.txtZipCode1.SetEditValue(this.OpenParam["zip_code1"].ToString());
					}
					
					if (this.OpenParam["zip_code2"].ToString() != "")
					{
						this.txtZipCode2.SetEditValue(this.OpenParam["zip_code2"].ToString());
					}
				}

				else
				{
					this.cboSearchCondition.SelectedValue = "2";

					if (this.OpenParam["address"].ToString() != "")
					{
						this.txtAddress.SetEditValue(this.OpenParam["address"].ToString());
					}
				}
			}
			else
			{
				this.cboSearchCondition.SelectedValue = "1";
			}

            this.grdBAS0123.QueryLayout(false);
		}

		private void grdBAS0123_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowNumber = -1;
			if (e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				rowNumber = this.grdBAS0123.GetHitRowNumber(e.Y);
                if (rowNumber != -1) 
				    this.layZipCode.LayoutTable.ImportRow(this.grdBAS0123.LayoutTable.Rows[rowNumber]);

				this.Close();
			}
		}

		private void BAS0123Q00_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
			if (this.layZipCode.RowCount > 0)
			{
				CommonItemCollection param = new CommonItemCollection();
				param.Add("BAS0123", this.layZipCode);
				param.Add("zip_code1", this.layZipCode.GetItemString(0, "zip_code1"));
				param.Add("zip_code2", this.layZipCode.GetItemString(0, "zip_code2"));
				param.Add("address", this.layZipCode.GetItemString(0, "zip_name1") + this.layZipCode.GetItemString(0, "zip_name2") +
					                 this.layZipCode.GetItemString(0, "zip_name3") );

				((XScreen)(this.Opener)).Command("BAS0123Q00", param);


			}
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			int rowNumber = this.grdBAS0123.CurrentRowNumber;

			if (rowNumber >= 0)
			{
				this.layZipCode.LayoutTable.ImportRow(this.grdBAS0123.LayoutTable.Rows[rowNumber]);

				this.Close();
			}
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
        {
            this.grdBAS0123.QueryLayout(false);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.layZipCode.Dispose();

			this.Close();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.layZipCode.Dispose();

			this.Close();
		}

		private void TextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                this.grdBAS0123.QueryLayout(false);
			}
		}

        private void grdBAS0123_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0123.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdBAS0123.SetBindVarValue("f_condition", cboSearchCondition.GetDataValue());
            this.grdBAS0123.SetBindVarValue("f_address", txtAddress.GetDataValue());
            this.grdBAS0123.SetBindVarValue("f_zip1", txtZipCode1.GetDataValue());
            this.grdBAS0123.SetBindVarValue("f_zip2", txtZipCode2.GetDataValue());
        }

	    private List<string> grdBAS0123_CreateParamsList()
	    {
            List<string> lstParams = new List<string>();
            lstParams.Add("f_condition");
            lstParams.Add("f_address");
            lstParams.Add("f_zip1");
            lstParams.Add("f_zip2");
	        return lstParams;
	    }

	    private IList<object[]> grdBAS0123_GetData(BindVarCollection bindVarCollection)
	    {
            IList<object[]> listObjZipCodeInfo = new List<object[]>();
            BasManageZipCodeArgs args = new BasManageZipCodeArgs(bindVarCollection["f_condition"].VarValue,
                bindVarCollection["f_address"].VarValue, bindVarCollection["f_zip1"].VarValue, bindVarCollection["f_zip2"].VarValue);
            BasManageZipCodeResult result =
                CloudService.Instance.Submit<BasManageZipCodeResult, BasManageZipCodeArgs>(args);
	        if (result != null)
	        {
                IList<BasManageZipCodeInfo> lstManageZipCodeInfo = result.ManageZipCodeItem;
                if (lstManageZipCodeInfo != null && lstManageZipCodeInfo.Count > 0)
                {
                    foreach (BasManageZipCodeInfo basManageZipCodeInfo in lstManageZipCodeInfo)
                    {
                        object[] zipCodeInfo =
                        {
                            basManageZipCodeInfo.ZipCode,
                            basManageZipCodeInfo.ZipName1,
                            basManageZipCodeInfo.ZipName2,
                            basManageZipCodeInfo.ZipName3,
                            basManageZipCodeInfo.ZipNameGaga1,
                            basManageZipCodeInfo.ZipNameGaga2,
                            basManageZipCodeInfo.ZipNameGaga3,
                            basManageZipCodeInfo.ZipCode1,
                            basManageZipCodeInfo.ZipCode2
                        };
                        listObjZipCodeInfo.Add(zipCodeInfo);
                    }
                }    
	        }
	        return listObjZipCodeInfo;

	    }
	}
}


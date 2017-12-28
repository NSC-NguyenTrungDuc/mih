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
	/// DRG3041P01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG3041P01 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XEditGrid grdChulgoList;
        private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XTextBox tbxBarcode;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XButton btnCancel;
        private IHIS.Framework.XTextBox tbxUserID;
		private System.Windows.Forms.GroupBox groupBox1;
		private IHIS.Framework.XDatePicker dtpChulgoDate;
        private IHIS.Framework.XPatientBox PaBox;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XEditGrid grdChulgoJUSAOrder;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell101;
		private IHIS.Framework.XEditGridCell xEditGridCell102;
		private IHIS.Framework.XEditGridCell xEditGridCell103;
		private IHIS.Framework.XEditGridCell xEditGridCell104;
		private IHIS.Framework.XEditGridCell xEditGridCell105;
		private IHIS.Framework.XEditGridCell xEditGridCell106;
		private IHIS.Framework.XEditGridCell xEditGridCell107;
		private IHIS.Framework.XEditGridCell xEditGridCell108;
		private IHIS.Framework.XEditGridCell xEditGridCell109;
		private IHIS.Framework.XEditGridCell xEditGridCell110;
		private IHIS.Framework.XEditGridCell xEditGridCell111;
		private IHIS.Framework.XEditGridCell xEditGridCell112;
		private IHIS.Framework.XEditGridCell xEditGridCell113;
		private IHIS.Framework.XEditGridCell xEditGridCell114;
		private IHIS.Framework.XEditGridCell xEditGridCell115;
		private IHIS.Framework.XEditGridCell xEditGridCell116;
		private IHIS.Framework.XEditGridCell xEditGridCell117;
		private IHIS.Framework.XEditGridCell xEditGridCell118;
		private IHIS.Framework.XEditGridCell xEditGridCell119;
		private IHIS.Framework.XEditGridCell xEditGridCell120;
		private IHIS.Framework.XEditGridCell xEditGridCell121;
		private IHIS.Framework.XEditGridCell xEditGridCell122;
		private IHIS.Framework.XEditGridCell xEditGridCell124;
		private IHIS.Framework.XEditGridCell xEditGridCell125;
		private IHIS.Framework.XEditGridCell xEditGridCell128;
		private IHIS.Framework.XEditGridCell xEditGridCell130;
		private IHIS.Framework.XEditGridCell xEditGridCell257;
		private IHIS.Framework.XEditGrid grdMagamOrder;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell53;
		private IHIS.Framework.XEditGridCell xEditGridCell54;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell123;
		private IHIS.Framework.XEditGridCell xEditGridCell126;
		private IHIS.Framework.XEditGridCell xEditGridCell127;
		private IHIS.Framework.XEditGridCell xEditGridCell129;
        private IHIS.Framework.XEditGridCell xEditGridCell258;
		private IHIS.Framework.XPanel xPanel4;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
        private XLabel xLabel4;
        private XLabel xLabel3;
        private XLabel lbDate;
        private XLabel xLabel2;
        private XEditGridCell xEditGridCell21;
        private XLabel lbUserName;
        private ImageList imageListMixGroup;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XDictComboBox cbxBuseo;
        private XLabel xLabel7;
        private XGridHeader xGridHeader1;
        private XEditGridCell xEditGridCell25;
		private System.ComponentModel.IContainer components;

		public DRG3041P01()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG3041P01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.lbUserName = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxBuseo = new IHIS.Framework.XDictComboBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.lbDate = new IHIS.Framework.XLabel();
            this.PaBox = new IHIS.Framework.XPatientBox();
            this.dtpChulgoDate = new IHIS.Framework.XDatePicker();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdChulgoJUSAOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell114 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell117 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell118 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell257 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.grdMagamOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell258 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grdChulgoList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.tbxUserID = new IHIS.Framework.XTextBox();
            this.tbxBarcode = new IHIS.Framework.XTextBox();
            this.btnCancel = new IHIS.Framework.XButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaBox)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChulgoJUSAOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChulgoList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.lbUserName);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.groupBox1);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.tbxUserID);
            this.xPanel1.Controls.Add(this.tbxBarcode);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 5);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel1.Size = new System.Drawing.Size(1055, 569);
            this.xPanel1.TabIndex = 0;
            // 
            // lbUserName
            // 
            this.lbUserName.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbUserName.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.lbUserName.Location = new System.Drawing.Point(192, 8);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(359, 34);
            this.lbUserName.TabIndex = 309;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel2.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Blue);
            this.xLabel2.Location = new System.Drawing.Point(5, 49);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(70, 34);
            this.xLabel2.TabIndex = 308;
            this.xLabel2.Text = "● ラベル";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel4.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Blue);
            this.xLabel4.Location = new System.Drawing.Point(5, 8);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(70, 34);
            this.xLabel4.TabIndex = 307;
            this.xLabel4.Text = "● 出庫者";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxBuseo);
            this.groupBox1.Controls.Add(this.xLabel7);
            this.groupBox1.Controls.Add(this.xLabel3);
            this.groupBox1.Controls.Add(this.lbDate);
            this.groupBox1.Controls.Add(this.PaBox);
            this.groupBox1.Controls.Add(this.dtpChulgoDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ForeColor = System.Drawing.Color.Gray;
            this.groupBox1.Location = new System.Drawing.Point(2, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1049, 50);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // cbxBuseo
            // 
            this.cbxBuseo.Location = new System.Drawing.Point(44, 19);
            this.cbxBuseo.Name = "cbxBuseo";
            this.cbxBuseo.Size = new System.Drawing.Size(80, 21);
            this.cbxBuseo.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxBuseo.TabIndex = 310;
            this.cbxBuseo.UserSQL = resources.GetString("cbxBuseo.UserSQL");
            this.cbxBuseo.SelectionChangeCommitted += new System.EventHandler(this.cbxBuseo_SelectionChangeCommitted);
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel7.Location = new System.Drawing.Point(4, 19);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(40, 21);
            this.xLabel7.TabIndex = 311;
            this.xLabel7.Text = "病棟";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel3.Location = new System.Drawing.Point(303, 20);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(70, 20);
            this.xLabel3.TabIndex = 306;
            this.xLabel3.Text = "患者番号";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDate
            // 
            this.lbDate.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbDate.EdgeRounding = false;
            this.lbDate.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbDate.Location = new System.Drawing.Point(128, 20);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(70, 20);
            this.lbDate.TabIndex = 305;
            this.lbDate.Text = "出庫日付";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PaBox
            // 
            this.PaBox.Location = new System.Drawing.Point(303, 15);
            this.PaBox.Name = "PaBox";
            this.PaBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.PaBox.Size = new System.Drawing.Size(412, 31);
            this.PaBox.TabIndex = 103;
            // 
            // dtpChulgoDate
            // 
            this.dtpChulgoDate.Location = new System.Drawing.Point(198, 20);
            this.dtpChulgoDate.Name = "dtpChulgoDate";
            this.dtpChulgoDate.Size = new System.Drawing.Size(100, 20);
            this.dtpChulgoDate.TabIndex = 101;
            this.dtpChulgoDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpChulgoDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpChulgoDate_DataValidating);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xPanel4);
            this.xPanel3.Controls.Add(this.splitter1);
            this.xPanel3.Controls.Add(this.grdChulgoList);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel3.Location = new System.Drawing.Point(2, 133);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.xPanel3.Size = new System.Drawing.Size(1049, 432);
            this.xPanel3.TabIndex = 111;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.grdChulgoJUSAOrder);
            this.xPanel4.Controls.Add(this.grdMagamOrder);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel4.Location = new System.Drawing.Point(0, 285);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.xPanel4.Size = new System.Drawing.Size(1049, 147);
            this.xPanel4.TabIndex = 24;
            // 
            // grdChulgoJUSAOrder
            // 
            this.grdChulgoJUSAOrder.AddedHeaderLine = 1;
            this.grdChulgoJUSAOrder.ApplyPaintEventToAllColumn = true;
            this.grdChulgoJUSAOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell57,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108,
            this.xEditGridCell109,
            this.xEditGridCell110,
            this.xEditGridCell111,
            this.xEditGridCell112,
            this.xEditGridCell113,
            this.xEditGridCell114,
            this.xEditGridCell115,
            this.xEditGridCell116,
            this.xEditGridCell117,
            this.xEditGridCell118,
            this.xEditGridCell119,
            this.xEditGridCell120,
            this.xEditGridCell121,
            this.xEditGridCell122,
            this.xEditGridCell124,
            this.xEditGridCell125,
            this.xEditGridCell128,
            this.xEditGridCell130,
            this.xEditGridCell257,
            this.xEditGridCell19,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24});
            this.grdChulgoJUSAOrder.ColPerLine = 15;
            this.grdChulgoJUSAOrder.Cols = 16;
            this.grdChulgoJUSAOrder.ControlBinding = true;
            this.grdChulgoJUSAOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChulgoJUSAOrder.FixedCols = 1;
            this.grdChulgoJUSAOrder.FixedRows = 2;
            this.grdChulgoJUSAOrder.HeaderHeights.Add(37);
            this.grdChulgoJUSAOrder.HeaderHeights.Add(0);
            this.grdChulgoJUSAOrder.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdChulgoJUSAOrder.Location = new System.Drawing.Point(0, 2);
            this.grdChulgoJUSAOrder.Name = "grdChulgoJUSAOrder";
            this.grdChulgoJUSAOrder.QuerySQL = resources.GetString("grdChulgoJUSAOrder.QuerySQL");
            this.grdChulgoJUSAOrder.ReadOnly = true;
            this.grdChulgoJUSAOrder.RowHeaderVisible = true;
            this.grdChulgoJUSAOrder.Rows = 3;
            this.grdChulgoJUSAOrder.Size = new System.Drawing.Size(1049, 145);
            this.grdChulgoJUSAOrder.TabIndex = 23;
            this.grdChulgoJUSAOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdChulgoJUSAOrder_QueryEnd);
            this.grdChulgoJUSAOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdChulgoJUSAOrder_QueryStarting);
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell57.CellName = "order_date";
            this.xEditGridCell57.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell57.Col = 1;
            this.xEditGridCell57.HeaderText = "オーダ日付";
            this.xEditGridCell57.IsReadOnly = true;
            this.xEditGridCell57.IsUpdCol = false;
            this.xEditGridCell57.RowSpan = 2;
            this.xEditGridCell57.SuppressRepeating = true;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "mix_group";
            this.xEditGridCell101.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell101.CellWidth = 30;
            this.xEditGridCell101.Col = 2;
            this.xEditGridCell101.HeaderText = "MIX";
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.IsUpdCol = false;
            this.xEditGridCell101.RowSpan = 2;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell102.CellName = "jaeryo_code";
            this.xEditGridCell102.Col = 3;
            this.xEditGridCell102.HeaderText = "オーダコード";
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsUpdCol = false;
            this.xEditGridCell102.RowSpan = 2;
            this.xEditGridCell102.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "jaeryo_name";
            this.xEditGridCell103.CellWidth = 305;
            this.xEditGridCell103.Col = 4;
            this.xEditGridCell103.HeaderText = "オーダコード名";
            this.xEditGridCell103.IsReadOnly = true;
            this.xEditGridCell103.IsUpdCol = false;
            this.xEditGridCell103.RowSpan = 2;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "ord_suryang";
            this.xEditGridCell104.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell104.CellWidth = 40;
            this.xEditGridCell104.Col = 5;
            this.xEditGridCell104.HeaderText = "数量";
            this.xEditGridCell104.IsReadOnly = true;
            this.xEditGridCell104.IsUpdCol = false;
            this.xEditGridCell104.RowSpan = 2;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "dv_time";
            this.xEditGridCell105.CellWidth = 22;
            this.xEditGridCell105.Col = 6;
            this.xEditGridCell105.IsReadOnly = true;
            this.xEditGridCell105.IsUpdCol = false;
            this.xEditGridCell105.Row = 1;
            this.xEditGridCell105.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "dv";
            this.xEditGridCell106.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell106.CellWidth = 25;
            this.xEditGridCell106.Col = 7;
            this.xEditGridCell106.IsReadOnly = true;
            this.xEditGridCell106.IsUpdCol = false;
            this.xEditGridCell106.Row = 1;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "nalsu";
            this.xEditGridCell107.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell107.CellWidth = 22;
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.HeaderText = "日\r\n数";
            this.xEditGridCell107.IsReadOnly = true;
            this.xEditGridCell107.IsUpdCol = false;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "order_danui";
            this.xEditGridCell108.CellWidth = 50;
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.HeaderText = "単位";
            this.xEditGridCell108.IsReadOnly = true;
            this.xEditGridCell108.IsUpdCol = false;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "danui_name";
            this.xEditGridCell109.CellWidth = 49;
            this.xEditGridCell109.Col = 8;
            this.xEditGridCell109.HeaderText = "単位";
            this.xEditGridCell109.IsReadOnly = true;
            this.xEditGridCell109.IsUpdCol = false;
            this.xEditGridCell109.RowSpan = 2;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "bogyong_code";
            this.xEditGridCell110.CellWidth = 197;
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.HeaderText = "用法";
            this.xEditGridCell110.IsReadOnly = true;
            this.xEditGridCell110.IsUpdCol = false;
            this.xEditGridCell110.IsVisible = false;
            this.xEditGridCell110.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "bogyong_name";
            this.xEditGridCell111.CellWidth = 75;
            this.xEditGridCell111.Col = 9;
            this.xEditGridCell111.HeaderText = "注射\r\n速度";
            this.xEditGridCell111.IsReadOnly = true;
            this.xEditGridCell111.IsUpdCol = false;
            this.xEditGridCell111.RowSpan = 2;
            this.xEditGridCell111.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "powder_yn";
            this.xEditGridCell112.CellWidth = 25;
            this.xEditGridCell112.Col = 10;
            this.xEditGridCell112.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell112.HeaderText = "粉\r\n砕";
            this.xEditGridCell112.IsReadOnly = true;
            this.xEditGridCell112.RowSpan = 2;
            this.xEditGridCell112.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "remark";
            this.xEditGridCell113.CellWidth = 77;
            this.xEditGridCell113.Col = 15;
            this.xEditGridCell113.DisplayMemoText = true;
            this.xEditGridCell113.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell113.HeaderText = "コメント";
            this.xEditGridCell113.IsReadOnly = true;
            this.xEditGridCell113.RowSpan = 2;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "dv_1";
            this.xEditGridCell114.Col = -1;
            this.xEditGridCell114.HeaderText = "朝";
            this.xEditGridCell114.IsReadOnly = true;
            this.xEditGridCell114.IsVisible = false;
            this.xEditGridCell114.Row = -1;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "dv_2";
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.HeaderText = "昼";
            this.xEditGridCell115.IsReadOnly = true;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "dv_3";
            this.xEditGridCell116.Col = -1;
            this.xEditGridCell116.HeaderText = "夕";
            this.xEditGridCell116.IsReadOnly = true;
            this.xEditGridCell116.IsVisible = false;
            this.xEditGridCell116.Row = -1;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "dv_4";
            this.xEditGridCell117.Col = -1;
            this.xEditGridCell117.HeaderText = "就寝";
            this.xEditGridCell117.IsReadOnly = true;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "dv_5";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.HeaderText = "dv_5";
            this.xEditGridCell118.IsReadOnly = true;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "hubal_change_yn";
            this.xEditGridCell119.CellWidth = 25;
            this.xEditGridCell119.Col = 13;
            this.xEditGridCell119.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell119.HeaderText = "後\r\n発";
            this.xEditGridCell119.IsReadOnly = true;
            this.xEditGridCell119.RowSpan = 2;
            this.xEditGridCell119.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "pharmacy";
            this.xEditGridCell120.CellWidth = 30;
            this.xEditGridCell120.Col = 11;
            this.xEditGridCell120.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell120.HeaderText = "簡易\r\n懸濁";
            this.xEditGridCell120.IsReadOnly = true;
            this.xEditGridCell120.RowSpan = 2;
            this.xEditGridCell120.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "drg_pack_yn";
            this.xEditGridCell121.CellWidth = 25;
            this.xEditGridCell121.Col = 12;
            this.xEditGridCell121.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell121.HeaderText = "一\r\n包";
            this.xEditGridCell121.IsReadOnly = true;
            this.xEditGridCell121.RowSpan = 2;
            this.xEditGridCell121.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "jusa";
            this.xEditGridCell122.CellWidth = 120;
            this.xEditGridCell122.Col = 14;
            this.xEditGridCell122.HeaderText = "注射";
            this.xEditGridCell122.IsReadOnly = true;
            this.xEditGridCell122.RowSpan = 2;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "suname";
            this.xEditGridCell124.Col = -1;
            this.xEditGridCell124.HeaderText = "患者氏名";
            this.xEditGridCell124.IsVisible = false;
            this.xEditGridCell124.Row = -1;
            this.xEditGridCell124.SuppressRepeating = true;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "drg_bunho";
            this.xEditGridCell125.CellWidth = 40;
            this.xEditGridCell125.Col = -1;
            this.xEditGridCell125.HeaderText = "投薬\r\n番号";
            this.xEditGridCell125.IsVisible = false;
            this.xEditGridCell125.Row = -1;
            this.xEditGridCell125.SuppressRepeating = true;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "jubsu_date";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.HeaderText = "jubsu_date";
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "bunho";
            this.xEditGridCell130.CellWidth = 75;
            this.xEditGridCell130.Col = -1;
            this.xEditGridCell130.HeaderText = "患者番号";
            this.xEditGridCell130.IsVisible = false;
            this.xEditGridCell130.Row = -1;
            this.xEditGridCell130.SuppressRepeating = true;
            // 
            // xEditGridCell257
            // 
            this.xEditGridCell257.CellName = "ho_dong";
            this.xEditGridCell257.CellWidth = 29;
            this.xEditGridCell257.Col = -1;
            this.xEditGridCell257.HeaderText = "病\r\n棟";
            this.xEditGridCell257.IsVisible = false;
            this.xEditGridCell257.Row = -1;
            this.xEditGridCell257.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "dc_yn";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "dc_yn";
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "fkocs2003";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderText = "fkocs2003";
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "fkinp1001";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.HeaderText = "fkinp1001";
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "group_ser";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "group_ser";
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 6;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "回数";
            this.xGridHeader1.HeaderWidth = 22;
            // 
            // grdMagamOrder
            // 
            this.grdMagamOrder.ApplyPaintEventToAllColumn = true;
            this.grdMagamOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell27,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell123,
            this.xEditGridCell126,
            this.xEditGridCell127,
            this.xEditGridCell129,
            this.xEditGridCell258});
            this.grdMagamOrder.ColPerLine = 13;
            this.grdMagamOrder.ColResizable = true;
            this.grdMagamOrder.Cols = 14;
            this.grdMagamOrder.ControlBinding = true;
            this.grdMagamOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMagamOrder.FixedCols = 1;
            this.grdMagamOrder.FixedRows = 1;
            this.grdMagamOrder.HeaderHeights.Add(37);
            this.grdMagamOrder.Location = new System.Drawing.Point(0, 2);
            this.grdMagamOrder.Name = "grdMagamOrder";
            this.grdMagamOrder.QuerySQL = resources.GetString("grdMagamOrder.QuerySQL");
            this.grdMagamOrder.ReadOnly = true;
            this.grdMagamOrder.RowHeaderVisible = true;
            this.grdMagamOrder.Rows = 2;
            this.grdMagamOrder.Size = new System.Drawing.Size(1049, 145);
            this.grdMagamOrder.TabIndex = 22;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "order_date";
            this.xEditGridCell27.CellWidth = 77;
            this.xEditGridCell27.Col = 1;
            this.xEditGridCell27.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell27.HeaderText = "オーダ日付";
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.SuppressRepeating = true;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "group_ser";
            this.xEditGridCell32.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell32.CellWidth = 20;
            this.xEditGridCell32.Col = 2;
            this.xEditGridCell32.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell32.HeaderText = "Gr";
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdCol = false;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "jaeryo_code";
            this.xEditGridCell33.CellWidth = 77;
            this.xEditGridCell33.Col = 3;
            this.xEditGridCell33.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell33.HeaderText = "オーダコード";
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "jaeryo_name";
            this.xEditGridCell34.CellWidth = 203;
            this.xEditGridCell34.Col = 4;
            this.xEditGridCell34.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell34.HeaderText = "オーダコード名";
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdCol = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "ord_suryang";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell35.CellWidth = 40;
            this.xEditGridCell35.Col = 5;
            this.xEditGridCell35.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell35.HeaderText = "数量";
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsUpdCol = false;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "dv_time";
            this.xEditGridCell36.CellWidth = 22;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.HeaderText = "DV";
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "dv";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell40.CellWidth = 22;
            this.xEditGridCell40.Col = 6;
            this.xEditGridCell40.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell40.HeaderText = "回\r\n数";
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsUpdCol = false;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "nalsu";
            this.xEditGridCell41.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell41.CellWidth = 22;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.HeaderText = "日\r\n数";
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsUpdCol = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "order_danui";
            this.xEditGridCell42.CellWidth = 50;
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.HeaderText = "単位";
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.IsUpdCol = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "danui_name";
            this.xEditGridCell43.CellWidth = 49;
            this.xEditGridCell43.Col = 7;
            this.xEditGridCell43.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell43.HeaderText = "単位";
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsUpdCol = false;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "bogyong_code";
            this.xEditGridCell44.CellWidth = 197;
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.HeaderText = "用法";
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.IsUpdCol = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "bogyong_name";
            this.xEditGridCell45.CellWidth = 127;
            this.xEditGridCell45.Col = 8;
            this.xEditGridCell45.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell45.HeaderText = "用法";
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.IsUpdCol = false;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "powder_yn";
            this.xEditGridCell46.CellWidth = 25;
            this.xEditGridCell46.Col = 9;
            this.xEditGridCell46.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell46.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell46.HeaderText = "粉\r\n砕";
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "remark";
            this.xEditGridCell47.CellWidth = 284;
            this.xEditGridCell47.Col = 13;
            this.xEditGridCell47.DisplayMemoText = true;
            this.xEditGridCell47.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell47.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell47.HeaderText = "コメント";
            this.xEditGridCell47.IsReadOnly = true;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "dv_1";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.HeaderText = "朝";
            this.xEditGridCell48.IsReadOnly = true;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "dv_2";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.HeaderText = "昼";
            this.xEditGridCell49.IsReadOnly = true;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "dv_3";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.HeaderText = "夕";
            this.xEditGridCell50.IsReadOnly = true;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "dv_4";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.HeaderText = "就寝";
            this.xEditGridCell51.IsReadOnly = true;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "dv_5";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.HeaderText = "dv_5";
            this.xEditGridCell52.IsReadOnly = true;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "hubal_change_yn";
            this.xEditGridCell53.CellWidth = 25;
            this.xEditGridCell53.Col = 12;
            this.xEditGridCell53.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell53.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell53.HeaderText = "後\r\n発";
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "pharmacy";
            this.xEditGridCell54.CellWidth = 30;
            this.xEditGridCell54.Col = 10;
            this.xEditGridCell54.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell54.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell54.HeaderText = "簡易\r\n懸濁";
            this.xEditGridCell54.IsReadOnly = true;
            this.xEditGridCell54.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "drg_pack_yn";
            this.xEditGridCell55.CellWidth = 25;
            this.xEditGridCell55.Col = 11;
            this.xEditGridCell55.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell55.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Flat;
            this.xEditGridCell55.HeaderText = "一\r\n包";
            this.xEditGridCell55.IsReadOnly = true;
            this.xEditGridCell55.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "jusa";
            this.xEditGridCell56.CellWidth = 43;
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.HeaderText = "注射";
            this.xEditGridCell56.IsReadOnly = true;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            this.xEditGridCell56.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "suname";
            this.xEditGridCell123.Col = -1;
            this.xEditGridCell123.HeaderText = "患者氏名";
            this.xEditGridCell123.IsVisible = false;
            this.xEditGridCell123.Row = -1;
            this.xEditGridCell123.SuppressRepeating = true;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "drg_bunho";
            this.xEditGridCell126.CellWidth = 40;
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.HeaderText = "投薬\r\n番号";
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            this.xEditGridCell126.SuppressRepeating = true;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "jubsu_date";
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.HeaderText = "jubsu_date";
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "bunho";
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.HeaderText = "患者番号";
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            this.xEditGridCell129.SuppressRepeating = true;
            // 
            // xEditGridCell258
            // 
            this.xEditGridCell258.CellName = "ho_dong";
            this.xEditGridCell258.CellWidth = 30;
            this.xEditGridCell258.Col = -1;
            this.xEditGridCell258.HeaderText = "病\r\n棟";
            this.xEditGridCell258.IsVisible = false;
            this.xEditGridCell258.Row = -1;
            this.xEditGridCell258.SuppressRepeating = true;
            this.xEditGridCell258.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 282);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1049, 3);
            this.splitter1.TabIndex = 25;
            this.splitter1.TabStop = false;
            // 
            // grdChulgoList
            // 
            this.grdChulgoList.ApplyPaintEventToAllColumn = true;
            this.grdChulgoList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell21,
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
            this.xEditGridCell20,
            this.xEditGridCell25});
            this.grdChulgoList.ColPerLine = 16;
            this.grdChulgoList.Cols = 17;
            this.grdChulgoList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdChulgoList.FixedCols = 1;
            this.grdChulgoList.FixedRows = 1;
            this.grdChulgoList.FocusColumnName = "chulgo_date";
            this.grdChulgoList.HeaderHeights.Add(21);
            this.grdChulgoList.Location = new System.Drawing.Point(0, 2);
            this.grdChulgoList.Name = "grdChulgoList";
            this.grdChulgoList.QuerySQL = resources.GetString("grdChulgoList.QuerySQL");
            this.grdChulgoList.RowHeaderVisible = true;
            this.grdChulgoList.Rows = 2;
            this.grdChulgoList.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdChulgoList.Size = new System.Drawing.Size(1049, 280);
            this.grdChulgoList.TabIndex = 6;
            this.grdChulgoList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdChulgoList_QueryEnd);
            this.grdChulgoList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdChulgoList_QueryStarting);
            this.grdChulgoList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdChulgoList_RowFocusChanged);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell21.CellName = "bunho";
            this.xEditGridCell21.CellWidth = 70;
            this.xEditGridCell21.Col = 5;
            this.xEditGridCell21.HeaderText = "患者番号";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.CellName = "jubsu_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = 7;
            this.xEditGridCell1.HeaderText = "出力日付";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.SuppressRepeating = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell2.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell2.CellName = "drg_bunho";
            this.xEditGridCell2.CellWidth = 38;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "番号";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell2.SuppressRepeating = true;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell3.CellName = "serial_v";
            this.xEditGridCell3.CellWidth = 25;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.HeaderText = "Rp";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.CellName = "chulgo_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.Col = 8;
            this.xEditGridCell4.HeaderText = "薬局出庫";
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell5.CellName = "chulgo_time";
            this.xEditGridCell5.CellWidth = 40;
            this.xEditGridCell5.Col = 9;
            this.xEditGridCell5.HeaderText = "時間";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "chulgo_id";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "出庫者";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell7.CellName = "ipgo_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.Col = 11;
            this.xEditGridCell7.HeaderText = "病棟入庫";
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell8.CellName = "ipgo_time";
            this.xEditGridCell8.CellWidth = 40;
            this.xEditGridCell8.Col = 12;
            this.xEditGridCell8.HeaderText = "時間";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "ipgo_id";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "入庫者";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell10.CellName = "acting_date";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.Col = 14;
            this.xEditGridCell10.HeaderText = "実施日付";
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell11.CellName = "acting_time";
            this.xEditGridCell11.CellWidth = 40;
            this.xEditGridCell11.Col = 15;
            this.xEditGridCell11.HeaderText = "時間";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "acting_id";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "実施者";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "ho_dong";
            this.xEditGridCell13.CellWidth = 35;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.HeaderText = "病棟";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "ho_code";
            this.xEditGridCell14.CellWidth = 40;
            this.xEditGridCell14.Col = 4;
            this.xEditGridCell14.HeaderText = "病室";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "chulgo_id_name";
            this.xEditGridCell15.CellWidth = 90;
            this.xEditGridCell15.Col = 10;
            this.xEditGridCell15.HeaderText = "出庫者";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "ipgo_id_name";
            this.xEditGridCell16.CellWidth = 90;
            this.xEditGridCell16.Col = 13;
            this.xEditGridCell16.HeaderText = "入庫者";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "acging_id_name";
            this.xEditGridCell17.CellWidth = 90;
            this.xEditGridCell17.Col = 16;
            this.xEditGridCell17.HeaderText = "実施者";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "suname";
            this.xEditGridCell18.CellWidth = 90;
            this.xEditGridCell18.Col = 6;
            this.xEditGridCell18.HeaderText = "患者氏名";
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.SuppressRepeating = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "magam_gubun";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // tbxUserID
            // 
            this.tbxUserID.EnterKeyToTab = false;
            this.tbxUserID.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUserID.Location = new System.Drawing.Point(75, 8);
            this.tbxUserID.MaxLength = 80;
            this.tbxUserID.Name = "tbxUserID";
            this.tbxUserID.Size = new System.Drawing.Size(116, 34);
            this.tbxUserID.TabIndex = 0;
            this.tbxUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxUserID_KeyPress);
            // 
            // tbxBarcode
            // 
            this.tbxBarcode.EnterKeyToTab = false;
            this.tbxBarcode.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxBarcode.Location = new System.Drawing.Point(75, 49);
            this.tbxBarcode.MaxLength = 80;
            this.tbxBarcode.Name = "tbxBarcode";
            this.tbxBarcode.Size = new System.Drawing.Size(204, 34);
            this.tbxBarcode.TabIndex = 3;
            this.tbxBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxBarcode_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCancel.Size = new System.Drawing.Size(110, 28);
            this.btnCancel.TabIndex = 92;
            this.btnCancel.Text = "出庫取消処理";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Controls.Add(this.btnCancel);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 574);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1055, 36);
            this.xPanel2.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(890, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 1;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "20.gif");
            this.imageListMixGroup.Images.SetKeyName(1, "1.gif");
            this.imageListMixGroup.Images.SetKeyName(2, "2.gif");
            this.imageListMixGroup.Images.SetKeyName(3, "3.gif");
            this.imageListMixGroup.Images.SetKeyName(4, "4.gif");
            this.imageListMixGroup.Images.SetKeyName(5, "5.gif");
            this.imageListMixGroup.Images.SetKeyName(6, "6.gif");
            this.imageListMixGroup.Images.SetKeyName(7, "7.gif");
            this.imageListMixGroup.Images.SetKeyName(8, "8.gif");
            this.imageListMixGroup.Images.SetKeyName(9, "9.gif");
            this.imageListMixGroup.Images.SetKeyName(10, "10.gif");
            this.imageListMixGroup.Images.SetKeyName(11, "11.gif");
            this.imageListMixGroup.Images.SetKeyName(12, "12.gif");
            this.imageListMixGroup.Images.SetKeyName(13, "13.gif");
            this.imageListMixGroup.Images.SetKeyName(14, "14.gif");
            this.imageListMixGroup.Images.SetKeyName(15, "15.gif");
            this.imageListMixGroup.Images.SetKeyName(16, "16.gif");
            this.imageListMixGroup.Images.SetKeyName(17, "17.gif");
            this.imageListMixGroup.Images.SetKeyName(18, "18.gif");
            this.imageListMixGroup.Images.SetKeyName(19, "19.gif");
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "seq";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.HeaderText = "No";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DRG3041P01
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Name = "DRG3041P01";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1065, 615);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaBox)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChulgoJUSAOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMagamOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChulgoList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region Common Properties
        private string mHospCode = EnvironInfo.HospCode;
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			this.dtpChulgoDate.SetDataValue(EnvironInfo.GetSysDate());
            this.cbxBuseo.SelectedIndex = 0;

            if (!grdChulgoList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
		}
		#endregion

        #region [grdChulgoList_QueryEnd]
        private void grdChulgoList_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
            if (this.grdChulgoList.RowCount < 1) this.grdChulgoJUSAOrder.Reset();

			this.tbxBarcode.SetDataValue("");
			this.tbxBarcode.Focus();
        }
        #endregion

        #region [tbxUserID_KeyPress]
        private void tbxUserID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                object userName = Service.ExecuteScalar("SELECT FN_ADM_LOAD_USER_NAME('" + tbxUserID.GetDataValue() + "') FROM DUAL");
                if (!TypeCheck.IsNull(userName))
                {
                    lbUserName.Text = "";
                    lbUserName.Text = userName.ToString();
                }
                else lbUserName.Text = "";

                this.tbxBarcode.Focus();
            }
        }
        #endregion

        #region [tbxBarcode_KeyPress]
        private void tbxBarcode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				#region ユーザーＩＤ
				if (lbUserName.Text == "")
				{
                    this.tbxBarcode.SetDataValue("");
                    this.tbxBarcode.AcceptData();

					this.tbxUserID.Focus();

                    XMessageBox.Show("ユーザーＩＤを入力してください。", "確認", MessageBoxIcon.Warning);
					return;
				}
				#endregion

                this.DsvSave(tbxBarcode.GetDataValue(), "I");
			}
        }
        #endregion

        #region [-- DsvSave() --]
        /// <summary>
        /// dsvSave Service Conversion PC:DRG3041P01, WT:2
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="iudGubun"></param>
        private void DsvSave(string barcode, string iudGubun)
        {
            if (TypeCheck.IsNull(barcode)) return;

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(barcode);
            inputList.Add(iudGubun);
            inputList.Add(tbxUserID.GetDataValue());
            inputList.Add(EnvironInfo.GetSysDate().ToShortDateString().Replace("-", "").Replace("-", ""));
            inputList.Add("DRG");
            inputList.Add("");

            if (Service.ExecuteProcedure("PR_DRG_MAKE_BARCODE", inputList, outputList))
            {
                string err_code = outputList[6].ToString();

                if (err_code == "1")
                {
                    XMessageBox.Show("バーコード内容を確認して下さい。", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "2")
                {
                    XMessageBox.Show("締切されてないオーダです。", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "3")
                {
                    XMessageBox.Show("返却オーダーが含まれています。", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "4")
                {
                    XMessageBox.Show("既に処理された処方箋です。", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "5")
                {
                    XMessageBox.Show("薬局から出庫されてない処方箋です。", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "6")
                {
                    XMessageBox.Show("患者情報を確認して下さい。", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "9")
                {
                    XMessageBox.Show("既に病棟入庫処理されました｡ 取消出来ません｡", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "10")
                {
                    XMessageBox.Show("既に実施処理されました｡ 取消出来ません。", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "11")
                {
                    XMessageBox.Show("病棟入庫処理されていません｡", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "12")
                {
                    XMessageBox.Show("MIXオーダではありません｡", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "13")
                {
                    XMessageBox.Show("既にMIX処理されました｡ 取消出来ません。", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "14")
                {
                    XMessageBox.Show("MIX処理がされていません｡", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "15")
                {
                    XMessageBox.Show("返却オーダのため入庫できません。", "確認", MessageBoxIcon.Warning);
                    return;
                }
                else if (err_code == "Z")
                {
                    XMessageBox.Show("Z", "Error", MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (iudGubun == "I") XMessageBox.Show("出庫処理ｶﾞ完了されました｡", "出庫完了", MessageBoxIcon.Warning);

                    if (iudGubun == "D") XMessageBox.Show("出庫取消処理ｶﾞ完了されました｡", "出庫取消完了", MessageBoxIcon.Warning);

                    // 注射オーダ照会
                    this.grdChulgoList.QueryLayout(false);
                }
            }
        }
        #endregion

        #region [btnCancel_Click 取消ボタンクリック]
        private void btnCancel_Click(object sender, System.EventArgs e)
		{
            //string barcode = grdChulgoList.GetItemString(grdChulgoList.CurrentRowNumber, "jubsu_date").Replace("/","").Replace("-", "");
            //barcode = barcode + grdChulgoList.GetItemString(grdChulgoList.CurrentRowNumber, "drg_bunho");

            if (this.grdChulgoList.RowCount < 0) return;

            string barcode = grdChulgoList.GetItemString(grdChulgoList.CurrentRowNumber, "jubsu_date").Replace("/", "");
            barcode += grdChulgoList.GetItemString(grdChulgoList.CurrentRowNumber, "drg_bunho");
            barcode += grdChulgoList.GetItemString(grdChulgoList.CurrentRowNumber, "serial_v");
            barcode += grdChulgoList.GetItemString(grdChulgoList.CurrentRowNumber, "seq");

			DsvSave(barcode, "D");

            this.grdChulgoList.QueryLayout(false);
        }
        #endregion

        #region [grdChulgoList_RowFocusChanged]
        private void grdChulgoList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            //string magam_gubun = "", magam_bunryu = "";
            //magam_gubun = grdChulgoList.GetItemString(grdChulgoList.CurrentRowNumber, "magam_gubun");
			
            ////내복, 외용
            //if ((magam_gubun == "11") || (magam_gubun == "21"))
            //{
            //    CurrMQLayout = grdMagamOrder;
            //    magam_bunryu = "1";
            //    grdMagamOrder.SetBindVarValue("f_jubsu_date", grdChulgoList.GetItemString(e.CurrentRow, "jubsu_date"));
            //    grdMagamOrder.SetBindVarValue("f_drg_bunho",  grdChulgoList.GetItemString(e.CurrentRow, "drg_bunho"));
            //    grdMagamOrder.SetBindVarValue("f_hosp_code",  mHospCode);
            //    grdMagamOrder.Visible = true;
            //    grdMagamJUSAOrder.Visible = false;

            //    if (!grdMagamOrder.QueryLayout(true)) XMessageBox.Show(Service.ErrFullMsg);
            //}

            ////주사
            //if ((magam_gubun == "12") || (magam_gubun == "22"))
            //{
            //    CurrMQLayout = grdMagamJUSAOrder;
            //    magam_bunryu = "2";


            //this.grdMagamOrder.Visible = false;
            //this.grdChulgoJUSAOrder.Visible = true;

            this.grdChulgoJUSAOrder.QueryLayout(true);

            //}
        }
        #endregion

        #region [btnList_ButtonClick　ボタンリストクリック]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
                    e.IsBaseCall = false;
					if(!grdChulgoList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
					break;
				default:
					break;
			}
        }
        #endregion

        #region [dtpChulgoDate_DataValidating 出庫日付選択]
        private void dtpChulgoDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (!this.grdChulgoList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }
        #endregion

        #region [grdChulgoList_QueryStarting]
        private void grdChulgoList_QueryStarting(object sender, CancelEventArgs e)
        {
            //grdChulgoList.SetBindVarValue("f_chulgo_all_yn", chkAllQry.GetDataValue());
            this.grdChulgoList.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdChulgoList.SetBindVarValue("f_chulgo_date", dtpChulgoDate.GetDataValue());
            this.grdChulgoList.SetBindVarValue("f_bunho", PaBox.BunHo);
            this.grdChulgoList.SetBindVarValue("f_ho_dong", this.cbxBuseo.GetDataValue());
        }
        #endregion

        #region [grdChulgoJUSAOrder_QueryStarting]
        private void grdChulgoJUSAOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdChulgoJUSAOrder.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdChulgoJUSAOrder.SetBindVarValue("f_jubsu_date", this.grdChulgoList.GetItemString(this.grdChulgoList.CurrentRowNumber, "jubsu_date"));
            this.grdChulgoJUSAOrder.SetBindVarValue("f_drg_bunho", this.grdChulgoList.GetItemString(this.grdChulgoList.CurrentRowNumber, "drg_bunho"));
            this.grdChulgoJUSAOrder.SetBindVarValue("f_serial_v", this.grdChulgoList.GetItemString(this.grdChulgoList.CurrentRowNumber, "serial_v"));
        }
        #endregion

        #region [grdChulgoJUSAOrder_QueryEnd]
        private void grdChulgoJUSAOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            if (grd.RowCount > 0)
            {
                DisplayMixGroup(grd);
            }
        }
        #endregion

        #region Mix Group 데이타 Image Display (DiaplayMixGroup)
        /// <summary>
        /// Mix Group 데이타 Image Display
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <returns> void  </returns>
        private void DisplayMixGroup(XEditGrid aGrd)
        {
            if (aGrd == null) return;

            try
            {
                //aGrd.Redraw = false; // Grid Display 멈춤

                int imageCnt = 0;

                // 기존 image 클리어
                for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

                for (int i = 0; i < aGrd.RowCount; i++)
                {
                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            if (aGrd.GetItemString(i, "dc_yn") == "Y") continue;

                            // 동일 group_ser, 동일 mix_group, 동일 희망일자, 동일 OrderGubun가 Mix구별임..
                            if (aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_date").ToString().Trim() == aGrd.GetItemValue(j, "order_date").ToString().Trim() //&&
                                //aGrd.GetItemValue(i, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) ==
                                //aGrd.GetItemValue(j, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1)
                                )
                            {
                                count++;
                                if (count > 1)
                                {
                                    //      헤더를 빼야 실제 Row
                                    aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                    aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                }
                            }
                        }
                        // 현재는 image 갯수만큼 처리
                        if (count > 1) imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
                    }
                }
            }
            finally
            {
                //aGrd.Redraw = true; // Grid Display 
            }

        }
        #endregion

        #region [cbxBuseo_SelectionChangeCommitted 病棟選択]
        private void cbxBuseo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!this.grdChulgoList.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }
        #endregion
    }
}


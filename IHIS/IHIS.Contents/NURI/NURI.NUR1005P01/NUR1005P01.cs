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

namespace IHIS.NURI
{
	/// <summary>
	/// NUR1005P01에 대한 요약 설명입니다.(반납리스트)
	/// </summary>
	[ToolboxItem(false)]
	public class NUR1005P01 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string FindName = string.Empty;
		#endregion
            
		#region 자동생성    
		private IHIS.Framework.XDisplayBox dbxSuname;
        private IHIS.Framework.XLabel lblBunho;
		private IHIS.Framework.XFindBox fbxBunho;
		private IHIS.Framework.XBuseoCombo cboHo_dong;
		private IHIS.Framework.XLabel lblHo_dong;
		private IHIS.Framework.XDatePicker dtpTo_order_date;
		private IHIS.Framework.XDatePicker dtpFrom_order_date;
		private IHIS.Framework.XLabel lblOrder_date;
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XRadioButton rbxY;
		private IHIS.Framework.XRadioButton rbxN;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XDataWindow dw_NUR1005P01;
		private System.Windows.Forms.Label lblDash;
		private IHIS.Framework.XGroupBox gbxGubun;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdNur1005;
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
		private IHIS.Framework.XFindWorker fwkBunho;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XRadioButton rbxA;
		private IHIS.Framework.XCheckBox chkAll;
		private IHIS.Framework.SingleLayout vsvBunhoCheck;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XLabel lblNurse_confirm;
		private IHIS.Framework.XLabel lblBan;
		private IHIS.Framework.XGroupBox gbxBannab_confirm;
		private IHIS.Framework.XRadioButton rbxBannab_confirm_N;
		private IHIS.Framework.XRadioButton rbxBannab_confirm_Y;
		private IHIS.Framework.XRadioButton rbxBannab_confirm_All;
		private IHIS.Framework.XCheckBox cbxIpwon_date_yn;
        private SingleLayoutItem singleLayoutItem1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR1005P01()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1005P01));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cbxIpwon_date_yn = new IHIS.Framework.XCheckBox();
            this.gbxBannab_confirm = new IHIS.Framework.XGroupBox();
            this.rbxBannab_confirm_N = new IHIS.Framework.XRadioButton();
            this.rbxBannab_confirm_Y = new IHIS.Framework.XRadioButton();
            this.rbxBannab_confirm_All = new IHIS.Framework.XRadioButton();
            this.lblBan = new IHIS.Framework.XLabel();
            this.lblNurse_confirm = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAll = new IHIS.Framework.XCheckBox();
            this.gbxGubun = new IHIS.Framework.XGroupBox();
            this.rbxN = new IHIS.Framework.XRadioButton();
            this.rbxY = new IHIS.Framework.XRadioButton();
            this.rbxA = new IHIS.Framework.XRadioButton();
            this.lblDash = new System.Windows.Forms.Label();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.lblBunho = new IHIS.Framework.XLabel();
            this.fbxBunho = new IHIS.Framework.XFindBox();
            this.fwkBunho = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.cboHo_dong = new IHIS.Framework.XBuseoCombo();
            this.lblHo_dong = new IHIS.Framework.XLabel();
            this.dtpTo_order_date = new IHIS.Framework.XDatePicker();
            this.dtpFrom_order_date = new IHIS.Framework.XDatePicker();
            this.lblOrder_date = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dw_NUR1005P01 = new IHIS.Framework.XDataWindow();
            this.grdNur1005 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.vsvBunhoCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.pnlTop.SuspendLayout();
            this.gbxBannab_confirm.SuspendLayout();
            this.gbxGubun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNur1005)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cbxIpwon_date_yn);
            this.pnlTop.Controls.Add(this.gbxBannab_confirm);
            this.pnlTop.Controls.Add(this.lblBan);
            this.pnlTop.Controls.Add(this.lblNurse_confirm);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.chkAll);
            this.pnlTop.Controls.Add(this.gbxGubun);
            this.pnlTop.Controls.Add(this.lblDash);
            this.pnlTop.Controls.Add(this.dbxSuname);
            this.pnlTop.Controls.Add(this.lblBunho);
            this.pnlTop.Controls.Add(this.fbxBunho);
            this.pnlTop.Controls.Add(this.cboHo_dong);
            this.pnlTop.Controls.Add(this.lblHo_dong);
            this.pnlTop.Controls.Add(this.dtpTo_order_date);
            this.pnlTop.Controls.Add(this.dtpFrom_order_date);
            this.pnlTop.Controls.Add(this.lblOrder_date);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(965, 95);
            this.pnlTop.TabIndex = 0;
            // 
            // cbxIpwon_date_yn
            // 
            this.cbxIpwon_date_yn.Location = new System.Drawing.Point(323, 7);
            this.cbxIpwon_date_yn.Name = "cbxIpwon_date_yn";
            this.cbxIpwon_date_yn.Size = new System.Drawing.Size(75, 18);
            this.cbxIpwon_date_yn.TabIndex = 150;
            this.cbxIpwon_date_yn.Text = "入院日～";
            this.cbxIpwon_date_yn.UseVisualStyleBackColor = false;
            this.cbxIpwon_date_yn.CheckedChanged += new System.EventHandler(this.cbxIpwon_date_yn_CheckedChanged);
            // 
            // gbxBannab_confirm
            // 
            this.gbxBannab_confirm.Controls.Add(this.rbxBannab_confirm_N);
            this.gbxBannab_confirm.Controls.Add(this.rbxBannab_confirm_Y);
            this.gbxBannab_confirm.Controls.Add(this.rbxBannab_confirm_All);
            this.gbxBannab_confirm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxBannab_confirm.Location = new System.Drawing.Point(87, 28);
            this.gbxBannab_confirm.Name = "gbxBannab_confirm";
            this.gbxBannab_confirm.Size = new System.Drawing.Size(171, 27);
            this.gbxBannab_confirm.TabIndex = 149;
            this.gbxBannab_confirm.TabStop = false;
            this.gbxBannab_confirm.Visible = false;
            // 
            // rbxBannab_confirm_N
            // 
            this.rbxBannab_confirm_N.CheckedValue = "N";
            this.rbxBannab_confirm_N.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbxBannab_confirm_N.Location = new System.Drawing.Point(8, 7);
            this.rbxBannab_confirm_N.Name = "rbxBannab_confirm_N";
            this.rbxBannab_confirm_N.Size = new System.Drawing.Size(63, 18);
            this.rbxBannab_confirm_N.TabIndex = 141;
            this.rbxBannab_confirm_N.Text = "未確認";
            this.rbxBannab_confirm_N.UseVisualStyleBackColor = false;
            this.rbxBannab_confirm_N.Visible = false;
            // 
            // rbxBannab_confirm_Y
            // 
            this.rbxBannab_confirm_Y.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbxBannab_confirm_Y.Location = new System.Drawing.Point(71, 7);
            this.rbxBannab_confirm_Y.Name = "rbxBannab_confirm_Y";
            this.rbxBannab_confirm_Y.Size = new System.Drawing.Size(49, 18);
            this.rbxBannab_confirm_Y.TabIndex = 142;
            this.rbxBannab_confirm_Y.Text = "確認";
            this.rbxBannab_confirm_Y.UseVisualStyleBackColor = false;
            this.rbxBannab_confirm_Y.Visible = false;
            // 
            // rbxBannab_confirm_All
            // 
            this.rbxBannab_confirm_All.Checked = true;
            this.rbxBannab_confirm_All.CheckedValue = "%";
            this.rbxBannab_confirm_All.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbxBannab_confirm_All.Location = new System.Drawing.Point(120, 7);
            this.rbxBannab_confirm_All.Name = "rbxBannab_confirm_All";
            this.rbxBannab_confirm_All.Size = new System.Drawing.Size(59, 18);
            this.rbxBannab_confirm_All.TabIndex = 143;
            this.rbxBannab_confirm_All.TabStop = true;
            this.rbxBannab_confirm_All.Text = "全体";
            this.rbxBannab_confirm_All.UseVisualStyleBackColor = false;
            this.rbxBannab_confirm_All.Visible = false;
            // 
            // lblBan
            // 
            this.lblBan.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBan.EdgeRounding = false;
            this.lblBan.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBan.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblBan.Location = new System.Drawing.Point(6, 34);
            this.lblBan.Name = "lblBan";
            this.lblBan.Size = new System.Drawing.Size(81, 20);
            this.lblBan.TabIndex = 148;
            this.lblBan.Text = "薬局確認有無";
            this.lblBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBan.Visible = false;
            // 
            // lblNurse_confirm
            // 
            this.lblNurse_confirm.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNurse_confirm.EdgeRounding = false;
            this.lblNurse_confirm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNurse_confirm.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblNurse_confirm.Location = new System.Drawing.Point(290, 34);
            this.lblNurse_confirm.Name = "lblNurse_confirm";
            this.lblNurse_confirm.Size = new System.Drawing.Size(81, 20);
            this.lblNurse_confirm.TabIndex = 147;
            this.lblNurse_confirm.Text = "看護確認有無";
            this.lblNurse_confirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNurse_confirm.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(949, 23);
            this.label1.TabIndex = 146;
            this.label1.Text = "該当プログラムは照会期間で照会をします。照会時照会期間(オーダ開始日付、オーダ終了日付)を確認してください。";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(676, 36);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 18);
            this.chkAll.TabIndex = 145;
            this.chkAll.Text = "全体";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // gbxGubun
            // 
            this.gbxGubun.Controls.Add(this.rbxN);
            this.gbxGubun.Controls.Add(this.rbxY);
            this.gbxGubun.Controls.Add(this.rbxA);
            this.gbxGubun.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxGubun.Location = new System.Drawing.Point(371, 28);
            this.gbxGubun.Name = "gbxGubun";
            this.gbxGubun.Size = new System.Drawing.Size(171, 27);
            this.gbxGubun.TabIndex = 4;
            this.gbxGubun.TabStop = false;
            this.gbxGubun.Visible = false;
            // 
            // rbxN
            // 
            this.rbxN.Checked = true;
            this.rbxN.CheckedValue = "N";
            this.rbxN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbxN.Location = new System.Drawing.Point(8, 7);
            this.rbxN.Name = "rbxN";
            this.rbxN.Size = new System.Drawing.Size(63, 18);
            this.rbxN.TabIndex = 141;
            this.rbxN.TabStop = true;
            this.rbxN.Text = "未確認";
            this.rbxN.UseVisualStyleBackColor = false;
            // 
            // rbxY
            // 
            this.rbxY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbxY.Location = new System.Drawing.Point(71, 7);
            this.rbxY.Name = "rbxY";
            this.rbxY.Size = new System.Drawing.Size(49, 18);
            this.rbxY.TabIndex = 142;
            this.rbxY.Text = "確認";
            this.rbxY.UseVisualStyleBackColor = false;
            // 
            // rbxA
            // 
            this.rbxA.CheckedValue = "%";
            this.rbxA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbxA.Location = new System.Drawing.Point(120, 7);
            this.rbxA.Name = "rbxA";
            this.rbxA.Size = new System.Drawing.Size(49, 18);
            this.rbxA.TabIndex = 143;
            this.rbxA.Text = "全体";
            this.rbxA.UseVisualStyleBackColor = false;
            // 
            // lblDash
            // 
            this.lblDash.BackColor = System.Drawing.Color.Transparent;
            this.lblDash.Location = new System.Drawing.Point(506, 9);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(8, 14);
            this.lblDash.TabIndex = 144;
            this.lblDash.Text = "-";
            this.lblDash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxSuname
            // 
            this.dbxSuname.Location = new System.Drawing.Point(808, 4);
            this.dbxSuname.Name = "dbxSuname";
            this.dbxSuname.Size = new System.Drawing.Size(147, 22);
            this.dbxSuname.TabIndex = 140;
            // 
            // lblBunho
            // 
            this.lblBunho.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBunho.EdgeRounding = false;
            this.lblBunho.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBunho.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblBunho.Location = new System.Drawing.Point(640, 6);
            this.lblBunho.Name = "lblBunho";
            this.lblBunho.Size = new System.Drawing.Size(68, 20);
            this.lblBunho.TabIndex = 139;
            this.lblBunho.Text = "患者番号";
            this.lblBunho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fbxBunho
            // 
            this.fbxBunho.FindWorker = this.fwkBunho;
            this.fbxBunho.Location = new System.Drawing.Point(708, 6);
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.Size = new System.Drawing.Size(100, 20);
            this.fbxBunho.TabIndex = 0;
            this.fbxBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunho_DataValidating);
            // 
            // fwkBunho
            // 
            this.fwkBunho.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkBunho.FormText = "患者リスト";
            this.fwkBunho.InputSQL = resources.GetString("fwkBunho.InputSQL");
            this.fwkBunho.ServerFilter = true;
            this.fwkBunho.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkBunho_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "bunho";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "患者番号";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "suname";
            this.findColumnInfo2.ColWidth = 147;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "患者氏名";
            // 
            // cboHo_dong
            // 
            this.cboHo_dong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHo_dong.Location = new System.Drawing.Point(74, 6);
            this.cboHo_dong.MaxDropDownItems = 50;
            this.cboHo_dong.Name = "cboHo_dong";
            this.cboHo_dong.Size = new System.Drawing.Size(171, 21);
            this.cboHo_dong.TabIndex = 1;
            this.cboHo_dong.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cboHo_dong_DataValidating);
            // 
            // lblHo_dong
            // 
            this.lblHo_dong.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_dong.EdgeRounding = false;
            this.lblHo_dong.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHo_dong.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHo_dong.Location = new System.Drawing.Point(6, 6);
            this.lblHo_dong.Name = "lblHo_dong";
            this.lblHo_dong.Size = new System.Drawing.Size(68, 21);
            this.lblHo_dong.TabIndex = 136;
            this.lblHo_dong.Text = "病棟";
            this.lblHo_dong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTo_order_date
            // 
            this.dtpTo_order_date.Location = new System.Drawing.Point(518, 6);
            this.dtpTo_order_date.Name = "dtpTo_order_date";
            this.dtpTo_order_date.Size = new System.Drawing.Size(100, 20);
            this.dtpTo_order_date.TabIndex = 3;
            this.dtpTo_order_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtp_order_date_DataValidating);
            // 
            // dtpFrom_order_date
            // 
            this.dtpFrom_order_date.Location = new System.Drawing.Point(401, 6);
            this.dtpFrom_order_date.Name = "dtpFrom_order_date";
            this.dtpFrom_order_date.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom_order_date.TabIndex = 2;
            this.dtpFrom_order_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtp_order_date_DataValidating);
            // 
            // lblOrder_date
            // 
            this.lblOrder_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblOrder_date.EdgeRounding = false;
            this.lblOrder_date.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder_date.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblOrder_date.Location = new System.Drawing.Point(255, 6);
            this.lblOrder_date.Name = "lblOrder_date";
            this.lblOrder_date.Size = new System.Drawing.Size(66, 21);
            this.lblOrder_date.TabIndex = 133;
            this.lblOrder_date.Text = "オーダ日";
            this.lblOrder_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 556);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(965, 34);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisiblePreview = false;
            this.btnList.Location = new System.Drawing.Point(640, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.Size = new System.Drawing.Size(325, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // dw_NUR1005P01
            // 
            this.dw_NUR1005P01.DataWindowObject = "dw_nur1005p01";
            this.dw_NUR1005P01.LibraryList = "..\\NURI\\nuri.nur1005p01.pbd";
            this.dw_NUR1005P01.Location = new System.Drawing.Point(0, 378);
            this.dw_NUR1005P01.Name = "dw_NUR1005P01";
            this.dw_NUR1005P01.Size = new System.Drawing.Size(960, 178);
            this.dw_NUR1005P01.TabIndex = 2;
            this.dw_NUR1005P01.Text = "xDataWindow1";
            // 
            // grdNur1005
            // 
            this.grdNur1005.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell13,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell14,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18});
            this.grdNur1005.ColPerLine = 9;
            this.grdNur1005.Cols = 10;
            this.grdNur1005.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNur1005.FixedCols = 1;
            this.grdNur1005.FixedRows = 1;
            this.grdNur1005.HeaderHeights.Add(29);
            this.grdNur1005.Location = new System.Drawing.Point(0, 95);
            this.grdNur1005.Name = "grdNur1005";
            this.grdNur1005.QuerySQL = resources.GetString("grdNur1005.QuerySQL");
            this.grdNur1005.ReadOnly = true;
            this.grdNur1005.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdNur1005.RowHeaderVisible = true;
            this.grdNur1005.Rows = 2;
            this.grdNur1005.RowStateCheckOnPaint = false;
            this.grdNur1005.Size = new System.Drawing.Size(965, 461);
            this.grdNur1005.TabIndex = 3;
            this.grdNur1005.ToolTipActive = true;
            this.grdNur1005.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNur1005_QueryStarting);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "ho_dong1";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "病棟";
            this.xEditGridCell13.IsUpdCol = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "ho_code1";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "病室";
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.CellWidth = 85;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "患者番号";
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.SuppressRepeating = true;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.CellWidth = 100;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "患者氏名";
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.SuppressRepeating = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "hangmog_code";
            this.xEditGridCell4.Col = 6;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "項目コード";
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "hangmog_name";
            this.xEditGridCell5.CellWidth = 281;
            this.xEditGridCell5.Col = 7;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell5.HeaderText = "項目名";
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "subul_suyang";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell6.CellWidth = 50;
            this.xEditGridCell6.Col = 8;
            this.xEditGridCell6.DecimalDigits = 1;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "返却\r\n数量";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "subul_danui";
            this.xEditGridCell7.CellWidth = 50;
            this.xEditGridCell7.Col = 9;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "単位";
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "nurse_confirm_user";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "nurse_confirm_user";
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "memb_name";
            this.xEditGridCell9.CellWidth = 90;
            this.xEditGridCell9.Col = 5;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "返却者";
            this.xEditGridCell9.IsUpdCol = false;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "order_date";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell14.CellWidth = 90;
            this.xEditGridCell14.Col = 1;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "返却日";
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.SuppressRepeating = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "jundal_part";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "jundal_part";
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "jundal_part_name";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "jundal_part_name";
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "bannab_confirm";
            this.xEditGridCell12.CellWidth = 30;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "薬局\r\n確認";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "nurse_confirm_yn";
            this.xEditGridCell15.CellWidth = 30;
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "看護\r\n確認";
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "acting_date";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell16.CellWidth = 90;
            this.xEditGridCell16.Col = 4;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "処方箋出力日";
            this.xEditGridCell16.IsUpdCol = false;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "pkocs2003";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "pkocs2003";
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "tag";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "tag";
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // vsvBunhoCheck
            // 
            this.vsvBunhoCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.vsvBunhoCheck.QuerySQL = resources.GetString("vsvBunhoCheck.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxSuname;
            this.singleLayoutItem1.DataName = "suname";
            // 
            // NUR1005P01
            // 
            this.Controls.Add(this.grdNur1005);
            this.Controls.Add(this.dw_NUR1005P01);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR1005P01";
            this.Size = new System.Drawing.Size(965, 590);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.gbxBannab_confirm.ResumeLayout(false);
            this.gbxGubun.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNur1005)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 스크린 로드
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			PostCallHelper.PostCall(new PostMethod(PostLoad));

		}

		private void PostLoad()
		{
			this.CurrMQLayout = this.grdNur1005;

            this.cboHo_dong.DataValidating -= new IHIS.Framework.DataValidatingEventHandler(this.cboHo_dong_DataValidating);
            this.dtpFrom_order_date.DataValidating -= new IHIS.Framework.DataValidatingEventHandler(this.dtp_order_date_DataValidating);
            this.dtpTo_order_date.DataValidating -= new IHIS.Framework.DataValidatingEventHandler(this.dtp_order_date_DataValidating);

			/* 간호사의 병동을 디폴트로 셋팅 */
			if(!TypeCheck.IsNull(UserInfo.HoDong.ToString()))
				this.cboHo_dong.SetEditValue(UserInfo.HoDong.ToString());
            else
                this.cboHo_dong.SetEditValue("1");


			/* 현재일자를 디폴트로 셋팅 */
            this.dtpFrom_order_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.dtpFrom_order_date.AcceptData();
            this.dtpTo_order_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.dtpTo_order_date.AcceptData();

			if (this.OpenParam != null)
			{
				this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
				this.fbxBunho.AcceptData();
				this.fbxBunho.Focus();
			}
			else
			{
				//현재스크린 환자번호
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					this.fbxBunho.SetEditValue(patientInfo.BunHo);
					this.fbxBunho.AcceptData();
				}
			}

            this.cboHo_dong.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cboHo_dong_DataValidating);
            this.dtpFrom_order_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtp_order_date_DataValidating);
            this.dtpTo_order_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtp_order_date_DataValidating);

            this.btnList.PerformClick(FunctionType.Query);
		}
		#endregion

		/// <summary>
		///	파인드 박스 통합 Validation 체크 
		/// </summary>
		/// <param name="fbx">
		/// 파인드박스 명
		/// </param>
		/// <returns></returns>

		#region 환자이름 조회
		private void fbxBunho_Enter(object sender, System.EventArgs e)
		{
//			FindName = "bunho";
//			this.MakeValService(this.fbxBunho);
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}

					e.IsBaseCall = false;

					if(!this.grdNur1005.QueryLayout(false))
					{
                        XMessageBox.Show(Service.ErrFullMsg);
						return;
					}
					break;

				case FunctionType.Print:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					if(this.grdNur1005.RowCount > 0)
					{
						this.dw_NUR1005P01.Reset();

						this.dw_NUR1005P01.FillData(this.grdNur1005.LayoutTable);

						if(this.dw_NUR1005P01.RowCount > 0)
						{
							try
							{
								this.dw_NUR1005P01.Print(true);
								if (this.grdNur1005.RowCount > 0)
								{
									for (int i = 0; i < this.grdNur1005.RowCount; i++)
									{
										this.grdNur1005.SetItemValue(i, "tag", "Y");
									}

                                    //저장안시킴. 리스트 출력만
                                    //if(!this.DataServiceCall(this.dsvUpdate))
                                    //{
                                    //    XMessageBox.Show(this.dsvUpdate.ErrFullMsg.ToString());
                                    //    return;
                                    //}
								}
							}
							catch(Exception Xe)
							{
								//https://sofiamedix.atlassian.net/browse/MED-10610
								//XMessageBox.Show(Xe.Message.ToString());
								return;
							}
						}
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region 등록번호를 입력을 했을 때
		private void fbxBunho_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{	
			if(this.fbxBunho.GetDataValue().ToString() == "")
			{
				this.dbxSuname.ResetData();
				return;
			}

            this.vsvBunhoCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.vsvBunhoCheck.SetBindVarValue("f_bunho", e.DataValue);
            this.vsvBunhoCheck.QueryLayout();
			
			if (TypeCheck.IsNull( vsvBunhoCheck.GetItemValue("suname").ToString()) == true)
            {
                string mbxMsg = "", mbxCap = "";
                mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が有効ではありません。"
                    : "환자번호를 확인하세요..";
                mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인!!!";
                XMessageBox.Show(mbxMsg, mbxCap);
				dbxSuname.SetDataValue("");
				e.Cancel = true;
				return;
			}
            this.dbxSuname.SetDataValue(vsvBunhoCheck.GetItemValue("suname").ToString());			

			GetBannabList(this.fbxBunho.GetDataValue().ToString());
		
		}

		private void GetBannabList(string aBunho)
		{
			//this.dsvNur1005p01.SetInValue("bunho",aBunho);
			if(!this.grdNur1005.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg);
				return;
			}
		}
		#endregion

		#region 환자 전체 선택시
		private void chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.chkAll.Checked)
			{
				this.fbxBunho.SetDataValue("");
				this.dbxSuname.SetDataValue("");
				this.fbxBunho.Enabled = false;
				this.dbxSuname.Enabled = false;

				GetBannabList("%");
			}
			else
			{
				this.fbxBunho.Enabled = true;
				this.dbxSuname.Enabled = true;
				this.fbxBunho.Focus();
			}

		}
		#endregion

        #region QueryStarting
        private void grdNur1005_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNur1005.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNur1005.SetBindVarValue("f_ho_dong", this.cboHo_dong.GetDataValue());
            this.grdNur1005.SetBindVarValue("f_bunho", this.fbxBunho.GetDataValue());
            this.grdNur1005.SetBindVarValue("f_ipwon_date_yn", this.cbxIpwon_date_yn.GetDataValue());
            this.grdNur1005.SetBindVarValue("f_from_date", this.dtpFrom_order_date.GetDataValue());
            this.grdNur1005.SetBindVarValue("f_to_date", this.dtpTo_order_date.GetDataValue());
            //this.grdNur1005.SetBindVarValue("f_confirm_yn", this.gbxGubun.GetDataValue());
            this.grdNur1005.SetBindVarValue("f_confirm_yn", "%");
            this.grdNur1005.SetBindVarValue("f_bannab_confirm_yn", this.gbxBannab_confirm.GetDataValue());
            this.grdNur1005.SetBindVarValue("q_user_id", UserInfo.UserID);
        }

        private void fwkBunho_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkBunho.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.fwkBunho.SetBindVarValue("f_ho_dong", this.cboHo_dong.GetDataValue());
        }
        #endregion

        private void dtp_order_date_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void cbxIpwon_date_yn_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxIpwon_date_yn.Checked)
                this.dtpFrom_order_date.Enabled = false;
            else
                this.dtpFrom_order_date.Enabled = true;

            this.btnList.PerformClick(FunctionType.Query);

        }

        private void cboHo_dong_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        #region 자동반납후 재조회
        //private void dsvUpdate_ServiceEnd(object sender, IHIS.Framework.ServiceEndArgs e)
        //{
        //    if(e.Result == SvcResult.OK)
        //    {
        //        if(this.DataServiceCall(this.dsvNur1005p01))
        //        {
        //        }
        //        else
        //        {
        //            XMessageBox.Show(this.dsvNur1005p01.ErrFullMsg.ToString());
        //            return;
        //        }
        //        return;
        //    }
        //}
		#endregion
    
        #region XSavePerformer 
        //private class XSavePerformer : ISavePerformer
        //{
        //    NUR1005P01 parent;

        //    public XSavePerformer(NUR1005P01 parent)
        //    {
        //        this.parent = parent;
        //    }

        //    public bool Execute(char callerID, RowDataItem item)
        //    {
        //        string cmdText = "";

        //        item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //        item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

        //        if (item.BindVarList["f_bannab_confirm"].VarValue != "Y" && item.BindVarList["f_nurse_bannab_confirm"].VarValue == "Y")
        //        { 
        //                PR_DRG_OCS_BANNAB('I', 'Y', :i_pkocs2003, :i_subul_danui, :i_subul_suyang, :q_user_id);                
        //        }

        //        return Service.ExecuteNonQuery(cmdText, item.BindVarList);
        //    }
        //}
        #endregion
    }
}


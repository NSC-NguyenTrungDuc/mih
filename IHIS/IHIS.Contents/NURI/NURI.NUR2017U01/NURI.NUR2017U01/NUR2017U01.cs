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

namespace IHIS.NURI
{
	/// <summary>
	/// NUR2017U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR2017U01 : IHIS.Framework.XScreen
	{
		#region 화면변수
		private string order_date       = string.Empty;
		private string pkocs2003        = string.Empty;
		private string user_id          = string.Empty;
		private string order_gubun      = string.Empty;
        private string acting_date      = string.Empty;
        //insert by jc
        private string act_res_date = string.Empty;
        private int paListRownum = -1;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdNUR2017;
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
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private System.Windows.Forms.ImageList imageListMixGroup;
		private IHIS.Framework.XDisplayBox dbxConfirmUserName;
		private IHIS.Framework.XTextBox txtConfirmUser;
		private IHIS.Framework.XLabel lblNurseId;
		private IHIS.Framework.XButton btnClearConfirmUser;
		private IHIS.Framework.XLabel lblOrder_date;
		private IHIS.Framework.XDatePicker dtpAct_Res_date;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.SingleLayout layBannab_yn_check;
        private IHIS.Framework.XPanel pnlBannab;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
        private SingleLayout layCommon;
        private SingleLayoutItem singleLayoutItem1;
        private XButton btnBannab_Y;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell43;
        private XBuseoCombo cboHo_dong;
        private XLabel lblHo_dong;
        private XEditGrid grdPalist;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private XButton btnNextPatient;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XCheckBox cbxBannab_del;
        private XButton btnAfterDate;
        private XButton btnBeforeDate;
        private XPanel pnlSession;
        private XLabel xLabel6;
        private XCheckBox cbxA;
        private XCheckBox cbxB;
        private XCheckBox cbxC;
        private XCheckBox cbxD;
		private System.ComponentModel.IContainer components;
		#endregion

		#region 생성자
		public NUR2017U01()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR2017U01));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.pnlSession = new IHIS.Framework.XPanel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.cbxA = new IHIS.Framework.XCheckBox();
            this.cbxB = new IHIS.Framework.XCheckBox();
            this.cbxC = new IHIS.Framework.XCheckBox();
            this.cbxD = new IHIS.Framework.XCheckBox();
            this.btnAfterDate = new IHIS.Framework.XButton();
            this.btnBeforeDate = new IHIS.Framework.XButton();
            this.cbxBannab_del = new IHIS.Framework.XCheckBox();
            this.dtpAct_Res_date = new IHIS.Framework.XDatePicker();
            this.lblOrder_date = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.dbxConfirmUserName = new IHIS.Framework.XDisplayBox();
            this.txtConfirmUser = new IHIS.Framework.XTextBox();
            this.lblNurseId = new IHIS.Framework.XLabel();
            this.btnClearConfirmUser = new IHIS.Framework.XButton();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnNextPatient = new IHIS.Framework.XButton();
            this.pnlBannab = new IHIS.Framework.XPanel();
            this.btnBannab_Y = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdNUR2017 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.layBannab_yn_check = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.cboHo_dong = new IHIS.Framework.XBuseoCombo();
            this.lblHo_dong = new IHIS.Framework.XLabel();
            this.grdPalist = new IHIS.Framework.XEditGrid();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.pnlTop.SuspendLayout();
            this.pnlSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlBannab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR2017)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "앞으로.gif");
            this.ImageList.Images.SetKeyName(5, "뒤로.gif");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlSession);
            this.pnlTop.Controls.Add(this.btnAfterDate);
            this.pnlTop.Controls.Add(this.btnBeforeDate);
            this.pnlTop.Controls.Add(this.cbxBannab_del);
            this.pnlTop.Controls.Add(this.dtpAct_Res_date);
            this.pnlTop.Controls.Add(this.lblOrder_date);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Controls.Add(this.dbxConfirmUserName);
            this.pnlTop.Controls.Add(this.txtConfirmUser);
            this.pnlTop.Controls.Add(this.lblNurseId);
            this.pnlTop.Controls.Add(this.btnClearConfirmUser);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1461, 63);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlSession
            // 
            this.pnlSession.Controls.Add(this.xLabel6);
            this.pnlSession.Controls.Add(this.cbxA);
            this.pnlSession.Controls.Add(this.cbxB);
            this.pnlSession.Controls.Add(this.cbxC);
            this.pnlSession.Controls.Add(this.cbxD);
            this.pnlSession.Location = new System.Drawing.Point(3, 35);
            this.pnlSession.Name = "pnlSession";
            this.pnlSession.Size = new System.Drawing.Size(236, 22);
            this.pnlSession.TabIndex = 30;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Location = new System.Drawing.Point(1, 1);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(63, 21);
            this.xLabel6.TabIndex = 20;
            this.xLabel6.Text = "チーム";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxA
            // 
            this.cbxA.AutoSize = true;
            this.cbxA.Location = new System.Drawing.Point(74, 3);
            this.cbxA.Name = "cbxA";
            this.cbxA.Size = new System.Drawing.Size(31, 17);
            this.cbxA.TabIndex = 14;
            this.cbxA.Text = "A";
            this.cbxA.UseVisualStyleBackColor = false;
            this.cbxA.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxB
            // 
            this.cbxB.AutoSize = true;
            this.cbxB.Location = new System.Drawing.Point(116, 3);
            this.cbxB.Name = "cbxB";
            this.cbxB.Size = new System.Drawing.Size(31, 17);
            this.cbxB.TabIndex = 15;
            this.cbxB.Text = "B";
            this.cbxB.UseVisualStyleBackColor = false;
            this.cbxB.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxC
            // 
            this.cbxC.AutoSize = true;
            this.cbxC.Location = new System.Drawing.Point(158, 3);
            this.cbxC.Name = "cbxC";
            this.cbxC.Size = new System.Drawing.Size(32, 17);
            this.cbxC.TabIndex = 16;
            this.cbxC.Text = "C";
            this.cbxC.UseVisualStyleBackColor = false;
            this.cbxC.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxD
            // 
            this.cbxD.AutoSize = true;
            this.cbxD.Location = new System.Drawing.Point(201, 3);
            this.cbxD.Name = "cbxD";
            this.cbxD.Size = new System.Drawing.Size(31, 17);
            this.cbxD.TabIndex = 17;
            this.cbxD.Text = "D";
            this.cbxD.UseVisualStyleBackColor = false;
            this.cbxD.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // btnAfterDate
            // 
            this.btnAfterDate.ImageIndex = 4;
            this.btnAfterDate.ImageList = this.ImageList;
            this.btnAfterDate.Location = new System.Drawing.Point(390, 6);
            this.btnAfterDate.Name = "btnAfterDate";
            this.btnAfterDate.Size = new System.Drawing.Size(24, 23);
            this.btnAfterDate.TabIndex = 29;
            this.btnAfterDate.Click += new System.EventHandler(this.btnAfterDate_Click);
            // 
            // btnBeforeDate
            // 
            this.btnBeforeDate.ImageIndex = 5;
            this.btnBeforeDate.ImageList = this.ImageList;
            this.btnBeforeDate.Location = new System.Drawing.Point(245, 5);
            this.btnBeforeDate.Name = "btnBeforeDate";
            this.btnBeforeDate.Size = new System.Drawing.Size(24, 23);
            this.btnBeforeDate.TabIndex = 28;
            this.btnBeforeDate.Click += new System.EventHandler(this.btnBeforeDate_Click);
            // 
            // cbxBannab_del
            // 
            this.cbxBannab_del.AutoSize = true;
            this.cbxBannab_del.Location = new System.Drawing.Point(909, 43);
            this.cbxBannab_del.Name = "cbxBannab_del";
            this.cbxBannab_del.Size = new System.Drawing.Size(88, 17);
            this.cbxBannab_del.TabIndex = 27;
            this.cbxBannab_del.Text = "返却非表示";
            this.cbxBannab_del.UseVisualStyleBackColor = false;
            this.cbxBannab_del.CheckedChanged += new System.EventHandler(this.cbxBannab_del_CheckedChanged);
            // 
            // dtpAct_Res_date
            // 
            this.dtpAct_Res_date.IsJapanYearType = true;
            this.dtpAct_Res_date.Location = new System.Drawing.Point(271, 7);
            this.dtpAct_Res_date.Name = "dtpAct_Res_date";
            this.dtpAct_Res_date.Size = new System.Drawing.Size(117, 20);
            this.dtpAct_Res_date.TabIndex = 26;
            this.dtpAct_Res_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpAct_Res_date_DataValidating);
            // 
            // lblOrder_date
            // 
            this.lblOrder_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblOrder_date.EdgeRounding = false;
            this.lblOrder_date.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblOrder_date.Location = new System.Drawing.Point(159, 6);
            this.lblOrder_date.Name = "lblOrder_date";
            this.lblOrder_date.Size = new System.Drawing.Size(79, 21);
            this.lblOrder_date.TabIndex = 25;
            this.lblOrder_date.Text = "実施日";
            this.lblOrder_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paBox
            // 
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(422, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(1078, 34);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // dbxConfirmUserName
            // 
            this.dbxConfirmUserName.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbxConfirmUserName.Location = new System.Drawing.Point(1239, 37);
            this.dbxConfirmUserName.Name = "dbxConfirmUserName";
            this.dbxConfirmUserName.Size = new System.Drawing.Size(120, 23);
            this.dbxConfirmUserName.TabIndex = 26;
            // 
            // txtConfirmUser
            // 
            this.txtConfirmUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConfirmUser.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmUser.Location = new System.Drawing.Point(1127, 37);
            this.txtConfirmUser.Name = "txtConfirmUser";
            this.txtConfirmUser.Size = new System.Drawing.Size(112, 23);
            this.txtConfirmUser.TabIndex = 1;
            this.txtConfirmUser.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtConfirmUser_DataValidating);
            // 
            // lblNurseId
            // 
            this.lblNurseId.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNurseId.EdgeRounding = false;
            this.lblNurseId.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNurseId.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblNurseId.Location = new System.Drawing.Point(1003, 37);
            this.lblNurseId.Name = "lblNurseId";
            this.lblNurseId.Size = new System.Drawing.Size(124, 23);
            this.lblNurseId.TabIndex = 24;
            this.lblNurseId.Text = "看護確認 ID";
            this.lblNurseId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClearConfirmUser
            // 
            this.btnClearConfirmUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearConfirmUser.Image = ((System.Drawing.Image)(resources.GetObject("btnClearConfirmUser.Image")));
            this.btnClearConfirmUser.Location = new System.Drawing.Point(1365, 37);
            this.btnClearConfirmUser.Name = "btnClearConfirmUser";
            this.btnClearConfirmUser.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnClearConfirmUser.Size = new System.Drawing.Size(62, 23);
            this.btnClearConfirmUser.TabIndex = 23;
            this.btnClearConfirmUser.Text = "クリア";
            this.btnClearConfirmUser.Click += new System.EventHandler(this.btnClearConfirmUser_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnNextPatient);
            this.pnlBottom.Controls.Add(this.pnlBannab);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 555);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1461, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnNextPatient
            // 
            this.btnNextPatient.ImageIndex = 4;
            this.btnNextPatient.ImageList = this.ImageList;
            this.btnNextPatient.Location = new System.Drawing.Point(949, 3);
            this.btnNextPatient.Name = "btnNextPatient";
            this.btnNextPatient.Size = new System.Drawing.Size(121, 28);
            this.btnNextPatient.TabIndex = 2;
            this.btnNextPatient.Text = "次の患者さんへ";
            this.btnNextPatient.Click += new System.EventHandler(this.btnNextPatient_Click);
            // 
            // pnlBannab
            // 
            this.pnlBannab.Controls.Add(this.btnBannab_Y);
            this.pnlBannab.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBannab.Location = new System.Drawing.Point(0, 0);
            this.pnlBannab.Name = "pnlBannab";
            this.pnlBannab.Padding = new System.Windows.Forms.Padding(3);
            this.pnlBannab.Size = new System.Drawing.Size(187, 35);
            this.pnlBannab.TabIndex = 1;
            // 
            // btnBannab_Y
            // 
            this.btnBannab_Y.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBannab_Y.ImageIndex = 0;
            this.btnBannab_Y.ImageList = this.ImageList;
            this.btnBannab_Y.Location = new System.Drawing.Point(3, 3);
            this.btnBannab_Y.Name = "btnBannab_Y";
            this.btnBannab_Y.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnBannab_Y.Size = new System.Drawing.Size(181, 29);
            this.btnBannab_Y.TabIndex = 0;
            this.btnBannab_Y.Tag = "B";
            this.btnBannab_Y.Text = "返却(返却取消)";
            this.btnBannab_Y.Visible = false;
            this.btnBannab_Y.Click += new System.EventHandler(this.btnBannab_Y_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Location = new System.Drawing.Point(1136, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.Size = new System.Drawing.Size(325, 35);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdNUR2017
            // 
            this.grdNUR2017.AddedHeaderLine = 1;
            this.grdNUR2017.ApplyPaintEventToAllColumn = true;
            this.grdNUR2017.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell40,
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
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell38,
            this.xEditGridCell36,
            this.xEditGridCell39,
            this.xEditGridCell42,
            this.xEditGridCell37,
            this.xEditGridCell43,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56});
            this.grdNUR2017.ColPerLine = 22;
            this.grdNUR2017.Cols = 23;
            this.grdNUR2017.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR2017.FixedCols = 1;
            this.grdNUR2017.FixedRows = 2;
            this.grdNUR2017.HeaderHeights.Add(49);
            this.grdNUR2017.HeaderHeights.Add(0);
            this.grdNUR2017.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdNUR2017.Location = new System.Drawing.Point(276, 63);
            this.grdNUR2017.Name = "grdNUR2017";
            this.grdNUR2017.QuerySQL = resources.GetString("grdNUR2017.QuerySQL");
            this.grdNUR2017.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdNUR2017.RowHeaderVisible = true;
            this.grdNUR2017.Rows = 3;
            this.grdNUR2017.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdNUR2017.Size = new System.Drawing.Size(1185, 492);
            this.grdNUR2017.TabIndex = 2;
            this.grdNUR2017.ToolTipActive = true;
            this.grdNUR2017.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdNUR2017_ItemValueChanging);
            this.grdNUR2017.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNUR2017_QueryEnd);
            this.grdNUR2017.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grdNUR2017_MouseMove);
            this.grdNUR2017.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdNUR2017_GridColumnProtectModify);
            this.grdNUR2017.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR2017_GridColumnChanged);
            this.grdNUR2017.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR2017_GridCellPainting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "ho_code1";
            this.xEditGridCell1.CellWidth = 0;
            this.xEditGridCell1.Col = 4;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "病室";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "bunho";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "suname";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gwa_name";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "診療科";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "hangmog_code";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "項目コード";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "hangmog_name";
            this.xEditGridCell6.CellWidth = 226;
            this.xEditGridCell6.Col = 8;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "項目名";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "act_res_date";
            this.xEditGridCell40.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell40.CellWidth = 40;
            this.xEditGridCell40.Col = 6;
            this.xEditGridCell40.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell40.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell40.HeaderText = "施行\r\n予定日";
            this.xEditGridCell40.HeaderTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.RowSpan = 2;
            this.xEditGridCell40.SuppressRepeating = true;
            this.xEditGridCell40.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "suryang";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell7.CellWidth = 31;
            this.xEditGridCell7.Col = 9;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "数\r\n量";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "ord_danui";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "単位";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "dv_time";
            this.xEditGridCell9.CellWidth = 17;
            this.xEditGridCell9.Col = 11;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "dv_time";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.Row = 1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "dv";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell10.CellWidth = 18;
            this.xEditGridCell10.Col = 12;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell10.HeaderText = "dv";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.Row = 1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "jusa";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "注射";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "bogyong_code";
            this.xEditGridCell12.CellWidth = 150;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "bogyong_code";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "acting_date";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell13.CellWidth = 40;
            this.xEditGridCell13.Col = 17;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell13.HeaderText = "acting_date";
            this.xEditGridCell13.Row = 1;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "acting_time";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell14.CellWidth = 40;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "acting_time";
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Mask = "HH:MI";
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "act_user";
            this.xEditGridCell15.CellWidth = 53;
            this.xEditGridCell15.Col = 18;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "act_user";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.Row = 1;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "acting_yn";
            this.xEditGridCell16.CellWidth = 35;
            this.xEditGridCell16.Col = 20;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "確\r\n認";
            this.xEditGridCell16.RowSpan = 2;
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "fkocs2003";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "fkocs2003";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "seq";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "seq";
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "order_date";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell19.CellWidth = 40;
            this.xEditGridCell19.Col = 5;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.HeaderText = "オーダ\r\n日付";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.SuppressRepeating = true;
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "bogyong_name";
            this.xEditGridCell20.CellWidth = 123;
            this.xEditGridCell20.Col = 14;
            this.xEditGridCell20.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell20.HeaderText = "服用法/注射速度";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.RowSpan = 2;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "dc_yn";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "dc_yn";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "group_ser";
            this.xEditGridCell22.CellWidth = 23;
            this.xEditGridCell22.Col = 7;
            this.xEditGridCell22.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell22.HeaderText = "GR";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdCol = false;
            this.xEditGridCell22.RowSpan = 2;
            this.xEditGridCell22.SuppressRepeating = true;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "mix_group";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.HeaderText = "mix_group";
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdCol = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.SuppressRepeating = true;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "hope_date";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "hope_date";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "jusa_text";
            this.xEditGridCell25.CellWidth = 81;
            this.xEditGridCell25.Col = 13;
            this.xEditGridCell25.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell25.HeaderText = "注射";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.RowSpan = 2;
            this.xEditGridCell25.SuppressRepeating = true;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "danui_text";
            this.xEditGridCell26.CellWidth = 30;
            this.xEditGridCell26.Col = 10;
            this.xEditGridCell26.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell26.HeaderText = "単位";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.RowSpan = 2;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellLen = 2000;
            this.xEditGridCell27.CellName = "order_remark";
            this.xEditGridCell27.CellWidth = 83;
            this.xEditGridCell27.Col = 22;
            this.xEditGridCell27.DisplayMemoText = true;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell27.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell27.HeaderText = "医師コメント";
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.RowSpan = 2;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellLen = 2000;
            this.xEditGridCell28.CellName = "nurse_remark";
            this.xEditGridCell28.CellWidth = 79;
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell28.HeaderText = "看護コメント";
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "input_gubun_text";
            this.xEditGridCell29.CellWidth = 60;
            this.xEditGridCell29.Col = 3;
            this.xEditGridCell29.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell29.HeaderText = "区分";
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.RowSpan = 2;
            this.xEditGridCell29.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "jusa_spd_gubun";
            this.xEditGridCell30.CellWidth = 40;
            this.xEditGridCell30.Col = 15;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell30.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell30.HeaderText = "ml\r\nhr";
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.RowSpan = 2;
            this.xEditGridCell30.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell30.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM OCS0132\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
                ")\r\n   AND CODE_TYPE = \'JUSA_SPD_GUBUN\'\r\n ORDER BY 1\r\n";
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "act_user_name";
            this.xEditGridCell31.Col = 19;
            this.xEditGridCell31.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell31.HeaderText = "act_user_name";
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.Row = 1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "bannab_yn";
            this.xEditGridCell32.CellWidth = 0;
            this.xEditGridCell32.Col = 1;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell32.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell32.HeaderText = "返却";
            this.xEditGridCell32.RowSpan = 2;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "bannab_fkocs2003";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.HeaderText = "bannab_fkocs2003";
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "old_bannab_yn";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.HeaderText = "old_bannab_yn";
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "drug_bannab_yn";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.HeaderText = "drug_bannab_yn";
            this.xEditGridCell35.IsUpdCol = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "order_dc_yn";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.HeaderText = "order_dc_yn";
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "order_bannab_yn";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.HeaderText = "order_bannab_yn";
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "bannab_acting_yn";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.HeaderText = "bannab_acting_yn";
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "pattern_gubun";
            this.xEditGridCell42.CellWidth = 43;
            this.xEditGridCell42.Col = 16;
            this.xEditGridCell42.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell42.HeaderText = "pattern_gubun";
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.Row = 1;
            this.xEditGridCell42.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "order_gubun";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.HeaderText = "order_gubun";
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "order_gubun_name";
            this.xEditGridCell43.CellWidth = 40;
            this.xEditGridCell43.Col = 2;
            this.xEditGridCell43.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell43.HeaderText = "オーダ\r\n区分";
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.RowSpan = 2;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "pass_yn";
            this.xEditGridCell52.CellWidth = 35;
            this.xEditGridCell52.Col = 21;
            this.xEditGridCell52.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell52.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell52.HeaderText = "見\r\n送\r\nり";
            this.xEditGridCell52.RowSpan = 2;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "if_data_send_yn";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.HeaderText = "if_data_send_yn";
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "jubsu_date";
            this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "drg_bunho";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "serial_v";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 11;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader1.HeaderText = "回数";
            this.xGridHeader1.HeaderWidth = 17;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 16;
            this.xGridHeader2.ColSpan = 4;
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader2.HeaderText = "確認内訳";
            this.xGridHeader2.HeaderWidth = 43;
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "");
            this.imageListMixGroup.Images.SetKeyName(1, "");
            this.imageListMixGroup.Images.SetKeyName(2, "");
            this.imageListMixGroup.Images.SetKeyName(3, "");
            this.imageListMixGroup.Images.SetKeyName(4, "");
            this.imageListMixGroup.Images.SetKeyName(5, "");
            this.imageListMixGroup.Images.SetKeyName(6, "");
            this.imageListMixGroup.Images.SetKeyName(7, "");
            this.imageListMixGroup.Images.SetKeyName(8, "");
            this.imageListMixGroup.Images.SetKeyName(9, "");
            this.imageListMixGroup.Images.SetKeyName(10, "");
            this.imageListMixGroup.Images.SetKeyName(11, "");
            this.imageListMixGroup.Images.SetKeyName(12, "");
            this.imageListMixGroup.Images.SetKeyName(13, "");
            this.imageListMixGroup.Images.SetKeyName(14, "");
            this.imageListMixGroup.Images.SetKeyName(15, "");
            this.imageListMixGroup.Images.SetKeyName(16, "");
            this.imageListMixGroup.Images.SetKeyName(17, "");
            this.imageListMixGroup.Images.SetKeyName(18, "");
            this.imageListMixGroup.Images.SetKeyName(19, "");
            // 
            // layBannab_yn_check
            // 
            this.layBannab_yn_check.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layBannab_yn_check.QuerySQL = "SELECT FN_OCS_CAN_PART_BANNAB(:f_fkocs2003) FROM DUAL";
            this.layBannab_yn_check.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layBannab_yn_check_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "bannab_yn";
            // 
            // cboHo_dong
            // 
            this.cboHo_dong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHo_dong.Enabled = false;
            this.cboHo_dong.Location = new System.Drawing.Point(72, 5);
            this.cboHo_dong.MaxDropDownItems = 40;
            this.cboHo_dong.Name = "cboHo_dong";
            this.cboHo_dong.Size = new System.Drawing.Size(81, 21);
            this.cboHo_dong.TabIndex = 25;
            // 
            // lblHo_dong
            // 
            this.lblHo_dong.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_dong.EdgeRounding = false;
            this.lblHo_dong.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHo_dong.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHo_dong.Location = new System.Drawing.Point(3, 5);
            this.lblHo_dong.Name = "lblHo_dong";
            this.lblHo_dong.Size = new System.Drawing.Size(63, 21);
            this.lblHo_dong.TabIndex = 26;
            this.lblHo_dong.Text = "病棟";
            this.lblHo_dong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdPalist
            // 
            this.grdPalist.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell50,
            this.xEditGridCell41,
            this.xEditGridCell51,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49});
            this.grdPalist.ColPerLine = 8;
            this.grdPalist.Cols = 8;
            this.grdPalist.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdPalist.FixedRows = 1;
            this.grdPalist.HeaderHeights.Add(23);
            this.grdPalist.Location = new System.Drawing.Point(0, 63);
            this.grdPalist.Name = "grdPalist";
            this.grdPalist.QuerySQL = resources.GetString("grdPalist.QuerySQL");
            this.grdPalist.ReadOnly = true;
            this.grdPalist.Rows = 2;
            this.grdPalist.Size = new System.Drawing.Size(276, 492);
            this.grdPalist.TabIndex = 22;
            this.grdPalist.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPalist_QueryEnd);
            this.grdPalist.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPalist_QueryStarting);
            this.grdPalist.Click += new System.EventHandler(this.grdPalist_Click);
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "ho_dong";
            this.xEditGridCell50.Col = 6;
            this.xEditGridCell50.HeaderText = "病棟";
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellLen = 4;
            this.xEditGridCell41.CellName = "ho_code";
            this.xEditGridCell41.CellWidth = 40;
            this.xEditGridCell41.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell41.HeaderText = "病室";
            this.xEditGridCell41.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "bed_no";
            this.xEditGridCell51.Col = 7;
            this.xEditGridCell51.HeaderText = "病床";
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellLen = 9;
            this.xEditGridCell44.CellName = "bunho";
            this.xEditGridCell44.CellWidth = 75;
            this.xEditGridCell44.Col = 1;
            this.xEditGridCell44.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell44.HeaderText = "患者番号";
            this.xEditGridCell44.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellLen = 30;
            this.xEditGridCell45.CellName = "su_name";
            this.xEditGridCell45.CellWidth = 100;
            this.xEditGridCell45.Col = 2;
            this.xEditGridCell45.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell45.HeaderText = "患者氏名";
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "pkinp1001";
            this.xEditGridCell46.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellLen = 20;
            this.xEditGridCell47.CellName = "age_sex";
            this.xEditGridCell47.CellWidth = 40;
            this.xEditGridCell47.Col = 3;
            this.xEditGridCell47.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell47.HeaderText = "年/性";
            this.xEditGridCell47.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "ipwon_date";
            this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell48.CellWidth = 90;
            this.xEditGridCell48.Col = 4;
            this.xEditGridCell48.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell48.HeaderText = "入院日付";
            this.xEditGridCell48.IsJapanYearType = true;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellLen = 30;
            this.xEditGridCell49.CellName = "doctor_name";
            this.xEditGridCell49.CellWidth = 100;
            this.xEditGridCell49.Col = 5;
            this.xEditGridCell49.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell49.HeaderText = "主治医";
            // 
            // NUR2017U01
            // 
            this.Controls.Add(this.cboHo_dong);
            this.Controls.Add(this.lblHo_dong);
            this.Controls.Add(this.grdNUR2017);
            this.Controls.Add(this.grdPalist);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "NUR2017U01";
            this.Size = new System.Drawing.Size(1461, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR2017U01_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSession.ResumeLayout(false);
            this.pnlSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBannab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR2017)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region 메세지처리 同期化完了
        /// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "user_id":
					msg = NetInfo.Language == LangMode.Ko ? "간호확인 ID가 정확하지 않습니다. 확인해 주세요."
						: "看護確認IDが正確ではありません。ご確認ください。";
					caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "確認";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "nurse_confirm_enable":
					msg = NetInfo.Language == LangMode.Ko ? "오더확인권한이 없습니다. 확인바랍니다."
						: "オーダ確認権限がありません。ご確認ください。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "確認";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "bannab_yn":
					msg = NetInfo.Language == LangMode.Ko ? "해당 오다는 반납처리를 할 수 없는 오다입니다."
						: "該当オーダは返却処理不可能なオーダです。";
					caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "確認";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "保存完了";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。";
					msg += "\r\n[" + Service.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "保存失敗";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				case "bannab_true":
					msg = NetInfo.Language == LangMode.Ko ? "처리가 완료되었습니다."
						: "処理が完了しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "保存完了";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				default:
					break;
			}
		}
		#endregion

		#region Screen Load 同期化完了
		private void NUR2017U01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            int width = this.Width;
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;

            //if (rc.Width - 30 < this.Width)
            //{
            //    width = rc.Width - 30;
            //}
            this.ParentForm.Size = new System.Drawing.Size(width, rc.Height - 105);

            this.grdNUR2017.SavePerformer = new XSavePerformer(this);
			this.CurrMQLayout = this.grdNUR2017;
            this.dtpAct_Res_date.Enabled = true;
            this.paBox.Enabled = true;

            if (e.OpenParam != null)
            {
                if (e.OpenParam.Contains("order_date") && e.OpenParam["order_date"] != null)
                {
                    this.act_res_date = this.OpenParam["order_date"].ToString();
                    //this.dtpAct_Res_date.SetEditValue(this.OpenParam["order_date"].ToString());
                    //this.dtpAct_Res_date.AcceptData();
                }

                if (e.OpenParam.Contains("pkocs2003") && e.OpenParam["pkocs2003"] != null)
                {
                    this.pkocs2003 = this.OpenParam["pkocs2003"].ToString();
                    this.dtpAct_Res_date.Enabled = false;
                    this.paBox.Enabled = false;
                }

                if (e.OpenParam.Contains("user_id") && e.OpenParam["user_id"] != null)
                {
                    this.user_id = this.OpenParam["user_id"].ToString();
                    this.txtConfirmUser.SetEditValue(this.user_id.ToString());
                    this.txtConfirmUser.AcceptData();
                }

                if (e.OpenParam.Contains("order_gubun") && e.OpenParam["order_gubun"] != null)
                {
                    this.order_gubun = this.OpenParam["order_gubun"].ToString();
                }
                if (e.OpenParam.Contains("acting_date") && e.OpenParam["acting_date"] != null)
                {
                    this.acting_date = this.OpenParam["acting_date"].ToString();
                    this.dtpAct_Res_date.SetEditValue(this.OpenParam["acting_date"].ToString());
                    //this.dtpAct_Res_date.AcceptData();
                }
                else
                {
                    this.dtpAct_Res_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    //this.dtpAct_Res_date.AcceptData();
                    this.act_res_date = this.dtpAct_Res_date.GetDataValue().ToString();
                }

                if (e.OpenParam.Contains("bunho") && e.OpenParam["bunho"] != null)
                {

                    this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());

                    string sqlcmd = "SELECT HO_DONG1 FROM VW_OCS_INP1001_01 WHERE HOSP_CODE='" + EnvironInfo.HospCode + "' AND BUNHO = '" + e.OpenParam["bunho"].ToString() + "'";

                    object result = Service.ExecuteScalar(sqlcmd);

                    if (result != null)
                    {
                        this.cboHo_dong.SetEditValue(result.ToString());
                    }

                    grdPalist.QueryLayout(true);
                }                

                PostCallHelper.PostCall(new PostMethod(SetFocus));

                //this.btnList.PerformClick(FunctionType.Query);
            }
            else
            {
                this.dtpAct_Res_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                //this.dtpAct_Res_date.AcceptData();
                this.act_res_date = this.dtpAct_Res_date.GetDataValue().ToString();
            }

		}
		#endregion

		#region 포커스이동 同期化完了
		private void SetFocus()
		{
			this.txtConfirmUser.Focus();
		}
		#endregion

		#region DC여부를 표현 同期化完了
		private void grdNUR2017_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			// 간호사가 주사투여화면에서 반납실시한 건은 빨간 줄 표시
			// 의사가 반납지시낸 건을 반납처리한 경우는 주사실시가 된 건이라면 빨간 줄을 표시하지 않는다.
            //if (e.DataRow["old_bannab_yn"].ToString() == "Y")
            //{
            //    e.DrawMiddleLine = true;
            //    e.MiddleLineColor = Color.Red;
            //}

            if (e.DataRow["order_bannab_yn"].ToString() == "Y" && e.DataRow["acting_yn"].ToString() == "N" && e.ColName != "bannab_yn" && e.ColName != "acting_yn")
			{
				e.DrawMiddleLine = true;
				e.MiddleLineColor = Color.Red;
			}
			
            //if (e.DataRow["drug_bannab_yn"].ToString() == "Y") 
            if (e.DataRow["order_dc_yn"].ToString() == "Y" && e.ColName != "bannab_yn" && e.ColName != "acting_yn") 
			{	
				e.DrawMiddleLine = true;
				e.MiddleLineColor = Color.Red;
                //e.BackColor = Color.MistyRose;
				e.ForeColor = Color.Red;
			}

            if (grdNUR2017.GetItemString(e.RowNumber, "if_data_send_yn") == "Y")
            {
                e.BackColor = Color.DarkGray;
            }	

//			if (e.ColName == "act_user")
//			{
//				if (e.DataRow["act_user"].ToString() != "" && e.DataRow["act_user"].ToString() != this.user_id.ToString())
//				{
//					e.BackColor = Color.Khaki;
//				}
//			}
		}
		#endregion

		#region 그리드에서 확인을 했을 때
		private void grdNUR2017_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
		{

			this.grdNUR2017.ItemValueChanging -= new IHIS.Framework.ItemValueChangingEventHandler(this.grdNUR2017_ItemValueChanging);

            switch(e.ColName)
			{
				case "acting_yn":
					if (this.user_id.ToString() == "")
					{
						this.GetMessage("user_id");
						if (e.ChangeValue.ToString() == "Y")
						{
							this.grdNUR2017.SetItemValue(e.RowNumber, "acting_yn"  , "N");
							this.grdNUR2017.AcceptData();
						}
						else
						{
							this.grdNUR2017.SetItemValue(e.RowNumber, "acting_yn"  , "Y");
							this.grdNUR2017.AcceptData();
						}
						this.grdNUR2017.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdNUR2017_ItemValueChanging);
                        this.txtConfirmUser.Focus();
						return;
					}

					if(e.ChangeValue.ToString() == "Y")
					{
                        for (int i = 0; i < this.grdNUR2017.RowCount; i++)
                        {
                           if(e.RowNumber == i)
                           {
                               continue;
                           }
                            //같은 종류 체크
                            if (
                                    //약은 패턴구분이 있고, 패턴 구분이 같고, 취소 구분이 같은것
                                    ((
                                        (this.grdNUR2017.GetItemValue(e.RowNumber, "pattern_gubun").ToString() != "") &&
                                        (this.grdNUR2017.GetItemValue(e.RowNumber, "pattern_gubun").ToString() == this.grdNUR2017.GetItemValue(i, "pattern_gubun").ToString())&&
                                        (this.grdNUR2017.GetItemValue(e.RowNumber, "order_dc_yn").ToString() == this.grdNUR2017.GetItemValue(i, "order_dc_yn").ToString())
                                    )||
                                    //주사는 패턴 구분이 없고, MIX그룹이 같고 SEQ가 같은것
                                    (
                                        (this.grdNUR2017.GetItemValue(e.RowNumber, "pattern_gubun").ToString() == "") &&
                                        (this.grdNUR2017.GetItemValue(e.RowNumber, "mix_group").ToString() != "") &&
                                        (this.grdNUR2017.GetItemValue(e.RowNumber, "mix_group").ToString() == this.grdNUR2017.GetItemValue(i, "mix_group").ToString()) &&
                                        (this.grdNUR2017.GetItemValue(e.RowNumber, "seq").ToString() == this.grdNUR2017.GetItemValue(i, "seq").ToString())&&
                                        (this.grdNUR2017.GetItemValue(e.RowNumber, "group_ser").ToString() == this.grdNUR2017.GetItemValue(i, "group_ser").ToString())
                                    ))&&
                                    ("N" == this.grdNUR2017.GetItemValue(i, "acting_yn").ToString())
                                )
                            {
                                this.grdNUR2017.SetItemValue(i, "acting_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                                this.grdNUR2017.SetItemValue(i, "acting_time", EnvironInfo.GetSysDateTime().ToString("HH:mm"));
                                this.grdNUR2017.SetItemValue(i, "act_user", this.user_id.ToString());
                                this.grdNUR2017.SetItemValue(i, "act_user_name", this.dbxConfirmUserName.GetDataValue().ToString());
                                this.grdNUR2017.SetItemValue(i, "acting_yn", "Y");
                                this.grdNUR2017.SetItemValue(i, "pass_yn", "Y");
                                this.grdNUR2017.AcceptData();
                            }
                        }
                        this.grdNUR2017.SetItemValue(e.RowNumber, "acting_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                        this.grdNUR2017.SetItemValue(e.RowNumber, "acting_time", EnvironInfo.GetSysDateTime().ToString("HH:mm"));
                        this.grdNUR2017.SetItemValue(e.RowNumber, "act_user", this.user_id.ToString());
                        this.grdNUR2017.SetItemValue(e.RowNumber, "act_user_name", this.dbxConfirmUserName.GetDataValue().ToString());
                        this.grdNUR2017.SetItemValue(e.RowNumber, "acting_yn", "Y");
                        this.grdNUR2017.SetItemValue(e.RowNumber, "pass_yn", "Y");
                        this.grdNUR2017.AcceptData();
					}
					else // 실시 체크 해제시 acting 만 푼다.
					{                        
                        //this.grdNUR2017.SetItemValue(e.RowNumber, "acting_date", "");
                        //this.grdNUR2017.SetItemValue(e.RowNumber, "acting_time", "");
                        //this.grdNUR2017.SetItemValue(e.RowNumber, "act_user", "");
                        //this.grdNUR2017.SetItemValue(e.RowNumber, "act_user_name", "");
                        this.grdNUR2017.SetItemValue(e.RowNumber, "acting_yn", "N");
                        this.grdNUR2017.AcceptData();                        
					}
					break;

                case "pass_yn":

                    if (grdNUR2017.GetItemString(e.RowNumber, "if_data_send_yn") == "Y")
                    {
                        XMessageBox.Show("既に会計されました。会計取消をしてから、作業できます。", "医事課連絡", MessageBoxIcon.Warning);
                        grdNUR2017.SetItemValue(e.RowNumber, e.ColName, e.ChangeValue.ToString() == "Y" ? "N" : "Y");
                        this.grdNUR2017.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdNUR2017_ItemValueChanging);
                        return;
                    }

                    if (this.user_id.ToString() == "")
                    {
                        this.GetMessage("user_id");
                        if (e.ChangeValue.ToString() == "Y")
                        {
                            this.grdNUR2017.SetItemValue(e.RowNumber, "pass_yn", "N");
                            this.grdNUR2017.AcceptData();
                        }
                        else
                        {
                            this.grdNUR2017.SetItemValue(e.RowNumber, "pass_yn", "Y");
                            this.grdNUR2017.AcceptData();
                        }
                        this.grdNUR2017.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdNUR2017_ItemValueChanging);
                        this.txtConfirmUser.Focus();
                        return;
                    }


                    if (e.ChangeValue.ToString() == "Y")
                    {
                        if (this.grdNUR2017.GetItemString(e.RowNumber, "acting_yn") == "Y")
                        {
                            this.grdNUR2017.SetItemValue(e.RowNumber, "pass_yn", "Y");
                        }
                        else
                        {
                            this.grdNUR2017.SetItemValue(e.RowNumber, "acting_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                            this.grdNUR2017.SetItemValue(e.RowNumber, "acting_time", EnvironInfo.GetSysDateTime().ToString("HH:mm"));
                            this.grdNUR2017.SetItemValue(e.RowNumber, "act_user", this.user_id.ToString());
                            this.grdNUR2017.SetItemValue(e.RowNumber, "act_user_name", this.dbxConfirmUserName.GetDataValue().ToString());
                            this.grdNUR2017.SetItemValue(e.RowNumber, "pass_yn", "Y");
                        }
                    }
                    else
                    {
                        this.grdNUR2017.SetItemValue(e.RowNumber, "acting_date", "");
                        this.grdNUR2017.SetItemValue(e.RowNumber, "acting_time", "");
                        this.grdNUR2017.SetItemValue(e.RowNumber, "act_user", "");
                        this.grdNUR2017.SetItemValue(e.RowNumber, "act_user_name", "");
                        this.grdNUR2017.SetItemValue(e.RowNumber, "acting_yn", "N");
                        this.grdNUR2017.SetItemValue(e.RowNumber, "pass_yn", "N");
                    }
                    this.grdNUR2017.AcceptData();
                    break;
                case "bannab_yn":
                    if (this.user_id.ToString() == "")
                    {
                        this.GetMessage("user_id");
                        if (e.ChangeValue.ToString() == "Y")
                        {
                            this.grdNUR2017.SetItemValue(e.RowNumber, "bannab_yn", "N");
                            this.grdNUR2017.AcceptData();
                        }
                        else
                        {
                            this.grdNUR2017.SetItemValue(e.RowNumber, "bannab_yn", "Y");
                            this.grdNUR2017.AcceptData();
                        }
                        this.grdNUR2017.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdNUR2017_ItemValueChanging);
                        return;
                    }

                    //반납이 가능한지 여부를 조회한다.
                    //delete by jc
                    //if (this.layBannab_yn_check.QueryLayout())
                    //{
                    //    if (this.layBannab_yn_check.GetItemValue("bannab_yn").ToString() != "Y")
                    //    {
                    //        if (e.ChangeValue.ToString() == "Y")
                    //        {
                    //            this.GetMessage("bannab_yn");
                    //            this.grdNUR2017.SetItemValue(this.grdNUR2017.CurrentRowNumber, "bannab_yn", "N");
                    //        }
                    //        else
                    //        {
                    //            this.GetMessage("bannab_yn");
                    //            this.grdNUR2017.SetItemValue(this.grdNUR2017.CurrentRowNumber, "bannab_yn", "Y");
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    XMessageBox.Show(Service.ErrFullMsg.ToString());
                    //    return;
                    //}
                    break;
			}
			this.grdNUR2017.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdNUR2017_ItemValueChanging);
		}
		#endregion

		#region 복용법명칭 Tooltip처리 同期化完了
		private void grdNUR2017_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            //if (this.grdNUR2017.RowCount <= 0) return;

            //XCell ac = this.grdNUR2017.CellAtPoint(new Point(e.X,e.Y));

            //if (ac == null) return;

            //if (ac.CellName == "bogyong_code")
            //    ac.ToolTipText = this.grdNUR2017.GetItemString(ac.Row-2,"bogyong_name").ToString();

            if (this.grdNUR2017.RowCount > 0)
            {
                XCell cell = this.grdNUR2017.CellAtPoint(new Point(e.X, e.Y));
                if ((cell != null) && (cell.CellName == "bogyong_code"))
                {
                    cell.ToolTipText = this.grdNUR2017.GetItemString(cell.Row - 2, "bogyong_name").ToString();
                }
            }

		}
		#endregion

		#region Mix Group 데이타 Image Display (DisplayMixGroup) 同期化完了
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
                //for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 1].Image = null;
                for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

				for (int i = 0; i < aGrd.RowCount; i++)
				{
					// 이미 이미지 세팅이 안된건에 한해서 작업수행
					//if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 1].Image == null)
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
					{
						//이미수행한건 빼는로직이 있어야함..
						int count = 0;
						for (int j = i; j < aGrd.RowCount; j++)
						{
							if (aGrd.GetItemValue(i, "input_gubun_text").ToString().Trim() == aGrd.GetItemValue(j, "input_gubun_text").ToString().Trim() &&
							// 동일 group_ser, 동일 mix_group
							    aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
								aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
								aGrd.GetItemValue(i, "hope_date").ToString().Trim() == aGrd.GetItemValue(j, "hope_date").ToString().Trim() &&
								aGrd.GetItemValue(i, "seq").ToString().Trim() == aGrd.GetItemValue(j, "seq").ToString().Trim())
							{
								count++;
								if (count > 1)
								{
									//      헤더를 빼야 실제 Row
									//aGrd[j + aGrd.HeaderHeights.Count, 1].Image = this.imageListMixGroup.Images[imageCnt];
									//aGrd[i + aGrd.HeaderHeights.Count, 1].Image = this.imageListMixGroup.Images[imageCnt];
                                    aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                    aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
								}
							}
						}
						// 현재는 image 갯수만큼 처리
						imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
					}
				}
			}
			finally
			{
				//aGrd.Redraw = true; // Grid Display 
			}

		}
		#endregion

		#region 환자번호가 입력이 됐을 때 同期化完了
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
            if (this.paBox.BunHo.ToString() != "")
            {
                /* 조회 */
                this.GetTuyaqkList();

                PostCallHelper.PostCall(new PostMethod(SetFocus));
            }
            
		}
		#endregion

		#region 조회 同期化完了
		private void GetTuyaqkList()
		{
			if(this.paBox.BunHo.ToString() != "")
            {
                this.grdNUR2017.SetBindVarValue("f_hosp_code"   , EnvironInfo.HospCode );
				//this.grdNUR2017.SetBindVarValue("f_order_date"  , this.order_date);
                this.grdNUR2017.SetBindVarValue("f_pkocs2003"   , this.pkocs2003);
                this.grdNUR2017.SetBindVarValue("f_bunho"       , this.paBox.BunHo.ToString());
                this.grdNUR2017.SetBindVarValue("f_order_gubun" , this.order_gubun);
                //this.grdNUR2017.SetBindVarValue("f_act_res_date", this.act_res_date);
                this.grdNUR2017.SetBindVarValue("f_act_res_date", this.dtpAct_Res_date.GetDataValue());
                this.grdNUR2017.SetBindVarValue("f_bannab_del", this.cbxBannab_del.GetDataValue());

				if(this.grdNUR2017.QueryLayout(false))
				{
					this.DisplayMixGroup(this.grdNUR2017);
					this.BannabDisplay(this.grdNUR2017);
                    PostCallHelper.PostCall(new PostMethod(SetFocus));
				}
				else
				{
					XMessageBox.Show(Service.ErrFullMsg.ToString());
					return;
				}

                //PostCallHelper.PostCall(new PostMethod(SetFocus));
			}
		}

        private void grdNUR2017_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //string cmdText = "";
            //string tFKOCS2003 = "";

//            for (int i = 0; i < grdNUR2017.RowCount; i++)
//            {
//                tFKOCS2003 = this.grdNUR2017.GetItemString(i, "bannab_fkocs2003");

//                /* 약국반납여부를 조회한다. */
//                if (tFKOCS2003 != "")
//                {
//                    cmdText = @"SELECT DECODE(A.ACTING_DATE, NULL, 'N', 'Y') DRUG_BANNAB_YN
//                                  FROM OCS2003 A
//                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                   AND A.PKOCS2003 = :f_bannab_fkocs2003";

//                    BindVarCollection bc = new BindVarCollection();
//                    bc.Add("f_hosp_code", EnvironInfo.HospCode);
//                    bc.Add("f_bannab_fkocs2003", tFKOCS2003);

//                    object drug_bannab_yn = Service.ExecuteScalar(cmdText, bc);
//                    if (!TypeCheck.IsNull(drug_bannab_yn))
//                    {
//                        this.grdNUR2017.SetItemValue(i, "drug_bannab_yn", drug_bannab_yn.ToString());
//                    }

//                }
//            }
//            this.grdNUR2017.ResetUpdate();
        }
        #endregion

        #region 버튼리스트에서 클릭을 했을 때 同期化完了2
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					/* 조회 */
					this.GetTuyaqkList();
					break;
				case FunctionType.Update:
                    e.IsBaseCall = false;

                    int updRow = 0;
                    for (int i = 0; i < grdNUR2017.RowCount; i++)
                    {
                        if (grdNUR2017.GetRowState(i) != DataRowState.Unchanged)
                        {
                            updRow++;
                        }
                    }

                    if (updRow > 0)
                    {
                        if (this.grdNUR2017.SaveLayout())
                        {
                            /* 조회 */
                            this.GetTuyaqkList();
                            this.GetMessage("save_true");
                            e.IsSuccess = true;
                        }
                        else
                        {
                            this.GetMessage("save_false");
                            e.IsSuccess = false;
                        }
                    }
					break;
				default:
					break;
			}
		}
		#endregion
		
		#region [간호확인사용자] 同期化完了
		private void txtConfirmUser_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			dbxConfirmUserName.SetDataValue("");
			this.user_id = "";

			if( TypeCheck.IsNull(e.DataValue) )
			{
				txtConfirmUser.SetDataValue("");
			}
			
			string user_nm = this.GetAdminUSER_NAME(e.DataValue);

            if (TypeCheck.IsNull(user_nm))
            {
                txtConfirmUser.SetDataValue("");
                txtConfirmUser.Focus();
                txtConfirmUser.SelectAll();
            }
            else
            {
                this.dbxConfirmUserName.SetDataValue(user_nm);
                this.user_id = this.txtConfirmUser.GetDataValue().ToString().Trim();
                this.grdNUR2017.Focus();
            }
        }

        #region [ユーザの名前を取得] 同期化完了
        private string GetAdminUSER_NAME(string aUser_id)
		{
			string user_name = "";

			this.layCommon.Reset();
			this.layCommon.QuerySQL = @"SELECT USER_NM
                                             , FN_PPE_LOAD_CONFIRM_ENABLE(USER_ID) CONFIRM_GRANT
                                          FROM ADM3200   
                                         WHERE HOSP_CODE = :f_hosp_code
                                           AND USER_ID   = :f_user_id";

            this.layCommon.LayoutItems.Clear();
            this.layCommon.LayoutItems.Add("user_name");
            this.layCommon.LayoutItems.Add("confirm_grant");

            this.layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layCommon.SetBindVarValue("f_user_id", aUser_id);
                    
			if(this.layCommon.QueryLayout())
			{
                if (layCommon.GetItemValue("confirm_grant").ToString() != "Y")
				{
					this.GetMessage("nurse_confirm_enable");
					return user_name;

				}
				user_name = this.layCommon.GetItemValue("user_name").ToString();				
			}

			return user_name;
        }
        #endregion

        private void btnClearConfirmUser_Click(object sender, System.EventArgs e)
		{
			txtConfirmUser.SetDataValue("");
			dbxConfirmUserName.SetDataValue("");
			this.user_id = "";
		}
		#endregion

		#region 날짜를 변경을 했을 때 同期化完了
        private void dtpAct_Res_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            //this.order_date = "";
            //this.order_date = this.dtpOrder_date.GetDataValue().ToString();
            this.act_res_date = "";
            this.act_res_date = this.dtpAct_Res_date.GetDataValue().ToString();
            this.acting_date = this.dtpAct_Res_date.GetDataValue().ToString();
            this.btnList.PerformClick(FunctionType.Query);
		}
		#endregion

		#region 믹스인 경우 시간을 입력을 하면 같이 변경 同期化完了
		private void grdNUR2017_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
            if(UserInfo.UserGubun == UserType.Nurse)
            {
                string ColNM = e.ColName;

                if (((ColNM != null) && (ColNM == "acting_time")) && (this.user_id.ToString() != ""))
                {
                    for (int i = 0; i < this.grdNUR2017.RowCount; i++)
                    {

                        if ((this.grdNUR2017.GetItemValue(e.RowNumber, "input_gubun_text").ToString() == this.grdNUR2017.GetItemValue(i, "input_gubun_text").ToString()) &&
                            (this.grdNUR2017.GetItemValue(e.RowNumber, "group_ser").ToString() == this.grdNUR2017.GetItemValue(i, "group_ser").ToString()) &&
                            (this.grdNUR2017.GetItemValue(e.RowNumber, "mix_group").ToString() == this.grdNUR2017.GetItemValue(i, "mix_group").ToString()) &&
                            this.grdNUR2017.GetItemValue(e.RowNumber, "mix_group").ToString() != "" &&
                            this.grdNUR2017.GetItemValue(i, "mix_group").ToString() != "" &&
                            (this.grdNUR2017.GetItemValue(e.RowNumber, "seq").ToString() == this.grdNUR2017.GetItemValue(i, "seq").ToString()))
                        {
                            //if (this.grdNUR2017.GetItemValue(e.RowNumber, "old_bannab_yn").ToString() != "Y")
                            this.grdNUR2017.SetItemValue(i, "acting_time", this.grdNUR2017.GetItemValue(e.RowNumber, "acting_time").ToString());
                            this.grdNUR2017.AcceptData();

                        }
                    }
                }
            }

            //switch(e.ColName)
            //{
            //    case "acting_time":
            //        if (this.user_id.ToString() != "")
            //        {
            //            for(int i = 0; i < this.grdNUR2017.RowCount; i++)
            //            {
            //                if( (this.grdNUR2017.GetItemValue(e.RowNumber, "input_gubun_text").ToString() == this.grdNUR2017.GetItemValue(i, "input_gubun_text").ToString()) &&
            //                    (this.grdNUR2017.GetItemValue(e.RowNumber, "group_ser").ToString() == this.grdNUR2017.GetItemValue(i, "group_ser").ToString()) &&
            //                    (this.grdNUR2017.GetItemValue(e.RowNumber, "mix_group").ToString() == this.grdNUR2017.GetItemValue(i, "mix_group").ToString()) &&
            //                    this.grdNUR2017.GetItemValue(e.RowNumber, "mix_group").ToString() != "" && 
            //                    this.grdNUR2017.GetItemValue(i, "mix_group").ToString() != "" &&
            //                    (this.grdNUR2017.GetItemValue(e.RowNumber, "seq").ToString() == this.grdNUR2017.GetItemValue(i, "seq").ToString()))
            //                {
            //                    //if (this.grdNUR2017.GetItemValue(e.RowNumber, "old_bannab_yn").ToString() != "Y")
            //                        this.grdNUR2017.SetItemValue(i, "acting_time", this.grdNUR2017.GetItemValue(e.RowNumber, "acting_time").ToString());
            //                        this.grdNUR2017.AcceptData();
                                
            //                }
            //            }
            //        }
            //        break;
            //    default:
            //        break;
            //}
		}
		#endregion

        #region 반납여부에 따라 화면에 프로텍트를 건다 同期化完了
        private void grdNUR2017_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            // 간호사가 반납지시한 경우는 실시 처리 못하도록 프로텍트 검.
            //if (e.DataRow["old_bannab_yn"].ToString() == "Y")
            //{
                //string currentColName = e.ColName;

                //if (currentColName != null)
                //{
                //    switch (e.ColName)
                //    {
                //        case "acting_date":
                //            e.Protect = true;
                //            break;
                //        case "acting_time":
                //            e.Protect = true;
                //            break;
                //        case "acting_yn":
                //            e.Protect = true;
                //            break;
                //        case "bannab_yn":
                //            e.Protect = false;
                //            break;
                //    }
                //}
                //else
                //    e.Protect = true;
            if(UserInfo.UserGubun == UserType.Nurse)
            {
                string currentColName = e.ColName;

                if (currentColName != null)
                {
                    if (!(currentColName == "bannab_yn"))
                    {
                        if (((currentColName == "acting_date") || (currentColName == "acting_time")) || (currentColName == "acting_yn") || (currentColName == "pass_yn"))
                        {
                            //if (e.DataRow["order_bannab_yn"].ToString() == "Y")
                            if (e.DataRow["order_dc_yn"].ToString() == "Y")
                            {
                                e.Protect = true;
                            }
                            else
                            {
                                e.Protect = false;
                            }
                        }
                    }
                    else if (e.DataRow["bannab_acting_yn"].ToString() == "Y")
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        e.Protect = false;
                    }
                }
             }
            //}

            //if (e.DataRow["drug_bannab_yn"].ToString() == "Y")
            //{
            //    e.Protect = true;
            //}

        }
		#endregion

		#region 반납 주체 이미지 표시 同期化完了2
		private void BannabDisplay(XEditGrid aGrd)
		{
			// 기존 image 클리어
			//delete by jc
            //for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 2].Image = null;
			
            
            //for (int i = 0; i < aGrd.RowCount; i++)
            //{
            //   // 의사 반납 지시
            //   if (aGrd.GetItemValue(i, "order_bannab_yn").ToString().Trim() == "Y")  
            //    {
            //        aGrd[i + aGrd.HeaderHeights.Count, 2].Image = this.ImageList.Images[2];
            //    }
            //    // 간호사 반납 실시
            //    else if (aGrd.GetItemValue(i, "old_bannab_yn").ToString().Trim() == "Y")
            //    {
            //        aGrd[i + aGrd.HeaderHeights.Count, 2].Image = this.ImageList.Images[3];
            //    }
            //}
            //for (int i = 0; i < aGrd.RowCount; i++)
            //{
            //    aGrd[i + aGrd.HeaderHeights.Count, 2].Image = null;
            //    //aGrd.[i + aGrd.HeaderHeights.Count, 2].Image = null;
            //}

		}
		#endregion	

        #region layBannab_yn_checek_QueryStarting 同期化完了
        private void layBannab_yn_check_QueryStarting(object sender, CancelEventArgs e)
        {
            layBannab_yn_check.SetBindVarValue("f_fkocs2003", grdNUR2017.GetItemString(grdNUR2017.CurrentRowNumber, "fkocs2003"));
        }
        #endregion

        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        {
            private NUR2017U01 parent;

            public XSavePerformer(NUR2017U01 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                string str2;

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch(callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:

                                //if (item.BindVarList["f_pass_yn"].VarValue == "Y")
                                //{

                                    cmdText = @"UPDATE OCS2003
                                                   SET UPD_ID               = :q_user_id
                                                     , UPD_DATE             = SYSDATE
                                                     , NURSE_PICKUP_USER    = :f_act_user
                                                     , NURSE_PICKUP_DATE    = TO_DATE(:f_act_res_date, 'YYYY/MM/DD')
                                                     , NURSE_PICKUP_TIME    = REPLACE(:f_acting_time, ':', '')
                                                 WHERE HOSP_CODE    = :f_hosp_code
                                                   AND PKOCS2003    = :f_fkocs2003
                                                   AND NURSE_PICKUP_USER IS NULL
                                                   AND NURSE_PICKUP_DATE IS NULL
                                                   AND NURSE_PICKUP_TIME IS NULL";

                                    Service.ExecuteNonQuery(cmdText, item.BindVarList);


//                                    if (item.BindVarList["f_jusa"].VarValue != "")
//                                    {
//                                        cmdText = @"UPDATE DRG3041 A
//                                                       SET A.ACTING_DATE = DECODE(:f_acting_yn, 'Y', TO_DATE(:f_acting_date, 'YYYY/MM/DD'), NULL)
//                                                         , A.ACTING_TIME = DECODE(:f_acting_yn, 'Y', REPLACE(:f_acting_time, ':', ''), NULL)
//                                                         , A.ACTING_ID   = DECODE(:f_acting_yn, 'Y', :f_act_user, NULL)
//                                                     WHERE A.HOSP_CODE  = :f_hosp_code
//                                                       AND A.JUBSU_DATE = :f_jubsu_date
//                                                       AND A.DRG_BUNHO  = :f_drg_bunho
//                                                       AND A.SERIAL_V   = :f_serial_v
//                                                       AND A.SEQ        = :f_seq";

//                                        Service.ExecuteNonQuery(cmdText, item.BindVarList);
//                                    }

                                    
                                    /* 투약기록을 입력한다. */
                                    cmdText = @"UPDATE OCS2017
                                                   SET UPD_ID       = :q_user_id
                                                     , UPD_DATE     = SYSDATE
                                                     , ACTING_DATE  = DECODE(:f_acting_yn, 'Y', TO_DATE(:f_acting_date, 'YYYY/MM/DD'), NULL)
                                                     , ACTING_TIME  = DECODE(:f_acting_yn, 'Y', REPLACE(:f_acting_time, ':', ''), NULL)
                                                     , ACT_USER     = DECODE(:f_acting_yn, 'Y', :f_act_user, NULL)
                                                     , PASS_DATE    = DECODE(:f_pass_yn, 'Y', TO_DATE(:f_acting_date, 'YYYY/MM/DD'), NULL)
                                                     , PASS_TIME    = DECODE(:f_pass_yn, 'Y', REPLACE(:f_acting_time, ':', ''), NULL)
                                                     , PASS_USER    = DECODE(:f_pass_yn, 'Y', :f_act_user, NULL)
                                                 WHERE HOSP_CODE    = :f_hosp_code
                                                   AND FKOCS2003    = :f_fkocs2003
                                                   AND ACT_RES_DATE   = TO_DATE(:f_act_res_date, 'YYYY/MM/DD')
                                                   AND HANGMOG_CODE = :f_hangmog_code
                                                   AND SEQ          = :f_seq";
//                                }
//                                else
//                                {
//                                    /* 투약기록을 취소한다. */
//                                    cmdText = @"UPDATE OCS2017
//                                                   SET UPD_ID       = :q_user_id
//                                                     , UPD_DATE     = SYSDATE
//                                                     , ACTING_DATE  = NULL
//                                                     , ACTING_TIME  = NULL
//                                                     , ACT_USER     = NULL
//                                                 WHERE HOSP_CODE    = :f_hosp_code
//                                                   AND FKOCS2003    = :f_fkocs2003
//                                                   AND ACT_RES_DATE   = TO_DATE(:f_act_res_date, 'YYYY/MM/DD')
//                                                   AND HANGMOG_CODE = :f_hangmog_code
//                                                   AND SEQ          = :f_seq";                                
//                                }

                                break;
                        }
                        break;

                    case '2' :

                        str2 = "";
                        cmdText = "";
                        if (item.BindVarList["f_bannab_yn"].VarValue != item.BindVarList["f_old_bannab_yn"].VarValue)
                        {
                            if (!(item.BindVarList["f_bannab_yn"].VarValue == "Y"))
                                str2 = "3";
                            else
                                str2 = "2";
                        }


                        //if (item.BindVarList["f_bannab_yn"].VarValue == "Y")
                        //{
                        //    item.BindVarList.Add("f_bannab_yn_insert", "B");
                        //}
                        //else
                        //{
                        //    item.BindVarList.Add("f_bannab_yn_insert", "C");
                        //}

                        //if (item.BindVarList["f_bannab_yn"].VarValue == "Y" 
                        //    ||(item.BindVarList["f_bannab_yn"].VarValue == "N" && item.BindVarList["f_old_bannab_yn"].VarValue == "Y"))
                        //{
                            ArrayList inputList = new ArrayList();
                            ArrayList outputList = new ArrayList();

                            inputList.Add(str2);
                            //inputList.Add(item.BindVarList["f_bannab_yn_insert"].VarValue); //i_bannab_yn_insert
                            inputList.Add(item.BindVarList["f_fkocs2003"].VarValue); //i_fkocs2003
                            inputList.Add(item.BindVarList["f_seq"].VarValue); //i_seq
                            //inputList.Add(item.BindVarList["f_bannab_fkocs2003"].VarValue); //i_bannab_fkocs2003
                            inputList.Add(item.BindVarList["q_user_id"].VarValue); //q_user_id

                            //if (!Service.ExecuteProcedure("PR_OCS_PART_BANNAB_ORDER_INP", inputList, outputList))
                            if (!Service.ExecuteProcedure("PR_OCSI_PROCESS_BANNAB", inputList, outputList))
                            {
                                //MessageBox.Show("処理に失敗しました。\r\n" + Service.ErrFullMsg, "処理失敗", MessageBoxIcon.Error);
                                parent.mErrMsg = Service.ErrFullMsg;
                                return false;
                            }

                            //if (!TypeCheck.IsNull(outputList) && outputList[1].ToString() != "0")
                            if (!TypeCheck.IsNull(outputList) && outputList[0].ToString() != "0")
                            {
                                //XMessageBox.Show("処理に失敗しました。\r\n" + outputList[0].ToString(), "処理失敗", MessageBoxIcon.Error);
                                parent.mErrMsg = outputList[0].ToString();
                                return false;
                            }

                            /* 투약기록을 취소한다. */
//                            cmdText = @"UPDATE OCS2017
//                                           SET UPD_DATE  = SYSDATE
//                                             , UPD_ID    = :q_user_id
//                                             , BANNAB_YN = NVL(:f_bannab_yn, 'N')
//                                         WHERE HOSP_CODE = :f_hosp_code 
//                                           AND FKOCS2003 = :f_fkocs2003
//                                           AND SEQ       = :f_seq";                     
                            
                        //}

                        break;
                }

                if(cmdText != "")
                    return Service.ExecuteNonQuery(cmdText, item.BindVarList);
                return true;
            }
        }
        #endregion 

        #region 반납처리 또는 반납취소처리 同期化完了2
        private string mErrMsg = "";
        private void btnBannab_Y_Click(object sender, EventArgs e)
        {
            try
            {
                mErrMsg = "";
                Service.BeginTransaction(); 

                this.grdNUR2017.CallerID = '2';
                if (!this.grdNUR2017.SaveLayout())
                    throw new Exception();

                this.grdNUR2017.CallerID = '1';
                Service.CommitTransaction(); 
            }
            catch
            {
                Service.RollbackTransaction(); 
                XMessageBox.Show("処理に失敗しました。\r\n" + mErrMsg, "処理失敗", MessageBoxIcon.Error);
            }

            int num = this.grdNUR2017.CurrentRowNumber;

            this.btnList.PerformClick(0);
            if (num < this.grdNUR2017.RowCount)
            {
                this.grdNUR2017.SetFocusToItem(num, 0);
            }

        }
        #endregion

        private void grdPalist_Click(object sender, EventArgs e)
        {
            if (grdPalist.CurrentRowNumber >= 0)
            {
                //환자번호 Set
                this.paBox.SetPatientID(grdPalist.GetItemValue(this.grdPalist.CurrentRowNumber, "bunho").ToString());
                this.paListRownum = grdPalist.CurrentRowNumber;
            }
        }

        private void cboHo_dong_SelectedIndexChanged(object sender, EventArgs e)
        {
            paListRownum = 0;
            grdPalist.QueryLayout(true);
        }

        private void grdPalist_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (grdPalist.RowCount == 0)
                return;

            this.grdPalist.UnSelectAll();
            paListRownum = -1;

            for (int i = 0; i < this.grdPalist.RowCount; i++)
            {
                if (this.grdPalist.GetItemString(i, "bunho") == paBox.BunHo)
                {
                    this.grdPalist.SelectRow(i);
                    grdPalist.SetFocusToItem(i, "bunho");
                    paListRownum = i;
                    break;
                }
            }

            if (paListRownum >= 0)
            {
                grdPalist.SelectRow(paListRownum);
                grdPalist.SetFocusToItem(paListRownum, "bunho");
            }
            else
            {
                XMessageBox.Show("投薬の対象ではありません。");
                grdNUR2017.Reset();
            }
        }

        private void grdPalist_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPalist.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdNUR2017.SetBindVarValue("f_order_date"  , this.order_date);
            this.grdPalist.SetBindVarValue("f_pkocs2003", this.pkocs2003);
            this.grdPalist.SetBindVarValue("f_bunho", this.paBox.BunHo.ToString());
            this.grdPalist.SetBindVarValue("f_order_gubun", this.order_gubun);
            //this.grdNUR2017.SetBindVarValue("f_act_res_date", this.act_res_date);
            this.grdPalist.SetBindVarValue("f_act_res_date", this.dtpAct_Res_date.GetDataValue());
            this.grdPalist.SetBindVarValue("f_ho_dong", this.cboHo_dong.GetDataValue());
            this.grdPalist.SetBindVarValue("f_a", cbxA.GetDataValue());
            this.grdPalist.SetBindVarValue("f_b", cbxB.GetDataValue());
            this.grdPalist.SetBindVarValue("f_c", cbxC.GetDataValue());
            this.grdPalist.SetBindVarValue("f_d", cbxD.GetDataValue());
        }

        private void btnNextPatient_Click(object sender, EventArgs e)
        {
            btnList.PerformClick(FunctionType.Update);

            int rownum = paListRownum + 1 < grdPalist.RowCount ? paListRownum + 1 : 0;

            paBox.SetPatientID(grdPalist.GetItemString(rownum, "bunho"));

            paListRownum = rownum;

            grdPalist.UnSelectAll();
            grdPalist.SelectRow(rownum);
            grdPalist.SetFocusToItem(rownum, "bunho");
            btnNextPatient.Focus();
        }

        private void cbxBannab_del_CheckedChanged(object sender, EventArgs e)
        {
            GetTuyaqkList();
        }

        private void btnBeforeDate_Click(object sender, EventArgs e)
        {
            dtpAct_Res_date.SetDataValue(DateTime.Parse(dtpAct_Res_date.GetDataValue()).AddDays(-1));
            dtpAct_Res_date.AcceptData();
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void btnAfterDate_Click(object sender, EventArgs e)
        {
            dtpAct_Res_date.SetDataValue(DateTime.Parse(dtpAct_Res_date.GetDataValue()).AddDays(1));
            dtpAct_Res_date.AcceptData();
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void cbxTeam_CheckedChanged(object sender, EventArgs e)
        {
            grdPalist.QueryLayout(false);
        }
    }
}


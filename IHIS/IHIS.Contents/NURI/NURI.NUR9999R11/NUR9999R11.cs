#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.Text;
#endregion

namespace IHIS.NURI
{
	/// <summary>
	/// OCS118U에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR9999R11 : IHIS.Framework.XScreen
	{
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel pnlRight;
		private IHIS.Framework.XFindWorker fwkNUR9999;
		private IHIS.Framework.FindColumnInfo findColumnInfo11;
        private IHIS.Framework.FindColumnInfo findColumnInfo12;
        private System.Windows.Forms.ToolTip toolTip;
        private XPanel xPanel3;
        private XEditGrid grdNUR9999;
        private GroupBox gbxInput;
        private XPanel pnlLeft;
        private XLabel xLabel24;
        private XLabel xLabel23;
        private XLabel xLabel22;
        private XLabel xLabel21;
        private XLabel xLabel20;
        private XLabel xLabel19;
        private XLabel xLabel17;
        private XLabel xLabel16;
        private XLabel xLabel15;
        private XLabel xLabel14;
        private XLabel xLabel13;
        private XLabel xLabel12;
        private XLabel xLabel11;
        private XLabel xLabel10;
        private XLabel xLabel9;
        private XLabel lblToiwon_date;
        private XLabel xLabel7;
        private XLabel xLabel6;
        private XLabel lblReason;
        private XLabel xLabel3;
        private XLabel xLabel2;
        private XLabel xLabel18;
        private XLabel xLabel29;
        private XLabel xLabel30;
        private XLabel xLabel27;
        private XLabel xLabel28;
        private XLabel xLabel26;
        private XLabel xLabel25;
        private XLabel xLabel35;
        private XLabel xLabel33;
        private XLabel xLabel34;
        private XLabel xLabel31;
        private XLabel xLabel32;
        private XDatePicker dtpToiwonDate;
        private XDatePicker dtpIpwonDate;
        private XTextBox txtTel;
        private XTextBox txtSangName;
        private XTextBox txtAddress;
        private XTextBox txtReason;
        private XTextBox txtContinueNursing;
        private XTextBox txtNursingPass;
        private XTextBox txtInpatientCourse;
        private XTextBox txtPastHis;
        private XTextBox txtTaboo;
        private XTextBox txtInfection;
        private XTextBox txtKey2Office;
        private XTextBox txtKey2Phone;
        private XTextBox txtKey2Home;
        private XTextBox txtKey1Office;
        private XTextBox txtKey1Phone;
        private XTextBox txtKey1Home;
        private XTextBox txtDoctor;
        private XTextBox txtGwa;
        private XTextBox txtSuname;
        private XTextBox txtHodong;
        private XDictComboBox cboFoodADL;
        private XTextBox txtComments;
        private XTextBox txtTube;
        private XTextBox txtSleep;
        private XTextBox txtExcretion;
        private XTextBox txtWash;
        private XTextBox txtFood;
        private XDatePicker dtpBirth;
        private XDictComboBox cboWareADL;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell32;
        private XPanel pnlTop;
        private XPatientBox paBox;
        private XLabel xLabel36;
        private XDictComboBox cboPkInp1001;
        private XDictComboBox cboGubun;
        private XLabel xLabel37;
        private XDatePicker dtpWriteDate;
        private XLabel xLabel38;
        private XTextBox txtMoveAdlCmt;
        private XTextBox txtExcretionAdlCmt;
        private XTextBox txtFoodAdlCmt;
        private XTextBox txtWareAdlCmt;
        private XTextBox txtWashAdlCmt;
        private XTextBox txtBunho;
        private XDictComboBox cboCommunication;
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
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell44;
        private XLabel xLabel42;
        private XLabel xLabel43;
        private XLabel xLabel44;
        private XLabel xLabel41;
        private XLabel xLabel40;
        private XLabel xLabel39;
        private SingleLayout layPaInfo;
        private XTextBox txtLeaderNurse;
        private XTextBox txtDamdangNurse;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private SingleLayoutItem singleLayoutItem7;
        private SingleLayoutItem singleLayoutItem8;
        private SingleLayoutItem singleLayoutItem9;
        private SingleLayoutItem singleLayoutItem10;
        private SingleLayoutItem singleLayoutItem12;
        private SingleLayoutItem singleLayoutItem13;
        private SingleLayoutItem singleLayoutItem14;
        private SingleLayoutItem singleLayoutItem15;
        private SingleLayoutItem singleLayoutItem16;
        private SingleLayoutItem singleLayoutItem17;
        private SingleLayoutItem singleLayoutItem18;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
        private XTextBox txtKey2Relation;
        private XLabel xLabel46;
        private XTextBox txtKey1Relation;
        private XLabel xLabel45;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private XLabel xLabel5;
        private XTextBox txtAge;
        private XEditGridCell xEditGridCell52;
        private SingleLayoutItem singleLayoutItem19;
        private SingleLayoutItem singleLayoutItem6;
        private XDictComboBox cboMoveADL;
        private XDictComboBox cboMove;
        private XDictComboBox cboExcretionADL;
        private XDictComboBox cboWashADL;
        private XTextBox txtPknur9999;
        private SingleLayoutItem singleLayoutItem11;
		private System.ComponentModel.IContainer components;

        
        public NUR9999R11()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            this.SaveLayoutList.Add(this.grdNUR9999);
            this.grdNUR9999.SavePerformer = new XSavePerformer(this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR9999R11));
            this.btnList = new IHIS.Framework.XButtonList();
            this.fwkNUR9999 = new IHIS.Framework.XFindWorker();
            this.findColumnInfo11 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo12 = new IHIS.Framework.FindColumnInfo();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.gbxInput = new System.Windows.Forms.GroupBox();
            this.txtPknur9999 = new IHIS.Framework.XTextBox();
            this.cboMoveADL = new IHIS.Framework.XDictComboBox();
            this.cboMove = new IHIS.Framework.XDictComboBox();
            this.cboExcretionADL = new IHIS.Framework.XDictComboBox();
            this.cboWashADL = new IHIS.Framework.XDictComboBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.txtAge = new IHIS.Framework.XTextBox();
            this.txtKey2Relation = new IHIS.Framework.XTextBox();
            this.xLabel46 = new IHIS.Framework.XLabel();
            this.txtKey1Relation = new IHIS.Framework.XTextBox();
            this.xLabel45 = new IHIS.Framework.XLabel();
            this.txtLeaderNurse = new IHIS.Framework.XTextBox();
            this.txtDamdangNurse = new IHIS.Framework.XTextBox();
            this.txtKey1Home = new IHIS.Framework.XTextBox();
            this.txtKey1Phone = new IHIS.Framework.XTextBox();
            this.txtKey1Office = new IHIS.Framework.XTextBox();
            this.txtKey2Office = new IHIS.Framework.XTextBox();
            this.txtKey2Phone = new IHIS.Framework.XTextBox();
            this.txtKey2Home = new IHIS.Framework.XTextBox();
            this.xLabel42 = new IHIS.Framework.XLabel();
            this.xLabel43 = new IHIS.Framework.XLabel();
            this.xLabel44 = new IHIS.Framework.XLabel();
            this.xLabel41 = new IHIS.Framework.XLabel();
            this.xLabel40 = new IHIS.Framework.XLabel();
            this.xLabel39 = new IHIS.Framework.XLabel();
            this.cboCommunication = new IHIS.Framework.XDictComboBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.lblToiwon_date = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.txtBunho = new IHIS.Framework.XTextBox();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.txtWareAdlCmt = new IHIS.Framework.XTextBox();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.txtWashAdlCmt = new IHIS.Framework.XTextBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.txtMoveAdlCmt = new IHIS.Framework.XTextBox();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.txtExcretionAdlCmt = new IHIS.Framework.XTextBox();
            this.dtpIpwonDate = new IHIS.Framework.XDatePicker();
            this.txtFoodAdlCmt = new IHIS.Framework.XTextBox();
            this.dtpToiwonDate = new IHIS.Framework.XDatePicker();
            this.dtpWriteDate = new IHIS.Framework.XDatePicker();
            this.txtTel = new IHIS.Framework.XTextBox();
            this.xLabel38 = new IHIS.Framework.XLabel();
            this.txtHodong = new IHIS.Framework.XTextBox();
            this.cboGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel37 = new IHIS.Framework.XLabel();
            this.cboWareADL = new IHIS.Framework.XDictComboBox();
            this.dtpBirth = new IHIS.Framework.XDatePicker();
            this.cboFoodADL = new IHIS.Framework.XDictComboBox();
            this.txtComments = new IHIS.Framework.XTextBox();
            this.txtTube = new IHIS.Framework.XTextBox();
            this.txtSleep = new IHIS.Framework.XTextBox();
            this.txtExcretion = new IHIS.Framework.XTextBox();
            this.txtWash = new IHIS.Framework.XTextBox();
            this.txtFood = new IHIS.Framework.XTextBox();
            this.txtContinueNursing = new IHIS.Framework.XTextBox();
            this.txtNursingPass = new IHIS.Framework.XTextBox();
            this.txtInpatientCourse = new IHIS.Framework.XTextBox();
            this.txtPastHis = new IHIS.Framework.XTextBox();
            this.txtTaboo = new IHIS.Framework.XTextBox();
            this.txtInfection = new IHIS.Framework.XTextBox();
            this.txtDoctor = new IHIS.Framework.XTextBox();
            this.txtGwa = new IHIS.Framework.XTextBox();
            this.txtSuname = new IHIS.Framework.XTextBox();
            this.txtSangName = new IHIS.Framework.XTextBox();
            this.txtAddress = new IHIS.Framework.XTextBox();
            this.txtReason = new IHIS.Framework.XTextBox();
            this.xLabel35 = new IHIS.Framework.XLabel();
            this.xLabel33 = new IHIS.Framework.XLabel();
            this.xLabel34 = new IHIS.Framework.XLabel();
            this.xLabel31 = new IHIS.Framework.XLabel();
            this.xLabel32 = new IHIS.Framework.XLabel();
            this.xLabel29 = new IHIS.Framework.XLabel();
            this.xLabel30 = new IHIS.Framework.XLabel();
            this.xLabel27 = new IHIS.Framework.XLabel();
            this.xLabel28 = new IHIS.Framework.XLabel();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.xLabel25 = new IHIS.Framework.XLabel();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.xLabel23 = new IHIS.Framework.XLabel();
            this.xLabel22 = new IHIS.Framework.XLabel();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.lblReason = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdNUR9999 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.cboPkInp1001 = new IHIS.Framework.XDictComboBox();
            this.layPaInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem10 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem12 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem13 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem14 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem15 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem16 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem17 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem18 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem19 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem11 = new IHIS.Framework.SingleLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.gbxInput.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR9999)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "선택.ICO");
            this.ImageList.Images.SetKeyName(1, "미선택.ICO");
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(496, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(487, 32);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // fwkNUR9999
            // 
            this.fwkNUR9999.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo11,
            this.findColumnInfo12});
            this.fwkNUR9999.FormText = "撮影区分照会";
            this.fwkNUR9999.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkNUR9999.ServerFilter = true;
            // 
            // findColumnInfo11
            // 
            this.findColumnInfo11.ColName = "code";
            this.findColumnInfo11.ColWidth = 131;
            this.findColumnInfo11.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo11.HeaderText = "촬영구분코드";
            // 
            // findColumnInfo12
            // 
            this.findColumnInfo12.ColName = "name";
            this.findColumnInfo12.ColWidth = 269;
            this.findColumnInfo12.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo12.HeaderText = "촬영구분명";
            // 
            // pnlRight
            // 
            this.pnlRight.AutoScroll = true;
            this.pnlRight.Controls.Add(this.gbxInput);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(308, 47);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pnlRight.Size = new System.Drawing.Size(680, 636);
            this.pnlRight.TabIndex = 2;
            // 
            // gbxInput
            // 
            this.gbxInput.Controls.Add(this.txtPknur9999);
            this.gbxInput.Controls.Add(this.cboMoveADL);
            this.gbxInput.Controls.Add(this.cboMove);
            this.gbxInput.Controls.Add(this.cboExcretionADL);
            this.gbxInput.Controls.Add(this.cboWashADL);
            this.gbxInput.Controls.Add(this.xLabel5);
            this.gbxInput.Controls.Add(this.txtAge);
            this.gbxInput.Controls.Add(this.txtKey2Relation);
            this.gbxInput.Controls.Add(this.xLabel46);
            this.gbxInput.Controls.Add(this.txtKey1Relation);
            this.gbxInput.Controls.Add(this.xLabel45);
            this.gbxInput.Controls.Add(this.txtLeaderNurse);
            this.gbxInput.Controls.Add(this.txtDamdangNurse);
            this.gbxInput.Controls.Add(this.txtKey1Home);
            this.gbxInput.Controls.Add(this.txtKey1Phone);
            this.gbxInput.Controls.Add(this.txtKey1Office);
            this.gbxInput.Controls.Add(this.txtKey2Office);
            this.gbxInput.Controls.Add(this.txtKey2Phone);
            this.gbxInput.Controls.Add(this.txtKey2Home);
            this.gbxInput.Controls.Add(this.xLabel42);
            this.gbxInput.Controls.Add(this.xLabel43);
            this.gbxInput.Controls.Add(this.xLabel44);
            this.gbxInput.Controls.Add(this.xLabel41);
            this.gbxInput.Controls.Add(this.xLabel40);
            this.gbxInput.Controls.Add(this.xLabel39);
            this.gbxInput.Controls.Add(this.cboCommunication);
            this.gbxInput.Controls.Add(this.xLabel7);
            this.gbxInput.Controls.Add(this.lblToiwon_date);
            this.gbxInput.Controls.Add(this.xLabel9);
            this.gbxInput.Controls.Add(this.txtBunho);
            this.gbxInput.Controls.Add(this.xLabel10);
            this.gbxInput.Controls.Add(this.txtWareAdlCmt);
            this.gbxInput.Controls.Add(this.xLabel11);
            this.gbxInput.Controls.Add(this.txtWashAdlCmt);
            this.gbxInput.Controls.Add(this.xLabel12);
            this.gbxInput.Controls.Add(this.txtMoveAdlCmt);
            this.gbxInput.Controls.Add(this.xLabel13);
            this.gbxInput.Controls.Add(this.txtExcretionAdlCmt);
            this.gbxInput.Controls.Add(this.dtpIpwonDate);
            this.gbxInput.Controls.Add(this.txtFoodAdlCmt);
            this.gbxInput.Controls.Add(this.dtpToiwonDate);
            this.gbxInput.Controls.Add(this.dtpWriteDate);
            this.gbxInput.Controls.Add(this.txtTel);
            this.gbxInput.Controls.Add(this.xLabel38);
            this.gbxInput.Controls.Add(this.txtHodong);
            this.gbxInput.Controls.Add(this.cboGubun);
            this.gbxInput.Controls.Add(this.xLabel37);
            this.gbxInput.Controls.Add(this.cboWareADL);
            this.gbxInput.Controls.Add(this.dtpBirth);
            this.gbxInput.Controls.Add(this.cboFoodADL);
            this.gbxInput.Controls.Add(this.txtComments);
            this.gbxInput.Controls.Add(this.txtTube);
            this.gbxInput.Controls.Add(this.txtSleep);
            this.gbxInput.Controls.Add(this.txtExcretion);
            this.gbxInput.Controls.Add(this.txtWash);
            this.gbxInput.Controls.Add(this.txtFood);
            this.gbxInput.Controls.Add(this.txtContinueNursing);
            this.gbxInput.Controls.Add(this.txtNursingPass);
            this.gbxInput.Controls.Add(this.txtInpatientCourse);
            this.gbxInput.Controls.Add(this.txtPastHis);
            this.gbxInput.Controls.Add(this.txtTaboo);
            this.gbxInput.Controls.Add(this.txtInfection);
            this.gbxInput.Controls.Add(this.txtDoctor);
            this.gbxInput.Controls.Add(this.txtGwa);
            this.gbxInput.Controls.Add(this.txtSuname);
            this.gbxInput.Controls.Add(this.txtSangName);
            this.gbxInput.Controls.Add(this.txtAddress);
            this.gbxInput.Controls.Add(this.txtReason);
            this.gbxInput.Controls.Add(this.xLabel35);
            this.gbxInput.Controls.Add(this.xLabel33);
            this.gbxInput.Controls.Add(this.xLabel34);
            this.gbxInput.Controls.Add(this.xLabel31);
            this.gbxInput.Controls.Add(this.xLabel32);
            this.gbxInput.Controls.Add(this.xLabel29);
            this.gbxInput.Controls.Add(this.xLabel30);
            this.gbxInput.Controls.Add(this.xLabel27);
            this.gbxInput.Controls.Add(this.xLabel28);
            this.gbxInput.Controls.Add(this.xLabel26);
            this.gbxInput.Controls.Add(this.xLabel25);
            this.gbxInput.Controls.Add(this.xLabel24);
            this.gbxInput.Controls.Add(this.xLabel23);
            this.gbxInput.Controls.Add(this.xLabel22);
            this.gbxInput.Controls.Add(this.xLabel21);
            this.gbxInput.Controls.Add(this.xLabel20);
            this.gbxInput.Controls.Add(this.xLabel19);
            this.gbxInput.Controls.Add(this.xLabel17);
            this.gbxInput.Controls.Add(this.xLabel16);
            this.gbxInput.Controls.Add(this.xLabel15);
            this.gbxInput.Controls.Add(this.xLabel14);
            this.gbxInput.Controls.Add(this.xLabel6);
            this.gbxInput.Controls.Add(this.lblReason);
            this.gbxInput.Controls.Add(this.xLabel3);
            this.gbxInput.Controls.Add(this.xLabel2);
            this.gbxInput.Controls.Add(this.xLabel18);
            this.gbxInput.Enabled = false;
            this.gbxInput.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxInput.Location = new System.Drawing.Point(6, 3);
            this.gbxInput.Name = "gbxInput";
            this.gbxInput.Size = new System.Drawing.Size(652, 1010);
            this.gbxInput.TabIndex = 0;
            this.gbxInput.TabStop = false;
            // 
            // txtPknur9999
            // 
            this.txtPknur9999.Location = new System.Drawing.Point(66, 27);
            this.txtPknur9999.Name = "txtPknur9999";
            this.txtPknur9999.Size = new System.Drawing.Size(100, 20);
            this.txtPknur9999.TabIndex = 128;
            this.txtPknur9999.Tag = "pknur9999";
            this.txtPknur9999.Visible = false;
            // 
            // cboMoveADL
            // 
            this.cboMoveADL.Location = new System.Drawing.Point(117, 791);
            this.cboMoveADL.Name = "cboMoveADL";
            this.cboMoveADL.Size = new System.Drawing.Size(100, 21);
            this.cboMoveADL.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboMoveADL.TabIndex = 38;
            this.cboMoveADL.Tag = "move_adl";
            this.cboMoveADL.UserSQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n  FROM NUR0102 A \r\n WHERE A.HOSP_CODE= FN_ADM_" +
                "LOAD_HOSP_CODE()\r\n   AND A.CODE_TYPE = \'SUMMARY_ADL\'\r\n ORDER BY A.SORT_KEY, A.CO" +
                "DE";
            this.cboMoveADL.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // cboMove
            // 
            this.cboMove.Location = new System.Drawing.Point(117, 765);
            this.cboMove.Name = "cboMove";
            this.cboMove.Size = new System.Drawing.Size(210, 21);
            this.cboMove.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboMove.TabIndex = 37;
            this.cboMove.Tag = "move";
            this.cboMove.UserSQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n  FROM NUR0102 A \r\n WHERE A.HOSP_CODE= FN_ADM_" +
                "LOAD_HOSP_CODE()\r\n   AND A.CODE_TYPE = \'SUMMARY_MOVE_WAY\'\r\n ORDER BY A.SORT_KEY," +
                " A.CODE";
            this.cboMove.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // cboExcretionADL
            // 
            this.cboExcretionADL.Location = new System.Drawing.Point(117, 736);
            this.cboExcretionADL.Name = "cboExcretionADL";
            this.cboExcretionADL.Size = new System.Drawing.Size(100, 21);
            this.cboExcretionADL.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboExcretionADL.TabIndex = 35;
            this.cboExcretionADL.Tag = "excretion_adl";
            this.cboExcretionADL.UserSQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n  FROM NUR0102 A \r\n WHERE A.HOSP_CODE= FN_ADM_" +
                "LOAD_HOSP_CODE()\r\n   AND A.CODE_TYPE = \'SUMMARY_ADL\'\r\n ORDER BY A.SORT_KEY, A.CO" +
                "DE";
            this.cboExcretionADL.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // cboWashADL
            // 
            this.cboWashADL.Location = new System.Drawing.Point(436, 684);
            this.cboWashADL.Name = "cboWashADL";
            this.cboWashADL.Size = new System.Drawing.Size(100, 21);
            this.cboWashADL.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboWashADL.TabIndex = 41;
            this.cboWashADL.Tag = "wash_adl";
            this.cboWashADL.UserSQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n  FROM NUR0102 A \r\n WHERE A.HOSP_CODE= FN_ADM_" +
                "LOAD_HOSP_CODE()\r\n   AND A.CODE_TYPE = \'SUMMARY_ADL\'\r\n ORDER BY A.SORT_KEY, A.CO" +
                "DE";
            this.cboWashADL.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Location = new System.Drawing.Point(223, 93);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(42, 20);
            this.xLabel5.TabIndex = 127;
            this.xLabel5.Text = "年齢";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAge
            // 
            this.txtAge.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtAge.Location = new System.Drawing.Point(268, 93);
            this.txtAge.MaxLength = 3;
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(60, 20);
            this.txtAge.TabIndex = 5;
            this.txtAge.Tag = "age";
            this.txtAge.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtKey2Relation
            // 
            this.txtKey2Relation.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKey2Relation.Location = new System.Drawing.Point(466, 311);
            this.txtKey2Relation.MaxLength = 40;
            this.txtKey2Relation.Name = "txtKey2Relation";
            this.txtKey2Relation.Size = new System.Drawing.Size(182, 20);
            this.txtKey2Relation.TabIndex = 22;
            this.txtKey2Relation.Tag = "key2_relation";
            this.txtKey2Relation.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // xLabel46
            // 
            this.xLabel46.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel46.Location = new System.Drawing.Point(433, 311);
            this.xLabel46.Margin = new System.Windows.Forms.Padding(0);
            this.xLabel46.Name = "xLabel46";
            this.xLabel46.Size = new System.Drawing.Size(36, 20);
            this.xLabel46.TabIndex = 125;
            this.xLabel46.Text = "関係";
            // 
            // txtKey1Relation
            // 
            this.txtKey1Relation.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtKey1Relation.Location = new System.Drawing.Point(466, 222);
            this.txtKey1Relation.MaxLength = 40;
            this.txtKey1Relation.Name = "txtKey1Relation";
            this.txtKey1Relation.Size = new System.Drawing.Size(182, 20);
            this.txtKey1Relation.TabIndex = 18;
            this.txtKey1Relation.Tag = "key1_relation";
            this.txtKey1Relation.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // xLabel45
            // 
            this.xLabel45.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel45.Location = new System.Drawing.Point(433, 222);
            this.xLabel45.Margin = new System.Windows.Forms.Padding(0);
            this.xLabel45.Name = "xLabel45";
            this.xLabel45.Size = new System.Drawing.Size(36, 20);
            this.xLabel45.TabIndex = 123;
            this.xLabel45.Text = "関係";
            // 
            // txtLeaderNurse
            // 
            this.txtLeaderNurse.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtLeaderNurse.Location = new System.Drawing.Point(437, 170);
            this.txtLeaderNurse.MaxLength = 40;
            this.txtLeaderNurse.Name = "txtLeaderNurse";
            this.txtLeaderNurse.Size = new System.Drawing.Size(100, 20);
            this.txtLeaderNurse.TabIndex = 16;
            this.txtLeaderNurse.Tag = "leader_nurse";
            this.txtLeaderNurse.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtDamdangNurse
            // 
            this.txtDamdangNurse.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtDamdangNurse.Location = new System.Drawing.Point(437, 144);
            this.txtDamdangNurse.MaxLength = 40;
            this.txtDamdangNurse.Name = "txtDamdangNurse";
            this.txtDamdangNurse.Size = new System.Drawing.Size(100, 20);
            this.txtDamdangNurse.TabIndex = 15;
            this.txtDamdangNurse.Tag = "damdang_nurse";
            this.txtDamdangNurse.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtKey1Home
            // 
            this.txtKey1Home.Location = new System.Drawing.Point(466, 243);
            this.txtKey1Home.MaxLength = 40;
            this.txtKey1Home.Name = "txtKey1Home";
            this.txtKey1Home.Size = new System.Drawing.Size(182, 20);
            this.txtKey1Home.TabIndex = 19;
            this.txtKey1Home.Tag = "key1_home";
            this.txtKey1Home.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtKey1Phone
            // 
            this.txtKey1Phone.Location = new System.Drawing.Point(466, 264);
            this.txtKey1Phone.MaxLength = 40;
            this.txtKey1Phone.Name = "txtKey1Phone";
            this.txtKey1Phone.Size = new System.Drawing.Size(182, 20);
            this.txtKey1Phone.TabIndex = 20;
            this.txtKey1Phone.Tag = "key1_phone";
            this.txtKey1Phone.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtKey1Office
            // 
            this.txtKey1Office.Location = new System.Drawing.Point(466, 285);
            this.txtKey1Office.MaxLength = 40;
            this.txtKey1Office.Name = "txtKey1Office";
            this.txtKey1Office.Size = new System.Drawing.Size(182, 20);
            this.txtKey1Office.TabIndex = 21;
            this.txtKey1Office.Tag = "key1_office";
            this.txtKey1Office.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtKey2Office
            // 
            this.txtKey2Office.Location = new System.Drawing.Point(466, 374);
            this.txtKey2Office.MaxLength = 40;
            this.txtKey2Office.Name = "txtKey2Office";
            this.txtKey2Office.Size = new System.Drawing.Size(182, 20);
            this.txtKey2Office.TabIndex = 25;
            this.txtKey2Office.Tag = "key2_office";
            this.txtKey2Office.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtKey2Phone
            // 
            this.txtKey2Phone.Location = new System.Drawing.Point(466, 353);
            this.txtKey2Phone.MaxLength = 40;
            this.txtKey2Phone.Name = "txtKey2Phone";
            this.txtKey2Phone.Size = new System.Drawing.Size(182, 20);
            this.txtKey2Phone.TabIndex = 24;
            this.txtKey2Phone.Tag = "key2_phone";
            this.txtKey2Phone.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtKey2Home
            // 
            this.txtKey2Home.Location = new System.Drawing.Point(466, 332);
            this.txtKey2Home.MaxLength = 40;
            this.txtKey2Home.Name = "txtKey2Home";
            this.txtKey2Home.Size = new System.Drawing.Size(182, 20);
            this.txtKey2Home.TabIndex = 23;
            this.txtKey2Home.Tag = "key2_home";
            this.txtKey2Home.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // xLabel42
            // 
            this.xLabel42.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel42.Location = new System.Drawing.Point(433, 374);
            this.xLabel42.Margin = new System.Windows.Forms.Padding(0);
            this.xLabel42.Name = "xLabel42";
            this.xLabel42.Size = new System.Drawing.Size(36, 20);
            this.xLabel42.TabIndex = 119;
            this.xLabel42.Text = "勤務";
            // 
            // xLabel43
            // 
            this.xLabel43.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel43.Location = new System.Drawing.Point(433, 352);
            this.xLabel43.Margin = new System.Windows.Forms.Padding(0);
            this.xLabel43.Name = "xLabel43";
            this.xLabel43.Size = new System.Drawing.Size(36, 20);
            this.xLabel43.TabIndex = 118;
            this.xLabel43.Text = "携帯";
            // 
            // xLabel44
            // 
            this.xLabel44.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel44.Location = new System.Drawing.Point(433, 332);
            this.xLabel44.Margin = new System.Windows.Forms.Padding(0);
            this.xLabel44.Name = "xLabel44";
            this.xLabel44.Size = new System.Drawing.Size(36, 20);
            this.xLabel44.TabIndex = 117;
            this.xLabel44.Text = "自宅";
            // 
            // xLabel41
            // 
            this.xLabel41.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel41.Location = new System.Drawing.Point(433, 285);
            this.xLabel41.Margin = new System.Windows.Forms.Padding(0);
            this.xLabel41.Name = "xLabel41";
            this.xLabel41.Size = new System.Drawing.Size(36, 20);
            this.xLabel41.TabIndex = 116;
            this.xLabel41.Text = "勤務";
            // 
            // xLabel40
            // 
            this.xLabel40.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel40.Location = new System.Drawing.Point(433, 263);
            this.xLabel40.Margin = new System.Windows.Forms.Padding(0);
            this.xLabel40.Name = "xLabel40";
            this.xLabel40.Size = new System.Drawing.Size(36, 20);
            this.xLabel40.TabIndex = 115;
            this.xLabel40.Text = "携帯";
            // 
            // xLabel39
            // 
            this.xLabel39.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel39.Location = new System.Drawing.Point(433, 243);
            this.xLabel39.Margin = new System.Windows.Forms.Padding(0);
            this.xLabel39.Name = "xLabel39";
            this.xLabel39.Size = new System.Drawing.Size(36, 20);
            this.xLabel39.TabIndex = 114;
            this.xLabel39.Text = "自宅";
            // 
            // cboCommunication
            // 
            this.cboCommunication.Location = new System.Drawing.Point(436, 737);
            this.cboCommunication.Name = "cboCommunication";
            this.cboCommunication.Size = new System.Drawing.Size(211, 21);
            this.cboCommunication.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboCommunication.TabIndex = 45;
            this.cboCommunication.Tag = "communication";
            this.cboCommunication.UserSQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n  FROM NUR0102 A \r\n WHERE A.HOSP_CODE= FN_ADM_" +
                "LOAD_HOSP_CODE()\r\n   AND A.CODE_TYPE = \'COMMUNICATION_ADL\'\r\n ORDER BY A.SORT_KEY" +
                ", A.CODE";
            this.cboCommunication.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.Location = new System.Drawing.Point(333, 66);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(97, 20);
            this.xLabel7.TabIndex = 21;
            this.xLabel7.Text = "入院年月日";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToiwon_date
            // 
            this.lblToiwon_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblToiwon_date.EdgeRounding = false;
            this.lblToiwon_date.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblToiwon_date.Location = new System.Drawing.Point(333, 92);
            this.lblToiwon_date.Name = "lblToiwon_date";
            this.lblToiwon_date.Size = new System.Drawing.Size(97, 20);
            this.lblToiwon_date.TabIndex = 22;
            this.lblToiwon_date.Text = "退院年月日";
            this.lblToiwon_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel9.Location = new System.Drawing.Point(333, 118);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(97, 20);
            this.xLabel9.TabIndex = 23;
            this.xLabel9.Text = "病　　棟　　名";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBunho
            // 
            this.txtBunho.Location = new System.Drawing.Point(117, 66);
            this.txtBunho.Name = "txtBunho";
            this.txtBunho.ReadOnly = true;
            this.txtBunho.Size = new System.Drawing.Size(80, 20);
            this.txtBunho.TabIndex = 2;
            this.txtBunho.TabStop = false;
            this.txtBunho.Tag = "bunho";
            this.txtBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // xLabel10
            // 
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel10.Location = new System.Drawing.Point(333, 144);
            this.xLabel10.Name = "xLabel10";
            this.xLabel10.Size = new System.Drawing.Size(97, 20);
            this.xLabel10.TabIndex = 24;
            this.xLabel10.Text = "担当看護師";
            this.xLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWareAdlCmt
            // 
            this.txtWareAdlCmt.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtWareAdlCmt.Location = new System.Drawing.Point(538, 711);
            this.txtWareAdlCmt.MaxLength = 28;
            this.txtWareAdlCmt.Name = "txtWareAdlCmt";
            this.txtWareAdlCmt.Size = new System.Drawing.Size(109, 20);
            this.txtWareAdlCmt.TabIndex = 44;
            this.txtWareAdlCmt.Tag = "ware_adl_cmt";
            this.txtWareAdlCmt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // xLabel11
            // 
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel11.Location = new System.Drawing.Point(333, 170);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(97, 20);
            this.xLabel11.TabIndex = 25;
            this.xLabel11.Text = "師　　　　長";
            this.xLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWashAdlCmt
            // 
            this.txtWashAdlCmt.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtWashAdlCmt.Location = new System.Drawing.Point(538, 685);
            this.txtWashAdlCmt.MaxLength = 28;
            this.txtWashAdlCmt.Name = "txtWashAdlCmt";
            this.txtWashAdlCmt.Size = new System.Drawing.Size(109, 20);
            this.txtWashAdlCmt.TabIndex = 42;
            this.txtWashAdlCmt.Tag = "wash_adl_cmt";
            this.txtWashAdlCmt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // xLabel12
            // 
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel12.Location = new System.Drawing.Point(333, 196);
            this.xLabel12.Name = "xLabel12";
            this.xLabel12.Size = new System.Drawing.Size(97, 20);
            this.xLabel12.TabIndex = 26;
            this.xLabel12.Text = "電　話　番　号";
            this.xLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMoveAdlCmt
            // 
            this.txtMoveAdlCmt.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtMoveAdlCmt.Location = new System.Drawing.Point(219, 792);
            this.txtMoveAdlCmt.MaxLength = 28;
            this.txtMoveAdlCmt.Name = "txtMoveAdlCmt";
            this.txtMoveAdlCmt.Size = new System.Drawing.Size(107, 20);
            this.txtMoveAdlCmt.TabIndex = 39;
            this.txtMoveAdlCmt.Tag = "move_adl_cmt";
            this.txtMoveAdlCmt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // xLabel13
            // 
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel13.Location = new System.Drawing.Point(333, 222);
            this.xLabel13.Name = "xLabel13";
            this.xLabel13.Size = new System.Drawing.Size(97, 83);
            this.xLabel13.TabIndex = 27;
            this.xLabel13.Text = "連　絡　先　１";
            this.xLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtExcretionAdlCmt
            // 
            this.txtExcretionAdlCmt.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtExcretionAdlCmt.Location = new System.Drawing.Point(219, 737);
            this.txtExcretionAdlCmt.MaxLength = 28;
            this.txtExcretionAdlCmt.Name = "txtExcretionAdlCmt";
            this.txtExcretionAdlCmt.Size = new System.Drawing.Size(107, 20);
            this.txtExcretionAdlCmt.TabIndex = 36;
            this.txtExcretionAdlCmt.Tag = "excretion_adl_cmt";
            this.txtExcretionAdlCmt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // dtpIpwonDate
            // 
            this.dtpIpwonDate.Location = new System.Drawing.Point(437, 66);
            this.dtpIpwonDate.Name = "dtpIpwonDate";
            this.dtpIpwonDate.Size = new System.Drawing.Size(100, 20);
            this.dtpIpwonDate.TabIndex = 12;
            this.dtpIpwonDate.Tag = "ipwon_date";
            this.dtpIpwonDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtFoodAdlCmt
            // 
            this.txtFoodAdlCmt.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtFoodAdlCmt.Location = new System.Drawing.Point(219, 685);
            this.txtFoodAdlCmt.MaxLength = 28;
            this.txtFoodAdlCmt.Name = "txtFoodAdlCmt";
            this.txtFoodAdlCmt.Size = new System.Drawing.Size(108, 20);
            this.txtFoodAdlCmt.TabIndex = 33;
            this.txtFoodAdlCmt.Tag = "food_adl_cmt";
            this.txtFoodAdlCmt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // dtpToiwonDate
            // 
            this.dtpToiwonDate.Location = new System.Drawing.Point(437, 92);
            this.dtpToiwonDate.Name = "dtpToiwonDate";
            this.dtpToiwonDate.Size = new System.Drawing.Size(100, 20);
            this.dtpToiwonDate.TabIndex = 13;
            this.dtpToiwonDate.Tag = "toiwon_date";
            this.dtpToiwonDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // dtpWriteDate
            // 
            this.dtpWriteDate.Location = new System.Drawing.Point(545, 27);
            this.dtpWriteDate.Name = "dtpWriteDate";
            this.dtpWriteDate.Size = new System.Drawing.Size(100, 20);
            this.dtpWriteDate.TabIndex = 1;
            this.dtpWriteDate.Tag = "write_date";
            this.dtpWriteDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(437, 196);
            this.txtTel.MaxLength = 40;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(211, 20);
            this.txtTel.TabIndex = 17;
            this.txtTel.Tag = "tel";
            this.txtTel.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // xLabel38
            // 
            this.xLabel38.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel38.EdgeRounding = false;
            this.xLabel38.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel38.Location = new System.Drawing.Point(455, 27);
            this.xLabel38.Name = "xLabel38";
            this.xLabel38.Size = new System.Drawing.Size(84, 20);
            this.xLabel38.TabIndex = 104;
            this.xLabel38.Text = "記録日";
            this.xLabel38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHodong
            // 
            this.txtHodong.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtHodong.Location = new System.Drawing.Point(437, 118);
            this.txtHodong.MaxLength = 2;
            this.txtHodong.Name = "txtHodong";
            this.txtHodong.Size = new System.Drawing.Size(100, 20);
            this.txtHodong.TabIndex = 14;
            this.txtHodong.Tag = "ho_dong";
            this.txtHodong.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // cboGubun
            // 
            this.cboGubun.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGubun.Location = new System.Drawing.Point(240, 15);
            this.cboGubun.Name = "cboGubun";
            this.cboGubun.Size = new System.Drawing.Size(80, 32);
            this.cboGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGubun.TabIndex = 0;
            this.cboGubun.Tag = "gubun";
            this.cboGubun.UserSQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n  FROM NUR0102 A \r\n WHERE A.HOSP_CODE= FN_ADM_" +
                "LOAD_HOSP_CODE()\r\n   AND A.CODE_TYPE = \'SUMMARY_GUBUN\'\r\n ORDER BY A.SORT_KEY, A." +
                "CODE";
            this.cboGubun.SelectedIndexChanged += new System.EventHandler(this.cboGubun_SelectedIndexChanged);
            this.cboGubun.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // xLabel37
            // 
            this.xLabel37.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel37.EdgeRounding = false;
            this.xLabel37.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel37.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel37.Location = new System.Drawing.Point(322, 15);
            this.xLabel37.Margin = new System.Windows.Forms.Padding(0);
            this.xLabel37.Name = "xLabel37";
            this.xLabel37.Size = new System.Drawing.Size(77, 32);
            this.xLabel37.TabIndex = 102;
            this.xLabel37.Text = "サマリー";
            // 
            // cboWareADL
            // 
            this.cboWareADL.Location = new System.Drawing.Point(436, 710);
            this.cboWareADL.Name = "cboWareADL";
            this.cboWareADL.Size = new System.Drawing.Size(100, 21);
            this.cboWareADL.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboWareADL.TabIndex = 43;
            this.cboWareADL.Tag = "ware_adl";
            this.cboWareADL.UserSQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n  FROM NUR0102 A \r\n WHERE A.HOSP_CODE= FN_ADM_" +
                "LOAD_HOSP_CODE()\r\n   AND A.CODE_TYPE = \'SUMMARY_ADL\'\r\n ORDER BY A.SORT_KEY, A.CO" +
                "DE";
            this.cboWareADL.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // dtpBirth
            // 
            this.dtpBirth.Location = new System.Drawing.Point(117, 93);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(100, 20);
            this.dtpBirth.TabIndex = 4;
            this.dtpBirth.Tag = "birth";
            this.dtpBirth.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // cboFoodADL
            // 
            this.cboFoodADL.Location = new System.Drawing.Point(117, 684);
            this.cboFoodADL.Name = "cboFoodADL";
            this.cboFoodADL.Size = new System.Drawing.Size(100, 21);
            this.cboFoodADL.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboFoodADL.TabIndex = 32;
            this.cboFoodADL.Tag = "food_adl";
            this.cboFoodADL.UserSQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n  FROM NUR0102 A \r\n WHERE A.HOSP_CODE= FN_ADM_" +
                "LOAD_HOSP_CODE()\r\n   AND A.CODE_TYPE = \'SUMMARY_ADL\'\r\n ORDER BY A.SORT_KEY, A.CO" +
                "DE";
            this.cboFoodADL.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtComments
            // 
            this.txtComments.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtComments.Location = new System.Drawing.Point(117, 818);
            this.txtComments.MaxLength = 4000;
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(530, 157);
            this.txtComments.TabIndex = 48;
            this.txtComments.Tag = "comments";
            this.txtComments.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtTube
            // 
            this.txtTube.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtTube.Location = new System.Drawing.Point(436, 792);
            this.txtTube.MaxLength = 40;
            this.txtTube.Name = "txtTube";
            this.txtTube.Size = new System.Drawing.Size(211, 20);
            this.txtTube.TabIndex = 47;
            this.txtTube.Tag = "tube";
            this.txtTube.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtSleep
            // 
            this.txtSleep.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSleep.Location = new System.Drawing.Point(436, 765);
            this.txtSleep.MaxLength = 40;
            this.txtSleep.Name = "txtSleep";
            this.txtSleep.Size = new System.Drawing.Size(211, 20);
            this.txtSleep.TabIndex = 46;
            this.txtSleep.Tag = "sleep";
            this.txtSleep.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtExcretion
            // 
            this.txtExcretion.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtExcretion.Location = new System.Drawing.Point(117, 711);
            this.txtExcretion.MaxLength = 40;
            this.txtExcretion.Name = "txtExcretion";
            this.txtExcretion.Size = new System.Drawing.Size(210, 20);
            this.txtExcretion.TabIndex = 34;
            this.txtExcretion.Tag = "excretion";
            this.txtExcretion.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtWash
            // 
            this.txtWash.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtWash.Location = new System.Drawing.Point(436, 659);
            this.txtWash.MaxLength = 40;
            this.txtWash.Name = "txtWash";
            this.txtWash.Size = new System.Drawing.Size(211, 20);
            this.txtWash.TabIndex = 40;
            this.txtWash.Tag = "wash";
            this.txtWash.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtFood
            // 
            this.txtFood.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtFood.Location = new System.Drawing.Point(117, 659);
            this.txtFood.MaxLength = 40;
            this.txtFood.Name = "txtFood";
            this.txtFood.Size = new System.Drawing.Size(210, 20);
            this.txtFood.TabIndex = 31;
            this.txtFood.Tag = "food";
            this.txtFood.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtContinueNursing
            // 
            this.txtContinueNursing.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtContinueNursing.Location = new System.Drawing.Point(117, 633);
            this.txtContinueNursing.MaxLength = 100;
            this.txtContinueNursing.Name = "txtContinueNursing";
            this.txtContinueNursing.Size = new System.Drawing.Size(528, 20);
            this.txtContinueNursing.TabIndex = 30;
            this.txtContinueNursing.Tag = "continue_nursing";
            this.txtContinueNursing.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtNursingPass
            // 
            this.txtNursingPass.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtNursingPass.Location = new System.Drawing.Point(117, 554);
            this.txtNursingPass.MaxLength = 1000;
            this.txtNursingPass.Multiline = true;
            this.txtNursingPass.Name = "txtNursingPass";
            this.txtNursingPass.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNursingPass.Size = new System.Drawing.Size(528, 73);
            this.txtNursingPass.TabIndex = 29;
            this.txtNursingPass.Tag = "nursing_pass";
            this.txtNursingPass.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtInpatientCourse
            // 
            this.txtInpatientCourse.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtInpatientCourse.Location = new System.Drawing.Point(117, 450);
            this.txtInpatientCourse.MaxLength = 1000;
            this.txtInpatientCourse.Multiline = true;
            this.txtInpatientCourse.Name = "txtInpatientCourse";
            this.txtInpatientCourse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInpatientCourse.Size = new System.Drawing.Size(528, 98);
            this.txtInpatientCourse.TabIndex = 28;
            this.txtInpatientCourse.Tag = "inpatient_course";
            this.txtInpatientCourse.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtPastHis
            // 
            this.txtPastHis.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPastHis.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtPastHis.Location = new System.Drawing.Point(117, 311);
            this.txtPastHis.MaxLength = 356;
            this.txtPastHis.Multiline = true;
            this.txtPastHis.Name = "txtPastHis";
            this.txtPastHis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPastHis.Size = new System.Drawing.Size(211, 135);
            this.txtPastHis.TabIndex = 11;
            this.txtPastHis.Tag = "past_his";
            this.txtPastHis.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtTaboo
            // 
            this.txtTaboo.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtTaboo.Location = new System.Drawing.Point(435, 426);
            this.txtTaboo.MaxLength = 40;
            this.txtTaboo.Name = "txtTaboo";
            this.txtTaboo.Size = new System.Drawing.Size(211, 20);
            this.txtTaboo.TabIndex = 27;
            this.txtTaboo.Tag = "taboo";
            this.txtTaboo.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtInfection
            // 
            this.txtInfection.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtInfection.Location = new System.Drawing.Point(435, 400);
            this.txtInfection.MaxLength = 40;
            this.txtInfection.Name = "txtInfection";
            this.txtInfection.Size = new System.Drawing.Size(211, 20);
            this.txtInfection.TabIndex = 26;
            this.txtInfection.Tag = "infection";
            this.txtInfection.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtDoctor
            // 
            this.txtDoctor.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtDoctor.Location = new System.Drawing.Point(223, 118);
            this.txtDoctor.MaxLength = 40;
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(105, 20);
            this.txtDoctor.TabIndex = 7;
            this.txtDoctor.Tag = "doctor";
            this.txtDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtGwa
            // 
            this.txtGwa.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtGwa.Location = new System.Drawing.Point(117, 118);
            this.txtGwa.MaxLength = 40;
            this.txtGwa.Name = "txtGwa";
            this.txtGwa.Size = new System.Drawing.Size(100, 20);
            this.txtGwa.TabIndex = 6;
            this.txtGwa.Tag = "gwa";
            this.txtGwa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtSuname
            // 
            this.txtSuname.Location = new System.Drawing.Point(203, 66);
            this.txtSuname.MaxLength = 50;
            this.txtSuname.Name = "txtSuname";
            this.txtSuname.Size = new System.Drawing.Size(125, 20);
            this.txtSuname.TabIndex = 3;
            this.txtSuname.Tag = "suname";
            this.txtSuname.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtSangName
            // 
            this.txtSangName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSangName.Location = new System.Drawing.Point(117, 222);
            this.txtSangName.MaxLength = 228;
            this.txtSangName.Multiline = true;
            this.txtSangName.Name = "txtSangName";
            this.txtSangName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSangName.Size = new System.Drawing.Size(211, 85);
            this.txtSangName.TabIndex = 10;
            this.txtSangName.Tag = "sang_name";
            this.txtSangName.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtAddress
            // 
            this.txtAddress.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtAddress.Location = new System.Drawing.Point(117, 171);
            this.txtAddress.MaxLength = 114;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(211, 45);
            this.txtAddress.TabIndex = 9;
            this.txtAddress.Tag = "address";
            this.txtAddress.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // txtReason
            // 
            this.txtReason.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtReason.Location = new System.Drawing.Point(117, 145);
            this.txtReason.MaxLength = 40;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(211, 20);
            this.txtReason.TabIndex = 8;
            this.txtReason.Tag = "reason";
            this.txtReason.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.DataValidating);
            // 
            // xLabel35
            // 
            this.xLabel35.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel35.EdgeRounding = false;
            this.xLabel35.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel35.Location = new System.Drawing.Point(15, 818);
            this.xLabel35.Name = "xLabel35";
            this.xLabel35.Size = new System.Drawing.Size(97, 157);
            this.xLabel35.TabIndex = 48;
            this.xLabel35.Text = "備考";
            this.xLabel35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel33
            // 
            this.xLabel33.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel33.EdgeRounding = false;
            this.xLabel33.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel33.Location = new System.Drawing.Point(334, 792);
            this.xLabel33.Name = "xLabel33";
            this.xLabel33.Size = new System.Drawing.Size(97, 20);
            this.xLabel33.TabIndex = 47;
            this.xLabel33.Text = "チューブ類";
            this.xLabel33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel34
            // 
            this.xLabel34.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel34.EdgeRounding = false;
            this.xLabel34.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel34.Location = new System.Drawing.Point(333, 765);
            this.xLabel34.Name = "xLabel34";
            this.xLabel34.Size = new System.Drawing.Size(97, 20);
            this.xLabel34.TabIndex = 46;
            this.xLabel34.Text = "睡眠状況";
            this.xLabel34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel31
            // 
            this.xLabel31.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel31.EdgeRounding = false;
            this.xLabel31.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel31.Location = new System.Drawing.Point(333, 737);
            this.xLabel31.Name = "xLabel31";
            this.xLabel31.Size = new System.Drawing.Size(97, 20);
            this.xLabel31.TabIndex = 45;
            this.xLabel31.Text = "コミュニケーション";
            this.xLabel31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel32
            // 
            this.xLabel32.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel32.EdgeRounding = false;
            this.xLabel32.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel32.Location = new System.Drawing.Point(333, 711);
            this.xLabel32.Name = "xLabel32";
            this.xLabel32.Size = new System.Drawing.Size(97, 20);
            this.xLabel32.TabIndex = 44;
            this.xLabel32.Text = "更衣ADL";
            this.xLabel32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel29
            // 
            this.xLabel29.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel29.EdgeRounding = false;
            this.xLabel29.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel29.Location = new System.Drawing.Point(15, 791);
            this.xLabel29.Name = "xLabel29";
            this.xLabel29.Size = new System.Drawing.Size(97, 20);
            this.xLabel29.TabIndex = 43;
            this.xLabel29.Text = "移動ADL";
            this.xLabel29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel30
            // 
            this.xLabel30.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel30.EdgeRounding = false;
            this.xLabel30.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel30.Location = new System.Drawing.Point(15, 764);
            this.xLabel30.Name = "xLabel30";
            this.xLabel30.Size = new System.Drawing.Size(97, 20);
            this.xLabel30.TabIndex = 42;
            this.xLabel30.Text = "移動";
            this.xLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel27
            // 
            this.xLabel27.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel27.EdgeRounding = false;
            this.xLabel27.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel27.Location = new System.Drawing.Point(15, 737);
            this.xLabel27.Name = "xLabel27";
            this.xLabel27.Size = new System.Drawing.Size(97, 20);
            this.xLabel27.TabIndex = 41;
            this.xLabel27.Text = "排泄ADL";
            this.xLabel27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel28
            // 
            this.xLabel28.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel28.EdgeRounding = false;
            this.xLabel28.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel28.Location = new System.Drawing.Point(15, 711);
            this.xLabel28.Name = "xLabel28";
            this.xLabel28.Size = new System.Drawing.Size(97, 20);
            this.xLabel28.TabIndex = 40;
            this.xLabel28.Text = "排泄";
            this.xLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel26
            // 
            this.xLabel26.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel26.EdgeRounding = false;
            this.xLabel26.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel26.Location = new System.Drawing.Point(333, 686);
            this.xLabel26.Name = "xLabel26";
            this.xLabel26.Size = new System.Drawing.Size(97, 20);
            this.xLabel26.TabIndex = 39;
            this.xLabel26.Text = "清潔ADL";
            this.xLabel26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel25
            // 
            this.xLabel25.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel25.EdgeRounding = false;
            this.xLabel25.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel25.Location = new System.Drawing.Point(15, 686);
            this.xLabel25.Name = "xLabel25";
            this.xLabel25.Size = new System.Drawing.Size(97, 20);
            this.xLabel25.TabIndex = 38;
            this.xLabel25.Text = "食事ADL";
            this.xLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel24
            // 
            this.xLabel24.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel24.EdgeRounding = false;
            this.xLabel24.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel24.Location = new System.Drawing.Point(15, 659);
            this.xLabel24.Name = "xLabel24";
            this.xLabel24.Size = new System.Drawing.Size(97, 20);
            this.xLabel24.TabIndex = 37;
            this.xLabel24.Text = "食種";
            this.xLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel23
            // 
            this.xLabel23.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel23.EdgeRounding = false;
            this.xLabel23.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel23.Location = new System.Drawing.Point(15, 633);
            this.xLabel23.Name = "xLabel23";
            this.xLabel23.Size = new System.Drawing.Size(97, 20);
            this.xLabel23.TabIndex = 36;
            this.xLabel23.Text = "継　続　看　護";
            this.xLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel22
            // 
            this.xLabel22.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel22.EdgeRounding = false;
            this.xLabel22.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel22.Location = new System.Drawing.Point(15, 554);
            this.xLabel22.Name = "xLabel22";
            this.xLabel22.Size = new System.Drawing.Size(97, 73);
            this.xLabel22.TabIndex = 35;
            this.xLabel22.Text = "看　護　経　過";
            this.xLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel21
            // 
            this.xLabel21.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel21.EdgeRounding = false;
            this.xLabel21.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel21.Location = new System.Drawing.Point(15, 450);
            this.xLabel21.Name = "xLabel21";
            this.xLabel21.Size = new System.Drawing.Size(97, 98);
            this.xLabel21.TabIndex = 34;
            this.xLabel21.Text = "入院までの経過";
            this.xLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel20
            // 
            this.xLabel20.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel20.EdgeRounding = false;
            this.xLabel20.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel20.Location = new System.Drawing.Point(333, 659);
            this.xLabel20.Name = "xLabel20";
            this.xLabel20.Size = new System.Drawing.Size(97, 20);
            this.xLabel20.TabIndex = 33;
            this.xLabel20.Text = "清潔";
            this.xLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel19
            // 
            this.xLabel19.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel19.EdgeRounding = false;
            this.xLabel19.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel19.Location = new System.Drawing.Point(333, 426);
            this.xLabel19.Name = "xLabel19";
            this.xLabel19.Size = new System.Drawing.Size(97, 20);
            this.xLabel19.TabIndex = 32;
            this.xLabel19.Text = "禁　　　　忌";
            this.xLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel17
            // 
            this.xLabel17.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel17.EdgeRounding = false;
            this.xLabel17.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel17.Location = new System.Drawing.Point(333, 400);
            this.xLabel17.Name = "xLabel17";
            this.xLabel17.Size = new System.Drawing.Size(97, 20);
            this.xLabel17.TabIndex = 31;
            this.xLabel17.Text = "感　　染　　症";
            this.xLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel16
            // 
            this.xLabel16.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel16.EdgeRounding = false;
            this.xLabel16.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel16.Location = new System.Drawing.Point(333, 311);
            this.xLabel16.Name = "xLabel16";
            this.xLabel16.Size = new System.Drawing.Size(97, 83);
            this.xLabel16.TabIndex = 30;
            this.xLabel16.Text = "連　絡　先　２";
            this.xLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel15
            // 
            this.xLabel15.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel15.EdgeRounding = false;
            this.xLabel15.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel15.Location = new System.Drawing.Point(15, 311);
            this.xLabel15.Name = "xLabel15";
            this.xLabel15.Size = new System.Drawing.Size(97, 135);
            this.xLabel15.TabIndex = 29;
            this.xLabel15.Text = "既　　　往";
            this.xLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel14
            // 
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel14.Location = new System.Drawing.Point(15, 222);
            this.xLabel14.Name = "xLabel14";
            this.xLabel14.Size = new System.Drawing.Size(97, 85);
            this.xLabel14.TabIndex = 28;
            this.xLabel14.Text = "病　　　　名";
            this.xLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Location = new System.Drawing.Point(15, 171);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(97, 45);
            this.xLabel6.TabIndex = 20;
            this.xLabel6.Text = "住　　　　所";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReason
            // 
            this.lblReason.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblReason.EdgeRounding = false;
            this.lblReason.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblReason.Location = new System.Drawing.Point(15, 145);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(97, 20);
            this.lblReason.TabIndex = 19;
            this.lblReason.Text = "転　院　事　由";
            this.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Location = new System.Drawing.Point(15, 118);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(97, 20);
            this.xLabel3.TabIndex = 17;
            this.xLabel3.Text = "診療科/診療医";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(15, 93);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(97, 20);
            this.xLabel2.TabIndex = 16;
            this.xLabel2.Text = "生　年　月　日";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel18
            // 
            this.xLabel18.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel18.EdgeRounding = false;
            this.xLabel18.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel18.Location = new System.Drawing.Point(15, 66);
            this.xLabel18.Name = "xLabel18";
            this.xLabel18.Size = new System.Drawing.Size(97, 20);
            this.xLabel18.TabIndex = 14;
            this.xLabel18.Text = "患者 ID/氏名";
            this.xLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel3.Location = new System.Drawing.Point(5, 683);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(983, 32);
            this.xPanel3.TabIndex = 3;
            // 
            // grdNUR9999
            // 
            this.grdNUR9999.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell45,
            this.xEditGridCell30,
            this.xEditGridCell29,
            this.xEditGridCell1,
            this.xEditGridCell31,
            this.xEditGridCell2,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell52,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell32,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell48,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell49,
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
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44});
            this.grdNUR9999.ColPerLine = 3;
            this.grdNUR9999.Cols = 4;
            this.grdNUR9999.ControlBinding = true;
            this.grdNUR9999.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR9999.FixedCols = 1;
            this.grdNUR9999.FixedRows = 1;
            this.grdNUR9999.HeaderHeights.Add(24);
            this.grdNUR9999.Location = new System.Drawing.Point(0, 0);
            this.grdNUR9999.Name = "grdNUR9999";
            this.grdNUR9999.QuerySQL = resources.GetString("grdNUR9999.QuerySQL");
            this.grdNUR9999.RowHeaderVisible = true;
            this.grdNUR9999.Rows = 2;
            this.grdNUR9999.Size = new System.Drawing.Size(303, 636);
            this.grdNUR9999.TabIndex = 0;
            this.grdNUR9999.TabStop = false;
            this.grdNUR9999.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNUR9999_QueryEnd);
            this.grdNUR9999.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR9999_QueryStarting);
            this.grdNUR9999.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR9999_SaveEnd);
            this.grdNUR9999.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR9999_RowFocusChanged);
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "fkinp1001";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.HeaderText = "fkinp1001";
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "pknur9999";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.HeaderText = "pknur9999";
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "gubun";
            this.xEditGridCell29.CellWidth = 63;
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.HeaderText = "gubun";
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "gubun_name";
            this.xEditGridCell1.CellWidth = 64;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderText = "区分";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "write_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.CellWidth = 107;
            this.xEditGridCell31.Col = 3;
            this.xEditGridCell31.HeaderText = "作成日";
            this.xEditGridCell31.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "bunho";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "suname";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.HeaderText = "suname";
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "birth";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.HeaderText = "birth";
            this.xEditGridCell47.IsReadOnly = true;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "age";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.HeaderText = "age";
            this.xEditGridCell52.IsReadOnly = true;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "gwa";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "gwa";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "doctor";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "doctor";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "reason";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "reason";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "address";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "address";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "ipwon_date";
            this.xEditGridCell32.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell32.CellWidth = 104;
            this.xEditGridCell32.Col = 2;
            this.xEditGridCell32.HeaderText = "入院日";
            this.xEditGridCell32.IsReadOnly = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "toiwon_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "toiwon_date";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "ho_dong";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "ho_dong";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "damdang_nurse";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "damdang_nurse";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "leader_nurse";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "leader_nurse";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "tel";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "tel";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "sang_name";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "sang_name";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "past_his";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "past_his";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "key1_relation";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.HeaderText = "key1_relation";
            this.xEditGridCell48.IsReadOnly = true;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "key1_home";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "key1_home";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "key1_phone";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "key1_phone";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "key1_office";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "key1_office";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "key2_relation";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.HeaderText = "key2_relation";
            this.xEditGridCell49.IsReadOnly = true;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "key2_home";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "key2_home";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "key2_phone";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "key2_phone";
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "key2_office";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "key2_office";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "infection";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "infection";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "taboo";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "taboo";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "inpatient_course";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderText = "inpatient_course";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "nursing_pass";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.HeaderText = "nursing_pass";
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "continue_nursing";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "continue_nursing";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "food";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.HeaderText = "food";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "food_adl";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.HeaderText = "food_adl";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "food_adl_cmt";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.HeaderText = "food_adl_cmt";
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "excretion";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.HeaderText = "excretion";
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "excretion_adl";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.HeaderText = "excretion_adl";
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "excretion_adl_cmt";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.HeaderText = "excretion_adl_cmt";
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "move";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.HeaderText = "move";
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "move_adl";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.HeaderText = "move_adl";
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "move_adl_cmt";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.HeaderText = "move_adl_cmt";
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "wash";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.HeaderText = "wash";
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "wash_adl";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.HeaderText = "wash_adl";
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "wash_adl_cmt";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.HeaderText = "wash_adl_cmt";
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "ware_adl";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.HeaderText = "ware_adl";
            this.xEditGridCell50.IsReadOnly = true;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "ware_adl_cmt";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.HeaderText = "ware_adl_cmt";
            this.xEditGridCell51.IsReadOnly = true;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "communication";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.HeaderText = "communication";
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "sleep";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.HeaderText = "sleep";
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "tube";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.HeaderText = "tube";
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellLen = 4000;
            this.xEditGridCell44.CellName = "comments";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.HeaderText = "comments";
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grdNUR9999);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(5, 47);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(303, 636);
            this.pnlLeft.TabIndex = 1;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Controls.Add(this.xLabel36);
            this.pnlTop.Controls.Add(this.cboPkInp1001);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(5, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(983, 42);
            this.pnlTop.TabIndex = 0;
            // 
            // paBox
            // 
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(3, 3);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(650, 37);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xLabel36
            // 
            this.xLabel36.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel36.EdgeRounding = false;
            this.xLabel36.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel36.Location = new System.Drawing.Point(659, 11);
            this.xLabel36.Name = "xLabel36";
            this.xLabel36.Size = new System.Drawing.Size(84, 20);
            this.xLabel36.TabIndex = 100;
            this.xLabel36.Text = "入院履歴";
            this.xLabel36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboPkInp1001
            // 
            this.cboPkInp1001.Location = new System.Drawing.Point(748, 11);
            this.cboPkInp1001.Name = "cboPkInp1001";
            this.cboPkInp1001.Size = new System.Drawing.Size(230, 21);
            this.cboPkInp1001.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboPkInp1001.TabIndex = 1;
            this.cboPkInp1001.UserSQL = resources.GetString("cboPkInp1001.UserSQL");
            this.cboPkInp1001.SelectedIndexChanged += new System.EventHandler(this.cboPkInp1001_SelectedIndexChanged);
            // 
            // layPaInfo
            // 
            this.layPaInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4,
            this.singleLayoutItem5,
            this.singleLayoutItem7,
            this.singleLayoutItem8,
            this.singleLayoutItem9,
            this.singleLayoutItem10,
            this.singleLayoutItem12,
            this.singleLayoutItem13,
            this.singleLayoutItem14,
            this.singleLayoutItem15,
            this.singleLayoutItem16,
            this.singleLayoutItem17,
            this.singleLayoutItem18,
            this.singleLayoutItem19,
            this.singleLayoutItem6,
            this.singleLayoutItem11});
            this.layPaInfo.QuerySQL = resources.GetString("layPaInfo.QuerySQL");
            this.layPaInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPaInfo_QueryStarting);
            this.layPaInfo.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layPaInfo_QueryEnd);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dtpIpwonDate;
            this.singleLayoutItem1.DataName = "dtpIpwonDate";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.BindControl = this.dtpToiwonDate;
            this.singleLayoutItem2.DataName = "dtpToiwonDate";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.BindControl = this.txtHodong;
            this.singleLayoutItem3.DataName = "txtHodong";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.BindControl = this.txtGwa;
            this.singleLayoutItem4.DataName = "txtGwa";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.BindControl = this.txtDoctor;
            this.singleLayoutItem5.DataName = "txtDoctor";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.BindControl = this.txtKey1Relation;
            this.singleLayoutItem7.DataName = "txtKey1Relation";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.BindControl = this.txtKey1Home;
            this.singleLayoutItem8.DataName = "txtKey1Home";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.BindControl = this.txtKey1Phone;
            this.singleLayoutItem9.DataName = "txtKey1Phone";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.BindControl = this.txtKey1Office;
            this.singleLayoutItem10.DataName = "txtKey1Office";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.BindControl = this.txtKey2Relation;
            this.singleLayoutItem12.DataName = "txtKey2Relation";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.BindControl = this.txtKey2Home;
            this.singleLayoutItem13.DataName = "txtKey2Home";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.BindControl = this.txtKey2Phone;
            this.singleLayoutItem14.DataName = "txtKey2Phone";
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.BindControl = this.txtKey2Office;
            this.singleLayoutItem15.DataName = "txtKey2Office";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.BindControl = this.txtInfection;
            this.singleLayoutItem16.DataName = "txtInfection";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.BindControl = this.txtInpatientCourse;
            this.singleLayoutItem17.DataName = "txtInpatientCourse";
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.BindControl = this.txtDamdangNurse;
            this.singleLayoutItem18.DataName = "txtDamdangNurse";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.BindControl = this.txtSangName;
            this.singleLayoutItem19.DataName = "txtSangName";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.BindControl = this.txtAge;
            this.singleLayoutItem6.DataName = "txtAge";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.BindControl = this.txtPastHis;
            this.singleLayoutItem11.DataName = "txtPastHis";
            // 
            // NUR9999R11
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR9999R11";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(993, 720);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR9999R11_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.gbxInput.ResumeLayout(false);
            this.gbxInput.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR9999)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            // TODO:  NUR9999U00.OnLoad 구현을 추가합니다.
            base.OnLoad(e);
        }
        #endregion

        private void NUR9999R11_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(this.ParentForm.Size.Width, rc.Height - 105);

            // 선택된 환자정보 가져오기

             

        }
        #region [btnList_ButtonClick] 버튼클릭이벤트

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
            {
                case FunctionType.Print:

                    if (UpdateCheck())
                    {
                        grdNUR9999.SaveLayout();
                    }

                    CommonItemCollection cic = new CommonItemCollection();

                    cic.Add("isCalled", "N");
                    cic.Add("pknur9999", txtPknur9999.Text);

                    OpenScreenWithParam(this, EnvironInfo.CurrSystemID, "NUR9999R12", ScreenOpenStyle.PopUpFixed, cic);                    

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    if (!UpdateCheck())
                    {
                        e.IsSuccess = false;
                        return;
                    }

                    if (this.grdNUR9999.SaveLayout())
                        e.IsSuccess = true;
                    else
                        e.IsSuccess = false;


                    break;


                case FunctionType.Insert:
                    e.IsBaseCall = false;

                    if(paBox.BunHo == "")
                    {
                        e.IsSuccess = false;
                        XMessageBox.Show("まず患者番号を入力してください。");

                        paBox.Focus();

                        return;
                    }

                    grdNUR9999.Focus();
                    for (int i = 0; i < grdNUR9999.RowCount; i++)
                    {
                        if (grdNUR9999.GetRowState(i) == DataRowState.Added)
                        {
                            XMessageBox.Show("保存されてない行があります。", "お知らせ", MessageBoxIcon.Information);
                            return;
                        }
                    }

                    int rownum = -1;
                    rownum = this.grdNUR9999.InsertRow(0);

                    string sqlCmd = @"SELECT NUR9999_SEQ.NEXTVAL FROM SYS.DUAL";

                    object retval = Service.ExecuteScalar(sqlCmd);

                    this.grdNUR9999.SetItemValue(rownum, "pknur9999", retval.ToString());
                    
                    this.txtPknur9999.SetDataValue(retval);
                    this.grdNUR9999.SetItemValue(rownum, "fkinp1001", cboPkInp1001.GetDataValue());


                    grdNUR9999.AcceptData();
                    break;

                case FunctionType.Query:

                    e.IsBaseCall = false;
                    this.grdNUR9999.QueryLayout(false);

                    break;

                case FunctionType.Close:

                    //e.IsBaseCall = false;

                    break;

                case FunctionType.Delete:
                    grdNUR9999.Focus();
                    break;


            }
		}
		#endregion

        private bool UpdateCheck()
        {
            if (this.paBox.BunHo == "")
            {
                XMessageBox.Show("患者番号が正しくありません。", "確認");
                return false;
            }

            //if (this.grdNUR9999.CurrentRowNumber == -1)
            //{
            //    XMessageBox.Show("入力ボタンをクリックしてから入力してください。", "確認");

            //    e.IsSuccess = false;
            //    return;
            //}

            if (this.cboGubun.SelectedIndex == -1)
            {
                XMessageBox.Show("サマリーの種類が正しくありません。", "確認");
                return false;
            }


            if (this.grdNUR9999.DeletedRowCount > 0)
            {
                return true;
            }

            if (this.grdNUR9999.GetRowState(grdNUR9999.CurrentRowNumber) == DataRowState.Unchanged)
            {
                return false;
            }

            return true;
        }

            
        //#region [btnList_PostButtonClick]
        //private void btnList_PostButtonClick(object sender, PostButtonClickEventArgs e)
        //{
        //    switch (e.Func)
        //    {
        //        case FunctionType.Update:
        //            if (e.IsSuccess)
        //            {
        //                XMessageBox.Show("保存が完了しました。", "保存", MessageBoxIcon.Asterisk);
                        

        //                this.grdNUR9999.QueryLayout(true);
        //            }
        //            else
        //            {
        //                XMessageBox.Show("保存に失敗しました。", "保存失敗", MessageBoxIcon.Error);
                        
        //            }
        //            break;
        //    }
        //}
        //#endregion

        #region [cbxXrayGubun_SelectedIndexChanged　撮影区分検索]
        private void cbxXrayGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        {
            NUR9999R11 parent = null;

            public XSavePerformer(NUR9999R11 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                {
                    #region [case '1']
                    case '1':

                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"INSERT INTO  NUR9999
                                           (      SYS_ID                , SYS_DATE            , UPD_ID
                                                , UPD_DATE              , HOSP_CODE           , FKINP1001
                                                , PKNUR9999             , GUBUN               , WRITE_DATE
                                                , BUNHO                 , SUNAME              , BIRTH
                                                , AGE                   , GWA                 , DOCTOR
                                                , REASON                , ADDRESS             , IPWON_DATE
                                                , TOIWON_DATE           , HO_DONG             , DAMDANG_NURSE
                                                , LEADER_NURSE          , TEL                 , SANG_NAME
                                                , PAST_HIS              
                                                , KEY1_RELATION         , KEY1_HOME           , KEY1_PHONE
                                                , KEY1_OFFICE           
                                                , KEY2_RELATION         , KEY2_HOME           , KEY2_PHONE
                                                , KEY2_OFFICE           , INFECTION           , TABOO
                                                , INPATIENT_COURSE      , NURSING_PASS        , CONTINUE_NURSING
                                                , FOOD                  , FOOD_ADL            , FOOD_ADL_CMT
                                                , EXCRETION             , EXCRETION_ADL       , EXCRETION_ADL_CMT
                                                , MOVE                  , MOVE_ADL            , MOVE_ADL_CMT
                                                , WASH                  , WASH_ADL            , WASH_ADL_CMT
                                                , WARE_ADL              , WARE_ADL_CMT        , COMMUNICATION
                                                , SLEEP                 , TUBE                , COMMENTS            )
                                           VALUES
                                           (      :q_user_id            , SYSDATE             , :q_user_id
                                                , SYSDATE               , :f_hosp_code        , :f_fkinp1001
                                                , :f_pknur9999          , :f_gubun            , :f_write_date
                                                , :f_bunho              , :f_suname           , :f_birth
                                                , :f_age                , :f_gwa              , :f_doctor
                                                , :f_reason             , :f_address          , :f_ipwon_date
                                                , :f_toiwon_date        , :f_ho_dong          , :f_damdang_nurse
                                                , :f_leader_nurse       , :f_tel              , :f_sang_name
                                                , :f_past_his           
                                                , :f_key1_relation      , :f_key1_home        , :f_key1_phone
                                                , :f_key1_office        
                                                , :f_key2_relation      , :f_key2_home        , :f_key2_phone
                                                , :f_key2_office        , :f_infection        , :f_taboo
                                                , :f_inpatient_course   , :f_nursing_pass     , :f_continue_nursing
                                                , :f_food               , :f_food_adl         , :f_food_adl_cmt
                                                , :f_excretion          , :f_excretion_adl    , :f_excretion_adl_cmt
                                                , :f_move               , :f_move_adl         , :f_move_adl_cmt
                                                , :f_wash               , :f_wash_adl         , :f_wash_adl_cmt
                                                , :f_ware_adl           , :f_ware_adl_cmt     , :f_communication
                                                , :f_sleep              , :f_tube             , :f_comments         )";
                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE NUR9999
                                               SET UPD_ID            = :q_user_id
                                                 , UPD_DATE          = sysdate
                                                 , GUBUN             = :f_gubun
                                                 , WRITE_DATE        = :f_write_date
                                                 , BUNHO             = :f_bunho
                                                 , AGE               = :f_age
                                                 , GWA               = :f_gwa
                                                 , DOCTOR            = :f_doctor
                                                 , REASON            = :f_reason
                                                 , ADDRESS           = :f_address
                                                 , IPWON_DATE        = :f_ipwon_date
                                                 , TOIWON_DATE       = :f_toiwon_date
                                                 , HO_DONG           = :f_ho_dong
                                                 , DAMDANG_NURSE     = :f_damdang_nurse
                                                 , LEADER_NURSE      = :f_leader_nurse
                                                 , TEL               = :f_tel
                                                 , SANG_NAME         = :f_sang_name
                                                 , PAST_HIS          = :f_past_his
                                                 , KEY1_RELATION     = :f_key1_relation
                                                 , KEY1_HOME         = :f_key1_home
                                                 , KEY1_PHONE        = :f_key1_phone
                                                 , KEY1_OFFICE       = :f_key1_office
                                                 , KEY2_RELATION     = :f_key2_relation
                                                 , KEY2_HOME         = :f_key2_home
                                                 , KEY2_PHONE        = :f_key2_phone
                                                 , KEY2_OFFICE       = :f_key2_office
                                                 , INFECTION         = :f_infection
                                                 , TABOO             = :f_taboo
                                                 , INPATIENT_COURSE  = :f_inpatient_course
                                                 , NURSING_PASS      = :f_nursing_pass
                                                 , CONTINUE_NURSING  = :f_continue_nursing
                                                 , FOOD              = :f_food
                                                 , FOOD_ADL          = :f_food_adl
                                                 , FOOD_ADL_CMT      = :f_food_adl_cmt
                                                 , EXCRETION         = :f_excretion
                                                 , EXCRETION_ADL     = :f_excretion_adl
                                                 , EXCRETION_ADL_CMT = :f_excretion_adl_cmt
                                                 , MOVE              = :f_move
                                                 , MOVE_ADL          = :f_move_adl
                                                 , MOVE_ADL_CMT      = :f_move_adl_cmt
                                                 , WASH              = :f_wash
                                                 , WASH_ADL          = :f_wash_adl
                                                 , WASH_ADL_CMT      = :f_wash_adl_cmt
                                                 , WARE_ADL          = :f_ware_adl
                                                 , WARE_ADL_CMT      = :f_ware_adl_cmt
                                                 , COMMUNICATION     = :f_communication
                                                 , SLEEP             = :f_sleep
                                                 , TUBE              = :f_tube
                                                 , COMMENTS          = :f_comments
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND PKNUR9999 = :f_pknur9999";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE NUR9999
                                         WHERE HOSP_CODE = :f_hosp_code
                                           AND PKNUR9999 = :f_pknur9999";
                                break;
                        }

                        break;
                    #endregion
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            gbxInput.Enabled = false;

            cboPkInp1001.SetBindVarValue("f_bunho", paBox.BunHo);

            cboPkInp1001.SelectedIndexChanged -= new EventHandler(cboPkInp1001_SelectedIndexChanged);
            cboPkInp1001.SetDictDDLB();
            cboPkInp1001.SelectedIndex = 0;
            cboPkInp1001.SelectedIndexChanged += new EventHandler(cboPkInp1001_SelectedIndexChanged);

            grdNUR9999.QueryLayout(true);
        }

        private void grdNUR9999_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNUR9999.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdNUR9999.SetBindVarValue("f_fkinp1001", cboPkInp1001.GetDataValue());
        }

        private void cboPkInp1001_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdNUR9999.QueryLayout(true);
        }

        private void grdNUR9999_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {

            if (grdNUR9999.CurrentRowNumber > -1)
                gbxInput.Enabled = true;
            else
                gbxInput.Enabled = false;

            //여기에서 환자정보, 각 날짜등 셋팅

            //기록 정보가 있는 경우 (pk 키가 있는 경우)
            if (grdNUR9999.GetItemString(e.CurrentRow, "pknur9999") != "")
            {
                //레이블 이름 변경 전동OR퇴원
                ChangeGubunName(grdNUR9999.GetItemString(grdNUR9999.CurrentRowNumber, "gubun"));
                //grdnur9999 내용 각 컨트롤에 뿌리기
                SetGridToControl();
            }
            else  //신규 기록
            {
                ClearInputGroup();
                //초기값 세팅
                this.dtpWriteDate.SetDataValue(EnvironInfo.GetSysDate());
                this.txtBunho.SetDataValue(paBox.BunHo);
                this.txtSuname.SetDataValue(paBox.SuName);
                this.dtpBirth.SetDataValue(paBox.Birth);
                this.txtTel.SetDataValue(paBox.Tel);
                this.txtAddress.SetDataValue(paBox.Address1);
                this.cboGubun.SelectedIndex = 0;
                
                layPaInfo.QueryLayout();
            }
        }



        private void layPaInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            layPaInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layPaInfo.SetBindVarValue("f_write_date", dtpWriteDate.GetDataValue());
            layPaInfo.SetBindVarValue("f_fkinp1001", cboPkInp1001.GetDataValue());
        }

        private void DataValidating(object sender, DataValidatingEventArgs e)
        {
         
            Type type = sender.GetType();

            switch (type.Name)
            {       
                case "XDictComboBox":
                    XDictComboBox cbo = sender as XDictComboBox;
                    if (cbo != null)
                    {
                        grdNUR9999.SetItemValue(grdNUR9999.CurrentRowNumber, cbo.Tag.ToString(), cbo.GetDataValue());
                    }

                    break;

                case "XTextBox":
                    XTextBox txt = sender as XTextBox;

                    

                    if (txt != null)
                    {
                        if (Encoding.Default.GetByteCount(txt.Text) > txt.MaxLength)
                        {
                            XMessageBox.Show("入力内容が制限を超過しました。" + Encoding.Default.GetByteCount(txt.Text).ToString() + " / " + txt.MaxLength);
                            txt.Focus();
                        }
                        else
                        {
                            grdNUR9999.SetItemValue(grdNUR9999.CurrentRowNumber, txt.Tag.ToString(), txt.Text);
                        }
                    }

                    break;

                default:

                    Control ctl = sender as Control;
                    if (ctl != null)
                    {
                        grdNUR9999.SetItemValue(grdNUR9999.CurrentRowNumber, ctl.Tag.ToString(), ctl.Text);
                    }
                    break;
            }
        }

        private void layPaInfo_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //layPaInfo 레이아웃과 컨트롤은 바인딩 되어 있어서 바로 컨트롤에 값이 적용된다.
            //그것을 grdNUR9999에 적용하는 로직
            SetControlToGrid();            
        }

        private void ClearInputGroup()
        {
            foreach (Control ctl in gbxInput.Controls)
            {
                if (ctl.Tag != null)
                {
                    Type type = ctl.GetType();

                    switch (type.Name)
                    {
                        case "XDictComboBox":
                            XDictComboBox cbo = ctl as XDictComboBox;
                            cbo.SelectedIndex = 0;
                            cbo.AcceptData();
                            cbo.SelectedIndex = -1;
                            cbo.AcceptData();
                            break;

                        case "XTextBox":
                            XTextBox txt = ctl as XTextBox;
                            txt.Clear();
                            txt.AcceptData();
                            break;

                        case "XDatePicker":
                            XDatePicker dtp = ctl as XDatePicker;
                            dtp.Clear();
                            dtp.AcceptData();
                            break;
                    }

                }
            }
        }

        private void SetGridToControl()
        {
            foreach (Control ctl in gbxInput.Controls)
            {
                if (ctl.Tag != null)
                {
                    Type type = ctl.GetType();
                    switch (type.Name)
                    {
                        case "XDictComboBox":
                            XDictComboBox cbo = ctl as XDictComboBox;
                            if (cbo != null)
                            {
                                cbo.SetEditValue(grdNUR9999.GetItemString(grdNUR9999.CurrentRowNumber, cbo.Tag.ToString()));
                            }
                            break;

                        case "XTextBox":
                            XTextBox txt = ctl as XTextBox;
                            if (txt != null)
                            {
                                txt.SetEditValue(grdNUR9999.GetItemString(grdNUR9999.CurrentRowNumber, txt.Tag.ToString()));
                            }
                            break;
                            
                        case "XDatePicker":
                            XDatePicker dtp = ctl as XDatePicker;

                            if(dtp != null)
                            {
                                dtp.SetDataValue(grdNUR9999.GetItemString(grdNUR9999.CurrentRowNumber, dtp.Tag.ToString()));
                            }
                            break;                        
                    }
                }
            }
        }

        private void SetControlToGrid()
        {            
            foreach (Control ctl in gbxInput.Controls)
            {
                if (ctl.Tag != null)
                {
                    Type type = ctl.GetType();
                    switch (type.Name)
                    {
                        case "XDictComboBox":
                            XDictComboBox cbo = ctl as XDictComboBox;
                            if (cbo != null)
                            {
                                grdNUR9999.SetItemValue(grdNUR9999.CurrentRowNumber, cbo.Tag.ToString(), cbo.GetDataValue());
                            }
                            break;

                        case "XTextBox":
                            XTextBox txt = ctl as XTextBox;
                            if (txt != null)
                            {
                                grdNUR9999.SetItemValue(grdNUR9999.CurrentRowNumber, txt.Tag.ToString(), txt.Text);
                            }
                            break;

                        case "XDatePicker":
                            XDatePicker dtp = ctl as XDatePicker;
                            if (dtp != null)
                            {
                                grdNUR9999.SetItemValue(grdNUR9999.CurrentRowNumber, dtp.Tag.ToString(), dtp.GetDataValue());
                            }
                            break;

                        //default:

                        //    if (ctl != null)
                        //    {
                        //        grdNUR9999.SetItemValue(grdNUR9999.CurrentRowNumber, ctl.Tag.ToString(), ctl.Text);
                        //    }
                        //    break;
                    }
                }
            }
        }

        private void cboGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeGubunName(cboGubun.GetDataValue());
        }

        private void ChangeGubunName(string gubun)
        {
            if (gubun == "01")
            {
                lblToiwon_date.Text = "転棟年月日";
                lblReason.Text = "転　棟　事　由";
            }
            else
            {
                lblToiwon_date.Text = "退院年月日";
                lblReason.Text = "退　院　事　由";
            }
        }

        private void grdNUR9999_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (grdNUR9999.RowCount == 0)
            {
                ClearInputGroup();
                gbxInput.Enabled = false;
            }
        }

        private void paBox_PatientSelectionFailed(object sender, EventArgs e)
        {
            gbxInput.Enabled = false;   
            cboPkInp1001.SelectedIndex = -1;
            grdNUR9999.QueryLayout(true);
            ClearInputGroup();
        }

        private void grdNUR9999_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                XMessageBox.Show("保存が完了しました。", "保存", MessageBoxIcon.Asterisk);


                //this.grdNUR9999.QueryLayout(true);
            }
            else
            {
                XMessageBox.Show("保存に失敗しました。", "保存失敗", MessageBoxIcon.Error);

            }
        }
    }
}


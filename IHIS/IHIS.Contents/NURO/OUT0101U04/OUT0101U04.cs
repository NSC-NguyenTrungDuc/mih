#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.NURO.Properties;

#endregion

namespace IHIS.NURO
{
	/// <summary>
	/// OUT0101U04에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OUT0101U04 : IHIS.Framework.XScreen
	{
		#region 자동생성
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XLabel xLabel8;
		private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XLabel xLabel10;
		private IHIS.Framework.XLabel xLabel11;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XCheckBox cbxPaceMakerYN;
		private IHIS.Framework.XDictComboBox cboTelGubun3;
		private IHIS.Framework.XTextBox txtTelHP;
		private IHIS.Framework.XDictComboBox cboTelGubun2;
		private IHIS.Framework.XTextBox txtTel1;
		private IHIS.Framework.XDictComboBox cboTelGubun1;
		private IHIS.Framework.XTextBox txtTel;
		private IHIS.Framework.XTextBox txtAddress2;
		private IHIS.Framework.XFindBox fbxAddress1;
		private IHIS.Framework.XTextBox txtZipCode2;
		private IHIS.Framework.XFindBox fbxZipCode1;
		private IHIS.Framework.XDisplayBox dbxSex;
		private IHIS.Framework.XDisplayBox dbxBirth;
		private IHIS.Framework.XDisplayBox dbxSuname2;
		private IHIS.Framework.XDisplayBox dbxSuname;
		private IHIS.Framework.XEditGrid grdOUT0101;
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
		private IHIS.Framework.XLabel xLabel12;
		private IHIS.Framework.XTextBox txtEMail;
		private IHIS.Framework.XPanel pnlControl;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XCheckBox cbxSelfPaceMaker;
		private IHIS.Framework.XLabel xLabel13;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private const string CACHE_OUT0101U04_COMBO_TEL_KEYS = "Nuro.Out0101u04.cboTel";
		#endregion

        private string date_of_birth = "";

		public OUT0101U04()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            //TODO remove harcode
//            CacheService.Instance.Clear();

			this.SaveLayoutList.Add(this.grdOUT0101);
            //this.grdOUT0101.SavePerformer = new XSavePerformer(this);
            this.grdOUT0101.ExecuteQuery = GetDataForManagePatient;

		    InitializeCboTel();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OUT0101U04));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlControl = new IHIS.Framework.XPanel();
            this.cbxSelfPaceMaker = new IHIS.Framework.XCheckBox();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.grdOUT0101 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.dbxSuname2 = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.dbxBirth = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.dbxSex = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.fbxZipCode1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.txtZipCode2 = new IHIS.Framework.XTextBox();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.fbxAddress1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.txtAddress2 = new IHIS.Framework.XTextBox();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.txtTel = new IHIS.Framework.XTextBox();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.txtTel1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.txtTelHP = new IHIS.Framework.XTextBox();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.cboTelGubun1 = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.cboTelGubun2 = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.cboTelGubun3 = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.txtEMail = new IHIS.Framework.XTextBox();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.cbxPaceMakerYN = new IHIS.Framework.XCheckBox();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT0101)).BeginInit();
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
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // paBox
            // 
            this.paBox.AccessibleDescription = null;
            this.paBox.AccessibleName = null;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackgroundImage = null;
            this.paBox.Name = "paBox";
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlControl
            // 
            this.pnlControl.AccessibleDescription = null;
            this.pnlControl.AccessibleName = null;
            resources.ApplyResources(this.pnlControl, "pnlControl");
            this.pnlControl.BackgroundImage = null;
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.cbxSelfPaceMaker);
            this.pnlControl.Controls.Add(this.xLabel13);
            this.pnlControl.Controls.Add(this.grdOUT0101);
            this.pnlControl.Controls.Add(this.txtEMail);
            this.pnlControl.Controls.Add(this.xLabel12);
            this.pnlControl.Controls.Add(this.cbxPaceMakerYN);
            this.pnlControl.Controls.Add(this.xLabel11);
            this.pnlControl.Controls.Add(this.cboTelGubun3);
            this.pnlControl.Controls.Add(this.txtTelHP);
            this.pnlControl.Controls.Add(this.cboTelGubun2);
            this.pnlControl.Controls.Add(this.txtTel1);
            this.pnlControl.Controls.Add(this.cboTelGubun1);
            this.pnlControl.Controls.Add(this.xLabel10);
            this.pnlControl.Controls.Add(this.txtTel);
            this.pnlControl.Controls.Add(this.xLabel9);
            this.pnlControl.Controls.Add(this.xLabel8);
            this.pnlControl.Controls.Add(this.txtAddress2);
            this.pnlControl.Controls.Add(this.fbxAddress1);
            this.pnlControl.Controls.Add(this.txtZipCode2);
            this.pnlControl.Controls.Add(this.xLabel7);
            this.pnlControl.Controls.Add(this.fbxZipCode1);
            this.pnlControl.Controls.Add(this.xLabel6);
            this.pnlControl.Controls.Add(this.dbxSex);
            this.pnlControl.Controls.Add(this.xLabel5);
            this.pnlControl.Controls.Add(this.dbxBirth);
            this.pnlControl.Controls.Add(this.xLabel4);
            this.pnlControl.Controls.Add(this.dbxSuname2);
            this.pnlControl.Controls.Add(this.xLabel3);
            this.pnlControl.Controls.Add(this.dbxSuname);
            this.pnlControl.Controls.Add(this.xLabel2);
            this.pnlControl.Controls.Add(this.xLabel1);
            this.pnlControl.Font = null;
            this.pnlControl.Name = "pnlControl";
            // 
            // cbxSelfPaceMaker
            // 
            this.cbxSelfPaceMaker.AccessibleDescription = null;
            this.cbxSelfPaceMaker.AccessibleName = null;
            resources.ApplyResources(this.cbxSelfPaceMaker, "cbxSelfPaceMaker");
            this.cbxSelfPaceMaker.BackgroundImage = null;
            this.cbxSelfPaceMaker.Name = "cbxSelfPaceMaker";
            this.cbxSelfPaceMaker.UseVisualStyleBackColor = false;
            this.cbxSelfPaceMaker.CheckedChanged += new System.EventHandler(this.cbxSelfPaceMaker_CheckedChanged);
            // 
            // xLabel13
            // 
            this.xLabel13.AccessibleDescription = null;
            this.xLabel13.AccessibleName = null;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.Image = null;
            this.xLabel13.Name = "xLabel13";
            // 
            // grdOUT0101
            // 
            resources.ApplyResources(this.grdOUT0101, "grdOUT0101");
            this.grdOUT0101.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell17,
            this.xEditGridCell16,
            this.xEditGridCell18});
            this.grdOUT0101.ColPerLine = 18;
            this.grdOUT0101.Cols = 18;
            this.grdOUT0101.ControlBinding = true;
            this.grdOUT0101.ExecuteQuery = null;
            this.grdOUT0101.FixedRows = 1;
            this.grdOUT0101.HeaderHeights.Add(18);
            this.grdOUT0101.Name = "grdOUT0101";
            this.grdOUT0101.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOUT0101.ParamList")));
            this.grdOUT0101.QuerySQL = resources.GetString("grdOUT0101.QuerySQL");
            this.grdOUT0101.Rows = 2;
            this.grdOUT0101.ToolTipActive = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.CellWidth = 81;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.BindControl = this.dbxSuname;
            this.xEditGridCell2.CellName = "suname";
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // dbxSuname
            // 
            this.dbxSuname.AccessibleDescription = null;
            this.dbxSuname.AccessibleName = null;
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Image = null;
            this.dbxSuname.Name = "dbxSuname";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.BindControl = this.dbxSuname2;
            this.xEditGridCell3.CellName = "suname2";
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // dbxSuname2
            // 
            this.dbxSuname2.AccessibleDescription = null;
            this.dbxSuname2.AccessibleName = null;
            resources.ApplyResources(this.dbxSuname2, "dbxSuname2");
            this.dbxSuname2.Image = null;
            this.dbxSuname2.Name = "dbxSuname2";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "birth";
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // dbxBirth
            // 
            this.dbxBirth.AccessibleDescription = null;
            this.dbxBirth.AccessibleName = null;
            resources.ApplyResources(this.dbxBirth, "dbxBirth");
            this.dbxBirth.EditMaskType = IHIS.Framework.MaskType.Date;
            this.dbxBirth.Image = null;
            this.dbxBirth.Name = "dbxBirth";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.BindControl = this.dbxSex;
            this.xEditGridCell5.CellName = "sex";
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // dbxSex
            // 
            this.dbxSex.AccessibleDescription = null;
            this.dbxSex.AccessibleName = null;
            resources.ApplyResources(this.dbxSex, "dbxSex");
            this.dbxSex.Image = null;
            this.dbxSex.Name = "dbxSex";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.BindControl = this.fbxZipCode1;
            this.xEditGridCell6.CellName = "zip_code1";
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // fbxZipCode1
            // 
            this.fbxZipCode1.AccessibleDescription = null;
            this.fbxZipCode1.AccessibleName = null;
            resources.ApplyResources(this.fbxZipCode1, "fbxZipCode1");
            this.fbxZipCode1.ApplyByteLimit = true;
            this.fbxZipCode1.AutoTabDataSelected = true;
            this.fbxZipCode1.BackgroundImage = null;
            this.fbxZipCode1.Name = "fbxZipCode1";
            this.fbxZipCode1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxZipCode1_DataValidating);
            this.fbxZipCode1.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.BindControl = this.txtZipCode2;
            this.xEditGridCell7.CellName = "zip_code2";
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // txtZipCode2
            // 
            this.txtZipCode2.AccessibleDescription = null;
            this.txtZipCode2.AccessibleName = null;
            resources.ApplyResources(this.txtZipCode2, "txtZipCode2");
            this.txtZipCode2.ApplyByteLimit = true;
            this.txtZipCode2.BackgroundImage = null;
            this.txtZipCode2.Name = "txtZipCode2";
            this.txtZipCode2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtZipCode2_DataValidating);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.BindControl = this.fbxAddress1;
            this.xEditGridCell8.CellName = "address1";
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // fbxAddress1
            // 
            this.fbxAddress1.AccessibleDescription = null;
            this.fbxAddress1.AccessibleName = null;
            resources.ApplyResources(this.fbxAddress1, "fbxAddress1");
            this.fbxAddress1.ApplyByteLimit = true;
            this.fbxAddress1.AutoTabDataSelected = true;
            this.fbxAddress1.BackgroundImage = null;
            this.fbxAddress1.Name = "fbxAddress1";
            this.fbxAddress1.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.BindControl = this.txtAddress2;
            this.xEditGridCell9.CellName = "address2";
            this.xEditGridCell9.Col = 8;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            // 
            // txtAddress2
            // 
            this.txtAddress2.AccessibleDescription = null;
            this.txtAddress2.AccessibleName = null;
            resources.ApplyResources(this.txtAddress2, "txtAddress2");
            this.txtAddress2.ApplyByteLimit = true;
            this.txtAddress2.BackgroundImage = null;
            this.txtAddress2.Name = "txtAddress2";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.BindControl = this.txtTel;
            this.xEditGridCell10.CellName = "tel";
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            // 
            // txtTel
            // 
            this.txtTel.AccessibleDescription = null;
            this.txtTel.AccessibleName = null;
            resources.ApplyResources(this.txtTel, "txtTel");
            this.txtTel.ApplyByteLimit = true;
            this.txtTel.BackgroundImage = null;
            this.txtTel.Name = "txtTel";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.BindControl = this.txtTel1;
            this.xEditGridCell11.CellName = "tel1";
            this.xEditGridCell11.Col = 10;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // txtTel1
            // 
            this.txtTel1.AccessibleDescription = null;
            this.txtTel1.AccessibleName = null;
            resources.ApplyResources(this.txtTel1, "txtTel1");
            this.txtTel1.ApplyByteLimit = true;
            this.txtTel1.BackgroundImage = null;
            this.txtTel1.Name = "txtTel1";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.BindControl = this.txtTelHP;
            this.xEditGridCell12.CellName = "tel_hp";
            this.xEditGridCell12.Col = 11;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            // 
            // txtTelHP
            // 
            this.txtTelHP.AccessibleDescription = null;
            this.txtTelHP.AccessibleName = null;
            resources.ApplyResources(this.txtTelHP, "txtTelHP");
            this.txtTelHP.ApplyByteLimit = true;
            this.txtTelHP.BackgroundImage = null;
            this.txtTelHP.Name = "txtTelHP";
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.BindControl = this.cboTelGubun1;
            this.xEditGridCell13.CellName = "tel_gubun";
            this.xEditGridCell13.Col = 12;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            // 
            // cboTelGubun1
            // 
            this.cboTelGubun1.AccessibleDescription = null;
            this.cboTelGubun1.AccessibleName = null;
            resources.ApplyResources(this.cboTelGubun1, "cboTelGubun1");
            this.cboTelGubun1.BackgroundImage = null;
            this.cboTelGubun1.ExecuteQuery = null;
            this.cboTelGubun1.Name = "cboTelGubun1";
            this.cboTelGubun1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTelGubun1.ParamList")));
            this.cboTelGubun1.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.BindControl = this.cboTelGubun2;
            this.xEditGridCell14.CellName = "tel_gubun2";
            this.xEditGridCell14.Col = 13;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            // 
            // cboTelGubun2
            // 
            this.cboTelGubun2.AccessibleDescription = null;
            this.cboTelGubun2.AccessibleName = null;
            resources.ApplyResources(this.cboTelGubun2, "cboTelGubun2");
            this.cboTelGubun2.BackgroundImage = null;
            this.cboTelGubun2.ExecuteQuery = null;
            this.cboTelGubun2.Name = "cboTelGubun2";
            this.cboTelGubun2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTelGubun2.ParamList")));
            this.cboTelGubun2.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.BindControl = this.cboTelGubun3;
            this.xEditGridCell15.CellName = "tel_gubun3";
            this.xEditGridCell15.Col = 14;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            // 
            // cboTelGubun3
            // 
            this.cboTelGubun3.AccessibleDescription = null;
            this.cboTelGubun3.AccessibleName = null;
            resources.ApplyResources(this.cboTelGubun3, "cboTelGubun3");
            this.cboTelGubun3.BackgroundImage = null;
            this.cboTelGubun3.ExecuteQuery = null;
            this.cboTelGubun3.Name = "cboTelGubun3";
            this.cboTelGubun3.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTelGubun3.ParamList")));
            this.cboTelGubun3.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.BindControl = this.txtEMail;
            this.xEditGridCell17.CellName = "e_mail";
            this.xEditGridCell17.Col = 16;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            // 
            // txtEMail
            // 
            this.txtEMail.AccessibleDescription = null;
            this.txtEMail.AccessibleName = null;
            resources.ApplyResources(this.txtEMail, "txtEMail");
            this.txtEMail.ApplyByteLimit = true;
            this.txtEMail.BackgroundImage = null;
            this.txtEMail.Name = "txtEMail";
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.BindControl = this.cbxPaceMakerYN;
            this.xEditGridCell16.CellName = "pace_maker_yn";
            this.xEditGridCell16.Col = 15;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            // 
            // cbxPaceMakerYN
            // 
            this.cbxPaceMakerYN.AccessibleDescription = null;
            this.cbxPaceMakerYN.AccessibleName = null;
            resources.ApplyResources(this.cbxPaceMakerYN, "cbxPaceMakerYN");
            this.cbxPaceMakerYN.BackgroundImage = null;
            this.cbxPaceMakerYN.Name = "cbxPaceMakerYN";
            this.cbxPaceMakerYN.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.BindControl = this.cbxSelfPaceMaker;
            this.xEditGridCell18.CellName = "self_pace_maker";
            this.xEditGridCell18.Col = 17;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            // 
            // xLabel12
            // 
            this.xLabel12.AccessibleDescription = null;
            this.xLabel12.AccessibleName = null;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.Image = null;
            this.xLabel12.Name = "xLabel12";
            // 
            // xLabel11
            // 
            this.xLabel11.AccessibleDescription = null;
            this.xLabel11.AccessibleName = null;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.Image = null;
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel10
            // 
            this.xLabel10.AccessibleDescription = null;
            this.xLabel10.AccessibleName = null;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.Image = null;
            this.xLabel10.Name = "xLabel10";
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Image = null;
            this.xLabel1.ImageList = this.ImageList;
            this.xLabel1.Name = "xLabel1";
            // 
            // OUT0101U04
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xPanel1);
            this.Name = "OUT0101U04";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OUT0101U04_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OUT0101U04_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT0101)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region [환자정보 Reques/Receive Event]
        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                this.paBox.Focus();
                this.paBox.SetPatientID(info.BunHo);
            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
            {
                return new XPatientInfo(this.paBox.BunHo.ToString(), "", "", "", this.ScreenName);
            }

            return null;
        }
        #endregion

		#region Screen 변수

		// 메세지 관련 변수
		private string mMsg = "";
		private string mCap = "";

		#endregion

		#region Function

		#region InitScreen 

		private void InitScreen ()
		{
			if (this.OpenParam != null)
			{
				if (this.OpenParam.Contains("bunho"))
				{
					this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
					this.paBox.IsEditableBunho = false;

					return;
				}
			}
			
			this.ControlProtect (true);
		}

		#endregion

		#region Control Protect 

		private void ControlProtect (bool aIsProtect)
		{
			foreach (Control control in this.pnlControl.Controls)
			{
				if (control is IDataControl)
				{
					((IDataControl)(control)).Protect = aIsProtect ;
				}
			}
		}

		#endregion

		#region Clear

		private void ClearControl ()
		{
			this.Reset();

			this.ControlProtect(true);
		}

		#endregion

		#endregion

		#region OpenScreen 

		/// <summary>
		/// 우편번호 검색 창
		/// </summary>
		/// <param name="aSearchGubun"></param>
		private void OpenScreen_BAS0123Q00(string aSearchGubun, string aZipCode1, string aZipCode2, string aAddress)
		{
			CommonItemCollection param = new CommonItemCollection();

			if (aSearchGubun == "zipCode")
			{
				param.Add("SearchGubun", aSearchGubun);
				param.Add("zip_code1", fbxZipCode1.GetDataValue());
				param.Add("zip_code2", txtZipCode2.GetDataValue());
			}
			else
			{
				param.Add("SearchGubun", aSearchGubun);
				param.Add("address", this.fbxAddress1.GetDataValue());
			}

			XScreen.OpenScreenWithParam(this, "BASS", "BAS0123Q00", ScreenOpenStyle.ResponseFixed, param);
		}

		#endregion

        #region
        public override object Command(string command, CommonItemCollection commandParam)
        {
            this.fbxZipCode1.SetDataValue(commandParam["zip_code1"]);
            this.txtZipCode2.SetDataValue(commandParam["zip_code2"]);
            this.fbxAddress1.SetEditValue(commandParam["address"]);
            this.fbxAddress1.AcceptData();
            this.grdOUT0101.SetItemValue(grdOUT0101.CurrentRowNumber, "zip_code1", commandParam["zip_code1"]);
            this.grdOUT0101.SetItemValue(grdOUT0101.CurrentRowNumber, "zip_code2", commandParam["zip_code2"]);

            this.txtAddress2.Focus();
            return base.Command(command, commandParam);
        }

        #endregion

        #region DataLoad

        private void LoadOUT0101 ()
        {
            this.grdOUT0101.ParamList = CreateListParam();
            this.grdOUT0101.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.grdOUT0101.SetBindVarValue("f_bunho", this.paBox.BunHo);

			if(!this.grdOUT0101.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : grdOUT0101 Query Error");
				return;
			}
            date_of_birth = grdOUT0101.GetItemString(grdOUT0101.CurrentRowNumber, "birth");
            DateTime dt = Convert.ToDateTime(date_of_birth);
            if (NetInfo.Language == LangMode.Vi)
            {
                dbxBirth.Text = dt.ToString("dd/MM/yyyy");
                fbxZipCode1.Enabled = false;
                fbxAddress1.Enabled = false;

            }
            else
            {
                dbxBirth.Text = dt.ToString("yyyy/MM/dd");
            }
            
            //if (NetInfo.Language == LangMode.Vi)
            //{
            //    fbxZipCode1.Enabled = false;
            //    fbxAddress1.Enabled = false;
            //    DateTime dt = Convert.ToDateTime(date_of_birth);
            //    dbxBirth.Text = dt.ToString("dd/mm/yyyy");
            //}
            //else
            //{
            //    dbxBirth.Text = date_of_birth;
            //}

		}

		private void UpDateData ()
		{
			try
            {
                mIsSaveSuccess = true;
                //Service.BeginTransaction();

                //if (this.grdOUT0101.SaveLayout())
                //{
                //    Service.CommitTransaction();
                //    this.mMsg = Resources.MSG001_MSG;
                //    this.mCap = Resources.MSG001_CAP;

                //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
                //else
                //{
                //    Service.RollbackTransaction();
                //    this.mMsg = Resources.MSG002_MSG;
                //    this.mMsg += " - " + Service.ErrFullMsg;
                //    this.mCap = Resources.MSG002_CAP;

                //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                if (SaveGrdOUT0101())
                {
                    this.mMsg = Resources.MSG001_MSG;
                    this.mCap = Resources.MSG001_CAP;

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    this.mMsg = Resources.MSG002_MSG;
                    this.mMsg += " - " + Service.ErrFullMsg;
                    this.mCap = Resources.MSG002_CAP;

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			}
			catch(Exception ex)
			{
                //Service.RollbackTransaction();
                mIsSaveSuccess = false;
                //https://sofiamedix.atlassian.net/browse/MED-10610
				//XMessageBox.Show(ex.Message + " : SavePerfomer Error");
			}
			
		}

	    private bool SaveGrdOUT0101()
	    {
	        List<NuroManagePatientInfo> inputList = GetListFromGrdOUT0101();
	        if (inputList.Count == 0)
	        {
	            return true;
	        }
            OUT0101U04SaveLayoutArgs args = new OUT0101U04SaveLayoutArgs(UserInfo.UserID, inputList);
	        UpdateResult result = CloudService.Instance.Submit<UpdateResult, OUT0101U04SaveLayoutArgs>(args);
	        if (result.ExecutionStatus == ExecutionStatus.Success)
	        {
	            return result.Result;
	        }
	        return false;
	    }

	    private List<NuroManagePatientInfo> GetListFromGrdOUT0101()
	    {
	        List<NuroManagePatientInfo> dataList = new List<NuroManagePatientInfo>();
	        for (int i = 0; i < grdOUT0101.RowCount; i++)
	        {
	            if (grdOUT0101.GetRowState(i) == DataRowState.Unchanged)
	            {
	                continue;
	            }

	            NuroManagePatientInfo info = new NuroManagePatientInfo();
                info.PatientCode = grdOUT0101.GetItemString(i, "bunho");
                info.PatientName1 = grdOUT0101.GetItemString(i, "suname");
                info.PatientName2 = grdOUT0101.GetItemString(i, "suname2");
                info.Birth = grdOUT0101.GetItemString(i, "birth");
                info.Sex = grdOUT0101.GetItemString(i, "sex");
                info.ZipCode1 = grdOUT0101.GetItemString(i, "zip_code1");
                info.ZipCode2 = grdOUT0101.GetItemString(i, "zip_code2");
                info.Address1 = grdOUT0101.GetItemString(i, "address1");
                info.Address2 = grdOUT0101.GetItemString(i, "address2");
                info.Tel = grdOUT0101.GetItemString(i, "tel");
                info.Tel1 = grdOUT0101.GetItemString(i, "tel1");
                info.TelHp = grdOUT0101.GetItemString(i, "tel_hp");
                info.TelType = grdOUT0101.GetItemString(i, "tel_gubun");
                info.TelType2 = grdOUT0101.GetItemString(i, "tel_gubun2");
                info.TelType3 = grdOUT0101.GetItemString(i, "tel_gubun3");
                info.EMail = grdOUT0101.GetItemString(i, "e_mail");
                info.PaceMakerYn = grdOUT0101.GetItemString(i, "pace_maker_yn");
                info.SelfPaceMaker = grdOUT0101.GetItemString(i, "self_pace_maker");

                dataList.Add(info);
	        }
	        return dataList;
	    }

	    #endregion

		#region XFindBox 

		private void FindBox_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			XFindBox control = sender as XFindBox ;
            string zipCode1 = "";
            string zipCode2 = "";
            string address1 = "";
			switch (control.Name)
			{
                case "fbxZipCode1":
                    zipCode1 = this.fbxZipCode1.GetDataValue();
                    zipCode2 = this.txtZipCode2.GetDataValue();
                    address1 = this.fbxAddress1.GetDataValue();
                    this.OpenScreen_BAS0123Q00("zipCode", zipCode1, zipCode2, address1);
					break;
                case "fbxAddress1":
                    zipCode1 = this.fbxZipCode1.GetDataValue();
                    zipCode2 = this.txtZipCode2.GetDataValue();
                    address1 = this.fbxAddress1.GetDataValue();
                    this.OpenScreen_BAS0123Q00("address", zipCode1, zipCode2, address1);
					break;
			}
		}

		#endregion

		#region DataValidating

		private void txtZipCode2_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string name = "";

			if (e.DataValue == "")
			{
				this.fbxAddress1.SetDataValue("");
				this.txtAddress2.SetDataValue("");
				return ;
			}

//            string cmdText = @"SELECT A.ZIP_NAME1 || A.ZIP_NAME2 || A.ZIP_NAME3
//							     FROM BAS0123 A
//							    WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE
//                                  AND A.ZIP_CODE = :f_zip_code1 || :f_zip_code2";

//            BindVarCollection bindVars = new BindVarCollection();
//            bindVars.Add("f_zip_code1", this.fbxZipCode1.GetDataValue());
//            bindVars.Add("f_zip_code2", e.DataValue);

//            object retVal = Service.ExecuteScalar(cmdText, bindVars);

            OUT0101U04TxtZipCode2DataValidatingArgs args = new OUT0101U04TxtZipCode2DataValidatingArgs();
		    args.ZipCode1 = this.fbxZipCode1.GetDataValue();
		    args.ZipCode2 = e.DataValue;

		    OUT0101U04TxtZipCode2DataValidatingResult result =
		        CloudService.Instance
		            .Submit<OUT0101U04TxtZipCode2DataValidatingResult, OUT0101U04TxtZipCode2DataValidatingArgs>(args);

            //if(retVal == null)
			if(result.ExecutionStatus != ExecutionStatus.Success)
			{
				XMessageBox.Show(Service.ErrFullMsg + " : Zip_Name");
				return;
			}

            //if (retVal.ToString() == "")
			if (result.RetVal == "")
			{
				this.mMsg = Resources.MSG003_MSG;
				this.SetMsg(this.mMsg, MsgType.Error);
				e.Cancel = true;
				return;
			}
			else
			{
				this.fbxAddress1.SetEditValue(name);
				this.fbxAddress1.AcceptData();
			}
		}

		private void fbxZipCode1_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue != "")
			{
				this.txtZipCode2.SetEditValue("");
				this.txtZipCode2.AcceptData();
			}
		}

		#endregion

		#region Screen Open 

		private void OUT0101U04_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            this.InitScreen();

            // 값을 받아서 조회함
            if (this.OpenParam != null)
            {
                if (OpenParam.Contains("bunho"))
                {
                    paBox.SetPatientID(this.OpenParam["bunho"].ToString());
                }
            }
            else
            {
                //현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    paBox.SetPatientID(patientInfo.BunHo);
                }
            }
            //this.cboTelGubun1.ParamList = CreateParamForCboTel();
            //this.cboTelGubun1.SetBindVarValue("code_type", Resources.TEL_GUBUN);
            //this.cboTelGubun1.SetDictDDLB();
            //this.cboTelGubun2.ParamList = CreateParamForCboTel();
            //this.cboTelGubun2.SetBindVarValue("code_type", Resources.TEL_GUBUN);
            //this.cboTelGubun2.SetDictDDLB();
            //this.cboTelGubun3.ParamList = CreateParamForCboTel();
            //this.cboTelGubun3.SetBindVarValue("code_type", Resources.TEL_GUBUN);
            //this.cboTelGubun3.SetDictDDLB();

//		    InitializeCboTel();
		}



	    #endregion

		#region XPatientBox

		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			this.ControlProtect(false);

			this.btnList.PerformClick(FunctionType.Query);
		}

		private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			this.ClearControl();
		}

		#endregion

		#region XButtonList
        private bool mIsSaveSuccess = true;
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:

					e.IsBaseCall = false;

					this.LoadOUT0101();

					PostCallHelper.PostCall(new PostMethod(PostLoad));

					break;

				case FunctionType.Update :

					e.IsBaseCall = false;

					this.AcceptData();

					this.UpDateData();

                    this.grdOUT0101.ResetUpdate();

					break;
			}
		}

		private void PostLoad ()
		{
			this.fbxZipCode1.Focus();
		}

        #endregion

        #region cbxSelfPaceMaker_CheckedChanged
        private void cbxSelfPaceMaker_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (cb.Checked)
            {
                this.cbxPaceMakerYN.Checked = true;
            }
        }
        #endregion

		#region 저장로직
//        private class XSavePerformer : IHIS.Framework.ISavePerformer
//        {
//            private OUT0101U04 parent = null;

//            public XSavePerformer(OUT0101U04 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callID, RowDataItem item)
//            {
//                bool resultUpdate = false;
//                String cmdQry = null;

//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                item.BindVarList.Add("f_user_id", UserInfo.UserID);
				
//                switch(item.RowState)
//                {
//                    case DataRowState.Modified:
////						cmdQry = "UPDATE OUT0101"
////								+"   SET ZIP_CODE1          = :f_zip_code1"
////								+"     , ZIP_CODE2          = :f_zip_code2"
////								+"     , ADDRESS1           = :f_address1"
////								+"     , ADDRESS2           = :f_address2"
////								+"     , TEL                = :f_tel"
////								+"     , TEL1               = :f_tel1"
////								+"     , TEL_HP             = :f_tel_hp"
////								+"     , TEL_GUBUN          = :f_tel_gubun"
////								+"     , TEL_GUBUN2         = :f_tel_gubun2"
////								+"     , TEL_GUBUN3         = :f_tel_gubun3"
////								+"     , EMAIL              = :f_e_mail"
////								+"     , PACE_MAKER_YN      = :f_pace_maker_yn"
////								+"     , SELF_PACE_MAKER    = :f_self_pace_maker"
////                                +" WHERE HOSP_CODE          = :f_hosp_code "
////                                +"   AND BUNHO              = :f_bunho";
//                        BindVarCollection bindVarCollection = item.BindVarList;
//                        NuroManagePatientUpdateData managePatientUpdateData =
//                            new NuroManagePatientUpdateData(bindVarCollection["f_zip_code1"].VarValue,
//                                bindVarCollection["f_zip_code2"].VarValue,
//                                bindVarCollection["f_address1"].VarValue, bindVarCollection["f_address2"].VarValue,
//                                bindVarCollection["f_tel"].VarValue, bindVarCollection["f_tel1"].VarValue,
//                                bindVarCollection["f_tel_hp"].VarValue, bindVarCollection["f_tel_gubun"].VarValue,
//                                bindVarCollection["f_tel_gubun2"].VarValue,
//                                bindVarCollection["f_tel_gubun3"].VarValue, bindVarCollection["f_e_mail"].VarValue,
//                                bindVarCollection["f_pace_maker_yn"].VarValue,
//                                bindVarCollection["f_self_pace_maker"].VarValue, bindVarCollection["f_bunho"].VarValue);
//                        NuroManagePatientUpdateAgrs managePatientUpdateAgrs = new NuroManagePatientUpdateAgrs(managePatientUpdateData);
//                        NuroManagePatientUpdateResult patientUpdateResult =
//                            CloudService.Instance.Submit<NuroManagePatientUpdateResult, NuroManagePatientUpdateAgrs>(managePatientUpdateAgrs);
//                        resultUpdate = patientUpdateResult.ResultUpdate;
//                        break;
//                        // connect to server return value;
//                }
////				return Service.ExecuteNonQuery(cmdQry,item.BindVarList);
//                return resultUpdate;
//            }
//        }
		#endregion

        private void OUT0101U04_Closing(object sender, CancelEventArgs e)
        {
            if (!this.mIsSaveSuccess)
            {
                e.Cancel = true;
            }

            this.mIsSaveSuccess = true;

        }

        #region CreateListParam, GetDataForManagePatient
        private IList<object[]> GetDataForManagePatient(BindVarCollection lisCollection)
	    {
            IList<object[]> lstDataResult = new List<object[]>();
            NuroManagePatientArgs managePatientArgs = new NuroManagePatientArgs(lisCollection["f_bunho"].VarValue);
            NuroManagePatientResult nuroManagePatientResult =
                CloudService.Instance.Submit<NuroManagePatientResult, NuroManagePatientArgs>(managePatientArgs);

            if (nuroManagePatientResult != null)
            {
                IList<NuroManagePatientInfo> lstManagePatientInfos = nuroManagePatientResult.LstManagePatientInfos;
                foreach (NuroManagePatientInfo managePatientInfo in lstManagePatientInfos)
                {
                    object[] data =
                    {
                        managePatientInfo.PatientCode,
                        managePatientInfo.PatientName1,
                        managePatientInfo.PatientName2,
                        managePatientInfo.Birth,
                        managePatientInfo.Sex,
                        managePatientInfo.ZipCode1,
                        managePatientInfo.ZipCode2,
                        managePatientInfo.Address1,
                        managePatientInfo.Address2,
                        managePatientInfo.Tel,
                        managePatientInfo.Tel1,
                        managePatientInfo.TelHp,
                        managePatientInfo.TelType,
                        managePatientInfo.TelType2,
                        managePatientInfo.TelType3,
                        managePatientInfo.EMail,
                        managePatientInfo.PaceMakerYn,
                        managePatientInfo.SelfPaceMaker
                    };
                lstDataResult.Add(data);
                }
            }
                
            return lstDataResult;
	    }

	    private List<string> CreateListParam()
	    {
            List<string> lstParam = new List<string>();
            lstParam.Add("f_hosp_code");
            lstParam.Add("f_bunho");
	        return lstParam;
	    }
	    #endregion

        #region CreateParamForCboTel, GetDataForCboSelectTel

        //private List<string> CreateParamForCboTel()
        //{
        //    List<string> lstParam = new List<string>();
        //    lstParam.Add("code_type");
        //    return lstParam;
        //}

        //private IList<object[]> GetDataForCboSelectTel(BindVarCollection bindVarCollection)
        //{
        //    IList<object[]> lstDataResult = new List<object[]>();
        //    try
        //    {
        //        ComboListByCodeTypeArgs comboListByCodeTypeArgs = new ComboListByCodeTypeArgs(bindVarCollection["code_type"].VarValue, true);
        //        ComboListItemResult result =
        //            CloudService.Instance.Submit<ComboListItemResult, ComboListByCodeTypeArgs>(
        //                comboListByCodeTypeArgs);
        //        if (result != null)
        //        {
        //            IList<ComboListItemInfo> listItemInfos = result.ListItemInfos;
        //            if (listItemInfos != null)
        //            {
        //                foreach (ComboListItemInfo comboListItemInfo in  listItemInfos)
        //                {
        //                    object[] cboItem =
        //                    {
        //                        comboListItemInfo.Code,
        //                        comboListItemInfo.CodeName
        //                    };
        //                    lstDataResult.Add(cboItem);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
	            
        //        throw;
        //    }
        //    return lstDataResult;
        //}


        private void InitializeCboTel()
        {
            IList<object[]> lstDataResult = new List<object[]>();
            try
            {
                InitializeComboListItemArgs args = new InitializeComboListItemArgs();
                args.CodeTypeCboTel = Resources.TEL_GUBUN;

                InitializeComboListItemResult result = CacheService.Instance.Get<InitializeComboListItemArgs, InitializeComboListItemResult>(args, delegate(InitializeComboListItemResult itemResult)
                {
                    return itemResult != null && itemResult.ExecutionStatus == ExecutionStatus.Success;
                });
                if (result != null)
                {
                    IList<ComboListItemInfo> listItemInfos = result.ComboTelItem;
                    if (listItemInfos != null)
                    {
                        foreach (ComboListItemInfo comboListItemInfo in listItemInfos)
                        {
                            object[] cboItem =
                                {
                                    comboListItemInfo.Code,
                                    comboListItemInfo.CodeName
                                };
                            lstDataResult.Add(cboItem);
                        }
                    }
                    this.cboTelGubun1.SetDictDDLB(lstDataResult);
                    this.cboTelGubun2.SetDictDDLB(lstDataResult);
                    this.cboTelGubun3.SetDictDDLB(lstDataResult);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
	}
}


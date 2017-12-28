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
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0270Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0270Q00 : IHIS.Framework.XScreen
	{
		#region 화면변수
		private string aOsim_gubun  = string.Empty;
		private string aAll_gubun   = string.Empty;
		private string aQuery_gubun = "N";
		private string aGwa         = string.Empty;
		private string aOp_yn       = string.Empty;
		private string aJukyong_date = IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
        private bool aReserOutYn = false;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlTopTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XEditGrid grdBAS0270;
		private IHIS.Framework.XLabel lblGwa;
		private IHIS.Framework.XBuseoCombo cboGwa;
		private IHIS.Framework.XPanel pnlRbTop;
		private IHIS.Framework.XRadioButton rbAll;
		private IHIS.Framework.XRadioButton rbA;
		private IHIS.Framework.XRadioButton rbK;
		private IHIS.Framework.XRadioButton rbS;
		private IHIS.Framework.XRadioButton rbT;
		private IHIS.Framework.XRadioButton rbN;
		private IHIS.Framework.XRadioButton rbH;
		private IHIS.Framework.XRadioButton rbM;
		private IHIS.Framework.XRadioButton rbY;
		private IHIS.Framework.XRadioButton rbR;
		private IHIS.Framework.XRadioButton rbW;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XLabel lblQuery;
		private IHIS.Framework.XTextBox txtQuery;
		private IHIS.Framework.XLabel lblDoctor_grade;
        private IHIS.Framework.XDictComboBox cboDoctor_grade;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자

	    public OCS0270Q00()
	    {
	        // 이 호출은 Windows Form 디자이너에 필요합니다.
	        InitializeComponent();

	        cboDoctor_grade.ExecuteQuery = ComboDoctorGrade;
	        cboDoctor_grade.SetDictDDLB();

	        grdBAS0270.ParamList = GridParamList();
	        grdBAS0270.ExecuteQuery = GridList;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0270Q00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cboDoctor_grade = new IHIS.Framework.XDictComboBox();
            this.lblDoctor_grade = new IHIS.Framework.XLabel();
            this.txtQuery = new IHIS.Framework.XTextBox();
            this.lblQuery = new IHIS.Framework.XLabel();
            this.cboGwa = new IHIS.Framework.XBuseoCombo();
            this.lblGwa = new IHIS.Framework.XLabel();
            this.pnlTopTop = new IHIS.Framework.XPanel();
            this.pnlRbTop = new IHIS.Framework.XPanel();
            this.rbA = new IHIS.Framework.XRadioButton();
            this.rbK = new IHIS.Framework.XRadioButton();
            this.rbS = new IHIS.Framework.XRadioButton();
            this.rbT = new IHIS.Framework.XRadioButton();
            this.rbN = new IHIS.Framework.XRadioButton();
            this.rbH = new IHIS.Framework.XRadioButton();
            this.rbM = new IHIS.Framework.XRadioButton();
            this.rbY = new IHIS.Framework.XRadioButton();
            this.rbR = new IHIS.Framework.XRadioButton();
            this.rbW = new IHIS.Framework.XRadioButton();
            this.rbAll = new IHIS.Framework.XRadioButton();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdBAS0270 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).BeginInit();
            this.pnlTopTop.SuspendLayout();
            this.pnlRbTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0270)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cboDoctor_grade);
            this.pnlTop.Controls.Add(this.lblDoctor_grade);
            this.pnlTop.Controls.Add(this.txtQuery);
            this.pnlTop.Controls.Add(this.lblQuery);
            this.pnlTop.Controls.Add(this.cboGwa);
            this.pnlTop.Controls.Add(this.lblGwa);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // cboDoctor_grade
            // 
            this.cboDoctor_grade.ExecuteQuery = null;
            resources.ApplyResources(this.cboDoctor_grade, "cboDoctor_grade");
            this.cboDoctor_grade.Name = "cboDoctor_grade";
            this.cboDoctor_grade.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboDoctor_grade.ParamList")));
            this.cboDoctor_grade.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDoctor_grade.UserSQL = "SELECT \'%\'                                   DOCTOR_GRADE";
            this.cboDoctor_grade.SelectedIndexChanged += new System.EventHandler(this.cboDoctor_grade_SelectedIndexChanged);
            // 
            // lblDoctor_grade
            // 
            this.lblDoctor_grade.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblDoctor_grade.EdgeRounding = false;
            this.lblDoctor_grade.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.lblDoctor_grade, "lblDoctor_grade");
            this.lblDoctor_grade.Name = "lblDoctor_grade";
            // 
            // txtQuery
            // 
            resources.ApplyResources(this.txtQuery, "txtQuery");
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtQuery_DataValidating);
            // 
            // lblQuery
            // 
            this.lblQuery.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblQuery.EdgeRounding = false;
            this.lblQuery.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.lblQuery, "lblQuery");
            this.lblQuery.Name = "lblQuery";
            // 
            // cboGwa
            // 
            this.cboGwa.IsAppendAll = true;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
            // 
            // lblGwa
            // 
            this.lblGwa.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblGwa.EdgeRounding = false;
            this.lblGwa.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.lblGwa, "lblGwa");
            this.lblGwa.Name = "lblGwa";
            // 
            // pnlTopTop
            // 
            this.pnlTopTop.Controls.Add(this.pnlRbTop);
            resources.ApplyResources(this.pnlTopTop, "pnlTopTop");
            this.pnlTopTop.Name = "pnlTopTop";
            // 
            // pnlRbTop
            // 
            this.pnlRbTop.Controls.Add(this.rbA);
            this.pnlRbTop.Controls.Add(this.rbK);
            this.pnlRbTop.Controls.Add(this.rbS);
            this.pnlRbTop.Controls.Add(this.rbT);
            this.pnlRbTop.Controls.Add(this.rbN);
            this.pnlRbTop.Controls.Add(this.rbH);
            this.pnlRbTop.Controls.Add(this.rbM);
            this.pnlRbTop.Controls.Add(this.rbY);
            this.pnlRbTop.Controls.Add(this.rbR);
            this.pnlRbTop.Controls.Add(this.rbW);
            this.pnlRbTop.Controls.Add(this.rbAll);
            resources.ApplyResources(this.pnlRbTop, "pnlRbTop");
            this.pnlRbTop.Name = "pnlRbTop";
            // 
            // rbA
            // 
            resources.ApplyResources(this.rbA, "rbA");
            this.rbA.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbA.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbA.Name = "rbA";
            this.rbA.Tag = "A";
            this.rbA.UseVisualStyleBackColor = false;
            this.rbA.CheckedChanged += new System.EventHandler(this.rbH_CheckedChanged);
            // 
            // rbK
            // 
            resources.ApplyResources(this.rbK, "rbK");
            this.rbK.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbK.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbK.Name = "rbK";
            this.rbK.Tag = "K";
            this.rbK.UseVisualStyleBackColor = false;
            this.rbK.CheckedChanged += new System.EventHandler(this.rbH_CheckedChanged);
            // 
            // rbS
            // 
            resources.ApplyResources(this.rbS, "rbS");
            this.rbS.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbS.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbS.Name = "rbS";
            this.rbS.Tag = "S";
            this.rbS.UseVisualStyleBackColor = false;
            this.rbS.CheckedChanged += new System.EventHandler(this.rbH_CheckedChanged);
            // 
            // rbT
            // 
            resources.ApplyResources(this.rbT, "rbT");
            this.rbT.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbT.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbT.Name = "rbT";
            this.rbT.Tag = "T";
            this.rbT.UseVisualStyleBackColor = false;
            this.rbT.CheckedChanged += new System.EventHandler(this.rbH_CheckedChanged);
            // 
            // rbN
            // 
            resources.ApplyResources(this.rbN, "rbN");
            this.rbN.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbN.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbN.Name = "rbN";
            this.rbN.Tag = "N";
            this.rbN.UseVisualStyleBackColor = false;
            this.rbN.CheckedChanged += new System.EventHandler(this.rbH_CheckedChanged);
            // 
            // rbH
            // 
            resources.ApplyResources(this.rbH, "rbH");
            this.rbH.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbH.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbH.Name = "rbH";
            this.rbH.Tag = "H";
            this.rbH.UseVisualStyleBackColor = false;
            this.rbH.CheckedChanged += new System.EventHandler(this.rbH_CheckedChanged);
            // 
            // rbM
            // 
            resources.ApplyResources(this.rbM, "rbM");
            this.rbM.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbM.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbM.Name = "rbM";
            this.rbM.Tag = "M";
            this.rbM.UseVisualStyleBackColor = false;
            this.rbM.CheckedChanged += new System.EventHandler(this.rbH_CheckedChanged);
            // 
            // rbY
            // 
            resources.ApplyResources(this.rbY, "rbY");
            this.rbY.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbY.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbY.Name = "rbY";
            this.rbY.Tag = "Y";
            this.rbY.UseVisualStyleBackColor = false;
            this.rbY.CheckedChanged += new System.EventHandler(this.rbH_CheckedChanged);
            // 
            // rbR
            // 
            resources.ApplyResources(this.rbR, "rbR");
            this.rbR.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbR.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbR.Name = "rbR";
            this.rbR.Tag = "R";
            this.rbR.UseVisualStyleBackColor = false;
            this.rbR.CheckedChanged += new System.EventHandler(this.rbH_CheckedChanged);
            // 
            // rbW
            // 
            resources.ApplyResources(this.rbW, "rbW");
            this.rbW.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbW.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbW.Name = "rbW";
            this.rbW.Tag = "W";
            this.rbW.UseVisualStyleBackColor = false;
            this.rbW.CheckedChanged += new System.EventHandler(this.rbH_CheckedChanged);
            // 
            // rbAll
            // 
            resources.ApplyResources(this.rbAll, "rbAll");
            this.rbAll.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbAll.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbAll.Name = "rbAll";
            this.rbAll.Tag = "%";
            this.rbAll.UseVisualStyleBackColor = false;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbH_CheckedChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btProcessName, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdBAS0270
            // 
            this.grdBAS0270.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdBAS0270.ColPerLine = 3;
            this.grdBAS0270.Cols = 4;
            resources.ApplyResources(this.grdBAS0270, "grdBAS0270");
            this.grdBAS0270.ExecuteQuery = null;
            this.grdBAS0270.FixedCols = 1;
            this.grdBAS0270.FixedRows = 1;
            this.grdBAS0270.HeaderHeights.Add(28);
            this.grdBAS0270.Name = "grdBAS0270";
            this.grdBAS0270.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0270.ParamList")));
            this.grdBAS0270.QuerySQL = "SELECT DISTINCT A.DOCTOR      DOCTOR";
            this.grdBAS0270.ReadOnly = true;
            this.grdBAS0270.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdBAS0270.RowHeaderVisible = true;
            this.grdBAS0270.Rows = 2;
            this.grdBAS0270.ToolTipActive = true;
            this.grdBAS0270.DoubleClick += new System.EventHandler(this.grdBAS0270_DoubleClick);
            this.grdBAS0270.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0270_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "con_key";
            this.xEditGridCell3.CellWidth = 138;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "department_name";
            this.xEditGridCell4.CellWidth = 120;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "doctor";
            this.xEditGridCell1.CellWidth = 182;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "doctor_name";
            this.xEditGridCell2.CellWidth = 169;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // OCS0270Q00
            // 
            this.Controls.Add(this.grdBAS0270);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTopTop);
            this.Controls.Add(this.pnlTop);
            this.Name = "OCS0270Q00";
            resources.ApplyResources(this, "$this");
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0270Q00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).EndInit();
            this.pnlTopTop.ResumeLayout(false);
            this.pnlRbTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0270)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		#region 메세지처리
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "doctor_gwa":
					msg = (NetInfo.Language == LangMode.Ko ? "타과 의사는 입력이 불가능합니다."
						: Resources.MS1);
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: Resources.CAP1);
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				default:
					break;
			}
		}
		#endregion

		#region 조회
		private void GetQuery()
		{
			if (this.cboGwa.GetDataValue().ToString() == "") return;

			if (this.aOsim_gubun == "") return;

			if (this.aAll_gubun == "") return;

            //if (this.aQuery_gubun == "%") //전체
            //{
				this.grdBAS0270.SetBindVarValue("f_osim_gubun", this.aOsim_gubun);
                this.grdBAS0270.SetBindVarValue("f_all_gubun", this.aAll_gubun);
                this.grdBAS0270.SetBindVarValue("f_jukyong_date", this.aJukyong_date);

				if (!this.grdBAS0270.QueryLayout(true))
				{
					XMessageBox.Show(Service.ErrFullMsg);
					return;
				}
            //}
            //else //통계닥터
            //{
                //this.dsvQuery.SetInValue("osim_gubun", this.aOsim_gubun);
                //this.dsvQuery.SetInValue("all_gubun" , this.aAll_gubun);
                //this.dsvQuery.SetInValue("jukyong_date", this.aJukyong_date);

                //if (!this.DataServiceCall(this.dsvQuery))
                //{
                //    XMessageBox.Show(this.dsvQuery.ErrFullMsg.ToString());
                //    return;
                //}
            //}
		}
		#endregion

		#region 데이터전달
		private void SetData()
		{
			if (this.grdBAS0270.RowCount < 0) return;

			if (this.grdBAS0270.CurrentRowNumber < 0) return;

			if (this.aOp_yn == "Y")
			{
				if (this.cboGwa.GetDataValue().ToString() != this.aGwa)
				{
					this.GetMessage("doctor_gwa");
					return;
				}
			}
			
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "doctor"     , this.grdBAS0270.GetItemString(this.grdBAS0270.CurrentRowNumber, "doctor").ToString());
			commandParams.Add( "doctor_name", this.grdBAS0270.GetItemString(this.grdBAS0270.CurrentRowNumber, "doctor_name").ToString());
			commandParams.Add( "gwa"        , this.cboGwa.GetDataValue().ToString());

			scrOpener.Command(ScreenID, commandParams);
	
			this.Close();
		}
		#endregion

		#region Screen Load
        private string mHospCode = "";
		private void OCS0270Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			if (UserInfo.Gwa.ToString() != "")
			{
				this.cboGwa.SetEditValue(UserInfo.Gwa.ToString());
				this.cboGwa.AcceptData();
			}			
			this.cboDoctor_grade.SelectedIndex = 0;

			if (e.OpenParam != null)
			{
				if (e.OpenParam.Contains("gwa") && e.OpenParam["gwa"] != null)
				{
					this.aGwa = this.OpenParam["gwa"].ToString();
					this.cboGwa.SetEditValue(this.OpenParam["gwa"].ToString());
					this.cboGwa.AcceptData();
				}

				if (e.OpenParam.Contains("word") && e.OpenParam["word"] != null)
				{
					this.txtQuery.SetEditValue(this.OpenParam["word"].ToString());
					this.txtQuery.AcceptData();
				}

				if (e.OpenParam.Contains("all_gubun") && e.OpenParam["all_gubun"] != null)
				{
					this.aAll_gubun = this.OpenParam["all_gubun"].ToString();
				}
                this.aAll_gubun = "N";

				if (e.OpenParam.Contains("query_gubun") && e.OpenParam["query_gubun"] != null)
				{
					this.aQuery_gubun = this.OpenParam["query_gubun"].ToString();
				}

				if (e.OpenParam.Contains("op_yn") && e.OpenParam["op_yn"] != null)
				{
					this.aOp_yn = this.OpenParam["op_yn"].ToString();
				}

				if (e.OpenParam.Contains("jukyong_date") && e.OpenParam["jukyong_date"] != null)
				{
					this.aJukyong_date = this.OpenParam["jukyong_date"].ToString();
				}

                if (e.OpenParam.Contains("hosp_code") && e.OpenParam["hosp_code"] != null)
                {
                    this.mHospCode = this.OpenParam["hosp_code"].ToString();
                }

                if (e.OpenParam.Contains("reser_out_yn") && e.OpenParam["reser_out_yn"] != null)
                {
                    this.aReserOutYn = Boolean.Parse(this.OpenParam["reser_out_yn"].ToString());
                }
			}

            this.rbAll.Checked = true;
		}
		#endregion

		#region 라디오버튼에서 오심음을 선택을 했을 때
		private void rbH_CheckedChanged(object sender, System.EventArgs e)
		{
			this.aOsim_gubun = "";

			IHIS.Framework.XRadioButton rb = (IHIS.Framework.XRadioButton)sender;

			if (rb.Checked)
			{
				foreach(System.Windows.Forms.Control cs in this.pnlRbTop.Controls)
				{
					if (cs is XRadioButton)
					{
						//((IHIS.Framework.XRadioButton)cs).ImageIndex = 1;
						((IHIS.Framework.XRadioButton)cs).BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
						((IHIS.Framework.XRadioButton)cs).ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
					}
				}
				rb.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
				rb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);

				this.aOsim_gubun = rb.Tag.ToString();
			}

			//조회
			GetQuery();
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Process:
					//데이터 전달
					this.SetData();
					
					break;
				case FunctionType.Query:
					if (!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

					//조회
					GetQuery();
					break;
				default:
					break;
			}
		}
		#endregion

		#region 진료과를 변경을 했을 때
		private void cboGwa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//조회
			GetQuery();
		}
		#endregion

		#region 검색어를 입력을 했을 때
		private void txtQuery_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			//조회
			GetQuery();
		}
		#endregion

		#region 그리드에서 두번 클릭을 했을 때
		private void grdBAS0270_DoubleClick(object sender, System.EventArgs e)
		{
			//데이터전달
			SetData();
		}
		#endregion

		#region 의사등급을 변경을 했을 때
		private void cboDoctor_grade_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//조회
			GetQuery();
		}
		#endregion

        private void grdBAS0270_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0270.SetBindVarValue("f_hosp_code", this.mHospCode != "" ? this.mHospCode : UserInfo.HospCode);
            this.grdBAS0270.SetBindVarValue("f_gwa", cboGwa.GetDataValue());
            this.grdBAS0270.SetBindVarValue("f_doctor_grade", cboDoctor_grade.GetDataValue());
            this.grdBAS0270.SetBindVarValue("f_query", txtQuery.GetDataValue());
            this.grdBAS0270.SetBindVarValue("f_date", aJukyong_date);
        }


        #region Update Code

	    private List<string> GridParamList()
	    {
	        List<string> param = new List<string>();
            param.Add("f_all_gubun");
            param.Add("f_date");
            param.Add("f_doctor_grade");
            param.Add("f_gwa");
            param.Add("f_osim_gubun");
            param.Add("f_query");

	        return param;
	    }

	    //OCSAOCS0270Q00GridBAS0270RowInfo
        private IList<object[]> GridList(BindVarCollection list)
        {

            IList<object[]> lstResult = new List<object[]>();

            OCSAOCS0270Q00GridBAS0270Args args = new OCSAOCS0270Q00GridBAS0270Args();            
            args.AllGubun = list["f_all_gubun"].VarValue;
            args.Date = list["f_date"].VarValue;
            args.DoctorGrade = list["f_doctor_grade"].VarValue;
            args.Gwa = list["f_gwa"].VarValue;
            args.OsimGubun = list["f_osim_gubun"].VarValue;
            args.Query = list["f_query"].VarValue;
            args.HospCode = this.mHospCode;
            args.ReserOutYn = this.aReserOutYn;

            OCSAOCS0270Q00GridBAS0270Result result = CloudService.Instance
                    .Submit<OCSAOCS0270Q00GridBAS0270Result, OCSAOCS0270Q00GridBAS0270Args>(args);

            if (result != null)
            {
                IList<OCSAOCS0270Q00GridBAS0270RowInfo> listItem = result.Rows ;

                foreach (OCSAOCS0270Q00GridBAS0270RowInfo item in listItem)
                {

                    object[] objects =
                        {   item.ContKey , 
                            item.DepartmentName,
                            item.Doctor ,
                            item.DoctorName                            
                        };
                    lstResult.Add(objects);
                }
            }

            return lstResult;
        }

	    private const string CACHE_COMBODOCTORGRADE_KEYS = "Ocsa.OCS0270Q00.CmbDoctorGrade";
       //Load data into Combobox Doctor Grade
        private IList<object[]> ComboDoctorGrade(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();
            OCSAOCS0270Q00CboDoctorGradeArgs args = new OCSAOCS0270Q00CboDoctorGradeArgs();
            args.HospCode = this.mHospCode;
            
            OCSAOCS0270Q00CboDoctorGradeResult result = CacheService.Instance
                    .Get<OCSAOCS0270Q00CboDoctorGradeArgs, OCSAOCS0270Q00CboDoctorGradeResult>(args);
            
            if (result != null)
            {
                IList<IHIS.CloudConnector.Contracts.Models.System.ComboListItemInfo> listItem = result.ComboListItems ;

                foreach (IHIS.CloudConnector.Contracts.Models.System.ComboListItemInfo item in listItem)
                {

                    object[] objects =
                        {
                            item.Code, 
                            item.CodeName 
                        };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }


        #endregion
    }
}


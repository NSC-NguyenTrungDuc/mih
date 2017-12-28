using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.BASS.Properties;
using IHIS.Framework;

namespace IHIS.BASS
{
	/// <summary>
	/// IlgwalInsertForm에 대한 요약 설명입니다.
	/// </summary>
	public class IlgwalInsertForm : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XDisplayBox xDisplayBox1;
		private IHIS.Framework.XDisplayBox xDisplayBox2;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XTextBox txtDoctorName;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XLabel xLabel8;
		private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XDictComboBox cboDoctorGwa;
		private IHIS.Framework.XDictComboBox cboDoctorGrade;
		private IHIS.Framework.XCheckBox cbxJubsuYN;
		private IHIS.Framework.XCheckBox cbxReserYN;
		private IHIS.Framework.XTextBox txtMayakLicense;
		private IHIS.Framework.XDatePicker dtpDoctorYMD;
		private IHIS.Framework.XEditMask emkDoctorSeq;
		private IHIS.Framework.XTextBox txtDoctorName2;
		private IHIS.Framework.XButtonList btnList;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public IlgwalInsertForm()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IlgwalInsertForm));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.dtpDoctorYMD = new IHIS.Framework.XDatePicker();
            this.txtMayakLicense = new IHIS.Framework.XTextBox();
            this.cbxReserYN = new IHIS.Framework.XCheckBox();
            this.cbxJubsuYN = new IHIS.Framework.XCheckBox();
            this.cboDoctorGrade = new IHIS.Framework.XDictComboBox();
            this.cboDoctorGwa = new IHIS.Framework.XDictComboBox();
            this.emkDoctorSeq = new IHIS.Framework.XEditMask();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.txtDoctorName2 = new IHIS.Framework.XTextBox();
            this.txtDoctorName = new IHIS.Framework.XTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xDisplayBox2 = new IHIS.Framework.XDisplayBox();
            this.xDisplayBox1 = new IHIS.Framework.XDisplayBox();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightBlue);
            this.xPanel2.Controls.Add(this.dtpDoctorYMD);
            this.xPanel2.Controls.Add(this.txtMayakLicense);
            this.xPanel2.Controls.Add(this.cbxReserYN);
            this.xPanel2.Controls.Add(this.cbxJubsuYN);
            this.xPanel2.Controls.Add(this.cboDoctorGrade);
            this.xPanel2.Controls.Add(this.cboDoctorGwa);
            this.xPanel2.Controls.Add(this.emkDoctorSeq);
            this.xPanel2.Controls.Add(this.xLabel9);
            this.xPanel2.Controls.Add(this.xLabel8);
            this.xPanel2.Controls.Add(this.xLabel7);
            this.xPanel2.Controls.Add(this.xLabel6);
            this.xPanel2.Controls.Add(this.xLabel5);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Controls.Add(this.txtDoctorName2);
            this.xPanel2.Controls.Add(this.txtDoctorName);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Controls.Add(this.xDisplayBox2);
            this.xPanel2.Controls.Add(this.xDisplayBox1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // dtpDoctorYMD
            // 
            resources.ApplyResources(this.dtpDoctorYMD, "dtpDoctorYMD");
            this.dtpDoctorYMD.Name = "dtpDoctorYMD";
            // 
            // txtMayakLicense
            // 
            resources.ApplyResources(this.txtMayakLicense, "txtMayakLicense");
            this.txtMayakLicense.Name = "txtMayakLicense";
            // 
            // cbxReserYN
            // 
            this.cbxReserYN.Checked = true;
            this.cbxReserYN.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.cbxReserYN, "cbxReserYN");
            this.cbxReserYN.Name = "cbxReserYN";
            this.cbxReserYN.UseVisualStyleBackColor = false;
            // 
            // cbxJubsuYN
            // 
            this.cbxJubsuYN.Checked = true;
            this.cbxJubsuYN.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.cbxJubsuYN, "cbxJubsuYN");
            this.cbxJubsuYN.Name = "cbxJubsuYN";
            this.cbxJubsuYN.UseVisualStyleBackColor = false;
            // 
            // cboDoctorGrade
            // 
            resources.ApplyResources(this.cboDoctorGrade, "cboDoctorGrade");
            this.cboDoctorGrade.Name = "cboDoctorGrade";
            this.cboDoctorGrade.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDoctorGrade.UserSQL = "SELECT CODE, \'(\'||CODE||\') \'||CODE_NAME\r\nFROM BAS0102\r\nWHERE CODE_TYPE = \'DOCTOR_" +
                "GRADE\'\r\nORDER BY CODE";
            // 
            // cboDoctorGwa
            // 
            resources.ApplyResources(this.cboDoctorGwa, "cboDoctorGwa");
            this.cboDoctorGwa.Name = "cboDoctorGwa";
            this.cboDoctorGwa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDoctorGwa.UserSQL = "SELECT A.GWA, A.GWA_NAME\r\n  FROM BAS0260 A\r\nWHERE A.BUSEO_GUBUN = \'1\'\r\n  AND A.EN" +
                "D_DATE = TO_DATE(\'9998/12/31\', \'YYYY/MM/DD\')\r\n  AND A.OUT_JUBSU_YN = \'Y\'\r\nORDER " +
                "BY A.GWA";
            // 
            // emkDoctorSeq
            // 
            resources.ApplyResources(this.emkDoctorSeq, "emkDoctorSeq");
            this.emkDoctorSeq.Mask = "####";
            this.emkDoctorSeq.Name = "emkDoctorSeq";
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Name = "xLabel8";
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // txtDoctorName2
            // 
            this.txtDoctorName2.ApplyByteLimit = true;
            resources.ApplyResources(this.txtDoctorName2, "txtDoctorName2");
            this.txtDoctorName2.Name = "txtDoctorName2";
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.ApplyByteLimit = true;
            resources.ApplyResources(this.txtDoctorName, "txtDoctorName");
            this.txtDoctorName.Name = "txtDoctorName";
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xDisplayBox2
            // 
            this.xDisplayBox2.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            resources.ApplyResources(this.xDisplayBox2, "xDisplayBox2");
            this.xDisplayBox2.Name = "xDisplayBox2";
            // 
            // xDisplayBox1
            // 
            this.xDisplayBox1.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            resources.ApplyResources(this.xDisplayBox1, "xDisplayBox1");
            this.xDisplayBox1.Name = "xDisplayBox1";
            // 
            // IlgwalInsertForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "IlgwalInsertForm";
            this.Load += new System.EventHandler(this.IlgwalInsertForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.IlgwalInsertForm_Closing);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region Form 변수

		// 메세지 관련 변수
		private string mMsg = "";
		private string mCap = "";

		// 원래 스크린으로 리턴할 의사명
		public string mDoctorName = "";

		#endregion

		#region Form Load 이벤트

		private void IlgwalInsertForm_Load(object sender, System.EventArgs e)
		{
			// 적용일자 일단 오늘로 기본셋팅
			this.dtpDoctorYMD.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));

			PostCallHelper.PostCall(new PostMethod(PostFormLoad));
		}

		private void PostFormLoad ()
		{
			// 포커스 순번으로
			this.emkDoctorSeq.Focus();
		}

		#endregion

		#region Form Closing 이벤트

		private void IlgwalInsertForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.mDoctorName = this.txtDoctorName.GetDataValue();
		}

		#endregion

		#region Process Call

		private void ProcessCall ()
		{
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(emkDoctorSeq.GetDataValue());
            inputList.Add(txtDoctorName.GetDataValue());
            inputList.Add(txtDoctorName2.GetDataValue());
            inputList.Add(cboDoctorGwa.GetDataValue());
            inputList.Add(cboDoctorGrade.GetDataValue());
            inputList.Add(cbxJubsuYN.GetDataValue());
            inputList.Add(cbxReserYN.GetDataValue());
            inputList.Add(txtMayakLicense.GetDataValue());
            inputList.Add(dtpDoctorYMD.GetDataValue());

            if (Service.ExecuteProcedure("PR_BAS_MAKE_DOCTOR_CODE_ALL", inputList, outputList))
            {
                this.mMsg = NetInfo.Language == LangMode.Ko ? "정상적으로 처리 되었습니다." : Resources.IlgwalInsertForm_ProcessCall_;
                this.mCap = NetInfo.Language == LangMode.Ko ? "처리완료" : Resources.IlgwalInsertForm_ProcessCall_TEXT2;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.mMsg = NetInfo.Language == LangMode.Ko ? "처리에 실패 하였습니다." : Resources.IlgwalInsertForm_ProcessCall_TEXT3;
                this.mMsg += " - " + Service.ErrFullMsg;
                this.mCap = NetInfo.Language == LangMode.Ko ? "처리실패" : Resources.IlgwalInsertForm_ProcessCall_TEXT3;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

		#endregion

		#region 저장전 데이터 체크 

		private bool CheckDataNULL ()
		{
			bool isUpdatable = true;

			if (this.txtDoctorName.GetDataValue() == "" ||
				this.txtDoctorName2.GetDataValue() == ""  )
			{
				this.mMsg = (NetInfo.Language == LangMode.Ko ? "의사명을 입력해 주세요." : Resources.IlgwalInsertForm_CheckDataNULL_TEXT4);

				isUpdatable = false;
			}

			if (this.cboDoctorGwa.GetDataValue() == "" )
			{
				this.mMsg = (NetInfo.Language == LangMode.Ko ? "소속과를 선택해 주세요." : Resources.IlgwalInsertForm_CheckDataNULL_TEXT5);

				isUpdatable = false;
			}

			if (this.cboDoctorGrade.GetDataValue() == "")
			{
				this.mMsg = (NetInfo.Language == LangMode.Ko ? "의사등급을 선택해 주세요." : Resources.IlgwalInsertForm_CheckDataNULL_TEXT5);

				isUpdatable = false;
			}

			if (this.dtpDoctorYMD.GetDataValue() == "")
			{
				this.mMsg = (NetInfo.Language == LangMode.Ko ? "적용일자를 입력해 주세요." : Resources.IlgwalInsertForm_CheckDataNULL_TEXT6);

				isUpdatable = false;
			}

			if (isUpdatable == false)
			{
				this.mCap = (NetInfo.Language == LangMode.Ko ? "저장실패" : Resources.IlgwalInsertForm_CheckDataNULL_TEXT7);

				XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
			else
			{
				return true;
			}

		}

		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process :

					if (this.CheckDataNULL())
						this.ProcessCall();

					break;

				case FunctionType.Close :

					break;
			}
		}

		#endregion

	}
}

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
using IHIS.OCS;

#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0100U00.cs에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0100U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XComboBox cboBuseo;

		private IHIS.OCS.OrderBiz  mOrderBiz  = null;

		private System.Windows.Forms.Label lbxTitle;         // OCS 그룹 Business 라이브러리

        private Image mBackImage;
        private string mImagePath = @"C:\IHIS\Images\";

		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0100U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
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

            this.mBackImage.Dispose();

			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.lbxTitle = new System.Windows.Forms.Label();
            this.btnList = new IHIS.Framework.XButtonList();
            this.cboBuseo = new IHIS.Framework.XComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxTitle
            // 
            this.lbxTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbxTitle.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxTitle.ForeColor = System.Drawing.Color.White;
            this.lbxTitle.Location = new System.Drawing.Point(115, 83);
            this.lbxTitle.Name = "lbxTitle";
            this.lbxTitle.Size = new System.Drawing.Size(176, 24);
            this.lbxTitle.TabIndex = 0;
            this.lbxTitle.Text = "lbTitle";
            this.lbxTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(121, 216);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 1;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // cboBuseo
            // 
            this.cboBuseo.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBuseo.Location = new System.Drawing.Point(93, 140);
            this.cboBuseo.MaxDropDownItems = 30;
            this.cboBuseo.Name = "cboBuseo";
            this.cboBuseo.Size = new System.Drawing.Size(212, 29);
            this.cboBuseo.TabIndex = 0;
            // 
            // OCS0100U00
            // 
            this.Controls.Add(this.cboBuseo);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.lbxTitle);
            this.Name = "OCS0100U00";
            this.Size = new System.Drawing.Size(408, 300);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		///////////////////////////////////////////////////////////////////////////////////////////////////////
		#region [Screen Event]
		/// <summary>
		/// Screen Load시 Post Event로 Call 되서 Load시 처리할 로직들을 기술한다
		/// </summary>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            // 바탕 이미지 설정
            this.mBackImage = Image.FromFile(this.mImagePath + "Login.gif");
            this.BackgroundImage = this.mBackImage;
			
			this.PostLoad();

		}
		private void PostLoad()
		{
			this.cboBuseo.DataSource = null;
			this.cboBuseo.ComboItems.Clear();

			// Combo 세팅
			DataTable dtTemp = null;

			if (IHIS.Framework.UserInfo.UserGubun == UserType.Doctor)
			{
				// 의사면 진료과 선택
				dtTemp  = this.mOrderBiz.LoadComboDataSource("gwa").LayoutTable;
				lbxTitle.Text = NetInfo.Language == LangMode.Jr ? "診療科選択" : "진료과선택";
			}
			else if (IHIS.Framework.UserInfo.UserGubun == UserType.Nurse)
			{
				// 병동시스템이면 병동, 외래면 진료과
				if (IHIS.Framework.EnvironInfo.CurrSystemID == "OCSI" || IHIS.Framework.EnvironInfo.CurrSystemID == "NURI")
				{
					dtTemp  = this.mOrderBiz.LoadComboDataSource("ho_dong").LayoutTable;
					lbxTitle.Text = NetInfo.Language == LangMode.Jr ? "病棟選択" : "병동선택";
				}
				else
				{
					dtTemp  = this.mOrderBiz.LoadComboDataSource("gwa").LayoutTable;
					lbxTitle.Text = NetInfo.Language == LangMode.Jr ? "診療科選択" : "진료과선택";
				}
			}
			else
			{
				// 기타면 OCS입력 가능 부서등록
				dtTemp  = this.mOrderBiz.LoadComboDataSource("ocs_buseo_code").LayoutTable;
				lbxTitle.Text = NetInfo.Language == LangMode.Jr ? "部署選択" : "부서선택";
			}

			this.cboBuseo.SetComboItems(dtTemp, "code_name", "code", XComboSetType.NoAppend);

		}

		#endregion
		///////////////////////////////////////////////////////////////////////////////////////////////////////

		#region buttonList ButtonList 클릭 Event : Find SQL조건 및 필드 정의 (btnList_ButtonClick)
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			string mbxMsg = "";
			string mbxCap = "";
			switch (e.Func)
			{

				case FunctionType.Process: // 선택

					e.IsBaseCall = false; e.IsSuccess  = true;

					if (!this.AcceptData()) {e.IsSuccess  = false; break;}

					// 입원정보 존재여부 체크
					if (TypeCheck.IsNull(this.cboBuseo.GetDataValue())) 
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "入力するデータを選択してください" : "입력할 데이타를 선택하십시오";						
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

						this.cboBuseo.Focus();
						e.IsSuccess  = false; break;
					}

					mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が完了しました。" : "처리가 완료되었습니다.";
					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);

					if (!OrderVariables.CommonInfo.Items.Contains(OrderVariables.DOCTORINFO)) OrderVariables.CommonInfo.Items.Add(OrderVariables.DOCTORINFO);

					if (OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Contains("input_part"))      OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Remove("input_part");
					if (OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Contains("input_part_name")) OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Remove("input_part_name");

					OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Add("input_part",      this.cboBuseo.GetDataValue().ToString().Trim());
					OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Add("input_part_name", this.cboBuseo.Text.ToString().Trim());

					if (IHIS.Framework.UserInfo.UserGubun == UserType.Doctor)
					{
						// 의사면 진료과 선택
					}
					else if (IHIS.Framework.UserInfo.UserGubun == UserType.Nurse)
					{
						// 병동시스템이면 병동, 외래면 진료과
					}
					else
					{ 
						// 기타면 OCS입력 가능 부서등록 => 입력구분 제세팅		

						// 0.부서명,1.입력구분,2:부서구분
						if (this.cboBuseo.Text.ToString().Trim().Split('|').Length < 5) return;

						string buseo_code    = this.cboBuseo.GetDataValue().ToString().Trim();
						string buseo_name    = this.cboBuseo.Text.ToString().Trim().Split('|')[0].Trim();
						string input_gubun   = this.cboBuseo.Text.ToString().Trim().Split('|')[1].Trim();
						string buseo_gubun   = this.cboBuseo.Text.ToString().Trim().Split('|')[2].Trim();
						string gwa           = this.cboBuseo.Text.ToString().Trim().Split('|')[3].Trim();
						string gwa_name      = this.cboBuseo.Text.ToString().Trim().Split('|')[4].Trim();

						if (OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Contains("input_part"))       OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Remove("input_part");
						if (OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Contains("input_part_name"))  OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Remove("input_part_name");
						if (OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Contains("buseo_code"))       OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Remove("buseo_code");
						if (OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Contains("buseo_name"))       OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Remove("buseo_name");
						if (OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Contains("buseo_gubun"))      OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Remove("buseo_gubun");
						if (OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Contains("input_gubun"))      OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Remove("input_gubun");
						if (OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Contains("input_gubun_name")) OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Remove("input_gubun_name");
						if (OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Contains("gwa"))              OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Remove("gwa");
						if (OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Contains("gwa_name"))         OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Remove("gwa_name");

						OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Add("input_part",       TypeCheck.NVL(gwa,      buseo_code));
						OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Add("input_part_name",  TypeCheck.NVL(gwa_name, buseo_name));
						OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Add("buseo_code",       buseo_code);
						OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Add("buseo_name",       buseo_name);
						OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Add("buseo_gubun",      buseo_gubun);					
						OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Add("input_gubun",      input_gubun);
						OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Add("input_gubun_name", buseo_name);
						OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Add("gwa",              gwa);
						OrderVariables.CommonInfo.Items[OrderVariables.DOCTORINFO].Items.Add("gwa_name",         gwa_name);

					}

					// 화면을 닫는다
					if (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.ResponseFixed || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.ResponseSizable)
					{
						PostCallHelper.PostCall(new PostMethod(this.Close));
					}

					break;
			}
		}
		#endregion
	}
}


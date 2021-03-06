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


namespace IHIS.OCSA
{
	/// <summary>
	/// frmYaksok_code에 대한 요약 설명입니다.
	/// </summary>
	public class frmYaksok_code : IHIS.Framework.XForm
	{
		#region [Instance Variable]		
		//Message처리
		private string mbxMsg = "", mbxCap = "";		
		//처방화면에서 약속코드생성시
		string mYaksok_code = "", mYaksok_name = "";
        // DataService用
        string cmdText = string.Empty;
        object retObjt = null;
		#endregion

		private IHIS.Framework.XLabel xLabel62;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XTextBox txtYaksok_code;
		private IHIS.Framework.XTextBox txtYaksok_name;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XLabel xLabel2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmYaksok_code()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmYaksok_code));
			this.xLabel62 = new IHIS.Framework.XLabel();
			this.xLabel1 = new IHIS.Framework.XLabel();
			this.txtYaksok_code = new IHIS.Framework.XTextBox();
			this.txtYaksok_name = new IHIS.Framework.XTextBox();
			this.xButtonList1 = new IHIS.Framework.XButtonList();
			this.xLabel2 = new IHIS.Framework.XLabel();
			((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
			this.SuspendLayout();
			// 
			// xLabel62
			// 
			this.xLabel62.BackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
			this.xLabel62.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.xLabel62.EdgeRounding = false;
			this.xLabel62.Enabled = false;
			this.xLabel62.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xLabel62.ForeColor = IHIS.Framework.XColor.NormalForeColor;
			this.xLabel62.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
			this.xLabel62.Location = new System.Drawing.Point(6, 10);
			this.xLabel62.Name = "xLabel62";
			this.xLabel62.Size = new System.Drawing.Size(108, 20);
			this.xLabel62.TabIndex = 14;
			this.xLabel62.Text = "セットオ―ダ";
			this.xLabel62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// xLabel1
			// 
			this.xLabel1.BackColor = IHIS.Framework.XColor.XListBoxItemBorderColor;
			this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
			this.xLabel1.EdgeRounding = false;
			this.xLabel1.Enabled = false;
			this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xLabel1.ForeColor = IHIS.Framework.XColor.NormalForeColor;
			this.xLabel1.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
			this.xLabel1.Location = new System.Drawing.Point(6, 34);
			this.xLabel1.Name = "xLabel1";
			this.xLabel1.Size = new System.Drawing.Size(108, 20);
			this.xLabel1.TabIndex = 15;
			this.xLabel1.Text = "セットオ―ダ名";
			this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtYaksok_code
			// 
			this.txtYaksok_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtYaksok_code.ImeMode = System.Windows.Forms.ImeMode.Alpha;
			this.txtYaksok_code.Location = new System.Drawing.Point(116, 10);
			this.txtYaksok_code.MaxLength = 10;
			this.txtYaksok_code.Name = "txtYaksok_code";
			this.txtYaksok_code.Size = new System.Drawing.Size(154, 20);
			this.txtYaksok_code.TabIndex = 16;
			this.txtYaksok_code.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtYaksok_code_DataValidating);
			// 
			// txtYaksok_name
			// 
			this.txtYaksok_name.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.txtYaksok_name.Location = new System.Drawing.Point(116, 34);
			this.txtYaksok_name.MaxLength = 60;
			this.txtYaksok_name.Name = "txtYaksok_name";
			this.txtYaksok_name.Size = new System.Drawing.Size(278, 20);
			this.txtYaksok_name.TabIndex = 17;
			// 
			// xButtonList1
			// 
			this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xButtonList1.IsVisibleReset = false;
			this.xButtonList1.Location = new System.Drawing.Point(154, 90);
			this.xButtonList1.Name = "xButtonList1";
			this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Process;
			this.xButtonList1.Size = new System.Drawing.Size(244, 34);
			this.xButtonList1.TabIndex = 19;
			this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
			// 
			// xLabel2
			// 
			this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
			this.xLabel2.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
			this.xLabel2.Image = ((System.Drawing.Image)(resources.GetObject("xLabel2.Image")));
			this.xLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.xLabel2.Location = new System.Drawing.Point(10, 60);
			this.xLabel2.Name = "xLabel2";
			this.xLabel2.Size = new System.Drawing.Size(380, 22);
			this.xLabel2.TabIndex = 20;
			this.xLabel2.Text = " 生成するセットコード及びセットコード名を登録してください。";
			// 
			// frmYaksok_code
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(404, 152);
			this.Controls.Add(this.xLabel2);
			this.Controls.Add(this.xButtonList1);
			this.Controls.Add(this.txtYaksok_name);
			this.Controls.Add(this.txtYaksok_code);
			this.Controls.Add(this.xLabel1);
			this.Controls.Add(this.xLabel62);
			this.Name = "frmYaksok_code";
			this.Text = "セットオ―ダ";
			this.Load += new System.EventHandler(this.frmYaksok_code_Load);
			this.Controls.SetChildIndex(this.xLabel62, 0);
			this.Controls.SetChildIndex(this.xLabel1, 0);
			this.Controls.SetChildIndex(this.txtYaksok_code, 0);
			this.Controls.SetChildIndex(this.txtYaksok_name, 0);
			this.Controls.SetChildIndex(this.xButtonList1, 0);
			this.Controls.SetChildIndex(this.xLabel2, 0);
			((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region [properties]
	
        
		/// <summary>
		/// 등록한 약속코드를 가져옵니다.
		/// </summary>		
		public string Yaksok_code
		{
			get
			{
				return mYaksok_code;
			}
			set
			{
				mYaksok_code = value;
			}
		}

		/// <summary>
		/// 등록한 약속코드명를 가져옵니다.
		/// </summary>
		public string Yaksok_name
		{
			get
			{
				return mYaksok_name;
			}
			set
			{
				mYaksok_name = value;
			}
		}

		#endregion

		#region [Form Event]
		private void frmYaksok_code_Load(object sender, System.EventArgs e)
		{	
			this.txtYaksok_code.SetDataValue(mYaksok_code);
			this.txtYaksok_name.SetDataValue(mYaksok_name);
			
			txtYaksok_code.Focus();
			txtYaksok_code.SelectAll();
		}
		#endregion

		#region [Button List Event]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			SetMsg("");

			e.IsBaseCall = false;

			switch (e.Func)
			{
				
				case FunctionType.Process:
					e.IsBaseCall = false;
					CreateReturnValue();

					break;
				
				default:

					e.IsBaseCall = false;

					this.DialogResult = DialogResult.Cancel;
					this.Close();

					break;
			}
		}
		#endregion

		#region [Function]
		/// <summary>
		/// 등록한 약속코드 및 약속코드명을 변수로 생성합니다.		
		/// </summary>
		private void CreateReturnValue()
		{  
			if(this.txtYaksok_code.GetDataValue().Trim() != "")
				mYaksok_code = txtYaksok_code.GetDataValue().Trim();

			if(this.txtYaksok_name.GetDataValue().Trim() != "")
				mYaksok_name = txtYaksok_name.GetDataValue().Trim();

			DialogResult = DialogResult.OK;
		}

		#endregion 
        
		#region [Control Event]
		private void txtYaksok_code_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			e.Cancel= false;

			if(e.DataValue.Trim() == "") return;
            
			//중복check
			cmdText = "";
			cmdText = "SELECT YAKSOK_NAME"
                    + "  FROM OCS0301"
                    + " WHERE MEMB        = '" + UserInfo.YaksokOpenID + "' "
                    + "   AND YAKSOK_CODE = '" + e.DataValue.Trim()    + "' "
                    + "   AND HOSP_CODE   = '" + EnvironInfo.HospCode  + "' ";

            retObjt = Service.ExecuteScalar(cmdText);

            if (!TypeCheck.IsNull(retObjt))
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "同じセットオ―ダコードがあります。 ご確認ください。" : "약속코드가 중복됩니다. 확인바랍니다.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                e.Cancel = true;				
            }
		}
		#endregion

	}
}

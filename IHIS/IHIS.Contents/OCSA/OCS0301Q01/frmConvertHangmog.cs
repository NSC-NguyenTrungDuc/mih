#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// frmConvertHangmog에 대한 요약 설명입니다.
	/// </summary>
	public class frmConvertHangmog : IHIS.Framework.XForm
	{
		#region [Instance Variable]		
		//Message처리
		private string mbxMsg = "", mbxCap = "";		
		//변경항목코드
		string mhangmog_code = "";
		// Save
		string saveStr = "";
		IHIS.Framework.BindVarCollection saveBindVars = new BindVarCollection();
		#endregion

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private System.Windows.Forms.ImageList imageList1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XRadioButton rbtOftenUsed;
		private IHIS.Framework.XRadioButton rbtSet;
		private IHIS.Framework.XFindWorker fwkOCS0103;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XDisplayBox dpxHangmog_name;
		private IHIS.Framework.XFindBox fbxHangmog_code;
		private IHIS.Framework.XLabel xLabel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XDisplayBox dpxConvHanmog_name;
		private IHIS.Framework.XFindBox fbxConvHangmog_code;
		private IHIS.Framework.FindColumnInfo findColumnInfo3;
		private IHIS.Framework.FindColumnInfo findColumnInfo4;
		private IHIS.Framework.MultiLayout layHangmogInfo;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem5;
		private System.ComponentModel.IContainer components;

		public frmConvertHangmog()
		{
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvertHangmog));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.rbtOftenUsed = new IHIS.Framework.XRadioButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rbtSet = new IHIS.Framework.XRadioButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.fwkOCS0103 = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.dpxHangmog_name = new IHIS.Framework.XDisplayBox();
            this.fbxHangmog_code = new IHIS.Framework.XFindBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dpxConvHanmog_name = new IHIS.Framework.XDisplayBox();
            this.fbxConvHangmog_code = new IHIS.Framework.XFindBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.layHangmogInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layHangmogInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.rbtOftenUsed);
            this.xPanel1.Controls.Add(this.rbtSet);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(632, 34);
            this.xPanel1.TabIndex = 1;
            // 
            // rbtOftenUsed
            // 
            this.rbtOftenUsed.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtOftenUsed.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtOftenUsed.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtOftenUsed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtOftenUsed.ImageIndex = 0;
            this.rbtOftenUsed.ImageList = this.imageList1;
            this.rbtOftenUsed.Location = new System.Drawing.Point(116, 6);
            this.rbtOftenUsed.Name = "rbtOftenUsed";
            this.rbtOftenUsed.Size = new System.Drawing.Size(110, 26);
            this.rbtOftenUsed.TabIndex = 18;
            this.rbtOftenUsed.Tag = "2";
            this.rbtOftenUsed.Text = "      常用オーダ";
            this.rbtOftenUsed.UseVisualStyleBackColor = false;
            this.rbtOftenUsed.Click += new System.EventHandler(this.rbtSet_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // rbtSet
            // 
            this.rbtSet.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtSet.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtSet.Checked = true;
            this.rbtSet.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtSet.ImageIndex = 1;
            this.rbtSet.ImageList = this.imageList1;
            this.rbtSet.Location = new System.Drawing.Point(6, 6);
            this.rbtSet.Name = "rbtSet";
            this.rbtSet.Size = new System.Drawing.Size(110, 26);
            this.rbtSet.TabIndex = 17;
            this.rbtSet.TabStop = true;
            this.rbtSet.Tag = "1";
            this.rbtSet.Text = "      セットオーダ";
            this.rbtSet.UseVisualStyleBackColor = false;
            this.rbtSet.Click += new System.EventHandler(this.rbtSet_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 106);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(632, 44);
            this.xPanel2.TabIndex = 2;
            // 
            // xButtonList1
            // 
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.Location = new System.Drawing.Point(466, 8);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // fwkOCS0103
            // 
            this.fwkOCS0103.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkOCS0103.FormText = "オ―ダコード";
            this.fwkOCS0103.InputSQL = resources.GetString("fwkOCS0103.InputSQL");
            this.fwkOCS0103.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkOCS0103.SearchTextCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.fwkOCS0103.ServerFilter = true;
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "hangmog_code";
            this.findColumnInfo3.ColWidth = 103;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo3.HeaderText = "オ―ダコード";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "hangmog_name";
            this.findColumnInfo4.ColWidth = 373;
            this.findColumnInfo4.HeaderText = "オ―ダコード名";
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "hangmog_code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "オ―ダコード";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "hangmog_name";
            this.findColumnInfo2.ColWidth = 448;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.Yes;
            this.findColumnInfo2.HeaderText = "オ―ダコード名";
            // 
            // dpxHangmog_name
            // 
            this.dpxHangmog_name.Location = new System.Drawing.Point(196, 46);
            this.dpxHangmog_name.Name = "dpxHangmog_name";
            this.dpxHangmog_name.Size = new System.Drawing.Size(358, 20);
            this.dpxHangmog_name.TabIndex = 17;
            // 
            // fbxHangmog_code
            // 
            this.fbxHangmog_code.AutoTabDataSelected = true;
            this.fbxHangmog_code.FindWorker = this.fwkOCS0103;
            this.fbxHangmog_code.Location = new System.Drawing.Point(96, 46);
            this.fbxHangmog_code.Name = "fbxHangmog_code";
            this.fbxHangmog_code.Size = new System.Drawing.Size(100, 20);
            this.fbxHangmog_code.TabIndex = 15;
            this.fbxHangmog_code.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHangmog_code_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(6, 46);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(88, 20);
            this.xLabel1.TabIndex = 16;
            this.xLabel1.Text = "項目コード";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(36, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 20);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // dpxConvHanmog_name
            // 
            this.dpxConvHanmog_name.Location = new System.Drawing.Point(254, 76);
            this.dpxConvHanmog_name.Name = "dpxConvHanmog_name";
            this.dpxConvHanmog_name.Size = new System.Drawing.Size(358, 20);
            this.dpxConvHanmog_name.TabIndex = 22;
            // 
            // fbxConvHangmog_code
            // 
            this.fbxConvHangmog_code.AutoTabDataSelected = true;
            this.fbxConvHangmog_code.FindWorker = this.fwkOCS0103;
            this.fbxConvHangmog_code.Location = new System.Drawing.Point(154, 76);
            this.fbxConvHangmog_code.Name = "fbxConvHangmog_code";
            this.fbxConvHangmog_code.Size = new System.Drawing.Size(100, 20);
            this.fbxConvHangmog_code.TabIndex = 20;
            this.fbxConvHangmog_code.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxConvHangmog_code_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(64, 76);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(88, 20);
            this.xLabel2.TabIndex = 21;
            this.xLabel2.Text = "代替項目コード";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layHangmogInfo
            // 
            this.layHangmogInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5});
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "gubun";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "hangmog_code";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "hangmog_name";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "conv_hangmog";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "conv_hangmog_name";
            // 
            // frmConvertHangmog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(632, 172);
            this.Controls.Add(this.dpxConvHanmog_name);
            this.Controls.Add(this.fbxConvHangmog_code);
            this.Controls.Add(this.xLabel2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dpxHangmog_name);
            this.Controls.Add(this.fbxHangmog_code);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "frmConvertHangmog";
            this.Text = "オーダ代替";
            this.Load += new System.EventHandler(this.frmConvertHangmog_Load);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.Controls.SetChildIndex(this.xLabel1, 0);
            this.Controls.SetChildIndex(this.fbxHangmog_code, 0);
            this.Controls.SetChildIndex(this.dpxHangmog_name, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.xLabel2, 0);
            this.Controls.SetChildIndex(this.fbxConvHangmog_code, 0);
            this.Controls.SetChildIndex(this.dpxConvHanmog_name, 0);
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layHangmogInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region [properties]
		/// <summary>
		/// 항목코드 
		/// </summary>		
		public string HANGMOG_CODE
		{
			get
			{
				return mhangmog_code;
			}
			set
			{
				mhangmog_code = value;
			}
		}

        string mHospCode = EnvironInfo.HospCode;
		#endregion

		#region [Form Event]
		private void frmConvertHangmog_Load(object sender, System.EventArgs e)
		{
			PostCallHelper.PostCall(new PostMethod(postLoad));
		}

		private void postLoad()
		{
			if(!TypeCheck.IsNull(mhangmog_code))
			{
				this.fbxHangmog_code.SetEditValue(mhangmog_code);
				this.fbxHangmog_code.AcceptData();
			}
		}
		#endregion

		#region [Control Event]
		private void fbxHangmog_code_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string hangmog_name = GetCodeName("hangmog_code", e.DataValue);
			dpxHangmog_name.SetDataValue(hangmog_name);
		}

		private void fbxConvHangmog_code_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string hangmog_name = GetCodeName("hangmog_code", e.DataValue);
			dpxConvHanmog_name.SetDataValue(hangmog_name);		
		}
	
		private void rbtSet_Click(object sender, System.EventArgs e)
		{
			if(rbtSet.Checked)
			{
				rbtSet.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtSet.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtSet.ImageIndex = 1;
				
				rbtOftenUsed.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtOftenUsed.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtOftenUsed.ImageIndex = 0;

			}
			else 
			{
				rbtOftenUsed.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtOftenUsed.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtOftenUsed.ImageIndex = 1;
				
				rbtSet.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtSet.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtSet.ImageIndex = 0;
			}	
		}
		#endregion

		#region [Load Code Name]
		/// <summary>
		/// 해당 코드에 대한 명을 가져옵니다.
		/// </summary>
		/// <param name="codeMode">코드구분</param>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCodeName(string codeMode, string code)
		{
			string codeName = "";

			if(code.Trim() == "" ) return codeName;
			switch (codeMode)
			{
				case "hangmog_code":
					string cmdText = " SELECT HANGMOG_NAME "
						+ "   FROM OCS0103 "
						+ "  WHERE HANGMOG_CODE = :f_code ";
					IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
					bindVars.Add("f_code",code);

					object retVal =Service.ExecuteScalar(cmdText,bindVars);

					if(retVal == null)
					{
						codeName ="";
					}
					else
					{
						codeName = retVal.ToString();
					}
					break;
				default:
					break;
			}

			return codeName;
		}
		#endregion

		#region [ButtonList]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process:
					if(!makeHangmogInfo()) break;
					if(GetSaveStr() == null || GetSaveStr() == "") break;
					if(Service.ExecuteNonQuery(saveStr,saveBindVars))
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
						SetMsg(mbxMsg);
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "保存に失敗しました。" : "저장이 실패하였습니다."; 
						mbxMsg = mbxMsg + "\n\r" + Service.ErrFullMsg;
						mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
					}
					break;
				default:
					break;
			}			
		}	

		private bool makeHangmogInfo()
		{
			this.layHangmogInfo.Reset();
            
			int insertRow = layHangmogInfo.InsertRow(-1);

			if(TypeCheck.IsNull(this.dpxHangmog_name.GetDataValue().Trim()))
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダに間違いがあります。　ご確認ください。" : "처방이 정확하지않습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap);
				this.fbxHangmog_code.Focus();
				this.fbxHangmog_code.SelectAll();
				return false;
			}

			if(TypeCheck.IsNull(this.dpxConvHanmog_name.GetDataValue().Trim()))
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "代替オーダに間違いがあります。　ご確認ください。" : "대체처방이 정확하지않습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap);
				this.fbxConvHangmog_code.Focus();
				this.fbxConvHangmog_code.SelectAll();
				return false;
			}

			if(this.rbtSet.Checked)
			{
				layHangmogInfo.SetItemValue(insertRow, "gubun", "0");
				saveBindVars.Add("f_gubun","0");
			}
			else
			{
				layHangmogInfo.SetItemValue(insertRow, "gubun", "1");
				saveBindVars.Add("f_gubun","1");
			}

			layHangmogInfo.SetItemValue(insertRow, "hangmog_code"     , fbxHangmog_code.GetDataValue());
			saveBindVars.Add("f_hangmog_code",fbxHangmog_code.GetDataValue());
			layHangmogInfo.SetItemValue(insertRow, "hangmog_name"     , dpxHangmog_name.GetDataValue());
			saveBindVars.Add("f_hangmog_name",dpxHangmog_name.GetDataValue());
			layHangmogInfo.SetItemValue(insertRow, "conv_hangmog"     , fbxConvHangmog_code.GetDataValue());
			saveBindVars.Add("f_conv_hangmog",fbxConvHangmog_code.GetDataValue());
			layHangmogInfo.SetItemValue(insertRow, "conv_hangmog_name", dpxConvHanmog_name.GetDataValue());
			saveBindVars.Add("f_conv_hangmog_name",dpxConvHanmog_name.GetDataValue());

			this.AcceptData();

			return true;
		}

		#endregion

		#region[Save Process]

		private string GetSaveStr()
		{
			string cmdText = ""
				+ "SELECT SLIP_CODE"
				+ "  FROM OCS0103"
				+ " WHERE HANGMOG_CODE = :f_conv_hangmog"
				+ "   AND ROWNUM       = 1"
                + "   AND HOSP_CODE    = :f_hosp_code";
			IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
			bindVars.Add("f_conv_hangmog",fbxConvHangmog_code.GetDataValue());
            bindVars.Add("f_hosp_code",   mHospCode);
			object retVal = Service.ExecuteScalar(cmdText,bindVars);

			if(retVal != null)
			{
				saveBindVars.Add("f_user_id",UserInfo.UserID);
				saveBindVars.Add("f_slip_code", retVal.ToString());
                saveBindVars.Add("f_hosp_code", mHospCode);

				saveStr = @"
						BEGIN

							IF :f_gubun = 0 THEN
								UPDATE OCS0303
							       SET UPD_ID       = :f_user_id     ,
									   UPD_DATE     = SYSDATE        ,
									   HANGMOG_CODE = :f_conv_hangmog
							     WHERE HANGMOG_CODE = :f_hangmog_code
                                   AND HOSP_CODE    = :f_hosp_code;
							ELSE
								UPDATE OCS0203 A
								   SET A.UPD_ID       = :f_user_id     ,
									   A.UPD_DATE     = SYSDATE        ,
									   A.OFTEN_USE    = 'Y'
								 WHERE A.HANGMOG_CODE = :f_conv_hangmog
								   AND A.OFTEN_USE    = 'N'
                                   AND A.HOSP_CODE      = :f_hosp_code
								   AND EXISTS ( SELECT 'X'
												  FROM OCS0203 B
								   				 WHERE B.MEMB         = A.MEMB
                                                   AND B.HOSP_CODE    = A.HOSP_CODE
												   AND B.OFTEN_USE    = 'Y'
												   AND B.HANGMOG_CODE = :f_hangmog_code );

								UPDATE OCS0203 A
								   SET A.UPD_ID        = :f_user_id     ,
									   A.UPD_DATE     = SYSDATE        ,
									   A.OFTEN_USE    = 'N'
								 WHERE A.HANGMOG_CODE = :f_hangmog_code
                                   AND A.HOSP_CODE      = :f_hosp_code
								   AND EXISTS ( SELECT 'X'
												  FROM OCS0203 B
												 WHERE B.MEMB         = A.MEMB
                                                   AND B.HOSP_CODE    = A.HOSP_CODE
												   AND B.OFTEN_USE    = 'Y'
												   AND B.HANGMOG_CODE = :f_conv_hangmog );

								UPDATE OCS0203 A
								   SET A.UPD_ID       = :f_user_id     ,
									   A.UPD_DATE     = SYSDATE        ,
									   A.SLIP_CODE    = :f_slip_code   ,
									   A.HANGMOG_CODE = :f_conv_hangmog
								 WHERE A.HANGMOG_CODE = :f_hangmog_code
                                   AND A.HOSP_CODE      = :f_hosp_code
								   AND A.OFTEN_USE    = 'Y'
								   AND NOT EXISTS ( SELECT 'X'
													  FROM OCS0203 B
													 WHERE B.MEMB         = A.MEMB
                                                       AND B.HOSP_CODE    = A.HOSP_CODE
													   AND B.HANGMOG_CODE = :f_conv_hangmog );
							END IF;

						END;";
				saveStr = saveStr.Replace("\r","");
			}
			else
			{
				saveStr = "";
			}

			return saveStr;
		}

		#endregion
	}
}

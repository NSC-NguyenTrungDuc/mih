using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.NURI
{
	/// <summary>
	/// INPDateForm에 대한 요약 설명입니다.
	/// </summary>
	public class INPDateForm : IHIS.Framework.XForm
	{
		#region 자동생성
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XPictureBox xPictureBox1;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XLabel xLabel8;
		private IHIS.Framework.XLabel lblTotalTitle;
		private IHIS.Framework.XLabel lblBeforeTitle;
		private IHIS.Framework.XLabel lblAfetTitle;
		private IHIS.Framework.XDatePicker dtpFromIpwonDate;
		private IHIS.Framework.XDatePicker dtpToIpwonDate;
		private IHIS.Framework.XEditMask mskFromIpwonTime;
		private IHIS.Framework.XEditMask mskToIpwonTime;
		private IHIS.Framework.XButtonList btnList;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public INPDateForm(string aPkinp1001, string aBunho, string aSuname, string aIpwonDate, string aIpwonTime)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			lblTotalTitle.Text = "▶ ";
			lblTotalTitle.Text += aBunho + "  ";
			lblTotalTitle.Text += aSuname ;

			// 입원일자
			this.dtpFromIpwonDate.SetEditValue(aIpwonDate);
			this.dtpFromIpwonDate.AcceptData();

			// 입원시간
			this.mskFromIpwonTime.SetEditValue(aIpwonTime);
			this.mskFromIpwonTime.AcceptData();

			// PK 셋팅
			this.mPkinp1001 = aPkinp1001;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INPDateForm));
            this.lblTotalTitle = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.lblBeforeTitle = new IHIS.Framework.XLabel();
            this.lblAfetTitle = new IHIS.Framework.XLabel();
            this.xPictureBox1 = new IHIS.Framework.XPictureBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.dtpFromIpwonDate = new IHIS.Framework.XDatePicker();
            this.dtpToIpwonDate = new IHIS.Framework.XDatePicker();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.mskFromIpwonTime = new IHIS.Framework.XEditMask();
            this.mskToIpwonTime = new IHIS.Framework.XEditMask();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(488, 42);
            this.lblTotalTitle.TabIndex = 1;
            // 
            // xLabel2
            // 
            this.xLabel2.Location = new System.Drawing.Point(10, 58);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(488, 78);
            this.xLabel2.TabIndex = 2;
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Image = ((System.Drawing.Image)(resources.GetObject("xLabel5.Image")));
            this.xLabel5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel5.Location = new System.Drawing.Point(356, 20);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(126, 22);
            this.xLabel5.TabIndex = 118;
            this.xLabel5.Text = "    [ 入院日変更 ]";
            // 
            // lblBeforeTitle
            // 
            this.lblBeforeTitle.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBeforeTitle.EdgeRounding = false;
            this.lblBeforeTitle.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblBeforeTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBeforeTitle.Location = new System.Drawing.Point(24, 72);
            this.lblBeforeTitle.Name = "lblBeforeTitle";
            this.lblBeforeTitle.Size = new System.Drawing.Size(22, 48);
            this.lblBeforeTitle.TabIndex = 119;
            // 
            // lblAfetTitle
            // 
            this.lblAfetTitle.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblAfetTitle.EdgeRounding = false;
            this.lblAfetTitle.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblAfetTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAfetTitle.Location = new System.Drawing.Point(272, 72);
            this.lblAfetTitle.Name = "lblAfetTitle";
            this.lblAfetTitle.Size = new System.Drawing.Size(22, 48);
            this.lblAfetTitle.TabIndex = 120;
            // 
            // xPictureBox1
            // 
            this.xPictureBox1.BackColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xPictureBox1.Image")));
            this.xPictureBox1.Location = new System.Drawing.Point(248, 84);
            this.xPictureBox1.Name = "xPictureBox1";
            this.xPictureBox1.Protect = false;
            this.xPictureBox1.Size = new System.Drawing.Size(16, 22);
            this.xPictureBox1.TabIndex = 121;
            this.xPictureBox1.TabStop = false;
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel4.Location = new System.Drawing.Point(52, 100);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(68, 20);
            this.xLabel4.TabIndex = 123;
            this.xLabel4.Text = "入院時間";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFromIpwonDate
            // 
            this.dtpFromIpwonDate.IsJapanYearType = true;
            this.dtpFromIpwonDate.Location = new System.Drawing.Point(120, 72);
            this.dtpFromIpwonDate.Name = "dtpFromIpwonDate";
            this.dtpFromIpwonDate.Protect = true;
            this.dtpFromIpwonDate.ReadOnly = true;
            this.dtpFromIpwonDate.Size = new System.Drawing.Size(114, 20);
            this.dtpFromIpwonDate.TabIndex = 124;
            this.dtpFromIpwonDate.TabStop = false;
            this.dtpFromIpwonDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpToIpwonDate
            // 
            this.dtpToIpwonDate.IsJapanYearType = true;
            this.dtpToIpwonDate.Location = new System.Drawing.Point(368, 72);
            this.dtpToIpwonDate.Name = "dtpToIpwonDate";
            this.dtpToIpwonDate.Size = new System.Drawing.Size(114, 20);
            this.dtpToIpwonDate.TabIndex = 126;
            this.dtpToIpwonDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpToIpwonDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToIpwonDate_DataValidating);
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel6.Location = new System.Drawing.Point(300, 72);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(68, 20);
            this.xLabel6.TabIndex = 125;
            this.xLabel6.Text = "入院日";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel7.Location = new System.Drawing.Point(52, 72);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(68, 20);
            this.xLabel7.TabIndex = 127;
            this.xLabel7.Text = "入院日";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mskFromIpwonTime
            // 
            this.mskFromIpwonTime.EditMaskType = IHIS.Framework.MaskType.Time;
            this.mskFromIpwonTime.Location = new System.Drawing.Point(120, 100);
            this.mskFromIpwonTime.Mask = "HH:MI";
            this.mskFromIpwonTime.Name = "mskFromIpwonTime";
            this.mskFromIpwonTime.Protect = true;
            this.mskFromIpwonTime.ReadOnly = true;
            this.mskFromIpwonTime.Size = new System.Drawing.Size(58, 20);
            this.mskFromIpwonTime.TabIndex = 128;
            this.mskFromIpwonTime.TabStop = false;
            this.mskFromIpwonTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mskToIpwonTime
            // 
            this.mskToIpwonTime.EditMaskType = IHIS.Framework.MaskType.Time;
            this.mskToIpwonTime.Location = new System.Drawing.Point(368, 100);
            this.mskToIpwonTime.Mask = "HH:MI";
            this.mskToIpwonTime.Name = "mskToIpwonTime";
            this.mskToIpwonTime.Size = new System.Drawing.Size(58, 20);
            this.mskToIpwonTime.TabIndex = 130;
            this.mskToIpwonTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel8.Location = new System.Drawing.Point(300, 100);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(68, 20);
            this.xLabel8.TabIndex = 129;
            this.xLabel8.Text = "入院時間";
            this.xLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(0, 144);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Process;
            this.btnList.Size = new System.Drawing.Size(508, 34);
            this.btnList.TabIndex = 131;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // INPDateForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(508, 200);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.mskToIpwonTime);
            this.Controls.Add(this.xLabel8);
            this.Controls.Add(this.mskFromIpwonTime);
            this.Controls.Add(this.xLabel7);
            this.Controls.Add(this.dtpToIpwonDate);
            this.Controls.Add(this.xLabel6);
            this.Controls.Add(this.dtpFromIpwonDate);
            this.Controls.Add(this.xLabel4);
            this.Controls.Add(this.xPictureBox1);
            this.Controls.Add(this.lblAfetTitle);
            this.Controls.Add(this.lblBeforeTitle);
            this.Controls.Add(this.xLabel5);
            this.Controls.Add(this.xLabel2);
            this.Controls.Add(this.lblTotalTitle);
            this.Name = "INPDateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入院日変更";
            this.Load += new System.EventHandler(this.INPDateForm_Load);
            this.Controls.SetChildIndex(this.lblTotalTitle, 0);
            this.Controls.SetChildIndex(this.xLabel2, 0);
            this.Controls.SetChildIndex(this.xLabel5, 0);
            this.Controls.SetChildIndex(this.lblBeforeTitle, 0);
            this.Controls.SetChildIndex(this.lblAfetTitle, 0);
            this.Controls.SetChildIndex(this.xPictureBox1, 0);
            this.Controls.SetChildIndex(this.xLabel4, 0);
            this.Controls.SetChildIndex(this.dtpFromIpwonDate, 0);
            this.Controls.SetChildIndex(this.xLabel6, 0);
            this.Controls.SetChildIndex(this.dtpToIpwonDate, 0);
            this.Controls.SetChildIndex(this.xLabel7, 0);
            this.Controls.SetChildIndex(this.mskFromIpwonTime, 0);
            this.Controls.SetChildIndex(this.xLabel8, 0);
            this.Controls.SetChildIndex(this.mskToIpwonTime, 0);
            this.Controls.SetChildIndex(this.btnList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Form 변수

		private string mMsg = "";
		private string mCaption = "";
		private string mPkinp1001 = "";

		#endregion

		private void INPDateForm_Load(object sender, System.EventArgs e)
		{
			/* Label 텍스트 설정 */
			this.lblBeforeTitle.Text = "変\n更\n前";
			this.lblAfetTitle.Text = "変\n更\n後";
		}

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process:

					e.IsBaseCall = false;

                    if (mPkinp1001.Length == 0)
                    {
                        XMessageBox.Show(EnvironInfo.GetServerMsg(321));
                        return;
                    }

                    if (this.dtpFromIpwonDate.GetDataValue().Length == 0)
                    {
                        XMessageBox.Show(EnvironInfo.GetServerMsg(322));
                        return;
                    }

                    if (this.mskFromIpwonTime.GetDataValue().Length == 0)
                    {
                        XMessageBox.Show(EnvironInfo.GetServerMsg(323));
                        return;
                    }

                    if (this.dtpToIpwonDate.GetDataValue().Length == 0)
                    {
                        XMessageBox.Show(EnvironInfo.GetServerMsg(324));
                        return;
                    }

                    if (this.mskToIpwonTime.GetDataValue().Length == 0)
                    {
                        XMessageBox.Show(EnvironInfo.GetServerMsg(325));
                        return;
                    }

					this.mMsg = (NetInfo.Language == LangMode.Ko ? "입원일 변경을 하시겠습니까?" 
						: "入院日を変更しますか?");
					this.mCaption = (NetInfo.Language == LangMode.Ko ? "입원일변경" : "入院日変更");

					if (XMessageBox.Show(this.mMsg, this.mCaption, MessageBoxButtons.YesNo) == DialogResult.Yes)
					{

						ArrayList inputList = new ArrayList();
						ArrayList outputList = new ArrayList();

						inputList.Add(UserInfo.UserID);
						inputList.Add(mPkinp1001);
						inputList.Add(this.dtpFromIpwonDate.GetDataValue());
						inputList.Add(this.dtpToIpwonDate.GetDataValue());
						inputList.Add(this.mskFromIpwonTime.GetDataValue());
						inputList.Add(this.mskToIpwonTime.GetDataValue());
						inputList.Add("N");
						inputList.Add("N");

                        Service.BeginTransaction();

                        try
                        {
                            if (!Service.ExecuteProcedure("PR_INP_UPDATE_IPWON_DATE", inputList, outputList))
                            {
                                XMessageBox.Show(Service.ErrFullMsg + " : PR_INP_UPDATE_IPWON_DATE Error");
                                throw new Exception();
                            }
                            else
                            {
                                if (outputList[0].ToString() != "0")
                                {
                                    XMessageBox.Show(outputList[1].ToString());
                                    throw new Exception();
                                }

                                Service.CommitTransaction();

                                mMsg = (NetInfo.Language == LangMode.Ko ? "정상적으로 처리 되었습니다" : "処理が完了しました");
                                XMessageBox.Show(mMsg);
                            }
                        }
                        catch
                        {
                            Service.RollbackTransaction();
                        }
					}
					break;
			}
		}

        private void dtpToIpwonDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                return;
            }

            //입원일보다 과거로만 수정가능
            DateTime fromIpwonDate = Convert.ToDateTime(this.dtpFromIpwonDate.GetDataValue());
            DateTime toIpwonDate = Convert.ToDateTime(e.DataValue);

            if (toIpwonDate >= fromIpwonDate)
            {
                XMessageBox.Show("入院日の変更には現在の入院日より過去の日付を入力してください。", "日付確認", MessageBoxIcon.Warning);
                e.Cancel = true;
            }

        }
	}
}

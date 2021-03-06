using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;

namespace IHIS.Framework
{
	/// <summary>
	/// ErrorLogForm에 대한 요약 설명입니다.
	/// </summary>
	internal class ErrorLogForm : System.Windows.Forms.Form
	{
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XButton btnContinue;
        private IHIS.Framework.XButton btnSend;
		private System.Windows.Forms.Label lbTitle;
        private XRichTextBox txtErrDescription;
        private Label lbDescription;
        private Label lbErrMsg;
        private LinkLabel lkLblKarteJP;
        private LinkLabel lkLblKarteVN;
        private Label lbJP;
        private Label lbVN;
        private Label label1;
        private Label label2;
		private System.ComponentModel.IContainer components = null;

		public ErrorLogForm(string errMsg)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			SetControlTextByLangMode();
			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			this.lbErrMsg.Text = errMsg;
		}

        public ErrorLogForm(string errMsg, string errDescription)
        {
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();

            SetControlTextByLangMode();
            //
            // TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
            //
            this.lbErrMsg.Text = errMsg;
            this.txtErrDescription.Text = errDescription;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorLogForm));
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnSend = new IHIS.Framework.XButton();
            this.btnContinue = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.txtErrDescription = new IHIS.Framework.XRichTextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbErrMsg = new System.Windows.Forms.Label();
            this.lkLblKarteJP = new System.Windows.Forms.LinkLabel();
            this.lkLblKarteVN = new System.Windows.Forms.LinkLabel();
            this.lbJP = new System.Windows.Forms.Label();
            this.lbVN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Brown;
            this.lbTitle.Location = new System.Drawing.Point(2, 6);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(438, 18);
            this.lbTitle.TabIndex = 3;
            this.lbTitle.Text = "※ An unexpected error has ocurred. ";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(494, 282);
            this.btnSend.Name = "btnSend";
            this.btnSend.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnSend.Size = new System.Drawing.Size(90, 28);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "오류전송";
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinue.Image = ((System.Drawing.Image)(resources.GetObject("btnContinue.Image")));
            this.btnContinue.Location = new System.Drawing.Point(408, 282);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnContinue.Size = new System.Drawing.Size(80, 28);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "계 속";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(320, 282);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "종 료";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtErrDescription
            // 
            this.txtErrDescription.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGray);
            this.txtErrDescription.Location = new System.Drawing.Point(5, 144);
            this.txtErrDescription.Name = "txtErrDescription";
            this.txtErrDescription.Size = new System.Drawing.Size(575, 132);
            this.txtErrDescription.TabIndex = 5;
            this.txtErrDescription.Text = "";
            // 
            // lbDescription
            // 
            this.lbDescription.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescription.ForeColor = System.Drawing.Color.Brown;
            this.lbDescription.Location = new System.Drawing.Point(5, 123);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(438, 18);
            this.lbDescription.TabIndex = 7;
            this.lbDescription.Text = "※ Error description:";
            this.lbDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbErrMsg
            // 
            this.lbErrMsg.Location = new System.Drawing.Point(4, 33);
            this.lbErrMsg.Name = "lbErrMsg";
            this.lbErrMsg.Size = new System.Drawing.Size(578, 53);
            this.lbErrMsg.TabIndex = 4;
            // 
            // lkLblKarteJP
            // 
            this.lkLblKarteJP.AutoSize = true;
            this.lkLblKarteJP.Location = new System.Drawing.Point(39, 80);
            this.lkLblKarteJP.Name = "lkLblKarteJP";
            this.lkLblKarteJP.Size = new System.Drawing.Size(115, 13);
            this.lkLblKarteJP.TabIndex = 8;
            this.lkLblKarteJP.TabStop = true;
            this.lkLblKarteJP.Text = "https://karte.clinic";
            this.lkLblKarteJP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // lkLblKarteVN
            // 
            this.lkLblKarteVN.AutoSize = true;
            this.lkLblKarteVN.Location = new System.Drawing.Point(39, 100);
            this.lkLblKarteVN.Name = "lkLblKarteVN";
            this.lkLblKarteVN.Size = new System.Drawing.Size(149, 13);
            this.lkLblKarteVN.TabIndex = 9;
            this.lkLblKarteVN.TabStop = true;
            this.lkLblKarteVN.Text = "http://www.karteclinic.vn";
            this.lkLblKarteVN.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // lbJP
            // 
            this.lbJP.Location = new System.Drawing.Point(155, 82);
            this.lbJP.Name = "lbJP";
            this.lbJP.Size = new System.Drawing.Size(103, 20);
            this.lbJP.TabIndex = 10;
            this.lbJP.Text = "(for Japanese)";
            // 
            // lbVN
            // 
            this.lbVN.Location = new System.Drawing.Point(191, 101);
            this.lbVN.Name = "lbVN";
            this.lbVN.Size = new System.Drawing.Size(103, 22);
            this.lbVN.TabIndex = 11;
            this.lbVN.Text = "(for Vietnamese)";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "-";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "-";
            // 
            // ErrorLogForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(588, 318);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbVN);
            this.Controls.Add(this.lbJP);
            this.Controls.Add(this.lkLblKarteVN);
            this.Controls.Add(this.lkLblKarteJP);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.txtErrDescription);
            this.Controls.Add(this.lbErrMsg);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ErrorLogForm";
            this.Padding = new System.Windows.Forms.Padding(5, 30, 5, 30);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System error";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void btnContinue_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		//일본어, 한글 모드에 따른 Text 설정
		private void SetControlTextByLangMode()
		{
            try
            {
                this.Text = XMsg.GetMsg("M007"); // 시스템 에러
                this.lbTitle.Text = XMsg.GetMsg("M008"); // 시스템에서  다음과  같은  에러가  발생하였습니다.
                this.btnClose.Text = XMsg.GetField("F010"); //종 료
                this.btnContinue.Text = XMsg.GetField("F011"); //계 속
                this.btnSend.Text = XMsg.GetField("F012"); //오류전송
                this.lbDescription.Text = XMsg.GetField("F056");
                this.lbJP.Text = XMsg.GetField("F057");
                this.lbVN.Text = XMsg.GetField("F058");
                this.lkLblKarteJP.Text = ConfigurationManager.AppSettings["HomepageUrlJP"];
                this.lkLblKarteVN.Text = ConfigurationManager.AppSettings["HomepageUrlVN"];
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
		}

        private void SetErrorDescription()
        {

        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LinkLabel lbl = sender as LinkLabel;
                string hpURL = "";

                // Determine which link was clicked within the LinkLabel.
                lbl.Links[lbl.Links.IndexOf(e.Link)].Visited = true;

                if (lbl.Name == lkLblKarteJP.Name)
                {
                    // Karte Clinic JP
                    hpURL = ConfigurationManager.AppSettings["HomepageUrlJP"];
                }
                else
                {
                    // Karte Clinic VN
                    hpURL = ConfigurationManager.AppSettings["HomepageUrlVN"];
                }

                // Navigate to Karte Clinic homepage
                System.Diagnostics.Process.Start(hpURL);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex.Message);
                Logs.WriteLog(ex.StackTrace);
            }
            finally { }
        }
	}
}

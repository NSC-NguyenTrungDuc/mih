using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using Microsoft.Win32;
using IHIS.Properties;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Endo;

namespace IHIS
{
    /// <summary>
    /// FormSelectHospCode
    /// </summary>
    internal class FormSelectHospCode : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtHospCode;
        private IHIS.XPButton btnConfirm;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Label label2;
        private Label lbSystem;
        private XPButton btnClose;

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectHospCode));
            this.txtHospCode = new System.Windows.Forms.TextBox();
            this.btnConfirm = new IHIS.XPButton();
            this.lbMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSystem = new System.Windows.Forms.Label();
            this.btnClose = new IHIS.XPButton();
            this.SuspendLayout();
            // 
            // txtHospCode
            // 
            this.txtHospCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtHospCode, "txtHospCode");
            this.txtHospCode.Name = "txtHospCode";
            // 
            // btnConfirm
            // 
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbMsg
            // 
            this.lbMsg.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lbMsg, "lbMsg");
            this.lbMsg.ForeColor = System.Drawing.Color.IndianRed;
            this.lbMsg.Name = "lbMsg";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lbSystem
            // 
            this.lbSystem.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lbSystem, "lbSystem");
            this.lbSystem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbSystem.Name = "lbSystem";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.xpButton1_Click);
            // 
            // FormSelectHospCode
            // 
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = global::IHIS.Properties.Resources.FormSelectHospCode;
            this.CancelButton = this.btnClose;
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbSystem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.txtHospCode);
            this.Controls.Add(this.btnConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSelectHospCode";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private string hospName = "";

        public string HospName
        {
            get { return hospName; }
        }

        public FormSelectHospCode()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtHospCode.Text.Trim() == "") return;

            try
            {
                FormSelectHospCodeArgs args = new FormSelectHospCodeArgs();
                args.HospCode = txtHospCode.Text.Trim();
                FormSelectHospCodeResult res = CloudService.Instance.Submit<FormSelectHospCodeResult, FormSelectHospCodeArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (res.HospCode != "")
                    {
                        if (!CacheService.Instance.IsSet("CACHE_HOSP_CODE"))
                        {
                            CacheService.Instance.Set("CACHE_HOSP_CODE", res.HospCode, TimeSpan.MaxValue);
                        }
                        CacheService.Instance.Set("CACHE_HOSP_CODE", res.HospCode, TimeSpan.MaxValue);

                        //if (!CacheService.Instance.IsSet("CACHE_HOSP_NAME"))
                        //{
                        //    CacheService.Instance.Set("CACHE_HOSP_NAME", res.HospName, TimeSpan.MaxValue);
                        //}

                        this.hospName = res.HospName;
                        UserInfo.VpnYn = res.VpnYn == "Y";

                        // Close this form
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        // Hosp code does not exist
                        lbMsg.Text = string.Format(Resources.MSG005, txtHospCode.Text.Trim());
                        txtHospCode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.WriteLog("FormSelectHospCodeRequest exception: " + ex.Message);
                Application.Exit();
            }
        }

        private void xpButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
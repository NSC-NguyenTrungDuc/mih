using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using IHIS.Framework;

namespace IHIS
{
    /// <summary>
    /// StartingForm에 대한 요약 설명입니다.
    /// </summary>
    internal class StartingForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;

        public StartingForm(int autoHideSecond)
        {
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();

            SetBackgroundImage();

            //자동숨김 초 설정
            if (autoHideSecond > 0)
            {
                this.timer1.Interval = autoHideSecond * 1000;
                this.timer1.Enabled = true;
                this.timer1.Start();
            }
        }

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StartingForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(239, 44);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(239, 44);
            this.MinimumSize = new System.Drawing.Size(239, 44);
            this.Name = "StartingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }
        #endregion

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            //화면 닫기
            this.Close();
            this.Dispose();
        }

        private void SetBackgroundImage()
        {
            //한국어,일본어 모드에 따라 배경 이미지 설정
            try
            {
                string resName = "";
                switch (NetInfo.Language)
                {
                    case LangMode.En:
                        resName = "IHIS.Images.StartingFormEn.gif";
                        break;
                    case LangMode.Jr:
                        resName = "IHIS.Images.StartingFormJr.gif";
                        break;
                    case LangMode.Ko:
                        resName = "IHIS.Images.StartingFormKo.gif";
                        break;
                    case LangMode.Vi:
                        resName = "IHIS.Images.StartingFormVi.gif";
                        break;
                    default:
                        resName = "IHIS.Images.StartingFormJr.gif";
                        break;
                }
                System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
                this.BackgroundImage = (Bitmap)Bitmap.FromStream(l_as.GetManifestResourceStream(resName));
            }
            catch { }

        }
    }
}

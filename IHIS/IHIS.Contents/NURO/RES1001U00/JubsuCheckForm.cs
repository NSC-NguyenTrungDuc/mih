using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.X;

namespace IHIS.NURO
{
    /// <summary>
    /// JubsuCheckForm에 대한 요약 설명입니다.
    /// </summary>
    public class JubsuCheckForm : IHIS.Framework.XForm
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel lbDoctorName;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XDisplayBox dbxMagamTime1;
        private IHIS.Framework.XDisplayBox dbxMagamTime;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDisplayBox xDisplayBox2;
        private IHIS.Framework.XDisplayBox dbxTitle;
        //private IHIS.Framework.DataServiceSISO dsvQryMagamInfo;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XButton btnOK;
        private IHIS.Framework.XButton btnNo;
        private System.Windows.Forms.ImageList ImageList;
        private SingleLayout layQryMagamInfo;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private System.ComponentModel.IContainer components;

        public JubsuCheckForm(string aMagamDate, string aDoctor, string aGwa)
        {
            //
            // Windows Form 디자이너 지원에 필요합니다.
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
            //

            this.mGwa = aGwa;
            this.mDoctor = aDoctor;
            this.mMagamDate = aMagamDate;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JubsuCheckForm));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnNo = new IHIS.Framework.XButton();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.btnOK = new IHIS.Framework.XButton();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.lbDoctorName = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dbxMagamTime1 = new IHIS.Framework.XDisplayBox();
            this.dbxMagamTime = new IHIS.Framework.XDisplayBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xDisplayBox2 = new IHIS.Framework.XDisplayBox();
            this.dbxTitle = new IHIS.Framework.XDisplayBox();
            this.layQryMagamInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.btnNo);
            this.xPanel1.Controls.Add(this.btnOK);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.Controls.Add(this.xLabel7);
            this.xPanel1.Controls.Add(this.xLabel6);
            this.xPanel1.Controls.Add(this.lbDoctorName);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.dbxMagamTime1);
            this.xPanel1.Controls.Add(this.dbxMagamTime);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.xDisplayBox2);
            this.xPanel1.Controls.Add(this.dbxTitle);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnNo
            // 
            this.btnNo.AccessibleDescription = null;
            this.btnNo.AccessibleName = null;
            resources.ApplyResources(this.btnNo, "btnNo");
            this.btnNo.BackgroundImage = null;
            this.btnNo.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Image")));
            this.btnNo.ImageIndex = 1;
            this.btnNo.ImageList = this.ImageList;
            this.btnNo.Name = "btnNo";
            this.btnNo.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // btnOK
            // 
            this.btnOK.AccessibleDescription = null;
            this.btnOK.AccessibleName = null;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.BackgroundImage = null;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageIndex = 0;
            this.btnOK.ImageList = this.ImageList;
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BorderColor = IHIS.Framework.XColor.XFormBackColor;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BorderColor = IHIS.Framework.XColor.XFormBackColor;
            this.xLabel7.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BorderColor = IHIS.Framework.XColor.XFormBackColor;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // lbDoctorName
            // 
            this.lbDoctorName.AccessibleDescription = null;
            this.lbDoctorName.AccessibleName = null;
            resources.ApplyResources(this.lbDoctorName, "lbDoctorName");
            this.lbDoctorName.BorderColor = IHIS.Framework.XColor.XFormBackColor;
            this.lbDoctorName.Image = null;
            this.lbDoctorName.Name = "lbDoctorName";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BorderColor = IHIS.Framework.XColor.XFormBackColor;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XFormBackColor;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // dbxMagamTime1
            // 
            this.dbxMagamTime1.AccessibleDescription = null;
            this.dbxMagamTime1.AccessibleName = null;
            resources.ApplyResources(this.dbxMagamTime1, "dbxMagamTime1");
            this.dbxMagamTime1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Khaki);
            this.dbxMagamTime1.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.dbxMagamTime1.Image = null;
            this.dbxMagamTime1.Mask = "##:##";
            this.dbxMagamTime1.Name = "dbxMagamTime1";
            // 
            // dbxMagamTime
            // 
            this.dbxMagamTime.AccessibleDescription = null;
            this.dbxMagamTime.AccessibleName = null;
            resources.ApplyResources(this.dbxMagamTime, "dbxMagamTime");
            this.dbxMagamTime.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Khaki);
            this.dbxMagamTime.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.dbxMagamTime.Image = null;
            this.dbxMagamTime.Mask = "##:##";
            this.dbxMagamTime.Name = "dbxMagamTime";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
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
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // xDisplayBox2
            // 
            this.xDisplayBox2.AccessibleDescription = null;
            this.xDisplayBox2.AccessibleName = null;
            resources.ApplyResources(this.xDisplayBox2, "xDisplayBox2");
            this.xDisplayBox2.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.xDisplayBox2.Image = null;
            this.xDisplayBox2.Name = "xDisplayBox2";
            // 
            // dbxTitle
            // 
            this.dbxTitle.AccessibleDescription = null;
            this.dbxTitle.AccessibleName = null;
            resources.ApplyResources(this.dbxTitle, "dbxTitle");
            this.dbxTitle.BackColor = IHIS.Framework.XColor.XFormBackColor;
            this.dbxTitle.Image = null;
            this.dbxTitle.Name = "dbxTitle";
            // 
            // layQryMagamInfo
            // 
            this.layQryMagamInfo.ExecuteQuery = null;
            this.layQryMagamInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3});
            this.layQryMagamInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layQryMagamInfo.ParamList")));
            this.layQryMagamInfo.QuerySQL = resources.GetString("layQryMagamInfo.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "doctor_name";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "magam_time_am";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "magam_time_pm";
            // 
            // JubsuCheckForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "JubsuCheckForm";
            this.Load += new System.EventHandler(this.JubsuCheckForm_Load);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.xPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Form 변수

        private string mGwa = "";
        private string mDoctor = "";
        private string mMagamDate = "";

        #endregion

        #region Form Load

        private void JubsuCheckForm_Load(object sender, System.EventArgs e)
        {
            this.btnOK.Image = this.ImageList.Images[0];
            this.btnNo.Image = this.ImageList.Images[1];
            this.LoadDoctorData();
        }

        #endregion

        #region DataLoad

        private void LoadDoctorData()
        {
            this.layQryMagamInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layQryMagamInfo.SetBindVarValue("f_magam_date", this.mMagamDate);
            //this.layQryMagamInfo.SetBindVarValue("gwa", this.mGwa); PC파일에서 파싱안되고 있음
            this.layQryMagamInfo.SetBindVarValue("f_doctor", this.mDoctor);

            this.layQryMagamInfo.QueryLayout();

            // 데이터 셋팅
            this.lbDoctorName.Text = "☞ " + this.layQryMagamInfo.GetItemValue("doctor_name").ToString();
            this.dbxMagamTime.SetDataValue(this.layQryMagamInfo.GetItemValue("magam_time_am").ToString());
            this.dbxMagamTime1.SetDataValue(this.layQryMagamInfo.GetItemValue("magam_time_pm").ToString());
        }

        #endregion

        #region XButton

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void btnNo_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        #endregion
    }
}

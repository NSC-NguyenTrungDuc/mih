using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCS;
using IHIS.OCSA.Properties;
using PatientInfo = IHIS.OCS.PatientInfo;

namespace IHIS.OCSA
{
    public partial class OCS0103U18 : XScreen
    {

        #region Constructor

        private UCOCS0103U18 mainControl;
        public OCS0103U18()
        {
            InitializeComponent();
            this.mainControl = new IHIS.OCSA.UCOCS0103U18();
            this.pnlFill.Controls.Add(this.mainControl);
            this.mainControl.Name = "OCS0103U15";
            this.mainControl.Dock = DockStyle.Fill;
            this.mainControl.Location = new Point(0, 0);
            this.mainControl.Size = new Size(1300, 531);

            this.mainControl.MContainer = this;
            //  this.mainControl.MOpener = this.Opener;
            this.mainControl.MbtnCopy = this.btnCopy;
            this.mainControl.MbtnList = this.btnList;
            this.mainControl.MbtnPaste = this.btnPaste;
            this.mainControl.MpnlTop = this.pnlTop;
            //this.mainControl.MdbxAge_Sex = this.dbxAge_Sex;
            //this.mainControl.MdbxGubun_name = this.dbxGubun_name;
            //this.mainControl.MdbxInputGubunName = this.dbxInputGubunName;
            //this.mainControl.MdbxSuname = this.dbxSuname;
            //this.mainControl.MdbxWeight_height = this.dbxWeight_height;
            //this.mainControl.MdpkOrder_Date = this.dpkOrder_Date;
            //this.mainControl.MfbxBunho = this.fbxBunho;

            //MED6991
            InitializeLookAndFeel();
            xFlatLabel3.Visible = true;

        }

        #endregion

        private void InitializeLookAndFeel()
        {
            if (NetInfo.Language != LangMode.Jr)
            {
                dbxInputGubunName.Width += 10;
            }
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {

            return this.mainControl.Command(command, commandParam);
        }

        #region Event

        #endregion

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnCopyClick(false);
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnCopyClick(true);
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnPasteClick();
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            this.mainControl.HandleBtnListButtonClick(e.Func);
            e.IsBaseCall = false;
        }

        private void btnList_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == null) return;

            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {

                if (this.CurrMQLayout != null) this.mainControl.MOrderBiz.GridDisplayValue((XGrid)this.CurrMQLayout); // 현재 Current Row의 모든 값을 디스플레이한다
            }
        }

        private void OCS0103U10_Closing(object sender, CancelEventArgs e)
        {
            string mbxMsg = "", mbxCap = "";

            // 처방 변경된 자료가 있는 경우 자료 Reset됨을 알림
            // 처방 입력가능여부 이면서 자료 수정여부 체크
            //if (this.IsOrderInputCheck(false, true, false) && this.IsOrderDataModifed())
            //{
            //    mbxMsg = "저장하지 않은 데이타가 존재합니다.\r\n외래처방을 종료하시겠습니까?";
            //    mbxCap = "종료여부";
            //    if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.No)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}

            // 종료 버튼등 클릭여부 Validation Check 안하기 위함
            // Control의 Validation 체크에 의하여 종료가 안되는 것을 푼다... (중요)
            e.Cancel = false;
        }

        private void OCS0103U10_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            string mInputGubunName = this.mainControl.ScreenOpen(this.OpenParam);
            this.mainControl.MOpener = (XScreen)this.Opener;

            if (OpenParam != null) // 다른 화면에서 콜되는 경우
            {
                #region 파라미터 셋팅
                this.dpkOrder_Date.Protect = true;
                this.fbxBunho.Protect = true;
                if (this.OpenParam.Contains("input_gubun"))
                {
                    this.dbxInputGubunName.SetDataValue("【 " + mInputGubunName + " 】");
                }
                // 오더일자
                if (OpenParam.Contains("order_date"))
                {
                    if (dpkOrder_Date != null)
                        dpkOrder_Date.SetDataValue(this.OpenParam["order_date"].ToString());
                }
                else
                {
                    dpkOrder_Date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
                }

                // 환자번호
                if (OpenParam.Contains("bunho"))
                {
                    this.fbxBunho.SetEditValue(OpenParam["bunho"].ToString());
                    this.fbxBunho.AcceptData();
                }


                // 환자정보
                if (OpenParam.Contains("patient_info"))
                {
                    // 환자정보가 있으면 이거 가져다 넣어주ㅝ야 함.
                    this.SetPatientInfo();
                }




                // 오더일자와 환자번호는 변경할수 없도록 프로텍트 처리
                this.dpkOrder_Date.Protect = true;
                this.fbxBunho.Protect = true;

                #endregion


            }

        }

        private void SetPatientInfo()
        {
            try
            {
                // 환자정보
                this.dbxSuname.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["suname"].ToString() + " " + this.mainControl.MPatientInfo.GetPatientInfo["suname2"].ToString());
                // 성별 나이
                this.dbxAge_Sex.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["sex_age"].ToString());
                // 보험 이ㅣ름
                this.dbxGubun_name.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["gubun_name"].ToString());
                // 진료정보 ( 여기다가 뭘 넣을까.... )

                // 신장, 체중
                this.dbxWeight_height.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["weight_height"].ToString());

                //MED-8418
                if (this.mainControl.MPatientInfo.GetPatientInfo["chojae_name"] != null)
                {
                    this.dbxChojae_name.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["chojae_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Exception on Method SetPatientInfo: " + ex.StackTrace);
            }
        }
    }
}

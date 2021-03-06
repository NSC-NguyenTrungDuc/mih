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
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCS;
using IHIS.OCSA.Properties;
using PatientInfo = IHIS.OCS.PatientInfo;

namespace IHIS.OCSA
{
    public partial class OCS0103U19 : XScreen
    {
        private UCOCS0103U19 _mainControl;
        public OCS0103U19()
        {
            InitializeComponent();
            FixFontAndSizeColumns();
            InitMainCotrol();

            //MED6991
            InitializeLookAndFeel();
            //xFlatLabel3.Visible = true;
            //xFlatLabel3.Location = new Point(234, 8);
        }

        private void InitializeLookAndFeel()
        {
            if (NetInfo.Language != LangMode.Jr)
            {
                dbxInputGubunName.Width += 10;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        /// <summary>
        /// Screen Open시 Parameter를 받는다 (등록번호 연계)
        /// </summary>
        /// <remarks>
        /// 해당 등록번호와 내원정보로 외래처방 데이타 조회
        /// </remarks>
        private void OCS0103U10_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            OCS0103U19InitializeScreenResult screebResult;
            _mainControl.ScreenOpen(this.OpenParam, out screebResult);
            this._mainControl.MOpener = (XScreen)this.Opener;
            if (e.OpenParam != null) // 다른 화면에서 콜되는 경우
            {
                // 오더일자
                if (this.OpenParam.Contains("order_date"))
                {
                    this.dpkOrder_Date.SetDataValue(this.OpenParam["order_date"].ToString());
                }
                else
                {
                    this.dpkOrder_Date.SetDataValue(
                        DateTime.Parse(screebResult.SysDate).ToString("yyyy/MM/dd").Replace("-", "/"));
                }
                // 환자번호
                if (this.OpenParam.Contains("bunho"))
                {
                    this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                    this.fbxBunho.AcceptData();
                }
                // 환자정보
                if (this.OpenParam.Contains("patient_info"))
                {
                    // 환자정보가 있으면 이거 가져다 넣어주ㅝ야 함.
                    this.SetPatientInfo();
                }
                // 입력구분 셋팅
                if (this.OpenParam.Contains("input_gubun"))
                {
                    this.dbxInputGubunName.SetDataValue("【 " + screebResult.Code + " 】");
                }

                //DatePicker 문제로 일단        Reset하고 현재일자를 넣어준다.
                if (this.dpkOrder_Date.GetDataValue() == "")
                {
                    this.dpkOrder_Date.SetDataValue(DateTime.Parse(screebResult.SysDate).ToString("yyyy/MM/dd"));
                }
                // 오더일자와 환자번호는 변경할수 없도록 프로텍트 처리
                this.dpkOrder_Date.Protect = true;
                this.fbxBunho.Protect = true;
            }
        }
        private void OCS0103U10_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }
        private void InitMainCotrol()
        {
            _mainControl = new UCOCS0103U19();
            _mainControl.Size = new Size(this.pnlFill.Size.Width, this.pnlFill.Size.Height);
            this.pnlFill.Controls.Add(this._mainControl);
            this._mainControl.MContainer = this;
            this._mainControl.MPnlTop = this.pnlTop;
            this._mainControl.MBtnList = this.btnList;
            this._mainControl.MBtnCopy = this.btnCopy;
            this._mainControl.MBtnPaste = this.btnPaste;
            this._mainControl.MPbxCopy = this.pbxCopy;    
        }
        private void SetPatientInfo()
        {
            try
            {
                // 환자정보
                this.dbxSuname.SetDataValue(this._mainControl.MPatientInfo.GetPatientInfo["suname"].ToString() + " " + this._mainControl.MPatientInfo.GetPatientInfo["suname2"].ToString());
                // 성별 나이
                this.dbxAge_Sex.SetDataValue(this._mainControl.MPatientInfo.GetPatientInfo["sex_age"].ToString());
                // 보험 이ㅣ름
                this.dbxGubun_name.SetDataValue(this._mainControl.MPatientInfo.GetPatientInfo["gubun_name"].ToString());
                // 진료정보 ( 여기다가 뭘 넣을까.... )
                // 신장, 체중
                this.dbxWeight_height.SetDataValue(this._mainControl.MPatientInfo.GetPatientInfo["weight_height"].ToString());

                //MED-8418
                if (this._mainControl.MPatientInfo.GetPatientInfo["chojae_name"] != null)
                {
                    this.dbxChojae_name.SetDataValue(this._mainControl.MPatientInfo.GetPatientInfo["chojae_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Exception on Method SetPatientInfo: " + ex.StackTrace);
            }
        }
        
        #region EventHandler
        private void btnList_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == null) return;

            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {
                if (this.CurrMQLayout != null) this._mainControl.MOrderBiz.GridDisplayValue((XGrid)this.CurrMQLayout); // 현재 Current Row의 모든 값을 디스플레이한다
            }
        }
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            this._mainControl.BtnListClick(e.Func);
            e.IsBaseCall = false;
        }
        private void btnCopy_Click(object sender, System.EventArgs e)
        {
            this._mainControl.BtnCopyClick(false);
        }        
        private void btnCut_Click(object sender, System.EventArgs e)
        {
            this._mainControl.BtnCopyClick(true);
        }
        private void btnPaste_Click(object sender, System.EventArgs e)
        {
            this._mainControl.BtnPasteClick();
        }
        #endregion

        #region [ Command ]
        public override object Command(string command, CommonItemCollection commandParam)
        {
            return this._mainControl.Command(command, commandParam);
        }
        #endregion

        private void dbxChojae_name_Click(object sender, EventArgs e)
        {

        }
        private void FixFontAndSizeColumns()
        {
            xFlatLabel3.Visible = true;
            if (NetInfo.Language != LangMode.Jr)
            {
                lblNaewonDate.Font = new Font("Arial", (float)8.75);
                xFlatLabel3.Font = new Font("Arial", (float)8.75);
                
                //xFlatLabel3.Location = new Point(193, 9);
                dbxSuname.Font = new Font("Arial", (float)12, FontStyle.Bold);
                dbxAge_Sex.Font = new Font("Arial", (float)12, FontStyle.Bold);
                dbxInputGubunName.Font = new Font("Arial", 12, FontStyle.Bold);
                dbxInputGubunName.Size = new Size(127, 30);
                dbxChojae_name.Font = new Font("Arial", (float)8.75);
                dbxChojae_name.Size = new Size(106, 30);
                dbxGubun_name.Font = new Font("Arial", (float)8.75);
                dbxGubun_name.Size = new Size(114, 30);
                dbxWeight_height.Font = new Font("Arial", (float)8.75);
                dbxWeight_height.Location = new Point(778, 3);
                dbxInputGubunName.Location = new Point(895, 3);
                dbxChojae_name.Location = new Point(1035, 3);

            }
        }
    }
}

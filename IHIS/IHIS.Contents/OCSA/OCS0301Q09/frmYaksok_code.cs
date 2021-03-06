using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.OCSA.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;

namespace IHIS.OCSA
{
    /// <summary>
    /// frmYaksok_code에 대한 요약 설명입니다.
    /// </summary>
    public partial class frmYaksok_code : IHIS.Framework.XForm
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

        #region Constructor
        /// <summary>
        /// frmYaksok_code
        /// </summary>
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
            //cmdText = "";
            //cmdText = "SELECT YAKSOK_NAME"
            //        + "  FROM OCS0301"
            //        + " WHERE MEMB        = '" + UserInfo.YaksokOpenID + "' "
            //        + "   AND YAKSOK_CODE = '" + e.DataValue.Trim()    + "' "
            //        + "   AND HOSP_CODE   = '" + EnvironInfo.HospCode  + "' ";

            //retObjt = Service.ExecuteScalar(cmdText);

            // Cloud updated code START
            OCS0301Q09TxtYaksokCodeDataValidatingArgs args = new OCS0301Q09TxtYaksokCodeDataValidatingArgs();
            args.YaksokCode = e.DataValue.Trim();
            args.YaksokOpenId = UserInfo.YaksokOpenID;
            OCS0301Q09TxtYaksokCodeDataValidatingResult res = CloudService.Instance.Submit<OCS0301Q09TxtYaksokCodeDataValidatingResult,
                OCS0301Q09TxtYaksokCodeDataValidatingArgs>(args);

            if (null != res)
            {
                if (!string.IsNullOrEmpty(res.Result))
                {
                    mbxMsg = Resources.MSG008_MSG;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
            // Cloud updated code END

            //if (!TypeCheck.IsNull(retObjt))
            //{
            //    mbxMsg = Resources.MSG008_MSG;
            //    mbxCap = "";
            //    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
            //    e.Cancel = true;                
            //}
        }
        #endregion

    }
}

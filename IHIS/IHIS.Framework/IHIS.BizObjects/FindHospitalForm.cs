using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector;

namespace IHIS.Framework
{
    /// <summary>
    /// FindHospitalForm
    /// 2015.06.19 Added and assembled by AnhNV
    /// </summary>
    public partial class FindHospitalForm : Form
    {
        #region Fields & Properties

        /// <summary>
        /// 病院コード
        /// </summary>
        private string hospCode = "";
        public string HospCode
        {
            get { return hospCode; }
            set { hospCode = value; }
        }

        /// <summary>
        /// 病院名
        /// </summary>
        private string hospName = "";
        public string HospName
        {
            get { return hospName; }
            set { hospName = value; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Without param(s)
        /// </summary>
        public FindHospitalForm()
        {
            InitializeComponent();

            // grdHospCode
            grdHospCode.ParamList = new List<string>(new string[] { "f_hosp_code" });
            grdHospCode.ExecuteQuery = GetGrdHospCode;
        }
        #endregion

        #region Events

        #region searchBtn_Click
        /// <summary>
        /// searchBtn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBtn_Click(object sender, EventArgs e)
        {
            grdHospCode.QueryLayout(true);
        }
        #endregion

        #region enterBtn_Click
        /// <summary>
        /// enterBtn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterBtn_Click(object sender, EventArgs e)
        {
            // No record was found
            if (grdHospCode.RowCount < 1) return;

            // Returns hosp code and name
            this.HospCode = grdHospCode.GetItemString(grdHospCode.CurrentRowNumber, "hosp_code");
            this.HospName = grdHospCode.GetItemString(grdHospCode.CurrentRowNumber, "hosp_name");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region closeBtn_Click
        /// <summary>
        /// closeBtn_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region grdHospCode_MouseDown
        /// <summary>
        /// grdHospCode_MouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdHospCode_MouseDown(object sender, MouseEventArgs e)
        {
            // Double click
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                enterBtn.PerformClick();
            }
        }
        #endregion

        #region FindHospitalForm_Load
        /// <summary>
        /// FindHospitalForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindHospitalForm_Load(object sender, EventArgs e)
        {
            grdHospCode.QueryLayout(true);
        }
        #endregion

        #region grdHospCode_QueryStarting
        /// <summary>
        /// grdHospCode_QueryStarting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdHospCode_QueryStarting(object sender, CancelEventArgs e)
        {
            string hospCode = TypeCheck.IsNull(txtHospcode.Text) ? "%" : txtHospcode.Text;
            grdHospCode.SetBindVarValue("f_hosp_code", hospCode);
        }
        #endregion

        #region FindHospitalForm_KeyDown
        /// <summary>
        /// FindHospitalForm_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindHospitalForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:
                    searchBtn.Focus();
                    searchBtn.PerformClick();
                    break;
                case Keys.F3:
                    enterBtn.Focus();
                    enterBtn.PerformClick();
                    break;
                case Keys.Escape:
                    closeBtn.Focus();
                    closeBtn.PerformClick();
                    break;
            }
        }
        #endregion

        #endregion

        #region Methods(private)

        #region GetGrdHospCode
        /// <summary>
        /// GetGrdHospCode
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdHospCode(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            FwXHospCodeBoxGetGrdHospCodeArgs args = new FwXHospCodeBoxGetGrdHospCodeArgs();
            args.HospCode = bvc["f_hosp_code"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, FwXHospCodeBoxGetGrdHospCodeArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #endregion
    }
}
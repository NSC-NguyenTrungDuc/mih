using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.NURO.Properties;
using System.Reflection;

namespace IHIS.NURO
{
    /// <summary>
    /// 2016.02.16 Added by AnhNV
    /// https://sofiamedix.atlassian.net/browse/MED-7465
    /// NUR2016Q00 - Links a patient to another clinic
    /// </summary>
    [ToolboxItem(false)]
    public partial class NUR2016Q00 : IHIS.Framework.XScreen
    {
        #region Fields & Properties

        /// <summary>
        /// Patient ID
        /// </summary>
        private string _bunho;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// NUR2016Q00
        /// </summary>
        public NUR2016Q00()
        {
            InitializeComponent();
            grdHospList.ParamList = new List<string>(new string[]
                {
                    "f_region",
                    "f_hosp_code",
                    "f_yoyang_name",
                    "f_page_number",
                });
            grdHospList.ExecuteQuery = GetGrdHospList;
        }

        #endregion

        #region Events

        private void NUR2016Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            if (e.OpenParam.Contains("bunho"))
            {
                this._bunho = e.OpenParam["bunho"].ToString();
            }

            grdHospList.QueryLayout(false);
        }

        private void grdHospList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdHospList.SetBindVarValue("f_region", txtRegion.Text.Trim());
            grdHospList.SetBindVarValue("f_hosp_code", txtHospCode.Text.Trim());
            grdHospList.SetBindVarValue("f_yoyang_name", txtHospName.Text.Trim());
        }

        private void grdHospList_MouseDown(object sender, MouseEventArgs e)
        {
            // Prevents user from clicking to header row
            if (grdHospList.CurrentRowNumber < 0) return;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                btnList.PerformClick(FunctionType.Process);
            }
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    grdHospList.QueryLayout(false);
                    break;
                case FunctionType.Process:
                    OpenPopup();
                    break;
                case FunctionType.Close:
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Methods(private)

        private void OpenPopup()
        {
            try
            {
                // Get current process hospcode
                string hospCodeLink = grdHospList.GetItemString(grdHospList.CurrentRowNumber, "hosp_code");

                // Cannot link to current hospital
                if (hospCodeLink == UserInfo.HospCode)
                {
                    XMessageBox.Show(Resources.MSG_004, Resources.CAP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!TypeCheck.IsNull(hospCodeLink))
                {
                    // Open popup PatientSelect
                    FormSelectPatient frm = new FormSelectPatient(this._bunho, hospCodeLink, grdHospList.GetItemString(grdHospList.CurrentRowNumber,"yoyang_name"));
                    frm.ShowDialog(this);
                }
                else
                {
                    XMessageBox.Show(Resources.MSG_003, Resources.CAP_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " error: " + ex.Message);
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " stacktrace: " + ex.StackTrace);
            }
        }

        #endregion

        #region CloudConnector

        private List<object[]> GetGrdHospList(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            NUR2016Q00GrdHospListArgs args = new NUR2016Q00GrdHospListArgs();
            args.Address = bc["f_region"].VarValue;
            args.HospCode = bc["f_hosp_code"].VarValue;
            args.YoyangName = bc["f_yoyang_name"].VarValue;
            args.Offset = "200";
            args.PageNumber = bc["f_page_number"].VarValue;
            NUR2016Q00GrdHospListResult res = CloudService.Instance.Submit<NUR2016Q00GrdHospListResult, NUR2016Q00GrdHospListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.HospListItem.ForEach(delegate(NUR2016Q00GrdHospListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.HospCode,
                        item.YoyangName,
                        item.KanaName,                      
                        item.Address,
                        item.Tel,
                    });
                });
            }

            return lObj;
        }

        #endregion

        private void grdHospList_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}

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
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.NURO.Properties;
using System.Reflection;

namespace IHIS.NURO
{
    /// <summary>
    /// NUR2016U02 - Link a patient to another clinic
    /// https://sofiamedix.atlassian.net/browse/MED-7474
    /// </summary>
    public partial class NUR2016U02 : XScreen
    {
        #region Fields & Properties

        private string _bunho = "";

        #endregion

        #region Constructors

        /// <summary>
        /// NUR2016U02
        /// </summary>
        public NUR2016U02()
        {
            InitializeComponent();

            grdList.ParamList = new List<string>(new string[] { "f_bunho" });
            grdList.ExecuteQuery = GetGrdList;
        }

        #endregion

        #region Events

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Patient has not been selected
                if (TypeCheck.IsNull(paBox.BunHo))
                {
                    XMessageBox.Show(Resources.MSG_NOT_SELECT_PATIENT, Resources.CAP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 解除してよろしいですか？
                if (XMessageBox.Show(Resources.MSG_DELETED_CONFIRM, Resources.CAP_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                List<NUR2016U02DeleteLinkPatientInfo> lstData = GetListPatientDelete();
                // No records was selected
                if (lstData.Count == 0)
                {
                    // 一件以上を選択してください。
                    XMessageBox.Show(Resources.MSG_NOT_SELECT_ERR, Resources.CAP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                NUR2016U02DeleteLinkPatientArgs args = new NUR2016U02DeleteLinkPatientArgs();
                args.LinkPatItem = lstData;
                args.Bunho = this._bunho;
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, NUR2016U02DeleteLinkPatientArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    // 解除するのが成功しました。
                    XMessageBox.Show(Resources.MSG_DELETE_SUCCESS, Resources.CAP_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grdList.QueryLayout(true);
                }
                else
                {
                    // 解除するのが失敗しました。
                    XMessageBox.Show(Resources.MSG_DELETE_FAIL, Resources.CAP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Service.StartWriteLog();
                Service.WriteLog("[" + this.Name + ": DELETE LINK PATIENT FAILED].");
                Service.WriteLog("[Stack trace]: " + ex.StackTrace);
                Service.WriteLog("[Message]: " + ex.Message);
                Service.EndWriteLog();
            }
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    grdList.QueryLayout(true);
                    break;
                case FunctionType.Close:
                    break;
                default:
                    break;
            }
        }

        private void NUR2016U02_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            if (e.OpenParam.Contains("bunho"))
            {
                this._bunho = e.OpenParam["bunho"].ToString();
                paBox.SetPatientID(this._bunho);
                txtBunho.Text = this._bunho;

                grdList.QueryLayout(true);
            }
        }

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdList.SetBindVarValue("f_bunho", paBox.BunHo);
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            try
            {
                this.txtBunho.Text = this.paBox.BunHo;
                grdList.QueryLayout(false);
            }
            catch (Exception ex)
            {
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " error: " + ex.Message);
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " stacktrace: " + ex.StackTrace);
            }
        }

        private void paBox_PatientSelectionFailed(object sender, EventArgs e)
        {
            this.txtBunho.Text = "";
            this.paBox.Reset();
        }

        private void txtBunho_DataValidating(object sender, DataValidatingEventArgs e)
        {
            try
            {
                if (e.DataValue != "")
                {
                    string bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
                    this.paBox.SetPatientID(bunho);
                    this.txtBunho.Focus();
                }
                else
                {
                    this.paBox.Reset();
                }

                grdList.QueryLayout(false);
            }
            catch (Exception ex)
            {
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " error: " + ex.Message);
                Service.WriteLog(MethodBase.GetCurrentMethod().Name + " stacktrace: " + ex.StackTrace);
            }
        }

        #endregion

        #region Methods

        private List<NUR2016U02DeleteLinkPatientInfo> GetListPatientDelete()
        {
            List<NUR2016U02DeleteLinkPatientInfo> lstData = new List<NUR2016U02DeleteLinkPatientInfo>();

            for (int i = 0; i < grdList.RowCount; i++)
            {
                // Skips records which is not be checked
                if (grdList.GetItemString(i, "select") != "Y") continue;

                NUR2016U02DeleteLinkPatientInfo item = new NUR2016U02DeleteLinkPatientInfo();
                item.BunhoLink = grdList.GetItemString(i, "bunho");
                item.HospCodeLink = grdList.GetItemString(i, "hosp_code");

                lstData.Add(item);
            }

            return lstData;
        }

        #endregion

        #region CloudConnector

        private List<object[]> GetGrdList(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            NUR2016U02GrdListArgs args = new NUR2016U02GrdListArgs();
            args.Bunho = bc["f_bunho"].VarValue;
            NUR2016U02GrdListResult res = CloudService.Instance.Submit<NUR2016U02GrdListResult, NUR2016U02GrdListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdItem.ForEach(delegate(NUR2016U02GrdListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Select,
                        item.HospCodeLink,
                        item.YoyangName,
                        item.BunhoLink,
                        item.Suname,
                        item.Address1,
                        Utilities.GetDateByLangMode(item.Birth, NetInfo.Language),
                    });
                });
            }

            return lObj;
        }

        #endregion
    }
}

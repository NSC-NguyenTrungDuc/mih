using System;
using System.ComponentModel;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.ADM.Properties;

namespace IHIS.ADMA
{
    /// <summary>
    /// https://sofiamedix.atlassian.net/browse/MED-9831
    /// </summary>
    [ToolboxItem(false)]
    public partial class ADM104Q : IHIS.Framework.XScreen
    {
        #region Fields & Properties

        #endregion

        #region Constructors

        public ADM104Q()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Events

        private void txtUserId_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (TypeCheck.IsNull(txtUserId.GetDataValue())) return;

            ADM104QGetPatientArgs args = new ADM104QGetPatientArgs();
            args.UserId = txtUserId.GetDataValue();
            ADM104QGetPatientResult res = CloudService.Instance.Submit<ADM104QGetPatientResult, ADM104QGetPatientArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && res.Exist == true)
            {
                lbMsg.Visible = false;
                dbxUserName.SetEditValue(res.UserName);
            }
            else
            {
                lbMsg.Visible = true;
                lbMsg.Text = Resources.MSG_USER_NOT_EXIST;
                txtUserId.Focus();
                txtUserId.SetDataValue("");
                dbxUserName.SetDataValue("");
                e.Cancel = true;
            }
        }

        private void ADM104Q_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            // https://sofiamedix.atlassian.net/browse/MED-14736
            //string userId = "";
            //string userName = "";

            //if (e.OpenParam != null && e.OpenParam.Contains("user_id"))
            //{
            //    userId = e.OpenParam["user_id"].ToString();
            //}

            //if (e.OpenParam != null && e.OpenParam.Contains("user_name"))
            //{
            //    userName = e.OpenParam["user_name"].ToString();
            //}

            //if (!TypeCheck.IsNull(userId) && !TypeCheck.IsNull(userName))
            //{
            //    txtUserId.SetDataValue(userId);
            //    dbxUserName.SetDataValue(userName);
            //}
            //else
            //{
            //    txtUserId.SetDataValue(UserInfo.UserID);
            //    dbxUserName.SetDataValue(UserInfo.UserName);
            //}
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Process:
                    this.SetData();
                    break;
                case FunctionType.Close:
                    this.Close();
                    break;
            }
        }

        #endregion

        #region Methods

        private void SetData()
        {
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            commandParams.Add("user_id", this.txtUserId.GetDataValue());
            commandParams.Add("user_name", this.dbxUserName.GetDataValue());

            scrOpener.Command(ScreenID, commandParams);

            this.Close();
        }

        #endregion
    }
}
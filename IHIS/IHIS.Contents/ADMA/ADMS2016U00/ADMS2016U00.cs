using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.ADMA.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Models.Adma;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;

namespace IHIS.ADMA
{
    public partial class ADMS2016U00 : IHIS.Framework.XScreen
    {
        public ADMS2016U00()
        {
            InitializeComponent();

            //initialize Cloud
            this.grdSharding.ExecuteQuery = LoadDataGrdSharding;
        }

        private void ADMS2016U00_Load(object sender, EventArgs e)
        {
            this.btnList.PerformClick(IHIS.Framework.FunctionType.Query);
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case IHIS.Framework.FunctionType.Close:
                    break;
                case IHIS.Framework.FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdSharding.QueryLayout(true);
                    break;
                case IHIS.Framework.FunctionType.Update:
                    if (SaveChanges())
                    {
                        XMessageBox.Show(Resources.MSG_2, Resources.MSG_CAP_4, MessageBoxIcon.Information);
                        this.btnList.PerformClick(FunctionType.Query);
                    }
                    else
                    {
                        XMessageBox.Show(Resources.MSG_3, Resources.MSG_CAP_4, MessageBoxIcon.Error);
                    }
                    e.IsBaseCall = false;
                    break;
            }
        }

        private void grdSharding_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "maintenance_mode")
            {
                DialogResult dlgResult;
                if (e.ChangeValue.ToString() == "Y")
                {
                    dlgResult = XMessageBox.Show(Resources.MSG_04, Resources.MSG_CAP_4, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dlgResult == DialogResult.No)
                    {
                        btnList.PerformClick(FunctionType.Query);
                    }
                }
                else if (e.ChangeValue.ToString() == "N")
                {
                    dlgResult = XMessageBox.Show(Resources.MSG_05, Resources.MSG_CAP_4, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dlgResult == DialogResult.No)
                    {
                        btnList.PerformClick(FunctionType.Query);
                    }
                }
            }
        }

        #region CloudService

        //get data for grdSharding from server
        private IList<object[]> LoadDataGrdSharding(BindVarCollection varlist)
        {
            IList<object[]> lstObj = new List<object[]>();
            Adms2016U00GetMaintainanceSettingArgs args = new Adms2016U00GetMaintainanceSettingArgs();
            Adms2016U00GetMaintainanceSettingResult result =
                CloudService.Instance
                    .Submit<Adms2016U00GetMaintainanceSettingResult, Adms2016U00GetMaintainanceSettingArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (MaintainanceSettingInfo info in result.MaintainanceSettings)
                {
                    lstObj.Add(new object[]
                    {
                       info.HospGroupCd,
                       info.HospGroupName,
                       (info.MaintenanceMode == 1) ? "Y" : "N"
                    });
                }
            }
            return lstObj;
        }

        //save data to DB
        private bool SaveChanges()
        {
            List<MaintainanceSettingInfo> lstInput = GetGrdShardingSaveInfo();
            if (lstInput.Count > 0)
            {
                Adms2016U00SaveMaintainanceSettingArgs args = new Adms2016U00SaveMaintainanceSettingArgs();
                args.MaintainanceSettings = lstInput;
                UpdateResult result =
                    CloudService.Instance.Submit<UpdateResult, Adms2016U00SaveMaintainanceSettingArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success && result.Result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        //get modified record only
        private List<MaintainanceSettingInfo> GetGrdShardingSaveInfo()
        {
            List<MaintainanceSettingInfo> lstInfo = new List<MaintainanceSettingInfo>();
            for (int i = 0; i < grdSharding.RowCount; i++)
            {
                if (grdSharding.GetRowState(i) == DataRowState.Modified)
                {
                    MaintainanceSettingInfo info = new MaintainanceSettingInfo();
                    info.HospGroupCd = grdSharding.GetItemString(i, "hosp_group_cd");
                    info.HospGroupName = grdSharding.GetItemString(i, "hosp_group_name");
                    info.MaintenanceMode = (grdSharding.GetItemString(i, "maintenance_mode") == "Y") ? 1 : 0;
                    lstInfo.Add(info);
                }
            }
            return lstInfo;
        }

        #endregion

    }
}
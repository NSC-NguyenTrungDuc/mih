using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    public class MaintainanceSettingInfo
    {
        private String _hospGroupCd;
        private String _hospGroupName;
        private Int32 _maintenanceMode;

        public String HospGroupCd
        {
            get { return this._hospGroupCd; }
            set { this._hospGroupCd = value; }
        }

        public String HospGroupName
        {
            get { return this._hospGroupName; }
            set { this._hospGroupName = value; }
        }

        public Int32 MaintenanceMode
        {
            get { return this._maintenanceMode; }
            set { this._maintenanceMode = value; }
        }

        public MaintainanceSettingInfo() { }

        public MaintainanceSettingInfo(String hospGroupCd, String hospGroupName, Int32 maintenanceMode)
        {
            this._hospGroupCd = hospGroupCd;
            this._hospGroupName = hospGroupName;
            this._maintenanceMode = maintenanceMode;
        }

    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    public class Adms2016U00GetMaintainanceSettingResult : AbstractContractResult
    {
        private List<MaintainanceSettingInfo> _maintainanceSettings = new List<MaintainanceSettingInfo>();

        public List<MaintainanceSettingInfo> MaintainanceSettings
        {
            get { return this._maintainanceSettings; }
            set { this._maintainanceSettings = value; }
        }

        public Adms2016U00GetMaintainanceSettingResult() { }

    }
}
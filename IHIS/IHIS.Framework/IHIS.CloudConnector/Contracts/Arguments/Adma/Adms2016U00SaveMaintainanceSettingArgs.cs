using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    public class Adms2016U00SaveMaintainanceSettingArgs : IContractArgs
    {
        private List<MaintainanceSettingInfo> _maintainanceSettings = new List<MaintainanceSettingInfo>();

        public List<MaintainanceSettingInfo> MaintainanceSettings
        {
            get { return this._maintainanceSettings; }
            set { this._maintainanceSettings = value; }
        }

        public Adms2016U00SaveMaintainanceSettingArgs() { }

        public Adms2016U00SaveMaintainanceSettingArgs(List<MaintainanceSettingInfo> maintainanceSettings)
        {
            this._maintainanceSettings = maintainanceSettings;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Adms2016U00SaveMaintainanceSettingRequest();
        }
    }
}
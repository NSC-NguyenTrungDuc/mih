using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class OCS2015U00EmrBackTimeRimindArgs : IContractArgs
    {
        private Boolean _isBackup;

        public Boolean IsBackup
        {
            get { return this._isBackup; }
            set { this._isBackup = value; }
        }

        public OCS2015U00EmrBackTimeRimindArgs() { }

        public OCS2015U00EmrBackTimeRimindArgs(Boolean isBackup)
        {
            this._isBackup = isBackup;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS2015U00EmrBackTimeRimindRequest();
        }
    }
}
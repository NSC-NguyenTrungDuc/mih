using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U31GetADM3200UserResult : AbstractContractResult
    {
        private List<OCS2015U31GetADM3200UserInfo> _adm3200UserInfo = new List<OCS2015U31GetADM3200UserInfo>();

        public List<OCS2015U31GetADM3200UserInfo> Adm3200UserInfo
        {
            get { return this._adm3200UserInfo; }
            set { this._adm3200UserInfo = value; }
        }

        public OCS2015U31GetADM3200UserResult() { }

    }
}
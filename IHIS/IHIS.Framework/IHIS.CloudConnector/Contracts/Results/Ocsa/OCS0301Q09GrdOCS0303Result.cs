using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    public class OCS0301Q09GrdOCS0303Result : AbstractContractResult
    {
        private List<OCS0301Q09GrdOCS0303Info> _grdOcs0303Item = new List<OCS0301Q09GrdOCS0303Info>();
        private List<ComboListItemInfo> _comboList0307Item = new List<ComboListItemInfo>();

        public List<OCS0301Q09GrdOCS0303Info> GrdOcs0303Item
        {
            get { return this._grdOcs0303Item; }
            set { this._grdOcs0303Item = value; }
        }

        public List<ComboListItemInfo> ComboList0307Item
        {
            get { return this._comboList0307Item; }
            set { this._comboList0307Item = value; }
        }

        public OCS0301Q09GrdOCS0303Result() { }

    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class ADM103UGetFwkHospitalResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _hospList = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> HospList
        {
            get { return this._hospList; }
            set { this._hospList = value; }
        }

        public ADM103UGetFwkHospitalResult() { }

    }
}
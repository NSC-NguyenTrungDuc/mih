using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00GrdSpecimenResult : AbstractContractResult
    {
        private List<CPL2010U00GrdSpecimenListItemInfo> _grdSpecimenList = new List<CPL2010U00GrdSpecimenListItemInfo>();

        public List<CPL2010U00GrdSpecimenListItemInfo> GrdSpecimenList
        {
            get { return this._grdSpecimenList; }
            set { this._grdSpecimenList = value; }
        }

        public CPL2010U00GrdSpecimenResult() { }

    }
}
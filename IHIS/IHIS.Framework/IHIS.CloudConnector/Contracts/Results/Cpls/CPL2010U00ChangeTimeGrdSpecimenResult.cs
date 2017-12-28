using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00ChangeTimeGrdSpecimenResult : AbstractContractResult
    {
        private List<CPL2010U00ChangeTimeGrdSpecimenListItemInfo> _grdSpecimenList = new List<CPL2010U00ChangeTimeGrdSpecimenListItemInfo>();

        public List<CPL2010U00ChangeTimeGrdSpecimenListItemInfo> GrdSpecimenList
        {
            get { return this._grdSpecimenList; }
            set { this._grdSpecimenList = value; }
        }

        public CPL2010U00ChangeTimeGrdSpecimenResult() { }

    }
}
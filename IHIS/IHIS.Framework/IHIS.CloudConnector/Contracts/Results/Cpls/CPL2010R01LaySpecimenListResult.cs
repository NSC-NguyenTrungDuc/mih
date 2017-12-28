using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010R01LaySpecimenListResult : AbstractContractResult
    {
        private List<CPL2010R01LaySpecimenListItemInfo> _laySpecimenList = new List<CPL2010R01LaySpecimenListItemInfo>();

        public List<CPL2010R01LaySpecimenListItemInfo> LaySpecimenList
        {
            get { return this._laySpecimenList; }
            set { this._laySpecimenList = value; }
        }

        public CPL2010R01LaySpecimenListResult() { }

    }
}
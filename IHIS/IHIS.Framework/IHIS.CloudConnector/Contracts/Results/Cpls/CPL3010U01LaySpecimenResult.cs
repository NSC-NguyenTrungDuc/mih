using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3010U01LaySpecimenResult : AbstractContractResult
    {
        private List<CPL3010U01LaySpecimenInfo> _laySpecimenLst = new List<CPL3010U01LaySpecimenInfo>();

        public List<CPL3010U01LaySpecimenInfo> LaySpecimenLst
        {
            get { return this._laySpecimenLst; }
            set { this._laySpecimenLst = value; }
        }

        public CPL3010U01LaySpecimenResult() { }

    }
}
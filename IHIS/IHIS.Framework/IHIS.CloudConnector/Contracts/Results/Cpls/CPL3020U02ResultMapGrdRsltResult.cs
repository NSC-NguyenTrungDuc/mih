using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3020U02ResultMapGrdRsltResult : AbstractContractResult
    {
        private List<CPL3020U02ResultMapGrdRsltInfo> _grdResultList = new List<CPL3020U02ResultMapGrdRsltInfo>();

        public List<CPL3020U02ResultMapGrdRsltInfo> GrdResultList
        {
            get { return this._grdResultList; }
            set { this._grdResultList = value; }
        }

        public CPL3020U02ResultMapGrdRsltResult() { }

    }
}
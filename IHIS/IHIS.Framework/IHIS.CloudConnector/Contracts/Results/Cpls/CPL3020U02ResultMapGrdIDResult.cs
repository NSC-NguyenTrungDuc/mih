using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3020U02ResultMapGrdIDResult : AbstractContractResult
    {
        private List<CPL3020U02ResultMapGrdIDInfo> _grdIDList = new List<CPL3020U02ResultMapGrdIDInfo>();

        public List<CPL3020U02ResultMapGrdIDInfo> GrdIDList
        {
            get { return this._grdIDList; }
            set { this._grdIDList = value; }
        }

        public CPL3020U02ResultMapGrdIDResult() { }

    }
}
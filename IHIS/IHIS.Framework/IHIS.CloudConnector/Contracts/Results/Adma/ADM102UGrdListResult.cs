using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class ADM102UGrdListResult : AbstractContractResult
    {
        private List<ADM102UGrdListItemInfo> _grdList = new List<ADM102UGrdListItemInfo>();

        public List<ADM102UGrdListItemInfo> GrdList
        {
            get { return this._grdList; }
            set { this._grdList = value; }
        }

        public ADM102UGrdListResult() { }

    }
}
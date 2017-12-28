using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NUR2016U02GrdListResult : AbstractContractResult
    {
        private List<NUR2016U02GrdListInfo> _grdItem = new List<NUR2016U02GrdListInfo>();

        public List<NUR2016U02GrdListInfo> GrdItem
        {
            get { return this._grdItem; }
            set { this._grdItem = value; }
        }

        public NUR2016U02GrdListResult() { }

    }
}
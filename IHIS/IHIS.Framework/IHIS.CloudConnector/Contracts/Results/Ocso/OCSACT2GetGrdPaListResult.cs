using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OCSACT2GetGrdPaListResult : AbstractContractResult
    {
        private List<OCSACT2GetGrdPaListInfo> _paItem = new List<OCSACT2GetGrdPaListInfo>();

        public List<OCSACT2GetGrdPaListInfo> PaItem
        {
            get { return this._paItem; }
            set { this._paItem = value; }
        }

        public OCSACT2GetGrdPaListResult() { }

    }
}
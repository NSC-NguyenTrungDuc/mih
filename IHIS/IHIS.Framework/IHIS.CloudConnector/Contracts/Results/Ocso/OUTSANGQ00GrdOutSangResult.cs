using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OUTSANGQ00GrdOutSangResult : AbstractContractResult
    {
        private List<OUTSANGQ00GrdOutSangInfo> _listItem = new List<OUTSANGQ00GrdOutSangInfo>();

        public List<OUTSANGQ00GrdOutSangInfo> ListItem
        {
            get { return this._listItem; }
            set { this._listItem = value; }
        }

        public OUTSANGQ00GrdOutSangResult() { }

    }
}
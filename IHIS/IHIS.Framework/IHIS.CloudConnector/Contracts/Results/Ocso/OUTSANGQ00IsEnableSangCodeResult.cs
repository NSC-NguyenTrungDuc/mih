using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OUTSANGQ00IsEnableSangCodeResult : AbstractContractResult
    {
        private List<OUTSANGQ00IsEnableSangCodeInfo> _listItem = new List<OUTSANGQ00IsEnableSangCodeInfo>();

        public List<OUTSANGQ00IsEnableSangCodeInfo> ListItem
        {
            get { return this._listItem; }
            set { this._listItem = value; }
        }

        public OUTSANGQ00IsEnableSangCodeResult() { }

    }
}
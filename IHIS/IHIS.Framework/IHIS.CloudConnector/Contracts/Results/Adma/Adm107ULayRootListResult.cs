using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class Adm107ULayRootListResult : AbstractContractResult
    {
        private List<Adm107ULayDownListInfo> _layRootListItem = new List<Adm107ULayDownListInfo>();

        public List<Adm107ULayDownListInfo> LayRootListItem
        {
            get { return this._layRootListItem; }
            set { this._layRootListItem = value; }
        }

        public Adm107ULayRootListResult() { }

    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class Adm107ULayDownListResult : AbstractContractResult
    {
        private List<Adm107ULayDownListInfo> _layDownListItem = new List<Adm107ULayDownListInfo>();

        public List<Adm107ULayDownListInfo> LayDownListItem
        {
            get { return this._layDownListItem; }
            set { this._layDownListItem = value; }
        }

        public Adm107ULayDownListResult() { }

    }
}
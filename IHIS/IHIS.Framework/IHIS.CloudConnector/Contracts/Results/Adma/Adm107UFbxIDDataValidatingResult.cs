using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class Adm107UFbxIDDataValidatingResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _fbxItem = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> FbxItem
        {
            get { return this._fbxItem; }
            set { this._fbxItem = value; }
        }

        public Adm107UFbxIDDataValidatingResult() { }

    }
}
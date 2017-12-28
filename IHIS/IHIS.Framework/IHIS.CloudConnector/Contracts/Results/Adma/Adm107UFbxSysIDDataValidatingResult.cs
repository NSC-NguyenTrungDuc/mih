using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class Adm107UFbxSysIDDataValidatingResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _fbxSytemItem = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> FbxSytemItem
        {
            get { return this._fbxSytemItem; }
            set { this._fbxSytemItem = value; }
        }

        public Adm107UFbxSysIDDataValidatingResult() { }

    }
}
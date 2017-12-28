using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    public class Adm107UFwkUserIdResult : AbstractContractResult
    {
        private List<Adm107UFwkUserIdInfo> _listInfo = new List<Adm107UFwkUserIdInfo>();

        public List<Adm107UFwkUserIdInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public Adm107UFwkUserIdResult() { }

    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class ComBizLoadIFS0001InfoResult : AbstractContractResult
    {
        private List<ComBizLoadIFS0001Info> _infoList = new List<ComBizLoadIFS0001Info>();

        public List<ComBizLoadIFS0001Info> InfoList
        {
            get { return this._infoList; }
            set { this._infoList = value; }
        }

        public ComBizLoadIFS0001InfoResult() { }

    }
}
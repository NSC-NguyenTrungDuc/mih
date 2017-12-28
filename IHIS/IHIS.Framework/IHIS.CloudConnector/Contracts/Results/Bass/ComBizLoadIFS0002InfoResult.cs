using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class ComBizLoadIFS0002InfoResult : AbstractContractResult
    {
        private List<ComBizLoadIFS0002Info> _infoList = new List<ComBizLoadIFS0002Info>();

        public List<ComBizLoadIFS0002Info> InfoList
        {
            get { return this._infoList; }
            set { this._infoList = value; }
        }

        public ComBizLoadIFS0002InfoResult() { }

    }
}
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroInspectionOrderGetInfoTextResult : AbstractContractResult
    {
        private List<String> _infoTextItem = new List<String>();

        public List<String> InfoTextItem
        {
            get { return this._infoTextItem; }
            set { this._infoTextItem = value; }
        }

        public NuroInspectionOrderGetInfoTextResult() { }

    }
}

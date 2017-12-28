using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroInspectionOrderGetTelResult : AbstractContractResult
    {
        private String _telItem;

        public String TelItem
        {
            get { return this._telItem; }
            set { this._telItem = value; }
        }

        public NuroInspectionOrderGetTelResult() { }

    }
}
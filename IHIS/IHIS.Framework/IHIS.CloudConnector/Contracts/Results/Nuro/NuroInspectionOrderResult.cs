using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;


namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroInspectionOrderResult : AbstractContractResult
    {
        private List<NuroInspectionOrderInfo> _inspectionOrderInfo = new List<NuroInspectionOrderInfo>();

        public List<NuroInspectionOrderInfo> InspectionOrderInfo
        {
            get { return this._inspectionOrderInfo; }
            set { this._inspectionOrderInfo = value; }
        }

        public NuroInspectionOrderResult() { }

    }
}

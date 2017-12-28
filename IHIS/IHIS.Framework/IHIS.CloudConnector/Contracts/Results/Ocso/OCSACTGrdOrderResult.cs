using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCSACTGrdOrderResult : AbstractContractResult
    {
        private List<OCSACTGrdOrderInfo> _grdOrderItem = new List<OCSACTGrdOrderInfo>();

        public List<OCSACTGrdOrderInfo> GrdOrderItem
        {
            get { return this._grdOrderItem; }
            set { this._grdOrderItem = value; }
        }

        public OCSACTGrdOrderResult() { }

    }
}
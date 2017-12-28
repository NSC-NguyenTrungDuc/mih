using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Endo
{
    [Serializable]
    public class END1001U02BtnQueryResult : AbstractContractResult
    {
        private List<END1001U02DsvDwInfo> _dsvdwItem = new List<END1001U02DsvDwInfo>();
        private List<END1001U02GrdPaStatusInfo> _pastatusItem = new List<END1001U02GrdPaStatusInfo>();

        public List<END1001U02DsvDwInfo> DsvdwItem
        {
            get { return this._dsvdwItem; }
            set { this._dsvdwItem = value; }
        }

        public List<END1001U02GrdPaStatusInfo> PastatusItem
        {
            get { return this._pastatusItem; }
            set { this._pastatusItem = value; }
        }

        public END1001U02BtnQueryResult() { }

    }
}
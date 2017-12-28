using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Endo
{
    [Serializable]
    public class END1001U02DsvDwResult : AbstractContractResult
    {
        private List<END1001U02DsvDwInfo> _dsvDwItem = new List<END1001U02DsvDwInfo>();

        public List<END1001U02DsvDwInfo> DsvDwItem
        {
            get { return this._dsvDwItem; }
            set { this._dsvDwItem = value; }
        }

        public END1001U02DsvDwResult() { }

    }
}
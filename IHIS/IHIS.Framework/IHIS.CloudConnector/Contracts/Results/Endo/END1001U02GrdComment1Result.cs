using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Endo
{
    [Serializable]
    public class END1001U02GrdComment1Result : AbstractContractResult
    {
        private List<END1001U02StrInfo> _grdComment1Item = new List<END1001U02StrInfo>();

        public List<END1001U02StrInfo> GrdComment1Item
        {
            get { return this._grdComment1Item; }
            set { this._grdComment1Item = value; }
        }

        public END1001U02GrdComment1Result() { }

    }
}
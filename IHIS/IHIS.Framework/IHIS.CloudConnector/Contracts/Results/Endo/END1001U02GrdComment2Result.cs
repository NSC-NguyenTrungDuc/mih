using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Endo
{
    [Serializable]
    public class END1001U02GrdComment2Result : AbstractContractResult
    {
        private List<END1001U02StrInfo> _grdComment2Item = new List<END1001U02StrInfo>();

        public List<END1001U02StrInfo> GrdComment2Item
        {
            get { return this._grdComment2Item; }
            set { this._grdComment2Item = value; }
        }

        public END1001U02GrdComment2Result() { }

    }
}
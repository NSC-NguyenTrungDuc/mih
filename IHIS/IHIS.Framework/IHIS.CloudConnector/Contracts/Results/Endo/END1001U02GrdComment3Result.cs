using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Endo
{
    [Serializable]
    public class END1001U02GrdComment3Result : AbstractContractResult
    {
        private List<END1001U02GrdComment3Info> _grdComment3Item = new List<END1001U02GrdComment3Info>();

        public List<END1001U02GrdComment3Info> GrdComment3Item
        {
            get { return this._grdComment3Item; }
            set { this._grdComment3Item = value; }
        }

        public END1001U02GrdComment3Result() { }

    }
}
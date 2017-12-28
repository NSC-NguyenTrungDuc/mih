using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV4001LoadBuseoResult : AbstractContractResult
    {
        private List<INV4001LoadBuseoInfo> _lst = new List<INV4001LoadBuseoInfo>();

        public List<INV4001LoadBuseoInfo> Lst
        {
            get { return this._lst; }
            set { this._lst = value; }
        }

        public INV4001LoadBuseoResult() { }

    }
}
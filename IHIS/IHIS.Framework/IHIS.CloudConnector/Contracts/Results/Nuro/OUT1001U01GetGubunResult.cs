using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class OUT1001U01GetGubunResult : AbstractContractResult
    {
        private List<OUT1001U01GetGubunInfo> _gubunItem = new List<OUT1001U01GetGubunInfo>();

        public List<OUT1001U01GetGubunInfo> GubunItem
        {
            get { return this._gubunItem; }
            set { this._gubunItem = value; }
        }

        public OUT1001U01GetGubunResult() { }

    }
}
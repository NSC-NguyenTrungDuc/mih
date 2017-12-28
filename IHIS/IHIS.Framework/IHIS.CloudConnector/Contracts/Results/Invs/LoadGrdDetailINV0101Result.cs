using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class LoadGrdDetailINV0101Result : AbstractContractResult
    {
        private List<LoadGrdDetailINV0101Info> _listDetail = new List<LoadGrdDetailINV0101Info>();

        public List<LoadGrdDetailINV0101Info> ListDetail
        {
            get { return this._listDetail; }
            set { this._listDetail = value; }
        }

        public LoadGrdDetailINV0101Result() { }

    }
}
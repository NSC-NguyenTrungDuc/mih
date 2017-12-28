using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class LoadGrdMasterINV0101Result : AbstractContractResult
    {
        private List<LoadGrdMasterINV0101Info> _listMaster = new List<LoadGrdMasterINV0101Info>();

        public List<LoadGrdMasterINV0101Info> ListMaster
        {
            get { return this._listMaster; }
            set { this._listMaster = value; }
        }

        public LoadGrdMasterINV0101Result() { }

    }
}
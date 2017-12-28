using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class NUR2016Q00GrdHospListResult : AbstractContractResult
    {
        private List<NUR2016Q00GrdHospListInfo> _hospListItem = new List<NUR2016Q00GrdHospListInfo>();

        public List<NUR2016Q00GrdHospListInfo> HospListItem
        {
            get { return this._hospListItem; }
            set { this._hospListItem = value; }
        }

        public NUR2016Q00GrdHospListResult() { }

    }
}
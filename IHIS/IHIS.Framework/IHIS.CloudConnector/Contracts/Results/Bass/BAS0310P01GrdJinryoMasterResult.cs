using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0310P01GrdJinryoMasterResult : AbstractContractResult
    {
        private List<BAS0310P01GrdJinryoMasterInfo> _dt = new List<BAS0310P01GrdJinryoMasterInfo>();

        public List<BAS0310P01GrdJinryoMasterInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public BAS0310P01GrdJinryoMasterResult() { }

    }
}
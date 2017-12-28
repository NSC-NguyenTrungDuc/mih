using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0310P01GrdGenDrgMapResult : AbstractContractResult
    {
        private List<BAS0310P01GrdGenDrgMapInfo> _dt = new List<BAS0310P01GrdGenDrgMapInfo>();

        public List<BAS0310P01GrdGenDrgMapInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public BAS0310P01GrdGenDrgMapResult() { }

    }
}
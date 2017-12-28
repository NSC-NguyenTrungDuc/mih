using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    public class DRG0120U00GrdDrg0120Item1Result : AbstractContractResult
    {
        private List<DRG0120U00GrdDrg0120Item1Info> _listInfo = new List<DRG0120U00GrdDrg0120Item1Info>();

        public List<DRG0120U00GrdDrg0120Item1Info> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public DRG0120U00GrdDrg0120Item1Result() { }

    }
}
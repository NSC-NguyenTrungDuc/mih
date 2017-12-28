using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0111U00GrdBas0111Result : AbstractContractResult
    {
        private List<BAS0111U00GrdBas0111ItemInfo> _dt = new List<BAS0111U00GrdBas0111ItemInfo>();

        public List<BAS0111U00GrdBas0111ItemInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public BAS0111U00GrdBas0111Result() { }

    }
}
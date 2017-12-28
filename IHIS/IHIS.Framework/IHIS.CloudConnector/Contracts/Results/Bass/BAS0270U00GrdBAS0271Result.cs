using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0270U00GrdBAS0271Result : AbstractContractResult
    {
        private List<BAS0270U00GrdBAS0271Info> _grdBAS0271 = new List<BAS0270U00GrdBAS0271Info>();

        public List<BAS0270U00GrdBAS0271Info> GrdBAS0271
        {
            get { return this._grdBAS0271; }
            set { this._grdBAS0271 = value; }
        }

        public BAS0270U00GrdBAS0271Result() { }

    }
}
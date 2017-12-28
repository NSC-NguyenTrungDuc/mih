using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0270U00GrdBAS0272Result : AbstractContractResult
    {
        private List<BAS0270U00GrdBAS0272Info> _grdBAS0272 = new List<BAS0270U00GrdBAS0272Info>();

        public List<BAS0270U00GrdBAS0272Info> GrdBAS0272
        {
            get { return this._grdBAS0272; }
            set { this._grdBAS0272 = value; }
        }

        public BAS0270U00GrdBAS0272Result() { }

    }
}
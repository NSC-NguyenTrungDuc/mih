using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0203U00GrdBAS0203Result : AbstractContractResult
    {
        private List<BAS0203U00GrdBAS0203Info> _grdBas0203Item = new List<BAS0203U00GrdBAS0203Info>();

        public List<BAS0203U00GrdBAS0203Info> GrdBas0203Item
        {
            get { return this._grdBas0203Item; }
            set { this._grdBas0203Item = value; }
        }

        public BAS0203U00GrdBAS0203Result() { }

    }
}
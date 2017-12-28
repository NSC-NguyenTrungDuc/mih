using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U00GrdOCS0115Result : AbstractContractResult
    {
        private List<OCS0103U00GrdOCS0115Info> _grdOcs115Item = new List<OCS0103U00GrdOCS0115Info>();

        public List<OCS0103U00GrdOCS0115Info> GrdOcs115Item
        {
            get { return this._grdOcs115Item; }
            set { this._grdOcs115Item = value; }
        }

        public OCS0103U00GrdOCS0115Result() { }

    }
}
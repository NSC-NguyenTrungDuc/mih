using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0118U00GrdOCS0118Result : AbstractContractResult
    {
        private List<OCS0118U00GrdOCS0118Info> _grdOCS0118Info = new List<OCS0118U00GrdOCS0118Info>();

        public List<OCS0118U00GrdOCS0118Info> GrdOCS0118Info
        {
            get { return this._grdOCS0118Info; }
            set { this._grdOCS0118Info = value; }
        }

        public OCS0118U00GrdOCS0118Result() { }

    }
}
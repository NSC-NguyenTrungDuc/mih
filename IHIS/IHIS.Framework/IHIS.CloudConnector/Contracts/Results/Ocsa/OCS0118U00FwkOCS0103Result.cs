using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0118U00FwkOCS0103Result : AbstractContractResult
    {
        private List<OCS0118U00FwkOCS0103Info> _fwkOCS0103Info = new List<OCS0118U00FwkOCS0103Info>();

        public List<OCS0118U00FwkOCS0103Info> FwkOCS0103Info
        {
            get { return this._fwkOCS0103Info; }
            set { this._fwkOCS0103Info = value; }
        }

        public OCS0118U00FwkOCS0103Result() { }

    }
}
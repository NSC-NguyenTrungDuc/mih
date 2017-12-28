using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCS1023U00GrdOCS1023Result : AbstractContractResult
    {
        private List<OCS1023U00GrdOCS1023Info> _listInfo = new List<OCS1023U00GrdOCS1023Info>();

        public List<OCS1023U00GrdOCS1023Info> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public OCS1023U00GrdOCS1023Result() { }

    }
}
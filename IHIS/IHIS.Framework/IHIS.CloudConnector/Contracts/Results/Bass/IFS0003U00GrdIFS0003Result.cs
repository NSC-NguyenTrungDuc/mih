using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class IFS0003U00GrdIFS0003Result : AbstractContractResult
    {
        private List<IFS0003U00GrdIFS0003Info> _grdList = new List<IFS0003U00GrdIFS0003Info>();

        public List<IFS0003U00GrdIFS0003Info> GrdList
        {
            get { return this._grdList; }
            set { this._grdList = value; }
        }

        public IFS0003U00GrdIFS0003Result() { }

    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class IFS0003U01GrdIFS0003Result : AbstractContractResult
    {
        private List<IFS0003U01GrdIFS0003Info> _grdIfsItem = new List<IFS0003U01GrdIFS0003Info>();

        public List<IFS0003U01GrdIFS0003Info> GrdIfsItem
        {
            get { return this._grdIfsItem; }
            set { this._grdIfsItem = value; }
        }

        public IFS0003U01GrdIFS0003Result() { }

    }
}
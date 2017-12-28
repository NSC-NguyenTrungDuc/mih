using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV2003U00ExportCSVResult : AbstractContractResult
    {
        private List<INV2003U00ExportCSVInfo> _listInfo = new List<INV2003U00ExportCSVInfo>();

        public List<INV2003U00ExportCSVInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public INV2003U00ExportCSVResult() { }

    }
}
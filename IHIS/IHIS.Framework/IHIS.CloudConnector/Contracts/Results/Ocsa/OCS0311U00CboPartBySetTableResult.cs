using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311U00CboPartBySetTableResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _cboPartBySetTable = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> CboPartBySetTable
        {
            get { return this._cboPartBySetTable; }
            set { this._cboPartBySetTable = value; }
        }

        public OCS0311U00CboPartBySetTableResult() { }

    }
}
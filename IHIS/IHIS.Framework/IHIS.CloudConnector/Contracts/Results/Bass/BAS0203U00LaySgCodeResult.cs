using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0203U00LaySgCodeResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _laySgCodeItem = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> LaySgCodeItem
        {
            get { return this._laySgCodeItem; }
            set { this._laySgCodeItem = value; }
        }

        public BAS0203U00LaySgCodeResult() { }

    }
}
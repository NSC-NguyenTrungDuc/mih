using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class Schs0201U99CheckReserResult : AbstractContractResult
    {
        private List<Schs0201U99InsertResultInfo> _insItem = new List<Schs0201U99InsertResultInfo>();
        private OCS1003P01LaySaveLayoutListItemInfo _saveItem;

        public List<Schs0201U99InsertResultInfo> InsItem
        {
            get { return this._insItem; }
            set { this._insItem = value; }
        }

        public OCS1003P01LaySaveLayoutListItemInfo SaveItem
        {
            get { return this._saveItem; }
            set { this._saveItem = value; }
        }

        public Schs0201U99CheckReserResult() { }

    }
}
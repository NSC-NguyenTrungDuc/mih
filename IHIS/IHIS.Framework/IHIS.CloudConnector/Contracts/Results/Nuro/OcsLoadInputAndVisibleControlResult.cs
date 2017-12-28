using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class OcsLoadInputAndVisibleControlResult : AbstractContractResult
    {
        private List<OcsLoadInputControlListItemInfo> _controlList = new List<OcsLoadInputControlListItemInfo>();
        private List<OcsLoadVisibleControlListItemInfo> _visibleControlList = new List<OcsLoadVisibleControlListItemInfo>();

        public List<OcsLoadInputControlListItemInfo> ControlList
        {
            get { return this._controlList; }
            set { this._controlList = value; }
        }

        public List<OcsLoadVisibleControlListItemInfo> VisibleControlList
        {
            get { return this._visibleControlList; }
            set { this._visibleControlList = value; }
        }

        public OcsLoadInputAndVisibleControlResult() { }

    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCSACTCboSystemSelectedIndexChangedResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _cboPartItem = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _cbxActorItem = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> CboPartItem
        {
            get { return this._cboPartItem; }
            set { this._cboPartItem = value; }
        }

        public List<ComboListItemInfo> CbxActorItem
        {
            get { return this._cbxActorItem; }
            set { this._cbxActorItem = value; }
        }

        public OCSACTCboSystemSelectedIndexChangedResult() { }

    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCSACTCboTimeAndSystemResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _cboTime = new List<ComboListItemInfo>();
        private List<ComboListItemInfo> _cboSystem = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> CboTime
        {
            get { return this._cboTime; }
            set { this._cboTime = value; }
        }

        public List<ComboListItemInfo> CboSystem
        {
            get { return this._cboSystem; }
            set { this._cboSystem = value; }
        }

        public OCSACTCboTimeAndSystemResult() { }

    }
}
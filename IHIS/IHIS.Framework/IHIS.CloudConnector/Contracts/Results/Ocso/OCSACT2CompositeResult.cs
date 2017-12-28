using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OCSACT2CompositeResult : AbstractContractResult
    {
        private OCSACTCboTimeAndSystemResult _cboTimeAndSysRes;
        private ComboResult _cboUserRes;
        private OCSACT2GetGrdPaListResult _grdPaListRes;
        private OCSACTCboSystemSelectedIndexChangedResult _cboSelectedIndexChangeRes;
        private LayConstantInfoResult _layConstantConsRes;
        private LayConstantInfoResult _layConstantRes;

        public OCSACTCboTimeAndSystemResult CboTimeAndSysRes
        {
            get { return this._cboTimeAndSysRes; }
            set { this._cboTimeAndSysRes = value; }
        }

        public ComboResult CboUserRes
        {
            get { return this._cboUserRes; }
            set { this._cboUserRes = value; }
        }

        public OCSACT2GetGrdPaListResult GrdPaListRes
        {
            get { return this._grdPaListRes; }
            set { this._grdPaListRes = value; }
        }

        public OCSACTCboSystemSelectedIndexChangedResult CboSelectedIndexChangeRes
        {
            get { return this._cboSelectedIndexChangeRes; }
            set { this._cboSelectedIndexChangeRes = value; }
        }

        public LayConstantInfoResult LayConstantConsRes
        {
            get { return this._layConstantConsRes; }
            set { this._layConstantConsRes = value; }
        }

        public LayConstantInfoResult LayConstantRes
        {
            get { return this._layConstantRes; }
            set { this._layConstantRes = value; }
        }

        public OCSACT2CompositeResult() { }

    }
}
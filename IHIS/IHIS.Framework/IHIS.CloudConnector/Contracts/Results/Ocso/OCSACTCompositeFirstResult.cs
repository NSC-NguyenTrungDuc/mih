using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OCSACTCompositeFirstResult : AbstractContractResult
    {
        private OCSACTCboSystemSelectedIndexChangedResult _cboSystemEventList;
        private LayConstantInfoResult _layConstList;
        private LayConstantInfoResult _layAlarmList;

        public OCSACTCboSystemSelectedIndexChangedResult CboSystemEventList
        {
            get { return this._cboSystemEventList; }
            set { this._cboSystemEventList = value; }
        }

        public LayConstantInfoResult LayConstList
        {
            get { return this._layConstList; }
            set { this._layConstList = value; }
        }

        public LayConstantInfoResult LayAlarmList
        {
            get { return this._layAlarmList; }
            set { this._layAlarmList = value; }
        }

        public OCSACTCompositeFirstResult() { }

    }
}
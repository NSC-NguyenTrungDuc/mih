using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    public class OCSACTCompositeFirstArgs : IContractArgs
    {
        private OCSACTCboSystemSelectedIndexChangedArgs _cboSystemEventParam;
        private OCSACTLayconstantConstArgs _layConstParam;
        private OCSACTLayconstantAlarmArgs _layAlarmParam;

        public OCSACTCboSystemSelectedIndexChangedArgs CboSystemEventParam
        {
            get { return this._cboSystemEventParam; }
            set { this._cboSystemEventParam = value; }
        }

        public OCSACTLayconstantConstArgs LayConstParam
        {
            get { return this._layConstParam; }
            set { this._layConstParam = value; }
        }

        public OCSACTLayconstantAlarmArgs LayAlarmParam
        {
            get { return this._layAlarmParam; }
            set { this._layAlarmParam = value; }
        }

        public OCSACTCompositeFirstArgs() { }

        public OCSACTCompositeFirstArgs(OCSACTCboSystemSelectedIndexChangedArgs cboSystemEventParam, OCSACTLayconstantConstArgs layConstParam, OCSACTLayconstantAlarmArgs layAlarmParam)
        {
            this._cboSystemEventParam = cboSystemEventParam;
            this._layConstParam = layConstParam;
            this._layAlarmParam = layAlarmParam;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTCompositeFirstRequest();
        }
    }
}
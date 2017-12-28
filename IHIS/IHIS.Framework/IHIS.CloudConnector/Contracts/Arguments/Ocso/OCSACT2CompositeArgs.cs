using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Messaging;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    public class OCSACT2CompositeArgs : IContractArgs
    {
        private OCSACTCboTimeAndSystemArgs _cboTimeAndSys;
        private OCSACT2GetComboUserArgs _cboUser;
        private OCSACT2GetGrdPaListArgs _grdPaList;
        private OCSACTCboSystemSelectedIndexChangedArgs _cboSelectedIndexChange;
        private OCSACTLayconstantConstArgs _layConstantCons;
        private OCSACTLayconstantAlarmArgs _layConstantAlarm;

        public OCSACTCboTimeAndSystemArgs CboTimeAndSys
        {
            get { return this._cboTimeAndSys; }
            set { this._cboTimeAndSys = value; }
        }

        public OCSACT2GetComboUserArgs CboUser
        {
            get { return this._cboUser; }
            set { this._cboUser = value; }
        }

        public OCSACT2GetGrdPaListArgs GrdPaList
        {
            get { return this._grdPaList; }
            set { this._grdPaList = value; }
        }

        public OCSACTCboSystemSelectedIndexChangedArgs CboSelectedIndexChange
        {
            get { return this._cboSelectedIndexChange; }
            set { this._cboSelectedIndexChange = value; }
        }

        public OCSACTLayconstantConstArgs LayConstantCons
        {
            get { return this._layConstantCons; }
            set { this._layConstantCons = value; }
        }

        public OCSACTLayconstantAlarmArgs LayConstantAlarm
        {
            get { return this._layConstantAlarm; }
            set { this._layConstantAlarm = value; }
        }

        public OCSACT2CompositeArgs() { }

        public OCSACT2CompositeArgs(OCSACTCboTimeAndSystemArgs cboTimeAndSys, OCSACT2GetComboUserArgs cboUser, OCSACT2GetGrdPaListArgs grdPaList, OCSACTCboSystemSelectedIndexChangedArgs cboSelectedIndexChange, OCSACTLayconstantConstArgs layConstantCons, OCSACTLayconstantAlarmArgs layConstantAlarm)
        {
            this._cboTimeAndSys = cboTimeAndSys;
            this._cboUser = cboUser;
            this._grdPaList = grdPaList;
            this._cboSelectedIndexChange = cboSelectedIndexChange;
            this._layConstantCons = layConstantCons;
            this._layConstantAlarm = layConstantAlarm;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACT2CompositeRequest();
        }
    }
}
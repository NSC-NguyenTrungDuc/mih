using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    public class SaveEmrCompositeFirstArgs : IContractArgs
    {
        private OcsoOCS1003P01CheckXArgs _ocs1003p01Checkx;
        private List<CheckPatientStatusArgs> _checkPatientStatus = new List<CheckPatientStatusArgs>();
        private List<OcsoOCS1003P01GetChuciArgs> _ocs1003p01GetChuci = new List<OcsoOCS1003P01GetChuciArgs>();
        private List<DupCheckInputOutOrderArgs> _dupCheckInputOutOrder = new List<DupCheckInputOutOrderArgs>();

        public OcsoOCS1003P01CheckXArgs Ocs1003p01Checkx
        {
            get { return this._ocs1003p01Checkx; }
            set { this._ocs1003p01Checkx = value; }
        }

        public List<CheckPatientStatusArgs> CheckPatientStatus
        {
            get { return this._checkPatientStatus; }
            set { this._checkPatientStatus = value; }
        }

        public List<OcsoOCS1003P01GetChuciArgs> Ocs1003p01GetChuci
        {
            get { return this._ocs1003p01GetChuci; }
            set { this._ocs1003p01GetChuci = value; }
        }

        public List<DupCheckInputOutOrderArgs> DupCheckInputOutOrder
        {
            get { return this._dupCheckInputOutOrder; }
            set { this._dupCheckInputOutOrder = value; }
        }

        public SaveEmrCompositeFirstArgs() { }

        public SaveEmrCompositeFirstArgs(OcsoOCS1003P01CheckXArgs ocs1003p01Checkx, List<CheckPatientStatusArgs> checkPatientStatus, List<OcsoOCS1003P01GetChuciArgs> ocs1003p01GetChuci, List<DupCheckInputOutOrderArgs> dupCheckInputOutOrder)
        {
            this._ocs1003p01Checkx = ocs1003p01Checkx;
            this._checkPatientStatus = checkPatientStatus;
            this._ocs1003p01GetChuci = ocs1003p01GetChuci;
            this._dupCheckInputOutOrder = dupCheckInputOutOrder;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SaveEmrCompositeFirstRequest();
        }
    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.System;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    public class OpenScreenDRG5100P01CompositeArgs : IContractArgs
    {
        private List<DRG5100P01CheckActArgs> _checkAct = new List<DRG5100P01CheckActArgs>();
        private List<FormEnvironInfoSysDateArgs> _sysDate = new List<FormEnvironInfoSysDateArgs>();
        private List<DrgsDRG5100P01GridPaidListArgs> _paidList = new List<DrgsDRG5100P01GridPaidListArgs>();
        private List<GetPatientByCodeArgs> _patientBycode = new List<GetPatientByCodeArgs>();

        public List<DRG5100P01CheckActArgs> CheckAct
        {
            get { return this._checkAct; }
            set { this._checkAct = value; }
        }

        public List<FormEnvironInfoSysDateArgs> SysDate
        {
            get { return this._sysDate; }
            set { this._sysDate = value; }
        }

        public List<DrgsDRG5100P01GridPaidListArgs> PaidList
        {
            get { return this._paidList; }
            set { this._paidList = value; }
        }

        public List<GetPatientByCodeArgs> PatientBycode
        {
            get { return this._patientBycode; }
            set { this._patientBycode = value; }
        }

        public OpenScreenDRG5100P01CompositeArgs() { }

        public OpenScreenDRG5100P01CompositeArgs(List<DRG5100P01CheckActArgs> checkAct, List<FormEnvironInfoSysDateArgs> sysDate, List<DrgsDRG5100P01GridPaidListArgs> paidList, List<GetPatientByCodeArgs> patientBycode)
        {
            this._checkAct = checkAct;
            this._sysDate = sysDate;
            this._paidList = paidList;
            this._patientBycode = patientBycode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OpenScreenDRG5100P01CompositeRequest();
        }
    }
}
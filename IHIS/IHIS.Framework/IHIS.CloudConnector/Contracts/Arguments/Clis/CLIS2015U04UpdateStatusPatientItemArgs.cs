using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U04UpdateStatusPatientItemArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U04UpdateStatusPatientItemArgs other)
        {
            return Equals(_patientStatus, other._patientStatus);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U04UpdateStatusPatientItemArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_patientStatus != null ? _patientStatus.GetHashCode() : 0);
        }

        private List<CLIS2015U04GetPatientStatusListItemInfo> _patientStatus = new List<CLIS2015U04GetPatientStatusListItemInfo>();

        public List<CLIS2015U04GetPatientStatusListItemInfo> PatientStatus
        {
            get { return this._patientStatus; }
            set { this._patientStatus = value; }
        }

        public CLIS2015U04UpdateStatusPatientItemArgs() { }

        public CLIS2015U04UpdateStatusPatientItemArgs(List<CLIS2015U04GetPatientStatusListItemInfo> patientStatus)
        {
            this._patientStatus = patientStatus;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U04UpdateStatusPatientItemRequest();
        }
    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U03SaveLayoutArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U03SaveLayoutArgs other)
        {
            return Equals(_patientListItem, other._patientListItem) && string.Equals(_hospCode, other._hospCode) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U03SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_patientListItem != null ? _patientListItem.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private List<CLIS2015U03PatientListInfo> _patientListItem = new List<CLIS2015U03PatientListInfo>();
        private String _hospCode;
        private String _userId;

        public List<CLIS2015U03PatientListInfo> PatientListItem
        {
            get { return this._patientListItem; }
            set { this._patientListItem = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public CLIS2015U03SaveLayoutArgs() { }

        public CLIS2015U03SaveLayoutArgs(List<CLIS2015U03PatientListInfo> patientListItem, String hospCode, String userId)
        {
            this._patientListItem = patientListItem;
            this._hospCode = hospCode;
            this._userId = userId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U03SaveLayoutRequest();
        }
    }
}
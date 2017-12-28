using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroRES1001U00ReserListArgs : IContractArgs
    {
        protected bool Equals(NuroRES1001U00ReserListArgs other)
        {
            return string.Equals(_patientCode, other._patientCode) && string.Equals(_hospCodeLink, other._hospCodeLink) && _tabIsAll.Equals(other._tabIsAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00ReserListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_patientCode != null ? _patientCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _tabIsAll.GetHashCode();
                return hashCode;
            }
        }

        private String _patientCode;
        private String _hospCodeLink;
        private Boolean _tabIsAll;

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public Boolean TabIsAll
        {
            get { return this._tabIsAll; }
            set { this._tabIsAll = value; }
        }

        public NuroRES1001U00ReserListArgs() { }

        public NuroRES1001U00ReserListArgs(String patientCode, String hospCodeLink, Boolean tabIsAll)
        {
            this._patientCode = patientCode;
            this._hospCodeLink = hospCodeLink;
            this._tabIsAll = tabIsAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroRES1001U00ReserListRequest();
        }
    }
}
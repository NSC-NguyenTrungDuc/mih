using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class RES1001U00MapingCodeArgs : IContractArgs
    {
        protected bool Equals(RES1001U00MapingCodeArgs other)
        {
            return string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_hospCodeLink, other._hospCodeLink) && _tabIsAll.Equals(other._tabIsAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RES1001U00MapingCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _tabIsAll.GetHashCode();
                return hashCode;
            }
        }

        private String _gwa;
        private String _doctor;
        private String _hospCodeLink;
        private Boolean _tabIsAll;

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
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

        public RES1001U00MapingCodeArgs() { }

        public RES1001U00MapingCodeArgs(String gwa, String doctor, String hospCodeLink, Boolean tabIsAll)
        {
            this._gwa = gwa;
            this._doctor = doctor;
            this._hospCodeLink = hospCodeLink;
            this._tabIsAll = tabIsAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.RES1001U00MapingCodeRequest();
        }
    }
}
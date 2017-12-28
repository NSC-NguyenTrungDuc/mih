using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroRES0102U00CboGwaArgs : IContractArgs
    {
        protected bool Equals(NuroRES0102U00CboGwaArgs other)
        {
            return string.Equals(_appDate, other._appDate) && string.Equals(_hospCode, other._hospCode) && string.Equals(_hospCodeLink, other._hospCodeLink) && _tabIsAll.Equals(other._tabIsAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES0102U00CboGwaArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_appDate != null ? _appDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _tabIsAll.GetHashCode();
                return hashCode;
            }
        }

        private String _appDate;
        private String _hospCode;
        private String _hospCodeLink;
        private Boolean _tabIsAll;

        public String AppDate
        {
            get { return this._appDate; }
            set { this._appDate = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
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

        public NuroRES0102U00CboGwaArgs() { }

        public NuroRES0102U00CboGwaArgs(String appDate, String hospCode, String hospCodeLink, Boolean tabIsAll)
        {
            this._appDate = appDate;
            this._hospCode = hospCode;
            this._hospCodeLink = hospCodeLink;
            this._tabIsAll = tabIsAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroRES0102U00CboGwaRequest();
        }
    }
}
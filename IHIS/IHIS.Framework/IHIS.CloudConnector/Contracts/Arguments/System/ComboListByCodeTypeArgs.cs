using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class ComboListByCodeTypeArgs : IContractArgs
    {
        protected bool Equals(ComboListByCodeTypeArgs other)
        {
            return string.Equals(_codeType, other._codeType) && _isAll.Equals(other._isAll) && string.Equals(_hospCodeLink, other._hospCodeLink) && _tabIsAll.Equals(other._tabIsAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComboListByCodeTypeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _isAll.GetHashCode();
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _tabIsAll.GetHashCode();
                return hashCode;
            }
        }

        private String _codeType;
        private Boolean _isAll;
        private String _hospCodeLink;
        private Boolean _tabIsAll;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public Boolean IsAll
        {
            get { return this._isAll; }
            set { this._isAll = value; }
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

        public ComboListByCodeTypeArgs() { }

        public ComboListByCodeTypeArgs(String codeType, Boolean isAll, String hospCodeLink, Boolean tabIsAll)
        {
            this._codeType = codeType;
            this._isAll = isAll;
            this._hospCodeLink = hospCodeLink;
            this._tabIsAll = tabIsAll;
        }

        public ComboListByCodeTypeArgs(String codeType, Boolean isAll)
        {
            this._codeType = codeType;
            this._isAll = isAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ComboListByCodeTypeRequest();
        }
    }
}
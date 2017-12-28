using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM104UGridUserArgs : IContractArgs
    {
        protected bool Equals(ADM104UGridUserArgs other)
        {
            return string.Equals(_userGroup, other._userGroup) && string.Equals(_searchWord, other._searchWord) && string.Equals(_userGubun, other._userGubun) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM104UGridUserArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userGroup != null ? _userGroup.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_searchWord != null ? _searchWord.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userGubun != null ? _userGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userGroup;
        private String _searchWord;
        private String _userGubun;
        private String _hospCode;

        public String UserGroup
        {
            get { return this._userGroup; }
            set { this._userGroup = value; }
        }

        public String SearchWord
        {
            get { return this._searchWord; }
            set { this._searchWord = value; }
        }

        public String UserGubun
        {
            get { return this._userGubun; }
            set { this._userGubun = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public ADM104UGridUserArgs() { }

        public ADM104UGridUserArgs(String userGroup, String searchWord, String userGubun, String hospCode)
        {
            this._userGroup = userGroup;
            this._searchWord = searchWord;
            this._userGubun = userGubun;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM104UGridUserRequest();
        }
    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM2016U00GrdLoadDrgArgs : IContractArgs
    {
        protected bool Equals(ADM2016U00GrdLoadDrgArgs other)
        {
            return string.Equals(_searchName, other._searchName) && string.Equals(_searchType, other._searchType) && string.Equals(_searchAccount, other._searchAccount) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM2016U00GrdLoadDrgArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_searchName != null ? _searchName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_searchType != null ? _searchType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_searchAccount != null ? _searchAccount.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _searchName;
        private String _searchType;
        private String _searchAccount;
        private String _pageNumber;
        private String _offset;

        public String SearchName
        {
            get { return this._searchName; }
            set { this._searchName = value; }
        }

        public String SearchType
        {
            get { return this._searchType; }
            set { this._searchType = value; }
        }

        public String SearchAccount
        {
            get { return this._searchAccount; }
            set { this._searchAccount = value; }
        }

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public String Offset
        {
            get { return this._offset; }
            set { this._offset = value; }
        }

        public ADM2016U00GrdLoadDrgArgs() { }

        public ADM2016U00GrdLoadDrgArgs(String searchName, String searchType, String searchAccount, String pageNumber, String offset)
        {
            this._searchName = searchName;
            this._searchType = searchType;
            this._searchAccount = searchAccount;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM2016U00GrdLoadDrgRequest();
        }
    }
}
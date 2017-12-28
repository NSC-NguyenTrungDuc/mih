using System;
using IHIS.CloudConnector.Contracts.Models.Chts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
    public class CHT0117GrdCHT0117InitArgs : IContractArgs
    {
        protected bool Equals(CHT0117GrdCHT0117InitArgs other)
        {
            return string.Equals(_queryDate, other._queryDate) && string.Equals(_searchWord, other._searchWord) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0117GrdCHT0117InitArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_queryDate != null ? _queryDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_searchWord != null ? _searchWord.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _queryDate;
        private String _searchWord;
        private String _pageNumber;
        private String _offset;

        public String QueryDate
        {
            get { return this._queryDate; }
            set { this._queryDate = value; }
        }

        public String SearchWord
        {
            get { return this._searchWord; }
            set { this._searchWord = value; }
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

        public CHT0117GrdCHT0117InitArgs() { }

        public CHT0117GrdCHT0117InitArgs(String queryDate, String searchWord, String pageNumber, String offset)
        {
            this._queryDate = queryDate;
            this._searchWord = searchWord;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CHT0117GrdCHT0117InitRequest();
        }
    }
}
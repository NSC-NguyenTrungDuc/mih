using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM201UGrdDicMasterArgs : IContractArgs
    {
        protected bool Equals(ADM201UGrdDicMasterArgs other)
        {
            return string.Equals(_colId, other._colId) && string.Equals(_colNm, other._colNm) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM201UGrdDicMasterArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_colId != null ? _colId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_colNm != null ? _colNm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _colId;
        private String _colNm;
        private String _pageNumber;
        private String _offset;

        public String ColId
        {
            get { return this._colId; }
            set { this._colId = value; }
        }

        public String ColNm
        {
            get { return this._colNm; }
            set { this._colNm = value; }
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

        public ADM201UGrdDicMasterArgs() { }

        public ADM201UGrdDicMasterArgs(String colId, String colNm, String pageNumber, String offset)
        {
            this._colId = colId;
            this._colNm = colNm;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM201UGrdDicMasterRequest();
        }
    }
}
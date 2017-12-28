using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0101U04GrdMasterArgs : IContractArgs
    {
        protected bool Equals(BAS0101U04GrdMasterArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0101U04GrdMasterArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _codeType;
        private String _pageNumber;
        private String _offset;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
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

        public BAS0101U04GrdMasterArgs() { }

        public BAS0101U04GrdMasterArgs(String codeType, String pageNumber, String offset)
        {
            this._codeType = codeType;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0101U04GrdMasterRequest();
        }
    }
}
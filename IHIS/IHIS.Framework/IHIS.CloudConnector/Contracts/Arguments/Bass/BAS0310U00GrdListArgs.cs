using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0310U00GrdListArgs : IContractArgs
    {
        protected bool Equals(BAS0310U00GrdListArgs other)
        {
            return string.Equals(_bunCode, other._bunCode) && string.Equals(_aText, other._aText) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0310U00GrdListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunCode != null ? _bunCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_aText != null ? _aText.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunCode;
        private String _aText;
        private String _pageNumber;
        private String _offset;

        public String BunCode
        {
            get { return this._bunCode; }
            set { this._bunCode = value; }
        }

        public String AText
        {
            get { return this._aText; }
            set { this._aText = value; }
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

        public BAS0310U00GrdListArgs() { }

        public BAS0310U00GrdListArgs(String bunCode, String aText, String pageNumber, String offset)
        {
            this._bunCode = bunCode;
            this._aText = aText;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0310U00GrdListRequest();
        }
    }
}
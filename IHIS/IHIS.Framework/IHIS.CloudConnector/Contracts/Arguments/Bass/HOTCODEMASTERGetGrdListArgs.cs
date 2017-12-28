using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class HOTCODEMASTERGetGrdListArgs : IContractArgs
    {
        protected bool Equals(HOTCODEMASTERGetGrdListArgs other)
        {
            return string.Equals(_hotCode, other._hotCode) && string.Equals(_hangmogName, other._hangmogName) && string.Equals(_offset, other._offset) && string.Equals(_pageNumber, other._pageNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HOTCODEMASTERGetGrdListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hotCode != null ? _hotCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hangmogName != null ? _hangmogName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hotCode;
        private String _hangmogName;
        private String _offset;
        private String _pageNumber;

        public String HotCode
        {
            get { return this._hotCode; }
            set { this._hotCode = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String Offset
        {
            get { return this._offset; }
            set { this._offset = value; }
        }

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public HOTCODEMASTERGetGrdListArgs() { }

        public HOTCODEMASTERGetGrdListArgs(String hotCode, String hangmogName, String offset, String pageNumber)
        {
            this._hotCode = hotCode;
            this._hangmogName = hangmogName;
            this._offset = offset;
            this._pageNumber = pageNumber;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.HOTCODEMASTERGetGrdListRequest();
        }
    }
}
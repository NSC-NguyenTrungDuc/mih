using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U02GrdTrialDrgArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U02GrdTrialDrgArgs other)
        {
            return string.Equals(_protocolId, other._protocolId) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U02GrdTrialDrgArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_protocolId != null ? _protocolId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _protocolId;
        private String _pageNumber;
        private String _offset;

        public String ProtocolId
        {
            get { return this._protocolId; }
            set { this._protocolId = value; }
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

        public CLIS2015U02GrdTrialDrgArgs() { }

        public CLIS2015U02GrdTrialDrgArgs(String protocolId, String pageNumber, String offset)
        {
            this._protocolId = protocolId;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U02GrdTrialDrgRequest();
        }
    }
}
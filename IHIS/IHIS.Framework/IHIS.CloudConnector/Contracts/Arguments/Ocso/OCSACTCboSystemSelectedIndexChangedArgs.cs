using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTCboSystemSelectedIndexChangedArgs : IContractArgs
    {
    protected bool Equals(OCSACTCboSystemSelectedIndexChangedArgs other)
    {
        return string.Equals(_systemId, other._systemId) && string.Equals(_codeType, other._codeType) && string.Equals(_hoDong, other._hoDong);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSACTCboSystemSelectedIndexChangedArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_systemId != null ? _systemId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hoDong != null ? _hoDong.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _systemId;
        private String _codeType;
        private String _hoDong;

        public String SystemId
        {
            get { return this._systemId; }
            set { this._systemId = value; }
        }

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String HoDong
        {
            get { return this._hoDong; }
            set { this._hoDong = value; }
        }

        public OCSACTCboSystemSelectedIndexChangedArgs() { }

        public OCSACTCboSystemSelectedIndexChangedArgs(String systemId, String codeType, String hoDong)
        {
            this._systemId = systemId;
            this._codeType = codeType;
            this._hoDong = hoDong;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTCboSystemSelectedIndexChangedRequest();
        }
    }
}
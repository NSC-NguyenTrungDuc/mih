using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0311U00layDupHangmogCodeArgs : IContractArgs
    {
    protected bool Equals(OCS0311U00layDupHangmogCodeArgs other)
    {
        return string.Equals(_setPart, other._setPart) && string.Equals(_hangmogCode, other._hangmogCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0311U00layDupHangmogCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_setPart != null ? _setPart.GetHashCode() : 0)*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
        }
    }

    private String _setPart;
        private String _hangmogCode;

        public String SetPart
        {
            get { return this._setPart; }
            set { this._setPart = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public OCS0311U00layDupHangmogCodeArgs() { }

        public OCS0311U00layDupHangmogCodeArgs(String setPart, String hangmogCode)
        {
            this._setPart = setPart;
            this._hangmogCode = hangmogCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0311U00layDupHangmogCodeRequest();
        }
    }
}
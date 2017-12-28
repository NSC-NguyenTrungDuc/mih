using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0311U00grdSetHangmogArgs : IContractArgs
    {
    protected bool Equals(OCS0311U00grdSetHangmogArgs other)
    {
        return string.Equals(_setPart, other._setPart) && string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_setCode, other._setCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0311U00grdSetHangmogArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_setPart != null ? _setPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_setCode != null ? _setCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _setPart;
        private String _hangmogCode;
        private String _setCode;

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

        public String SetCode
        {
            get { return this._setCode; }
            set { this._setCode = value; }
        }

        public OCS0311U00grdSetHangmogArgs() { }

        public OCS0311U00grdSetHangmogArgs(String setPart, String hangmogCode, String setCode)
        {
            this._setPart = setPart;
            this._hangmogCode = hangmogCode;
            this._setCode = setCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0311U00grdSetHangmogRequest();
        }
    }
}
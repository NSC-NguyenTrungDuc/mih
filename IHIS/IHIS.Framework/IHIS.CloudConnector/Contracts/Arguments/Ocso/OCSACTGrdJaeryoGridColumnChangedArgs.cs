using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTGrdJaeryoGridColumnChangedArgs : IContractArgs
    {
    protected bool Equals(OCSACTGrdJaeryoGridColumnChangedArgs other)
    {
        return string.Equals(_hangmogCode1, other._hangmogCode1) && string.Equals(_hangmogCode2, other._hangmogCode2) && string.Equals(_setHangmogCode, other._setHangmogCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSACTGrdJaeryoGridColumnChangedArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_hangmogCode1 != null ? _hangmogCode1.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogCode2 != null ? _hangmogCode2.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_setHangmogCode != null ? _setHangmogCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _hangmogCode1;
        private String _hangmogCode2;
        private String _setHangmogCode;

        public String HangmogCode1
        {
            get { return this._hangmogCode1; }
            set { this._hangmogCode1 = value; }
        }

        public String HangmogCode2
        {
            get { return this._hangmogCode2; }
            set { this._hangmogCode2 = value; }
        }

        public String SetHangmogCode
        {
            get { return this._setHangmogCode; }
            set { this._setHangmogCode = value; }
        }

        public OCSACTGrdJaeryoGridColumnChangedArgs() { }

        public OCSACTGrdJaeryoGridColumnChangedArgs(String hangmogCode1, String hangmogCode2, String setHangmogCode)
        {
            this._hangmogCode1 = hangmogCode1;
            this._hangmogCode2 = hangmogCode2;
            this._setHangmogCode = setHangmogCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTGrdJaeryoGridColumnChangedRequest();
        }
    }
}
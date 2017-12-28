using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTBtnEMRClickArgs : IContractArgs
    {
    protected bool Equals(OCSACTBtnEMRClickArgs other)
    {
        return string.Equals(_naewonKey, other._naewonKey);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSACTBtnEMRClickArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_naewonKey != null ? _naewonKey.GetHashCode() : 0);
    }

    private String _naewonKey;

        public String NaewonKey
        {
            get { return this._naewonKey; }
            set { this._naewonKey = value; }
        }

        public OCSACTBtnEMRClickArgs() { }

        public OCSACTBtnEMRClickArgs(String naewonKey)
        {
            this._naewonKey = naewonKey;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTBtnEMRClickRequest();
        }
    }
}
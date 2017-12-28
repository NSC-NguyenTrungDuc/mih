using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class Xrt0122Q00GrdDCodeArgs : IContractArgs
    {
    protected bool Equals(Xrt0122Q00GrdDCodeArgs other)
    {
        return string.Equals(_buwiBunryu, other._buwiBunryu) && string.Equals(_flag, other._flag) && string.Equals(_buwiCode, other._buwiCode) && string.Equals(_buwiName, other._buwiName);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Xrt0122Q00GrdDCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_buwiBunryu != null ? _buwiBunryu.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_flag != null ? _flag.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_buwiCode != null ? _buwiCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_buwiName != null ? _buwiName.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _buwiBunryu;
        private String _flag;
        private String _buwiCode;
        private String _buwiName;

        public String BuwiBunryu
        {
            get { return this._buwiBunryu; }
            set { this._buwiBunryu = value; }
        }

        public String Flag
        {
            get { return this._flag; }
            set { this._flag = value; }
        }

        public String BuwiCode
        {
            get { return this._buwiCode; }
            set { this._buwiCode = value; }
        }

        public String BuwiName
        {
            get { return this._buwiName; }
            set { this._buwiName = value; }
        }

        public Xrt0122Q00GrdDCodeArgs() { }

        public Xrt0122Q00GrdDCodeArgs(String buwiBunryu, String flag, String buwiCode, String buwiName)
        {
            this._buwiBunryu = buwiBunryu;
            this._flag = flag;
            this._buwiCode = buwiCode;
            this._buwiName = buwiName;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.Xrt0122Q00GrdDCodeRequest();
        }
    }
}
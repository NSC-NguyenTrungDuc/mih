using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0122U00GrdDcodeArgs : IContractArgs
    {
    protected bool Equals(XRT0122U00GrdDcodeArgs other)
    {
        return string.Equals(_buwiName, other._buwiName) && string.Equals(_buwiCode, other._buwiCode) && string.Equals(_flag, other._flag) && string.Equals(_buwiBunryu, other._buwiBunryu);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0122U00GrdDcodeArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_buwiName != null ? _buwiName.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_buwiCode != null ? _buwiCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_flag != null ? _flag.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_buwiBunryu != null ? _buwiBunryu.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _buwiName;
        private String _buwiCode;
        private String _flag;
        private String _buwiBunryu;

        public String BuwiName
        {
            get { return this._buwiName; }
            set { this._buwiName = value; }
        }

        public String BuwiCode
        {
            get { return this._buwiCode; }
            set { this._buwiCode = value; }
        }

        public String Flag
        {
            get { return this._flag; }
            set { this._flag = value; }
        }

        public String BuwiBunryu
        {
            get { return this._buwiBunryu; }
            set { this._buwiBunryu = value; }
        }

        public XRT0122U00GrdDcodeArgs() { }

        public XRT0122U00GrdDcodeArgs(String buwiName, String buwiCode, String flag, String buwiBunryu)
        {
            this._buwiName = buwiName;
            this._buwiCode = buwiCode;
            this._flag = flag;
            this._buwiBunryu = buwiBunryu;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0122U00GrdDcodeRequest();
        }
    }
}
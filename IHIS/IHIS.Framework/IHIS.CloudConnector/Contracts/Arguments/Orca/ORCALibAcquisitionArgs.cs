using System;
using IHIS.CloudConnector.Contracts.Models.Orca;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Orca
{[Serializable]
    public class ORCALibAcquisitionArgs : IContractArgs
    {
    protected bool Equals(ORCALibAcquisitionArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_fkoif1101, other._fkoif1101);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ORCALibAcquisitionArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_fkoif1101 != null ? _fkoif1101.GetHashCode() : 0);
        }
    }

    private String _hospCode;
        private String _fkoif1101;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Fkoif1101
        {
            get { return this._fkoif1101; }
            set { this._fkoif1101 = value; }
        }

        public ORCALibAcquisitionArgs() { }

        public ORCALibAcquisitionArgs(String hospCode, String fkoif1101)
        {
            this._hospCode = hospCode;
            this._fkoif1101 = fkoif1101;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORCALibAcquisitionRequest();
        }
    }
}
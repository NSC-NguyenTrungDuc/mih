using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0108U00grdOCS0103Args : IContractArgs
    {
    protected bool Equals(OCS0108U00grdOCS0103Args other)
    {
        return string.Equals(_hangmogNameInx, other._hangmogNameInx) && string.Equals(_slipCode, other._slipCode) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0108U00grdOCS0103Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_hangmogNameInx != null ? _hangmogNameInx.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_slipCode != null ? _slipCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _hangmogNameInx;
        private String _slipCode;
        private String _hospCode;

        public String HangmogNameInx
        {
            get { return this._hangmogNameInx; }
            set { this._hangmogNameInx = value; }
        }

        public String SlipCode
        {
            get { return this._slipCode; }
            set { this._slipCode = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0108U00grdOCS0103Args() { }

        public OCS0108U00grdOCS0103Args(String hangmogNameInx, String slipCode, String hospCode)
        {
            this._hangmogNameInx = hangmogNameInx;
            this._slipCode = slipCode;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0108U00grdOCS0103Request();
        }
    }
}
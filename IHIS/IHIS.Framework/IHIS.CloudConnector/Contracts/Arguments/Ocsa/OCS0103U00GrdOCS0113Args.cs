using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00GrdOCS0113Args : IContractArgs
    {
    protected bool Equals(OCS0103U00GrdOCS0113Args other)
    {
        return string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_hangmogStartDate, other._hangmogStartDate) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00GrdOCS0113Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogStartDate != null ? _hangmogStartDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _hangmogCode;
        private String _hangmogStartDate;
        private String _hospCode;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HangmogStartDate
        {
            get { return this._hangmogStartDate; }
            set { this._hangmogStartDate = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0103U00GrdOCS0113Args() { }

        public OCS0103U00GrdOCS0113Args(String hangmogCode, String hangmogStartDate, String hospCode)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogStartDate = hangmogStartDate;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00GrdOCS0113Request();
        }
    }
}
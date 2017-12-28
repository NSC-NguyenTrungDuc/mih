using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00GrdOCS0113ColChangedArgs : IContractArgs
    {
    protected bool Equals(OCS0103U00GrdOCS0113ColChangedArgs other)
    {
        return string.Equals(_specimenCode, other._specimenCode) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00GrdOCS0113ColChangedArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_specimenCode != null ? _specimenCode.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }
    }

    private String _specimenCode;
        private String _hospCode;

        public String SpecimenCode
        {
            get { return this._specimenCode; }
            set { this._specimenCode = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0103U00GrdOCS0113ColChangedArgs() { }

        public OCS0103U00GrdOCS0113ColChangedArgs(String specimenCode, String hospCode)
        {
            this._specimenCode = specimenCode;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00GrdOCS0113ColChangedRequest();
        }
    }
}
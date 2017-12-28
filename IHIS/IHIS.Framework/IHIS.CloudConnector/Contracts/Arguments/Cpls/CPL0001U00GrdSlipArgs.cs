using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0001U00GrdSlipArgs : IContractArgs
    {
        protected bool Equals(CPL0001U00GrdSlipArgs other)
        {
            return string.Equals(_fHospCode, other._fHospCode) && string.Equals(_fSlipCode, other._fSlipCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0001U00GrdSlipArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_fHospCode != null ? _fHospCode.GetHashCode() : 0)*397) ^ (_fSlipCode != null ? _fSlipCode.GetHashCode() : 0);
            }
        }

        private String _fHospCode;
        private String _fSlipCode;

        public String FHospCode
        {
            get { return this._fHospCode; }
            set { this._fHospCode = value; }
        }

        public String FSlipCode
        {
            get { return this._fSlipCode; }
            set { this._fSlipCode = value; }
        }

        public CPL0001U00GrdSlipArgs() { }

        public CPL0001U00GrdSlipArgs(String fHospCode, String fSlipCode)
        {
            this._fHospCode = fHospCode;
            this._fSlipCode = fSlipCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0001U00GrdSlipRequest();
        }
    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM103UValidateFwkHospitalArgs : IContractArgs
    {
        protected bool Equals(ADM103UValidateFwkHospitalArgs other)
        {
            return string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM103UValidateFwkHospitalArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }

        private String _hospCode;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public ADM103UValidateFwkHospitalArgs() { }

        public ADM103UValidateFwkHospitalArgs(String hospCode)
        {
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM103UValidateFwkHospitalRequest();
        }
    }
}
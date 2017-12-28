using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]

    public class BAS0270U00FwkDoctorArgs : IContractArgs
    {
        protected bool Equals(BAS0270U00FwkDoctorArgs other)
        {
            return string.Equals(_find1, other._find1) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0270U00FwkDoctorArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_find1 != null ? _find1.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            }
        }

        private String _find1;
        private String _hospCode;

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public BAS0270U00FwkDoctorArgs() { }

        public BAS0270U00FwkDoctorArgs(String find1, String hospCode)
        {
            this._find1 = find1;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0270U00FwkDoctorRequest();
        }
    }
}
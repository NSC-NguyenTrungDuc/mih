using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Endo
{
    [Serializable]
    public class END1001U02DsvLDOCS0801Args : IContractArgs
    {
        protected bool Equals(END1001U02DsvLDOCS0801Args other)
        {
            return string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((END1001U02DsvLDOCS0801Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hangmogCode != null ? _hangmogCode.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            }
        }

        private String _hangmogCode;
        private String _hospCode;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public END1001U02DsvLDOCS0801Args() { }

        public END1001U02DsvLDOCS0801Args(String hangmogCode, String hospCode)
        {
            this._hangmogCode = hangmogCode;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.END1001U02DsvLDOCS0801Request();
        }
    }
}
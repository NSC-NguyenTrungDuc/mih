using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0203U00GrdBAS0203Args : IContractArgs
    {
        protected bool Equals(BAS0203U00GrdBAS0203Args other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_jyDate, other._jyDate) && string.Equals(_symyaGubun, other._symyaGubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0203U00GrdBAS0203Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jyDate != null ? _jyDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_symyaGubun != null ? _symyaGubun.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _jyDate;
        private String _symyaGubun;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String JyDate
        {
            get { return this._jyDate; }
            set { this._jyDate = value; }
        }

        public String SymyaGubun
        {
            get { return this._symyaGubun; }
            set { this._symyaGubun = value; }
        }

        public BAS0203U00GrdBAS0203Args() { }

        public BAS0203U00GrdBAS0203Args(String hospCode, String jyDate, String symyaGubun)
        {
            this._hospCode = hospCode;
            this._jyDate = jyDate;
            this._symyaGubun = symyaGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0203U00GrdBAS0203Request();
        }
    }
}
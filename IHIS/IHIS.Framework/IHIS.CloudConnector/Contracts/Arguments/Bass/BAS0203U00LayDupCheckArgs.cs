using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0203U00LayDupCheckArgs : IContractArgs
    {
        protected bool Equals(BAS0203U00LayDupCheckArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_symyaGubun, other._symyaGubun) && string.Equals(_bunCode, other._bunCode) && string.Equals(_sgCode, other._sgCode) && string.Equals(_jyDate, other._jyDate) && string.Equals(_fromTime, other._fromTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0203U00LayDupCheckArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_symyaGubun != null ? _symyaGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunCode != null ? _bunCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sgCode != null ? _sgCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jyDate != null ? _jyDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromTime != null ? _fromTime.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _symyaGubun;
        private String _bunCode;
        private String _sgCode;
        private String _jyDate;
        private String _fromTime;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String SymyaGubun
        {
            get { return this._symyaGubun; }
            set { this._symyaGubun = value; }
        }

        public String BunCode
        {
            get { return this._bunCode; }
            set { this._bunCode = value; }
        }

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public String JyDate
        {
            get { return this._jyDate; }
            set { this._jyDate = value; }
        }

        public String FromTime
        {
            get { return this._fromTime; }
            set { this._fromTime = value; }
        }

        public BAS0203U00LayDupCheckArgs() { }

        public BAS0203U00LayDupCheckArgs(String hospCode, String symyaGubun, String bunCode, String sgCode, String jyDate, String fromTime)
        {
            this._hospCode = hospCode;
            this._symyaGubun = symyaGubun;
            this._bunCode = bunCode;
            this._sgCode = sgCode;
            this._jyDate = jyDate;
            this._fromTime = fromTime;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0203U00LayDupCheckRequest();
        }
    }
}
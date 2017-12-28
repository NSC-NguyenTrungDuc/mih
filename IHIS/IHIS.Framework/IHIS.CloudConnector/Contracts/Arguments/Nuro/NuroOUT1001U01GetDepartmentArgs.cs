using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetDepartmentArgs : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01GetDepartmentArgs other)
        {
            return string.Equals(_buseoYmd, other._buseoYmd) && string.Equals(_find1, other._find1) && string.Equals(_buseoGubun, other._buseoGubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01GetDepartmentArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_buseoYmd != null ? _buseoYmd.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_buseoGubun != null ? _buseoGubun.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _buseoYmd;
        private String _find1;
        private String _buseoGubun;

        public String BuseoYmd
        {
            get { return this._buseoYmd; }
            set { this._buseoYmd = value; }
        }

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public String BuseoGubun
        {
            get { return this._buseoGubun; }
            set { this._buseoGubun = value; }
        }

        public NuroOUT1001U01GetDepartmentArgs() { }

        public NuroOUT1001U01GetDepartmentArgs(String buseoYmd, String find1, String buseoGubun)
        {
            this._buseoYmd = buseoYmd;
            this._find1 = find1;
            this._buseoGubun = buseoGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01GetDepartmentRequest();
        }
    }
}
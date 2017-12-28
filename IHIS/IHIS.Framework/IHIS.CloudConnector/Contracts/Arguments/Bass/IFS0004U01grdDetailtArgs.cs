using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0004U01grdDetailtArgs : IContractArgs
    {
        protected bool Equals(IFS0004U01grdDetailtArgs other)
        {
            return string.Equals(_curYmd, other._curYmd) && string.Equals(_nuGubun, other._nuGubun) && string.Equals(_nuCode, other._nuCode) && string.Equals(_nuYmd, other._nuYmd);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0004U01grdDetailtArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_curYmd != null ? _curYmd.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_nuGubun != null ? _nuGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_nuCode != null ? _nuCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_nuYmd != null ? _nuYmd.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _curYmd;
        private String _nuGubun;
        private String _nuCode;
        private String _nuYmd;

        public String CurYmd
        {
            get { return this._curYmd; }
            set { this._curYmd = value; }
        }

        public String NuGubun
        {
            get { return this._nuGubun; }
            set { this._nuGubun = value; }
        }

        public String NuCode
        {
            get { return this._nuCode; }
            set { this._nuCode = value; }
        }

        public String NuYmd
        {
            get { return this._nuYmd; }
            set { this._nuYmd = value; }
        }

        public IFS0004U01grdDetailtArgs() { }

        public IFS0004U01grdDetailtArgs(String curYmd, String nuGubun, String nuCode, String nuYmd)
        {
            this._curYmd = curYmd;
            this._nuGubun = nuGubun;
            this._nuCode = nuCode;
            this._nuYmd = nuYmd;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0004U01grdDetailtRequest();
        }
    }
}
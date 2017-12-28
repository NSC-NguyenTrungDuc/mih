using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0004U01grdMasterArgs : IContractArgs
    {
        protected bool Equals(IFS0004U01grdMasterArgs other)
        {
            return string.Equals(_nuGubun, other._nuGubun) && string.Equals(_nuYmd, other._nuYmd);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0004U01grdMasterArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_nuGubun != null ? _nuGubun.GetHashCode() : 0)*397) ^ (_nuYmd != null ? _nuYmd.GetHashCode() : 0);
            }
        }

        private String _nuGubun;
        private String _nuYmd;

        public String NuGubun
        {
            get { return this._nuGubun; }
            set { this._nuGubun = value; }
        }

        public String NuYmd
        {
            get { return this._nuYmd; }
            set { this._nuYmd = value; }
        }

        public IFS0004U01grdMasterArgs() { }

        public IFS0004U01grdMasterArgs(String nuGubun, String nuYmd)
        {
            this._nuGubun = nuGubun;
            this._nuYmd = nuYmd;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0004U01grdMasterRequest();
        }
    }
}
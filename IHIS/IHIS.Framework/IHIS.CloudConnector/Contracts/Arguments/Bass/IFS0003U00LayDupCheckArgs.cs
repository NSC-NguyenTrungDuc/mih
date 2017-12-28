using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0003U00LayDupCheckArgs : IContractArgs
    {
        protected bool Equals(IFS0003U00LayDupCheckArgs other)
        {
            return string.Equals(_mapGubun, other._mapGubun) && string.Equals(_mapGubunYmd, other._mapGubunYmd);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0003U00LayDupCheckArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_mapGubun != null ? _mapGubun.GetHashCode() : 0)*397) ^ (_mapGubunYmd != null ? _mapGubunYmd.GetHashCode() : 0);
            }
        }

        private String _mapGubun;
        private String _mapGubunYmd;

        public String MapGubun
        {
            get { return this._mapGubun; }
            set { this._mapGubun = value; }
        }

        public String MapGubunYmd
        {
            get { return this._mapGubunYmd; }
            set { this._mapGubunYmd = value; }
        }

        public IFS0003U00LayDupCheckArgs() { }

        public IFS0003U00LayDupCheckArgs(String mapGubun, String mapGubunYmd)
        {
            this._mapGubun = mapGubun;
            this._mapGubunYmd = mapGubunYmd;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0003U00LayDupCheckRequest();
        }
    }
}
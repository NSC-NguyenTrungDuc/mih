using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0003U01GrdIFS0003GridColumnChangedArgs : IContractArgs
    {
        protected bool Equals(IFS0003U01GrdIFS0003GridColumnChangedArgs other)
        {
            return string.Equals(_colName, other._colName) && string.Equals(_mapGubun, other._mapGubun) && string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0003U01GrdIFS0003GridColumnChangedArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_colName != null ? _colName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_mapGubun != null ? _mapGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_code != null ? _code.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _colName;
        private String _mapGubun;
        private String _code;

        public String ColName
        {
            get { return this._colName; }
            set { this._colName = value; }
        }

        public String MapGubun
        {
            get { return this._mapGubun; }
            set { this._mapGubun = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public IFS0003U01GrdIFS0003GridColumnChangedArgs() { }

        public IFS0003U01GrdIFS0003GridColumnChangedArgs(String colName, String mapGubun, String code)
        {
            this._colName = colName;
            this._mapGubun = mapGubun;
            this._code = code;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0003U01GrdIFS0003GridColumnChangedRequest();
        }
    }
}
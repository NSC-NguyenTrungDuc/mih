using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0003U00GridColumnChangeArgs : IContractArgs
    {
        protected bool Equals(IFS0003U00GridColumnChangeArgs other)
        {
            return string.Equals(_code, other._code) && string.Equals(_mapGubun, other._mapGubun) && string.Equals(_colName, other._colName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0003U00GridColumnChangeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_code != null ? _code.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_mapGubun != null ? _mapGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_colName != null ? _colName.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _code;
        private String _mapGubun;
        private String _colName;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String MapGubun
        {
            get { return this._mapGubun; }
            set { this._mapGubun = value; }
        }

        public String ColName
        {
            get { return this._colName; }
            set { this._colName = value; }
        }

        public IFS0003U00GridColumnChangeArgs() { }

        public IFS0003U00GridColumnChangeArgs(String code, String mapGubun, String colName)
        {
            this._code = code;
            this._mapGubun = mapGubun;
            this._colName = colName;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0003U00GridColumnChangeRequest();
        }
    }
}
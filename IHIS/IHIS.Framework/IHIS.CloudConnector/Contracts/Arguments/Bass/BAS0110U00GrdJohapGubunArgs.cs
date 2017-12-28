using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0110U00GrdJohapGubunArgs : IContractArgs
    {
        protected bool Equals(BAS0110U00GrdJohapGubunArgs other)
        {
            return string.Equals(_code, other._code) && string.Equals(_zipCode1, other._zipCode1) && string.Equals(_zipCode2, other._zipCode2) && string.Equals(_colName, other._colName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0110U00GrdJohapGubunArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_code != null ? _code.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_zipCode1 != null ? _zipCode1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_zipCode2 != null ? _zipCode2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_colName != null ? _colName.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _code;
        private String _zipCode1;
        private String _zipCode2;
        private String _colName;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String ZipCode1
        {
            get { return this._zipCode1; }
            set { this._zipCode1 = value; }
        }

        public String ZipCode2
        {
            get { return this._zipCode2; }
            set { this._zipCode2 = value; }
        }

        public String ColName
        {
            get { return this._colName; }
            set { this._colName = value; }
        }

        public BAS0110U00GrdJohapGubunArgs() { }

        public BAS0110U00GrdJohapGubunArgs(String code, String zipCode1, String zipCode2, String colName)
        {
            this._code = code;
            this._zipCode1 = zipCode1;
            this._zipCode2 = zipCode2;
            this._colName = colName;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0110U00GrdJohapGubunRequest();
        }
    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0311U00BilLoadArgs : IContractArgs
    {
        protected bool Equals(BAS0311U00BilLoadArgs other)
        {
            return string.Equals(_fBunCode, other._fBunCode) && string.Equals(_fGubunSuga, other._fGubunSuga) && string.Equals(_fSgCode, other._fSgCode) && string.Equals(_fOrderDate, other._fOrderDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0311U00BilLoadArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_fBunCode != null ? _fBunCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fGubunSuga != null ? _fGubunSuga.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fSgCode != null ? _fSgCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fOrderDate != null ? _fOrderDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _fGubunSuga;
        private String _fBunCode;
        private String _fSgCode;
        private String _fOrderDate;

        public String FGubunSuga
        {
            get { return this._fGubunSuga; }
            set { this._fGubunSuga = value; }
        }

        public String FBunCode
        {
            get { return this._fBunCode; }
            set { this._fBunCode = value; }
        }

        public String FSgCode
        {
            get { return this._fSgCode; }
            set { this._fSgCode = value; }
        }

        public String FOrderDate
        {
            get { return this._fOrderDate; }
            set { this._fOrderDate = value; }
        }

        public BAS0311U00BilLoadArgs() { }

        public BAS0311U00BilLoadArgs(String fGubunSuga, String fBunCode, String fSgCode, String fOrderDate)
        {
            this._fGubunSuga = fGubunSuga;
            this._fBunCode = fBunCode;
            this._fSgCode = fSgCode;
            this._fOrderDate = fOrderDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0311U00BilLoadRequest();
        }
    }
}
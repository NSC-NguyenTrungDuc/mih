using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class BAS0001U00ControlDataValidatingArgs : IContractArgs
    {
        protected bool Equals(BAS0001U00ControlDataValidatingArgs other)
        {
            return string.Equals(_zipCode1, other._zipCode1) && string.Equals(_zipCode2, other._zipCode2) && string.Equals(_ctlName, other._ctlName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0001U00ControlDataValidatingArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_zipCode1 != null ? _zipCode1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_zipCode2 != null ? _zipCode2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ctlName != null ? _ctlName.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _zipCode1;
        private String _zipCode2;
        private String _ctlName;

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

        public String CtlName
        {
            get { return this._ctlName; }
            set { this._ctlName = value; }
        }

        public BAS0001U00ControlDataValidatingArgs() { }

        public BAS0001U00ControlDataValidatingArgs(String zipCode1, String zipCode2, String ctlName)
        {
            this._zipCode1 = zipCode1;
            this._zipCode2 = zipCode2;
            this._ctlName = ctlName;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BAS0001U00ControlDataValidatingRequest();
        }
    }
}
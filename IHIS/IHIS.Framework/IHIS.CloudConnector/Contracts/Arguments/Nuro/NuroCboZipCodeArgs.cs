using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroCboZipCodeArgs : IContractArgs
    {
        protected bool Equals(NuroCboZipCodeArgs other)
        {
            return string.Equals(_zipCode1, other._zipCode1) && string.Equals(_zipCode2, other._zipCode2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroCboZipCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_zipCode1 != null ? _zipCode1.GetHashCode() : 0)*397) ^ (_zipCode2 != null ? _zipCode2.GetHashCode() : 0);
            }
        }

        public string _zipCode1;
        public string _zipCode2;

        public NuroCboZipCodeArgs()
        {
        }

        public NuroCboZipCodeArgs(string zipCode1, string zipCode2)
        {
            _zipCode1 = zipCode1;
            _zipCode2 = zipCode2;
        }

        public string ZipCode1
        {
            get { return _zipCode1; }
            set { _zipCode1 = value; }
        }

        public string ZipCode2
        {
            get { return _zipCode2; }
            set { _zipCode2 = value; }
        }

        public IExtensible GetRequestInstance()
        {
            return  new NuroCboZipCodeRequest();
        }
    }
}

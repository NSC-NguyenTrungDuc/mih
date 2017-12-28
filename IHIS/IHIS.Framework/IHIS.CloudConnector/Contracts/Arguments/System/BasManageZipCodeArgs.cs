using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Arguments;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class BasManageZipCodeArgs : IContractArgs
    {
    protected bool Equals(BasManageZipCodeArgs other)
    {
        return string.Equals(_condition, other._condition) && string.Equals(_address, other._address) && string.Equals(_zip1, other._zip1) && string.Equals(_zip2, other._zip2);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((BasManageZipCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_condition != null ? _condition.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_address != null ? _address.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_zip1 != null ? _zip1.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_zip2 != null ? _zip2.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _condition;
        private String _address;
        private String _zip1;
        private String _zip2;

        public String Condition
        {
            get { return this._condition; }
            set { this._condition = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Zip1
        {
            get { return this._zip1; }
            set { this._zip1 = value; }
        }

        public String Zip2
        {
            get { return this._zip2; }
            set { this._zip2 = value; }
        }

        public BasManageZipCodeArgs()
        {
        }

        public BasManageZipCodeArgs(String condition, String address, String zip1, String zip2)
        {
            this._condition = condition;
            this._address = address;
            this._zip1 = zip1;
            this._zip2 = zip2;
        }

        public IExtensible GetRequestInstance()
        {
            return new BasManageZipCodeRequest();
        }
    }
}
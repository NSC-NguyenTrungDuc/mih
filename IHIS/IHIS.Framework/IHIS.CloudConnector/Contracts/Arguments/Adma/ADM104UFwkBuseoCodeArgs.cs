using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM104UFwkBuseoCodeArgs : IContractArgs
    {
        protected bool Equals(ADM104UFwkBuseoCodeArgs other)
        {
            return string.Equals(_buseoCode, other._buseoCode) && string.Equals(_gwaName, other._gwaName) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM104UFwkBuseoCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_buseoCode != null ? _buseoCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwaName != null ? _gwaName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _buseoCode;
        private String _gwaName;
        private String _hospCode;

        public String BuseoCode
        {
            get { return this._buseoCode; }
            set { this._buseoCode = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public ADM104UFwkBuseoCodeArgs() { }

        public ADM104UFwkBuseoCodeArgs(String buseoCode, String gwaName, String hospCode)
        {
            this._buseoCode = buseoCode;
            this._gwaName = gwaName;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM104UFwkBuseoCodeRequest();
        }
    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class OUT0101U02GetPatientCodeArgs : IContractArgs
    {
        protected bool Equals(OUT0101U02GetPatientCodeArgs other)
        {
            return string.Equals(_getPatientCodeYn, other._getPatientCodeYn);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OUT0101U02GetPatientCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_getPatientCodeYn != null ? _getPatientCodeYn.GetHashCode() : 0);
        }

        private String _getPatientCodeYn;

        public String GetPatientCodeYn
        {
            get { return this._getPatientCodeYn; }
            set { this._getPatientCodeYn = value; }
        }

        public OUT0101U02GetPatientCodeArgs() { }

        public OUT0101U02GetPatientCodeArgs(String getPatientCodeYn)
        {
            this._getPatientCodeYn = getPatientCodeYn;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUT0101U02GetPatientCodeRequest();
        }
    }
}
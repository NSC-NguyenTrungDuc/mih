using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OcsaOCS0208U00LoadBogyongNameFromOcsArgs : IContractArgs
    {
    protected bool Equals(OcsaOCS0208U00LoadBogyongNameFromOcsArgs other)
    {
        return string.Equals(_code, other._code) && string.Equals(_doctor, other._doctor) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0208U00LoadBogyongNameFromOcsArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_code != null ? _code.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _code;
        private String _doctor;
        private String _hospCode;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OcsaOCS0208U00LoadBogyongNameFromOcsArgs() { }

        public OcsaOCS0208U00LoadBogyongNameFromOcsArgs(String code, String doctor, String hospCode)
        {
            this._code = code;
            this._doctor = doctor;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OcsaOCS0208U00LoadBogyongNameFromOcsRequest();
        }
    }
}
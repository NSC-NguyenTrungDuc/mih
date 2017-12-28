using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OcsaOCS0208U00CommonDataArgs : IContractArgs
    {
    protected bool Equals(OcsaOCS0208U00CommonDataArgs other)
    {
        return string.Equals(_doctor, other._doctor) && string.Equals(_bunryu1, other._bunryu1) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsaOCS0208U00CommonDataArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunryu1 != null ? _bunryu1.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _doctor;
        private String _bunryu1;
        private String _hospCode;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Bunryu1
        {
            get { return this._bunryu1; }
            set { this._bunryu1 = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OcsaOCS0208U00CommonDataArgs() { }

        public OcsaOCS0208U00CommonDataArgs(String doctor, String bunryu1, String hospCode)
        {
            this._doctor = doctor;
            this._bunryu1 = bunryu1;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OcsaOCS0208U00CommonDataRequest();
        }
    }
}
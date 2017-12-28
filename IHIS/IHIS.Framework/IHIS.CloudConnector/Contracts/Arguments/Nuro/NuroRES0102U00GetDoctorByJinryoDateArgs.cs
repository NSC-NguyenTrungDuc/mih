using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroRES0102U00GetDoctorByJinryoDateArgs : IContractArgs
    {
        protected bool Equals(NuroRES0102U00GetDoctorByJinryoDateArgs other)
        {
            return string.Equals(_doctor, other._doctor) && string.Equals(_jinryoPreDate, other._jinryoPreDate) && _byResPm.Equals(other._byResPm) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES0102U00GetDoctorByJinryoDateArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jinryoPreDate != null ? _jinryoPreDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _byResPm.GetHashCode();
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _doctor;
        private String _jinryoPreDate;
        private Boolean _byResPm;
        private String _hospCode;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String JinryoPreDate
        {
            get { return this._jinryoPreDate; }
            set { this._jinryoPreDate = value; }
        }

        public Boolean ByResPm
        {
            get { return this._byResPm; }
            set { this._byResPm = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public NuroRES0102U00GetDoctorByJinryoDateArgs() { }

        public NuroRES0102U00GetDoctorByJinryoDateArgs(String doctor, String jinryoPreDate, Boolean byResPm, String hospCode)
        {
            this._doctor = doctor;
            this._jinryoPreDate = jinryoPreDate;
            this._byResPm = byResPm;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroRES0102U00GetDoctorByJinryoDateRequest();
        }
    }
}
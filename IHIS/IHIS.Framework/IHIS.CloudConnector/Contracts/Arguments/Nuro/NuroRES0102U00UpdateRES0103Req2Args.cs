using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroRES0102U00UpdateRES0103Req2Args : IContractArgs
    {
        protected bool Equals(NuroRES0102U00UpdateRES0103Req2Args other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_resAmStartHhmm, other._resAmStartHhmm) && string.Equals(_resAmEndHhmm, other._resAmEndHhmm) && string.Equals(_resPmStartHhmm, other._resPmStartHhmm) && string.Equals(_resPmEndHhmm, other._resPmEndHhmm) && string.Equals(_remark, other._remark) && string.Equals(_hospCode, other._hospCode) && string.Equals(_doctor, other._doctor) && string.Equals(_jinryoPreDate, other._jinryoPreDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES0102U00UpdateRES0103Req2Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmStartHhmm != null ? _resAmStartHhmm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmEndHhmm != null ? _resAmEndHhmm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmStartHhmm != null ? _resPmStartHhmm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmEndHhmm != null ? _resPmEndHhmm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_remark != null ? _remark.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jinryoPreDate != null ? _jinryoPreDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _resAmStartHhmm;
        private String _resAmEndHhmm;
        private String _resPmStartHhmm;
        private String _resPmEndHhmm;
        private String _remark;
        private String _hospCode;
        private String _doctor;
        private String _jinryoPreDate;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String ResAmStartHhmm
        {
            get { return this._resAmStartHhmm; }
            set { this._resAmStartHhmm = value; }
        }

        public String ResAmEndHhmm
        {
            get { return this._resAmEndHhmm; }
            set { this._resAmEndHhmm = value; }
        }

        public String ResPmStartHhmm
        {
            get { return this._resPmStartHhmm; }
            set { this._resPmStartHhmm = value; }
        }

        public String ResPmEndHhmm
        {
            get { return this._resPmEndHhmm; }
            set { this._resPmEndHhmm = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

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

        public NuroRES0102U00UpdateRES0103Req2Args() { }

        public NuroRES0102U00UpdateRES0103Req2Args(String userId, String resAmStartHhmm, String resAmEndHhmm, String resPmStartHhmm, String resPmEndHhmm, String remark, String hospCode, String doctor, String jinryoPreDate)
        {
            this._userId = userId;
            this._resAmStartHhmm = resAmStartHhmm;
            this._resAmEndHhmm = resAmEndHhmm;
            this._resPmStartHhmm = resPmStartHhmm;
            this._resPmEndHhmm = resPmEndHhmm;
            this._remark = remark;
            this._hospCode = hospCode;
            this._doctor = doctor;
            this._jinryoPreDate = jinryoPreDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroRES0102U00UpdateRES0103Req2Request();
        }
    }
}
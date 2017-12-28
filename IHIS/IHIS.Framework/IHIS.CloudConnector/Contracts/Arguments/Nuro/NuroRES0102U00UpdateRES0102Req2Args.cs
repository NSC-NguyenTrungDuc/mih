using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroRES0102U00UpdateRES0102Req2Args : IContractArgs
    {
        protected bool Equals(NuroRES0102U00UpdateRES0102Req2Args other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_avgTime, other._avgTime) && string.Equals(_jinryoBreakYn, other._jinryoBreakYn) && string.Equals(_amStartHhmm1, other._amStartHhmm1) && string.Equals(_amStartHhmm2, other._amStartHhmm2) && string.Equals(_amStartHhmm3, other._amStartHhmm3) && string.Equals(_amStartHhmm4, other._amStartHhmm4) && string.Equals(_amStartHhmm5, other._amStartHhmm5) && string.Equals(_amStartHhmm6, other._amStartHhmm6) && string.Equals(_amStartHhmm7, other._amStartHhmm7) && string.Equals(_amEndHhmm1, other._amEndHhmm1) && string.Equals(_amEndHhmm2, other._amEndHhmm2) && string.Equals(_amEndHhmm3, other._amEndHhmm3) && string.Equals(_amEndHhmm4, other._amEndHhmm4) && string.Equals(_amEndHhmm5, other._amEndHhmm5) && string.Equals(_amEndHhmm6, other._amEndHhmm6) && string.Equals(_amEndHhmm7, other._amEndHhmm7) && string.Equals(_pmStartHhmm1, other._pmStartHhmm1) && string.Equals(_pmStartHhmm2, other._pmStartHhmm2) && string.Equals(_pmStartHhmm3, other._pmStartHhmm3) && string.Equals(_pmStartHhmm4, other._pmStartHhmm4) && string.Equals(_pmStartHhmm5, other._pmStartHhmm5) && string.Equals(_pmStartHhmm6, other._pmStartHhmm6) && string.Equals(_pmStartHhmm7, other._pmStartHhmm7) && string.Equals(_pmEndHhmm1, other._pmEndHhmm1) && string.Equals(_pmEndHhmm2, other._pmEndHhmm2) && string.Equals(_pmEndHhmm3, other._pmEndHhmm3) && string.Equals(_pmEndHhmm4, other._pmEndHhmm4) && string.Equals(_pmEndHhmm5, other._pmEndHhmm5) && string.Equals(_pmEndHhmm6, other._pmEndHhmm6) && string.Equals(_pmEndHhmm7, other._pmEndHhmm7) && string.Equals(_amGwaRoom1, other._amGwaRoom1) && string.Equals(_amGwaRoom2, other._amGwaRoom2) && string.Equals(_amGwaRoom3, other._amGwaRoom3) && string.Equals(_amGwaRoom4, other._amGwaRoom4) && string.Equals(_amGwaRoom5, other._amGwaRoom5) && string.Equals(_amGwaRoom6, other._amGwaRoom6) && string.Equals(_amGwaRoom7, other._amGwaRoom7) && string.Equals(_pmGwaRoom1, other._pmGwaRoom1) && string.Equals(_pmGwaRoom2, other._pmGwaRoom2) && string.Equals(_pmGwaRoom3, other._pmGwaRoom3) && string.Equals(_pmGwaRoom4, other._pmGwaRoom4) && string.Equals(_pmGwaRoom5, other._pmGwaRoom5) && string.Equals(_pmGwaRoom6, other._pmGwaRoom6) && string.Equals(_pmGwaRoom7, other._pmGwaRoom7) && string.Equals(_resAmStartHhmm1, other._resAmStartHhmm1) && string.Equals(_resAmStartHhmm2, other._resAmStartHhmm2) && string.Equals(_resAmStartHhmm3, other._resAmStartHhmm3) && string.Equals(_resAmStartHhmm4, other._resAmStartHhmm4) && string.Equals(_resAmStartHhmm5, other._resAmStartHhmm5) && string.Equals(_resAmStartHhmm6, other._resAmStartHhmm6) && string.Equals(_resAmStartHhmm7, other._resAmStartHhmm7) && string.Equals(_resAmEndHhmm1, other._resAmEndHhmm1) && string.Equals(_resAmEndHhmm2, other._resAmEndHhmm2) && string.Equals(_resAmEndHhmm3, other._resAmEndHhmm3) && string.Equals(_resAmEndHhmm4, other._resAmEndHhmm4) && string.Equals(_resAmEndHhmm5, other._resAmEndHhmm5) && string.Equals(_resAmEndHhmm6, other._resAmEndHhmm6) && string.Equals(_resAmEndHhmm7, other._resAmEndHhmm7) && string.Equals(_resPmStartHhmm1, other._resPmStartHhmm1) && string.Equals(_resPmStartHhmm2, other._resPmStartHhmm2) && string.Equals(_resPmStartHhmm3, other._resPmStartHhmm3) && string.Equals(_resPmStartHhmm4, other._resPmStartHhmm4) && string.Equals(_resPmStartHhmm5, other._resPmStartHhmm5) && string.Equals(_resPmStartHhmm6, other._resPmStartHhmm6) && string.Equals(_resPmStartHhmm7, other._resPmStartHhmm7) && string.Equals(_resPmEndHhmm1, other._resPmEndHhmm1) && string.Equals(_resPmEndHhmm2, other._resPmEndHhmm2) && string.Equals(_resPmEndHhmm3, other._resPmEndHhmm3) && string.Equals(_resPmEndHhmm4, other._resPmEndHhmm4) && string.Equals(_resPmEndHhmm5, other._resPmEndHhmm5) && string.Equals(_resPmEndHhmm6, other._resPmEndHhmm6) && string.Equals(_resPmEndHhmm7, other._resPmEndHhmm7) && string.Equals(_docResLimit, other._docResLimit) && string.Equals(_etcResLimit, other._etcResLimit) && string.Equals(_endDate, other._endDate) && string.Equals(_doctor, other._doctor) && string.Equals(_startDate, other._startDate) && string.Equals(_hospCode, other._hospCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES0102U00UpdateRES0102Req2Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_avgTime != null ? _avgTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jinryoBreakYn != null ? _jinryoBreakYn.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amStartHhmm1 != null ? _amStartHhmm1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amStartHhmm2 != null ? _amStartHhmm2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amStartHhmm3 != null ? _amStartHhmm3.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amStartHhmm4 != null ? _amStartHhmm4.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amStartHhmm5 != null ? _amStartHhmm5.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amStartHhmm6 != null ? _amStartHhmm6.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amStartHhmm7 != null ? _amStartHhmm7.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amEndHhmm1 != null ? _amEndHhmm1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amEndHhmm2 != null ? _amEndHhmm2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amEndHhmm3 != null ? _amEndHhmm3.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amEndHhmm4 != null ? _amEndHhmm4.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amEndHhmm5 != null ? _amEndHhmm5.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amEndHhmm6 != null ? _amEndHhmm6.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amEndHhmm7 != null ? _amEndHhmm7.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmStartHhmm1 != null ? _pmStartHhmm1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmStartHhmm2 != null ? _pmStartHhmm2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmStartHhmm3 != null ? _pmStartHhmm3.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmStartHhmm4 != null ? _pmStartHhmm4.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmStartHhmm5 != null ? _pmStartHhmm5.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmStartHhmm6 != null ? _pmStartHhmm6.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmStartHhmm7 != null ? _pmStartHhmm7.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmEndHhmm1 != null ? _pmEndHhmm1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmEndHhmm2 != null ? _pmEndHhmm2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmEndHhmm3 != null ? _pmEndHhmm3.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmEndHhmm4 != null ? _pmEndHhmm4.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmEndHhmm5 != null ? _pmEndHhmm5.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmEndHhmm6 != null ? _pmEndHhmm6.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmEndHhmm7 != null ? _pmEndHhmm7.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amGwaRoom1 != null ? _amGwaRoom1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amGwaRoom2 != null ? _amGwaRoom2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amGwaRoom3 != null ? _amGwaRoom3.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amGwaRoom4 != null ? _amGwaRoom4.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amGwaRoom5 != null ? _amGwaRoom5.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amGwaRoom6 != null ? _amGwaRoom6.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_amGwaRoom7 != null ? _amGwaRoom7.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmGwaRoom1 != null ? _pmGwaRoom1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmGwaRoom2 != null ? _pmGwaRoom2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmGwaRoom3 != null ? _pmGwaRoom3.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmGwaRoom4 != null ? _pmGwaRoom4.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmGwaRoom5 != null ? _pmGwaRoom5.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmGwaRoom6 != null ? _pmGwaRoom6.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pmGwaRoom7 != null ? _pmGwaRoom7.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmStartHhmm1 != null ? _resAmStartHhmm1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmStartHhmm2 != null ? _resAmStartHhmm2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmStartHhmm3 != null ? _resAmStartHhmm3.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmStartHhmm4 != null ? _resAmStartHhmm4.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmStartHhmm5 != null ? _resAmStartHhmm5.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmStartHhmm6 != null ? _resAmStartHhmm6.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmStartHhmm7 != null ? _resAmStartHhmm7.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmEndHhmm1 != null ? _resAmEndHhmm1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmEndHhmm2 != null ? _resAmEndHhmm2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmEndHhmm3 != null ? _resAmEndHhmm3.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmEndHhmm4 != null ? _resAmEndHhmm4.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmEndHhmm5 != null ? _resAmEndHhmm5.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmEndHhmm6 != null ? _resAmEndHhmm6.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resAmEndHhmm7 != null ? _resAmEndHhmm7.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmStartHhmm1 != null ? _resPmStartHhmm1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmStartHhmm2 != null ? _resPmStartHhmm2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmStartHhmm3 != null ? _resPmStartHhmm3.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmStartHhmm4 != null ? _resPmStartHhmm4.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmStartHhmm5 != null ? _resPmStartHhmm5.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmStartHhmm6 != null ? _resPmStartHhmm6.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmStartHhmm7 != null ? _resPmStartHhmm7.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmEndHhmm1 != null ? _resPmEndHhmm1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmEndHhmm2 != null ? _resPmEndHhmm2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmEndHhmm3 != null ? _resPmEndHhmm3.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmEndHhmm4 != null ? _resPmEndHhmm4.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmEndHhmm5 != null ? _resPmEndHhmm5.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmEndHhmm6 != null ? _resPmEndHhmm6.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resPmEndHhmm7 != null ? _resPmEndHhmm7.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_docResLimit != null ? _docResLimit.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_etcResLimit != null ? _etcResLimit.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_endDate != null ? _endDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _avgTime;
        private String _jinryoBreakYn;
        private String _amStartHhmm1;
        private String _amStartHhmm2;
        private String _amStartHhmm3;
        private String _amStartHhmm4;
        private String _amStartHhmm5;
        private String _amStartHhmm6;
        private String _amStartHhmm7;
        private String _amEndHhmm1;
        private String _amEndHhmm2;
        private String _amEndHhmm3;
        private String _amEndHhmm4;
        private String _amEndHhmm5;
        private String _amEndHhmm6;
        private String _amEndHhmm7;
        private String _pmStartHhmm1;
        private String _pmStartHhmm2;
        private String _pmStartHhmm3;
        private String _pmStartHhmm4;
        private String _pmStartHhmm5;
        private String _pmStartHhmm6;
        private String _pmStartHhmm7;
        private String _pmEndHhmm1;
        private String _pmEndHhmm2;
        private String _pmEndHhmm3;
        private String _pmEndHhmm4;
        private String _pmEndHhmm5;
        private String _pmEndHhmm6;
        private String _pmEndHhmm7;
        private String _amGwaRoom1;
        private String _amGwaRoom2;
        private String _amGwaRoom3;
        private String _amGwaRoom4;
        private String _amGwaRoom5;
        private String _amGwaRoom6;
        private String _amGwaRoom7;
        private String _pmGwaRoom1;
        private String _pmGwaRoom2;
        private String _pmGwaRoom3;
        private String _pmGwaRoom4;
        private String _pmGwaRoom5;
        private String _pmGwaRoom6;
        private String _pmGwaRoom7;
        private String _resAmStartHhmm1;
        private String _resAmStartHhmm2;
        private String _resAmStartHhmm3;
        private String _resAmStartHhmm4;
        private String _resAmStartHhmm5;
        private String _resAmStartHhmm6;
        private String _resAmStartHhmm7;
        private String _resAmEndHhmm1;
        private String _resAmEndHhmm2;
        private String _resAmEndHhmm3;
        private String _resAmEndHhmm4;
        private String _resAmEndHhmm5;
        private String _resAmEndHhmm6;
        private String _resAmEndHhmm7;
        private String _resPmStartHhmm1;
        private String _resPmStartHhmm2;
        private String _resPmStartHhmm3;
        private String _resPmStartHhmm4;
        private String _resPmStartHhmm5;
        private String _resPmStartHhmm6;
        private String _resPmStartHhmm7;
        private String _resPmEndHhmm1;
        private String _resPmEndHhmm2;
        private String _resPmEndHhmm3;
        private String _resPmEndHhmm4;
        private String _resPmEndHhmm5;
        private String _resPmEndHhmm6;
        private String _resPmEndHhmm7;
        private String _docResLimit;
        private String _etcResLimit;
        private String _endDate;
        private String _doctor;
        private String _startDate;
        private String _hospCode;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String AvgTime
        {
            get { return this._avgTime; }
            set { this._avgTime = value; }
        }

        public String JinryoBreakYn
        {
            get { return this._jinryoBreakYn; }
            set { this._jinryoBreakYn = value; }
        }

        public String AmStartHhmm1
        {
            get { return this._amStartHhmm1; }
            set { this._amStartHhmm1 = value; }
        }

        public String AmStartHhmm2
        {
            get { return this._amStartHhmm2; }
            set { this._amStartHhmm2 = value; }
        }

        public String AmStartHhmm3
        {
            get { return this._amStartHhmm3; }
            set { this._amStartHhmm3 = value; }
        }

        public String AmStartHhmm4
        {
            get { return this._amStartHhmm4; }
            set { this._amStartHhmm4 = value; }
        }

        public String AmStartHhmm5
        {
            get { return this._amStartHhmm5; }
            set { this._amStartHhmm5 = value; }
        }

        public String AmStartHhmm6
        {
            get { return this._amStartHhmm6; }
            set { this._amStartHhmm6 = value; }
        }

        public String AmStartHhmm7
        {
            get { return this._amStartHhmm7; }
            set { this._amStartHhmm7 = value; }
        }

        public String AmEndHhmm1
        {
            get { return this._amEndHhmm1; }
            set { this._amEndHhmm1 = value; }
        }

        public String AmEndHhmm2
        {
            get { return this._amEndHhmm2; }
            set { this._amEndHhmm2 = value; }
        }

        public String AmEndHhmm3
        {
            get { return this._amEndHhmm3; }
            set { this._amEndHhmm3 = value; }
        }

        public String AmEndHhmm4
        {
            get { return this._amEndHhmm4; }
            set { this._amEndHhmm4 = value; }
        }

        public String AmEndHhmm5
        {
            get { return this._amEndHhmm5; }
            set { this._amEndHhmm5 = value; }
        }

        public String AmEndHhmm6
        {
            get { return this._amEndHhmm6; }
            set { this._amEndHhmm6 = value; }
        }

        public String AmEndHhmm7
        {
            get { return this._amEndHhmm7; }
            set { this._amEndHhmm7 = value; }
        }

        public String PmStartHhmm1
        {
            get { return this._pmStartHhmm1; }
            set { this._pmStartHhmm1 = value; }
        }

        public String PmStartHhmm2
        {
            get { return this._pmStartHhmm2; }
            set { this._pmStartHhmm2 = value; }
        }

        public String PmStartHhmm3
        {
            get { return this._pmStartHhmm3; }
            set { this._pmStartHhmm3 = value; }
        }

        public String PmStartHhmm4
        {
            get { return this._pmStartHhmm4; }
            set { this._pmStartHhmm4 = value; }
        }

        public String PmStartHhmm5
        {
            get { return this._pmStartHhmm5; }
            set { this._pmStartHhmm5 = value; }
        }

        public String PmStartHhmm6
        {
            get { return this._pmStartHhmm6; }
            set { this._pmStartHhmm6 = value; }
        }

        public String PmStartHhmm7
        {
            get { return this._pmStartHhmm7; }
            set { this._pmStartHhmm7 = value; }
        }

        public String PmEndHhmm1
        {
            get { return this._pmEndHhmm1; }
            set { this._pmEndHhmm1 = value; }
        }

        public String PmEndHhmm2
        {
            get { return this._pmEndHhmm2; }
            set { this._pmEndHhmm2 = value; }
        }

        public String PmEndHhmm3
        {
            get { return this._pmEndHhmm3; }
            set { this._pmEndHhmm3 = value; }
        }

        public String PmEndHhmm4
        {
            get { return this._pmEndHhmm4; }
            set { this._pmEndHhmm4 = value; }
        }

        public String PmEndHhmm5
        {
            get { return this._pmEndHhmm5; }
            set { this._pmEndHhmm5 = value; }
        }

        public String PmEndHhmm6
        {
            get { return this._pmEndHhmm6; }
            set { this._pmEndHhmm6 = value; }
        }

        public String PmEndHhmm7
        {
            get { return this._pmEndHhmm7; }
            set { this._pmEndHhmm7 = value; }
        }

        public String AmGwaRoom1
        {
            get { return this._amGwaRoom1; }
            set { this._amGwaRoom1 = value; }
        }

        public String AmGwaRoom2
        {
            get { return this._amGwaRoom2; }
            set { this._amGwaRoom2 = value; }
        }

        public String AmGwaRoom3
        {
            get { return this._amGwaRoom3; }
            set { this._amGwaRoom3 = value; }
        }

        public String AmGwaRoom4
        {
            get { return this._amGwaRoom4; }
            set { this._amGwaRoom4 = value; }
        }

        public String AmGwaRoom5
        {
            get { return this._amGwaRoom5; }
            set { this._amGwaRoom5 = value; }
        }

        public String AmGwaRoom6
        {
            get { return this._amGwaRoom6; }
            set { this._amGwaRoom6 = value; }
        }

        public String AmGwaRoom7
        {
            get { return this._amGwaRoom7; }
            set { this._amGwaRoom7 = value; }
        }

        public String PmGwaRoom1
        {
            get { return this._pmGwaRoom1; }
            set { this._pmGwaRoom1 = value; }
        }

        public String PmGwaRoom2
        {
            get { return this._pmGwaRoom2; }
            set { this._pmGwaRoom2 = value; }
        }

        public String PmGwaRoom3
        {
            get { return this._pmGwaRoom3; }
            set { this._pmGwaRoom3 = value; }
        }

        public String PmGwaRoom4
        {
            get { return this._pmGwaRoom4; }
            set { this._pmGwaRoom4 = value; }
        }

        public String PmGwaRoom5
        {
            get { return this._pmGwaRoom5; }
            set { this._pmGwaRoom5 = value; }
        }

        public String PmGwaRoom6
        {
            get { return this._pmGwaRoom6; }
            set { this._pmGwaRoom6 = value; }
        }

        public String PmGwaRoom7
        {
            get { return this._pmGwaRoom7; }
            set { this._pmGwaRoom7 = value; }
        }

        public String ResAmStartHhmm1
        {
            get { return this._resAmStartHhmm1; }
            set { this._resAmStartHhmm1 = value; }
        }

        public String ResAmStartHhmm2
        {
            get { return this._resAmStartHhmm2; }
            set { this._resAmStartHhmm2 = value; }
        }

        public String ResAmStartHhmm3
        {
            get { return this._resAmStartHhmm3; }
            set { this._resAmStartHhmm3 = value; }
        }

        public String ResAmStartHhmm4
        {
            get { return this._resAmStartHhmm4; }
            set { this._resAmStartHhmm4 = value; }
        }

        public String ResAmStartHhmm5
        {
            get { return this._resAmStartHhmm5; }
            set { this._resAmStartHhmm5 = value; }
        }

        public String ResAmStartHhmm6
        {
            get { return this._resAmStartHhmm6; }
            set { this._resAmStartHhmm6 = value; }
        }

        public String ResAmStartHhmm7
        {
            get { return this._resAmStartHhmm7; }
            set { this._resAmStartHhmm7 = value; }
        }

        public String ResAmEndHhmm1
        {
            get { return this._resAmEndHhmm1; }
            set { this._resAmEndHhmm1 = value; }
        }

        public String ResAmEndHhmm2
        {
            get { return this._resAmEndHhmm2; }
            set { this._resAmEndHhmm2 = value; }
        }

        public String ResAmEndHhmm3
        {
            get { return this._resAmEndHhmm3; }
            set { this._resAmEndHhmm3 = value; }
        }

        public String ResAmEndHhmm4
        {
            get { return this._resAmEndHhmm4; }
            set { this._resAmEndHhmm4 = value; }
        }

        public String ResAmEndHhmm5
        {
            get { return this._resAmEndHhmm5; }
            set { this._resAmEndHhmm5 = value; }
        }

        public String ResAmEndHhmm6
        {
            get { return this._resAmEndHhmm6; }
            set { this._resAmEndHhmm6 = value; }
        }

        public String ResAmEndHhmm7
        {
            get { return this._resAmEndHhmm7; }
            set { this._resAmEndHhmm7 = value; }
        }

        public String ResPmStartHhmm1
        {
            get { return this._resPmStartHhmm1; }
            set { this._resPmStartHhmm1 = value; }
        }

        public String ResPmStartHhmm2
        {
            get { return this._resPmStartHhmm2; }
            set { this._resPmStartHhmm2 = value; }
        }

        public String ResPmStartHhmm3
        {
            get { return this._resPmStartHhmm3; }
            set { this._resPmStartHhmm3 = value; }
        }

        public String ResPmStartHhmm4
        {
            get { return this._resPmStartHhmm4; }
            set { this._resPmStartHhmm4 = value; }
        }

        public String ResPmStartHhmm5
        {
            get { return this._resPmStartHhmm5; }
            set { this._resPmStartHhmm5 = value; }
        }

        public String ResPmStartHhmm6
        {
            get { return this._resPmStartHhmm6; }
            set { this._resPmStartHhmm6 = value; }
        }

        public String ResPmStartHhmm7
        {
            get { return this._resPmStartHhmm7; }
            set { this._resPmStartHhmm7 = value; }
        }

        public String ResPmEndHhmm1
        {
            get { return this._resPmEndHhmm1; }
            set { this._resPmEndHhmm1 = value; }
        }

        public String ResPmEndHhmm2
        {
            get { return this._resPmEndHhmm2; }
            set { this._resPmEndHhmm2 = value; }
        }

        public String ResPmEndHhmm3
        {
            get { return this._resPmEndHhmm3; }
            set { this._resPmEndHhmm3 = value; }
        }

        public String ResPmEndHhmm4
        {
            get { return this._resPmEndHhmm4; }
            set { this._resPmEndHhmm4 = value; }
        }

        public String ResPmEndHhmm5
        {
            get { return this._resPmEndHhmm5; }
            set { this._resPmEndHhmm5 = value; }
        }

        public String ResPmEndHhmm6
        {
            get { return this._resPmEndHhmm6; }
            set { this._resPmEndHhmm6 = value; }
        }

        public String ResPmEndHhmm7
        {
            get { return this._resPmEndHhmm7; }
            set { this._resPmEndHhmm7 = value; }
        }

        public String DocResLimit
        {
            get { return this._docResLimit; }
            set { this._docResLimit = value; }
        }

        public String EtcResLimit
        {
            get { return this._etcResLimit; }
            set { this._etcResLimit = value; }
        }

        public String EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public NuroRES0102U00UpdateRES0102Req2Args() { }

        public NuroRES0102U00UpdateRES0102Req2Args(String userId, String avgTime, String jinryoBreakYn, String amStartHhmm1, String amStartHhmm2, String amStartHhmm3, String amStartHhmm4, String amStartHhmm5, String amStartHhmm6, String amStartHhmm7, String amEndHhmm1, String amEndHhmm2, String amEndHhmm3, String amEndHhmm4, String amEndHhmm5, String amEndHhmm6, String amEndHhmm7, String pmStartHhmm1, String pmStartHhmm2, String pmStartHhmm3, String pmStartHhmm4, String pmStartHhmm5, String pmStartHhmm6, String pmStartHhmm7, String pmEndHhmm1, String pmEndHhmm2, String pmEndHhmm3, String pmEndHhmm4, String pmEndHhmm5, String pmEndHhmm6, String pmEndHhmm7, String amGwaRoom1, String amGwaRoom2, String amGwaRoom3, String amGwaRoom4, String amGwaRoom5, String amGwaRoom6, String amGwaRoom7, String pmGwaRoom1, String pmGwaRoom2, String pmGwaRoom3, String pmGwaRoom4, String pmGwaRoom5, String pmGwaRoom6, String pmGwaRoom7, String resAmStartHhmm1, String resAmStartHhmm2, String resAmStartHhmm3, String resAmStartHhmm4, String resAmStartHhmm5, String resAmStartHhmm6, String resAmStartHhmm7, String resAmEndHhmm1, String resAmEndHhmm2, String resAmEndHhmm3, String resAmEndHhmm4, String resAmEndHhmm5, String resAmEndHhmm6, String resAmEndHhmm7, String resPmStartHhmm1, String resPmStartHhmm2, String resPmStartHhmm3, String resPmStartHhmm4, String resPmStartHhmm5, String resPmStartHhmm6, String resPmStartHhmm7, String resPmEndHhmm1, String resPmEndHhmm2, String resPmEndHhmm3, String resPmEndHhmm4, String resPmEndHhmm5, String resPmEndHhmm6, String resPmEndHhmm7, String docResLimit, String etcResLimit, String endDate, String doctor, String startDate, String hospCode)
        {
            this._userId = userId;
            this._avgTime = avgTime;
            this._jinryoBreakYn = jinryoBreakYn;
            this._amStartHhmm1 = amStartHhmm1;
            this._amStartHhmm2 = amStartHhmm2;
            this._amStartHhmm3 = amStartHhmm3;
            this._amStartHhmm4 = amStartHhmm4;
            this._amStartHhmm5 = amStartHhmm5;
            this._amStartHhmm6 = amStartHhmm6;
            this._amStartHhmm7 = amStartHhmm7;
            this._amEndHhmm1 = amEndHhmm1;
            this._amEndHhmm2 = amEndHhmm2;
            this._amEndHhmm3 = amEndHhmm3;
            this._amEndHhmm4 = amEndHhmm4;
            this._amEndHhmm5 = amEndHhmm5;
            this._amEndHhmm6 = amEndHhmm6;
            this._amEndHhmm7 = amEndHhmm7;
            this._pmStartHhmm1 = pmStartHhmm1;
            this._pmStartHhmm2 = pmStartHhmm2;
            this._pmStartHhmm3 = pmStartHhmm3;
            this._pmStartHhmm4 = pmStartHhmm4;
            this._pmStartHhmm5 = pmStartHhmm5;
            this._pmStartHhmm6 = pmStartHhmm6;
            this._pmStartHhmm7 = pmStartHhmm7;
            this._pmEndHhmm1 = pmEndHhmm1;
            this._pmEndHhmm2 = pmEndHhmm2;
            this._pmEndHhmm3 = pmEndHhmm3;
            this._pmEndHhmm4 = pmEndHhmm4;
            this._pmEndHhmm5 = pmEndHhmm5;
            this._pmEndHhmm6 = pmEndHhmm6;
            this._pmEndHhmm7 = pmEndHhmm7;
            this._amGwaRoom1 = amGwaRoom1;
            this._amGwaRoom2 = amGwaRoom2;
            this._amGwaRoom3 = amGwaRoom3;
            this._amGwaRoom4 = amGwaRoom4;
            this._amGwaRoom5 = amGwaRoom5;
            this._amGwaRoom6 = amGwaRoom6;
            this._amGwaRoom7 = amGwaRoom7;
            this._pmGwaRoom1 = pmGwaRoom1;
            this._pmGwaRoom2 = pmGwaRoom2;
            this._pmGwaRoom3 = pmGwaRoom3;
            this._pmGwaRoom4 = pmGwaRoom4;
            this._pmGwaRoom5 = pmGwaRoom5;
            this._pmGwaRoom6 = pmGwaRoom6;
            this._pmGwaRoom7 = pmGwaRoom7;
            this._resAmStartHhmm1 = resAmStartHhmm1;
            this._resAmStartHhmm2 = resAmStartHhmm2;
            this._resAmStartHhmm3 = resAmStartHhmm3;
            this._resAmStartHhmm4 = resAmStartHhmm4;
            this._resAmStartHhmm5 = resAmStartHhmm5;
            this._resAmStartHhmm6 = resAmStartHhmm6;
            this._resAmStartHhmm7 = resAmStartHhmm7;
            this._resAmEndHhmm1 = resAmEndHhmm1;
            this._resAmEndHhmm2 = resAmEndHhmm2;
            this._resAmEndHhmm3 = resAmEndHhmm3;
            this._resAmEndHhmm4 = resAmEndHhmm4;
            this._resAmEndHhmm5 = resAmEndHhmm5;
            this._resAmEndHhmm6 = resAmEndHhmm6;
            this._resAmEndHhmm7 = resAmEndHhmm7;
            this._resPmStartHhmm1 = resPmStartHhmm1;
            this._resPmStartHhmm2 = resPmStartHhmm2;
            this._resPmStartHhmm3 = resPmStartHhmm3;
            this._resPmStartHhmm4 = resPmStartHhmm4;
            this._resPmStartHhmm5 = resPmStartHhmm5;
            this._resPmStartHhmm6 = resPmStartHhmm6;
            this._resPmStartHhmm7 = resPmStartHhmm7;
            this._resPmEndHhmm1 = resPmEndHhmm1;
            this._resPmEndHhmm2 = resPmEndHhmm2;
            this._resPmEndHhmm3 = resPmEndHhmm3;
            this._resPmEndHhmm4 = resPmEndHhmm4;
            this._resPmEndHhmm5 = resPmEndHhmm5;
            this._resPmEndHhmm6 = resPmEndHhmm6;
            this._resPmEndHhmm7 = resPmEndHhmm7;
            this._docResLimit = docResLimit;
            this._etcResLimit = etcResLimit;
            this._endDate = endDate;
            this._doctor = doctor;
            this._startDate = startDate;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroRES0102U00UpdateRES0102Req2Request();
        }
    }
}
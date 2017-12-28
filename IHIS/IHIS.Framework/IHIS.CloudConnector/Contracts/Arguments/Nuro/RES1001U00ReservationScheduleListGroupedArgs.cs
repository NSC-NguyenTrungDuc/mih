using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class RES1001U00ReservationScheduleListGroupedArgs : IContractArgs
    {
        protected bool Equals(RES1001U00ReservationScheduleListGroupedArgs other)
        {
            return string.Equals(_examPreDate, other._examPreDate) && string.Equals(_departmentCode, other._departmentCode) && string.Equals(_doctorCode, other._doctorCode) && string.Equals(_fromTimeAm, other._fromTimeAm) && string.Equals(_fromTimePm, other._fromTimePm) && string.Equals(_toTimeAm, other._toTimeAm) && string.Equals(_avgTime, other._avgTime) && string.Equals(_toTimePm, other._toTimePm) && string.Equals(_hospCodeLink, other._hospCodeLink) && _tabIsAll.Equals(other._tabIsAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RES1001U00ReservationScheduleListGroupedArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_examPreDate != null ? _examPreDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_departmentCode != null ? _departmentCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctorCode != null ? _doctorCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromTimeAm != null ? _fromTimeAm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromTimePm != null ? _fromTimePm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toTimeAm != null ? _toTimeAm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_avgTime != null ? _avgTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toTimePm != null ? _toTimePm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _tabIsAll.GetHashCode();
                return hashCode;
            }
        }

        private String _examPreDate;
        private String _departmentCode;
        private String _doctorCode;
        private String _fromTimeAm;
        private String _toTimeAm;
        private String _fromTimePm;
        private String _toTimePm;
        private String _avgTime;
        private String _hospCodeLink;
        private Boolean _tabIsAll;

        public String ExamPreDate
        {
            get { return this._examPreDate; }
            set { this._examPreDate = value; }
        }

        public String DepartmentCode
        {
            get { return this._departmentCode; }
            set { this._departmentCode = value; }
        }

        public String DoctorCode
        {
            get { return this._doctorCode; }
            set { this._doctorCode = value; }
        }

        public String FromTimeAm
        {
            get { return this._fromTimeAm; }
            set { this._fromTimeAm = value; }
        }

        public String ToTimeAm
        {
            get { return this._toTimeAm; }
            set { this._toTimeAm = value; }
        }

        public String FromTimePm
        {
            get { return this._fromTimePm; }
            set { this._fromTimePm = value; }
        }

        public String ToTimePm
        {
            get { return this._toTimePm; }
            set { this._toTimePm = value; }
        }

        public String AvgTime
        {
            get { return this._avgTime; }
            set { this._avgTime = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
        }

        public Boolean TabIsAll
        {
            get { return this._tabIsAll; }
            set { this._tabIsAll = value; }
        }

        public RES1001U00ReservationScheduleListGroupedArgs() { }

        public RES1001U00ReservationScheduleListGroupedArgs(String examPreDate, String departmentCode, String doctorCode, String fromTimeAm, String toTimeAm, String fromTimePm, String toTimePm, String avgTime, String hospCodeLink, Boolean tabIsAll)
        {
            this._examPreDate = examPreDate;
            this._departmentCode = departmentCode;
            this._doctorCode = doctorCode;
            this._fromTimeAm = fromTimeAm;
            this._toTimeAm = toTimeAm;
            this._fromTimePm = fromTimePm;
            this._toTimePm = toTimePm;
            this._avgTime = avgTime;
            this._hospCodeLink = hospCodeLink;
            this._tabIsAll = tabIsAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.RES1001U00ReservationScheduleListGroupedRequest();
        }
    }
}
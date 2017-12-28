using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroRES1001U00ReservationScheduleListArgs : IContractArgs
    {
        protected bool Equals(NuroRES1001U00ReservationScheduleListArgs other)
        {
            return string.Equals(_examPreDate, other._examPreDate) && string.Equals(_departmentCode, other._departmentCode) && string.Equals(_doctorCode, other._doctorCode) && string.Equals(_fromTime, other._fromTime) && string.Equals(_toTime, other._toTime) && string.Equals(_avgTime, other._avgTime) && string.Equals(_hospCodeLink, other._hospCodeLink) && _tabIsAll.Equals(other._tabIsAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00ReservationScheduleListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_examPreDate != null ? _examPreDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_departmentCode != null ? _departmentCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctorCode != null ? _doctorCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fromTime != null ? _fromTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_toTime != null ? _toTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_avgTime != null ? _avgTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _tabIsAll.GetHashCode();
                return hashCode;
            }
        }

        private String _examPreDate;
        private String _departmentCode;
        private String _doctorCode;
        private String _fromTime;
        private String _toTime;
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

        public String FromTime
        {
            get { return this._fromTime; }
            set { this._fromTime = value; }
        }

        public String ToTime
        {
            get { return this._toTime; }
            set { this._toTime = value; }
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

        public NuroRES1001U00ReservationScheduleListArgs() { }

        public NuroRES1001U00ReservationScheduleListArgs(String examPreDate, String departmentCode, String doctorCode, String fromTime, String toTime, String avgTime, String hospCodeLink, Boolean tabIsAll)
        {
            this._examPreDate = examPreDate;
            this._departmentCode = departmentCode;
            this._doctorCode = doctorCode;
            this._fromTime = fromTime;
            this._toTime = toTime;
            this._avgTime = avgTime;
            this._hospCodeLink = hospCodeLink;
            this._tabIsAll = tabIsAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroRES1001U00ReservationScheduleListRequest();
        }
    }
}
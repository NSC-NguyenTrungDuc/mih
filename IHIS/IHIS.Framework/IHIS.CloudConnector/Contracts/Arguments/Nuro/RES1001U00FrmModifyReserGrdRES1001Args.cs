using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class RES1001U00FrmModifyReserGrdRES1001Args : IContractArgs
    {
        protected bool Equals(RES1001U00FrmModifyReserGrdRES1001Args other)
        {
            return string.Equals(_doctor, other._doctor) && string.Equals(_dayOfWeek, other._dayOfWeek) && string.Equals(_date, other._date) && string.Equals(_hospCodeLink, other._hospCodeLink) && _tabIsAll.Equals(other._tabIsAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RES1001U00FrmModifyReserGrdRES1001Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_dayOfWeek != null ? _dayOfWeek.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_date != null ? _date.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _tabIsAll.GetHashCode();
                return hashCode;
            }
        }

        private String _doctor;
        private String _dayOfWeek;
        private String _date;
        private String _hospCodeLink;
        private Boolean _tabIsAll;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String DayOfWeek
        {
            get { return this._dayOfWeek; }
            set { this._dayOfWeek = value; }
        }

        public String Date
        {
            get { return this._date; }
            set { this._date = value; }
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

        public RES1001U00FrmModifyReserGrdRES1001Args() { }

        public RES1001U00FrmModifyReserGrdRES1001Args(String doctor, String dayOfWeek, String date, String hospCodeLink, Boolean tabIsAll)
        {
            this._doctor = doctor;
            this._dayOfWeek = dayOfWeek;
            this._date = date;
            this._hospCodeLink = hospCodeLink;
            this._tabIsAll = tabIsAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.RES1001U00FrmModifyReserGrdRES1001Request();
        }
    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroRES1001U00PRDoctorScheduleNewArgs : IContractArgs
    {
        protected bool Equals(NuroRES1001U00PRDoctorScheduleNewArgs other)
        {
            return string.Equals(_iDoctor, other._iDoctor) && string.Equals(_iYymm, other._iYymm) && string.Equals(_hospCodeLink, other._hospCodeLink) && _tabIsAll.Equals(other._tabIsAll);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroRES1001U00PRDoctorScheduleNewArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_iDoctor != null ? _iDoctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_iYymm != null ? _iYymm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _tabIsAll.GetHashCode();
                return hashCode;
            }
        }

        private String _iDoctor;
        private String _iYymm;
        private String _hospCodeLink;
        private Boolean _tabIsAll;

        public String IDoctor
        {
            get { return this._iDoctor; }
            set { this._iDoctor = value; }
        }

        public String IYymm
        {
            get { return this._iYymm; }
            set { this._iYymm = value; }
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

        public NuroRES1001U00PRDoctorScheduleNewArgs() { }

        public NuroRES1001U00PRDoctorScheduleNewArgs(String iDoctor, String iYymm, String hospCodeLink, Boolean tabIsAll)
        {
            this._iDoctor = iDoctor;
            this._iYymm = iYymm;
            this._hospCodeLink = hospCodeLink;
            this._tabIsAll = tabIsAll;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroRES1001U00PRDoctorScheduleNewRequest();
        }
    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class RES1001U00PrIFSMakeYoyakuArgs : IContractArgs
    {
        protected bool Equals(RES1001U00PrIFSMakeYoyakuArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_pkout1001, other._pkout1001) && string.Equals(_procGubun, other._procGubun) && string.Equals(_yoyakuGubun, other._yoyakuGubun) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_userId, other._userId) && string.Equals(_bunho, other._bunho) && string.Equals(_gwa, other._gwa) && string.Equals(_doctor, other._doctor) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_jubsuTime, other._jubsuTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RES1001U00PrIFSMakeYoyakuArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_procGubun != null ? _procGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_yoyakuGubun != null ? _yoyakuGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuTime != null ? _jubsuTime.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _pkout1001;
        private String _procGubun;
        private String _yoyakuGubun;
        private String _ioGubun;
        private String _userId;
        private String _bunho;
        private String _gwa;
        private String _doctor;
        private String _naewonDate;
        private String _jubsuTime;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String ProcGubun
        {
            get { return this._procGubun; }
            set { this._procGubun = value; }
        }

        public String YoyakuGubun
        {
            get { return this._yoyakuGubun; }
            set { this._yoyakuGubun = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public RES1001U00PrIFSMakeYoyakuArgs() { }

        public RES1001U00PrIFSMakeYoyakuArgs(String hospCode, String pkout1001, String procGubun, String yoyakuGubun, String ioGubun, String userId, String bunho, String gwa, String doctor, String naewonDate, String jubsuTime)
        {
            this._hospCode = hospCode;
            this._pkout1001 = pkout1001;
            this._procGubun = procGubun;
            this._yoyakuGubun = yoyakuGubun;
            this._ioGubun = ioGubun;
            this._userId = userId;
            this._bunho = bunho;
            this._gwa = gwa;
            this._doctor = doctor;
            this._naewonDate = naewonDate;
            this._jubsuTime = jubsuTime;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.RES1001U00PrIFSMakeYoyakuRequest();
        }
    }
}
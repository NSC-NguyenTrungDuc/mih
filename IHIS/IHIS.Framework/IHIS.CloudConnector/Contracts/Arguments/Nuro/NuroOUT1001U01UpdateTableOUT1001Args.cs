using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOUT1001U01UpdateTableOUT1001Args : IContractArgs
    {
        protected bool Equals(NuroOUT1001U01UpdateTableOUT1001Args other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_doctor, other._doctor) && string.Equals(_chojae, other._chojae) && string.Equals(_jubsuNo, other._jubsuNo) && string.Equals(_gubun, other._gubun) && string.Equals(_jubsuTime, other._jubsuTime) && string.Equals(_arriveTime, other._arriveTime) && string.Equals(_jubsuGubun, other._jubsuGubun) && string.Equals(_checkNaewon, other._checkNaewon) && string.Equals(_pkout1001, other._pkout1001);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOUT1001U01UpdateTableOUT1001Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_chojae != null ? _chojae.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuNo != null ? _jubsuNo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuTime != null ? _jubsuTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_arriveTime != null ? _arriveTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_jubsuGubun != null ? _jubsuGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_checkNaewon != null ? _checkNaewon.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
        private String _doctor;
        private String _chojae;
        private String _jubsuNo;
        private String _gubun;
        private String _jubsuTime;
        private String _arriveTime;
        private String _jubsuGubun;
        private String _checkNaewon;
        private String _pkout1001;

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String Chojae
        {
            get { return this._chojae; }
            set { this._chojae = value; }
        }

        public String JubsuNo
        {
            get { return this._jubsuNo; }
            set { this._jubsuNo = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public String ArriveTime
        {
            get { return this._arriveTime; }
            set { this._arriveTime = value; }
        }

        public String JubsuGubun
        {
            get { return this._jubsuGubun; }
            set { this._jubsuGubun = value; }
        }

        public String CheckNaewon
        {
            get { return this._checkNaewon; }
            set { this._checkNaewon = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public NuroOUT1001U01UpdateTableOUT1001Args() { }

        public NuroOUT1001U01UpdateTableOUT1001Args(String userId, String doctor, String chojae, String jubsuNo, String gubun, String jubsuTime, String arriveTime, String jubsuGubun, String checkNaewon, String pkout1001)
        {
            this._userId = userId;
            this._doctor = doctor;
            this._chojae = chojae;
            this._jubsuNo = jubsuNo;
            this._gubun = gubun;
            this._jubsuTime = jubsuTime;
            this._arriveTime = arriveTime;
            this._jubsuGubun = jubsuGubun;
            this._checkNaewon = checkNaewon;
            this._pkout1001 = pkout1001;
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1001U01UpdateTableOUT1001Request();
        }
    }
}
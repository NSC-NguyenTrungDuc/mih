using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class OUT0101Q01GrdPatientListArgs : IContractArgs
    {
        protected bool Equals(OUT0101Q01GrdPatientListArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_suname2, other._suname2) && string.Equals(_sex, other._sex) && string.Equals(_birth, other._birth) && string.Equals(_tel, other._tel) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OUT0101Q01GrdPatientListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_suname2 != null ? _suname2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sex != null ? _sex.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_birth != null ? _birth.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_tel != null ? _tel.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _suname2;
        private String _sex;
        private String _birth;
        private String _tel;
        private String _pageNumber;
        private String _offset;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public String Offset
        {
            get { return this._offset; }
            set { this._offset = value; }
        }

        public OUT0101Q01GrdPatientListArgs() { }

        public OUT0101Q01GrdPatientListArgs(String hospCode, String suname2, String sex, String birth, String tel, String pageNumber, String offset)
        {
            this._hospCode = hospCode;
            this._suname2 = suname2;
            this._sex = sex;
            this._birth = birth;
            this._tel = tel;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUT0101Q01GrdPatientListRequest();
        }
    }
}
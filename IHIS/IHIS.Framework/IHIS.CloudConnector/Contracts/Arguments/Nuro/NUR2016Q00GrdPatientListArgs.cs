using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NUR2016Q00GrdPatientListArgs : IContractArgs
    {
        protected bool Equals(NUR2016Q00GrdPatientListArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_suname, other._suname) && string.Equals(_suname2, other._suname2) && string.Equals(_address, other._address) && string.Equals(_birth, other._birth) && string.Equals(_hospCodeLink, other._hospCodeLink) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR2016Q00GrdPatientListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_suname != null ? _suname.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_suname2 != null ? _suname2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_address != null ? _address.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_birth != null ? _birth.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hospCodeLink != null ? _hospCodeLink.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
        private String _suname;
        private String _suname2;
        private String _address;
        private String _birth;
        private String _hospCodeLink;
        private String _pageNumber;
        private String _offset;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String HospCodeLink
        {
            get { return this._hospCodeLink; }
            set { this._hospCodeLink = value; }
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

        public NUR2016Q00GrdPatientListArgs() { }

        public NUR2016Q00GrdPatientListArgs(String bunho, String suname, String suname2, String address, String birth, String hospCodeLink, String pageNumber, String offset)
        {
            this._bunho = bunho;
            this._suname = suname;
            this._suname2 = suname2;
            this._address = address;
            this._birth = birth;
            this._hospCodeLink = hospCodeLink;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NUR2016Q00GrdPatientListRequest();
        }
    }
}
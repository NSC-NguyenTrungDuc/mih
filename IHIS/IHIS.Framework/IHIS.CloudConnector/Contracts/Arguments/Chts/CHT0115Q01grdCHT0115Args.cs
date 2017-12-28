using System;
using IHIS.CloudConnector.Contracts.Models.Chts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
    public class CHT0115Q01grdCHT0115Args : IContractArgs
    {
        protected bool Equals(CHT0115Q01grdCHT0115Args other)
        {
            return string.Equals(_susikDetailGubun, other._susikDetailGubun) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0115Q01grdCHT0115Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_susikDetailGubun != null ? _susikDetailGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _susikDetailGubun;
        private String _pageNumber;
        private String _offset;

        public String SusikDetailGubun
        {
            get { return this._susikDetailGubun; }
            set { this._susikDetailGubun = value; }
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

        public CHT0115Q01grdCHT0115Args() { }

        public CHT0115Q01grdCHT0115Args(String susikDetailGubun, String pageNumber, String offset)
        {
            this._susikDetailGubun = susikDetailGubun;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CHT0115Q01grdCHT0115Request();
        }
    }
}
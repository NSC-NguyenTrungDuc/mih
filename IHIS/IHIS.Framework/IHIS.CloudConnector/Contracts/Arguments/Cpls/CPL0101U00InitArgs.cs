using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0101U00InitArgs : IContractArgs
    {
        protected bool Equals(CPL0101U00InitArgs other)
        {
            return string.Equals(_txtHangmog, other._txtHangmog) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0101U00InitArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_txtHangmog != null ? _txtHangmog.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _txtHangmog;
        private String _ioGubun;
        private String _pageNumber;
        private String _offset;

        public String TxtHangmog
        {
            get { return this._txtHangmog; }
            set { this._txtHangmog = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
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

        public CPL0101U00InitArgs() { }

        public CPL0101U00InitArgs(String txtHangmog, String ioGubun, String pageNumber, String offset)
        {
            this._txtHangmog = txtHangmog;
            this._ioGubun = ioGubun;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0101U00InitRequest();
        }
    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0003U00GridFindClickArgs : IContractArgs
    {
        protected bool Equals(IFS0003U00GridFindClickArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_find1, other._find1) && string.Equals(_colName, other._colName) && string.Equals(_mapGubun, other._mapGubun) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0003U00GridFindClickArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_colName != null ? _colName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_mapGubun != null ? _mapGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _codeType;
        private String _find1;
        private String _mapGubun;
        private String _colName;
        private String _pageNumber;
        private String _offset;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public String MapGubun
        {
            get { return this._mapGubun; }
            set { this._mapGubun = value; }
        }

        public String ColName
        {
            get { return this._colName; }
            set { this._colName = value; }
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

        public IFS0003U00GridFindClickArgs() { }

        public IFS0003U00GridFindClickArgs(String codeType, String find1, String mapGubun, String colName, String pageNumber, String offset)
        {
            this._codeType = codeType;
            this._find1 = find1;
            this._mapGubun = mapGubun;
            this._colName = colName;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0003U00GridFindClickRequest();
        }
    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0104U00GrdMasterArgs : IContractArgs
    {
        protected bool Equals(CPL0104U00GrdMasterArgs other)
        {
            return string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_specimenCode, other._specimenCode) && string.Equals(_emergency, other._emergency) && string.Equals(_gumsaName, other._gumsaName) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0104U00GrdMasterArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_specimenCode != null ? _specimenCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_emergency != null ? _emergency.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gumsaName != null ? _gumsaName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hangmogCode;
        private String _specimenCode;
        private String _emergency;
        private String _gumsaName;
        private String _pageNumber;
        private String _offset;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String SpecimenCode
        {
            get { return this._specimenCode; }
            set { this._specimenCode = value; }
        }

        public String Emergency
        {
            get { return this._emergency; }
            set { this._emergency = value; }
        }

        public String GumsaName
        {
            get { return this._gumsaName; }
            set { this._gumsaName = value; }
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

        public CPL0104U00GrdMasterArgs() { }

        public CPL0104U00GrdMasterArgs(String hangmogCode, String specimenCode, String emergency, String gumsaName, String pageNumber, String offset)
        {
            this._hangmogCode = hangmogCode;
            this._specimenCode = specimenCode;
            this._emergency = emergency;
            this._gumsaName = gumsaName;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0104U00GrdMasterRequest();
        }
    }
}
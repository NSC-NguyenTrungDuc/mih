using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00GrdOCS0103Args : IContractArgs
    {
    protected bool Equals(OCS0103U00GrdOCS0103Args other)
    {
        return string.Equals(_slipCode, other._slipCode) && string.Equals(_hangmogInx, other._hangmogInx) && string.Equals(_slipGubun, other._slipGubun) && string.Equals(_usedYn, other._usedYn) && string.Equals(_wonnaeYn, other._wonnaeYn) && string.Equals(_hospCode, other._hospCode) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00GrdOCS0103Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_slipCode != null ? _slipCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogInx != null ? _hangmogInx.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_slipGubun != null ? _slipGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_usedYn != null ? _usedYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_wonnaeYn != null ? _wonnaeYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _slipCode;
        private String _hangmogInx;
        private String _slipGubun;
        private String _usedYn;
        private String _wonnaeYn;
        private String _hospCode;
        private String _pageNumber;
        private String _offset;

        public String SlipCode
        {
            get { return this._slipCode; }
            set { this._slipCode = value; }
        }

        public String HangmogInx
        {
            get { return this._hangmogInx; }
            set { this._hangmogInx = value; }
        }

        public String SlipGubun
        {
            get { return this._slipGubun; }
            set { this._slipGubun = value; }
        }

        public String UsedYn
        {
            get { return this._usedYn; }
            set { this._usedYn = value; }
        }

        public String WonnaeYn
        {
            get { return this._wonnaeYn; }
            set { this._wonnaeYn = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
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

        public OCS0103U00GrdOCS0103Args() { }

        public OCS0103U00GrdOCS0103Args(String slipCode, String hangmogInx, String slipGubun, String usedYn, String wonnaeYn, String hospCode, String pageNumber, String offset)
        {
            this._slipCode = slipCode;
            this._hangmogInx = hangmogInx;
            this._slipGubun = slipGubun;
            this._usedYn = usedYn;
            this._wonnaeYn = wonnaeYn;
            this._hospCode = hospCode;
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00GrdOCS0103Request();
        }
    }
}
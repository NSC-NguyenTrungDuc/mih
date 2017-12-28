using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00FwkCommonArgs : IContractArgs
    {
    protected bool Equals(OCS0103U00FwkCommonArgs other)
    {
        return _isGridControl.Equals(other._isGridControl) && string.Equals(_gridName, other._gridName) && string.Equals(_controlName, other._controlName) && string.Equals(_slipGubun, other._slipGubun) && string.Equals(_sgCode, other._sgCode) && string.Equals(_kijunCode, other._kijunCode) && string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00FwkCommonArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = _isGridControl.GetHashCode();
            hashCode = (hashCode*397) ^ (_gridName != null ? _gridName.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_controlName != null ? _controlName.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_slipGubun != null ? _slipGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sgCode != null ? _sgCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_kijunCode != null ? _kijunCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private Boolean _isGridControl;
        private String _gridName;
        private String _controlName;
        private String _slipGubun;
        private String _sgCode;
        private String _kijunCode;
        private String _hangmogCode;
        private String _hospCode;

        public Boolean IsGridControl
        {
            get { return this._isGridControl; }
            set { this._isGridControl = value; }
        }

        public String GridName
        {
            get { return this._gridName; }
            set { this._gridName = value; }
        }

        public String ControlName
        {
            get { return this._controlName; }
            set { this._controlName = value; }
        }

        public String SlipGubun
        {
            get { return this._slipGubun; }
            set { this._slipGubun = value; }
        }

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public String KijunCode
        {
            get { return this._kijunCode; }
            set { this._kijunCode = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0103U00FwkCommonArgs() { }

        public OCS0103U00FwkCommonArgs(Boolean isGridControl, String gridName, String controlName, String slipGubun, String sgCode, String kijunCode, String hangmogCode, String hospCode)
        {
            this._isGridControl = isGridControl;
            this._gridName = gridName;
            this._controlName = controlName;
            this._slipGubun = slipGubun;
            this._sgCode = sgCode;
            this._kijunCode = kijunCode;
            this._hangmogCode = hangmogCode;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00FwkCommonRequest();
        }
    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00GridColumnChangedArgs : IContractArgs
    {
    protected bool Equals(OCS0103U00GridColumnChangedArgs other)
    {
        return string.Equals(_gridName, other._gridName) && string.Equals(_colName, other._colName) && string.Equals(_changeValue, other._changeValue) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00GridColumnChangedArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_gridName != null ? _gridName.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_colName != null ? _colName.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_changeValue != null ? _changeValue.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _gridName;
        private String _colName;
        private String _changeValue;
        private String _hospCode;

        public String GridName
        {
            get { return this._gridName; }
            set { this._gridName = value; }
        }

        public String ColName
        {
            get { return this._colName; }
            set { this._colName = value; }
        }

        public String ChangeValue
        {
            get { return this._changeValue; }
            set { this._changeValue = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0103U00GridColumnChangedArgs() { }

        public OCS0103U00GridColumnChangedArgs(String gridName, String colName, String changeValue, String hospCode)
        {
            this._gridName = gridName;
            this._colName = colName;
            this._changeValue = changeValue;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00GridColumnChangedRequest();
        }
    }
}
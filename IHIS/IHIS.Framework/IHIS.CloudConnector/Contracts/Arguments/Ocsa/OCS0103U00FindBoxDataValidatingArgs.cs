using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00FindBoxDataValidatingArgs : IContractArgs
    {
    protected bool Equals(OCS0103U00FindBoxDataValidatingArgs other)
    {
        return string.Equals(_fbName, other._fbName) && string.Equals(_dataValue, other._dataValue) && string.Equals(_startDate, other._startDate) && string.Equals(_orderGubun, other._orderGubun) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00FindBoxDataValidatingArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_fbName != null ? _fbName.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_dataValue != null ? _dataValue.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderGubun != null ? _orderGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _fbName;
        private String _dataValue;
        private String _startDate;
        private String _orderGubun;
        private String _hospCode;

        public String FbName
        {
            get { return this._fbName; }
            set { this._fbName = value; }
        }

        public String DataValue
        {
            get { return this._dataValue; }
            set { this._dataValue = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String OrderGubun
        {
            get { return this._orderGubun; }
            set { this._orderGubun = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0103U00FindBoxDataValidatingArgs() { }

        public OCS0103U00FindBoxDataValidatingArgs(String fbName, String dataValue, String startDate, String orderGubun, String hospCode)
        {
            this._fbName = fbName;
            this._dataValue = dataValue;
            this._startDate = startDate;
            this._orderGubun = orderGubun;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00FindBoxDataValidatingRequest();
        }
    }
}
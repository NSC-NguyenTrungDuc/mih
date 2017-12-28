using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT1002U00LayPrintDateArgs : IContractArgs
    {
    protected bool Equals(XRT1002U00LayPrintDateArgs other)
    {
        return string.Equals(_orderDate, other._orderDate) && string.Equals(_inOutGubun, other._inOutGubun) && string.Equals(_fkout1001, other._fkout1001) && string.Equals(_printOnly, other._printOnly) && string.Equals(_jundalPart, other._jundalPart) && string.Equals(_pkocs, other._pkocs) && string.Equals(_fkinp1001, other._fkinp1001);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT1002U00LayPrintDateArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inOutGubun != null ? _inOutGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkout1001 != null ? _fkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_printOnly != null ? _printOnly.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkocs != null ? _pkocs.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkinp1001 != null ? _fkinp1001.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _orderDate;
        private String _inOutGubun;
        private String _fkout1001;
        private String _printOnly;
        private String _jundalPart;
        private String _pkocs;
        private String _fkinp1001;

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String PrintOnly
        {
            get { return this._printOnly; }
            set { this._printOnly = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String Pkocs
        {
            get { return this._pkocs; }
            set { this._pkocs = value; }
        }

        public String Fkinp1001
        {
            get { return this._fkinp1001; }
            set { this._fkinp1001 = value; }
        }

        public XRT1002U00LayPrintDateArgs() { }

        public XRT1002U00LayPrintDateArgs(String orderDate, String inOutGubun, String fkout1001, String printOnly, String jundalPart, String pkocs, String fkinp1001)
        {
            this._orderDate = orderDate;
            this._inOutGubun = inOutGubun;
            this._fkout1001 = fkout1001;
            this._printOnly = printOnly;
            this._jundalPart = jundalPart;
            this._pkocs = pkocs;
            this._fkinp1001 = fkinp1001;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT1002U00LayPrintDateRequest();
        }
    }
}
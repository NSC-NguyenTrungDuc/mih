using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT1002U00LayPrintOrderArgs : IContractArgs
    {
    protected bool Equals(XRT1002U00LayPrintOrderArgs other)
    {
        return string.Equals(_orderDate, other._orderDate) && string.Equals(_gwa, other._gwa) && string.Equals(_inOutGubun, other._inOutGubun) && string.Equals(_pkocs, other._pkocs);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT1002U00LayPrintOrderArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwa != null ? _gwa.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inOutGubun != null ? _inOutGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkocs != null ? _pkocs.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _orderDate;
        private String _gwa;
        private String _inOutGubun;
        private String _pkocs;

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String Pkocs
        {
            get { return this._pkocs; }
            set { this._pkocs = value; }
        }

        public XRT1002U00LayPrintOrderArgs() { }

        public XRT1002U00LayPrintOrderArgs(String orderDate, String gwa, String inOutGubun, String pkocs)
        {
            this._orderDate = orderDate;
            this._gwa = gwa;
            this._inOutGubun = inOutGubun;
            this._pkocs = pkocs;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT1002U00LayPrintOrderRequest();
        }
    }
}
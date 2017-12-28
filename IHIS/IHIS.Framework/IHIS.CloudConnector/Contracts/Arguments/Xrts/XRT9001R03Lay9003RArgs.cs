using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT9001R03Lay9003RArgs : IContractArgs
    {
    protected bool Equals(XRT9001R03Lay9003RArgs other)
    {
        return string.Equals(_date, other._date);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT9001R03Lay9003RArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_date != null ? _date.GetHashCode() : 0);
    }

    private String _date;

        public String Date
        {
            get { return this._date; }
            set { this._date = value; }
        }

        public XRT9001R03Lay9003RArgs() { }

        public XRT9001R03Lay9003RArgs(String date)
        {
            this._date = date;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT9001R03Lay9003RRequest();
        }
    }
}
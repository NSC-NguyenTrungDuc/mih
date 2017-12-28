using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
	public class XRT0201U00GrdRadioListArgs : IContractArgs
	{
    protected bool Equals(XRT0201U00GrdRadioListArgs other)
    {
        return string.Equals(_orderDate, other._orderDate) && string.Equals(_bunho, other._bunho) && string.Equals(_inOutGubun, other._inOutGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0201U00GrdRadioListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inOutGubun != null ? _inOutGubun.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _orderDate;
		private String _bunho;
		private String _inOutGubun;

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String InOutGubun
		{
			get { return this._inOutGubun; }
			set { this._inOutGubun = value; }
		}

		public XRT0201U00GrdRadioListArgs() { }

		public XRT0201U00GrdRadioListArgs(String orderDate, String bunho, String inOutGubun)
		{
			this._orderDate = orderDate;
			this._bunho = bunho;
			this._inOutGubun = inOutGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new XRT0201U00GrdRadioListRequest();
		}
	}
}
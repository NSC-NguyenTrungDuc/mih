using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS3003Q10GrdOrderDateArgs : IContractArgs
	{
    protected bool Equals(OCS3003Q10GrdOrderDateArgs other)
    {
        return string.Equals(_ioGubun, other._ioGubun) && string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate) && string.Equals(_orderGubun, other._orderGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS3003Q10GrdOrderDateArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderGubun != null ? _orderGubun.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _ioGubun;
		private String _bunho;
		private String _orderDate;
		private String _orderGubun;

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String OrderGubun
		{
			get { return this._orderGubun; }
			set { this._orderGubun = value; }
		}

		public OCS3003Q10GrdOrderDateArgs() { }

		public OCS3003Q10GrdOrderDateArgs(String ioGubun, String bunho, String orderDate, String orderGubun)
		{
			this._ioGubun = ioGubun;
			this._bunho = bunho;
			this._orderDate = orderDate;
			this._orderGubun = orderGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS3003Q10GrdOrderDateRequest();
		}
	}
}
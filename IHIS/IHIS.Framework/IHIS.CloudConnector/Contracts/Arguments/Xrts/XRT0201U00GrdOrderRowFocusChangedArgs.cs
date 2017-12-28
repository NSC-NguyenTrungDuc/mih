using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
	public class XRT0201U00GrdOrderRowFocusChangedArgs : IContractArgs
	{
    protected bool Equals(XRT0201U00GrdOrderRowFocusChangedArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_jundalPart, other._jundalPart) && string.Equals(_fkocs, other._fkocs) && string.Equals(_grdOrderRowCount, other._grdOrderRowCount) && string.Equals(_hangmogCode, other._hangmogCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0201U00GrdOrderRowFocusChangedArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_jundalPart != null ? _jundalPart.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkocs != null ? _fkocs.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdOrderRowCount != null ? _grdOrderRowCount.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
		private String _orderDate;
		private String _ioGubun;
		private String _jundalPart;
		private String _fkocs;
		private String _grdOrderRowCount;
		private String _hangmogCode;

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

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public String Fkocs
		{
			get { return this._fkocs; }
			set { this._fkocs = value; }
		}

		public String GrdOrderRowCount
		{
			get { return this._grdOrderRowCount; }
			set { this._grdOrderRowCount = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public XRT0201U00GrdOrderRowFocusChangedArgs() { }

		public XRT0201U00GrdOrderRowFocusChangedArgs(String bunho, String orderDate, String ioGubun, String jundalPart, String fkocs, String grdOrderRowCount, String hangmogCode)
		{
			this._bunho = bunho;
			this._orderDate = orderDate;
			this._ioGubun = ioGubun;
			this._jundalPart = jundalPart;
			this._fkocs = fkocs;
			this._grdOrderRowCount = grdOrderRowCount;
			this._hangmogCode = hangmogCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new XRT0201U00GrdOrderRowFocusChangedRequest();
		}
	}
}
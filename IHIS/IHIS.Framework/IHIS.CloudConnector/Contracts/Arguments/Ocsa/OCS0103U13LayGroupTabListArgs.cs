using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U13LayGroupTabListArgs : IContractArgs
	{
    protected bool Equals(OCS0103U13LayGroupTabListArgs other)
    {
        return string.Equals(_orderMode, other._orderMode) && string.Equals(_memb, other._memb) && string.Equals(_yaksokCode, other._yaksokCode) && string.Equals(_inputGubun, other._inputGubun) && string.Equals(_inputTab, other._inputTab) && string.Equals(_fkInOutKey, other._fkInOutKey) && string.Equals(_orderDate, other._orderDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U13LayGroupTabListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_orderMode != null ? _orderMode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_memb != null ? _memb.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_yaksokCode != null ? _yaksokCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputGubun != null ? _inputGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkInOutKey != null ? _fkInOutKey.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _orderMode;
		private String _memb;
		private String _yaksokCode;
		private String _inputGubun;
		private String _inputTab;
		private String _fkInOutKey;
		private String _orderDate;

		public String OrderMode
		{
			get { return this._orderMode; }
			set { this._orderMode = value; }
		}

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String YaksokCode
		{
			get { return this._yaksokCode; }
			set { this._yaksokCode = value; }
		}

		public String InputGubun
		{
			get { return this._inputGubun; }
			set { this._inputGubun = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public String FkInOutKey
		{
			get { return this._fkInOutKey; }
			set { this._fkInOutKey = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public OCS0103U13LayGroupTabListArgs() { }

		public OCS0103U13LayGroupTabListArgs(String orderMode, String memb, String yaksokCode, String inputGubun, String inputTab, String fkInOutKey, String orderDate)
		{
			this._orderMode = orderMode;
			this._memb = memb;
			this._yaksokCode = yaksokCode;
			this._inputGubun = inputGubun;
			this._inputTab = inputTab;
			this._fkInOutKey = fkInOutKey;
			this._orderDate = orderDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U13LayGroupTabListRequest();
		}
	}
}
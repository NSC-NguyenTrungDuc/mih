using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U12SetSameOrderDateGroupSerArgs : IContractArgs
	{
    protected bool Equals(OCS0103U12SetSameOrderDateGroupSerArgs other)
    {
        return string.Equals(_orderDate, other._orderDate) && string.Equals(_inputTab, other._inputTab) && string.Equals(_bunho, other._bunho) && string.Equals(_inputDoctor, other._inputDoctor);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U12SetSameOrderDateGroupSerArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputDoctor != null ? _inputDoctor.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _orderDate;
		private String _inputTab;
		private String _bunho;
		private String _inputDoctor;

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String InputDoctor
		{
			get { return this._inputDoctor; }
			set { this._inputDoctor = value; }
		}

		public OCS0103U12SetSameOrderDateGroupSerArgs() { }

		public OCS0103U12SetSameOrderDateGroupSerArgs(String orderDate, String inputTab, String bunho, String inputDoctor)
		{
			this._orderDate = orderDate;
			this._inputTab = inputTab;
			this._bunho = bunho;
			this._inputDoctor = inputDoctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U12SetSameOrderDateGroupSerRequest();
		}
	}
}
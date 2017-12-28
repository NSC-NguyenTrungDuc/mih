using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01GridReserOrderListArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01GridReserOrderListArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_naewonDate, other._naewonDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01GridReserOrderListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
        }
    }

    private String _bunho;
		private String _naewonDate;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public OcsoOCS1003P01GridReserOrderListArgs() { }

		public OcsoOCS1003P01GridReserOrderListArgs(String bunho, String naewonDate)
		{
			this._bunho = bunho;
			this._naewonDate = naewonDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01GridReserOrderListRequest();
		}
	}
}
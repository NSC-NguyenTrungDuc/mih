using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01CheckXArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01CheckXArgs other)
    {
        return string.Equals(_actionDoctor, other._actionDoctor) && string.Equals(_bunho, other._bunho) && string.Equals(_naewonKey, other._naewonKey);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01CheckXArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_actionDoctor != null ? _actionDoctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonKey != null ? _naewonKey.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _actionDoctor;
		private String _bunho;
		private String _naewonKey;

		public String ActionDoctor
		{
			get { return this._actionDoctor; }
			set { this._actionDoctor = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String NaewonKey
		{
			get { return this._naewonKey; }
			set { this._naewonKey = value; }
		}

		public OcsoOCS1003P01CheckXArgs() { }

		public OcsoOCS1003P01CheckXArgs(String actionDoctor, String bunho, String naewonKey)
		{
			this._actionDoctor = actionDoctor;
			this._bunho = bunho;
			this._naewonKey = naewonKey;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01CheckXRequest();
		}
	}
}
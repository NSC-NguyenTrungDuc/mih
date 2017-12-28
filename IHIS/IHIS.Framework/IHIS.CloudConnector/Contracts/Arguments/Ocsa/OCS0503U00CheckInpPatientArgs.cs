using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0503U00CheckInpPatientArgs : IContractArgs
	{
    protected bool Equals(OCS0503U00CheckInpPatientArgs other)
    {
        return string.Equals(_bunho, other._bunho);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503U00CheckInpPatientArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_bunho != null ? _bunho.GetHashCode() : 0);
    }

    private String _bunho;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public OCS0503U00CheckInpPatientArgs() { }

		public OCS0503U00CheckInpPatientArgs(String bunho)
		{
			this._bunho = bunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503U00CheckInpPatientRequest();
		}
	}
}
using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0503U00gridOSC0503ListArgs : IContractArgs
	{
    protected bool Equals(OCS0503U00gridOSC0503ListArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_reqDoctor, other._reqDoctor);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0503U00gridOSC0503ListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_reqDoctor != null ? _reqDoctor.GetHashCode() : 0);
        }
    }

    private String _bunho;
		private String _reqDoctor;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String ReqDoctor
		{
			get { return this._reqDoctor; }
			set { this._reqDoctor = value; }
		}

		public OCS0503U00gridOSC0503ListArgs() { }

		public OCS0503U00gridOSC0503ListArgs(String bunho, String reqDoctor)
		{
			this._bunho = bunho;
			this._reqDoctor = reqDoctor;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0503U00gridOSC0503ListRequest();
		}
	}
}
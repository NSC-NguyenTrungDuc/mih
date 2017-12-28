using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OUTSANGU00createGwaDataArgs : IContractArgs
	{
    protected bool Equals(OUTSANGU00createGwaDataArgs other)
    {
        return string.Equals(_outJubsuYn, other._outJubsuYn);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUTSANGU00createGwaDataArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_outJubsuYn != null ? _outJubsuYn.GetHashCode() : 0);
    }

    private String _outJubsuYn;

		public String OutJubsuYn
		{
			get { return this._outJubsuYn; }
			set { this._outJubsuYn = value; }
		}

		public OUTSANGU00createGwaDataArgs() { }

		public OUTSANGU00createGwaDataArgs(String outJubsuYn)
		{
			this._outJubsuYn = outJubsuYn;
		}

		public IExtensible GetRequestInstance()
		{
			return new OUTSANGU00createGwaDataRequest();
		}
	}
}
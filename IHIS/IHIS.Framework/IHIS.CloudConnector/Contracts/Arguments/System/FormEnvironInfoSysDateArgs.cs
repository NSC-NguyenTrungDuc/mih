using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
	public class FormEnvironInfoSysDateArgs : IContractArgs
	{
    protected bool Equals(FormEnvironInfoSysDateArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FormEnvironInfoSysDateArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public FormEnvironInfoSysDateArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new FormEnvironInfoSysDateRequest();
		}
	}
}
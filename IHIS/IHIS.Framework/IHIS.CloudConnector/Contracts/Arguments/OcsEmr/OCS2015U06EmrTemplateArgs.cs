using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U06EmrTemplateArgs : IContractArgs
	{
    protected bool Equals(OCS2015U06EmrTemplateArgs other)
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U06EmrTemplateArgs) obj);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public OCS2015U06EmrTemplateArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U06EmrTemplateRequest();
		}
	}
}
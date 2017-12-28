using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
	public class CreateGwaComboArgs : IContractArgs
	{
	    protected bool Equals(CreateGwaComboArgs other)
	    {
	        return true;
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((CreateGwaComboArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return 0;
	    }

	    public CreateGwaComboArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new CreateGwaComboRequest();
		}
	}
}
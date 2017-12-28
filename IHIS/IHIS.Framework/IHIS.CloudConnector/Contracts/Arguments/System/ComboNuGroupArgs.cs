using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
	public class ComboNuGroupArgs : IContractArgs
	{
	    protected bool Equals(ComboNuGroupArgs other)
	    {
	        return _isAll.Equals(other._isAll);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((ComboNuGroupArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return _isAll.GetHashCode();
	    }

	    private Boolean _isAll;

		public Boolean IsAll
		{
			get { return this._isAll; }
			set { this._isAll = value; }
		}

		public ComboNuGroupArgs() { }

		public ComboNuGroupArgs(Boolean isAll)
		{
			this._isAll = isAll;
		}

		public IExtensible GetRequestInstance()
		{
			return new ComboNuGroupRequest();
		}
	}
}
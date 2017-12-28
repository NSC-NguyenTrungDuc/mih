using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using GetOrderCountInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.GetOrderCountInfo;
using GetUserOptionInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.GetUserOptionInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003P01GetUserOptionAndOrderCountArgs : IContractArgs
	{
    protected bool Equals(OCS1003P01GetUserOptionAndOrderCountArgs other)
    {
        return Equals(_userOption, other._userOption) && Equals(_orderCount, other._orderCount);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003P01GetUserOptionAndOrderCountArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_userOption != null ? _userOption.GetHashCode() : 0)*397) ^ (_orderCount != null ? _orderCount.GetHashCode() : 0);
        }
    }

    private GetUserOptionInfo _userOption;
		private GetOrderCountInfo _orderCount;

		public GetUserOptionInfo UserOption
		{
			get { return this._userOption; }
			set { this._userOption = value; }
		}

		public GetOrderCountInfo OrderCount
		{
			get { return this._orderCount; }
			set { this._orderCount = value; }
		}

		public OCS1003P01GetUserOptionAndOrderCountArgs() { }

		public OCS1003P01GetUserOptionAndOrderCountArgs(GetUserOptionInfo userOption, GetOrderCountInfo orderCount)
		{
			this._userOption = userOption;
			this._orderCount = orderCount;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003P01GetUserOptionAndOrderCountRequest();
		}
	}
}
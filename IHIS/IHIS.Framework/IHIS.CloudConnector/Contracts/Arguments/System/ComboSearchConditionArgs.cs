using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
	public class ComboSearchConditionArgs : IContractArgs
	{
	    protected bool Equals(ComboSearchConditionArgs other)
	    {
	        return string.Equals(_codeType, other._codeType);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((ComboSearchConditionArgs) obj);
	    }

	    public override int GetHashCode()
	    {
	        return (_codeType != null ? _codeType.GetHashCode() : 0);
	    }

	    private String _codeType;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public ComboSearchConditionArgs() { }

		public ComboSearchConditionArgs(String codeType)
		{
			this._codeType = codeType;
		}

		public IExtensible GetRequestInstance()
		{
			return new ComboSearchConditionRequest();
		}
	}
}
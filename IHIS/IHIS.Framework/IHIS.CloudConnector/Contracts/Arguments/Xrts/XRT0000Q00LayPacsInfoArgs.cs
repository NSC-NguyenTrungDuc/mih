using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{
    [Serializable]
	public class XRT0000Q00LayPacsInfoArgs : IContractArgs
	{
	    protected bool Equals(XRT0000Q00LayPacsInfoArgs other)
	    {
	        return string.Equals(_codeType, other._codeType);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((XRT0000Q00LayPacsInfoArgs) obj);
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

		public XRT0000Q00LayPacsInfoArgs() { }

		public XRT0000Q00LayPacsInfoArgs(String codeType)
		{
			this._codeType = codeType;
		}

		public IExtensible GetRequestInstance()
		{
			return new XRT0000Q00LayPacsInfoRequest();
		}
	}
}
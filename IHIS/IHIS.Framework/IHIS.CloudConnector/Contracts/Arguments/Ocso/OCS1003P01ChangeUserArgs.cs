using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003P01ChangeUserArgs : IContractArgs
	{
    protected bool Equals(OCS1003P01ChangeUserArgs other)
    {
        return string.Equals(_gwa, other._gwa);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003P01ChangeUserArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_gwa != null ? _gwa.GetHashCode() : 0);
    }

    private String _gwa;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public OCS1003P01ChangeUserArgs() { }

		public OCS1003P01ChangeUserArgs(String gwa)
		{
			this._gwa = gwa;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003P01ChangeUserRequest();
		}
	}
}
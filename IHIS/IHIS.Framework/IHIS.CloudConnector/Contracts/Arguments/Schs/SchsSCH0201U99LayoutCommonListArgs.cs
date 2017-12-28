using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201U99LayoutCommonListArgs : IContractArgs
	{
    protected bool Equals(SchsSCH0201U99LayoutCommonListArgs other)
    {
        return string.Equals(_doctor, other._doctor) && string.Equals(_fGwa, other._fGwa);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201U99LayoutCommonListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_doctor != null ? _doctor.GetHashCode() : 0)*397) ^ (_fGwa != null ? _fGwa.GetHashCode() : 0);
        }
    }

    private String _doctor;
		private String _fGwa;

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String FGwa
		{
			get { return this._fGwa; }
			set { this._fGwa = value; }
		}

		public SchsSCH0201U99LayoutCommonListArgs() { }

		public SchsSCH0201U99LayoutCommonListArgs(String doctor, String fGwa)
		{
			this._doctor = doctor;
			this._fGwa = fGwa;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201U99LayoutCommonListRequest();
		}
	}
}
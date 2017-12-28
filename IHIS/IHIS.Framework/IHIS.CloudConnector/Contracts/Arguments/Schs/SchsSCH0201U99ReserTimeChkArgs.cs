using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SchsSCH0201U99ReserTimeChkArgs : IContractArgs
	{
    protected bool Equals(SchsSCH0201U99ReserTimeChkArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_reserDate, other._reserDate) && string.Equals(_reserTime, other._reserTime) && string.Equals(_pksch0201, other._pksch0201);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SchsSCH0201U99ReserTimeChkArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserDate != null ? _reserDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_reserTime != null ? _reserTime.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pksch0201 != null ? _pksch0201.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
		private String _reserDate;
		private String _reserTime;
		private String _pksch0201;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String ReserTime
		{
			get { return this._reserTime; }
			set { this._reserTime = value; }
		}

		public String Pksch0201
		{
			get { return this._pksch0201; }
			set { this._pksch0201 = value; }
		}

		public SchsSCH0201U99ReserTimeChkArgs() { }

		public SchsSCH0201U99ReserTimeChkArgs(String bunho, String reserDate, String reserTime, String pksch0201)
		{
			this._bunho = bunho;
			this._reserDate = reserDate;
			this._reserTime = reserTime;
			this._pksch0201 = pksch0201;
		}

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201U99ReserTimeChkRequest();
		}
	}
}
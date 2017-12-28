using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OUTSANGU00findBoxToGwaArgs : IContractArgs
	{
    protected bool Equals(OUTSANGU00findBoxToGwaArgs other)
    {
        return string.Equals(_startDate, other._startDate) && string.Equals(_find1, other._find1);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUTSANGU00findBoxToGwaArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_startDate != null ? _startDate.GetHashCode() : 0)*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
        }
    }

    private String _startDate;
		private String _find1;

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public OUTSANGU00findBoxToGwaArgs() { }

		public OUTSANGU00findBoxToGwaArgs(String startDate, String find1)
		{
			this._startDate = startDate;
			this._find1 = find1;
		}

		public IExtensible GetRequestInstance()
		{
			return new OUTSANGU00findBoxToGwaRequest();
		}
	}
}
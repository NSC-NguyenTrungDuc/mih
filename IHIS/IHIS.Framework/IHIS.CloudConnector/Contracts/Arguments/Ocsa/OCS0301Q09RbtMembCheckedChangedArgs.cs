using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0301Q09RbtMembCheckedChangedArgs : IContractArgs
	{
    protected bool Equals(OCS0301Q09RbtMembCheckedChangedArgs other)
    {
        return string.Equals(_code, other._code) && string.Equals(_id, other._id) && string.Equals(_m0300, other._m0300) && string.Equals(_m0301, other._m0301) && string.Equals(_directPath, other._directPath) && string.Equals(_rbtName, other._rbtName);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0301Q09RbtMembCheckedChangedArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_code != null ? _code.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_id != null ? _id.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_m0300 != null ? _m0300.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_m0301 != null ? _m0301.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_directPath != null ? _directPath.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_rbtName != null ? _rbtName.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _code;
		private String _id;
		private String _m0300;
		private String _m0301;
		private String _directPath;
		private String _rbtName;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String Id
		{
			get { return this._id; }
			set { this._id = value; }
		}

		public String M0300
		{
			get { return this._m0300; }
			set { this._m0300 = value; }
		}

		public String M0301
		{
			get { return this._m0301; }
			set { this._m0301 = value; }
		}

		public String DirectPath
		{
			get { return this._directPath; }
			set { this._directPath = value; }
		}

		public String RbtName
		{
			get { return this._rbtName; }
			set { this._rbtName = value; }
		}

		public OCS0301Q09RbtMembCheckedChangedArgs() { }

		public OCS0301Q09RbtMembCheckedChangedArgs(String code, String id, String m0300, String m0301, String directPath, String rbtName)
		{
			this._code = code;
			this._id = id;
			this._m0300 = m0300;
			this._m0301 = m0301;
			this._directPath = directPath;
			this._rbtName = rbtName;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0301Q09RbtMembCheckedChangedRequest();
		}
	}
}
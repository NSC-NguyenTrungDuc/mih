using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U04EditBookmarkByPkout1001Args : IContractArgs
	{
    protected bool Equals(OCS2015U04EditBookmarkByPkout1001Args other)
    {
        return string.Equals(_bookmarkText, other._bookmarkText) && string.Equals(_updId, other._updId) && string.Equals(_emrBookmarkId, other._emrBookmarkId) && string.Equals(_pkout1001, other._pkout1001);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U04EditBookmarkByPkout1001Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bookmarkText != null ? _bookmarkText.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_updId != null ? _updId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_emrBookmarkId != null ? _emrBookmarkId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bookmarkText;
		private String _updId;
		private String _emrBookmarkId;
		private String _pkout1001;

		public String BookmarkText
		{
			get { return this._bookmarkText; }
			set { this._bookmarkText = value; }
		}

		public String UpdId
		{
			get { return this._updId; }
			set { this._updId = value; }
		}

		public String EmrBookmarkId
		{
			get { return this._emrBookmarkId; }
			set { this._emrBookmarkId = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public OCS2015U04EditBookmarkByPkout1001Args() { }

		public OCS2015U04EditBookmarkByPkout1001Args(String bookmarkText, String updId, String emrBookmarkId, String pkout1001)
		{
			this._bookmarkText = bookmarkText;
			this._updId = updId;
			this._emrBookmarkId = emrBookmarkId;
			this._pkout1001 = pkout1001;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U04EditBookmarkByPkout1001Request();
		}
	}
}
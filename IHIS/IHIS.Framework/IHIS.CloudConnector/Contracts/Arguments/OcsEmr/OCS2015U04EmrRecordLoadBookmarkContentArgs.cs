using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U04EmrRecordLoadBookmarkContentArgs : IContractArgs
	{
    protected bool Equals(OCS2015U04EmrRecordLoadBookmarkContentArgs other)
    {
        return string.Equals(_emrRecordId, other._emrRecordId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U04EmrRecordLoadBookmarkContentArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_emrRecordId != null ? _emrRecordId.GetHashCode() : 0);
    }

    private String _emrRecordId;

		public String EmrRecordId
		{
			get { return this._emrRecordId; }
			set { this._emrRecordId = value; }
		}

		public OCS2015U04EmrRecordLoadBookmarkContentArgs() { }

		public OCS2015U04EmrRecordLoadBookmarkContentArgs(String emrRecordId)
		{
			this._emrRecordId = emrRecordId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U04EmrRecordLoadBookmarkContentRequest();
		}
	}
}
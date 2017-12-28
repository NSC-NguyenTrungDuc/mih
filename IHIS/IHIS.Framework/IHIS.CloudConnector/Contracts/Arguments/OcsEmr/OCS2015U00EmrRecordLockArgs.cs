using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U00EmrRecordLockArgs : IContractArgs
	{
    protected bool Equals(OCS2015U00EmrRecordLockArgs other)
    {
        return string.Equals(_recordId, other._recordId) && string.Equals(_updId, other._updId) && string.Equals(_screenId, other._screenId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U00EmrRecordLockArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_recordId != null ? _recordId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_updId != null ? _updId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_screenId != null ? _screenId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _recordId;
		private String _updId;
		private String _screenId;

		public String RecordId
		{
			get { return this._recordId; }
			set { this._recordId = value; }
		}

		public String UpdId
		{
			get { return this._updId; }
			set { this._updId = value; }
		}

		public String ScreenId
		{
			get { return this._screenId; }
			set { this._screenId = value; }
		}

		public OCS2015U00EmrRecordLockArgs() { }

		public OCS2015U00EmrRecordLockArgs(String recordId, String updId, String screenId)
		{
			this._recordId = recordId;
			this._updId = updId;
			this._screenId = screenId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U00EmrRecordLockRequest();
		}
	}
}
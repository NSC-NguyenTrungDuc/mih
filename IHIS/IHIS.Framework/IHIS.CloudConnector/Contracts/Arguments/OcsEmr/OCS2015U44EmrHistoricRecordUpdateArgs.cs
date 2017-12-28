using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U44EmrHistoricRecordUpdateArgs : IContractArgs
	{
    protected bool Equals(OCS2015U44EmrHistoricRecordUpdateArgs other)
    {
        return string.Equals(_recordId, other._recordId) && string.Equals(_updId, other._updId) && string.Equals(_content, other._content) && string.Equals(_metadata, other._metadata) && string.Equals(_recordLog, other._recordLog) && string.Equals(_emailFlg, other._emailFlg);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U44EmrHistoricRecordUpdateArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_recordId != null ? _recordId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_updId != null ? _updId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_content != null ? _content.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_metadata != null ? _metadata.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_recordLog != null ? _recordLog.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_emailFlg != null ? _emailFlg.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _recordId;
		private String _updId;
		private String _content;
		private String _metadata;
		private String _recordLog;
		private String _emailFlg;

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

		public String Content
		{
			get { return this._content; }
			set { this._content = value; }
		}

		public String Metadata
		{
			get { return this._metadata; }
			set { this._metadata = value; }
		}

		public String RecordLog
		{
			get { return this._recordLog; }
			set { this._recordLog = value; }
		}

		public String EmailFlg
		{
			get { return this._emailFlg; }
			set { this._emailFlg = value; }
		}

		public OCS2015U44EmrHistoricRecordUpdateArgs() { }

		public OCS2015U44EmrHistoricRecordUpdateArgs(String recordId, String updId, String content, String metadata, String recordLog, String emailFlg)
		{
			this._recordId = recordId;
			this._updId = updId;
			this._content = content;
			this._metadata = metadata;
			this._recordLog = recordLog;
			this._emailFlg = emailFlg;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U44EmrHistoricRecordUpdateRequest();
		}
	}
}
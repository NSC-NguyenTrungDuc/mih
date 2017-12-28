using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U09EmrRecordUpdateArgs : IContractArgs
	{
    protected bool Equals(OCS2015U09EmrRecordUpdateArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_content, other._content) && string.Equals(_metadata, other._metadata) && string.Equals(_sysId, other._sysId) && string.Equals(_recordLog, other._recordLog) && Equals(_bookmark, other._bookmark);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U09EmrRecordUpdateArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_content != null ? _content.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_metadata != null ? _metadata.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sysId != null ? _sysId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_recordLog != null ? _recordLog.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bookmark != null ? _bookmark.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
		private String _content;
		private String _metadata;
		private String _sysId;
		private String _recordLog;
        private List<IHIS.CloudConnector.Contracts.Models.OcsEmr.OCS2015U09EmrBookmarkInfo> _bookmark = new List<IHIS.CloudConnector.Contracts.Models.OcsEmr.OCS2015U09EmrBookmarkInfo>();

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
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

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public String RecordLog
		{
			get { return this._recordLog; }
			set { this._recordLog = value; }
		}

        public List<IHIS.CloudConnector.Contracts.Models.OcsEmr.OCS2015U09EmrBookmarkInfo> Bookmark
		{
			get { return this._bookmark; }
			set { this._bookmark = value; }
		}

		public OCS2015U09EmrRecordUpdateArgs() { }

        public OCS2015U09EmrRecordUpdateArgs(String bunho, String content, String metadata, String sysId, String recordLog, List<IHIS.CloudConnector.Contracts.Models.OcsEmr.OCS2015U09EmrBookmarkInfo> bookmark)
		{
			this._bunho = bunho;
			this._content = content;
			this._metadata = metadata;
			this._sysId = sysId;
			this._recordLog = recordLog;
			this._bookmark = bookmark;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U09EmrRecordUpdateRequest();
		}
	}
}
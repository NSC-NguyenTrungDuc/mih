using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{[Serializable]
	public class OCS2015U07EmrRecordInsertArgs : IContractArgs
	{
    protected bool Equals(OCS2015U07EmrRecordInsertArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_bunho, other._bunho) && string.Equals(_pkout1001, other._pkout1001) && string.Equals(_naewonDate, other._naewonDate) && string.Equals(_content, other._content) && string.Equals(_metadata, other._metadata) && string.Equals(_version, other._version) && string.Equals(_sysId, other._sysId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS2015U07EmrRecordInsertArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_content != null ? _content.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_metadata != null ? _metadata.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_version != null ? _version.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sysId != null ? _sysId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _hospCode;
		private String _bunho;
		private String _pkout1001;
		private String _naewonDate;
		private String _content;
		private String _metadata;
		private String _version;
		private String _sysId;

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
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

		public String Version
		{
			get { return this._version; }
			set { this._version = value; }
		}

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public OCS2015U07EmrRecordInsertArgs() { }

		public OCS2015U07EmrRecordInsertArgs(String hospCode, String bunho, String pkout1001, String naewonDate, String content, String metadata, String version, String sysId)
		{
			this._hospCode = hospCode;
			this._bunho = bunho;
			this._pkout1001 = pkout1001;
			this._naewonDate = naewonDate;
			this._content = content;
			this._metadata = metadata;
			this._version = version;
			this._sysId = sysId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U07EmrRecordInsertRequest();
		}
	}
}
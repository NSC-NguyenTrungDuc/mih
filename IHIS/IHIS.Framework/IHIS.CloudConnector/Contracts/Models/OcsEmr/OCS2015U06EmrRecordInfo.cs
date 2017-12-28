using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
	public class OCS2015U06EmrRecordInfo
	{
		private String _recordId;
		private String _bunho;
		private String _pkout1001;
		private String _naewonDate;
		private String _content;
		private String _metadata;
		private String _version;
		private String _created;
		private String _updated;
		private String _gwa;

		public String RecordId
		{
			get { return this._recordId; }
			set { this._recordId = value; }
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

		public String Created
		{
			get { return this._created; }
			set { this._created = value; }
		}

		public String Updated
		{
			get { return this._updated; }
			set { this._updated = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public OCS2015U06EmrRecordInfo() { }

		public OCS2015U06EmrRecordInfo(String recordId, String bunho, String pkout1001, String naewonDate, String content, String metadata, String version, String created, String updated, String gwa)
		{
			this._recordId = recordId;
			this._bunho = bunho;
			this._pkout1001 = pkout1001;
			this._naewonDate = naewonDate;
			this._content = content;
			this._metadata = metadata;
			this._version = version;
			this._created = created;
			this._updated = updated;
			this._gwa = gwa;
		}

	}
}
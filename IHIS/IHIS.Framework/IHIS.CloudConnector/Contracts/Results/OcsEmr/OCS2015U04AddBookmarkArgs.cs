using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.OcsEmr
{
    [Serializable]
	public class OCS2015U04AddBookmarkArgs : IContractArgs
	{
		private String _emrRecordId;
		private String _bookmarkText;
		private String _naewonDate;
		private String _pkout1001;
		private String _updId;

		public String EmrRecordId
		{
			get { return this._emrRecordId; }
			set { this._emrRecordId = value; }
		}

		public String BookmarkText
		{
			get { return this._bookmarkText; }
			set { this._bookmarkText = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public String UpdId
		{
			get { return this._updId; }
			set { this._updId = value; }
		}

		public OCS2015U04AddBookmarkArgs() { }

		public OCS2015U04AddBookmarkArgs(String emrRecordId, String bookmarkText, String naewonDate, String pkout1001, String updId)
		{
			this._emrRecordId = emrRecordId;
			this._bookmarkText = bookmarkText;
			this._naewonDate = naewonDate;
			this._pkout1001 = pkout1001;
			this._updId = updId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS2015U04AddBookmarkRequest();
		}
	}
}
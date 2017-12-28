using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
	public class OCS2015U04LoadBookmarkByPk0ut1001Info
	{
		private String _emrBookmarkId;
		private String _emrRecordId;
		private String _pkout1001;
		private String _bookmarkText;
		private String _naewonDate;
		private String _sysId;
		private String _updId;
		private String _created;
		private String _updated;
		private String _activeFlg;

		public String EmrBookmarkId
		{
			get { return this._emrBookmarkId; }
			set { this._emrBookmarkId = value; }
		}

		public String EmrRecordId
		{
			get { return this._emrRecordId; }
			set { this._emrRecordId = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
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

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public String UpdId
		{
			get { return this._updId; }
			set { this._updId = value; }
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

		public String ActiveFlg
		{
			get { return this._activeFlg; }
			set { this._activeFlg = value; }
		}

		public OCS2015U04LoadBookmarkByPk0ut1001Info() { }

		public OCS2015U04LoadBookmarkByPk0ut1001Info(String emrBookmarkId, String emrRecordId, String pkout1001, String bookmarkText, String naewonDate, String sysId, String updId, String created, String updated, String activeFlg)
		{
			this._emrBookmarkId = emrBookmarkId;
			this._emrRecordId = emrRecordId;
			this._pkout1001 = pkout1001;
			this._bookmarkText = bookmarkText;
			this._naewonDate = naewonDate;
			this._sysId = sysId;
			this._updId = updId;
			this._created = created;
			this._updated = updated;
			this._activeFlg = activeFlg;
		}

	}
}
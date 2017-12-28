using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
	public class OCS2015U06EmrTagInfo
	{
		private String _tagId;
		private String _tagCode;
		private String _tagName;
		private String _tagLevel;
		private String _tagParent;
		private String _description;
		private String _userId;
		private String _filterFlg;
		private String _created;
		private String _updated;

		public String TagId
		{
			get { return this._tagId; }
			set { this._tagId = value; }
		}

		public String TagCode
		{
			get { return this._tagCode; }
			set { this._tagCode = value; }
		}

		public String TagName
		{
			get { return this._tagName; }
			set { this._tagName = value; }
		}

		public String TagLevel
		{
			get { return this._tagLevel; }
			set { this._tagLevel = value; }
		}

		public String TagParent
		{
			get { return this._tagParent; }
			set { this._tagParent = value; }
		}

		public String Description
		{
			get { return this._description; }
			set { this._description = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String FilterFlg
		{
			get { return this._filterFlg; }
			set { this._filterFlg = value; }
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

		public OCS2015U06EmrTagInfo() { }

		public OCS2015U06EmrTagInfo(String tagId, String tagCode, String tagName, String tagLevel, String tagParent, String description, String userId, String filterFlg, String created, String updated)
		{
			this._tagId = tagId;
			this._tagCode = tagCode;
			this._tagName = tagName;
			this._tagLevel = tagLevel;
			this._tagParent = tagParent;
			this._description = description;
			this._userId = userId;
			this._filterFlg = filterFlg;
			this._created = created;
			this._updated = updated;
		}

	}
}
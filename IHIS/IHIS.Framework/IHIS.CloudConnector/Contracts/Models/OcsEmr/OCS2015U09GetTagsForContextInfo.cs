using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
	public class OCS2015U09GetTagsForContextInfo
	{
		private String _emrTagId;
		private String _tagCode;
		private String _tagName;
		private String _tagLevel;
		private String _tagDisplayText;
		private String _tagParent;
		private String _description;
		private String _permissionType;
		private String _sysId;
		private String _updId;

		public String EmrTagId
		{
			get { return this._emrTagId; }
			set { this._emrTagId = value; }
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

		public String TagDisplayText
		{
			get { return this._tagDisplayText; }
			set { this._tagDisplayText = value; }
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

		public String PermissionType
		{
			get { return this._permissionType; }
			set { this._permissionType = value; }
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

		public OCS2015U09GetTagsForContextInfo() { }

		public OCS2015U09GetTagsForContextInfo(String emrTagId, String tagCode, String tagName, String tagLevel, String tagDisplayText, String tagParent, String description, String permissionType, String sysId, String updId)
		{
			this._emrTagId = emrTagId;
			this._tagCode = tagCode;
			this._tagName = tagName;
			this._tagLevel = tagLevel;
			this._tagDisplayText = tagDisplayText;
			this._tagParent = tagParent;
			this._description = description;
			this._permissionType = permissionType;
			this._sysId = sysId;
			this._updId = updId;
		}

	}
}
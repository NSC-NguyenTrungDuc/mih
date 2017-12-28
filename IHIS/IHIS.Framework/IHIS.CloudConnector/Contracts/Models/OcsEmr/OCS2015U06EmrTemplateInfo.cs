using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
	public class OCS2015U06EmrTemplateInfo
	{
		private String _templateId;
		private String _templateTypeId;
		private String _templateCode;
		private String _templateName;
		private String _templateContent;
		private String _description;
		private String _gwa;
		private String _userId;
		private String _permissionType;
		private String _created;
		private String _updated;

		public String TemplateId
		{
			get { return this._templateId; }
			set { this._templateId = value; }
		}

		public String TemplateTypeId
		{
			get { return this._templateTypeId; }
			set { this._templateTypeId = value; }
		}

		public String TemplateCode
		{
			get { return this._templateCode; }
			set { this._templateCode = value; }
		}

		public String TemplateName
		{
			get { return this._templateName; }
			set { this._templateName = value; }
		}

		public String TemplateContent
		{
			get { return this._templateContent; }
			set { this._templateContent = value; }
		}

		public String Description
		{
			get { return this._description; }
			set { this._description = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String PermissionType
		{
			get { return this._permissionType; }
			set { this._permissionType = value; }
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

		public OCS2015U06EmrTemplateInfo() { }

		public OCS2015U06EmrTemplateInfo(String templateId, String templateTypeId, String templateCode, String templateName, String templateContent, String description, String gwa, String userId, String permissionType, String created, String updated)
		{
			this._templateId = templateId;
			this._templateTypeId = templateTypeId;
			this._templateCode = templateCode;
			this._templateName = templateName;
			this._templateContent = templateContent;
			this._description = description;
			this._gwa = gwa;
			this._userId = userId;
			this._permissionType = permissionType;
			this._created = created;
			this._updated = updated;
		}

	}
}
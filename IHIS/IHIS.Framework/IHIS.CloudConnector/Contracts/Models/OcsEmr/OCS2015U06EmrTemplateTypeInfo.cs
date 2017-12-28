using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
	public class OCS2015U06EmrTemplateTypeInfo
	{
		private String _templateTypeId;
		private String _typeCode;
		private String _typeName;
		private String _typeTag;
		private String _description;
		private String _activeFlg;
		private String _created;
		private String _updated;

		public String TemplateTypeId
		{
			get { return this._templateTypeId; }
			set { this._templateTypeId = value; }
		}

		public String TypeCode
		{
			get { return this._typeCode; }
			set { this._typeCode = value; }
		}

		public String TypeName
		{
			get { return this._typeName; }
			set { this._typeName = value; }
		}

		public String TypeTag
		{
			get { return this._typeTag; }
			set { this._typeTag = value; }
		}

		public String Description
		{
			get { return this._description; }
			set { this._description = value; }
		}

		public String ActiveFlg
		{
			get { return this._activeFlg; }
			set { this._activeFlg = value; }
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

		public OCS2015U06EmrTemplateTypeInfo() { }

		public OCS2015U06EmrTemplateTypeInfo(String templateTypeId, String typeCode, String typeName, String typeTag, String description, String activeFlg, String created, String updated)
		{
			this._templateTypeId = templateTypeId;
			this._typeCode = typeCode;
			this._typeName = typeName;
			this._typeTag = typeTag;
			this._description = description;
			this._activeFlg = activeFlg;
			this._created = created;
			this._updated = updated;
		}

	}
}
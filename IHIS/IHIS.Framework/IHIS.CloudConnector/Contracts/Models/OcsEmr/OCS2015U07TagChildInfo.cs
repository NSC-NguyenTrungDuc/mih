using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
	public class OCS2015U07TagChildInfo
	{
		private String _tagCode;
		private String _tagName;
		private String _tagDisplayText;

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

		public String TagDisplayText
		{
			get { return this._tagDisplayText; }
			set { this._tagDisplayText = value; }
		}

		public OCS2015U07TagChildInfo() { }

		public OCS2015U07TagChildInfo(String tagCode, String tagName, String tagDisplayText)
		{
			this._tagCode = tagCode;
			this._tagName = tagName;
			this._tagDisplayText = tagDisplayText;
		}

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class InjsINJ1001U01AllergyListItemInfo
	{
		private String _allergyInfo;

		public String AllergyInfo
		{
			get { return this._allergyInfo; }
			set { this._allergyInfo = value; }
		}

		public InjsINJ1001U01AllergyListItemInfo() { }

		public InjsINJ1001U01AllergyListItemInfo(String allergyInfo)
		{
			this._allergyInfo = allergyInfo;
		}

	}
}
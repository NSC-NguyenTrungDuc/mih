using System;

namespace IHIS.CloudConnector.Contracts.Models.Chts
{
    [Serializable]
	public class CHT0115Q00GrdScInfo
	{
		private String _susikCode;
		private String _susikName;
		private String _susikNameGana;
		private String _susikDetailGubun;

		public String SusikCode
		{
			get { return this._susikCode; }
			set { this._susikCode = value; }
		}

		public String SusikName
		{
			get { return this._susikName; }
			set { this._susikName = value; }
		}

		public String SusikNameGana
		{
			get { return this._susikNameGana; }
			set { this._susikNameGana = value; }
		}

		public String SusikDetailGubun
		{
			get { return this._susikDetailGubun; }
			set { this._susikDetailGubun = value; }
		}

		public CHT0115Q00GrdScInfo() { }

		public CHT0115Q00GrdScInfo(String susikCode, String susikName, String susikNameGana, String susikDetailGubun)
		{
			this._susikCode = susikCode;
			this._susikName = susikName;
			this._susikNameGana = susikNameGana;
			this._susikDetailGubun = susikDetailGubun;
		}

	}
}
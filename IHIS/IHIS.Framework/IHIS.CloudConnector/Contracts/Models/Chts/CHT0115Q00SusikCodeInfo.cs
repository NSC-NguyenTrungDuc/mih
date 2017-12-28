using System;

namespace IHIS.CloudConnector.Contracts.Models.Chts
{
    [Serializable]
	public class CHT0115Q00SusikCodeInfo
	{
		private String _susikName;
		private String _susikNameGana;
		private String _susikDetailGubun;

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

		public CHT0115Q00SusikCodeInfo() { }

		public CHT0115Q00SusikCodeInfo(String susikName, String susikNameGana, String susikDetailGubun)
		{
			this._susikName = susikName;
			this._susikNameGana = susikNameGana;
			this._susikDetailGubun = susikDetailGubun;
		}

	}
}
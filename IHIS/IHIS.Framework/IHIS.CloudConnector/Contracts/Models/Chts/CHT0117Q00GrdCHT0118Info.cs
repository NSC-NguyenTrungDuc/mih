using System;

namespace IHIS.CloudConnector.Contracts.Models.Chts
{
    [Serializable]
	public class CHT0117Q00GrdCHT0118Info
	{
		private String _buwi;
		private String _subBuwi;
		private String _subBuwiName;
		private String _contKey;

		public String Buwi
		{
			get { return this._buwi; }
			set { this._buwi = value; }
		}

		public String SubBuwi
		{
			get { return this._subBuwi; }
			set { this._subBuwi = value; }
		}

		public String SubBuwiName
		{
			get { return this._subBuwiName; }
			set { this._subBuwiName = value; }
		}

		public String ContKey
		{
			get { return this._contKey; }
			set { this._contKey = value; }
		}

		public CHT0117Q00GrdCHT0118Info() { }

		public CHT0117Q00GrdCHT0118Info(String buwi, String subBuwi, String subBuwiName, String contKey)
		{
			this._buwi = buwi;
			this._subBuwi = subBuwi;
			this._subBuwiName = subBuwiName;
			this._contKey = contKey;
		}

	}
}
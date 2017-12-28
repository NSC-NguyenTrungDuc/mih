using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SCH0201Q12UpdateReserData
	{
		private String _pkinj1002;
		private String _fksch0201;
		private String _reserTime;

		public String Pkinj1002
		{
			get { return this._pkinj1002; }
			set { this._pkinj1002 = value; }
		}

		public String Fksch0201
		{
			get { return this._fksch0201; }
			set { this._fksch0201 = value; }
		}

		public String ReserTime
		{
			get { return this._reserTime; }
			set { this._reserTime = value; }
		}

		public SCH0201Q12UpdateReserData() { }

		public SCH0201Q12UpdateReserData(String pkinj1002, String fksch0201, String reserTime)
		{
			this._pkinj1002 = pkinj1002;
			this._fksch0201 = fksch0201;
			this._reserTime = reserTime;
		}

	}
}
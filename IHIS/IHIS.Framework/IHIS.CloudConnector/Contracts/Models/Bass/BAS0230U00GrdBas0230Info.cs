using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
	public class BAS0230U00GrdBas0230Info
	{
		private String _bunCode;
		private String _bunName;
		private String _bunYmd;
		private String _dataRowState;

		public String BunCode
		{
			get { return this._bunCode; }
			set { this._bunCode = value; }
		}

		public String BunName
		{
			get { return this._bunName; }
			set { this._bunName = value; }
		}

		public String BunYmd
		{
			get { return this._bunYmd; }
			set { this._bunYmd = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public BAS0230U00GrdBas0230Info() { }

		public BAS0230U00GrdBas0230Info(String bunCode, String bunName, String bunYmd, String dataRowState)
		{
			this._bunCode = bunCode;
			this._bunName = bunName;
			this._bunYmd = bunYmd;
			this._dataRowState = dataRowState;
		}

	}
}
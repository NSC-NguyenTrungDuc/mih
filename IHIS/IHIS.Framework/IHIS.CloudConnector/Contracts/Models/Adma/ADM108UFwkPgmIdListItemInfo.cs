using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
	public class ADM108UFwkPgmIdListItemInfo
	{
		private String _pgmId;
		private String _pgmNm;
		private String _sysId;
		private String _sysNm;

		public String PgmId
		{
			get { return this._pgmId; }
			set { this._pgmId = value; }
		}

		public String PgmNm
		{
			get { return this._pgmNm; }
			set { this._pgmNm = value; }
		}

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public String SysNm
		{
			get { return this._sysNm; }
			set { this._sysNm = value; }
		}

		public ADM108UFwkPgmIdListItemInfo() { }

		public ADM108UFwkPgmIdListItemInfo(String pgmId, String pgmNm, String sysId, String sysNm)
		{
			this._pgmId = pgmId;
			this._pgmNm = pgmNm;
			this._sysId = sysId;
			this._sysNm = sysNm;
		}

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
	public class MdiFormMainMenuItemInfo
	{
		private String _pgmSysId;
		private String _pgmId;

		public String PgmSysId
		{
			get { return this._pgmSysId; }
			set { this._pgmSysId = value; }
		}

		public String PgmId
		{
			get { return this._pgmId; }
			set { this._pgmId = value; }
		}

		public MdiFormMainMenuItemInfo() { }

		public MdiFormMainMenuItemInfo(String pgmSysId, String pgmId)
		{
			this._pgmSysId = pgmSysId;
			this._pgmId = pgmId;
		}

	}
}
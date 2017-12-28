using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
	public class MenuViewFormItemInfo
	{
		private String _menuTp;
		private String _menuLevel;
		private String _trId;
		private String _menuTitle;
		private String _pgmId;
		private String _pgmOpenTp;
		private String _menuParam;

		public String MenuTp
		{
			get { return this._menuTp; }
			set { this._menuTp = value; }
		}

		public String MenuLevel
		{
			get { return this._menuLevel; }
			set { this._menuLevel = value; }
		}

		public String TrId
		{
			get { return this._trId; }
			set { this._trId = value; }
		}

		public String MenuTitle
		{
			get { return this._menuTitle; }
			set { this._menuTitle = value; }
		}

		public String PgmId
		{
			get { return this._pgmId; }
			set { this._pgmId = value; }
		}

		public String PgmOpenTp
		{
			get { return this._pgmOpenTp; }
			set { this._pgmOpenTp = value; }
		}

		public String MenuParam
		{
			get { return this._menuParam; }
			set { this._menuParam = value; }
		}

		public MenuViewFormItemInfo() { }

		public MenuViewFormItemInfo(String menuTp, String menuLevel, String trId, String menuTitle, String pgmId, String pgmOpenTp, String menuParam)
		{
			this._menuTp = menuTp;
			this._menuLevel = menuLevel;
			this._trId = trId;
			this._menuTitle = menuTitle;
			this._pgmId = pgmId;
			this._pgmOpenTp = pgmOpenTp;
			this._menuParam = menuParam;
		}

	}
}
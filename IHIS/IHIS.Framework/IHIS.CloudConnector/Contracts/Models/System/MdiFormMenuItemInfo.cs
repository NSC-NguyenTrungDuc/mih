using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
	public class MdiFormMenuItemInfo
	{
		private String _menuLevel;
		private String _menuTp;
		private String _pgmNm;
		private String _trId;
		private String _pgmId;
		private String _pgmSysId;
		private String _pgmEntGrad;
		private String _pgmUpdGrad;
		private String _pgmScrt;
		private String _pgmDupYn;
		private String _pgmOpenTp;
		private String _shortCut;
		private String _asmName;
		private String _asmPath;
		private String _asmVer;
		private String _menuParam;

		public String MenuLevel
		{
			get { return this._menuLevel; }
			set { this._menuLevel = value; }
		}

		public String MenuTp
		{
			get { return this._menuTp; }
			set { this._menuTp = value; }
		}

		public String PgmNm
		{
			get { return this._pgmNm; }
			set { this._pgmNm = value; }
		}

		public String TrId
		{
			get { return this._trId; }
			set { this._trId = value; }
		}

		public String PgmId
		{
			get { return this._pgmId; }
			set { this._pgmId = value; }
		}

		public String PgmSysId
		{
			get { return this._pgmSysId; }
			set { this._pgmSysId = value; }
		}

		public String PgmEntGrad
		{
			get { return this._pgmEntGrad; }
			set { this._pgmEntGrad = value; }
		}

		public String PgmUpdGrad
		{
			get { return this._pgmUpdGrad; }
			set { this._pgmUpdGrad = value; }
		}

		public String PgmScrt
		{
			get { return this._pgmScrt; }
			set { this._pgmScrt = value; }
		}

		public String PgmDupYn
		{
			get { return this._pgmDupYn; }
			set { this._pgmDupYn = value; }
		}

		public String PgmOpenTp
		{
			get { return this._pgmOpenTp; }
			set { this._pgmOpenTp = value; }
		}

		public String ShortCut
		{
			get { return this._shortCut; }
			set { this._shortCut = value; }
		}

		public String AsmName
		{
			get { return this._asmName; }
			set { this._asmName = value; }
		}

		public String AsmPath
		{
			get { return this._asmPath; }
			set { this._asmPath = value; }
		}

		public String AsmVer
		{
			get { return this._asmVer; }
			set { this._asmVer = value; }
		}

		public String MenuParam
		{
			get { return this._menuParam; }
			set { this._menuParam = value; }
		}

		public MdiFormMenuItemInfo() { }

		public MdiFormMenuItemInfo(String menuLevel, String menuTp, String pgmNm, String trId, String pgmId, String pgmSysId, String pgmEntGrad, String pgmUpdGrad, String pgmScrt, String pgmDupYn, String pgmOpenTp, String shortCut, String asmName, String asmPath, String asmVer, String menuParam)
		{
			this._menuLevel = menuLevel;
			this._menuTp = menuTp;
			this._pgmNm = pgmNm;
			this._trId = trId;
			this._pgmId = pgmId;
			this._pgmSysId = pgmSysId;
			this._pgmEntGrad = pgmEntGrad;
			this._pgmUpdGrad = pgmUpdGrad;
			this._pgmScrt = pgmScrt;
			this._pgmDupYn = pgmDupYn;
			this._pgmOpenTp = pgmOpenTp;
			this._shortCut = shortCut;
			this._asmName = asmName;
			this._asmPath = asmPath;
			this._asmVer = asmVer;
			this._menuParam = menuParam;
		}

	}
}
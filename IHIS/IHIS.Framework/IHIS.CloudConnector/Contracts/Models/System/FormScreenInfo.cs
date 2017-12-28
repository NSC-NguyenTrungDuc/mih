using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
	public class FormScreenInfo
	{
		private String _sysId;
		private String _pgmNm;
		private String _pgmEntGrad;
		private String _pgmUpdGrad;
		private String _pgmScrt;
		private String _pgmDupYn;
		private String _asmName;
		private String _asmPath;
		private String _asmVer;
		private String _grpId;

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public String PgmNm
		{
			get { return this._pgmNm; }
			set { this._pgmNm = value; }
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

		public String GrpId
		{
			get { return this._grpId; }
			set { this._grpId = value; }
		}

		public FormScreenInfo() { }

		public FormScreenInfo(String sysId, String pgmNm, String pgmEntGrad, String pgmUpdGrad, String pgmScrt, String pgmDupYn, String asmName, String asmPath, String asmVer, String grpId)
		{
			this._sysId = sysId;
			this._pgmNm = pgmNm;
			this._pgmEntGrad = pgmEntGrad;
			this._pgmUpdGrad = pgmUpdGrad;
			this._pgmScrt = pgmScrt;
			this._pgmDupYn = pgmDupYn;
			this._asmName = asmName;
			this._asmPath = asmPath;
			this._asmVer = asmVer;
			this._grpId = grpId;
		}

	}
}
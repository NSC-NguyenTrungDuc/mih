using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
	public class ADM401UAsmItemInfo
	{
		private String _asmType;
		private String _grpId;
		private String _sysId;

		public String AsmType
		{
			get { return this._asmType; }
			set { this._asmType = value; }
		}

		public String GrpId
		{
			get { return this._grpId; }
			set { this._grpId = value; }
		}

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public ADM401UAsmItemInfo() { }

		public ADM401UAsmItemInfo(String asmType, String grpId, String sysId)
		{
			this._asmType = asmType;
			this._grpId = grpId;
			this._sysId = sysId;
		}

	}
}
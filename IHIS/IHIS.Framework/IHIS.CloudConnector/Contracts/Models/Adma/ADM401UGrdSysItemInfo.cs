using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
	public class ADM401UGrdSysItemInfo
	{
		private String _sysId;
		private String _sysNm;
		private String _admSysYn;
		private String _msgSysYn;

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

		public String AdmSysYn
		{
			get { return this._admSysYn; }
			set { this._admSysYn = value; }
		}

		public String MsgSysYn
		{
			get { return this._msgSysYn; }
			set { this._msgSysYn = value; }
		}

		public ADM401UGrdSysItemInfo() { }

		public ADM401UGrdSysItemInfo(String sysId, String sysNm, String admSysYn, String msgSysYn)
		{
			this._sysId = sysId;
			this._sysNm = sysNm;
			this._admSysYn = admSysYn;
			this._msgSysYn = msgSysYn;
		}

	}
}
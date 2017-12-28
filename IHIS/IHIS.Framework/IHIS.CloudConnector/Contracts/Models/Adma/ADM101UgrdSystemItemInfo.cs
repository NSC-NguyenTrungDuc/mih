using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
	public class ADM101UgrdSystemItemInfo
	{
		private String _grpId;
		private String _sysId;
		private String _sysNm;
		private String _sysSeq;
		private String _admSysYn;
		private String _msgSysYn;
		private String _sysDesc;
		private String _mangDept;
		private String _buseoName1;
		private String _mangDept1;
		private String _buseoName2;
		private String _dataRowState;

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

		public String SysNm
		{
			get { return this._sysNm; }
			set { this._sysNm = value; }
		}

		public String SysSeq
		{
			get { return this._sysSeq; }
			set { this._sysSeq = value; }
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

		public String SysDesc
		{
			get { return this._sysDesc; }
			set { this._sysDesc = value; }
		}

		public String MangDept
		{
			get { return this._mangDept; }
			set { this._mangDept = value; }
		}

		public String BuseoName1
		{
			get { return this._buseoName1; }
			set { this._buseoName1 = value; }
		}

		public String MangDept1
		{
			get { return this._mangDept1; }
			set { this._mangDept1 = value; }
		}

		public String BuseoName2
		{
			get { return this._buseoName2; }
			set { this._buseoName2 = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public ADM101UgrdSystemItemInfo() { }

		public ADM101UgrdSystemItemInfo(String grpId, String sysId, String sysNm, String sysSeq, String admSysYn, String msgSysYn, String sysDesc, String mangDept, String buseoName1, String mangDept1, String buseoName2, String dataRowState)
		{
			this._grpId = grpId;
			this._sysId = sysId;
			this._sysNm = sysNm;
			this._sysSeq = sysSeq;
			this._admSysYn = admSysYn;
			this._msgSysYn = msgSysYn;
			this._sysDesc = sysDesc;
			this._mangDept = mangDept;
			this._buseoName1 = buseoName1;
			this._mangDept1 = mangDept1;
			this._buseoName2 = buseoName2;
			this._dataRowState = dataRowState;
		}

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
	public class ADM108UGrdListItemInfo
	{
		private String _sysId;
		private String _seq;
		private String _pgmSysId;
		private String _sysNm;
		private String _pgmId;
		private String _pgmNm;
		private String _dataRowState;
		private String _newSeq;

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public String PgmSysId
		{
			get { return this._pgmSysId; }
			set { this._pgmSysId = value; }
		}

		public String SysNm
		{
			get { return this._sysNm; }
			set { this._sysNm = value; }
		}

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

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public String NewSeq
		{
			get { return this._newSeq; }
			set { this._newSeq = value; }
		}

		public ADM108UGrdListItemInfo() { }

		public ADM108UGrdListItemInfo(String sysId, String seq, String pgmSysId, String sysNm, String pgmId, String pgmNm, String dataRowState, String newSeq)
		{
			this._sysId = sysId;
			this._seq = seq;
			this._pgmSysId = pgmSysId;
			this._sysNm = sysNm;
			this._pgmId = pgmId;
			this._pgmNm = pgmNm;
			this._dataRowState = dataRowState;
			this._newSeq = newSeq;
		}

	}
}
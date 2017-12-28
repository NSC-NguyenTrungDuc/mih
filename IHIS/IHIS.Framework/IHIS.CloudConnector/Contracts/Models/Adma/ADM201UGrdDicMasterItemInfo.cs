using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
	public class ADM201UGrdDicMasterItemInfo
	{
		private String _colId;
		private String _colNm;
		private String _colTp;
		private String _colLen;
		private String _colScal;
		private String _cmmt;
		private String _dataRowState;

		public String ColId
		{
			get { return this._colId; }
			set { this._colId = value; }
		}

		public String ColNm
		{
			get { return this._colNm; }
			set { this._colNm = value; }
		}

		public String ColTp
		{
			get { return this._colTp; }
			set { this._colTp = value; }
		}

		public String ColLen
		{
			get { return this._colLen; }
			set { this._colLen = value; }
		}

		public String ColScal
		{
			get { return this._colScal; }
			set { this._colScal = value; }
		}

		public String Cmmt
		{
			get { return this._cmmt; }
			set { this._cmmt = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public ADM201UGrdDicMasterItemInfo() { }

		public ADM201UGrdDicMasterItemInfo(String colId, String colNm, String colTp, String colLen, String colScal, String cmmt, String dataRowState)
		{
			this._colId = colId;
			this._colNm = colNm;
			this._colTp = colTp;
			this._colLen = colLen;
			this._colScal = colScal;
			this._cmmt = cmmt;
			this._dataRowState = dataRowState;
		}

	}
}
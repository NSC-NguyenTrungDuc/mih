using System;

namespace IHIS.CloudConnector.Contracts.Models.Adma
{
    [Serializable]
	public class ADM201UGrdDicDetailItemInfo
	{
		private String _colId;
		private String _code;
		private String _codeNm;
		private String _dataRowState;

		public String ColId
		{
			get { return this._colId; }
			set { this._colId = value; }
		}

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String CodeNm
		{
			get { return this._codeNm; }
			set { this._codeNm = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public ADM201UGrdDicDetailItemInfo() { }

		public ADM201UGrdDicDetailItemInfo(String colId, String code, String codeNm, String dataRowState)
		{
			this._colId = colId;
			this._code = code;
			this._codeNm = codeNm;
			this._dataRowState = dataRowState;
		}

	}
}
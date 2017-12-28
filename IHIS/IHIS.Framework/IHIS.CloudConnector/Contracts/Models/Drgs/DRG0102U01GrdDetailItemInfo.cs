using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DRG0102U01GrdDetailItemInfo
	{
		private String _codeType;
		private String _code;
		private String _code2;
		private String _codeName;
		private String _codeValue;
		private String _remark;
		private String _dataRowState;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String Code2
		{
			get { return this._code2; }
			set { this._code2 = value; }
		}

		public String CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public String CodeValue
		{
			get { return this._codeValue; }
			set { this._codeValue = value; }
		}

		public String Remark
		{
			get { return this._remark; }
			set { this._remark = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public DRG0102U01GrdDetailItemInfo() { }

		public DRG0102U01GrdDetailItemInfo(String codeType, String code, String code2, String codeName, String codeValue, String remark, String dataRowState)
		{
			this._codeType = codeType;
			this._code = code;
			this._code2 = code2;
			this._codeName = codeName;
			this._codeValue = codeValue;
			this._remark = remark;
			this._dataRowState = dataRowState;
		}

	}
}
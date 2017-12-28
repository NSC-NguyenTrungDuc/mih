using System;

namespace IHIS.CloudConnector.Contracts.Models.Phys
{
    [Serializable]
	public class PHY0001U00GrdOCS0132Info
	{
		private String _code;
		private String _codeName;
		private String _codeType;
		private String _ment;
		private String _rowState;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String Ment
		{
			get { return this._ment; }
			set { this._ment = value; }
		}

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public PHY0001U00GrdOCS0132Info() { }

		public PHY0001U00GrdOCS0132Info(String code, String codeName, String codeType, String ment, String rowState)
		{
			this._code = code;
			this._codeName = codeName;
			this._codeType = codeType;
			this._ment = ment;
			this._rowState = rowState;
		}

	}
}
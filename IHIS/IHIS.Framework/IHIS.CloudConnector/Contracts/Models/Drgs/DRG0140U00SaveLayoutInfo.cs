using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DRG0140U00SaveLayoutInfo
	{
		private String _code;
		private String _code1;
		private String _codeName;
		private String _codeName1;
		private String _rowState;
		private String _callerId;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String Code1
		{
			get { return this._code1; }
			set { this._code1 = value; }
		}

		public String CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public String CodeName1
		{
			get { return this._codeName1; }
			set { this._codeName1 = value; }
		}

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public String CallerId
		{
			get { return this._callerId; }
			set { this._callerId = value; }
		}

		public DRG0140U00SaveLayoutInfo() { }

		public DRG0140U00SaveLayoutInfo(String code, String code1, String codeName, String codeName1, String rowState, String callerId)
		{
			this._code = code;
			this._code1 = code1;
			this._codeName = codeName;
			this._codeName1 = codeName1;
			this._rowState = rowState;
			this._callerId = callerId;
		}

	}
}
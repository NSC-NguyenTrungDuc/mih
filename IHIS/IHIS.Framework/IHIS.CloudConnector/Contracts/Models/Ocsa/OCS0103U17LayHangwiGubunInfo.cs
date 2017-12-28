using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U17LayHangwiGubunInfo
	{
		private String _slipGubun;
		private String _slipGubunName;
		private String _slipCode;
		private String _slipName;
		private String _codeYn;
		private String _zeroValue;

		public String SlipGubun
		{
			get { return this._slipGubun; }
			set { this._slipGubun = value; }
		}

		public String SlipGubunName
		{
			get { return this._slipGubunName; }
			set { this._slipGubunName = value; }
		}

		public String SlipCode
		{
			get { return this._slipCode; }
			set { this._slipCode = value; }
		}

		public String SlipName
		{
			get { return this._slipName; }
			set { this._slipName = value; }
		}

		public String CodeYn
		{
			get { return this._codeYn; }
			set { this._codeYn = value; }
		}

		public String ZeroValue
		{
			get { return this._zeroValue; }
			set { this._zeroValue = value; }
		}

		public OCS0103U17LayHangwiGubunInfo() { }

		public OCS0103U17LayHangwiGubunInfo(String slipGubun, String slipGubunName, String slipCode, String slipName, String codeYn, String zeroValue)
		{
			this._slipGubun = slipGubun;
			this._slipGubunName = slipGubunName;
			this._slipCode = slipCode;
			this._slipName = slipName;
			this._codeYn = codeYn;
			this._zeroValue = zeroValue;
		}

	}
}
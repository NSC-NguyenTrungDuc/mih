using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U14LaySlipCodeTreeInfo
	{
		private String _slipGubun;
		private String _slipGubunName;
		private String _slipCode;
		private String _slipName;
		private String _pfeCodeYn;
		private String _zero;

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

		public String PfeCodeYn
		{
			get { return this._pfeCodeYn; }
			set { this._pfeCodeYn = value; }
		}

		public String Zero
		{
			get { return this._zero; }
			set { this._zero = value; }
		}

		public OCS0103U14LaySlipCodeTreeInfo() { }

		public OCS0103U14LaySlipCodeTreeInfo(String slipGubun, String slipGubunName, String slipCode, String slipName, String pfeCodeYn, String zero)
		{
			this._slipGubun = slipGubun;
			this._slipGubunName = slipGubunName;
			this._slipCode = slipCode;
			this._slipName = slipName;
			this._pfeCodeYn = pfeCodeYn;
			this._zero = zero;
		}

	}
}
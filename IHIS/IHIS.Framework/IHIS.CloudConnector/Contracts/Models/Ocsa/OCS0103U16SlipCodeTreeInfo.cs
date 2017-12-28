using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U16SlipCodeTreeInfo
	{
		private String _slipCode;
		private String _slipName;
		private String _xrayBuwi;
		private String _buwiName;
		private String _xrayCodeYn;
		private String _orderbykey;

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

		public String XrayBuwi
		{
			get { return this._xrayBuwi; }
			set { this._xrayBuwi = value; }
		}

		public String BuwiName
		{
			get { return this._buwiName; }
			set { this._buwiName = value; }
		}

		public String XrayCodeYn
		{
			get { return this._xrayCodeYn; }
			set { this._xrayCodeYn = value; }
		}

		public String Orderbykey
		{
			get { return this._orderbykey; }
			set { this._orderbykey = value; }
		}

		public OCS0103U16SlipCodeTreeInfo() { }

		public OCS0103U16SlipCodeTreeInfo(String slipCode, String slipName, String xrayBuwi, String buwiName, String xrayCodeYn, String orderbykey)
		{
			this._slipCode = slipCode;
			this._slipName = slipName;
			this._xrayBuwi = xrayBuwi;
			this._buwiName = buwiName;
			this._xrayCodeYn = xrayCodeYn;
			this._orderbykey = orderbykey;
		}

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0113U00LaySlipListItemInfo
	{
		private String _slipGubun;
		private String _slipGubunName;
		private String _slipCode;
		private String _slipName;

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

		public OCS0113U00LaySlipListItemInfo() { }

		public OCS0113U00LaySlipListItemInfo(String slipGubun, String slipGubunName, String slipCode, String slipName)
		{
			this._slipGubun = slipGubun;
			this._slipGubunName = slipGubunName;
			this._slipCode = slipCode;
			this._slipName = slipName;
		}

	}
}
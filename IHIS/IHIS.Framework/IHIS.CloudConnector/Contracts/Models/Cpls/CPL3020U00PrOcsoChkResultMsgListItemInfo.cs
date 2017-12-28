using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL3020U00PrOcsoChkResultMsgListItemInfo
	{
		private String _ipValue;
		private String _textValue;
		private String _errFlag;

		public String IpValue
		{
			get { return this._ipValue; }
			set { this._ipValue = value; }
		}

		public String TextValue
		{
			get { return this._textValue; }
			set { this._textValue = value; }
		}

		public String ErrFlag
		{
			get { return this._errFlag; }
			set { this._errFlag = value; }
		}

		public CPL3020U00PrOcsoChkResultMsgListItemInfo() { }

		public CPL3020U00PrOcsoChkResultMsgListItemInfo(String ipValue, String textValue, String errFlag)
		{
			this._ipValue = ipValue;
			this._textValue = textValue;
			this._errFlag = errFlag;
		}

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL0000Q00ResultListQuerySelect1ListItemInfo
	{
		private String _serial;
		private String _kyunResult;
		private String _kyunCode;
		private String _micName;
		private String _micResult;

		public String Serial
		{
			get { return this._serial; }
			set { this._serial = value; }
		}

		public String KyunResult
		{
			get { return this._kyunResult; }
			set { this._kyunResult = value; }
		}

		public String KyunCode
		{
			get { return this._kyunCode; }
			set { this._kyunCode = value; }
		}

		public String MicName
		{
			get { return this._micName; }
			set { this._micName = value; }
		}

		public String MicResult
		{
			get { return this._micResult; }
			set { this._micResult = value; }
		}

		public CPL0000Q00ResultListQuerySelect1ListItemInfo() { }

		public CPL0000Q00ResultListQuerySelect1ListItemInfo(String serial, String kyunResult, String kyunCode, String micName, String micResult)
		{
			this._serial = serial;
			this._kyunResult = kyunResult;
			this._kyunCode = kyunCode;
			this._micName = micName;
			this._micResult = micResult;
		}

	}
}
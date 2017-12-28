using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL0000Q00ResultListQuerySelect2ListItemInfo
	{
		private String _antiSeq;
		private String _antiName;
		private String _micName;
		private String _micResult;

		public String AntiSeq
		{
			get { return this._antiSeq; }
			set { this._antiSeq = value; }
		}

		public String AntiName
		{
			get { return this._antiName; }
			set { this._antiName = value; }
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

		public CPL0000Q00ResultListQuerySelect2ListItemInfo() { }

		public CPL0000Q00ResultListQuerySelect2ListItemInfo(String antiSeq, String antiName, String micName, String micResult)
		{
			this._antiSeq = antiSeq;
			this._antiName = antiName;
			this._micName = micName;
			this._micResult = micResult;
		}

	}
}
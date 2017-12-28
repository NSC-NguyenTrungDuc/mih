using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL0000Q00GetSigeyulDataSelect1ListItemInfo
	{
		private String _jubsuDate;
		private String _jubsuTime;
		private String _jubsuTime2;

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
		}

		public String JubsuTime
		{
			get { return this._jubsuTime; }
			set { this._jubsuTime = value; }
		}

		public String JubsuTime2
		{
			get { return this._jubsuTime2; }
			set { this._jubsuTime2 = value; }
		}

		public CPL0000Q00GetSigeyulDataSelect1ListItemInfo() { }

		public CPL0000Q00GetSigeyulDataSelect1ListItemInfo(String jubsuDate, String jubsuTime, String jubsuTime2)
		{
			this._jubsuDate = jubsuDate;
			this._jubsuTime = jubsuTime;
			this._jubsuTime2 = jubsuTime2;
		}

	}
}
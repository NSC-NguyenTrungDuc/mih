using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Xrts;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0201U00LayConstantResult : AbstractContractResult
	{
		private List<XRT0000Q00LayPacsInfoListItemInfo> _layConstantItemInfo = new List<XRT0000Q00LayPacsInfoListItemInfo>();
		private String _alarmFilePathXrt;
		private String _alarmFilePathXrtEm;

		public List<XRT0000Q00LayPacsInfoListItemInfo> LayConstantItemInfo
		{
			get { return this._layConstantItemInfo; }
			set { this._layConstantItemInfo = value; }
		}

		public String AlarmFilePathXrt
		{
			get { return this._alarmFilePathXrt; }
			set { this._alarmFilePathXrt = value; }
		}

		public String AlarmFilePathXrtEm
		{
			get { return this._alarmFilePathXrtEm; }
			set { this._alarmFilePathXrtEm = value; }
		}

		public XRT0201U00LayConstantResult() { }

	}
}
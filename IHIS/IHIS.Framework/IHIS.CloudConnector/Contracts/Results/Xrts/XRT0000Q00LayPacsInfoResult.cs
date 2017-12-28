using IHIS.CloudConnector.Contracts.Models.Xrts;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
	public class XRT0000Q00LayPacsInfoResult : AbstractContractResult
	{
		private List<XRT0000Q00LayPacsInfoListItemInfo> _layPacsInfoList = new List<XRT0000Q00LayPacsInfoListItemInfo>();

		public List<XRT0000Q00LayPacsInfoListItemInfo> LayPacsInfoList
		{
			get { return this._layPacsInfoList; }
			set { this._layPacsInfoList = value; }
		}

		public XRT0000Q00LayPacsInfoResult() { }

	}
}
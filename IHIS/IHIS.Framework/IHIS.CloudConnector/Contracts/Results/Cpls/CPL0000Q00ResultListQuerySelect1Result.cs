using IHIS.CloudConnector.Contracts.Models.Cpls;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL0000Q00ResultListQuerySelect1Result : AbstractContractResult
	{
		private List<CPL0000Q00ResultListQuerySelect1ListItemInfo> _resultList = new List<CPL0000Q00ResultListQuerySelect1ListItemInfo>();

		public List<CPL0000Q00ResultListQuerySelect1ListItemInfo> ResultList
		{
			get { return this._resultList; }
			set { this._resultList = value; }
		}

		public CPL0000Q00ResultListQuerySelect1Result() { }

	}
}
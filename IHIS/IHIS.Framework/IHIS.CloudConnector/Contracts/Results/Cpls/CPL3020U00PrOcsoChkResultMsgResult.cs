using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3020U00PrOcsoChkResultMsgResult : AbstractContractResult
	{
		private CPL3020U00PrOcsoChkResultMsgListItemInfo _resultList;

		public CPL3020U00PrOcsoChkResultMsgListItemInfo ResultList
		{
			get { return this._resultList; }
			set { this._resultList = value; }
		}

		public CPL3020U00PrOcsoChkResultMsgResult() { }

	}
}
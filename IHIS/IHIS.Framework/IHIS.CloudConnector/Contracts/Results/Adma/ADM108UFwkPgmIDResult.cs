using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM108UFwkPgmIDResult : AbstractContractResult
	{
		private List<ADM108UFwkPgmIdListItemInfo> _fwkPgmIdListItemInfo = new List<ADM108UFwkPgmIdListItemInfo>();

		public List<ADM108UFwkPgmIdListItemInfo> FwkPgmIdListItemInfo
		{
			get { return this._fwkPgmIdListItemInfo; }
			set { this._fwkPgmIdListItemInfo = value; }
		}

		public ADM108UFwkPgmIDResult() { }

	}
}
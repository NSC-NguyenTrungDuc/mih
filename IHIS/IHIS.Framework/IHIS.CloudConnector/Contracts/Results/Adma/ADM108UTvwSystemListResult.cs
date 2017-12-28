using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM108UTvwSystemListResult : AbstractContractResult
	{
		private List<ADM108UTvwSystemListItemInfo> _tvwSystemListItemInfo = new List<ADM108UTvwSystemListItemInfo>();

		public List<ADM108UTvwSystemListItemInfo> TvwSystemListItemInfo
		{
			get { return this._tvwSystemListItemInfo; }
			set { this._tvwSystemListItemInfo = value; }
		}

		public ADM108UTvwSystemListResult() { }

	}
}
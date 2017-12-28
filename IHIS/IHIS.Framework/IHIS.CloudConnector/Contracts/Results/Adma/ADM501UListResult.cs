using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM501UListResult : AbstractContractResult
	{
		private List<ADM501UListItemInfo> _listItemInfo = new List<ADM501UListItemInfo>();

		public List<ADM501UListItemInfo> ListItemInfo
		{
			get { return this._listItemInfo; }
			set { this._listItemInfo = value; }
		}

		public ADM501UListResult() { }

	}
}
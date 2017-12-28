using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0310U00GrdListResult : AbstractContractResult
	{
		private List<BAS0310U00GrdListItemInfo> _listInfo = new List<BAS0310U00GrdListItemInfo>();

		public List<BAS0310U00GrdListItemInfo> ListInfo
		{
			get { return this._listInfo; }
			set { this._listInfo = value; }
		}

		public BAS0310U00GrdListResult() { }

	}
}
using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class Ocs0103Q00LoadOcs0103Result : AbstractContractResult
	{
		private List<Ocs0103Q00LoadOcs0103ListItemInfo> _itemInfo = new List<Ocs0103Q00LoadOcs0103ListItemInfo>();

		public List<Ocs0103Q00LoadOcs0103ListItemInfo> ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public Ocs0103Q00LoadOcs0103Result() { }

	}
}
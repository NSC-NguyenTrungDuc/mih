using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0311Q01GrdBAS0311Result : AbstractContractResult
	{
		private List<BAS0311Q01GrdBAS0311Info> _itemInfo = new List<BAS0311Q01GrdBAS0311Info>();

		public List<BAS0311Q01GrdBAS0311Info> ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public BAS0311Q01GrdBAS0311Result() { }

	}
}
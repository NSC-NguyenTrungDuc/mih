using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Chts;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
	public class CHT0110Q01GrdCHT0110MListResult : AbstractContractResult
	{
		private List<CHT0110Q01GrdCHT0110MListInfo> _grdListItem = new List<CHT0110Q01GrdCHT0110MListInfo>();

		public List<CHT0110Q01GrdCHT0110MListInfo> GrdListItem
		{
			get { return this._grdListItem; }
			set { this._grdListItem = value; }
		}

		public CHT0110Q01GrdCHT0110MListResult() { }

	}
}
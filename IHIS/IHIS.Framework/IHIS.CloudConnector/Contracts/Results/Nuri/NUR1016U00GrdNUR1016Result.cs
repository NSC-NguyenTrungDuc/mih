using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuri;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
	public class NUR1016U00GrdNUR1016Result : AbstractContractResult
	{
		private List<NUR1016U00GrdNUR1016ListItemInfo> _grdNUR1016List = new List<NUR1016U00GrdNUR1016ListItemInfo>();

		public List<NUR1016U00GrdNUR1016ListItemInfo> GrdNUR1016List
		{
			get { return this._grdNUR1016List; }
			set { this._grdNUR1016List = value; }
		}

		public NUR1016U00GrdNUR1016Result() { }

	}
}
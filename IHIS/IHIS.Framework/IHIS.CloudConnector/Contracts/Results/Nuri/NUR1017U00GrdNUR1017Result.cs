using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuri;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
	public class NUR1017U00GrdNUR1017Result : AbstractContractResult
	{
		private List<NUR1017U00GrdNUR1017ListItemInfo> _grdNUR1017List = new List<NUR1017U00GrdNUR1017ListItemInfo>();

		public List<NUR1017U00GrdNUR1017ListItemInfo> GrdNUR1017List
		{
			get { return this._grdNUR1017List; }
			set { this._grdNUR1017List = value; }
		}

		public NUR1017U00GrdNUR1017Result() { }

	}
}
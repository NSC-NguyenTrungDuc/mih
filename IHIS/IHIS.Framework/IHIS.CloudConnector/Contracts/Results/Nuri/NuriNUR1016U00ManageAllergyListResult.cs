using System;
using IHIS.CloudConnector.Contracts.Models.Nuri;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
	public class NuriNUR1016U00ManageAllergyListResult : AbstractContractResult
	{
		private List<NuriNUR1016U00ManageAllergyListItemInfo> _manageAllergyListItem = new List<NuriNUR1016U00ManageAllergyListItemInfo>();

		public List<NuriNUR1016U00ManageAllergyListItemInfo> ManageAllergyListItem
		{
			get { return this._manageAllergyListItem; }
			set { this._manageAllergyListItem = value; }
		}

		public NuriNUR1016U00ManageAllergyListResult() { }

	}
}
using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0113U00GetFindWorkerResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _listCombo = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ListCombo
		{
			get { return this._listCombo; }
			set { this._listCombo = value; }
		}

		public OCS0113U00GetFindWorkerResult() { }

	}
}
using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U10CboInputGubunResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _cboGubunItem = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> CboGubunItem
		{
			get { return this._cboGubunItem; }
			set { this._cboGubunItem = value; }
		}

		public OCS0103U10CboInputGubunResult() { }

	}
}
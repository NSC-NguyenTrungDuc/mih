using IHIS.CloudConnector.Contracts.Models.System;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001U01CboTimeResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _grdOcs1003Item = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> GrdOcs1003Item
		{
			get { return this._grdOcs1003Item; }
			set { this._grdOcs1003Item = value; }
		}

		public INJ1001U01CboTimeResult() { }

	}
}
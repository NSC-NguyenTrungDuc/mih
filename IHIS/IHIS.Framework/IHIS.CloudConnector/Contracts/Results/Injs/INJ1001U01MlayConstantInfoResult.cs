using IHIS.CloudConnector.Contracts.Models.System;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001U01MlayConstantInfoResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _item = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> Item
		{
			get { return this._item; }
			set { this._item = value; }
		}

		public INJ1001U01MlayConstantInfoResult() { }

	}
}
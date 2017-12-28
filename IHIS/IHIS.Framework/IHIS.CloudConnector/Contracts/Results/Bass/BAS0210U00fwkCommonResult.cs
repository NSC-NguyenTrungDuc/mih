using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0210U00fwkCommonResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _fwkCommon = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> FwkCommon
		{
			get { return this._fwkCommon; }
			set { this._fwkCommon = value; }
		}

		public BAS0210U00fwkCommonResult() { }

	}
}
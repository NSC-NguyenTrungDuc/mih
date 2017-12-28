using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0123U00LayTonggyeCodeResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _info = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> Info
		{
			get { return this._info; }
			set { this._info = value; }
		}

		public BAS0123U00LayTonggyeCodeResult() { }

	}
}
using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADMS2015U01GetSystemResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _systemInfo = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> SystemInfo
		{
			get { return this._systemInfo; }
			set { this._systemInfo = value; }
		}

		public ADMS2015U01GetSystemResult() { }

	}
}
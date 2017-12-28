using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM108ULaySysListResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _laySysListItemInfo = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> LaySysListItemInfo
		{
			get { return this._laySysListItemInfo; }
			set { this._laySysListItemInfo = value; }
		}

		public ADM108ULaySysListResult() { }

	}
}
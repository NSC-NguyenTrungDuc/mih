using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3020U00FwkResultInputSQLResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _fwkResultList = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> FwkResultList
		{
			get { return this._fwkResultList; }
			set { this._fwkResultList = value; }
		}

		public CPL3020U00FwkResultInputSQLResult() { }

	}
}
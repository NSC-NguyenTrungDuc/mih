using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Injs;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1002R01LayQueryResult : AbstractContractResult
	{
		private List<INJ1002R01LayQueryListItemInfo> _layQuerryList = new List<INJ1002R01LayQueryListItemInfo>();

		public List<INJ1002R01LayQueryListItemInfo> LayQuerryList
		{
			get { return this._layQuerryList; }
			set { this._layQuerryList = value; }
		}

		public INJ1002R01LayQueryResult() { }

	}
}
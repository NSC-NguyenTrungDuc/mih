using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12SetSameOrderDateGroupSerResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _data = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> Data
		{
			get { return this._data; }
			set { this._data = value; }
		}

		public OCS0103U12SetSameOrderDateGroupSerResult() { }

	}
}
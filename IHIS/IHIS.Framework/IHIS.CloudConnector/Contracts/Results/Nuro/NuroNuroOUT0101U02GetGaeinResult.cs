using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroNuroOUT0101U02GetGaeinResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _gaeinList = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> GaeinList
		{
			get { return this._gaeinList; }
			set { this._gaeinList = value; }
		}

		public NuroNuroOUT0101U02GetGaeinResult() { }

	}
}
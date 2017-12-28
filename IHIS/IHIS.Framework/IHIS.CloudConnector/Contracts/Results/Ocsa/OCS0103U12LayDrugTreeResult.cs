using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12LayDrugTreeResult : AbstractContractResult
	{
		private List<OCS0103U12LayDrugTreeInfo> _layDrugTreeList = new List<OCS0103U12LayDrugTreeInfo>();

		public List<OCS0103U12LayDrugTreeInfo> LayDrugTreeList
		{
			get { return this._layDrugTreeList; }
			set { this._layDrugTreeList = value; }
		}

		public OCS0103U12LayDrugTreeResult() { }

	}
}
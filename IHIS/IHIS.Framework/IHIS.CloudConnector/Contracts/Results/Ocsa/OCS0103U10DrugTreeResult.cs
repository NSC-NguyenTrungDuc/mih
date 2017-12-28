using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U10DrugTreeResult : AbstractContractResult
	{
		private List<OCS0103U10DrugTreeInfo> _drugTreeItem = new List<OCS0103U10DrugTreeInfo>();

		public List<OCS0103U10DrugTreeInfo> DrugTreeItem
		{
			get { return this._drugTreeItem; }
			set { this._drugTreeItem = value; }
		}

		public OCS0103U10DrugTreeResult() { }

	}
}
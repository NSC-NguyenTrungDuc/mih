using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U13LaySpecimenTreeListResult : AbstractContractResult
	{
		private List<OCS0103U13LaySpecimenTreeListInfo> _laySpecimenTreeItem = new List<OCS0103U13LaySpecimenTreeListInfo>();

		public List<OCS0103U13LaySpecimenTreeListInfo> LaySpecimenTreeItem
		{
			get { return this._laySpecimenTreeItem; }
			set { this._laySpecimenTreeItem = value; }
		}

		public OCS0103U13LaySpecimenTreeListResult() { }

	}
}
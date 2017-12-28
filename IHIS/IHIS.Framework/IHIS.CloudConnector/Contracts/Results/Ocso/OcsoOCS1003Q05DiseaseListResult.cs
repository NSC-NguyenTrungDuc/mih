using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003Q05DiseaseListResult : AbstractContractResult
	{
		private List<OcsoOCS1003Q05DiseaseListItemInfo> _diseaseListItem = new List<OcsoOCS1003Q05DiseaseListItemInfo>();

		public List<OcsoOCS1003Q05DiseaseListItemInfo> DiseaseListItem
		{
			get { return this._diseaseListItem; }
			set { this._diseaseListItem = value; }
		}

		public OcsoOCS1003Q05DiseaseListResult() { }

	}
}
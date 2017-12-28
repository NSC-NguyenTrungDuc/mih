using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003Q05GrdRowFocusChangedResult : AbstractContractResult
	{
		private List<OcsoOCS1003Q05DiseaseListItemInfo> _diseaseItem = new List<OcsoOCS1003Q05DiseaseListItemInfo>();
		private List<OcsoOCS1003Q05OrderListItemInfo> _orderItem = new List<OcsoOCS1003Q05OrderListItemInfo>();

		public List<OcsoOCS1003Q05DiseaseListItemInfo> DiseaseItem
		{
			get { return this._diseaseItem; }
			set { this._diseaseItem = value; }
		}

		public List<OcsoOCS1003Q05OrderListItemInfo> OrderItem
		{
			get { return this._orderItem; }
			set { this._orderItem = value; }
		}

		public OcsoOCS1003Q05GrdRowFocusChangedResult() { }

	}
}
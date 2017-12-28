using IHIS.CloudConnector.Contracts.Models.Nuro;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class OUT0101Q01GrdPatientListResult : AbstractContractResult
	{
		private List<OUT0101Q01GrdPatientListInfo> _item = new List<OUT0101Q01GrdPatientListInfo>();

		public List<OUT0101Q01GrdPatientListInfo> Item
		{
			get { return this._item; }
			set { this._item = value; }
		}

		public OUT0101Q01GrdPatientListResult() { }

	}
}
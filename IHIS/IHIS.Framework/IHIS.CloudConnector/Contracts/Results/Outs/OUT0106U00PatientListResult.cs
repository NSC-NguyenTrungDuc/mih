using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Outs;

namespace IHIS.CloudConnector.Contracts.Results.Outs
{
    [Serializable]
	public class OUT0106U00PatientListResult : AbstractContractResult
	{
		private List<OUT0106U00PatientItemInfo> _itemInfo = new List<OUT0106U00PatientItemInfo>();

		public List<OUT0106U00PatientItemInfo> ItemInfo
		{
			get { return this._itemInfo; }
			set { this._itemInfo = value; }
		}

		public OUT0106U00PatientListResult() { }

	}
}
using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3010U00QuerySpecimenBySerResult : AbstractContractResult
	{
		private List<CPL3010U00GrdPartListItemInfo> _grdPartList = new List<CPL3010U00GrdPartListItemInfo>();

		public List<CPL3010U00GrdPartListItemInfo> GrdPartList
		{
			get { return this._grdPartList; }
			set { this._grdPartList = value; }
		}

		public CPL3010U00QuerySpecimenBySerResult() { }

	}
}
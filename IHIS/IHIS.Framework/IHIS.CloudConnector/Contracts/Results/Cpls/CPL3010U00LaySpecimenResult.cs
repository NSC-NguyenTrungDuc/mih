using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class CPL3010U00LaySpecimenResult : AbstractContractResult
	{
		private List<CPL3010U00LaySpecimenInfoListItemInfo> _laySpecimenInfo = new List<CPL3010U00LaySpecimenInfoListItemInfo>();

		public List<CPL3010U00LaySpecimenInfoListItemInfo> LaySpecimenInfo
		{
			get { return this._laySpecimenInfo; }
			set { this._laySpecimenInfo = value; }
		}

		public CPL3010U00LaySpecimenResult() { }

	}
}
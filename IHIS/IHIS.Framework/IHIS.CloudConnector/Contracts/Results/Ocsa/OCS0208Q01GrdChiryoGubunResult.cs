using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0208Q01GrdChiryoGubunResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _chiryoGubunInfo = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> ChiryoGubunInfo
		{
			get { return this._chiryoGubunInfo; }
			set { this._chiryoGubunInfo = value; }
		}

		public OCS0208Q01GrdChiryoGubunResult() { }

	}
}
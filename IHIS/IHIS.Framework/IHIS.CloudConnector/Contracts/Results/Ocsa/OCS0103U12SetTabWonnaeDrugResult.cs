using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12SetTabWonnaeDrugResult : AbstractContractResult
	{
		private List<OCS0103U12SetTabWonnaeDrugInfo> _info1 = new List<OCS0103U12SetTabWonnaeDrugInfo>();

		public List<OCS0103U12SetTabWonnaeDrugInfo> Info1
		{
			get { return this._info1; }
			set { this._info1 = value; }
		}

		public OCS0103U12SetTabWonnaeDrugResult() { }

	}
}
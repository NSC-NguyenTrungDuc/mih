using System;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Pfes
{
    [Serializable]
    public class PFE0101U00GrdDCodeResult : AbstractContractResult
	{
		private List<PFE0101U00GrdDCodeInfo> _dcodeItem = new List<PFE0101U00GrdDCodeInfo>();

		public List<PFE0101U00GrdDCodeInfo> DcodeItem
		{
			get { return this._dcodeItem; }
			set { this._dcodeItem = value; }
		}

		public PFE0101U00GrdDCodeResult() { }

	}
}
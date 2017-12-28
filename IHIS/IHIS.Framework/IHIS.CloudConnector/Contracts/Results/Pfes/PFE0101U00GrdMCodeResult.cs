using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Pfes;

namespace IHIS.CloudConnector.Contracts.Results.Pfes
{
    [Serializable]
	public class PFE0101U00GrdMCodeResult : AbstractContractResult
	{
		private List<PFE0101U00GrdMCodeInfo> _mcodeItem = new List<PFE0101U00GrdMCodeInfo>();

		public List<PFE0101U00GrdMCodeInfo> McodeItem
		{
			get { return this._mcodeItem; }
			set { this._mcodeItem = value; }
		}

		public PFE0101U00GrdMCodeResult() { }

	}
}
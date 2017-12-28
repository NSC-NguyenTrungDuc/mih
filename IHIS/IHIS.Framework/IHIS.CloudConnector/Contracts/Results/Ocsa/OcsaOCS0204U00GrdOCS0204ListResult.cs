using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0204U00GrdOCS0204ListResult : AbstractContractResult
	{
		private List<OcsaOCS0204U00GrdOCS0204ListInfo> _grd0204Item = new List<OcsaOCS0204U00GrdOCS0204ListInfo>();

		public List<OcsaOCS0204U00GrdOCS0204ListInfo> Grd0204Item
		{
			get { return this._grd0204Item; }
			set { this._grd0204Item = value; }
		}

		public OcsaOCS0204U00GrdOCS0204ListResult() { }

	}
}
using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class Ocs0103Q00GrdHangMogResult : AbstractContractResult
	{
		private List<Ocs0103Q00LoadOcs0103ListItemInfo> _listInfo = new List<Ocs0103Q00LoadOcs0103ListItemInfo>();

		public List<Ocs0103Q00LoadOcs0103ListItemInfo> ListInfo
		{
			get { return this._listInfo; }
			set { this._listInfo = value; }
		}

		public Ocs0103Q00GrdHangMogResult() { }

	}
}
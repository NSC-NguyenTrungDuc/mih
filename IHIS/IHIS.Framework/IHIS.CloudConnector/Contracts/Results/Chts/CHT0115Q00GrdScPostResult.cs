using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Chts;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
	public class CHT0115Q00GrdScPostResult : AbstractContractResult
	{
		private List<CHT0115Q00GrdScInfo> _grdscPostInfo = new List<CHT0115Q00GrdScInfo>();

		public List<CHT0115Q00GrdScInfo> GrdscPostInfo
		{
			get { return this._grdscPostInfo; }
			set { this._grdscPostInfo = value; }
		}

		public CHT0115Q00GrdScPostResult() { }

	}
}
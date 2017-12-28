using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Chts;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
	public class CHT0115Q00GrdScPreResult : AbstractContractResult
	{
		private List<CHT0115Q00GrdScInfo> _grdscPreInfo = new List<CHT0115Q00GrdScInfo>();

		public List<CHT0115Q00GrdScInfo> GrdscPreInfo
		{
			get { return this._grdscPreInfo; }
			set { this._grdscPreInfo = value; }
		}

		public CHT0115Q00GrdScPreResult() { }

	}
}
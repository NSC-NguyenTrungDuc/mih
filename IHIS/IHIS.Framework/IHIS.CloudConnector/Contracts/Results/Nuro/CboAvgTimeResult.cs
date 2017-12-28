using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class CboAvgTimeResult : AbstractContractResult
	{
		private List<CboAvgTimeInfo> _avgTimeItem = new List<CboAvgTimeInfo>();

		public List<CboAvgTimeInfo> AvgTimeItem
		{
			get { return this._avgTimeItem; }
			set { this._avgTimeItem = value; }
		}

		public CboAvgTimeResult() { }

	}
}
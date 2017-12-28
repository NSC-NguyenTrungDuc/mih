using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U10SetTabWonnaeDrgResult : AbstractContractResult
	{
		private List<OCS0103U10SetTabWonnaeDrgInfo> _wonnaeDrgItem = new List<OCS0103U10SetTabWonnaeDrgInfo>();

		public List<OCS0103U10SetTabWonnaeDrgInfo> WonnaeDrgItem
		{
			get { return this._wonnaeDrgItem; }
			set { this._wonnaeDrgItem = value; }
		}

		public OCS0103U10SetTabWonnaeDrgResult() { }

	}
}
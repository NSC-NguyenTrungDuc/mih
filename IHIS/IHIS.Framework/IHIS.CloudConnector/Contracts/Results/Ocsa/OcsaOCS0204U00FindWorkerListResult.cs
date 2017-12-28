using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0204U00FindWorkerListResult : AbstractContractResult
	{
		private List<OcsaOCS0204U00MembListInfo> _membList = new List<OcsaOCS0204U00MembListInfo>();

		public List<OcsaOCS0204U00MembListInfo> MembList
		{
			get { return this._membList; }
			set { this._membList = value; }
		}

		public OcsaOCS0204U00FindWorkerListResult() { }

	}
}
using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0301U00GrdOCS0301Result : AbstractContractResult
	{
		private List<OCS0301U00MembGrdInfo> _gridInfo = new List<OCS0301U00MembGrdInfo>();

		public List<OCS0301U00MembGrdInfo> GridInfo
		{
			get { return this._gridInfo; }
			set { this._gridInfo = value; }
		}

		public OCS0301U00GrdOCS0301Result() { }

	}
}
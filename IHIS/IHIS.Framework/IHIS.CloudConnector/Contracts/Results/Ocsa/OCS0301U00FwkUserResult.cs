using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0301U00FwkUserResult : AbstractContractResult
	{
		private List<TripleListItemInfo> _fwkUser = new List<TripleListItemInfo>();

		public List<TripleListItemInfo> FwkUser
		{
			get { return this._fwkUser; }
			set { this._fwkUser = value; }
		}

		public OCS0301U00FwkUserResult() { }

	}
}
using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103Q00CheckHangmogNameInxResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _result = new List<DataStringListItemInfo>();
        
		public List<DataStringListItemInfo> Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public OCS0103Q00CheckHangmogNameInxResult() { }

	}
}
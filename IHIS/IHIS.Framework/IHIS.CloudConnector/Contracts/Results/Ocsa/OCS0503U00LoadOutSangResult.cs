using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0503U00LoadOutSangResult : AbstractContractResult
	{
		private List<String> _sangName = new List<String>();

		public List<String> SangName
		{
			get { return this._sangName; }
			set { this._sangName = value; }
		}

		public OCS0503U00LoadOutSangResult() { }

	}
}
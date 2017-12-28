using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003Q05CodeListResult : AbstractContractResult
	{
		private List<String> _code = new List<String>();

		public List<String> Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public OcsoOCS1003Q05CodeListResult() { }

	}
}
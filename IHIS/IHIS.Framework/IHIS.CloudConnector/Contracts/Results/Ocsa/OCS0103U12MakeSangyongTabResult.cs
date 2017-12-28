using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12MakeSangyongTabResult : AbstractContractResult
	{
		private List<OCS0103U12MakeSangyongTabInfo> _result = new List<OCS0103U12MakeSangyongTabInfo>();

		public List<OCS0103U12MakeSangyongTabInfo> Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public OCS0103U12MakeSangyongTabResult() { }

	}
}
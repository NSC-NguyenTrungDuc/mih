using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroNUR2001U04ForeignKeyResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _result = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public NuroNUR2001U04ForeignKeyResult() { }

	}
}
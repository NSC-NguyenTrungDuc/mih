using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1002U01LayReserDateResult : AbstractContractResult
	{
		private List<DataStringListItemInfo> _reserDate = new List<DataStringListItemInfo>();

		public List<DataStringListItemInfo> ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public INJ1002U01LayReserDateResult() { }

	}
}
using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201U99ReserListResult : AbstractContractResult
	{
		private List<SchsSCH0201U99ReserListInfo> _reserList = new List<SchsSCH0201U99ReserListInfo>();

		public List<SchsSCH0201U99ReserListInfo> ReserList
		{
			get { return this._reserList; }
			set { this._reserList = value; }
		}

		public SchsSCH0201U99ReserListResult() { }

	}
}
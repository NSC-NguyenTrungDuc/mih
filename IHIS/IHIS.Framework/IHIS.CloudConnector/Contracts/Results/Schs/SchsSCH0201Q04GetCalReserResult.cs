using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201Q04GetCalReserResult : AbstractContractResult
	{
		private List<SchsSCH0201Q04ReserTimeListInfo> _reserTimeListItem = new List<SchsSCH0201Q04ReserTimeListInfo>();
		private Boolean _result;

		public List<SchsSCH0201Q04ReserTimeListInfo> ReserTimeListItem
		{
			get { return this._reserTimeListItem; }
			set { this._reserTimeListItem = value; }
		}

		public Boolean Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public SchsSCH0201Q04GetCalReserResult() { }

	}
}
using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201Q04ReserTimeListResult : AbstractContractResult
	{
		private List<SchsSCH0201Q04ReserTimeListInfo> _reserTimeListItem = new List<SchsSCH0201Q04ReserTimeListInfo>();

		public List<SchsSCH0201Q04ReserTimeListInfo> ReserTimeListItem
		{
			get { return this._reserTimeListItem; }
			set { this._reserTimeListItem = value; }
		}

		public SchsSCH0201Q04ReserTimeListResult() { }

	}
}
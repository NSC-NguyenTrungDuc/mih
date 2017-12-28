using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201Q02ReserList03Result : AbstractContractResult
	{
		private List<SchsSCH0201Q02ReserList03ItemInfo> _reserList03Item = new List<SchsSCH0201Q02ReserList03ItemInfo>();

		public List<SchsSCH0201Q02ReserList03ItemInfo> ReserList03Item
		{
			get { return this._reserList03Item; }
			set { this._reserList03Item = value; }
		}

		public SchsSCH0201Q02ReserList03Result() { }

	}
}
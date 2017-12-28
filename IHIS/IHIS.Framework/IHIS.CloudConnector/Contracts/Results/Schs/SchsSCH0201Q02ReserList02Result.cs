using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SchsSCH0201Q02ReserList02Result : AbstractContractResult
	{
		private List<SchsSCH0201Q02ReserList02ItemInfo> _reserList02Item = new List<SchsSCH0201Q02ReserList02ItemInfo>();

		public List<SchsSCH0201Q02ReserList02ItemInfo> ReserList02Item
		{
			get { return this._reserList02Item; }
			set { this._reserList02Item = value; }
		}

		public SchsSCH0201Q02ReserList02Result() { }

	}
}
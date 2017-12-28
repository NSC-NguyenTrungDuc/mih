using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U12IsUpdateCheckSelectResult : AbstractContractResult
	{
		private List<OCS0103U12IsUpdateCheckSelectInfo> _selectInfo = new List<OCS0103U12IsUpdateCheckSelectInfo>();

		public List<OCS0103U12IsUpdateCheckSelectInfo> SelectInfo
		{
			get { return this._selectInfo; }
			set { this._selectInfo = value; }
		}

		public OCS0103U12IsUpdateCheckSelectResult() { }

	}
}
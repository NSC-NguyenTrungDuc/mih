using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class BuseoListResult : AbstractContractResult
	{
		private List<BuseoInfo> _buseoList = new List<BuseoInfo>();

		public List<BuseoInfo> BuseoList
		{
			get { return this._buseoList; }
			set { this._buseoList = value; }
		}

		public BuseoListResult() { }

	}
}
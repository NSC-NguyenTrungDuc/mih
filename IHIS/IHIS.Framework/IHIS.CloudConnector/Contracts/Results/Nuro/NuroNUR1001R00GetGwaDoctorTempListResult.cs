using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroNUR1001R00GetGwaDoctorTempListResult : AbstractContractResult
	{
		private List<NuroNUR1001R00GetTempListItemInfo> _temItem = new List<NuroNUR1001R00GetTempListItemInfo>();

		public List<NuroNUR1001R00GetTempListItemInfo> TemItem
		{
			get { return this._temItem; }
			set { this._temItem = value; }
		}

		public NuroNUR1001R00GetGwaDoctorTempListResult() { }

	}
}
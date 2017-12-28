using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0301Q09GrdOCS0301Result : AbstractContractResult
	{
		private List<OCS0301Q09GrdOCS0301Info> _drgOcs0301Item = new List<OCS0301Q09GrdOCS0301Info>();

		public List<OCS0301Q09GrdOCS0301Info> DrgOcs0301Item
		{
			get { return this._drgOcs0301Item; }
			set { this._drgOcs0301Item = value; }
		}

		public OCS0301Q09GrdOCS0301Result() { }

	}
}
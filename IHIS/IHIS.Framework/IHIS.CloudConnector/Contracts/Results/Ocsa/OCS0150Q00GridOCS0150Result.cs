using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0150Q00GridOCS0150Result : AbstractContractResult
	{
		private List<OCS0150Q00GridOCS0150Info> _gridOcs0150Info = new List<OCS0150Q00GridOCS0150Info>();

		public List<OCS0150Q00GridOCS0150Info> GridOcs0150Info
		{
			get { return this._gridOcs0150Info; }
			set { this._gridOcs0150Info = value; }
		}

		public OCS0150Q00GridOCS0150Result() { }

	}
}
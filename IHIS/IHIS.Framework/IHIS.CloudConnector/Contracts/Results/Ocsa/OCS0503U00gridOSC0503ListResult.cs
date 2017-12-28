using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0503U00gridOSC0503ListResult : AbstractContractResult
	{
		private List<OCS0503U00gridOSC0503ListInfo> _gridOSC0503 = new List<OCS0503U00gridOSC0503ListInfo>();

		public List<OCS0503U00gridOSC0503ListInfo> GridOSC0503
		{
			get { return this._gridOSC0503; }
			set { this._gridOSC0503 = value; }
		}

		public OCS0503U00gridOSC0503ListResult() { }

	}
}
using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OUTSANGU00findBoxToGwaResult : AbstractContractResult
	{
		private List<OUTSANGU00findBoxToGwaInfo> _gwaInfo = new List<OUTSANGU00findBoxToGwaInfo>();

		public List<OUTSANGU00findBoxToGwaInfo> GwaInfo
		{
			get { return this._gwaInfo; }
			set { this._gwaInfo = value; }
		}

		public OUTSANGU00findBoxToGwaResult() { }

	}
}
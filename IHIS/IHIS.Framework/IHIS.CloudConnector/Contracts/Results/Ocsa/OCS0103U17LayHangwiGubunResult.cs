using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0103U17LayHangwiGubunResult : AbstractContractResult
	{
		private List<OCS0103U17LayHangwiGubunInfo> _layResult = new List<OCS0103U17LayHangwiGubunInfo>();

		public List<OCS0103U17LayHangwiGubunInfo> LayResult
		{
			get { return this._layResult; }
			set { this._layResult = value; }
		}

		public OCS0103U17LayHangwiGubunResult() { }

	}
}
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0503U00ValidationCheckResult : AbstractContractResult
	{
		private List<OCS0503U00ValidationCheckInfo> _validateCheck = new List<OCS0503U00ValidationCheckInfo>();

		public List<OCS0503U00ValidationCheckInfo> ValidateCheck
		{
			get { return this._validateCheck; }
			set { this._validateCheck = value; }
		}

		public OCS0503U00ValidationCheckResult() { }

	}
}
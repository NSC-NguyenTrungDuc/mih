using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class MultiResultViewLaySigeyulResult : AbstractContractResult
	{
		private List<MultiResultViewLaySigeyulInfo> _laySigeyulInfo = new List<MultiResultViewLaySigeyulInfo>();

		public List<MultiResultViewLaySigeyulInfo> LaySigeyulInfo
		{
			get { return this._laySigeyulInfo; }
			set { this._laySigeyulInfo = value; }
		}

		public MultiResultViewLaySigeyulResult() { }

	}
}
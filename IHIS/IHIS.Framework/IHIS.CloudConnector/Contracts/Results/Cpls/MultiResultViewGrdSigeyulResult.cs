using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class MultiResultViewGrdSigeyulResult : AbstractContractResult
	{
		private List<MultiResultViewGrdSigeyulInfo> _grdSigeyulInfo = new List<MultiResultViewGrdSigeyulInfo>();

		public List<MultiResultViewGrdSigeyulInfo> GrdSigeyulInfo
		{
			get { return this._grdSigeyulInfo; }
			set { this._grdSigeyulInfo = value; }
		}

		public MultiResultViewGrdSigeyulResult() { }

	}
}
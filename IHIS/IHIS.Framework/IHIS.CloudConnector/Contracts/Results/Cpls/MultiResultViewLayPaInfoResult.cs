using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
	public class MultiResultViewLayPaInfoResult : AbstractContractResult
	{
		private List<MultiResultViewLayPaInfo> _layPaInfo = new List<MultiResultViewLayPaInfo>();

		public List<MultiResultViewLayPaInfo> LayPaInfo
		{
			get { return this._layPaInfo; }
			set { this._layPaInfo = value; }
		}

		public MultiResultViewLayPaInfoResult() { }

	}
}
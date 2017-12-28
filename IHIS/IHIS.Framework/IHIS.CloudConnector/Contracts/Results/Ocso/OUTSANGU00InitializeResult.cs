using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OUTSANGU00InitializeResult : AbstractContractResult
	{
		private List<OUTSANGU00InitializeListItemInfo> _initInfo = new List<OUTSANGU00InitializeListItemInfo>();

		public List<OUTSANGU00InitializeListItemInfo> InitInfo
		{
			get { return this._initInfo; }
			set { this._initInfo = value; }
		}

		public OUTSANGU00InitializeResult() { }

	}
}
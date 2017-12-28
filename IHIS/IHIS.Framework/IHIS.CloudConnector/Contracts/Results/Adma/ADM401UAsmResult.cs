using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
	public class ADM401UAsmResult : AbstractContractResult
	{
		private List<ADM401UAsmItemInfo> _asmItemInfo = new List<ADM401UAsmItemInfo>();

		public List<ADM401UAsmItemInfo> AsmItemInfo
		{
			get { return this._asmItemInfo; }
			set { this._asmItemInfo = value; }
		}

		public ADM401UAsmResult() { }

	}
}
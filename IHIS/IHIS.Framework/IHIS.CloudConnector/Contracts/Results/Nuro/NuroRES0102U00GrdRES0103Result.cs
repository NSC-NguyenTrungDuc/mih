using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class NuroRES0102U00GrdRES0103Result : AbstractContractResult
	{
		private List<NuroRES0102U00GrdRES0103Info> _gridInfoList = new List<NuroRES0102U00GrdRES0103Info>();

		public List<NuroRES0102U00GrdRES0103Info> GridInfoList
		{
			get { return this._gridInfoList; }
			set { this._gridInfoList = value; }
		}

		public NuroRES0102U00GrdRES0103Result() { }

	}
}
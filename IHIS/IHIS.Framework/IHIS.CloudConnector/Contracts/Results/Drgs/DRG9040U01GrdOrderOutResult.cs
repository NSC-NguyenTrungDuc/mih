using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Drgs;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
	public class DRG9040U01GrdOrderOutResult : AbstractContractResult
	{
		private List<DRG9040U01GrdOrderOutInfo> _grdOrderOutInfo = new List<DRG9040U01GrdOrderOutInfo>();

		public List<DRG9040U01GrdOrderOutInfo> GrdOrderOutInfo
		{
			get { return this._grdOrderOutInfo; }
			set { this._grdOrderOutInfo = value; }
		}

		public DRG9040U01GrdOrderOutResult() { }

	}
}
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class RES1001U00FrmModifyReserGrdRES1001Result : AbstractContractResult
	{
		private List<RES1001U00FrmModifyReserGrdRES1001Info> _grdRes1001Info = new List<RES1001U00FrmModifyReserGrdRES1001Info>();

		public List<RES1001U00FrmModifyReserGrdRES1001Info> GrdRes1001Info
		{
			get { return this._grdRes1001Info; }
			set { this._grdRes1001Info = value; }
		}

		public RES1001U00FrmModifyReserGrdRES1001Result() { }

	}
}
using IHIS.CloudConnector.Contracts.Models.System;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
	public class RES1001U00FrmModifyReserCboReserGubunResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _cboReserGubunInfo = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> CboReserGubunInfo
		{
			get { return this._cboReserGubunInfo; }
			set { this._cboReserGubunInfo = value; }
		}

		public RES1001U00FrmModifyReserCboReserGubunResult() { }

	}
}
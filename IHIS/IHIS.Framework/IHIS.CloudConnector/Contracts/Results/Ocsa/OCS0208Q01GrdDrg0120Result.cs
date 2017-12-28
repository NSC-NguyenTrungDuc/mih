using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0208Q01GrdDrg0120Result : AbstractContractResult
	{
		private List<OCS0208Q01GrdDrg0120Info> _grdDrg0120Info = new List<OCS0208Q01GrdDrg0120Info>();
		private List<ComboListItemInfo> _comboInfo = new List<ComboListItemInfo>();

		public List<OCS0208Q01GrdDrg0120Info> GrdDrg0120Info
		{
			get { return this._grdDrg0120Info; }
			set { this._grdDrg0120Info = value; }
		}

		public List<ComboListItemInfo> ComboInfo
		{
			get { return this._comboInfo; }
			set { this._comboInfo = value; }
		}

		public OCS0208Q01GrdDrg0120Result() { }

	}
}
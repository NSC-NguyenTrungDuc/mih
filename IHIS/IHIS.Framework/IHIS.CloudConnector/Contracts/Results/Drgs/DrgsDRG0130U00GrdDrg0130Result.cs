using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Drgs
{
    [Serializable]
    public class DrgsDRG0130U00GrdDrg0130Result : AbstractContractResult
	{
		private List<DrgsDRG0130U00GrdDrg0130ListItemInfo> _grdDrg0130List = new List<DrgsDRG0130U00GrdDrg0130ListItemInfo>();

		public List<DrgsDRG0130U00GrdDrg0130ListItemInfo> GrdDrg0130List
		{
			get { return this._grdDrg0130List; }
			set { this._grdDrg0130List = value; }
		}

		public DrgsDRG0130U00GrdDrg0130Result() { }

	}
}
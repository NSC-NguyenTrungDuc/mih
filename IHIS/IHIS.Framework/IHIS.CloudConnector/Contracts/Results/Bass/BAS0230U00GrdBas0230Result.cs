using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0230U00GrdBas0230Result : AbstractContractResult
	{
		private List<BAS0230U00GrdBas0230Info> _grdBas0230Info = new List<BAS0230U00GrdBas0230Info>();

		public List<BAS0230U00GrdBas0230Info> GrdBas0230Info
		{
			get { return this._grdBas0230Info; }
			set { this._grdBas0230Info = value; }
		}

		public BAS0230U00GrdBas0230Result() { }

	}
}
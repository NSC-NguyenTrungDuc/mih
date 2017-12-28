using IHIS.CloudConnector.Contracts.Models.System;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001U01XEditGridCell88Result : AbstractContractResult
	{
		private List<ComboListItemInfo> _xeditGridCell88Item = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> XeditGridCell88Item
		{
			get { return this._xeditGridCell88Item; }
			set { this._xeditGridCell88Item = value; }
		}

		public INJ1001U01XEditGridCell88Result() { }

	}
}
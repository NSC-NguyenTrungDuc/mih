using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001U01XEditGridCell89Result : AbstractContractResult
	{
		private List<INJ1001U01XEditGridCell89ItemInfo> _xeditGridCell89Item = new List<INJ1001U01XEditGridCell89ItemInfo>();

		public List<INJ1001U01XEditGridCell89ItemInfo> XeditGridCell89Item
		{
			get { return this._xeditGridCell89Item; }
			set { this._xeditGridCell89Item = value; }
		}

		public INJ1001U01XEditGridCell89Result() { }

	}
}
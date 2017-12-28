using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuts;

namespace IHIS.CloudConnector.Contracts.Results.Nuts
{
    [Serializable]
	public class NUT0001U00Grd0002Result : AbstractContractResult
	{
		private List<NUT0001U00GrdNUT0002ItemInfo> _grd002ItemInfo = new List<NUT0001U00GrdNUT0002ItemInfo>();

		public List<NUT0001U00GrdNUT0002ItemInfo> Grd002ItemInfo
		{
			get { return this._grd002ItemInfo; }
			set { this._grd002ItemInfo = value; }
		}

		public NUT0001U00Grd0002Result() { }

	}
}
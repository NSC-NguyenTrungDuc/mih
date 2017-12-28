using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH3001U00GrdSCH3000Result : AbstractContractResult
	{
		private List<SCH3001U00GrdSCH3000Info> _grdSch3000List = new List<SCH3001U00GrdSCH3000Info>();

		public List<SCH3001U00GrdSCH3000Info> GrdSch3000List
		{
			get { return this._grdSch3000List; }
			set { this._grdSch3000List = value; }
		}

		public SCH3001U00GrdSCH3000Result() { }

	}
}
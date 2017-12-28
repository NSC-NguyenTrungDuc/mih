using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH3001U00GrdSCH0001Result : AbstractContractResult
	{
		private List<SCH3001U00GrdSCH0001Info> _grdSch0001List = new List<SCH3001U00GrdSCH0001Info>();

		public List<SCH3001U00GrdSCH0001Info> GrdSch0001List
		{
			get { return this._grdSch0001List; }
			set { this._grdSch0001List = value; }
		}

		public SCH3001U00GrdSCH0001Result() { }

	}
}
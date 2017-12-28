using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH3001U00GrdSCH3101Result : AbstractContractResult
	{
		private List<SCH3001U00GrdSCH3101Info> _grdSch3101List = new List<SCH3001U00GrdSCH3101Info>();

		public List<SCH3001U00GrdSCH3101Info> GrdSch3101List
		{
			get { return this._grdSch3101List; }
			set { this._grdSch3101List = value; }
		}

		public SCH3001U00GrdSCH3101Result() { }

	}
}
using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Schs;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH3001U00GrdSCH0001RowFocusChangedResult : AbstractContractResult
	{
		private List<SCH3001U00GrdJukyongDateInfo> _jukyongDateInfo = new List<SCH3001U00GrdJukyongDateInfo>();
		private List<SCH3001U00GrdSCH0002Info> _grdSch0002Info = new List<SCH3001U00GrdSCH0002Info>();
		private List<SCH3001U00GrdSCH3100Info> _grdSch3100Info = new List<SCH3001U00GrdSCH3100Info>();

		public List<SCH3001U00GrdJukyongDateInfo> JukyongDateInfo
		{
			get { return this._jukyongDateInfo; }
			set { this._jukyongDateInfo = value; }
		}

		public List<SCH3001U00GrdSCH0002Info> GrdSch0002Info
		{
			get { return this._grdSch0002Info; }
			set { this._grdSch0002Info = value; }
		}

		public List<SCH3001U00GrdSCH3100Info> GrdSch3100Info
		{
			get { return this._grdSch3100Info; }
			set { this._grdSch3100Info = value; }
		}

		public SCH3001U00GrdSCH0001RowFocusChangedResult() { }

	}
}
using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001U01GrdSangResult : AbstractContractResult
	{
		private List<INJ1001U01GrdSangItemInfo> _scheduleItem = new List<INJ1001U01GrdSangItemInfo>();

		public List<INJ1001U01GrdSangItemInfo> ScheduleItem
		{
			get { return this._scheduleItem; }
			set { this._scheduleItem = value; }
		}

		public INJ1001U01GrdSangResult() { }

	}
}
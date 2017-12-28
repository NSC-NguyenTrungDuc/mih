using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003Q05ScheduleResult : AbstractContractResult
	{
		private List<OcsoOCS1003Q05ScheduleItemInfo> _scheduleItem = new List<OcsoOCS1003Q05ScheduleItemInfo>();

		public List<OcsoOCS1003Q05ScheduleItemInfo> ScheduleItem
		{
			get { return this._scheduleItem; }
			set { this._scheduleItem = value; }
		}

		public OcsoOCS1003Q05ScheduleResult() { }

	}
}
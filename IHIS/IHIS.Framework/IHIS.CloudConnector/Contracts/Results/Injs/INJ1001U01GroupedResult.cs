using IHIS.CloudConnector.Contracts.Models.Injs;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001U01GroupedResult : AbstractContractResult
	{
		private List<InjsINJ1001U01ScheduleItemInfo> _scheduleItem = new List<InjsINJ1001U01ScheduleItemInfo>();
		private List<InjsINJ1001U01DetailListItemInfo> _detailListItem = new List<InjsINJ1001U01DetailListItemInfo>();
		private List<INJ1001U01GrdSangItemInfo> _grdSangItem = new List<INJ1001U01GrdSangItemInfo>();

		public List<InjsINJ1001U01ScheduleItemInfo> ScheduleItem
		{
			get { return this._scheduleItem; }
			set { this._scheduleItem = value; }
		}

		public List<InjsINJ1001U01DetailListItemInfo> DetailListItem
		{
			get { return this._detailListItem; }
			set { this._detailListItem = value; }
		}

		public List<INJ1001U01GrdSangItemInfo> GrdSangItem
		{
			get { return this._grdSangItem; }
			set { this._grdSangItem = value; }
		}

		public INJ1001U01GroupedResult() { }

	}
}
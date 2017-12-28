using IHIS.CloudConnector.Contracts.Models.Injs;
using IHIS.CloudConnector.Contracts.Models.System;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class INJ1001U01Grouped2Result : AbstractContractResult
	{
		private List<InjsINJ1001U01ScheduleItemInfo> _grdOcs1003ListItem = new List<InjsINJ1001U01ScheduleItemInfo>();
		private List<InjsINJ1001U01DetailListItemInfo> _grdDetailListItem = new List<InjsINJ1001U01DetailListItemInfo>();
		private List<InjsINJ1001U01InfectionListItemInfo> _grdNur1017ListItem = new List<InjsINJ1001U01InfectionListItemInfo>();
		private List<InjsINJ1001U01DiseaseListItemInfo> _grdSangListItem = new List<InjsINJ1001U01DiseaseListItemInfo>();
		private List<DataStringListItemInfo> _grdOut0106ListItem = new List<DataStringListItemInfo>();
		private List<DataStringListItemInfo> _grdNur1016ListItem = new List<DataStringListItemInfo>();

		public List<InjsINJ1001U01ScheduleItemInfo> GrdOcs1003ListItem
		{
			get { return this._grdOcs1003ListItem; }
			set { this._grdOcs1003ListItem = value; }
		}

		public List<InjsINJ1001U01DetailListItemInfo> GrdDetailListItem
		{
			get { return this._grdDetailListItem; }
			set { this._grdDetailListItem = value; }
		}

		public List<InjsINJ1001U01InfectionListItemInfo> GrdNur1017ListItem
		{
			get { return this._grdNur1017ListItem; }
			set { this._grdNur1017ListItem = value; }
		}

		public List<InjsINJ1001U01DiseaseListItemInfo> GrdSangListItem
		{
			get { return this._grdSangListItem; }
			set { this._grdSangListItem = value; }
		}

		public List<DataStringListItemInfo> GrdOut0106ListItem
		{
			get { return this._grdOut0106ListItem; }
			set { this._grdOut0106ListItem = value; }
		}

		public List<DataStringListItemInfo> GrdNur1016ListItem
		{
			get { return this._grdNur1016ListItem; }
			set { this._grdNur1016ListItem = value; }
		}

		public INJ1001U01Grouped2Result() { }

	}
}
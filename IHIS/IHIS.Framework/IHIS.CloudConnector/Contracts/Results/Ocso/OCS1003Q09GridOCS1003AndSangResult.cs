using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OCS1003Q09GridOCS1003AndSangResult : AbstractContractResult
	{
		private List<OcsoOCS1003Q05OrderListItemInfo> _gridOcs1003Info = new List<OcsoOCS1003Q05OrderListItemInfo>();
		private List<OCS1003Q09GridSangInfo> _gridSangInfo = new List<OCS1003Q09GridSangInfo>();

		public List<OcsoOCS1003Q05OrderListItemInfo> GridOcs1003Info
		{
			get { return this._gridOcs1003Info; }
			set { this._gridOcs1003Info = value; }
		}

		public List<OCS1003Q09GridSangInfo> GridSangInfo
		{
			get { return this._gridSangInfo; }
			set { this._gridSangInfo = value; }
		}

		public OCS1003Q09GridOCS1003AndSangResult() { }

	}
}
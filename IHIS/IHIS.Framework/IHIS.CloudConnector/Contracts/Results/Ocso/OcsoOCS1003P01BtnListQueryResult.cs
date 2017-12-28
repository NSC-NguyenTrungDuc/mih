using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01BtnListQueryResult : AbstractContractResult
	{
		private List<OcsoOCS1003P01GridOutSangInfo> _gridOutSangItem = new List<OcsoOCS1003P01GridOutSangInfo>();
		private List<ComboListItemInfo> _cboItem = new List<ComboListItemInfo>();
		private List<OcsoOCS1003P01LayoutQueryInfo> _outOrder = new List<OcsoOCS1003P01LayoutQueryInfo>();
		private List<OcsoOCS1003P01GridReserOrderListInfo> _reserOrder = new List<OcsoOCS1003P01GridReserOrderListInfo>();

		public List<OcsoOCS1003P01GridOutSangInfo> GridOutSangItem
		{
			get { return this._gridOutSangItem; }
			set { this._gridOutSangItem = value; }
		}

		public List<ComboListItemInfo> CboItem
		{
			get { return this._cboItem; }
			set { this._cboItem = value; }
		}

		public List<OcsoOCS1003P01LayoutQueryInfo> OutOrder
		{
			get { return this._outOrder; }
			set { this._outOrder = value; }
		}

		public List<OcsoOCS1003P01GridReserOrderListInfo> ReserOrder
		{
			get { return this._reserOrder; }
			set { this._reserOrder = value; }
		}

		public OcsoOCS1003P01BtnListQueryResult() { }

	}
}
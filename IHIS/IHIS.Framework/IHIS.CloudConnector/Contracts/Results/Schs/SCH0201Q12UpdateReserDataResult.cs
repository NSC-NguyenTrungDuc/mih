using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
	public class SCH0201Q12UpdateReserDataResult : AbstractContractResult
	{
		private Boolean _reserResult;
		private Boolean _kensaResult;
		private String _msg;
		private List<SCH0201Q12GrdListItemInfo> _grdListItem = new List<SCH0201Q12GrdListItemInfo>();

		public Boolean ReserResult
		{
			get { return this._reserResult; }
			set { this._reserResult = value; }
		}

		public Boolean KensaResult
		{
			get { return this._kensaResult; }
			set { this._kensaResult = value; }
		}

		public String Msg
		{
			get { return this._msg; }
			set { this._msg = value; }
		}

		public List<SCH0201Q12GrdListItemInfo> GrdListItem
		{
			get { return this._grdListItem; }
			set { this._grdListItem = value; }
		}

		public SCH0201Q12UpdateReserDataResult() { }

	}
}
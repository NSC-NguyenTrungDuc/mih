using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class MdiFormSystemMenuResult : AbstractContractResult
	{
		private Boolean _result;
		private String _msg;
		private List<MdiFormMenuItemInfo> _menuItemInfo = new List<MdiFormMenuItemInfo>();

		public Boolean Result
		{
			get { return this._result; }
			set { this._result = value; }
		}

		public String Msg
		{
			get { return this._msg; }
			set { this._msg = value; }
		}

		public List<MdiFormMenuItemInfo> MenuItemInfo
		{
			get { return this._menuItemInfo; }
			set { this._menuItemInfo = value; }
		}

		public MdiFormSystemMenuResult() { }

	}
}
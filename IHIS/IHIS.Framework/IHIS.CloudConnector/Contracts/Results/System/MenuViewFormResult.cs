using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
	public class MenuViewFormResult : AbstractContractResult
	{
		private Boolean _result;
		private String _msg;
		private List<MenuViewFormItemInfo> _menuViewFormItemInfo = new List<MenuViewFormItemInfo>();

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

		public List<MenuViewFormItemInfo> MenuViewFormItemInfo
		{
			get { return this._menuViewFormItemInfo; }
			set { this._menuViewFormItemInfo = value; }
		}

		public MenuViewFormResult() { }

	}
}
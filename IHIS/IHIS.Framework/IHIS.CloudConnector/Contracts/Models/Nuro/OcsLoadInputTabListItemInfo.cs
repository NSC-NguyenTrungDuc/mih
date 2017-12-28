using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class OcsLoadInputTabListItemInfo
	{
		private String _inputTab;
		private String _orderGubun;
		private String _mainYn;
		private String _defaultYn;

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public String OrderGubun
		{
			get { return this._orderGubun; }
			set { this._orderGubun = value; }
		}

		public String MainYn
		{
			get { return this._mainYn; }
			set { this._mainYn = value; }
		}

		public String DefaultYn
		{
			get { return this._defaultYn; }
			set { this._defaultYn = value; }
		}

		public OcsLoadInputTabListItemInfo() { }

		public OcsLoadInputTabListItemInfo(String inputTab, String orderGubun, String mainYn, String defaultYn)
		{
			this._inputTab = inputTab;
			this._orderGubun = orderGubun;
			this._mainYn = mainYn;
			this._defaultYn = defaultYn;
		}

	}
}
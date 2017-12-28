using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class OcsLoadVisibleControlListItemInfo
	{
		private String _inputTab;
		private String _colName;
		private String _visibleYn;

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public String ColName
		{
			get { return this._colName; }
			set { this._colName = value; }
		}

		public String VisibleYn
		{
			get { return this._visibleYn; }
			set { this._visibleYn = value; }
		}

		public OcsLoadVisibleControlListItemInfo() { }

		public OcsLoadVisibleControlListItemInfo(String inputTab, String colName, String visibleYn)
		{
			this._inputTab = inputTab;
			this._colName = colName;
			this._visibleYn = visibleYn;
		}

	}
}
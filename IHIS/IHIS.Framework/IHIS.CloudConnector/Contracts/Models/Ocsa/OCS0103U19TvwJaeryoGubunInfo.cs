using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U19TvwJaeryoGubunInfo
	{
		private String _orderGubun;
		private String _orderGubunName;
		private String _sortKey;

		public String OrderGubun
		{
			get { return this._orderGubun; }
			set { this._orderGubun = value; }
		}

		public String OrderGubunName
		{
			get { return this._orderGubunName; }
			set { this._orderGubunName = value; }
		}

		public String SortKey
		{
			get { return this._sortKey; }
			set { this._sortKey = value; }
		}

		public OCS0103U19TvwJaeryoGubunInfo() { }

		public OCS0103U19TvwJaeryoGubunInfo(String orderGubun, String orderGubunName, String sortKey)
		{
			this._orderGubun = orderGubun;
			this._orderGubunName = orderGubunName;
			this._sortKey = sortKey;
		}

	}
}
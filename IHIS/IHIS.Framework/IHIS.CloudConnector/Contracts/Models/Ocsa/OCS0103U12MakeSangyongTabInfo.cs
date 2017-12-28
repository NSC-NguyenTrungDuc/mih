using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U12MakeSangyongTabInfo
	{
		private String _orderGubun;
		private String _orderGubunName;
		private String _memb;
		private String _ynValue;
		private String _sort;

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

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String YnValue
		{
			get { return this._ynValue; }
			set { this._ynValue = value; }
		}

		public String Sort
		{
			get { return this._sort; }
			set { this._sort = value; }
		}

		public OCS0103U12MakeSangyongTabInfo() { }

		public OCS0103U12MakeSangyongTabInfo(String orderGubun, String orderGubunName, String memb, String ynValue, String sort)
		{
			this._orderGubun = orderGubun;
			this._orderGubunName = orderGubunName;
			this._memb = memb;
			this._ynValue = ynValue;
			this._sort = sort;
		}

	}
}
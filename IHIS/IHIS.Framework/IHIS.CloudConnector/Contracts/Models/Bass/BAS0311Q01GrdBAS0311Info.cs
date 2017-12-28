using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
	public class BAS0311Q01GrdBAS0311Info
	{
		private String _sgYmd;
		private String _sgCode;
		private String _sgName;
		private String _sgNameKana;
		private String _bunCode;
		private String _groupGubun;
		private String _danui;
		private String _bulyongYmd;

		public String SgYmd
		{
			get { return this._sgYmd; }
			set { this._sgYmd = value; }
		}

		public String SgCode
		{
			get { return this._sgCode; }
			set { this._sgCode = value; }
		}

		public String SgName
		{
			get { return this._sgName; }
			set { this._sgName = value; }
		}

		public String SgNameKana
		{
			get { return this._sgNameKana; }
			set { this._sgNameKana = value; }
		}

		public String BunCode
		{
			get { return this._bunCode; }
			set { this._bunCode = value; }
		}

		public String GroupGubun
		{
			get { return this._groupGubun; }
			set { this._groupGubun = value; }
		}

		public String Danui
		{
			get { return this._danui; }
			set { this._danui = value; }
		}

		public String BulyongYmd
		{
			get { return this._bulyongYmd; }
			set { this._bulyongYmd = value; }
		}

		public BAS0311Q01GrdBAS0311Info() { }

		public BAS0311Q01GrdBAS0311Info(String sgYmd, String sgCode, String sgName, String sgNameKana, String bunCode, String groupGubun, String danui, String bulyongYmd)
		{
			this._sgYmd = sgYmd;
			this._sgCode = sgCode;
			this._sgName = sgName;
			this._sgNameKana = sgNameKana;
			this._bunCode = bunCode;
			this._groupGubun = groupGubun;
			this._danui = danui;
			this._bulyongYmd = bulyongYmd;
		}

	}
}
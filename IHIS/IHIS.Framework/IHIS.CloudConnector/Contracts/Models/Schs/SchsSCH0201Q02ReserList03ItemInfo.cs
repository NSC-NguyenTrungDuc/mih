using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SchsSCH0201Q02ReserList03ItemInfo
	{
		private String _reserDate;
		private String _suname;
		private String _inOutGubun;
		private String _bunho;
		private String _actingDate;
		private String _comments;
		private String _jundalPartName;
		private String _gwaName;
		private String _updName;
		private String _contKey;

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String Suname
		{
			get { return this._suname; }
			set { this._suname = value; }
		}

		public String InOutGubun
		{
			get { return this._inOutGubun; }
			set { this._inOutGubun = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String ActingDate
		{
			get { return this._actingDate; }
			set { this._actingDate = value; }
		}

		public String Comments
		{
			get { return this._comments; }
			set { this._comments = value; }
		}

		public String JundalPartName
		{
			get { return this._jundalPartName; }
			set { this._jundalPartName = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String UpdName
		{
			get { return this._updName; }
			set { this._updName = value; }
		}

		public String ContKey
		{
			get { return this._contKey; }
			set { this._contKey = value; }
		}

		public SchsSCH0201Q02ReserList03ItemInfo() { }

		public SchsSCH0201Q02ReserList03ItemInfo(String reserDate, String suname, String inOutGubun, String bunho, String actingDate, String comments, String jundalPartName, String gwaName, String updName, String contKey)
		{
			this._reserDate = reserDate;
			this._suname = suname;
			this._inOutGubun = inOutGubun;
			this._bunho = bunho;
			this._actingDate = actingDate;
			this._comments = comments;
			this._jundalPartName = jundalPartName;
			this._gwaName = gwaName;
			this._updName = updName;
			this._contKey = contKey;
		}

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class Ocs0204Q00GrdOcs0204ListItemInfo
	{
		private String _memb;
		private String _sangGubun;
		private String _sangGubunName;
		private String _seq;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String SangGubun
		{
			get { return this._sangGubun; }
			set { this._sangGubun = value; }
		}

		public String SangGubunName
		{
			get { return this._sangGubunName; }
			set { this._sangGubunName = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public Ocs0204Q00GrdOcs0204ListItemInfo() { }

		public Ocs0204Q00GrdOcs0204ListItemInfo(String memb, String sangGubun, String sangGubunName, String seq)
		{
			this._memb = memb;
			this._sangGubun = sangGubun;
			this._sangGubunName = sangGubunName;
			this._seq = seq;
		}

	}
}
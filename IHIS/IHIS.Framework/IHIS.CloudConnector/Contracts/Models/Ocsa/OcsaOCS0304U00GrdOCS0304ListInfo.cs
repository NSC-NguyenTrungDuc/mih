using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OcsaOCS0304U00GrdOCS0304ListInfo
	{
		private String _memb;
		private String _membGubun;
		private String _yaksokDirectCode;
		private String _yaksokDirectName;
		private String _seq;
		private String _ment;
		private String _rowState;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String MembGubun
		{
			get { return this._membGubun; }
			set { this._membGubun = value; }
		}

		public String YaksokDirectCode
		{
			get { return this._yaksokDirectCode; }
			set { this._yaksokDirectCode = value; }
		}

		public String YaksokDirectName
		{
			get { return this._yaksokDirectName; }
			set { this._yaksokDirectName = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public String Ment
		{
			get { return this._ment; }
			set { this._ment = value; }
		}

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public OcsaOCS0304U00GrdOCS0304ListInfo() { }

		public OcsaOCS0304U00GrdOCS0304ListInfo(String memb, String membGubun, String yaksokDirectCode, String yaksokDirectName, String seq, String ment, String rowState)
		{
			this._memb = memb;
			this._membGubun = membGubun;
			this._yaksokDirectCode = yaksokDirectCode;
			this._yaksokDirectName = yaksokDirectName;
			this._seq = seq;
			this._ment = ment;
			this._rowState = rowState;
		}

	}
}
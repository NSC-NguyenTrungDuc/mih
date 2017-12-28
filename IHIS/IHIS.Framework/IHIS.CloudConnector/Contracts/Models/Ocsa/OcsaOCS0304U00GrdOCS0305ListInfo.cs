using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OcsaOCS0304U00GrdOCS0305ListInfo
	{
		private String _memb;
		private String _yaksokDirectCode;
		private String _pkSeq;
		private String _directGubun;
		private String _nurGrName;
		private String _directCode;
		private String _nurMdName;
		private String _directCont1;
		private String _directCont2;
		private String _directText;
		private String _directContYn;
		private String _rowState;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String YaksokDirectCode
		{
			get { return this._yaksokDirectCode; }
			set { this._yaksokDirectCode = value; }
		}

		public String PkSeq
		{
			get { return this._pkSeq; }
			set { this._pkSeq = value; }
		}

		public String DirectGubun
		{
			get { return this._directGubun; }
			set { this._directGubun = value; }
		}

		public String NurGrName
		{
			get { return this._nurGrName; }
			set { this._nurGrName = value; }
		}

		public String DirectCode
		{
			get { return this._directCode; }
			set { this._directCode = value; }
		}

		public String NurMdName
		{
			get { return this._nurMdName; }
			set { this._nurMdName = value; }
		}

		public String DirectCont1
		{
			get { return this._directCont1; }
			set { this._directCont1 = value; }
		}

		public String DirectCont2
		{
			get { return this._directCont2; }
			set { this._directCont2 = value; }
		}

		public String DirectText
		{
			get { return this._directText; }
			set { this._directText = value; }
		}

		public String DirectContYn
		{
			get { return this._directContYn; }
			set { this._directContYn = value; }
		}

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public OcsaOCS0304U00GrdOCS0305ListInfo() { }

		public OcsaOCS0304U00GrdOCS0305ListInfo(String memb, String yaksokDirectCode, String pkSeq, String directGubun, String nurGrName, String directCode, String nurMdName, String directCont1, String directCont2, String directText, String directContYn, String rowState)
		{
			this._memb = memb;
			this._yaksokDirectCode = yaksokDirectCode;
			this._pkSeq = pkSeq;
			this._directGubun = directGubun;
			this._nurGrName = nurGrName;
			this._directCode = directCode;
			this._nurMdName = nurMdName;
			this._directCont1 = directCont1;
			this._directCont2 = directCont2;
			this._directText = directText;
			this._directContYn = directContYn;
			this._rowState = rowState;
		}

	}
}
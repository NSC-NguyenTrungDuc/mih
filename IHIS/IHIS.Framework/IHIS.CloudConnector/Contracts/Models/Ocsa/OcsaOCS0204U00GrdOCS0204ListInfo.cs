using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OcsaOCS0204U00GrdOCS0204ListInfo
	{
		private String _memb;
		private String _fSeq;
		private String _sangGubun;
		private String _sangGubunName;
		private String _dataRowState;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String FSeq
		{
			get { return this._fSeq; }
			set { this._fSeq = value; }
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

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public OcsaOCS0204U00GrdOCS0204ListInfo() { }

		public OcsaOCS0204U00GrdOCS0204ListInfo(String memb, String fSeq, String sangGubun, String sangGubunName, String dataRowState)
		{
			this._memb = memb;
			this._fSeq = fSeq;
			this._sangGubun = sangGubun;
			this._sangGubunName = sangGubunName;
			this._dataRowState = dataRowState;
		}

	}
}
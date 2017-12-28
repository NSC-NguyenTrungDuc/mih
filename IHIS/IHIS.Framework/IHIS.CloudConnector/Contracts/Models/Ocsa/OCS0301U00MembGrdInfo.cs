using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0301U00MembGrdInfo
	{
		private String _memb;
		private String _keySeq;
		private String _yaksok;
		private String _yaksokName;
		private String _seq;
		private String _hospCode;
		private String _membGubun;
		private String _inputTab;
		private String _dataRowState;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String KeySeq
		{
			get { return this._keySeq; }
			set { this._keySeq = value; }
		}

		public String Yaksok
		{
			get { return this._yaksok; }
			set { this._yaksok = value; }
		}

		public String YaksokName
		{
			get { return this._yaksokName; }
			set { this._yaksokName = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public String HospCode
		{
			get { return this._hospCode; }
			set { this._hospCode = value; }
		}

		public String MembGubun
		{
			get { return this._membGubun; }
			set { this._membGubun = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public OCS0301U00MembGrdInfo() { }

		public OCS0301U00MembGrdInfo(String memb, String keySeq, String yaksok, String yaksokName, String seq, String hospCode, String membGubun, String inputTab, String dataRowState)
		{
			this._memb = memb;
			this._keySeq = keySeq;
			this._yaksok = yaksok;
			this._yaksokName = yaksokName;
			this._seq = seq;
			this._hospCode = hospCode;
			this._membGubun = membGubun;
			this._inputTab = inputTab;
			this._dataRowState = dataRowState;
		}

	}
}
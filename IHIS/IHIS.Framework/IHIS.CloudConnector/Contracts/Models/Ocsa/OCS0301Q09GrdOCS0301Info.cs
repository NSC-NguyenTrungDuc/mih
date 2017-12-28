using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0301Q09GrdOCS0301Info
	{
		private String _memb;
		private String _pkSeq;
		private String _yaksokGubun;
		private String _yaksokGubunName;
		private String _yaksokCode;
		private String _yaksokName;
		private String _inputTab;
		private String _pkYaksok;
		private String _inputTabName;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String PkSeq
		{
			get { return this._pkSeq; }
			set { this._pkSeq = value; }
		}

		public String YaksokGubun
		{
			get { return this._yaksokGubun; }
			set { this._yaksokGubun = value; }
		}

		public String YaksokGubunName
		{
			get { return this._yaksokGubunName; }
			set { this._yaksokGubunName = value; }
		}

		public String YaksokCode
		{
			get { return this._yaksokCode; }
			set { this._yaksokCode = value; }
		}

		public String YaksokName
		{
			get { return this._yaksokName; }
			set { this._yaksokName = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public String PkYaksok
		{
			get { return this._pkYaksok; }
			set { this._pkYaksok = value; }
		}

		public String InputTabName
		{
			get { return this._inputTabName; }
			set { this._inputTabName = value; }
		}

		public OCS0301Q09GrdOCS0301Info() { }

		public OCS0301Q09GrdOCS0301Info(String memb, String pkSeq, String yaksokGubun, String yaksokGubunName, String yaksokCode, String yaksokName, String inputTab, String pkYaksok, String inputTabName)
		{
			this._memb = memb;
			this._pkSeq = pkSeq;
			this._yaksokGubun = yaksokGubun;
			this._yaksokGubunName = yaksokGubunName;
			this._yaksokCode = yaksokCode;
			this._yaksokName = yaksokName;
			this._inputTab = inputTab;
			this._pkYaksok = pkYaksok;
			this._inputTabName = inputTabName;
		}

	}
}
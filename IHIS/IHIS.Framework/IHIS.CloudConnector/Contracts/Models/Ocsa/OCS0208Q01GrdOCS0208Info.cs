using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0208Q01GrdOCS0208Info
	{
		private String _gubun;
		private String _bogyongCode;
		private String _bogyongName;
		private String _userYn;
		private String _bogyongGubun;
		private String _seq;

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String BogyongCode
		{
			get { return this._bogyongCode; }
			set { this._bogyongCode = value; }
		}

		public String BogyongName
		{
			get { return this._bogyongName; }
			set { this._bogyongName = value; }
		}

		public String UserYn
		{
			get { return this._userYn; }
			set { this._userYn = value; }
		}

		public String BogyongGubun
		{
			get { return this._bogyongGubun; }
			set { this._bogyongGubun = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public OCS0208Q01GrdOCS0208Info() { }

		public OCS0208Q01GrdOCS0208Info(String gubun, String bogyongCode, String bogyongName, String userYn, String bogyongGubun, String seq)
		{
			this._gubun = gubun;
			this._bogyongCode = bogyongCode;
			this._bogyongName = bogyongName;
			this._userYn = userYn;
			this._bogyongGubun = bogyongGubun;
			this._seq = seq;
		}

	}
}
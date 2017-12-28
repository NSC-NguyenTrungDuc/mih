using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OcsaOCS0208U00GrdOCS0208U00ListInfo
	{
		private String _doctor;
		private String _seq;
		private String _bogyongCode;
		private String _bogyongName;
		private String _bunryu1;
		private String _dataRowState;

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
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

		public String Bunryu1
		{
			get { return this._bunryu1; }
			set { this._bunryu1 = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public OcsaOCS0208U00GrdOCS0208U00ListInfo() { }

		public OcsaOCS0208U00GrdOCS0208U00ListInfo(String doctor, String seq, String bogyongCode, String bogyongName, String bunryu1, String dataRowState)
		{
			this._doctor = doctor;
			this._seq = seq;
			this._bogyongCode = bogyongCode;
			this._bogyongName = bogyongName;
			this._bunryu1 = bunryu1;
			this._dataRowState = dataRowState;
		}

	}
}
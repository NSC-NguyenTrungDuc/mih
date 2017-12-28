using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
	public class OCS2015U04LoadExaminationInfo
	{
		private String _pkout1001;
		private String _naewonDate;
		private String _gwa;

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public OCS2015U04LoadExaminationInfo() { }

		public OCS2015U04LoadExaminationInfo(String pkout1001, String naewonDate, String gwa)
		{
			this._pkout1001 = pkout1001;
			this._naewonDate = naewonDate;
			this._gwa = gwa;
		}

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
	public class OcsoOCS1003P01LayPatInfo
	{
		private String _gwa;
		private String _bunho;
		private String _doctor;
		private String _groupKey;
		private String _naewonYn;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String GroupKey
		{
			get { return this._groupKey; }
			set { this._groupKey = value; }
		}

		public String NaewonYn
		{
			get { return this._naewonYn; }
			set { this._naewonYn = value; }
		}

		public OcsoOCS1003P01LayPatInfo() { }

		public OcsoOCS1003P01LayPatInfo(String gwa, String bunho, String doctor, String groupKey, String naewonYn)
		{
			this._gwa = gwa;
			this._bunho = bunho;
			this._doctor = doctor;
			this._groupKey = groupKey;
			this._naewonYn = naewonYn;
		}

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0503Q00FilteringTheInformationInfo
	{
		private String _reserYn;
		private String _jinryoTime;
		private String _gwaName;
		private String _doctorName;
		private String _naewonYn;
		private String _bunho;
		private String _naewonDate;
		private String _gwa;
		private String _doctor;
		private String _naewonType;
		private String _jubsuNo;

		public String ReserYn
		{
			get { return this._reserYn; }
			set { this._reserYn = value; }
		}

		public String JinryoTime
		{
			get { return this._jinryoTime; }
			set { this._jinryoTime = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String NaewonYn
		{
			get { return this._naewonYn; }
			set { this._naewonYn = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
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

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String NaewonType
		{
			get { return this._naewonType; }
			set { this._naewonType = value; }
		}

		public String JubsuNo
		{
			get { return this._jubsuNo; }
			set { this._jubsuNo = value; }
		}

		public OCS0503Q00FilteringTheInformationInfo() { }

		public OCS0503Q00FilteringTheInformationInfo(String reserYn, String jinryoTime, String gwaName, String doctorName, String naewonYn, String bunho, String naewonDate, String gwa, String doctor, String naewonType, String jubsuNo)
		{
			this._reserYn = reserYn;
			this._jinryoTime = jinryoTime;
			this._gwaName = gwaName;
			this._doctorName = doctorName;
			this._naewonYn = naewonYn;
			this._bunho = bunho;
			this._naewonDate = naewonDate;
			this._gwa = gwa;
			this._doctor = doctor;
			this._naewonType = naewonType;
			this._jubsuNo = jubsuNo;
		}

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class NuroOUT1001U01GetDoctorInfo
	{
		private String _gwa;
		private String _gwaName;
		private String _doctor;
		private String _doctorName;
		private String _waitingPatient;
		private String _totalPatient;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String WaitingPatient
		{
			get { return this._waitingPatient; }
			set { this._waitingPatient = value; }
		}

		public String TotalPatient
		{
			get { return this._totalPatient; }
			set { this._totalPatient = value; }
		}

		public NuroOUT1001U01GetDoctorInfo() { }

		public NuroOUT1001U01GetDoctorInfo(String gwa, String gwaName, String doctor, String doctorName, String waitingPatient, String totalPatient)
		{
			this._gwa = gwa;
			this._gwaName = gwaName;
			this._doctor = doctor;
			this._doctorName = doctorName;
			this._waitingPatient = waitingPatient;
			this._totalPatient = totalPatient;
		}

	}
}
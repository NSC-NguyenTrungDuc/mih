using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
	public class FormGwaItemInfo
	{
		private String _doctor;
		private String _doctorGwa;
		private String _gwaName;

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String DoctorGwa
		{
			get { return this._doctorGwa; }
			set { this._doctorGwa = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public FormGwaItemInfo() { }

		public FormGwaItemInfo(String doctor, String doctorGwa, String gwaName)
		{
			this._doctor = doctor;
			this._doctorGwa = doctorGwa;
			this._gwaName = gwaName;
		}

	}
}
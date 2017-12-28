using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
	public class OUTSANGU00findBoxToDoctorInfo
	{
		private String _doctor;
		private String _doctorName;
		private String _contKey;

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

		public String ContKey
		{
			get { return this._contKey; }
			set { this._contKey = value; }
		}

		public OUTSANGU00findBoxToDoctorInfo() { }

		public OUTSANGU00findBoxToDoctorInfo(String doctor, String doctorName, String contKey)
		{
			this._doctor = doctor;
			this._doctorName = doctorName;
			this._contKey = contKey;
		}

	}
}
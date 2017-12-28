using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class NuroRES0102U00GetDoctorInfo
	{
		private String _doctor;

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public NuroRES0102U00GetDoctorInfo() { }

		public NuroRES0102U00GetDoctorInfo(String doctor)
		{
			this._doctor = doctor;
		}

	}
}
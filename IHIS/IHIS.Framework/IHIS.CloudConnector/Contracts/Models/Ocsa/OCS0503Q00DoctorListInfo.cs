using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0503Q00DoctorListInfo
	{
		private String _doctor;
		private String _doctorName;
		private String _doctorSort;

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

		public String DoctorSort
		{
			get { return this._doctorSort; }
			set { this._doctorSort = value; }
		}

		public OCS0503Q00DoctorListInfo() { }

		public OCS0503Q00DoctorListInfo(String doctor, String doctorName, String doctorSort)
		{
			this._doctor = doctor;
			this._doctorName = doctorName;
			this._doctorSort = doctorSort;
		}

	}
}
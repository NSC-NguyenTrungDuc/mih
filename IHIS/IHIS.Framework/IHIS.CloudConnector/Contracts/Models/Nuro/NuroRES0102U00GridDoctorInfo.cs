using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class NuroRES0102U00GridDoctorInfo
	{
		private String _doctor;
		private String _startDate;
		private String _endDate;
		private String _sayu;
		private String _dataRowState;

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public String EndDate
		{
			get { return this._endDate; }
			set { this._endDate = value; }
		}

		public String Sayu
		{
			get { return this._sayu; }
			set { this._sayu = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public NuroRES0102U00GridDoctorInfo() { }

		public NuroRES0102U00GridDoctorInfo(String doctor, String startDate, String endDate, String sayu, String dataRowState)
		{
			this._doctor = doctor;
			this._startDate = startDate;
			this._endDate = endDate;
			this._sayu = sayu;
			this._dataRowState = dataRowState;
		}

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable ]
	public class NuroRES1001U00ReserListItemInfo
	{
		private String _comingDate;
		private String _examPreTime;
		private String _departmentName;
		private String _doctorName;

		public String ComingDate
		{
			get { return this._comingDate; }
			set { this._comingDate = value; }
		}

		public String ExamPreTime
		{
			get { return this._examPreTime; }
			set { this._examPreTime = value; }
		}

		public String DepartmentName
		{
			get { return this._departmentName; }
			set { this._departmentName = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public NuroRES1001U00ReserListItemInfo() { }

		public NuroRES1001U00ReserListItemInfo(String comingDate, String examPreTime, String departmentName, String doctorName)
		{
			this._comingDate = comingDate;
			this._examPreTime = examPreTime;
			this._departmentName = departmentName;
			this._doctorName = doctorName;
		}

	}
}
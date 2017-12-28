using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OcsaOCS0503Q01ListDataInfo
	{
		private String _ioGubun;
		private String _bunho;
		private String _reqDate;
		private String _jinryoPreDate;
		private String _reqGwa;
		private String _reqDoctor;
		private String _appDate;
		private String _consultGwa;
		private String _consultDoctor;
		private String _reqGwaName;
		private String _reqDoctorName;
		private String _consultGwaName;
		private String _consultDoctorName;

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String ReqDate
		{
			get { return this._reqDate; }
			set { this._reqDate = value; }
		}

		public String JinryoPreDate
		{
			get { return this._jinryoPreDate; }
			set { this._jinryoPreDate = value; }
		}

		public String ReqGwa
		{
			get { return this._reqGwa; }
			set { this._reqGwa = value; }
		}

		public String ReqDoctor
		{
			get { return this._reqDoctor; }
			set { this._reqDoctor = value; }
		}

		public String AppDate
		{
			get { return this._appDate; }
			set { this._appDate = value; }
		}

		public String ConsultGwa
		{
			get { return this._consultGwa; }
			set { this._consultGwa = value; }
		}

		public String ConsultDoctor
		{
			get { return this._consultDoctor; }
			set { this._consultDoctor = value; }
		}

		public String ReqGwaName
		{
			get { return this._reqGwaName; }
			set { this._reqGwaName = value; }
		}

		public String ReqDoctorName
		{
			get { return this._reqDoctorName; }
			set { this._reqDoctorName = value; }
		}

		public String ConsultGwaName
		{
			get { return this._consultGwaName; }
			set { this._consultGwaName = value; }
		}

		public String ConsultDoctorName
		{
			get { return this._consultDoctorName; }
			set { this._consultDoctorName = value; }
		}

		public OcsaOCS0503Q01ListDataInfo() { }

		public OcsaOCS0503Q01ListDataInfo(String ioGubun, String bunho, String reqDate, String jinryoPreDate, String reqGwa, String reqDoctor, String appDate, String consultGwa, String consultDoctor, String reqGwaName, String reqDoctorName, String consultGwaName, String consultDoctorName)
		{
			this._ioGubun = ioGubun;
			this._bunho = bunho;
			this._reqDate = reqDate;
			this._jinryoPreDate = jinryoPreDate;
			this._reqGwa = reqGwa;
			this._reqDoctor = reqDoctor;
			this._appDate = appDate;
			this._consultGwa = consultGwa;
			this._consultDoctor = consultDoctor;
			this._reqGwaName = reqGwaName;
			this._reqDoctorName = reqDoctorName;
			this._consultGwaName = consultGwaName;
			this._consultDoctorName = consultDoctorName;
		}

	}
}
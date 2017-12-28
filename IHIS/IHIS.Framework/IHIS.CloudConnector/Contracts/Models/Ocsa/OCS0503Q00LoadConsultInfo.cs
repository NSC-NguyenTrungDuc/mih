using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0503Q00LoadConsultInfo
	{
		private String _ioGubun;
		private String _answerYn;
		private String _gwaConsultYn;
		private String _naewonDate;
		private String _jinryoTime;
		private String _bunho;
		private String _suname;
		private String _suname2;
		private String _hoDong;
		private String _sexAge;
		private String _gubunName;
		private String _gwa;
		private String _doctor;
		private String _naewonType;
		private String _jubsuNo;
		private String _chojae;
		private String _chojaeName;
		private String _pkNaewon;
		private String _naewonYn;
		private String _reqDate;
		private String _reqGwa;
		private String _reqDoctor;
		private String _consultGwa;
		private String _consultDoctor;
		private String _reqIoGubun;
		private String _consGwaName;
		private String _consDoctorName;
		private String _answerUpdYn;
		private String _appDate;
		private String _pkocs0503;
		private String _orderEndYn;

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public String AnswerYn
		{
			get { return this._answerYn; }
			set { this._answerYn = value; }
		}

		public String GwaConsultYn
		{
			get { return this._gwaConsultYn; }
			set { this._gwaConsultYn = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String JinryoTime
		{
			get { return this._jinryoTime; }
			set { this._jinryoTime = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Suname
		{
			get { return this._suname; }
			set { this._suname = value; }
		}

		public String Suname2
		{
			get { return this._suname2; }
			set { this._suname2 = value; }
		}

		public String HoDong
		{
			get { return this._hoDong; }
			set { this._hoDong = value; }
		}

		public String SexAge
		{
			get { return this._sexAge; }
			set { this._sexAge = value; }
		}

		public String GubunName
		{
			get { return this._gubunName; }
			set { this._gubunName = value; }
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

		public String Chojae
		{
			get { return this._chojae; }
			set { this._chojae = value; }
		}

		public String ChojaeName
		{
			get { return this._chojaeName; }
			set { this._chojaeName = value; }
		}

		public String PkNaewon
		{
			get { return this._pkNaewon; }
			set { this._pkNaewon = value; }
		}

		public String NaewonYn
		{
			get { return this._naewonYn; }
			set { this._naewonYn = value; }
		}

		public String ReqDate
		{
			get { return this._reqDate; }
			set { this._reqDate = value; }
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

		public String ReqIoGubun
		{
			get { return this._reqIoGubun; }
			set { this._reqIoGubun = value; }
		}

		public String ConsGwaName
		{
			get { return this._consGwaName; }
			set { this._consGwaName = value; }
		}

		public String ConsDoctorName
		{
			get { return this._consDoctorName; }
			set { this._consDoctorName = value; }
		}

		public String AnswerUpdYn
		{
			get { return this._answerUpdYn; }
			set { this._answerUpdYn = value; }
		}

		public String AppDate
		{
			get { return this._appDate; }
			set { this._appDate = value; }
		}

		public String Pkocs0503
		{
			get { return this._pkocs0503; }
			set { this._pkocs0503 = value; }
		}

		public String OrderEndYn
		{
			get { return this._orderEndYn; }
			set { this._orderEndYn = value; }
		}

		public OCS0503Q00LoadConsultInfo() { }

		public OCS0503Q00LoadConsultInfo(String ioGubun, String answerYn, String gwaConsultYn, String naewonDate, String jinryoTime, String bunho, String suname, String suname2, String hoDong, String sexAge, String gubunName, String gwa, String doctor, String naewonType, String jubsuNo, String chojae, String chojaeName, String pkNaewon, String naewonYn, String reqDate, String reqGwa, String reqDoctor, String consultGwa, String consultDoctor, String reqIoGubun, String consGwaName, String consDoctorName, String answerUpdYn, String appDate, String pkocs0503, String orderEndYn)
		{
			this._ioGubun = ioGubun;
			this._answerYn = answerYn;
			this._gwaConsultYn = gwaConsultYn;
			this._naewonDate = naewonDate;
			this._jinryoTime = jinryoTime;
			this._bunho = bunho;
			this._suname = suname;
			this._suname2 = suname2;
			this._hoDong = hoDong;
			this._sexAge = sexAge;
			this._gubunName = gubunName;
			this._gwa = gwa;
			this._doctor = doctor;
			this._naewonType = naewonType;
			this._jubsuNo = jubsuNo;
			this._chojae = chojae;
			this._chojaeName = chojaeName;
			this._pkNaewon = pkNaewon;
			this._naewonYn = naewonYn;
			this._reqDate = reqDate;
			this._reqGwa = reqGwa;
			this._reqDoctor = reqDoctor;
			this._consultGwa = consultGwa;
			this._consultDoctor = consultDoctor;
			this._reqIoGubun = reqIoGubun;
			this._consGwaName = consGwaName;
			this._consDoctorName = consDoctorName;
			this._answerUpdYn = answerUpdYn;
			this._appDate = appDate;
			this._pkocs0503 = pkocs0503;
			this._orderEndYn = orderEndYn;
		}

	}
}
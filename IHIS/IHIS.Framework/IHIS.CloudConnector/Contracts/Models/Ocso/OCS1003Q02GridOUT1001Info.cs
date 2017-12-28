using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
	public class OCS1003Q02GridOUT1001Info
	{
		private String _jubsu;
		private String _reserYn;
		private String _jinryoTime;
		private String _gwaName;
		private String _doctorName;
		private String _naewonYnName;
		private String _bunho;
		private String _naewonDate;
		private String _gwa;
		private String _doctor;
		private String _naewonType;
		private String _jubsuNo;
		private String _pkNaewon;
		private String _orderEndYn;

		public String Jubsu
		{
			get { return this._jubsu; }
			set { this._jubsu = value; }
		}

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

		public String NaewonYnName
		{
			get { return this._naewonYnName; }
			set { this._naewonYnName = value; }
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

		public String PkNaewon
		{
			get { return this._pkNaewon; }
			set { this._pkNaewon = value; }
		}

		public String OrderEndYn
		{
			get { return this._orderEndYn; }
			set { this._orderEndYn = value; }
		}

		public OCS1003Q02GridOUT1001Info() { }

		public OCS1003Q02GridOUT1001Info(String jubsu, String reserYn, String jinryoTime, String gwaName, String doctorName, String naewonYnName, String bunho, String naewonDate, String gwa, String doctor, String naewonType, String jubsuNo, String pkNaewon, String orderEndYn)
		{
			this._jubsu = jubsu;
			this._reserYn = reserYn;
			this._jinryoTime = jinryoTime;
			this._gwaName = gwaName;
			this._doctorName = doctorName;
			this._naewonYnName = naewonYnName;
			this._bunho = bunho;
			this._naewonDate = naewonDate;
			this._gwa = gwa;
			this._doctor = doctor;
			this._naewonType = naewonType;
			this._jubsuNo = jubsuNo;
			this._pkNaewon = pkNaewon;
			this._orderEndYn = orderEndYn;
		}

	}
}
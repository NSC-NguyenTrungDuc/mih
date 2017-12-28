using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class MultiResultViewLayPaInfo
	{
		private String _suname;
		private String _suname2;
		private String _sex;
		private String _yearAge;
		private String _monthAge;
		private String _gubun;
		private String _admDictNm;
		private String _birth;
		private String _tel;
		private String _tel1;
		private String _telHp;
		private String _email;
		private String _zipCode1;
		private String _zipCode2;
		private String _address1;
		private String _address2;
		private String _inpJaewonCheck;

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

		public String Sex
		{
			get { return this._sex; }
			set { this._sex = value; }
		}

		public String YearAge
		{
			get { return this._yearAge; }
			set { this._yearAge = value; }
		}

		public String MonthAge
		{
			get { return this._monthAge; }
			set { this._monthAge = value; }
		}

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String AdmDictNm
		{
			get { return this._admDictNm; }
			set { this._admDictNm = value; }
		}

		public String Birth
		{
			get { return this._birth; }
			set { this._birth = value; }
		}

		public String Tel
		{
			get { return this._tel; }
			set { this._tel = value; }
		}

		public String Tel1
		{
			get { return this._tel1; }
			set { this._tel1 = value; }
		}

		public String TelHp
		{
			get { return this._telHp; }
			set { this._telHp = value; }
		}

		public String Email
		{
			get { return this._email; }
			set { this._email = value; }
		}

		public String ZipCode1
		{
			get { return this._zipCode1; }
			set { this._zipCode1 = value; }
		}

		public String ZipCode2
		{
			get { return this._zipCode2; }
			set { this._zipCode2 = value; }
		}

		public String Address1
		{
			get { return this._address1; }
			set { this._address1 = value; }
		}

		public String Address2
		{
			get { return this._address2; }
			set { this._address2 = value; }
		}

		public String InpJaewonCheck
		{
			get { return this._inpJaewonCheck; }
			set { this._inpJaewonCheck = value; }
		}

		public MultiResultViewLayPaInfo() { }

		public MultiResultViewLayPaInfo(String suname, String suname2, String sex, String yearAge, String monthAge, String gubun, String admDictNm, String birth, String tel, String tel1, String telHp, String email, String zipCode1, String zipCode2, String address1, String address2, String inpJaewonCheck)
		{
			this._suname = suname;
			this._suname2 = suname2;
			this._sex = sex;
			this._yearAge = yearAge;
			this._monthAge = monthAge;
			this._gubun = gubun;
			this._admDictNm = admDictNm;
			this._birth = birth;
			this._tel = tel;
			this._tel1 = tel1;
			this._telHp = telHp;
			this._email = email;
			this._zipCode1 = zipCode1;
			this._zipCode2 = zipCode2;
			this._address1 = address1;
			this._address2 = address2;
			this._inpJaewonCheck = inpJaewonCheck;
		}

	}
}
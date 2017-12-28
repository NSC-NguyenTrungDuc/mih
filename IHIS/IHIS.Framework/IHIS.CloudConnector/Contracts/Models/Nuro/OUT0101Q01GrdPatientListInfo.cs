using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class OUT0101Q01GrdPatientListInfo
	{
		private String _bunho;
		private String _suname;
		private String _suname2;
		private String _sex;
		private String _birth;
		private String _zipCode1;
		private String _zipCode2;
		private String _address1;
		private String _address2;
		private String _address;
		private String _tel;
		private String _tel1;
		private String _gubun;
		private String _jubsuBreak;
		private String _jubsuBreakReason;
		private String _deleteYn;
		private String _remark;
		private String _telHp;
		private String _email;
		private String _fnOutLoadLastNaewonDate;
		private String _fnBasLoadCodeName;
		private String _noHeader;
		private String _hoDong;
		private String _contKey;

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

		public String Sex
		{
			get { return this._sex; }
			set { this._sex = value; }
		}

		public String Birth
		{
			get { return this._birth; }
			set { this._birth = value; }
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

		public String Address
		{
			get { return this._address; }
			set { this._address = value; }
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

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String JubsuBreak
		{
			get { return this._jubsuBreak; }
			set { this._jubsuBreak = value; }
		}

		public String JubsuBreakReason
		{
			get { return this._jubsuBreakReason; }
			set { this._jubsuBreakReason = value; }
		}

		public String DeleteYn
		{
			get { return this._deleteYn; }
			set { this._deleteYn = value; }
		}

		public String Remark
		{
			get { return this._remark; }
			set { this._remark = value; }
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

		public String FnOutLoadLastNaewonDate
		{
			get { return this._fnOutLoadLastNaewonDate; }
			set { this._fnOutLoadLastNaewonDate = value; }
		}

		public String FnBasLoadCodeName
		{
			get { return this._fnBasLoadCodeName; }
			set { this._fnBasLoadCodeName = value; }
		}

		public String NoHeader
		{
			get { return this._noHeader; }
			set { this._noHeader = value; }
		}

		public String HoDong
		{
			get { return this._hoDong; }
			set { this._hoDong = value; }
		}

		public String ContKey
		{
			get { return this._contKey; }
			set { this._contKey = value; }
		}

		public OUT0101Q01GrdPatientListInfo() { }

		public OUT0101Q01GrdPatientListInfo(String bunho, String suname, String suname2, String sex, String birth, String zipCode1, String zipCode2, String address1, String address2, String address, String tel, String tel1, String gubun, String jubsuBreak, String jubsuBreakReason, String deleteYn, String remark, String telHp, String email, String fnOutLoadLastNaewonDate, String fnBasLoadCodeName, String noHeader, String hoDong, String contKey)
		{
			this._bunho = bunho;
			this._suname = suname;
			this._suname2 = suname2;
			this._sex = sex;
			this._birth = birth;
			this._zipCode1 = zipCode1;
			this._zipCode2 = zipCode2;
			this._address1 = address1;
			this._address2 = address2;
			this._address = address;
			this._tel = tel;
			this._tel1 = tel1;
			this._gubun = gubun;
			this._jubsuBreak = jubsuBreak;
			this._jubsuBreakReason = jubsuBreakReason;
			this._deleteYn = deleteYn;
			this._remark = remark;
			this._telHp = telHp;
			this._email = email;
			this._fnOutLoadLastNaewonDate = fnOutLoadLastNaewonDate;
			this._fnBasLoadCodeName = fnBasLoadCodeName;
			this._noHeader = noHeader;
			this._hoDong = hoDong;
			this._contKey = contKey;
		}

	}
}
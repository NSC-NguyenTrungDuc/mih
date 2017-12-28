using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL3020U00CplSpecimenInfo
	{
		private String _bunho;
		private String _suname;
		private String _sex;
		private String _birth;
		private String _sujumin1;
		private String _sujumin2;
		private String _gwa;
		private String _doctorName;
		private String _hoDong;
		private String _hoCode;
		private String _orderDate;
		private String _jubsuDate;
		private String _partJubsuDate;
		private String _jubsuTime;
		private String _partJubsuTime;
		private String _jubsuja;
		private String _inOutGubun;
		private String _jundalGubun;
		private String _specimenCode;
		private String _specimenName;
		private String _tat1;
		private String _tat2;
		private String _age;
		private String _switchValue;

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

		public String Sujumin1
		{
			get { return this._sujumin1; }
			set { this._sujumin1 = value; }
		}

		public String Sujumin2
		{
			get { return this._sujumin2; }
			set { this._sujumin2 = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String HoDong
		{
			get { return this._hoDong; }
			set { this._hoDong = value; }
		}

		public String HoCode
		{
			get { return this._hoCode; }
			set { this._hoCode = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
		}

		public String PartJubsuDate
		{
			get { return this._partJubsuDate; }
			set { this._partJubsuDate = value; }
		}

		public String JubsuTime
		{
			get { return this._jubsuTime; }
			set { this._jubsuTime = value; }
		}

		public String PartJubsuTime
		{
			get { return this._partJubsuTime; }
			set { this._partJubsuTime = value; }
		}

		public String Jubsuja
		{
			get { return this._jubsuja; }
			set { this._jubsuja = value; }
		}

		public String InOutGubun
		{
			get { return this._inOutGubun; }
			set { this._inOutGubun = value; }
		}

		public String JundalGubun
		{
			get { return this._jundalGubun; }
			set { this._jundalGubun = value; }
		}

		public String SpecimenCode
		{
			get { return this._specimenCode; }
			set { this._specimenCode = value; }
		}

		public String SpecimenName
		{
			get { return this._specimenName; }
			set { this._specimenName = value; }
		}

		public String Tat1
		{
			get { return this._tat1; }
			set { this._tat1 = value; }
		}

		public String Tat2
		{
			get { return this._tat2; }
			set { this._tat2 = value; }
		}

		public String Age
		{
			get { return this._age; }
			set { this._age = value; }
		}

		public String SwitchValue
		{
			get { return this._switchValue; }
			set { this._switchValue = value; }
		}

		public CPL3020U00CplSpecimenInfo() { }

		public CPL3020U00CplSpecimenInfo(String bunho, String suname, String sex, String birth, String sujumin1, String sujumin2, String gwa, String doctorName, String hoDong, String hoCode, String orderDate, String jubsuDate, String partJubsuDate, String jubsuTime, String partJubsuTime, String jubsuja, String inOutGubun, String jundalGubun, String specimenCode, String specimenName, String tat1, String tat2, String age, String switchValue)
		{
			this._bunho = bunho;
			this._suname = suname;
			this._sex = sex;
			this._birth = birth;
			this._sujumin1 = sujumin1;
			this._sujumin2 = sujumin2;
			this._gwa = gwa;
			this._doctorName = doctorName;
			this._hoDong = hoDong;
			this._hoCode = hoCode;
			this._orderDate = orderDate;
			this._jubsuDate = jubsuDate;
			this._partJubsuDate = partJubsuDate;
			this._jubsuTime = jubsuTime;
			this._partJubsuTime = partJubsuTime;
			this._jubsuja = jubsuja;
			this._inOutGubun = inOutGubun;
			this._jundalGubun = jundalGubun;
			this._specimenCode = specimenCode;
			this._specimenName = specimenName;
			this._tat1 = tat1;
			this._tat2 = tat2;
			this._age = age;
			this._switchValue = switchValue;
		}

	}
}
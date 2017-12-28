using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
	public class BAS0110Q00GrdBAS0110ItemInfo
	{
		private String _johap;
		private String _startDate;
		private String _johapName;
		private String _johapGubun;
		private String _zipCode1;
		private String _zipCode2;
		private String _address;
		private String _tel;
		private String _lawNo;
		private String _dodobuhyeunNo;
		private String _boheomjaNo;
		private String _cd;
		private String _giho;
		private String _remark;
		private String _checkDigitYn;
		private String _johapGubunName;

		public String Johap
		{
			get { return this._johap; }
			set { this._johap = value; }
		}

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public String JohapName
		{
			get { return this._johapName; }
			set { this._johapName = value; }
		}

		public String JohapGubun
		{
			get { return this._johapGubun; }
			set { this._johapGubun = value; }
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

		public String LawNo
		{
			get { return this._lawNo; }
			set { this._lawNo = value; }
		}

		public String DodobuhyeunNo
		{
			get { return this._dodobuhyeunNo; }
			set { this._dodobuhyeunNo = value; }
		}

		public String BoheomjaNo
		{
			get { return this._boheomjaNo; }
			set { this._boheomjaNo = value; }
		}

		public String Cd
		{
			get { return this._cd; }
			set { this._cd = value; }
		}

		public String Giho
		{
			get { return this._giho; }
			set { this._giho = value; }
		}

		public String Remark
		{
			get { return this._remark; }
			set { this._remark = value; }
		}

		public String CheckDigitYn
		{
			get { return this._checkDigitYn; }
			set { this._checkDigitYn = value; }
		}

		public String JohapGubunName
		{
			get { return this._johapGubunName; }
			set { this._johapGubunName = value; }
		}

		public BAS0110Q00GrdBAS0110ItemInfo() { }

		public BAS0110Q00GrdBAS0110ItemInfo(String johap, String startDate, String johapName, String johapGubun, String zipCode1, String zipCode2, String address, String tel, String lawNo, String dodobuhyeunNo, String boheomjaNo, String cd, String giho, String remark, String checkDigitYn, String johapGubunName)
		{
			this._johap = johap;
			this._startDate = startDate;
			this._johapName = johapName;
			this._johapGubun = johapGubun;
			this._zipCode1 = zipCode1;
			this._zipCode2 = zipCode2;
			this._address = address;
			this._tel = tel;
			this._lawNo = lawNo;
			this._dodobuhyeunNo = dodobuhyeunNo;
			this._boheomjaNo = boheomjaNo;
			this._cd = cd;
			this._giho = giho;
			this._remark = remark;
			this._checkDigitYn = checkDigitYn;
			this._johapGubunName = johapGubunName;
		}

	}
}
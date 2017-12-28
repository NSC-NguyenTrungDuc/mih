using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class InjsINJ1001U01TempListItemInfo
	{
		private String _serialV;
		private String _bunho;
		private String _suname;
		private String _suname2;
		private String _age;
		private String _sex;
		private String _orderDate;
		private String _jubsuDate;
		private String _cnt;
		private String _suryang;
		private String _danuiName;
		private String _bogyongName;
		private String _jusaName;
		private String _jaeryoName;
		private String _orderRemark;
		private String _dataGubun;
		private String _birth;
		private String _doctorName;
		private String _gwaName;

		public String SerialV
		{
			get { return this._serialV; }
			set { this._serialV = value; }
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

		public String Age
		{
			get { return this._age; }
			set { this._age = value; }
		}

		public String Sex
		{
			get { return this._sex; }
			set { this._sex = value; }
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

		public String Cnt
		{
			get { return this._cnt; }
			set { this._cnt = value; }
		}

		public String Suryang
		{
			get { return this._suryang; }
			set { this._suryang = value; }
		}

		public String DanuiName
		{
			get { return this._danuiName; }
			set { this._danuiName = value; }
		}

		public String BogyongName
		{
			get { return this._bogyongName; }
			set { this._bogyongName = value; }
		}

		public String JusaName
		{
			get { return this._jusaName; }
			set { this._jusaName = value; }
		}

		public String JaeryoName
		{
			get { return this._jaeryoName; }
			set { this._jaeryoName = value; }
		}

		public String OrderRemark
		{
			get { return this._orderRemark; }
			set { this._orderRemark = value; }
		}

		public String DataGubun
		{
			get { return this._dataGubun; }
			set { this._dataGubun = value; }
		}

		public String Birth
		{
			get { return this._birth; }
			set { this._birth = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public InjsINJ1001U01TempListItemInfo() { }

		public InjsINJ1001U01TempListItemInfo(String serialV, String bunho, String suname, String suname2, String age, String sex, String orderDate, String jubsuDate, String cnt, String suryang, String danuiName, String bogyongName, String jusaName, String jaeryoName, String orderRemark, String dataGubun, String birth, String doctorName, String gwaName)
		{
			this._serialV = serialV;
			this._bunho = bunho;
			this._suname = suname;
			this._suname2 = suname2;
			this._age = age;
			this._sex = sex;
			this._orderDate = orderDate;
			this._jubsuDate = jubsuDate;
			this._cnt = cnt;
			this._suryang = suryang;
			this._danuiName = danuiName;
			this._bogyongName = bogyongName;
			this._jusaName = jusaName;
			this._jaeryoName = jaeryoName;
			this._orderRemark = orderRemark;
			this._dataGubun = dataGubun;
			this._birth = birth;
			this._doctorName = doctorName;
			this._gwaName = gwaName;
		}

	}
}
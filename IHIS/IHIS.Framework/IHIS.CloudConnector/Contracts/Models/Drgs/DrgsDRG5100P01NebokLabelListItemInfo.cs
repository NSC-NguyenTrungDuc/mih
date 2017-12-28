using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01NebokLabelListItemInfo
	{
		private String _bunho;
		private String _gwaName;
		private String _doctorName;
		private String _suname;
		private String _suname2;
		private String _age;
		private String _sex;
		private String _birth;
		private String _drgBunho;
		private String _rpBunho;
		private String _reserDate;
		private String _jusaGubun;
		private String _jusaSpdGubun;
		private String _suryang;
		private String _ordDanui;
		private String _dvTime;
		private String _dv;
		private String _bogyongCode;
		private String _subulSuryang;
		private String _subulDanui;
		private String _jaeryoName;
		private String _nalsuCnt;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
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

		public String Birth
		{
			get { return this._birth; }
			set { this._birth = value; }
		}

		public String DrgBunho
		{
			get { return this._drgBunho; }
			set { this._drgBunho = value; }
		}

		public String RpBunho
		{
			get { return this._rpBunho; }
			set { this._rpBunho = value; }
		}

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String JusaGubun
		{
			get { return this._jusaGubun; }
			set { this._jusaGubun = value; }
		}

		public String JusaSpdGubun
		{
			get { return this._jusaSpdGubun; }
			set { this._jusaSpdGubun = value; }
		}

		public String Suryang
		{
			get { return this._suryang; }
			set { this._suryang = value; }
		}

		public String OrdDanui
		{
			get { return this._ordDanui; }
			set { this._ordDanui = value; }
		}

		public String DvTime
		{
			get { return this._dvTime; }
			set { this._dvTime = value; }
		}

		public String Dv
		{
			get { return this._dv; }
			set { this._dv = value; }
		}

		public String BogyongCode
		{
			get { return this._bogyongCode; }
			set { this._bogyongCode = value; }
		}

		public String SubulSuryang
		{
			get { return this._subulSuryang; }
			set { this._subulSuryang = value; }
		}

		public String SubulDanui
		{
			get { return this._subulDanui; }
			set { this._subulDanui = value; }
		}

		public String JaeryoName
		{
			get { return this._jaeryoName; }
			set { this._jaeryoName = value; }
		}

		public String NalsuCnt
		{
			get { return this._nalsuCnt; }
			set { this._nalsuCnt = value; }
		}

		public DrgsDRG5100P01NebokLabelListItemInfo() { }

		public DrgsDRG5100P01NebokLabelListItemInfo(String bunho, String gwaName, String doctorName, String suname, String suname2, String age, String sex, String birth, String drgBunho, String rpBunho, String reserDate, String jusaGubun, String jusaSpdGubun, String suryang, String ordDanui, String dvTime, String dv, String bogyongCode, String subulSuryang, String subulDanui, String jaeryoName, String nalsuCnt)
		{
			this._bunho = bunho;
			this._gwaName = gwaName;
			this._doctorName = doctorName;
			this._suname = suname;
			this._suname2 = suname2;
			this._age = age;
			this._sex = sex;
			this._birth = birth;
			this._drgBunho = drgBunho;
			this._rpBunho = rpBunho;
			this._reserDate = reserDate;
			this._jusaGubun = jusaGubun;
			this._jusaSpdGubun = jusaSpdGubun;
			this._suryang = suryang;
			this._ordDanui = ordDanui;
			this._dvTime = dvTime;
			this._dv = dv;
			this._bogyongCode = bogyongCode;
			this._subulSuryang = subulSuryang;
			this._subulDanui = subulDanui;
			this._jaeryoName = jaeryoName;
			this._nalsuCnt = nalsuCnt;
		}

	}
}
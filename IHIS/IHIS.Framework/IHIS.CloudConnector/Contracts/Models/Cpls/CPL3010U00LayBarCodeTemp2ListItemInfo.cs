using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL3010U00LayBarCodeTemp2ListItemInfo
	{
		private String _jundalGubun;
		private String _jundalGubunName;
		private String _specimenCode;
		private String _specimenName;
		private String _tubeCode;
		private String _tubeName;
		private String _inOutGubun;
		private String _specimenSer;
		private String _bunho;
		private String _suname;
		private String _uitakName;
		private String _dangerYn;
		private String _specimenSerBa;
		private String _jangbiName;
		private String _gumsaNameRe;
		private String _tubeAmt;
		private String _tubeNumbering;

		public String JundalGubun
		{
			get { return this._jundalGubun; }
			set { this._jundalGubun = value; }
		}

		public String JundalGubunName
		{
			get { return this._jundalGubunName; }
			set { this._jundalGubunName = value; }
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

		public String TubeCode
		{
			get { return this._tubeCode; }
			set { this._tubeCode = value; }
		}

		public String TubeName
		{
			get { return this._tubeName; }
			set { this._tubeName = value; }
		}

		public String InOutGubun
		{
			get { return this._inOutGubun; }
			set { this._inOutGubun = value; }
		}

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
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

		public String UitakName
		{
			get { return this._uitakName; }
			set { this._uitakName = value; }
		}

		public String DangerYn
		{
			get { return this._dangerYn; }
			set { this._dangerYn = value; }
		}

		public String SpecimenSerBa
		{
			get { return this._specimenSerBa; }
			set { this._specimenSerBa = value; }
		}

		public String JangbiName
		{
			get { return this._jangbiName; }
			set { this._jangbiName = value; }
		}

		public String GumsaNameRe
		{
			get { return this._gumsaNameRe; }
			set { this._gumsaNameRe = value; }
		}

		public String TubeAmt
		{
			get { return this._tubeAmt; }
			set { this._tubeAmt = value; }
		}

		public String TubeNumbering
		{
			get { return this._tubeNumbering; }
			set { this._tubeNumbering = value; }
		}

		public CPL3010U00LayBarCodeTemp2ListItemInfo() { }

		public CPL3010U00LayBarCodeTemp2ListItemInfo(String jundalGubun, String jundalGubunName, String specimenCode, String specimenName, String tubeCode, String tubeName, String inOutGubun, String specimenSer, String bunho, String suname, String uitakName, String dangerYn, String specimenSerBa, String jangbiName, String gumsaNameRe, String tubeAmt, String tubeNumbering)
		{
			this._jundalGubun = jundalGubun;
			this._jundalGubunName = jundalGubunName;
			this._specimenCode = specimenCode;
			this._specimenName = specimenName;
			this._tubeCode = tubeCode;
			this._tubeName = tubeName;
			this._inOutGubun = inOutGubun;
			this._specimenSer = specimenSer;
			this._bunho = bunho;
			this._suname = suname;
			this._uitakName = uitakName;
			this._dangerYn = dangerYn;
			this._specimenSerBa = specimenSerBa;
			this._jangbiName = jangbiName;
			this._gumsaNameRe = gumsaNameRe;
			this._tubeAmt = tubeAmt;
			this._tubeNumbering = tubeNumbering;
		}

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U13LayGroupTabListInfo
	{
		private String _iocsGubun;
		private String _fkout1001;
		private String _groupSer;
		private String _bogyongCode;
		private String _bogyongName;
		private String _nalsu;
		private String _emergency;
		private String _wonyoiOrderYn;

		public String IocsGubun
		{
			get { return this._iocsGubun; }
			set { this._iocsGubun = value; }
		}

		public String Fkout1001
		{
			get { return this._fkout1001; }
			set { this._fkout1001 = value; }
		}

		public String GroupSer
		{
			get { return this._groupSer; }
			set { this._groupSer = value; }
		}

		public String BogyongCode
		{
			get { return this._bogyongCode; }
			set { this._bogyongCode = value; }
		}

		public String BogyongName
		{
			get { return this._bogyongName; }
			set { this._bogyongName = value; }
		}

		public String Nalsu
		{
			get { return this._nalsu; }
			set { this._nalsu = value; }
		}

		public String Emergency
		{
			get { return this._emergency; }
			set { this._emergency = value; }
		}

		public String WonyoiOrderYn
		{
			get { return this._wonyoiOrderYn; }
			set { this._wonyoiOrderYn = value; }
		}

		public OCS0103U13LayGroupTabListInfo() { }

		public OCS0103U13LayGroupTabListInfo(String iocsGubun, String fkout1001, String groupSer, String bogyongCode, String bogyongName, String nalsu, String emergency, String wonyoiOrderYn)
		{
			this._iocsGubun = iocsGubun;
			this._fkout1001 = fkout1001;
			this._groupSer = groupSer;
			this._bogyongCode = bogyongCode;
			this._bogyongName = bogyongName;
			this._nalsu = nalsu;
			this._emergency = emergency;
			this._wonyoiOrderYn = wonyoiOrderYn;
		}

	}
}
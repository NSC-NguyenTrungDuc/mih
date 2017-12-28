using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0208Q01GrdDrg0120Info
	{
		private String _bogyongCode;
		private String _bogyongName;
		private String _blockGubun;
		private String _bogyongGubun;

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

		public String BlockGubun
		{
			get { return this._blockGubun; }
			set { this._blockGubun = value; }
		}

		public String BogyongGubun
		{
			get { return this._bogyongGubun; }
			set { this._bogyongGubun = value; }
		}

		public OCS0208Q01GrdDrg0120Info() { }

		public OCS0208Q01GrdDrg0120Info(String bogyongCode, String bogyongName, String blockGubun, String bogyongGubun)
		{
			this._bogyongCode = bogyongCode;
			this._bogyongName = bogyongName;
			this._blockGubun = blockGubun;
			this._bogyongGubun = bogyongGubun;
		}

	}
}
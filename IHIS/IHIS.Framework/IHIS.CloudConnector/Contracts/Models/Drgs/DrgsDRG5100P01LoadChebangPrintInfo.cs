using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01LoadChebangPrintInfo
	{
		private String _oGubunName;
		private String _oJohap;
		private String _oGaein;
		private String _oGaeinNo;
		private String _oBoninGubun;
		private String _oBonRate;
		private String _oBudamjaBunho1;
		private String _oSugubjaBunho1;
		private String _oBudamjaBunho2;
		private String _oSugubjaBunho2;
		private String _oSunwonGubun;
		private String _oNoinRateName;
		private String _oErr;

		public String OGubunName
		{
			get { return this._oGubunName; }
			set { this._oGubunName = value; }
		}

		public String OJohap
		{
			get { return this._oJohap; }
			set { this._oJohap = value; }
		}

		public String OGaein
		{
			get { return this._oGaein; }
			set { this._oGaein = value; }
		}

		public String OGaeinNo
		{
			get { return this._oGaeinNo; }
			set { this._oGaeinNo = value; }
		}

		public String OBoninGubun
		{
			get { return this._oBoninGubun; }
			set { this._oBoninGubun = value; }
		}

		public String OBonRate
		{
			get { return this._oBonRate; }
			set { this._oBonRate = value; }
		}

		public String OBudamjaBunho1
		{
			get { return this._oBudamjaBunho1; }
			set { this._oBudamjaBunho1 = value; }
		}

		public String OSugubjaBunho1
		{
			get { return this._oSugubjaBunho1; }
			set { this._oSugubjaBunho1 = value; }
		}

		public String OBudamjaBunho2
		{
			get { return this._oBudamjaBunho2; }
			set { this._oBudamjaBunho2 = value; }
		}

		public String OSugubjaBunho2
		{
			get { return this._oSugubjaBunho2; }
			set { this._oSugubjaBunho2 = value; }
		}

		public String OSunwonGubun
		{
			get { return this._oSunwonGubun; }
			set { this._oSunwonGubun = value; }
		}

		public String ONoinRateName
		{
			get { return this._oNoinRateName; }
			set { this._oNoinRateName = value; }
		}

		public String OErr
		{
			get { return this._oErr; }
			set { this._oErr = value; }
		}

		public DrgsDRG5100P01LoadChebangPrintInfo() { }

		public DrgsDRG5100P01LoadChebangPrintInfo(String oGubunName, String oJohap, String oGaein, String oGaeinNo, String oBoninGubun, String oBonRate, String oBudamjaBunho1, String oSugubjaBunho1, String oBudamjaBunho2, String oSugubjaBunho2, String oSunwonGubun, String oNoinRateName, String oErr)
		{
			this._oGubunName = oGubunName;
			this._oJohap = oJohap;
			this._oGaein = oGaein;
			this._oGaeinNo = oGaeinNo;
			this._oBoninGubun = oBoninGubun;
			this._oBonRate = oBonRate;
			this._oBudamjaBunho1 = oBudamjaBunho1;
			this._oSugubjaBunho1 = oSugubjaBunho1;
			this._oBudamjaBunho2 = oBudamjaBunho2;
			this._oSugubjaBunho2 = oSugubjaBunho2;
			this._oSunwonGubun = oSunwonGubun;
			this._oNoinRateName = oNoinRateName;
			this._oErr = oErr;
		}

	}
}
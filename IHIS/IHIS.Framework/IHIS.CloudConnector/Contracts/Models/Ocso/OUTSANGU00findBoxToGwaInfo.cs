using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
	public class OUTSANGU00findBoxToGwaInfo
	{
		private String _gwa;
		private String _gwaName;
		private String _buseoCode;

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String BuseoCode
		{
			get { return this._buseoCode; }
			set { this._buseoCode = value; }
		}

		public OUTSANGU00findBoxToGwaInfo() { }

		public OUTSANGU00findBoxToGwaInfo(String gwa, String gwaName, String buseoCode)
		{
			this._gwa = gwa;
			this._gwaName = gwaName;
			this._buseoCode = buseoCode;
		}

	}
}
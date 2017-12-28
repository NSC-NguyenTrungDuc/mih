using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
	public class BuseoInfo
	{
		private String _buseoCode;
		private String _buseoName;

		public String BuseoCode
		{
			get { return this._buseoCode; }
			set { this._buseoCode = value; }
		}

		public String BuseoName
		{
			get { return this._buseoName; }
			set { this._buseoName = value; }
		}

		public BuseoInfo() { }

		public BuseoInfo(String buseoCode, String buseoName)
		{
			this._buseoCode = buseoCode;
			this._buseoName = buseoName;
		}

	}
}
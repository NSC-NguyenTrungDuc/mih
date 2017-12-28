using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
	public class OCS2015U03OrderGubunInfo
	{
		private String _orderGubun;

		public String OrderGubun
		{
			get { return this._orderGubun; }
			set { this._orderGubun = value; }
		}

		public OCS2015U03OrderGubunInfo() { }

		public OCS2015U03OrderGubunInfo(String orderGubun)
		{
			this._orderGubun = orderGubun;
		}

	}
}
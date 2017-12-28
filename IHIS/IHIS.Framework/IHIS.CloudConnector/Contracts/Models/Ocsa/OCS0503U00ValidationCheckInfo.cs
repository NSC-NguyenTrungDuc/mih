using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0503U00ValidationCheckInfo
	{
		private String _naewon;
		private String _orderYn;

		public String Naewon
		{
			get { return this._naewon; }
			set { this._naewon = value; }
		}

		public String OrderYn
		{
			get { return this._orderYn; }
			set { this._orderYn = value; }
		}

		public OCS0503U00ValidationCheckInfo() { }

		public OCS0503U00ValidationCheckInfo(String naewon, String orderYn)
		{
			this._naewon = naewon;
			this._orderYn = orderYn;
		}

	}
}
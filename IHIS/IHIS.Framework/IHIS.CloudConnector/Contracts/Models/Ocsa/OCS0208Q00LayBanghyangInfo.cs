using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0208Q00LayBanghyangInfo
	{
		private String _banghyang;
		private String _donbogYn;

		public String Banghyang
		{
			get { return this._banghyang; }
			set { this._banghyang = value; }
		}

		public String DonbogYn
		{
			get { return this._donbogYn; }
			set { this._donbogYn = value; }
		}

		public OCS0208Q00LayBanghyangInfo() { }

		public OCS0208Q00LayBanghyangInfo(String banghyang, String donbogYn)
		{
			this._banghyang = banghyang;
			this._donbogYn = donbogYn;
		}

	}
}
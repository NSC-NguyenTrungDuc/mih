using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class NuroChkGetBunhoBySujinInfo
	{
		private String _bunho;
		private String _suname;

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

		public NuroChkGetBunhoBySujinInfo() { }

		public NuroChkGetBunhoBySujinInfo(String bunho, String suname)
		{
			this._bunho = bunho;
			this._suname = suname;
		}

	}
}
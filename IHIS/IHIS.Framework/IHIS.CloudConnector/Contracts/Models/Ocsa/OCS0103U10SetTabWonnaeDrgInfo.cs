using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U10SetTabWonnaeDrgInfo
	{
		private String _filter;
		private String _cnt;
		private String _yakKijunCode;

		public String Filter
		{
			get { return this._filter; }
			set { this._filter = value; }
		}

		public String Cnt
		{
			get { return this._cnt; }
			set { this._cnt = value; }
		}

		public String YakKijunCode
		{
			get { return this._yakKijunCode; }
			set { this._yakKijunCode = value; }
		}

		public OCS0103U10SetTabWonnaeDrgInfo() { }

		public OCS0103U10SetTabWonnaeDrgInfo(String filter, String cnt, String yakKijunCode)
		{
			this._filter = filter;
			this._cnt = cnt;
			this._yakKijunCode = yakKijunCode;
		}

	}
}
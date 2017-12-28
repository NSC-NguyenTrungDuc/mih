using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U12SetTabWonnaeDrugInfo
	{
		private String _filter;
		private String _count;
		private String _yakKijunCode;

		public String Filter
		{
			get { return this._filter; }
			set { this._filter = value; }
		}

		public String Count
		{
			get { return this._count; }
			set { this._count = value; }
		}

		public String YakKijunCode
		{
			get { return this._yakKijunCode; }
			set { this._yakKijunCode = value; }
		}

		public OCS0103U12SetTabWonnaeDrugInfo() { }

		public OCS0103U12SetTabWonnaeDrugInfo(String filter, String count, String yakKijunCode)
		{
			this._filter = filter;
			this._count = count;
			this._yakKijunCode = yakKijunCode;
		}

	}
}
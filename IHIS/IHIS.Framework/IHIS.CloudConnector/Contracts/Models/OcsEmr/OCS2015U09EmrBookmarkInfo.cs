using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    [Serializable]
	public class OCS2015U09EmrBookmarkInfo
	{
		private String _bookmarkText;
		private String _naewonDate;
		private String _pkout1001;

		public String BookmarkText
		{
			get { return this._bookmarkText; }
			set { this._bookmarkText = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String Pkout1001
		{
			get { return this._pkout1001; }
			set { this._pkout1001 = value; }
		}

		public OCS2015U09EmrBookmarkInfo() { }

		public OCS2015U09EmrBookmarkInfo(String bookmarkText, String naewonDate, String pkout1001)
		{
			this._bookmarkText = bookmarkText;
			this._naewonDate = naewonDate;
			this._pkout1001 = pkout1001;
		}

	}
}
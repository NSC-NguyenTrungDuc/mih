using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0221Q01GrdOCS0222Info
	{
		private String _memb;
		private String _seq;
		private String _serial;
		private String _commentTitle;
		private String _commentText;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String Seq
		{
			get { return this._seq; }
			set { this._seq = value; }
		}

		public String Serial
		{
			get { return this._serial; }
			set { this._serial = value; }
		}

		public String CommentTitle
		{
			get { return this._commentTitle; }
			set { this._commentTitle = value; }
		}

		public String CommentText
		{
			get { return this._commentText; }
			set { this._commentText = value; }
		}

		public OCS0221Q01GrdOCS0222Info() { }

		public OCS0221Q01GrdOCS0222Info(String memb, String seq, String serial, String commentTitle, String commentText)
		{
			this._memb = memb;
			this._seq = seq;
			this._serial = serial;
			this._commentTitle = commentTitle;
			this._commentText = commentText;
		}

	}
}
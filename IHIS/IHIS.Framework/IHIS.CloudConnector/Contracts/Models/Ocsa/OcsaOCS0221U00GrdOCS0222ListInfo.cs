using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OcsaOCS0221U00GrdOCS0222ListInfo
	{
		private String _memb;
		private String _seq;
		private String _serial;
		private String _commentTitle;
		private String _commentText;
		private String _dataRowState;

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

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public OcsaOCS0221U00GrdOCS0222ListInfo() { }

		public OcsaOCS0221U00GrdOCS0222ListInfo(String memb, String seq, String serial, String commentTitle, String commentText, String dataRowState)
		{
			this._memb = memb;
			this._seq = seq;
			this._serial = serial;
			this._commentTitle = commentTitle;
			this._commentText = commentText;
			this._dataRowState = dataRowState;
		}

	}
}
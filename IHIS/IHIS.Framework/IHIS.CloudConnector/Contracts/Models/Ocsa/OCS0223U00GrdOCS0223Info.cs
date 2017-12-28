using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0223U00GrdOCS0223Info
	{
		private String _jundalPart;
		private String _jundalPartName;
		private String _seq;
		private String _serial;
		private String _commentTitle;
		private String _commentText;
		private String _rowState;

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public String JundalPartName
		{
			get { return this._jundalPartName; }
			set { this._jundalPartName = value; }
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

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public OCS0223U00GrdOCS0223Info() { }

		public OCS0223U00GrdOCS0223Info(String jundalPart, String jundalPartName, String seq, String serial, String commentTitle, String commentText, String rowState)
		{
			this._jundalPart = jundalPart;
			this._jundalPartName = jundalPartName;
			this._seq = seq;
			this._serial = serial;
			this._commentTitle = commentTitle;
			this._commentText = commentText;
			this._rowState = rowState;
		}

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.Outs
{
    [Serializable]
	public class OUT0106U00GridItemInfo
	{
		private String _comments;
		private String _ser;
		private String _bunho;
		private String _displayYn;
		private String _dataRowState;

		public String Comments
		{
			get { return this._comments; }
			set { this._comments = value; }
		}

		public String Ser
		{
			get { return this._ser; }
			set { this._ser = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String DisplayYn
		{
			get { return this._displayYn; }
			set { this._displayYn = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public OUT0106U00GridItemInfo() { }

		public OUT0106U00GridItemInfo(String comments, String ser, String bunho, String displayYn, String dataRowState)
		{
			this._comments = comments;
			this._ser = ser;
			this._bunho = bunho;
			this._displayYn = displayYn;
			this._dataRowState = dataRowState;
		}

	}
}
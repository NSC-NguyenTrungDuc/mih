using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OcsaOCS0221U00GrdOCS0221ListInfo
	{
		private String _memb;
		private String _fSeq;
		private String _categoryGubun;
		private String _categoryName;
		private String _commentLimit;
		private String _dataRowState;

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String FSeq
		{
			get { return this._fSeq; }
			set { this._fSeq = value; }
		}

		public String CategoryGubun
		{
			get { return this._categoryGubun; }
			set { this._categoryGubun = value; }
		}

		public String CategoryName
		{
			get { return this._categoryName; }
			set { this._categoryName = value; }
		}

		public String CommentLimit
		{
			get { return this._commentLimit; }
			set { this._commentLimit = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public OcsaOCS0221U00GrdOCS0221ListInfo() { }

		public OcsaOCS0221U00GrdOCS0221ListInfo(String memb, String fSeq, String categoryGubun, String categoryName, String commentLimit, String dataRowState)
		{
			this._memb = memb;
			this._fSeq = fSeq;
			this._categoryGubun = categoryGubun;
			this._categoryName = categoryName;
			this._commentLimit = commentLimit;
			this._dataRowState = dataRowState;
		}

	}
}
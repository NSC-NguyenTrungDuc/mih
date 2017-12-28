using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL3020U00DsvNoteListItemInfo
	{
		private String _jundalPart;
		private String _specimenSer;
		private String _note;
		private String _code;
		private String _etcComment;

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
		}

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public String Note
		{
			get { return this._note; }
			set { this._note = value; }
		}

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String EtcComment
		{
			get { return this._etcComment; }
			set { this._etcComment = value; }
		}

		public CPL3020U00DsvNoteListItemInfo() { }

		public CPL3020U00DsvNoteListItemInfo(String jundalPart, String specimenSer, String note, String code, String etcComment)
		{
			this._jundalPart = jundalPart;
			this._specimenSer = specimenSer;
			this._note = note;
			this._code = code;
			this._etcComment = etcComment;
		}

	}
}
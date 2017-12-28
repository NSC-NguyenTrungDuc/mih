using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL3020U00GrdNoteUpdateInfo
	{
		private String _jundalGubun;
		private String _specimenSer;
		private String _code;
		private String _note;
		private String _etcComment;
		private String _dataRowState;

		public String JundalGubun
		{
			get { return this._jundalGubun; }
			set { this._jundalGubun = value; }
		}

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String Note
		{
			get { return this._note; }
			set { this._note = value; }
		}

		public String EtcComment
		{
			get { return this._etcComment; }
			set { this._etcComment = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public CPL3020U00GrdNoteUpdateInfo() { }

		public CPL3020U00GrdNoteUpdateInfo(String jundalGubun, String specimenSer, String code, String note, String etcComment, String dataRowState)
		{
			this._jundalGubun = jundalGubun;
			this._specimenSer = specimenSer;
			this._code = code;
			this._note = note;
			this._etcComment = etcComment;
			this._dataRowState = dataRowState;
		}

	}
}
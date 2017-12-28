using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
	public class CPL0000Q00LayJungboListItemInfo
	{
		private String _orderDate;
		private String _orderTime;
		private String _jubsuDate;
		private String _jubsuTime;
		private String _partJubsuDate;
		private String _partJubsuTime;
		private String _resultDate;
		private String _resultTime;
		private String _specimenSer;
		private String _specimenCode;
		private String _specimenName;
		private String _note;
		private String _gwaName;
		private String _doctorName;
		private String _comment;
		private String _fixNote;
		private String _hangmogComment;
		private String _paComment;

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String OrderTime
		{
			get { return this._orderTime; }
			set { this._orderTime = value; }
		}

		public String JubsuDate
		{
			get { return this._jubsuDate; }
			set { this._jubsuDate = value; }
		}

		public String JubsuTime
		{
			get { return this._jubsuTime; }
			set { this._jubsuTime = value; }
		}

		public String PartJubsuDate
		{
			get { return this._partJubsuDate; }
			set { this._partJubsuDate = value; }
		}

		public String PartJubsuTime
		{
			get { return this._partJubsuTime; }
			set { this._partJubsuTime = value; }
		}

		public String ResultDate
		{
			get { return this._resultDate; }
			set { this._resultDate = value; }
		}

		public String ResultTime
		{
			get { return this._resultTime; }
			set { this._resultTime = value; }
		}

		public String SpecimenSer
		{
			get { return this._specimenSer; }
			set { this._specimenSer = value; }
		}

		public String SpecimenCode
		{
			get { return this._specimenCode; }
			set { this._specimenCode = value; }
		}

		public String SpecimenName
		{
			get { return this._specimenName; }
			set { this._specimenName = value; }
		}

		public String Note
		{
			get { return this._note; }
			set { this._note = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String Comment
		{
			get { return this._comment; }
			set { this._comment = value; }
		}

		public String FixNote
		{
			get { return this._fixNote; }
			set { this._fixNote = value; }
		}

		public String HangmogComment
		{
			get { return this._hangmogComment; }
			set { this._hangmogComment = value; }
		}

		public String PaComment
		{
			get { return this._paComment; }
			set { this._paComment = value; }
		}

		public CPL0000Q00LayJungboListItemInfo() { }

		public CPL0000Q00LayJungboListItemInfo(String orderDate, String orderTime, String jubsuDate, String jubsuTime, String partJubsuDate, String partJubsuTime, String resultDate, String resultTime, String specimenSer, String specimenCode, String specimenName, String note, String gwaName, String doctorName, String comment, String fixNote, String hangmogComment, String paComment)
		{
			this._orderDate = orderDate;
			this._orderTime = orderTime;
			this._jubsuDate = jubsuDate;
			this._jubsuTime = jubsuTime;
			this._partJubsuDate = partJubsuDate;
			this._partJubsuTime = partJubsuTime;
			this._resultDate = resultDate;
			this._resultTime = resultTime;
			this._specimenSer = specimenSer;
			this._specimenCode = specimenCode;
			this._specimenName = specimenName;
			this._note = note;
			this._gwaName = gwaName;
			this._doctorName = doctorName;
			this._comment = comment;
			this._fixNote = fixNote;
			this._hangmogComment = hangmogComment;
			this._paComment = paComment;
		}

	}
}
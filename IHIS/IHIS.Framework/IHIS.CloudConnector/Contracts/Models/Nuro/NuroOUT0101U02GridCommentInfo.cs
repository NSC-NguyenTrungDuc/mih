using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable ]
	public class NuroOUT0101U02GridCommentInfo
	{
		private String _ser;
		private String _comment;
		private String _patientCode;

		public String Ser
		{
			get { return this._ser; }
			set { this._ser = value; }
		}

		public String Comment
		{
			get { return this._comment; }
			set { this._comment = value; }
		}

		public String PatientCode
		{
			get { return this._patientCode; }
			set { this._patientCode = value; }
		}

		public NuroOUT0101U02GridCommentInfo() { }

		public NuroOUT0101U02GridCommentInfo(String ser, String comment, String patientCode)
		{
			this._ser = ser;
			this._comment = comment;
			this._patientCode = patientCode;
		}

	}
}
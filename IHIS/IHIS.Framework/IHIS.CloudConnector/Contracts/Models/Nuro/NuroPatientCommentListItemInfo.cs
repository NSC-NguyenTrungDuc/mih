using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class NuroPatientCommentListItemInfo
	{
		private String _comment;
		private String _ser;
		private String _patientCode;
		private String _contKey;

		public String Comment
		{
			get { return this._comment; }
			set { this._comment = value; }
		}

		public String Ser
		{
			get { return this._ser; }
			set { this._ser = value; }
		}

		public String PatientCode
		{
			get { return this._patientCode; }
			set { this._patientCode = value; }
		}

		public String ContKey
		{
			get { return this._contKey; }
			set { this._contKey = value; }
		}

		public NuroPatientCommentListItemInfo() { }

		public NuroPatientCommentListItemInfo(String comment, String ser, String patientCode, String contKey)
		{
			this._comment = comment;
			this._ser = ser;
			this._patientCode = patientCode;
			this._contKey = contKey;
		}

	}
}


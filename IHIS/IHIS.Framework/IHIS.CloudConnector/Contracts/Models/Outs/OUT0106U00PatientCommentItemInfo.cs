using System;

namespace IHIS.CloudConnector.Contracts.Models.Outs
{
    [Serializable]
	public class OUT0106U00PatientCommentItemInfo
	{
		private String _patientInfo;
		private String _patientInfoName;
		private String _startDate;
		private String _endDate;
		private String _comments;
		private String _bunho;
		private String _contKey;
		private String _dataRowState;

		public String PatientInfo
		{
			get { return this._patientInfo; }
			set { this._patientInfo = value; }
		}

		public String PatientInfoName
		{
			get { return this._patientInfoName; }
			set { this._patientInfoName = value; }
		}

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public String EndDate
		{
			get { return this._endDate; }
			set { this._endDate = value; }
		}

		public String Comments
		{
			get { return this._comments; }
			set { this._comments = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String ContKey
		{
			get { return this._contKey; }
			set { this._contKey = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public OUT0106U00PatientCommentItemInfo() { }

		public OUT0106U00PatientCommentItemInfo(String patientInfo, String patientInfoName, String startDate, String endDate, String comments, String bunho, String contKey, String dataRowState)
		{
			this._patientInfo = patientInfo;
			this._patientInfoName = patientInfoName;
			this._startDate = startDate;
			this._endDate = endDate;
			this._comments = comments;
			this._bunho = bunho;
			this._contKey = contKey;
			this._dataRowState = dataRowState;
		}

	}
}
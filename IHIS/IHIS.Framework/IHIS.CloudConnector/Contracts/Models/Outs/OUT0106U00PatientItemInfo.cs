using System;

namespace IHIS.CloudConnector.Contracts.Models.Outs
{
    [Serializable]
	public class OUT0106U00PatientItemInfo
	{
		private String _patientInfo;
		private String _patientInfoName;
		private String _contKey;

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

		public String ContKey
		{
			get { return this._contKey; }
			set { this._contKey = value; }
		}

		public OUT0106U00PatientItemInfo() { }

		public OUT0106U00PatientItemInfo(String patientInfo, String patientInfoName, String contKey)
		{
			this._patientInfo = patientInfo;
			this._patientInfoName = patientInfoName;
			this._contKey = contKey;
		}

	}
}
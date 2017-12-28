using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01LoadMakayJungboInfo
	{
		private String _oMayakDoctor;
		private String _oMayakLicense;
		private String _oMayakAddress1;
		private String _oMayakAddress2;

		public String OMayakDoctor
		{
			get { return this._oMayakDoctor; }
			set { this._oMayakDoctor = value; }
		}

		public String OMayakLicense
		{
			get { return this._oMayakLicense; }
			set { this._oMayakLicense = value; }
		}

		public String OMayakAddress1
		{
			get { return this._oMayakAddress1; }
			set { this._oMayakAddress1 = value; }
		}

		public String OMayakAddress2
		{
			get { return this._oMayakAddress2; }
			set { this._oMayakAddress2 = value; }
		}

		public DrgsDRG5100P01LoadMakayJungboInfo() { }

		public DrgsDRG5100P01LoadMakayJungboInfo(String oMayakDoctor, String oMayakLicense, String oMayakAddress1, String oMayakAddress2)
		{
			this._oMayakDoctor = oMayakDoctor;
			this._oMayakLicense = oMayakLicense;
			this._oMayakAddress1 = oMayakAddress1;
			this._oMayakAddress2 = oMayakAddress2;
		}

	}
}
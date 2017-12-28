using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0503U01CommonDataResult : AbstractContractResult
	{
		private String _sangName;
		private String _gwaName;
		private String _doctorName;

		public String SangName
		{
			get { return this._sangName; }
			set { this._sangName = value; }
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

		public OcsaOCS0503U01CommonDataResult() { }

	}
}
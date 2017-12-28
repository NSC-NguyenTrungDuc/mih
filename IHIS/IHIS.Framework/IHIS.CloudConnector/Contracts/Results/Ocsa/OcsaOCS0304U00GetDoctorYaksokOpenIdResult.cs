using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OcsaOCS0304U00GetDoctorYaksokOpenIdResult : AbstractContractResult
	{
		private String _yaksokOpenId;

		public String YaksokOpenId
		{
			get { return this._yaksokOpenId; }
			set { this._yaksokOpenId = value; }
		}

		public OcsaOCS0304U00GetDoctorYaksokOpenIdResult() { }

	}
}
using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable ]
	public class NuroOUT0101U02GetInsuranceCode
	{
		private String _insuranceCode;

		public String InsuranceCode
		{
			get { return this._insuranceCode; }
			set { this._insuranceCode = value; }
		}

		public NuroOUT0101U02GetInsuranceCode() { }

		public NuroOUT0101U02GetInsuranceCode(String insuranceCode)
		{
			this._insuranceCode = insuranceCode;
		}

	}
}
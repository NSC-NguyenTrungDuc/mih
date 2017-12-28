using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable ]
	public class NuroOUT0101U02GetInsuranceInfo2
	{
		private String _insuranceCode;
		private String _insuranceName;

		public String InsuranceCode
		{
			get { return this._insuranceCode; }
			set { this._insuranceCode = value; }
		}

		public String InsuranceName
		{
			get { return this._insuranceName; }
			set { this._insuranceName = value; }
		}

		public NuroOUT0101U02GetInsuranceInfo2() { }

		public NuroOUT0101U02GetInsuranceInfo2(String insuranceCode, String insuranceName)
		{
			this._insuranceCode = insuranceCode;
			this._insuranceName = insuranceName;
		}

	}
}
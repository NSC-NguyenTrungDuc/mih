using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable ]
	public class NuroOUT0101U02GetInsurance2Result : AbstractContractResult
	{
		private List<NuroOUT0101U02GetInsuranceInfo2> _insuranceInfo = new List<NuroOUT0101U02GetInsuranceInfo2>();

		public List<NuroOUT0101U02GetInsuranceInfo2> InsuranceInfo
		{
			get { return this._insuranceInfo; }
			set { this._insuranceInfo = value; }
		}

		public NuroOUT0101U02GetInsurance2Result() { }

	}
}
using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable ]
	public class NuroOUT0101U02GetInsuranceResult : AbstractContractResult
	{
		private List<NuroOUT0101U02GetInsuranceCode> _insuranceCodeItem = new List<NuroOUT0101U02GetInsuranceCode>();

		public List<NuroOUT0101U02GetInsuranceCode> InsuranceCodeItem
		{
			get { return this._insuranceCodeItem; }
			set { this._insuranceCodeItem = value; }
		}

		public NuroOUT0101U02GetInsuranceResult() { }

	}
}
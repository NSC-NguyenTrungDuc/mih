using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0001U00FbxDodobuHyeunDataValidatingResult : AbstractContractResult
	{
		private List<BAS0001U00FbxDodobuHyeunDataValidatingInfo> _fbxDodobHyeunValidating = new List<BAS0001U00FbxDodobuHyeunDataValidatingInfo>();

		public List<BAS0001U00FbxDodobuHyeunDataValidatingInfo> FbxDodobHyeunValidating
		{
			get { return this._fbxDodobHyeunValidating; }
			set { this._fbxDodobHyeunValidating = value; }
		}

		public BAS0001U00FbxDodobuHyeunDataValidatingResult() { }

	}
}
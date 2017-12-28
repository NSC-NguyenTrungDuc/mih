using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
	public class BAS0001U00FbxDodobuHyeunFindClickResult : AbstractContractResult
	{
		private List<ComboListItemInfo> _fbxDodobuHyeunFindClick = new List<ComboListItemInfo>();

		public List<ComboListItemInfo> FbxDodobuHyeunFindClick
		{
			get { return this._fbxDodobuHyeunFindClick; }
			set { this._fbxDodobuHyeunFindClick = value; }
		}

		public BAS0001U00FbxDodobuHyeunFindClickResult() { }

	}
}
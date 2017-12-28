using IHIS.CloudConnector.Contracts.Models.Injs;
using IHIS.CloudConnector.Contracts.Models.System;
using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
	public class InjsINJ1001U01AllergyListResult : AbstractContractResult
	{
        private List<DataStringListItemInfo> _allergyInfo = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> AllergyInfo
        {
            get { return this._allergyInfo; }
            set { this._allergyInfo = value; }
        }
		public InjsINJ1001U01AllergyListResult() { }

	}
}
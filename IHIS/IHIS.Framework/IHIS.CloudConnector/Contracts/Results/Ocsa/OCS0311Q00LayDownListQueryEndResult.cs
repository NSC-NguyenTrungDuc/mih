using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311Q00LayDownListQueryEndResult : AbstractContractResult
    {
        private List<OCS0311Q00LayDownListQueryEndResInfo> _layDownResItem = new List<OCS0311Q00LayDownListQueryEndResInfo>();

        public List<OCS0311Q00LayDownListQueryEndResInfo> LayDownResItem
        {
            get { return this._layDownResItem; }
            set { this._layDownResItem = value; }
        }

        public OCS0311Q00LayDownListQueryEndResult() { }

    }
}
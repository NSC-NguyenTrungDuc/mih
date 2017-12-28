using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetGroupKeyResult : AbstractContractResult
    {
        private List<NuroOUT1001U01GetGroupKeyInfo> _getGroupKeyItem = new List<NuroOUT1001U01GetGroupKeyInfo>();

        public List<NuroOUT1001U01GetGroupKeyInfo> GetGroupKeyItem
        {
            get { return this._getGroupKeyItem; }
            set { this._getGroupKeyItem = value; }
        }

        public NuroOUT1001U01GetGroupKeyResult() { }

    }
}

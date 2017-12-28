using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01GetTypeResult : AbstractContractResult
    {
        private List<NuroOUT1001U01GetTypeInfo> _typeItem = new List<NuroOUT1001U01GetTypeInfo>();

        public List<NuroOUT1001U01GetTypeInfo> TypeItem
        {
            get { return this._typeItem; }
            set { this._typeItem = value; }
        }

        public NuroOUT1001U01GetTypeResult() { }

    }
}
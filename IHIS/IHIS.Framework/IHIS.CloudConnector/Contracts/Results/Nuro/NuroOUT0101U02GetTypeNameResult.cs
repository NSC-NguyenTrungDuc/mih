using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT0101U02GetTypeNameResult : AbstractContractResult
    {
        private String _typeName;

        public String TypeName
        {
            get { return this._typeName; }
            set { this._typeName = value; }
        }

        public NuroOUT0101U02GetTypeNameResult() { }

    }
}
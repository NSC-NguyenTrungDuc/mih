using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01LoadOUT0105Result : AbstractContractResult
    {
        private List<NuroOUT1001U01LoadOUT0105Info> _itemValue = new List<NuroOUT1001U01LoadOUT0105Info>();

        public List<NuroOUT1001U01LoadOUT0105Info> ItemValue
        {
            get { return this._itemValue; }
            set { this._itemValue = value; }
        }

        public NuroOUT1001U01LoadOUT0105Result() { }

    }
}

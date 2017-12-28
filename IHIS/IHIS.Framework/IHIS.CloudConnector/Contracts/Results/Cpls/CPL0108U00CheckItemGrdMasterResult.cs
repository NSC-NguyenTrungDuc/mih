using System;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0108U00CheckItemGrdMasterResult : AbstractContractResult
    {
        private String _checkItem;

        public String CheckItem
        {
            get { return this._checkItem; }
            set { this._checkItem = value; }
        }

        public CPL0108U00CheckItemGrdMasterResult() { }

    }
}
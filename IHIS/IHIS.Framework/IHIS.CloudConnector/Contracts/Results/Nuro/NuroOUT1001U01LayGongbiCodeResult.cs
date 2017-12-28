using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01LayGongbiCodeResult : AbstractContractResult
    {
        private List<NuroOUT1001U01LayGongbiCodeInfo> _layGongbiCodeItem = new List<NuroOUT1001U01LayGongbiCodeInfo>();

        public List<NuroOUT1001U01LayGongbiCodeInfo> LayGongbiCodeItem
        {
            get { return this._layGongbiCodeItem; }
            set { this._layGongbiCodeItem = value; }
        }

        public NuroOUT1001U01LayGongbiCodeResult() { }

    }
}

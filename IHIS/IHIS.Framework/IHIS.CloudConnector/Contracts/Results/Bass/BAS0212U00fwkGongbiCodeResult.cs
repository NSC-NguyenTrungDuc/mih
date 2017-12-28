using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0212U00fwkGongbiCodeResult : AbstractContractResult
    {
        private List<BAS0212U00fwkGongbiCodeInfo> _fwk = new List<BAS0212U00fwkGongbiCodeInfo>();

        public List<BAS0212U00fwkGongbiCodeInfo> Fwk
        {
            get { return this._fwk; }
            set { this._fwk = value; }
        }

        public BAS0212U00fwkGongbiCodeResult() { }

    }
}
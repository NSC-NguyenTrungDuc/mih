using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0503U00CommonResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _naewonYn = new List<DataStringListItemInfo>();
        private String _reserYn;
        private String _seq;

        public List<DataStringListItemInfo> NaewonYn
        {
            get { return this._naewonYn; }
            set { this._naewonYn = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public OCS0503U00CommonResult() { }

    }
}
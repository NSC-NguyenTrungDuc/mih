using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class IFS0003U01SaveLayoutResult : AbstractContractResult
    {
        private Boolean _result;
        private String _mapGubun;
        private String _mapGubunYmd;

        public Boolean Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public String MapGubun
        {
            get { return this._mapGubun; }
            set { this._mapGubun = value; }
        }

        public String MapGubunYmd
        {
            get { return this._mapGubunYmd; }
            set { this._mapGubunYmd = value; }
        }

        public IFS0003U01SaveLayoutResult() { }

    }
}
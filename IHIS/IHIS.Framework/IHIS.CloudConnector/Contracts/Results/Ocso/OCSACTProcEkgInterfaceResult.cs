using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCSACTProcEkgInterfaceResult : AbstractContractResult
    {
        private String _pkpfe5010;
        private String _rtnIfsCnt;
        private String _exceptionId;

        public String Pkpfe5010
        {
            get { return this._pkpfe5010; }
            set { this._pkpfe5010 = value; }
        }

        public String RtnIfsCnt
        {
            get { return this._rtnIfsCnt; }
            set { this._rtnIfsCnt = value; }
        }

        public String ExceptionId
        {
            get { return this._exceptionId; }
            set { this._exceptionId = value; }
        }

        public OCSACTProcEkgInterfaceResult() { }

    }
}
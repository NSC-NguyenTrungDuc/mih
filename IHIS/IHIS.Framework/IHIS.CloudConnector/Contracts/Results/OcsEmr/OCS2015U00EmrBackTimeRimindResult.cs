using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class OCS2015U00EmrBackTimeRimindResult : AbstractContractResult
    {
        private Boolean _isLock;
        private String _urlFile;
        private String _lastTime;

        public Boolean IsLock
        {
            get { return this._isLock; }
            set { this._isLock = value; }
        }

        public String UrlFile
        {
            get { return this._urlFile; }
            set { this._urlFile = value; }
        }

        public String LastTime
        {
            get { return this._lastTime; }
            set { this._lastTime = value; }
        }

        public OCS2015U00EmrBackTimeRimindResult() { }

    }
}
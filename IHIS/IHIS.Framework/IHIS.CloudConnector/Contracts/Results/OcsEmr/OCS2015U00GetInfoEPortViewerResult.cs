using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class OCS2015U00GetInfoEPortViewerResult : AbstractContractResult
    {
        private String _folderPath;
        private String _exePath;

        public String FolderPath
        {
            get { return this._folderPath; }
            set { this._folderPath = value; }
        }

        public String ExePath
        {
            get { return this._exePath; }
            set { this._exePath = value; }
        }

        public OCS2015U00GetInfoEPortViewerResult() { }

    }
}
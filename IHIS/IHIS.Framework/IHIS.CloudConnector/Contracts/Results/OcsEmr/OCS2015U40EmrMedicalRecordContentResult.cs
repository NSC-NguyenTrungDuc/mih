using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U40EmrMedicalRecordContentResult : AbstractContractResult
    {
        private String _content;
        private String _metadata;

        public String Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        public String Metadata
        {
            get { return this._metadata; }
            set { this._metadata = value; }
        }

        public OCS2015U40EmrMedicalRecordContentResult() { }

    }
}
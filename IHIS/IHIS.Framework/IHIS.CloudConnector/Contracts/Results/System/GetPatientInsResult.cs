using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    public class GetPatientInsResult : AbstractContractResult
    {
        private List<PrivateInsInfo> _priInfo = new List<PrivateInsInfo>();
        private List<PublicInsInfo> _pubInfo = new List<PublicInsInfo>();

        public List<PrivateInsInfo> PriInfo
        {
            get { return this._priInfo; }
            set { this._priInfo = value; }
        }

        public List<PublicInsInfo> PubInfo
        {
            get { return this._pubInfo; }
            set { this._pubInfo = value; }
        }

        public GetPatientInsResult() { }

    }
}
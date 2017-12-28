using System;
using IHIS.CloudConnector.Contracts.Models.Orca;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Orca
{
    [Serializable]
    public class ORCALibAcquisitionResult : AbstractContractResult
    {
        private List<ORCALibAcquisitionInfo> _acqItem = new List<ORCALibAcquisitionInfo>();

        public List<ORCALibAcquisitionInfo> AcqItem
        {
            get { return this._acqItem; }
            set { this._acqItem = value; }
        }

        public ORCALibAcquisitionResult() { }

    }
}
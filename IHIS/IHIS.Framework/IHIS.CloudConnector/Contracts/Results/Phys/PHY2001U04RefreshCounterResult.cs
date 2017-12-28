using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04RefreshCounterResult : AbstractContractResult
    {
        private List<PHY2001U04RefreshCounterInfo> _refCounterItem = new List<PHY2001U04RefreshCounterInfo>();

        public List<PHY2001U04RefreshCounterInfo> RefCounterItem
        {
            get { return this._refCounterItem; }
            set { this._refCounterItem = value; }
        }

        public PHY2001U04RefreshCounterResult() { }

    }
}
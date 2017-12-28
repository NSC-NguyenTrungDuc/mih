using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04CboJubsuGubunResult : AbstractContractResult
    {
        private List<PHY2001U04CboJubsuGubunInfo> _cboJubsuGubun = new List<PHY2001U04CboJubsuGubunInfo>();

        public List<PHY2001U04CboJubsuGubunInfo> CboJubsuGubun
        {
            get { return this._cboJubsuGubun; }
            set { this._cboJubsuGubun = value; }
        }

        public PHY2001U04CboJubsuGubunResult() { }

    }
}
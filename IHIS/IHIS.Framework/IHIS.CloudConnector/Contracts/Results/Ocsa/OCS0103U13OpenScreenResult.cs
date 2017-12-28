using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    public class OCS0103U13OpenScreenResult : AbstractContractResult
    {
        private OCS0103U13CboListResult _ocs0103u13CboList;
        private OCS0103U13FormLoadResult _ocs0103u13FormLoad;
        private List<OCS0103U13GrdSangyongOrderListResult> _ocs0103u14GrdSangyongOrderList = new List<OCS0103U13GrdSangyongOrderListResult>();
        private GetNextGroupSerResult _getNextGroupSer;

        public OCS0103U13CboListResult Ocs0103u13CboList
        {
            get { return this._ocs0103u13CboList; }
            set { this._ocs0103u13CboList = value; }
        }

        public OCS0103U13FormLoadResult Ocs0103u13FormLoad
        {
            get { return this._ocs0103u13FormLoad; }
            set { this._ocs0103u13FormLoad = value; }
        }

        public List<OCS0103U13GrdSangyongOrderListResult> Ocs0103u14GrdSangyongOrderList
        {
            get { return this._ocs0103u14GrdSangyongOrderList; }
            set { this._ocs0103u14GrdSangyongOrderList = value; }
        }

        public GetNextGroupSerResult GetNextGroupSer
        {
            get { return this._getNextGroupSer; }
            set { this._getNextGroupSer = value; }
        }

        public OCS0103U13OpenScreenResult() { }

    }
}
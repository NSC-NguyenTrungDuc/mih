using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    public class OCS0103U13OpenScreenArgs : IContractArgs
    {
        private OCS0103U13CboListArgs _ocs0103u13CboList;
        private OCS0103U13FormLoadArgs _ocs0103u13FormLoad;
        private List<OCS0103U13GrdSangyongOrderListArgs> _ocs0103u14GrdSangyongOrderList = new List<OCS0103U13GrdSangyongOrderListArgs>();
        private GetNextGroupSerArgs _getNextGroupSer;

        public OCS0103U13CboListArgs Ocs0103u13CboList
        {
            get { return this._ocs0103u13CboList; }
            set { this._ocs0103u13CboList = value; }
        }

        public OCS0103U13FormLoadArgs Ocs0103u13FormLoad
        {
            get { return this._ocs0103u13FormLoad; }
            set { this._ocs0103u13FormLoad = value; }
        }

        public List<OCS0103U13GrdSangyongOrderListArgs> Ocs0103u14GrdSangyongOrderList
        {
            get { return this._ocs0103u14GrdSangyongOrderList; }
            set { this._ocs0103u14GrdSangyongOrderList = value; }
        }

        public GetNextGroupSerArgs GetNextGroupSer
        {
            get { return this._getNextGroupSer; }
            set { this._getNextGroupSer = value; }
        }

        public OCS0103U13OpenScreenArgs() { }

        public OCS0103U13OpenScreenArgs(OCS0103U13CboListArgs ocs0103u13CboList, OCS0103U13FormLoadArgs ocs0103u13FormLoad, List<OCS0103U13GrdSangyongOrderListArgs> ocs0103u14GrdSangyongOrderList, GetNextGroupSerArgs getNextGroupSer)
        {
            this._ocs0103u13CboList = ocs0103u13CboList;
            this._ocs0103u13FormLoad = ocs0103u13FormLoad;
            this._ocs0103u14GrdSangyongOrderList = ocs0103u14GrdSangyongOrderList;
            this._getNextGroupSer = getNextGroupSer;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U13OpenScreenRequest();
        }
    }
}
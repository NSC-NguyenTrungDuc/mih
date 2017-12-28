using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    public class OCS0103U16ScreenOpenArgs : IContractArgs
    {
        private OCS0103U13CboListArgs _cboLstReqItem;
        private OCS0103U14FormLoadArgs _formLoadReqItem;
        private List<LoadSearchOrder2Args> _loadSearchOrder2ReqItem = new List<LoadSearchOrder2Args>();
        private OCS0103U16GrdSangyongOrderArgs _grdSangyongOrderReqItem;
        private OCS0103U16SlipCodeTreeArgs _slipCodeReqItem;
        private GetNextGroupSerArgs _nextGroupserReqItem;

        public OCS0103U13CboListArgs CboLstReqItem
        {
            get { return this._cboLstReqItem; }
            set { this._cboLstReqItem = value; }
        }

        public OCS0103U14FormLoadArgs FormLoadReqItem
        {
            get { return this._formLoadReqItem; }
            set { this._formLoadReqItem = value; }
        }

        public List<LoadSearchOrder2Args> LoadSearchOrder2ReqItem
        {
            get { return this._loadSearchOrder2ReqItem; }
            set { this._loadSearchOrder2ReqItem = value; }
        }

        public OCS0103U16GrdSangyongOrderArgs GrdSangyongOrderReqItem
        {
            get { return this._grdSangyongOrderReqItem; }
            set { this._grdSangyongOrderReqItem = value; }
        }

        public OCS0103U16SlipCodeTreeArgs SlipCodeReqItem
        {
            get { return this._slipCodeReqItem; }
            set { this._slipCodeReqItem = value; }
        }

        public GetNextGroupSerArgs NextGroupserReqItem
        {
            get { return this._nextGroupserReqItem; }
            set { this._nextGroupserReqItem = value; }
        }

        public OCS0103U16ScreenOpenArgs() { }

        public OCS0103U16ScreenOpenArgs(OCS0103U13CboListArgs cboLstReqItem, OCS0103U14FormLoadArgs formLoadReqItem, List<LoadSearchOrder2Args> loadSearchOrder2ReqItem, OCS0103U16GrdSangyongOrderArgs grdSangyongOrderReqItem, OCS0103U16SlipCodeTreeArgs slipCodeReqItem, GetNextGroupSerArgs nextGroupserReqItem)
        {
            this._cboLstReqItem = cboLstReqItem;
            this._formLoadReqItem = formLoadReqItem;
            this._loadSearchOrder2ReqItem = loadSearchOrder2ReqItem;
            this._grdSangyongOrderReqItem = grdSangyongOrderReqItem;
            this._slipCodeReqItem = slipCodeReqItem;
            this._nextGroupserReqItem = nextGroupserReqItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U16ScreenOpenRequest();
        }
    }
}
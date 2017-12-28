using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    public class OCS0103U16ScreenOpenResult : AbstractContractResult
    {
        private OCS0103U13CboListResult _cboLstResItem;
        private OCS0103U14FormLoadResult _formLoadResItem;
        private List<LoadSearchOrder2Result> _loadSearchOrder2ResItem = new List<LoadSearchOrder2Result>();
        private OCS0103U16GrdSangyongOrderResult _grdSangyongOrderResItem;
        private OCS0103U16SlipCodeTreeResult _slipCodeResItem;
        private GetNextGroupSerResult _nextGroupserResItem;

        public OCS0103U13CboListResult CboLstResItem
        {
            get { return this._cboLstResItem; }
            set { this._cboLstResItem = value; }
        }

        public OCS0103U14FormLoadResult FormLoadResItem
        {
            get { return this._formLoadResItem; }
            set { this._formLoadResItem = value; }
        }

        public List<LoadSearchOrder2Result> LoadSearchOrder2ResItem
        {
            get { return this._loadSearchOrder2ResItem; }
            set { this._loadSearchOrder2ResItem = value; }
        }

        public OCS0103U16GrdSangyongOrderResult GrdSangyongOrderResItem
        {
            get { return this._grdSangyongOrderResItem; }
            set { this._grdSangyongOrderResItem = value; }
        }

        public OCS0103U16SlipCodeTreeResult SlipCodeResItem
        {
            get { return this._slipCodeResItem; }
            set { this._slipCodeResItem = value; }
        }

        public GetNextGroupSerResult NextGroupserResItem
        {
            get { return this._nextGroupserResItem; }
            set { this._nextGroupserResItem = value; }
        }

        public OCS0103U16ScreenOpenResult() { }

    }
}
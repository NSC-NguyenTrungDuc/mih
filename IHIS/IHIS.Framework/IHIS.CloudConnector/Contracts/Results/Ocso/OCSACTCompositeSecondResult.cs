using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OCSACTCompositeSecondResult : AbstractContractResult
    {
        private OCSACTGrdJearyoResult _grdJearyoList;
        private OCSACTGrdSangByungResult _grdSangList;
        private OCSACTDefaultJearyoResult _grdDefaultList;

        public OCSACTGrdJearyoResult GrdJearyoList
        {
            get { return this._grdJearyoList; }
            set { this._grdJearyoList = value; }
        }

        public OCSACTGrdSangByungResult GrdSangList
        {
            get { return this._grdSangList; }
            set { this._grdSangList = value; }
        }

        public OCSACTDefaultJearyoResult GrdDefaultList
        {
            get { return this._grdDefaultList; }
            set { this._grdDefaultList = value; }
        }

        public OCSACTCompositeSecondResult() { }

    }
}
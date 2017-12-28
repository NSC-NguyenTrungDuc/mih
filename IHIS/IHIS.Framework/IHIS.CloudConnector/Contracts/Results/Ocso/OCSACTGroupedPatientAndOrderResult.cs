using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    public class OCSACTGroupedPatientAndOrderResult : AbstractContractResult
    {
        private List<OCSACTGrdPaListInfo> _grdPaLst = new List<OCSACTGrdPaListInfo>();
        private List<OCSACTGrdOrderInfo> _grdOrderLst = new List<OCSACTGrdOrderInfo>();
        private List<OCSACTDefaultJearyoInfo> _grdDefaultLst = new List<OCSACTDefaultJearyoInfo>();
        private List<OCSACTGrdJearyoInfo> _grdJearyoLst = new List<OCSACTGrdJearyoInfo>();
        private List<OCSACTGrdSangByungInfo> _grdSangLst = new List<OCSACTGrdSangByungInfo>();

        public List<OCSACTGrdPaListInfo> GrdPaLst
        {
            get { return this._grdPaLst; }
            set { this._grdPaLst = value; }
        }

        public List<OCSACTGrdOrderInfo> GrdOrderLst
        {
            get { return this._grdOrderLst; }
            set { this._grdOrderLst = value; }
        }

        public List<OCSACTDefaultJearyoInfo> GrdDefaultLst
        {
            get { return this._grdDefaultLst; }
            set { this._grdDefaultLst = value; }
        }

        public List<OCSACTGrdJearyoInfo> GrdJearyoLst
        {
            get { return this._grdJearyoLst; }
            set { this._grdJearyoLst = value; }
        }

        public List<OCSACTGrdSangByungInfo> GrdSangLst
        {
            get { return this._grdSangLst; }
            set { this._grdSangLst = value; }
        }

        public OCSACTGroupedPatientAndOrderResult() { }

    }
}
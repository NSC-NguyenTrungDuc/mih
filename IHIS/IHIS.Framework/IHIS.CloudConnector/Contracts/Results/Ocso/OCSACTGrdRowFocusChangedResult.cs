using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCSACTGrdRowFocusChangedResult : AbstractContractResult
    {
        private List<OCSACTGrdJearyoInfo> _jearyoItem = new List<OCSACTGrdJearyoInfo>();
        private List<OCSACTGrdSangByungInfo> _sangbyungItem = new List<OCSACTGrdSangByungInfo>();

        public List<OCSACTGrdJearyoInfo> JearyoItem
        {
            get { return this._jearyoItem; }
            set { this._jearyoItem = value; }
        }

        public List<OCSACTGrdSangByungInfo> SangbyungItem
        {
            get { return this._sangbyungItem; }
            set { this._sangbyungItem = value; }
        }

        public OCSACTGrdRowFocusChangedResult() { }

    }
}
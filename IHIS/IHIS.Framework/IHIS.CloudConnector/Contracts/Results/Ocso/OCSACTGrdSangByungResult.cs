using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCSACTGrdSangByungResult : AbstractContractResult
    {
        private List<OCSACTGrdSangByungInfo> _grdSangByungLst = new List<OCSACTGrdSangByungInfo>();

        public List<OCSACTGrdSangByungInfo> GrdSangByungLst
        {
            get { return this._grdSangByungLst; }
            set { this._grdSangByungLst = value; }
        }

        public OCSACTGrdSangByungResult() { }

    }
}
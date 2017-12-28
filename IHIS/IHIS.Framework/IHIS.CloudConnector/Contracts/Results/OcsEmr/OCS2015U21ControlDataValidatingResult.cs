using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocso;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U21ControlDataValidatingResult : AbstractContractResult
    {
        private List<OcsoOCS1003P01LayPatInfo> _layPatItem = new List<OcsoOCS1003P01LayPatInfo>();
        private Boolean _isJaewonPatient;
        private String _isAbleInsteadOrder;
        private String _notApproveOrderCnt;
        private Boolean _enablePostApprove;

        public List<OcsoOCS1003P01LayPatInfo> LayPatItem
        {
            get { return this._layPatItem; }
            set { this._layPatItem = value; }
        }

        public Boolean IsJaewonPatient
        {
            get { return this._isJaewonPatient; }
            set { this._isJaewonPatient = value; }
        }

        public String IsAbleInsteadOrder
        {
            get { return this._isAbleInsteadOrder; }
            set { this._isAbleInsteadOrder = value; }
        }

        public String NotApproveOrderCnt
        {
            get { return this._notApproveOrderCnt; }
            set { this._notApproveOrderCnt = value; }
        }

        public Boolean EnablePostApprove
        {
            get { return this._enablePostApprove; }
            set { this._enablePostApprove = value; }
        }

        public OCS2015U21ControlDataValidatingResult() { }

    }
}
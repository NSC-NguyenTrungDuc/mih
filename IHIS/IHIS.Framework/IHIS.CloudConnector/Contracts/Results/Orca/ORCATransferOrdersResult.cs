using System;
using IHIS.CloudConnector.Contracts.Models.Orca;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Orca
{
    [Serializable]
    public class ORCATransferOrdersResult : AbstractContractResult
    {
        private ORCATransferOrdersHeaderInfo _headerItem;
        private List<ORCATransferOrdersHealthInsuranceInfo> _healthInsItem = new List<ORCATransferOrdersHealthInsuranceInfo>();
        private List<ORCATransferOrdersDiseaseInfo> _diseaseItem = new List<ORCATransferOrdersDiseaseInfo>();
        private List<ORCATransferOrdersClaimExaminationFeeInfo> _claimExamItem = new List<ORCATransferOrdersClaimExaminationFeeInfo>();
        private List<ORCATransferOrdersClaimOrdersFeeInfo> _claimOrdersItem = new List<ORCATransferOrdersClaimOrdersFeeInfo>();
        private List<ORCATransferOrdersErrMsgInfo> _errMsgItem = new List<ORCATransferOrdersErrMsgInfo>();

        public ORCATransferOrdersHeaderInfo HeaderItem
        {
            get { return this._headerItem; }
            set { this._headerItem = value; }
        }

        public List<ORCATransferOrdersHealthInsuranceInfo> HealthInsItem
        {
            get { return this._healthInsItem; }
            set { this._healthInsItem = value; }
        }

        public List<ORCATransferOrdersDiseaseInfo> DiseaseItem
        {
            get { return this._diseaseItem; }
            set { this._diseaseItem = value; }
        }

        public List<ORCATransferOrdersClaimExaminationFeeInfo> ClaimExamItem
        {
            get { return this._claimExamItem; }
            set { this._claimExamItem = value; }
        }

        public List<ORCATransferOrdersClaimOrdersFeeInfo> ClaimOrdersItem
        {
            get { return this._claimOrdersItem; }
            set { this._claimOrdersItem = value; }
        }

        public List<ORCATransferOrdersErrMsgInfo> ErrMsgItem
        {
            get { return this._errMsgItem; }
            set { this._errMsgItem = value; }
        }

        public ORCATransferOrdersResult() { }

    }
}
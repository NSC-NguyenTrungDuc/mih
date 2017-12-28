using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Orca;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class NUR2016U02TranferResult : AbstractContractResult
    {
        private ORCATransferOrdersHeaderInfo _headerItem;
        private List<ORCATransferOrdersHealthInsuranceInfo> _healthInsItem = new List<ORCATransferOrdersHealthInsuranceInfo>();
        private List<ORCATransferOrdersDiseaseInfo> _diseaseItem = new List<ORCATransferOrdersDiseaseInfo>();
        private List<ORCATransferOrdersClaimExaminationFeeInfo> _claimExamItem = new List<ORCATransferOrdersClaimExaminationFeeInfo>();
        private List<ORCATransferOrdersClaimOrdersFeeInfo> _claimOrdersItem = new List<ORCATransferOrdersClaimOrdersFeeInfo>();
        private List<ORCATransferOrdersErrMsgInfo> _errMsgItem = new List<ORCATransferOrdersErrMsgInfo>();
        private List<NUR2016U02TranferInfo> _listinfoItem = new List<NUR2016U02TranferInfo>();

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

        public List<NUR2016U02TranferInfo> ListinfoItem
        {
            get { return this._listinfoItem; }
            set { this._listinfoItem = value; }
        }

        public NUR2016U02TranferResult() { }

    }
}
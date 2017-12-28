using System;
using IHIS.CloudConnector.Contracts.Models.Orca;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Orca
{
    [Serializable]
    public class ORCALibGetClaimInfoResult : AbstractContractResult
    {
        private List<ORCALibGetDocInfo> _docItem = new List<ORCALibGetDocInfo>();
        private List<ORCALibGetClaimPatientInfo> _patientItem = new List<ORCALibGetClaimPatientInfo>();
        private List<ORCALibAcquisitionInfo> _acquisItem = new List<ORCALibAcquisitionInfo>();
        private List<ORCALibGetClaimInsuredInfo> _insuranceItem = new List<ORCALibGetClaimInsuredInfo>();
        private List<ORCALibGetClaimOrderInfo> _claimOrderItem = new List<ORCALibGetClaimOrderInfo>();
        private List<ORCALibGetClaimDiagnosisInfo> _diagnosisItem = new List<ORCALibGetClaimDiagnosisInfo>();

        public List<ORCALibGetDocInfo> DocItem
        {
            get { return this._docItem; }
            set { this._docItem = value; }
        }

        public List<ORCALibGetClaimPatientInfo> PatientItem
        {
            get { return this._patientItem; }
            set { this._patientItem = value; }
        }

        public List<ORCALibAcquisitionInfo> AcquisItem
        {
            get { return this._acquisItem; }
            set { this._acquisItem = value; }
        }

        public List<ORCALibGetClaimInsuredInfo> InsuranceItem
        {
            get { return this._insuranceItem; }
            set { this._insuranceItem = value; }
        }

        public List<ORCALibGetClaimOrderInfo> ClaimOrderItem
        {
            get { return this._claimOrderItem; }
            set { this._claimOrderItem = value; }
        }

        public List<ORCALibGetClaimDiagnosisInfo> DiagnosisItem
        {
            get { return this._diagnosisItem; }
            set { this._diagnosisItem = value; }
        }

        public ORCALibGetClaimInfoResult() { }

    }
}
using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class OCS2015U00GetDataPrintEmrMedicalResult : AbstractContractResult
    {
        private String _insuranceClassification;
        private String _emrNo;
        private String _hospitalName;
        private String _hospitalAddress;
        private String _hospitalTel;
        private String _hospitalFax;
        private String _hospitalLogo;
        private String _hospitalWebsite;
        private List<OCS2015U00GetDataDoctorInfo> _doctorInfo = new List<OCS2015U00GetDataDoctorInfo>();
        private List<OCS2015U00GetDataDosageInfo> _dosageInfo = new List<OCS2015U00GetDataDosageInfo>();
        private List<OCS2015U00GetDataInsPersonInfo> _insPersionInfoFirst = new List<OCS2015U00GetDataInsPersonInfo>();
        private List<OCS2015U00GetDataInsPersonInfo> _insPersionInfoSecond = new List<OCS2015U00GetDataInsPersonInfo>();
        private List<OCS2015U00GetDataInsProviderInfo> _insProviderInfo = new List<OCS2015U00GetDataInsProviderInfo>();
        private List<OCS2015U00GetOrderReportInfo> _orderReportInfo = new List<OCS2015U00GetOrderReportInfo>();

        public String InsuranceClassification
        {
            get { return this._insuranceClassification; }
            set { this._insuranceClassification = value; }
        }

        public String EmrNo
        {
            get { return this._emrNo; }
            set { this._emrNo = value; }
        }

        public String HospitalName
        {
            get { return this._hospitalName; }
            set { this._hospitalName = value; }
        }

        public String HospitalAddress
        {
            get { return this._hospitalAddress; }
            set { this._hospitalAddress = value; }
        }

        public String HospitalTel
        {
            get { return this._hospitalTel; }
            set { this._hospitalTel = value; }
        }

        public String HospitalFax
        {
            get { return this._hospitalFax; }
            set { this._hospitalFax = value; }
        }

        public String HospitalLogo
        {
            get { return this._hospitalLogo; }
            set { this._hospitalLogo = value; }
        }

        public String HospitalWebsite
        {
            get { return this._hospitalWebsite; }
            set { this._hospitalWebsite = value; }
        }

        public List<OCS2015U00GetDataDoctorInfo> DoctorInfo
        {
            get { return this._doctorInfo; }
            set { this._doctorInfo = value; }
        }

        public List<OCS2015U00GetDataDosageInfo> DosageInfo
        {
            get { return this._dosageInfo; }
            set { this._dosageInfo = value; }
        }

        public List<OCS2015U00GetDataInsPersonInfo> InsPersionInfoFirst
        {
            get { return this._insPersionInfoFirst; }
            set { this._insPersionInfoFirst = value; }
        }

        public List<OCS2015U00GetDataInsPersonInfo> InsPersionInfoSecond
        {
            get { return this._insPersionInfoSecond; }
            set { this._insPersionInfoSecond = value; }
        }

        public List<OCS2015U00GetDataInsProviderInfo> InsProviderInfo
        {
            get { return this._insProviderInfo; }
            set { this._insProviderInfo = value; }
        }

        public List<OCS2015U00GetOrderReportInfo> OrderReportInfo
        {
            get { return this._orderReportInfo; }
            set { this._orderReportInfo = value; }
        }

        public OCS2015U00GetDataPrintEmrMedicalResult() { }

    }
}
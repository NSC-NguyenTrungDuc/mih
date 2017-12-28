using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class ORDERTRANSAPITransferOrdersResult : AbstractContractResult
    {
        private ORDERTRANSAPIMsgInfo _msgItem;
        private List<ORDERTRANSAPIHangmogInfo> _hangmogErrItem = new List<ORDERTRANSAPIHangmogInfo>();
        private List<MedicalInformation> _medicalInfoItem = new List<MedicalInformation>();
        private String _deptCode;
        private String _physicianCode;
        private String _doctorFee;
        private String _insuranceCombinationNumber;

        public ORDERTRANSAPIMsgInfo MsgItem
        {
            get { return this._msgItem; }
            set { this._msgItem = value; }
        }

        public List<ORDERTRANSAPIHangmogInfo> HangmogErrItem
        {
            get { return this._hangmogErrItem; }
            set { this._hangmogErrItem = value; }
        }

        public List<MedicalInformation> MedicalInfoItem
        {
            get { return this._medicalInfoItem; }
            set { this._medicalInfoItem = value; }
        }

        public String DeptCode
        {
            get { return this._deptCode; }
            set { this._deptCode = value; }
        }

        public String PhysicianCode
        {
            get { return this._physicianCode; }
            set { this._physicianCode = value; }
        }

        public String DoctorFee
        {
            get { return this._doctorFee; }
            set { this._doctorFee = value; }
        }

        public String InsuranceCombinationNumber
        {
            get { return this._insuranceCombinationNumber; }
            set { this._insuranceCombinationNumber = value; }
        }

        public ORDERTRANSAPITransferOrdersResult() { }

    }
}
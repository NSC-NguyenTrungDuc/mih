using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class NUR2001U04CheckExistMedicalRecordResult : AbstractContractResult
    {
        private List<NUR2001U04CheckExistMedicalRecordInfo> _medicalRecordInfo = new List<NUR2001U04CheckExistMedicalRecordInfo>();

        public List<NUR2001U04CheckExistMedicalRecordInfo> MedicalRecordInfo
        {
            get { return this._medicalRecordInfo; }
            set { this._medicalRecordInfo = value; }
        }

        public NUR2001U04CheckExistMedicalRecordResult() { }

    }
}
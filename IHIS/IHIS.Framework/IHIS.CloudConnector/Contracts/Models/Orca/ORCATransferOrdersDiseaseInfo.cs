using System;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    [Serializable]
    public class ORCATransferOrdersDiseaseInfo
    {
        private String _diagnosisCode;
        private String _diagnosisSystem;
        private String _diagnosisStartDate;
        private String _diagnosisEndDate;
        private String _mmlTableId;
        private String _diagnosisCategory;
        private String _jusangYn;

        public String DiagnosisCode
        {
            get { return this._diagnosisCode; }
            set { this._diagnosisCode = value; }
        }

        public String DiagnosisSystem
        {
            get { return this._diagnosisSystem; }
            set { this._diagnosisSystem = value; }
        }

        public String DiagnosisStartDate
        {
            get { return this._diagnosisStartDate; }
            set { this._diagnosisStartDate = value; }
        }

        public String DiagnosisEndDate
        {
            get { return this._diagnosisEndDate; }
            set { this._diagnosisEndDate = value; }
        }

        public String MmlTableId
        {
            get { return this._mmlTableId; }
            set { this._mmlTableId = value; }
        }

        public String DiagnosisCategory
        {
            get { return this._diagnosisCategory; }
            set { this._diagnosisCategory = value; }
        }

        public String JusangYn
        {
            get { return this._jusangYn; }
            set { this._jusangYn = value; }
        }

        public ORCATransferOrdersDiseaseInfo() { }

        public ORCATransferOrdersDiseaseInfo(String diagnosisCode, String diagnosisSystem, String diagnosisStartDate, String diagnosisEndDate, String mmlTableId, String diagnosisCategory, String jusangYn)
        {
            this._diagnosisCode = diagnosisCode;
            this._diagnosisSystem = diagnosisSystem;
            this._diagnosisStartDate = diagnosisStartDate;
            this._diagnosisEndDate = diagnosisEndDate;
            this._mmlTableId = mmlTableId;
            this._diagnosisCategory = diagnosisCategory;
            this._jusangYn = jusangYn;
        }

    }
}
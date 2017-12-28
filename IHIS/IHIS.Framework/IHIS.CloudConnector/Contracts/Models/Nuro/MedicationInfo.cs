using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class MedicationInfo
    {
        private String _medicationCode;
        private String _medicationName;
        private String _medicationNumber;
        private String _medicationGenericFlg;

        public String MedicationCode
        {
            get { return this._medicationCode; }
            set { this._medicationCode = value; }
        }

        public String MedicationName
        {
            get { return this._medicationName; }
            set { this._medicationName = value; }
        }

        public String MedicationNumber
        {
            get { return this._medicationNumber; }
            set { this._medicationNumber = value; }
        }

        public String MedicationGenericFlg
        {
            get { return this._medicationGenericFlg; }
            set { this._medicationGenericFlg = value; }
        }

        public MedicationInfo() { }

        public MedicationInfo(String medicationCode, String medicationName, String medicationNumber, String medicationGenericFlg)
        {
            this._medicationCode = medicationCode;
            this._medicationName = medicationName;
            this._medicationNumber = medicationNumber;
            this._medicationGenericFlg = medicationGenericFlg;
        }

    }
}
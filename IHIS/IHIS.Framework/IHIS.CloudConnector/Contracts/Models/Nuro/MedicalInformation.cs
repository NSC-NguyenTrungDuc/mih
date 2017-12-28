using System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class MedicalInformation
    {
        private String _medicalClass;
        private String _medicalClassName;
        private String _medicalClassNumber;
        private List<MedicationInfo> _medicationInfo = new List<MedicationInfo>();

        public String MedicalClass
        {
            get { return this._medicalClass; }
            set { this._medicalClass = value; }
        }

        public String MedicalClassName
        {
            get { return this._medicalClassName; }
            set { this._medicalClassName = value; }
        }

        public String MedicalClassNumber
        {
            get { return this._medicalClassNumber; }
            set { this._medicalClassNumber = value; }
        }

        public List<MedicationInfo> MedicationInfo
        {
            get { return this._medicationInfo; }
            set { this._medicationInfo = value; }
        }

        public MedicalInformation() { }

        public MedicalInformation(String medicalClass, String medicalClassName, String medicalClassNumber, List<MedicationInfo> medicationInfo)
        {
            this._medicalClass = medicalClass;
            this._medicalClassName = medicalClassName;
            this._medicalClassNumber = medicalClassNumber;
            this._medicationInfo = medicationInfo;
        }

    }
}
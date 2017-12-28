namespace IHIS.OCSO
{
    using System.Collections.Generic;

    using IHIS.CloudConnector.Contracts.Models.System;
    using IHIS.Framework;
    using IHIS.CloudConnector.Contracts.Models.Ocso;

    public class PatientData : PatientInfo
    {
        private List<string> diseases;

        private string patientCode;

        private OCS4001U00HospitalInfo hospital;

        private string doctorId;
        private string doctorName;
        private string printDate;

        public PatientData(XPatientBox patientBox, List<string> diseases, OCS4001U00HospitalInfo hospital, string doctorId, string doctorName, string printDate)
        {
            this.diseases = diseases;
            this.hospital = hospital;
            this.doctorId = doctorId;
            this.doctorName = doctorName;
            this.Address1 = patientBox.Address1;
            this.Address2 = patientBox.Address2;
            this.Birth = patientBox.Birth;
            this.Email = patientBox.Email;
            this.MonthAge = patientBox.MonthAge.ToString();
            this.PatientName1 = patientBox.SuName;
            this.PatientName2 = patientBox.SuName2;
            this.Sex = patientBox.Sex;
            this.Tel = patientBox.Tel;
            this.TelHp = patientBox.TelHP;
            this.YearAge = patientBox.YearAge.ToString();
            this.ZipCode1 = patientBox.Zip1;
            this.ZipCode2 = patientBox.Zip2;
            this.PatientCode = patientBox.BunHo;
            this.PrintDate = printDate;
        }

        public List<string> Diseases
        {
            get
            {
                return diseases;
            }
            set
            {
                diseases = value;
            }
        }

        public string PatientCode
        {
            get
            {
                return patientCode;
            }
            set
            {
                patientCode = value;
            }
        }

        public OCS4001U00HospitalInfo Hospital
        {
            get { return hospital; }
            set { hospital = value; }
        }

        public string DoctorId
        {
            get
            {
                return doctorId;
            }
            set
            {
                doctorId = value;
            }
        }

        public string DoctorName
        {
            get
            {
                return doctorName;
            }
            set
            {
                doctorName = value;
            }
        }

        public string PrintDate
        {
            get
            {
                return printDate;
            }
            set
            {
                printDate = value;
            }
        }
    }
}
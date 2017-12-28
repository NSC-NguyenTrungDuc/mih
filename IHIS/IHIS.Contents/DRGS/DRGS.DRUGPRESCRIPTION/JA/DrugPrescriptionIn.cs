using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.DRGS
{
    public class DrugPrescriptionIn : DrugPrescriptionBase
    {
        private string _pageNumber = "";
        private string _pageTotal = "";
        private string _gwaName = "";
        private string _patientCode = "";
        private string _gubunName = "";
        private string _drugBunho = "";
        private string _doctorCode = "";
        private string _sunwonGubunOval = "";
        private string _examinationDate = "";
        private string _gigamDate = "";
        private string _cautionName = "";
        private string _mayakDoctor = "";
        private string _mayakAddress1 = "";
        private string _mayakAddress2 = "";

        public string PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        public string PageTotal
        {
            get { return _pageTotal; }
            set { _pageTotal = value; }
        }

        public string GwaName
        {
            get { return _gwaName; }
            set { _gwaName = value; }
        }

        public string PatientCode
        {
            get { return _patientCode; }
            set { _patientCode = value; }
        }

        public string GubunName
        {
            get { return _gubunName; }
            set { _gubunName = value; }
        }

        public string DrugBunho
        {
            get { return _drugBunho; }
            set { _drugBunho = value; }
        }

        public string DoctorCode
        {
            get { return _doctorCode; }
            set { _doctorCode = value; }
        }

        public string SunwonGubunOval
        {
            get { return _sunwonGubunOval; }
            set { _sunwonGubunOval = value; }
        }

        public string ExaminationDate
        {
            get { return _examinationDate; }
            set { _examinationDate = value; }
        }

        public string GigamDate
        {
            get { return _gigamDate; }
            set { _gigamDate = value; }
        }

        public string CautionName
        {
            get { return _cautionName; }
            set { _cautionName = value; }
        }

        public string MayakDoctor
        {
            get { return _mayakDoctor; }
            set { _mayakDoctor = value; }
        }

        public string MayakAddress1
        {
            get { return _mayakAddress1; }
            set { _mayakAddress1 = value; }
        }

        public string MayakAddress2
        {
            get { return _mayakAddress2; }
            set { _mayakAddress2 = value; }
        }

        public DrugPrescriptionIn()
        {

        }
    }
}

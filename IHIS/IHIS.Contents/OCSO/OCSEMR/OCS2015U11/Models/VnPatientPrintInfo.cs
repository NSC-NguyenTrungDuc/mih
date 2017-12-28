using System;

namespace EmrDocker.Models
{
    public class VnPatientPrintInfo
    {
        private String _patientCode;
        private String _patientName;
        private String _patientDob;
        private String _patientSex;
        private String _patientAddress;
        private String _patientPhone;
        private String _receiptDate;
        private String _patientAge;

        public string PatientCode
        {
            get { return _patientCode; }
            set { _patientCode = value; }
        }

        public string PatientName
        {
            get { return _patientName; }
            set { _patientName = value; }
        }

        public string PatientDob
        {
            get { return _patientDob; }
            set { _patientDob = value; }
        }

        public string PatientSex
        {
            get { return _patientSex; }
            set { _patientSex = value; }
        }

        public string PatientAddress
        {
            get { return _patientAddress; }
            set { _patientAddress = value; }
        }

        public string PatientPhone
        {
            get { return _patientPhone; }
            set { _patientPhone = value; }
        }

        public string ReceiptDate
        {
            get { return _receiptDate; }
            set { _receiptDate = value; }
        }

        public string PatientAge
        {
            get { return _patientAge; }
            set { _patientAge = value; }
        }

        public VnPatientPrintInfo()
        {
        }

        public VnPatientPrintInfo(string patientCode, string patientName, string patientDob, string patientSex, string patientAddress, string patientPhone, string receiptDate, string patientAge)
        {
            _patientCode = patientCode;
            _patientName = patientName;
            _patientDob = patientDob;
            _patientSex = patientSex;
            _patientAddress = patientAddress;
            _patientPhone = patientPhone;
            _receiptDate = receiptDate;
            _patientAge = patientAge;
        }
    }
}
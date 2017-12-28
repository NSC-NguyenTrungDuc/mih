using System;
using System.Collections.Generic;

namespace EmrDocker.Models
{
    public class VnEmrPrintPageInfo
    {
        private String _pkOut;
        private String _templateId;
        private String _currentDate;
        private String _currentMonth;
        private String _currentYear;
        private String _doctorName;
        private bool _isPatientInfo;
        private bool _isOrderInfo;
        private bool _isDiseasePrinting;
        private VnHospPrintInfo _hospPrintInfo;
        private VnPatientPrintInfo _patientPrintInfo;
        private List<VnImagePrintInfo> _imagePrintInfos;
        private List<VnTagPrintInfo> _tagPrintInfos;
        private List<VnDrugPrintInfo> _drugPrintInfos;
        private List<VnDiseasePrintInfo> _diseasePrintInfos;

        public string PkOut
        {
            get { return _pkOut; }
            set { _pkOut = value; }
        }

        public string TemplateId
        {
            get { return _templateId; }
            set { _templateId = value; }
        }
        public string CurrentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; }
        }

        public string CurrentMonth
        {
            get { return _currentMonth; }
            set { _currentMonth = value; }
        }

        public string CurrentYear
        {
            get { return _currentYear; }
            set { _currentYear = value; }
        }

        public string DoctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; }
        }

        public bool IsPatientInfo
        {
            get { return _isPatientInfo; }
            set { _isPatientInfo = value; }
        }

        public bool IsOrderInfo
        {
            get { return _isOrderInfo; }
            set { _isOrderInfo = value; }
        }

        public bool IsDiseasePrinting
        {
            get { return _isDiseasePrinting; }
            set { _isDiseasePrinting = value; }
        }

        public VnHospPrintInfo HospPrintInfo
        {
            get { return _hospPrintInfo; }
            set { _hospPrintInfo = value; }
        }

        public VnPatientPrintInfo PatientPrintInfo
        {
            get { return _patientPrintInfo; }
            set { _patientPrintInfo = value; }
        }

        public List<VnImagePrintInfo> ImagePrintInfos
        {
            get { return _imagePrintInfos; }
            set { _imagePrintInfos = value; }
        }

        public List<VnTagPrintInfo> TagPrintInfos
        {
            get { return _tagPrintInfos; }
            set { _tagPrintInfos = value; }
        }

        public List<VnDrugPrintInfo> DrugPrintInfos
        {
            get { return _drugPrintInfos; }
            set { _drugPrintInfos = value; }
        }

        public List<VnDiseasePrintInfo> DiseasePrintInfos
        {
            get { return _diseasePrintInfos; }
            set { _diseasePrintInfos = value; }
        }

        public VnEmrPrintPageInfo()
        {
        }

        public VnEmrPrintPageInfo(string pkOut, string templateId, string currentDate, string currentMonth, string currentYear, string doctorName, bool isPatientInfo, bool isOrderInfo, bool isDiseasePrinting, VnHospPrintInfo hospPrintInfo, VnPatientPrintInfo patientPrintInfo, List<VnImagePrintInfo> imagePrintInfos, List<VnTagPrintInfo> tagPrintInfos, List<VnDrugPrintInfo> drugPrintInfos, List<VnDiseasePrintInfo> diseasePrintInfos)
        {
            _pkOut = pkOut;
            _templateId = templateId;
            _currentDate = currentDate;
            _currentMonth = currentMonth;
            _currentYear = currentYear;
            _doctorName = doctorName;
            _isPatientInfo = isPatientInfo;
            _isOrderInfo = isOrderInfo;
            _isDiseasePrinting = isDiseasePrinting;
            _hospPrintInfo = hospPrintInfo;
            _patientPrintInfo = patientPrintInfo;
            _imagePrintInfos = imagePrintInfos;
            _tagPrintInfos = tagPrintInfos;
            _drugPrintInfos = drugPrintInfos;
            _diseasePrintInfos = diseasePrintInfos;
        }
    }
}
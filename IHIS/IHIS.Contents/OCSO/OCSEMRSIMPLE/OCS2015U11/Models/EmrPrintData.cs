using System;
using System.Collections.Generic;
using DevExpress.XtraRichEdit.Utils;

namespace EmrDocker.Models
{
    public class EmrPrintData
    {
        //Get data from cache
        private String _patientCode;
        private String _nameKanji;
        private String _gender;
        private String _birthday;
        private String _age;
        private String _insuranceClassification;
        private String _patientTel;
        private String _firstExaminationDate;
        private String _lastExaminationDate;
        private String _pageNumber;
        private String _department;
        private String _doctorNameUserName;
        private String _diseaseFromMml;
        private String _patientAddress;
        private String _examinationDate;
        private String _tagCode;
        private String _tagName;
        private String _tagContent;
        private String _orderClassification;
        private String _doctorNameFromMml;
        private String _orderName;
        private String _orderContent;
        private String _dosage;
        private String _hospitalName;
        private String _hospitalAddress;
        private String _hospitalTel;
        private String _insPersonNo;
        private String _recipientNo;        
        private String _insPersonNo2;
        private String _recipientNo2;
        private String _insProviderNo;
        private String _insCode;
        private String _number;
        private String _expireDate;
        private String _insInstitutionalName;
        private String _effectiveDate;
        private String _startDate;
        private String _endDate;
        private String _reason;
        private String _nameKana;
        private String _disease;
        private String _doctorNameDataBase;
        private String _insName;
        private bool _isPatientInfo;
        private bool _isOrderInfo;
        private bool _isDiseasePrinting;
        private List<EmrPrintInfo> _emrPrintInfos;
        private List<DiseasePrintInfo> _diseasePrintInfos;

        public char[] InsPersonNoChracters
        {
            get
            {
                if(_insPersonNo == null) return new char[] {};
                return _insPersonNo.Trim().ToCharArray(); //.Split("".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
        }


        public char[] RecipientNoChracters
        {
            get
            {
                if (_recipientNo == null) return new char[] { };
                return _recipientNo.Trim().ToCharArray(); //Split("".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public char[] InsPersonNoChracters2
        {
            get
            {
                if (_insPersonNo2 == null) return new char[] { };
                return _insPersonNo2.Trim().ToCharArray(); //.Split("".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
        }


        public char[] RecipientNoChracters2
        {
            get
            {
                if (_recipientNo2 == null) return new char[] { };
                return _recipientNo2.Trim().ToCharArray(); //Split("".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public char[] InsProviderNoChracters
        {
            get
            {
                if (_insProviderNo == null) return new char[] { };
                return _insProviderNo.Trim().ToCharArray();//.Split("".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
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

        public string PatientCode
        {
            get { return _patientCode; }
            set { _patientCode = value; }
        }

        public string NameKanji
        {
            get { return _nameKanji; }
            set { _nameKanji = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string InsuranceClassification
        {
            get { return _insuranceClassification; }
            set { _insuranceClassification = value; }
        }

        public string PatientTel
        {
            get { return _patientTel; }
            set { _patientTel = value; }
        }

        public string FirstExaminationDate
        {
            get { return _firstExaminationDate; }
            set { _firstExaminationDate = value; }
        }

        public string LastExaminationDate
        {
            get { return _lastExaminationDate; }
            set { _lastExaminationDate = value; }
        }

        public string PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public string DoctorNameUserName
        {
            get { return _doctorNameUserName; }
            set { _doctorNameUserName = value; }
        }

        public string DiseaseFromMml
        {
            get { return _diseaseFromMml; }
            set { _diseaseFromMml = value; }
        }

        public string PatientAddress
        {
            get { return _patientAddress; }
            set { _patientAddress = value; }
        }

        public string ExaminationDate
        {
            get { return _examinationDate; }
            set { _examinationDate = value; }
        }

        public string TagCode
        {
            get { return _tagCode; }
            set { _tagCode = value; }
        }

        public string TagName
        {
            get { return _tagName; }
            set { _tagName = value; }
        }

        public string TagContent
        {
            get { return _tagContent; }
            set { _tagContent = value; }
        }

        public string OrderClassification
        {
            get { return _orderClassification; }
            set { _orderClassification = value; }
        }

        public string DoctorNameFromMml
        {
            get { return _doctorNameFromMml; }
            set { _doctorNameFromMml = value; }
        }

        public string OrderName
        {
            get { return _orderName; }
            set { _orderName = value; }
        }

        public string OrderContent
        {
            get { return _orderContent; }
            set { _orderContent = value; }
        }

        public string Dosage
        {
            get { return _dosage; }
            set { _dosage = value; }
        }

        public string HospitalName
        {
            get { return _hospitalName; }
            set { _hospitalName = value; }
        }

        public string HospitalAddress
        {
            get { return _hospitalAddress; }
            set { _hospitalAddress = value; }
        }

        public string HospitalTel
        {
            get { return _hospitalTel; }
            set { _hospitalTel = value; }
        }

        public string InsPersonNo
        {
            get { return _insPersonNo; }
            set { _insPersonNo = value; }
        }

        public string RecipientNo
        {
            get { return _recipientNo; }
            set { _recipientNo = value; }
        }

        public string InsPersonNo2
        {
            get { return _insPersonNo2; }
            set { _insPersonNo2 = value; }
        }

        public string RecipientNo2
        {
            get { return _recipientNo2; }
            set { _recipientNo2 = value; }
        }

        public string InsProviderNo
        {
            get { return _insProviderNo; }
            set { _insProviderNo = value; }
        }

        public string InsCode
        {
            get { return _insCode; }
            set { _insCode = value; }
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string ExpireDate
        {
            get { return _expireDate; }
            set { _expireDate = value; }
        }

        public string InsInstitutionalName
        {
            get { return _insInstitutionalName; }
            set { _insInstitutionalName = value; }
        }

        public string EffectiveDate
        {
            get { return _effectiveDate; }
            set { _effectiveDate = value; }
        }

        public string StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public string EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        public string NameKana
        {
            get { return _nameKana; }
            set { _nameKana = value; }
        }

        public string Disease
        {
            get { return _disease; }
            set { _disease = value; }
        }

        public string DoctorNameDataBase
        {
            get { return _doctorNameDataBase; }
            set { _doctorNameDataBase = value; }
        }

        public string InsName
        {
            get { return _insName; }
            set { _insName = value; }
        }

        public List<EmrPrintInfo> EmrPrintInfos
        {
            get { return _emrPrintInfos; }
            set { _emrPrintInfos = value; }
        }

        public List<DiseasePrintInfo> DiseasePrintInfos
        {
            get { return _diseasePrintInfos; }
            set { _diseasePrintInfos = value; }
        }

        public EmrPrintData()
        {
        }

        public EmrPrintData(string patientCode, string nameKanji, string gender, string birthday, string age, string insuranceClassification, string patientTel, string firstExaminationDate, string lastExaminationDate, string pageNumber, string department, string doctorNameUserName, string diseaseFromMml, string patientAddress, string examinationDate, string tagCode, string tagName, string tagContent, string orderClassification, string doctorNameFromMml, string orderName, string orderContent, string dosage, string hospitalName, string hospitalAddress, string hospitalTel, string insPersonNo, string recipientNo, string insPersonNo2, string recipientNo2, string insProviderNo, string insCode, string number, string expireDate, string insInstitutionalName, string effectiveDate, string startDate, string endDate, string reason, string nameKana, string disease, string doctorNameDataBase, string insName, bool isPatientInfo, bool isOrderInfo, bool isDiseasePrinting, List<EmrPrintInfo> emrPrintInfos, List<DiseasePrintInfo> diseasePrintInfos)
        {
            _patientCode = patientCode;
            _nameKanji = nameKanji;
            _gender = gender;
            _birthday = birthday;
            _age = age;
            _insuranceClassification = insuranceClassification;
            _patientTel = patientTel;
            _firstExaminationDate = firstExaminationDate;
            _lastExaminationDate = lastExaminationDate;
            _pageNumber = pageNumber;
            _department = department;
            _doctorNameUserName = doctorNameUserName;
            _diseaseFromMml = diseaseFromMml;
            _patientAddress = patientAddress;
            _examinationDate = examinationDate;
            _tagCode = tagCode;
            _tagName = tagName;
            _tagContent = tagContent;
            _orderClassification = orderClassification;
            _doctorNameFromMml = doctorNameFromMml;
            _orderName = orderName;
            _orderContent = orderContent;
            _dosage = dosage;
            _hospitalName = hospitalName;
            _hospitalAddress = hospitalAddress;
            _hospitalTel = hospitalTel;
            _insPersonNo = insPersonNo;
            _recipientNo = recipientNo;
            _insPersonNo2 = insPersonNo2;
            _recipientNo2 = recipientNo2;
            _insProviderNo = insProviderNo;
            _insCode = insCode;
            _number = number;
            _expireDate = expireDate;
            _insInstitutionalName = insInstitutionalName;
            _effectiveDate = effectiveDate;
            _startDate = startDate;
            _endDate = endDate;
            _reason = reason;
            _nameKana = nameKana;
            _disease = disease;
            _doctorNameDataBase = doctorNameDataBase;
            _insName = insName;
            _isPatientInfo = isPatientInfo;
            _isOrderInfo = isOrderInfo;
            _isDiseasePrinting = isDiseasePrinting;
            _emrPrintInfos = emrPrintInfos;
            _diseasePrintInfos = diseasePrintInfos;
        }
    }
}
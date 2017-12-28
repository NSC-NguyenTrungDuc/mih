using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.DRGS
{
    /// <summary>
    /// Drug prescription of VI hospitals. 
    /// To implement https://sofiamedix.atlassian.net/browse/MED-14480
    /// </summary>
    public class DrugPrescriptionVi
    {
        private string _hospName = "";
        private string _prescriptionNo = "";
        private string _patientName = "";
        private string _patientAddress = "";
        private string _mainDisease = "";
        private string _extraDisease = "";
        private string _birthYear = "";
        private string _gender = "";
        private string _johap = "";
        private List<DrugPrescriptionViDetail> _presDetail;
        private string _currentDate = "";
        private string _currentMonth = "";
        private string _currentYear = "";
        private string _doctorName = "";

        public string HospName
        {
            get { return _hospName; }
            set { _hospName = value; }
        }

        public string PrescriptionNo
        {
            get { return _prescriptionNo; }
            set { _prescriptionNo = value; }
        }

        public string PatientName
        {
            get { return _patientName; }
            set { _patientName = value; }
        }

        public string PatientAddress
        {
            get { return _patientAddress; }
            set { _patientAddress = value; }
        }

        public string MainDisease
        {
            get { return _mainDisease; }
            set { _mainDisease = value; }
        }

        public string ExtraDiseas
        {
            get { return _extraDisease; }
            set { _extraDisease = value; }
        }

        public string BirthYear
        {
            get { return _birthYear; }
            set { _birthYear = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string Johap
        {
            get { return _johap; }
            set { _johap = value; }
        }

        public List<DrugPrescriptionViDetail> PresDetail
        {
            get { return _presDetail; }
            set { _presDetail = value; }
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

        public DrugPrescriptionVi()
        {
        }

        public DrugPrescriptionVi(string hospName,
                                  string prescriptionNo,
                                  string patientName,
                                  string patientAddress,
                                  string mainDisease,
                                  string extraDisease,
                                  string birthYear,
                                  string gender,
                                  string johap,
                                  List<DrugPrescriptionViDetail> presDetail,
                                  string currentDate,
                                  string currentMonth,
                                  string currentYear,
                                  string doctorName)
        {
            this._hospName = hospName;
            this._prescriptionNo = prescriptionNo;
            this._patientName = patientName;
            this._patientAddress = patientAddress;
            this._mainDisease = mainDisease;
            this._extraDisease = extraDisease;
            this._birthYear = birthYear;
            this._gender = gender;
            this._johap = johap;
            this._presDetail = presDetail;
            this._currentDate = currentDate;
            this._currentMonth = CurrentMonth;
            this._currentYear = currentYear;
            this._doctorName = doctorName;            
        }
    }   

    public class DrugPrescriptionViDetail
    {
        private string _drugNo = "";
        private string _jaeryoName = "";
        private string _orderDanui = "";
        private string _quantity = "";
        private string _bogyongName = "";

        public string DrugNo
        {
            get { return _drugNo; }
            set { _drugNo = value; }
        }

        public string JaeryoName
        {
            get { return _jaeryoName; }
            set { _jaeryoName = value; }
        }

        public string OrderDanui
        {
            get { return _orderDanui; }
            set { _orderDanui = value; }
        }

        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string BogyongName
        {
            get { return _bogyongName; }
            set { _bogyongName = value; }
        }

        public DrugPrescriptionViDetail()
        { }

        public DrugPrescriptionViDetail(string drugNo, string jaeryoName, string orderDanui, string quantity, string bogyongName)
        {
            this._drugNo = drugNo;
            this._jaeryoName = jaeryoName;
            this._orderDanui = orderDanui;
            this._quantity = quantity;
            this._bogyongName = bogyongName;
        }
    }
}

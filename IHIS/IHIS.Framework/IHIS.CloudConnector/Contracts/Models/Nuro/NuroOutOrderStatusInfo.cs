using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroOutOrderStatusInfo
    {
        private string _pkOut1001;
        private string _patientCode;
        private string _patientName;
        private string _recepTionTime;
        private string _comingStatusDate;
        private string _reserYn;
        private string _deptCode;
        private string _doctorCode;
        private string _deptName;
        private string _doctorName;
        private string _receptionType;
        private string _completeExamination;
        private string _numberOfItemsReq;
        private string _actingPer;
        private string _allEndYn;
        private string _actingTime;
        private string _datasEndYn;

        public NuroOutOrderStatusInfo()
        {
        }

        public NuroOutOrderStatusInfo(string pkOut1001, string patientCode, string patientName, string recepTionTime, string comingStatusDate, string reserYn, string deptCode, string doctorCode, string deptName, string doctorName, string receptionType, string completeExamination, string numberOfItemsReq, string actingPer, string allEndYn, string actingTime, string datasEndYn)
        {
            _pkOut1001 = pkOut1001;
            _patientCode = patientCode;
            _patientName = patientName;
            _recepTionTime = recepTionTime;
            _comingStatusDate = comingStatusDate;
            _reserYn = reserYn;
            _deptCode = deptCode;
            _doctorCode = doctorCode;
            _deptName = deptName;
            _doctorName = doctorName;
            _receptionType = receptionType;
            _completeExamination = completeExamination;
            _numberOfItemsReq = numberOfItemsReq;
            _actingPer = actingPer;
            _allEndYn = allEndYn;
            _actingTime = actingTime;
            _datasEndYn = datasEndYn;
        }


        public string PkOut1001
        {
            get { return _pkOut1001; }
            set { _pkOut1001 = value; }
        }

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

        public string RecepTionTime
        {
            get { return _recepTionTime; }
            set { _recepTionTime = value; }
        }

        public string ComingStatusDate
        {
            get { return _comingStatusDate; }
            set { _comingStatusDate = value; }
        }

        public string ReserYn
        {
            get { return _reserYn; }
            set { _reserYn = value; }
        }

        public string DeptCode
        {
            get { return _deptCode; }
            set { _deptCode = value; }
        }

        public string DoctorCode
        {
            get { return _doctorCode; }
            set { _doctorCode = value; }
        }

        public string DeptName
        {
            get { return _deptName; }
            set { _deptName = value; }
        }

        public string DoctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; }
        }

        public string ReceptionType
        {
            get { return _receptionType; }
            set { _receptionType = value; }
        }

        public string CompleteExamination
        {
            get { return _completeExamination; }
            set { _completeExamination = value; }
        }

        public string NumberOfItemsReq
        {
            get { return _numberOfItemsReq; }
            set { _numberOfItemsReq = value; }
        }

        public string ActingPer
        {
            get { return _actingPer; }
            set { _actingPer = value; }
        }

        public string AllEndYn
        {
            get { return _allEndYn; }
            set { _allEndYn = value; }
        }

        public string ActingTime
        {
            get { return _actingTime; }
            set { _actingTime = value; }
        }

        public string DatasEndYn
        {
            get { return _datasEndYn; }
            set { _datasEndYn = value; }
        }
    }
}

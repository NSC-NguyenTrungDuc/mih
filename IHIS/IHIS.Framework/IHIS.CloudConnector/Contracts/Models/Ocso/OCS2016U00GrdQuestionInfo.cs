using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCS2016U00GrdQuestionInfo
    {
        private String _grpQuestionId;
        private String _reqDate;
        private String _reqGwa;
        private String _reqDoctor;
        private String _consultGwa;
        private String _consultDoctor;
        private String _consultDate;
        private String _consultHospCode;
        private String _bunho;
        private String _finishYn;
        private String _hospCode;
        private String _reqGwaName;
        private String _consultGwaName;
        private String _consultDoctorName;
        private String _consultHospName;
        private String _reqDoctorName;
        private String _reqHospitalName;
        private String _status;

        public String GrpQuestionId
        {
            get { return this._grpQuestionId; }
            set { this._grpQuestionId = value; }
        }

        public String ReqDate
        {
            get { return this._reqDate; }
            set { this._reqDate = value; }
        }

        public String ReqGwa
        {
            get { return this._reqGwa; }
            set { this._reqGwa = value; }
        }

        public String ReqDoctor
        {
            get { return this._reqDoctor; }
            set { this._reqDoctor = value; }
        }

        public String ConsultGwa
        {
            get { return this._consultGwa; }
            set { this._consultGwa = value; }
        }

        public String ConsultDoctor
        {
            get { return this._consultDoctor; }
            set { this._consultDoctor = value; }
        }

        public String ConsultDate
        {
            get { return this._consultDate; }
            set { this._consultDate = value; }
        }

        public String ConsultHospCode
        {
            get { return this._consultHospCode; }
            set { this._consultHospCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String FinishYn
        {
            get { return this._finishYn; }
            set { this._finishYn = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String ReqGwaName
        {
            get { return this._reqGwaName; }
            set { this._reqGwaName = value; }
        }

        public String ConsultGwaName
        {
            get { return this._consultGwaName; }
            set { this._consultGwaName = value; }
        }

        public String ConsultDoctorName
        {
            get { return this._consultDoctorName; }
            set { this._consultDoctorName = value; }
        }

        public String ConsultHospName
        {
            get { return this._consultHospName; }
            set { this._consultHospName = value; }
        }

        public String ReqDoctorName
        {
            get { return this._reqDoctorName; }
            set { this._reqDoctorName = value; }
        }

        public String ReqHospitalName
        {
            get { return this._reqHospitalName; }
            set { this._reqHospitalName = value; }
        }

        public String Status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        public OCS2016U00GrdQuestionInfo() { }

        public OCS2016U00GrdQuestionInfo(String grpQuestionId, String reqDate, String reqGwa, String reqDoctor, String consultGwa, String consultDoctor, String consultDate, String consultHospCode, String bunho, String finishYn, String hospCode, String reqGwaName, String consultGwaName, String consultDoctorName, String consultHospName, String reqDoctorName, String reqHospitalName, String status)
        {
            this._grpQuestionId = grpQuestionId;
            this._reqDate = reqDate;
            this._reqGwa = reqGwa;
            this._reqDoctor = reqDoctor;
            this._consultGwa = consultGwa;
            this._consultDoctor = consultDoctor;
            this._consultDate = consultDate;
            this._consultHospCode = consultHospCode;
            this._bunho = bunho;
            this._finishYn = finishYn;
            this._hospCode = hospCode;
            this._reqGwaName = reqGwaName;
            this._consultGwaName = consultGwaName;
            this._consultDoctorName = consultDoctorName;
            this._consultHospName = consultHospName;
            this._reqDoctorName = reqDoctorName;
            this._reqHospitalName = reqHospitalName;
            this._status = status;
        }

    }
}
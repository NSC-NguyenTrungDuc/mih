using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    public class BAS0270U00GrdBAS0271Info
    {
        private String _doctor;
        private String _doctorName;
        private String _doctorGrade;
        private String _ctorGradeName;
        private String _startDate;
        private String _jubsuYn;
        private String _reserYn;
        private String _endDate;
        private String _ocsStatus;
        private String _licenseBunho;
        private String _sabun;
        private String _doctorSign;
        private String _cpDoctorYn;
        private String _doctorName2;
        private String _mayakLicense;
        private String _tonggyeDoctor;
        private String _commonDoctorYn;
        private String _button;
        private String _doctorColor;
        private String _dataRowState;
        private String _fistnameKanji;
        private String _lastnameKanji;
        private String _fistnameKana;
        private String _lastnameKanna;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String DoctorGrade
        {
            get { return this._doctorGrade; }
            set { this._doctorGrade = value; }
        }

        public String CtorGradeName
        {
            get { return this._ctorGradeName; }
            set { this._ctorGradeName = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String JubsuYn
        {
            get { return this._jubsuYn; }
            set { this._jubsuYn = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        public String OcsStatus
        {
            get { return this._ocsStatus; }
            set { this._ocsStatus = value; }
        }

        public String LicenseBunho
        {
            get { return this._licenseBunho; }
            set { this._licenseBunho = value; }
        }

        public String Sabun
        {
            get { return this._sabun; }
            set { this._sabun = value; }
        }

        public String DoctorSign
        {
            get { return this._doctorSign; }
            set { this._doctorSign = value; }
        }

        public String CpDoctorYn
        {
            get { return this._cpDoctorYn; }
            set { this._cpDoctorYn = value; }
        }

        public String DoctorName2
        {
            get { return this._doctorName2; }
            set { this._doctorName2 = value; }
        }

        public String MayakLicense
        {
            get { return this._mayakLicense; }
            set { this._mayakLicense = value; }
        }

        public String TonggyeDoctor
        {
            get { return this._tonggyeDoctor; }
            set { this._tonggyeDoctor = value; }
        }

        public String CommonDoctorYn
        {
            get { return this._commonDoctorYn; }
            set { this._commonDoctorYn = value; }
        }

        public String Button
        {
            get { return this._button; }
            set { this._button = value; }
        }

        public String DoctorColor
        {
            get { return this._doctorColor; }
            set { this._doctorColor = value; }
        }

        public String DataRowState
        {
            get { return this._dataRowState; }
            set { this._dataRowState = value; }
        }

        public String FistnameKanji
        {
            get { return this._fistnameKanji; }
            set { this._fistnameKanji = value; }
        }

        public String LastnameKanji
        {
            get { return this._lastnameKanji; }
            set { this._lastnameKanji = value; }
        }

        public String FistnameKana
        {
            get { return this._fistnameKana; }
            set { this._fistnameKana = value; }
        }

        public String LastnameKanna
        {
            get { return this._lastnameKanna; }
            set { this._lastnameKanna = value; }
        }

        public BAS0270U00GrdBAS0271Info() { }

        public BAS0270U00GrdBAS0271Info(String doctor, String doctorName, String doctorGrade, String ctorGradeName, String startDate, String jubsuYn, String reserYn, String endDate, String ocsStatus, String licenseBunho, String sabun, String doctorSign, String cpDoctorYn, String doctorName2, String mayakLicense, String tonggyeDoctor, String commonDoctorYn, String button, String doctorColor, String dataRowState, String fistnameKanji, String lastnameKanji, String fistnameKana, String lastnameKanna)
        {
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._doctorGrade = doctorGrade;
            this._ctorGradeName = ctorGradeName;
            this._startDate = startDate;
            this._jubsuYn = jubsuYn;
            this._reserYn = reserYn;
            this._endDate = endDate;
            this._ocsStatus = ocsStatus;
            this._licenseBunho = licenseBunho;
            this._sabun = sabun;
            this._doctorSign = doctorSign;
            this._cpDoctorYn = cpDoctorYn;
            this._doctorName2 = doctorName2;
            this._mayakLicense = mayakLicense;
            this._tonggyeDoctor = tonggyeDoctor;
            this._commonDoctorYn = commonDoctorYn;
            this._button = button;
            this._doctorColor = doctorColor;
            this._dataRowState = dataRowState;
            this._fistnameKanji = fistnameKanji;
            this._lastnameKanji = lastnameKanji;
            this._fistnameKana = fistnameKana;
            this._lastnameKanna = lastnameKanna;
        }

    }
}
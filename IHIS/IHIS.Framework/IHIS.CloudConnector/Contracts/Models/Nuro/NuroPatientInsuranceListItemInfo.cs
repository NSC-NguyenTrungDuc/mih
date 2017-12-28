using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroPatientInsuranceListItemInfo
    {
        private String _status;
        private String _insurCode;
        private String _insurName;
        private String _lastCheckDate;
        private String _startDate;
        private String _patientCode;
        private String _budamjaPatientCode;
        private String _insurJiyeok;

        public String Status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        public String InsurCode
        {
            get { return this._insurCode; }
            set { this._insurCode = value; }
        }

        public String InsurName
        {
            get { return this._insurName; }
            set { this._insurName = value; }
        }

        public String LastCheckDate
        {
            get { return this._lastCheckDate; }
            set { this._lastCheckDate = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String BudamjaPatientCode
        {
            get { return this._budamjaPatientCode; }
            set { this._budamjaPatientCode = value; }
        }

        public String InsurJiyeok
        {
            get { return this._insurJiyeok; }
            set { this._insurJiyeok = value; }
        }

        public NuroPatientInsuranceListItemInfo() { }

        public NuroPatientInsuranceListItemInfo(String status, String insurCode, String insurName, String lastCheckDate, String startDate, String patientCode, String budamjaPatientCode, String insurJiyeok)
        {
            this._status = status;
            this._insurCode = insurCode;
            this._insurName = insurName;
            this._lastCheckDate = lastCheckDate;
            this._startDate = startDate;
            this._patientCode = patientCode;
            this._budamjaPatientCode = budamjaPatientCode;
            this._insurJiyeok = insurJiyeok;
        }

    }
}
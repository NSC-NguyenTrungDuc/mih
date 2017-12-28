using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0270U00GrdBAS0272Info
    {
        private String _doctor;
        private String _doctorGwa;
        private String _doctorGwaName;
        private String _mainGwaYn;
        private String _startDate;
        private String _endDate;
        private String _sabun;
        private String _endYn;
        private String _outDiscussYn;
        private String _reserOutYn;
        private String _dataRowState;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String DoctorGwa
        {
            get { return this._doctorGwa; }
            set { this._doctorGwa = value; }
        }

        public String DoctorGwaName
        {
            get { return this._doctorGwaName; }
            set { this._doctorGwaName = value; }
        }

        public String MainGwaYn
        {
            get { return this._mainGwaYn; }
            set { this._mainGwaYn = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        public String Sabun
        {
            get { return this._sabun; }
            set { this._sabun = value; }
        }

        public String EndYn
        {
            get { return this._endYn; }
            set { this._endYn = value; }
        }

        public String OutDiscussYn
        {
            get { return this._outDiscussYn; }
            set { this._outDiscussYn = value; }
        }

        public String ReserOutYn
        {
            get { return this._reserOutYn; }
            set { this._reserOutYn = value; }
        }

        public String DataRowState
        {
            get { return this._dataRowState; }
            set { this._dataRowState = value; }
        }

        public BAS0270U00GrdBAS0272Info() { }

        public BAS0270U00GrdBAS0272Info(String doctor, String doctorGwa, String doctorGwaName, String mainGwaYn, String startDate, String endDate, String sabun, String endYn, String outDiscussYn, String reserOutYn, String dataRowState)
        {
            this._doctor = doctor;
            this._doctorGwa = doctorGwa;
            this._doctorGwaName = doctorGwaName;
            this._mainGwaYn = mainGwaYn;
            this._startDate = startDate;
            this._endDate = endDate;
            this._sabun = sabun;
            this._endYn = endYn;
            this._outDiscussYn = outDiscussYn;
            this._reserOutYn = reserOutYn;
            this._dataRowState = dataRowState;
        }

    }
}
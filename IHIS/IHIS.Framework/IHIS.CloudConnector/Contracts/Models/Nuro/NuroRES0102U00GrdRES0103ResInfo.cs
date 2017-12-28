using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroRES0102U00GrdRES0103ResInfo
    {
        private String _doctor;
        private String _jinryoPreDate;
        private String _resAmStartHhmm;
        private String _resAmEndHhmm;
        private String _resPmStartHhmm;
        private String _resPmEndHhmm;
        private String _remark;
        private String _amGwaRoom;
        private String _pmGwaRoom;
        private String _dataRowState;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String JinryoPreDate
        {
            get { return this._jinryoPreDate; }
            set { this._jinryoPreDate = value; }
        }

        public String ResAmStartHhmm
        {
            get { return this._resAmStartHhmm; }
            set { this._resAmStartHhmm = value; }
        }

        public String ResAmEndHhmm
        {
            get { return this._resAmEndHhmm; }
            set { this._resAmEndHhmm = value; }
        }

        public String ResPmStartHhmm
        {
            get { return this._resPmStartHhmm; }
            set { this._resPmStartHhmm = value; }
        }

        public String ResPmEndHhmm
        {
            get { return this._resPmEndHhmm; }
            set { this._resPmEndHhmm = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String AmGwaRoom
        {
            get { return this._amGwaRoom; }
            set { this._amGwaRoom = value; }
        }

        public String PmGwaRoom
        {
            get { return this._pmGwaRoom; }
            set { this._pmGwaRoom = value; }
        }

        public String DataRowState
        {
            get { return this._dataRowState; }
            set { this._dataRowState = value; }
        }

        public NuroRES0102U00GrdRES0103ResInfo() { }

        public NuroRES0102U00GrdRES0103ResInfo(String doctor, String jinryoPreDate, String resAmStartHhmm, String resAmEndHhmm, String resPmStartHhmm, String resPmEndHhmm, String remark, String amGwaRoom, String pmGwaRoom, String dataRowState)
        {
            this._doctor = doctor;
            this._jinryoPreDate = jinryoPreDate;
            this._resAmStartHhmm = resAmStartHhmm;
            this._resAmEndHhmm = resAmEndHhmm;
            this._resPmStartHhmm = resPmStartHhmm;
            this._resPmEndHhmm = resPmEndHhmm;
            this._remark = remark;
            this._amGwaRoom = amGwaRoom;
            this._pmGwaRoom = pmGwaRoom;
            this._dataRowState = dataRowState;
        }

    }
}
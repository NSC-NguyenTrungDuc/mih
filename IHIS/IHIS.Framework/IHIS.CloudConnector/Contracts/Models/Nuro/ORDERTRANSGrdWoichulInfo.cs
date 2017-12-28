using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdWoichulInfo
    {
        private String _fkinp1001;
        private String _fkOutDate;
        private String _bunho;
        private String _outDate;
        private String _outTime;
        private String _inHopeDate;
        private String _inHopeTime;
        private String _inTrueDate;
        private String _inTrueTime;
        private String _outObjectText;
        private String _startDate;
        private String _endDate;
        private String _actingYn;
        private String _selectYn;
        private String _sendYn;
        private String _seq;

        public String Fkinp1001
        {
            get { return this._fkinp1001; }
            set { this._fkinp1001 = value; }
        }

        public String FkOutDate
        {
            get { return this._fkOutDate; }
            set { this._fkOutDate = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String OutDate
        {
            get { return this._outDate; }
            set { this._outDate = value; }
        }

        public String OutTime
        {
            get { return this._outTime; }
            set { this._outTime = value; }
        }

        public String InHopeDate
        {
            get { return this._inHopeDate; }
            set { this._inHopeDate = value; }
        }

        public String InHopeTime
        {
            get { return this._inHopeTime; }
            set { this._inHopeTime = value; }
        }

        public String InTrueDate
        {
            get { return this._inTrueDate; }
            set { this._inTrueDate = value; }
        }

        public String InTrueTime
        {
            get { return this._inTrueTime; }
            set { this._inTrueTime = value; }
        }

        public String OutObjectText
        {
            get { return this._outObjectText; }
            set { this._outObjectText = value; }
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

        public String ActingYn
        {
            get { return this._actingYn; }
            set { this._actingYn = value; }
        }

        public String SelectYn
        {
            get { return this._selectYn; }
            set { this._selectYn = value; }
        }

        public String SendYn
        {
            get { return this._sendYn; }
            set { this._sendYn = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public ORDERTRANSGrdWoichulInfo() { }

        public ORDERTRANSGrdWoichulInfo(String fkinp1001, String fkOutDate, String bunho, String outDate, String outTime, String inHopeDate, String inHopeTime, String inTrueDate, String inTrueTime, String outObjectText, String startDate, String endDate, String actingYn, String selectYn, String sendYn, String seq)
        {
            this._fkinp1001 = fkinp1001;
            this._fkOutDate = fkOutDate;
            this._bunho = bunho;
            this._outDate = outDate;
            this._outTime = outTime;
            this._inHopeDate = inHopeDate;
            this._inHopeTime = inHopeTime;
            this._inTrueDate = inTrueDate;
            this._inTrueTime = inTrueTime;
            this._outObjectText = outObjectText;
            this._startDate = startDate;
            this._endDate = endDate;
            this._actingYn = actingYn;
            this._selectYn = selectYn;
            this._sendYn = sendYn;
            this._seq = seq;
        }

    }
}
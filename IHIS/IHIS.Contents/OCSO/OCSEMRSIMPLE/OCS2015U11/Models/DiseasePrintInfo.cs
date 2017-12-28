using System;

namespace EmrDocker.Models
{
    public class DiseasePrintInfo
    {
        private String _disease;
        private String _startDate;
        private String _endDate;
        private String _reason;

        public string Disease
        {
            get { return _disease; }
            set { _disease = value; }
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

        public DiseasePrintInfo()
        {
        }

        public DiseasePrintInfo(string disease, string startDate, string endDate, string reason)
        {
            _disease = disease;
            _startDate = startDate;
            _endDate = endDate;
            _reason = reason;
        }
    }
}
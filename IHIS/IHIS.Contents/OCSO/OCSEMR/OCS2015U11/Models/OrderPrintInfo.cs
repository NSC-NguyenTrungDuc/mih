using System;

namespace EmrDocker.Models
{
    public class OrderPrintInfo
    {
        private String _orderClassification;
        private String _doctorName;
        private String _orderName; 
        private String _orderContent;
        private String _dosage;
        //MED-15473
        private String _dvTime;
        private String _mixSet;
        private String _jusaName;
        private String _unequalDosage;
        private String _hopeDate;
        private String _comment;
        private String _numberOfDay;
        private bool isMixSet;
        private bool isComment;
        private bool isHopeDate;
        private bool isUnequalDosage;
        private bool isDosage;  
        private bool isInjectionGuide;  
        private bool isBlank = false;  
      

        public string OrderClassification
        {
            get { return _orderClassification; }
            set { _orderClassification = value; }
        }

        public string DoctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; }
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

        public string DvTime
        {
            get { return _dvTime; }
            set { _dvTime = value; }
        }

        public string MixSet
        {
            get { return _mixSet; }
            set { _mixSet = value; }
        }

        public string JusaName
        {
            get { return _jusaName; }
            set { _jusaName = value; }
        }

        public string UnequalDosage
        {
            get { return _unequalDosage; }
            set { _unequalDosage = value; }
        }

        public string HopeDate
        {
            get { return _hopeDate; }
            set { _hopeDate = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public bool IsMixSet
        {
            get { return isMixSet; }
            set { isMixSet = value; }
        }

        public bool IsComment
        {
            get { return isComment;  }
            set { isComment = value; }
        }

        public bool IsHopeDate
        {
            get { return isHopeDate; }
            set { isHopeDate = value; }
        }

        public string NumberOfDay
        {
            get { return _numberOfDay; }
            set { _numberOfDay = value; }
        }

        public bool IsUnequalDosage
        {
            get { return isUnequalDosage; }
            set { isUnequalDosage = value; }
        }

        public bool IsDosage
        {
            get { return isDosage; }
            set { isDosage = value; }
        }

        public bool IsInjectionGuide
        {
            get { return isInjectionGuide; }
            set { isInjectionGuide = value; }
        }

        public bool IsBlank
        {
            get { return isBlank; }
            set { isBlank = value; }
        }

        public OrderPrintInfo()
        {
        }

        public OrderPrintInfo(string orderClassification, string doctorName, string orderName, string orderContent, string dosage, string dvTime, string mixSet, string jusaName, string unequalDosage, string hopeDate, string comment, string numberOfDay, bool isMixSet, bool isComment, bool isHopeDate, bool isUnequalDosage, bool isDosage, bool isInjectionGuide, bool isBlank)
        {
            _orderClassification = orderClassification;
            _doctorName = doctorName;
            _orderName = orderName;
            _orderContent = orderContent;
            _dosage = dosage;
            _dvTime = dvTime;
            _mixSet = mixSet;
            _jusaName = jusaName;
            _unequalDosage = unequalDosage;
            _hopeDate = hopeDate;
            _comment = comment;
            _numberOfDay = numberOfDay;
            this.isMixSet = isMixSet;
            this.isComment = isComment;
            this.isHopeDate = isHopeDate;
            this.isUnequalDosage = isUnequalDosage;
            this.isDosage = isDosage;
            this.isInjectionGuide = isInjectionGuide;
            this.isBlank = isBlank;
        }
    }
}
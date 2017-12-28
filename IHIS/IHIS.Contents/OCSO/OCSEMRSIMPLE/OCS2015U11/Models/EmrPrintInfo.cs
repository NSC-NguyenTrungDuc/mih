using System;
using System.Collections.Generic;

namespace EmrDocker.Models
{
    public class EmrPrintInfo
    {
        private String _examinationDate;
        private List<TagPrintInfo> _tagPrintInfos;
        private List<OrderPrintInfo> _orderPrintInfos;
        
        public string ExaminationDate
        {
            get { return _examinationDate; }
            set { _examinationDate = value; }
        }

        public List<TagPrintInfo> TagPrintInfos
        {
            get { return _tagPrintInfos; }
            set { _tagPrintInfos = value; }
        }

        public List<OrderPrintInfo> OrderPrintInfos
        {
            get { return _orderPrintInfos; }
            set { _orderPrintInfos = value; }
        }

        public EmrPrintInfo()
        {
        }

        public EmrPrintInfo(string examinationDate, List<TagPrintInfo> tagPrintInfos, List<OrderPrintInfo> orderPrintInfos)
        {
            _examinationDate = examinationDate;
            _tagPrintInfos = tagPrintInfos;
            _orderPrintInfos = orderPrintInfos;
        }
    }
}
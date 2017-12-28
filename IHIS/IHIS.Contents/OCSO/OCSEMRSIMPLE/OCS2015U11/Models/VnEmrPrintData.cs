using System;
using System.Collections.Generic;

namespace EmrDocker.Models
{
    public class VnEmrPrintData
    {
        private List<VnEmrPrintPageInfo> _emrPrintPageInfos;

        public List<VnEmrPrintPageInfo> EmrPrintPageInfos
        {
            get { return _emrPrintPageInfos; }
            set { _emrPrintPageInfos = value; }
        }

        public VnEmrPrintData()
        {
        }

        public VnEmrPrintData(List<VnEmrPrintPageInfo> emrPrintPageInfos)
        {
            _emrPrintPageInfos = emrPrintPageInfos;
        }
    }
}
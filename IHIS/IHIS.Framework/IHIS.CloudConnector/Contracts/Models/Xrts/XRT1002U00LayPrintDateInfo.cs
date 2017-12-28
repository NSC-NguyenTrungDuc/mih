using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT1002U00LayPrintDateInfo
    {
        private String _printDate;

        public String PrintDate
        {
            get { return this._printDate; }
            set { this._printDate = value; }
        }

        public XRT1002U00LayPrintDateInfo() { }

        public XRT1002U00LayPrintDateInfo(String printDate)
        {
            this._printDate = printDate;
        }

    }
}
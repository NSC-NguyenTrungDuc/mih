using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class BundleItemInfo
    {
        private string _classCode = "";
        private string _hangmogCode = "";
        private string _number;
        private string _numberCode = "";
        private int _bundleNumber;

        public string ClassCode
        {
            get { return _classCode; }
            set { _classCode = value; }
        }

        public string HangmogCode
        {
            get { return _hangmogCode; }
            set { _hangmogCode = value; }
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string NumberCode
        {
            get { return _numberCode; }
            set { _numberCode = value; }
        }

        public int BundleNumber
        {
            get { return _bundleNumber; }
            set { _bundleNumber = value; }
        }

        public BundleItemInfo()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class BundleItemInfo
    {
        private string _classCode = "";
        private int _bundleNumber;
        private string _hangmogCode = "";

        public string ClassCode
        {
            get { return _classCode; }
            set { _classCode = value; }
        }

        public int BundleNumber
        {
            get { return _bundleNumber; }
            set { _bundleNumber = value; }
        }

        public string HangmogCode
        {
            get { return _hangmogCode; }
            set { _hangmogCode = value; }
        }

        public BundleItemInfo()
        {
        }

        public BundleItemInfo(string classCode, int bundleNumber, string hangmogCode)
        {
            this._classCode = classCode;
            this._bundleNumber = bundleNumber;
            this._hangmogCode = hangmogCode;
        }
    }
}

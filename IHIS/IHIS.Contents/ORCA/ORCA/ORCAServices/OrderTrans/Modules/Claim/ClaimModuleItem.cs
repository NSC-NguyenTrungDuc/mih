using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class ClaimModuleItem
    {
        private string _doctorId = "";
        private string _gwaName = "";
        private string _reserMemo = "";
        private DateTime _performTime;
        private DateTime _registTime;
        private List<BundleItemInfo> _bundleListItem;

        public string DoctorId
        {
            get { return _doctorId; }
            set { _doctorId = value; }
        }

        public string GwaName
        {
            get { return _gwaName; }
            set { _gwaName = value; }
        }

        public string ReserMemo
        {
            get { return _reserMemo; }
            set { _reserMemo = value; }
        }

        public DateTime PerformTime
        {
            get { return _performTime; }
            set { _performTime = value; }
        }

        public DateTime RegistTime
        {
            get { return _registTime; }
            set { _registTime = value; }
        }

        public List<BundleItemInfo> BundleListItem
        {
            get { return _bundleListItem; }
            set { _bundleListItem = value; }
        }

        public ClaimModuleItem()
        { }
    }
}
